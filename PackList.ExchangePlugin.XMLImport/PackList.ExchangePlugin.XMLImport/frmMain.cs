using BSW_ExchangeShared;
using BSW_ExchangeData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PackList.ExchangePlugin.XMLImport
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;

        private string _sourceFolder = string.Empty;
        private string _processedFolder = string.Empty;
        private string _errorFolder = string.Empty;
        private string _ext = string.Empty;

        public frmMain(string profileID)
        {
            InitializeComponent();
            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                profileID = "8";

                this.Text = "Running Import profile - " + profileID;

                //try to parse the prfile id string to byte
                _ProfileID = byte.Parse(profileID);

                //lest start the timer - we use this only to give the application some time to load first
                _timer = new Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = 100;
                _timer.Enabled = true;
                _timer.Start();
            }
            catch (Exception exp)
            {
                lstInfo.Items.Add(exp.Message);
                //no need to do any error handling at this point
                this.Dispose();
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Enabled = false;
            _timer.Dispose();

            bool hadError = false;
            try
            {
                string msg = string.Empty;

                //we need to load the profile settings
                using (ProfileConfigFolderController controller = new ProfileConfigFolderController())
                {
                    if (controller.Get(new ProfileConfigFolderModel { ProfileID = _ProfileID }, ref msg))
                    {
                        if (controller.Count > 0)
                        {
                            //set all the needed settings
                            _sourceFolder = controller[0].SourceFolder;
                            _processedFolder = controller[0].ProcessedFolder;
                            _errorFolder = controller[0].ErrorFolder;
                            _ext = controller[0].FileExtention.Trim();

                            if (!ProcessFiles())
                                hadError = true;
                        }
                        else
                        {
                            hadError = true;
                            EventLog.LogProfileEvent(_ProfileID, "Folder Profile settings not found", EventLogType.Error);
                        }
                    }
                    else
                    {
                        hadError = true;
                        EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                hadError = true;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }
            if (hadError)
                EventLog.LogProfileEvent(_ProfileID, "Process Failed - view history for detail", EventLogType.ProcessFailed);
            else
                EventLog.LogProfileEvent(_ProfileID, "Process Successfully complete", EventLogType.ProcessComplete);

            //we close the application
            this.Dispose();
        }

        /// <summary>
        /// Load all the files found in the source folder and process them
        /// </summary>
        /// <returns></returns>
        private bool ProcessFiles()
        {
            bool result = true;
            try
            {
                //first we need to check if all the directories exist or not
                if (!Directory.Exists(_sourceFolder)) Directory.CreateDirectory(_sourceFolder);
                if (!Directory.Exists(_processedFolder)) Directory.CreateDirectory(_processedFolder);
                if (!Directory.Exists(_errorFolder)) Directory.CreateDirectory(_errorFolder);

                //see if we have any new files to process
                string[] files = Directory.GetFiles(_sourceFolder, "*." + _ext);
                EventLog.LogProfileEvent(_ProfileID, "Found - " + Convert.ToString(files.Length) + " new file(s) to process", EventLogType.Information);

                foreach (string processFile in files)
                {
                    //first lets see if we can access the file
                    if (IsFileAccessable(processFile))
                    {
                        try
                        {
                            XDocument doc = XDocument.Load(processFile);
                            //we need to due some minor validations on the file
                            string msg = string.Empty;
                            bool validationPassed = true;
                            string validationResults = string.Empty;                            
                            string clientRef2 = string.Empty;
                            string messageID = string.Empty;
                            long? batchID = null;
                            int version = 1;

                            // get the date modified of the file
                            DateTime messageDT; 
                            try
                            {
                                messageDT = new System.IO.FileInfo(processFile).LastWriteTime;
                            }
                            catch
                            {
                                messageDT = DateTime.Now;
                            }                            

                            List<ValidationError> valErrors = new List<ValidationError>();
                            using (PackListValidation validator = new PackListValidation())
                            {
                                validator.ProfileID = _ProfileID;
                                validationPassed = validator.ValidateStructure(doc, validationResults);
                                if (!validationPassed)
                                    valErrors.Add(new ValidationError { Message = validationResults, MessageClass = MessageClass.FailedStructuraError });
                                else
                                {
                                    validationPassed = validator.ValidateRequiredFields(doc, valErrors, true, ref messageID);
                                    validationPassed = validationPassed && validator.GetMessageID(doc, ref clientRef2, valErrors);
                                }
                            }

                            //get the batch and version this file must be linked to
                            if (!string.IsNullOrEmpty(messageID))
                            {
                                using (ImportBatchController controller = new ImportBatchController())
                                {
                                    if (controller.Get(messageID, ref msg))
                                    {
                                        if (controller.Count > 0)
                                        {
                                            batchID = controller[0].ImportBatchID;
                                            version = Convert.ToInt32(controller[0].Version);
                                        }
                                    }
                                    else
                                        valErrors.Add(new ValidationError { Message = msg, MessageClass = MessageClass.FailedInternalError });
                                }
                            }

                            //insert the file into the database
                            using (ImportMessageModel model = new ImportMessageModel())
                            {
                                model.ClientReference1 = Path.GetFileName(processFile);
                                model.MessageTypeID = (byte)MessageType.PackListImport;
                                model.ProfileID = _ProfileID;
                                model.XMLMessage = doc.ToString();

                                // remove the namespace node for ease of SQL querying
                                string text = model.XMLMessage;

                                model.XMLMessage = text;
                                model.ClientReference2 = clientRef2;
                                model.MessageDt = messageDT;
                                model.ImportBatchID = batchID;
                                model.Version = version;

                                if (validationPassed)
                                    model.MessageStatus = (byte)MessageStatus.ReceivedReady;
                                else
                                    model.MessageStatus = (byte)MessageStatus.ReceivedFail;

                                using (ImportMessageController controller = new ImportMessageController())
                                {
                                    if (controller.Insert(model, ref msg))
                                    {
                                        //check what history do we need to log
                                        using (ImportMessageHistoryController histcont = new ImportMessageHistoryController())
                                        {
                                            if (validationPassed)
                                            {
                                                ImportMessageHistoryModel histModel = new ImportMessageHistoryModel
                                                {
                                                    Description = "File received successfully",
                                                    ImportMessageID = model.MessageID,
                                                    MessageStatus = (byte)MessageStatus.ReceivedReady,
                                                    MessageClass = (byte)MessageClass.Sucess
                                                };
                                                histcont.Insert(histModel, ref msg);
                                            }
                                            else
                                            {
                                                foreach (ValidationError err in valErrors)
                                                {
                                                    ImportMessageHistoryModel histModel = new ImportMessageHistoryModel
                                                    {
                                                        Description = err.Message,
                                                        ImportMessageID = model.MessageID,
                                                        MessageStatus = (byte)err.MessageClass
                                                    };
                                                    histcont.Insert(histModel, ref msg);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                                        result = false;
                                    }
                                }
                            }

                            if (result)
                            {
                                //finally move the file to the processed folder
                                File.Move(processFile, _processedFolder + @"\" + Path.GetFileName(processFile));
                            }
                            else
                            {
                                //move this file to the error folder
                                File.Move(processFile, _errorFolder + @"\" + Path.GetFileName(processFile));
                            }
                        }
                        catch (Exception exp)
                        {
                            //file is not a valid xml document
                            EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
                            //move this file to the error folder
                            File.Move(processFile, _errorFolder + @"\" + Path.GetFileName(processFile));
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                result = false;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }

            return result;
        }

        /// <summary>
        /// Check if the current file is Accessable - or not
        /// </summary>
        /// <param name="filePath">File name and path</param>
        /// <returns>Result indicating if the file can be accessed</returns>
        private bool IsFileAccessable(string filePath)
        {
            try
            {
                using (Stream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    try
                    {
                        if (stream != null)
                        {
                            
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        stream.Flush();
                        stream.Close();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                return false;
            }
            catch (IOException ex)
            {
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                return false;
            }

            return true;
        }
    }
}
