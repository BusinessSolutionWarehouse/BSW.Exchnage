using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using BSW_ExchangeShared;
using BSW_ExchangeData;
using BSWFTPClient;
using System.Xml.Linq;

namespace SailingSchedule.ExhangePlugin.XMLImport
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;

        private string ftpHost = string.Empty;
        private string ftpUid = string.Empty;
        private string ftpPwd = string.Empty;
        private string ftpFolder = string.Empty;
        private List<ValidationError> valErrors = new List<ValidationError>();
        private DateTime? lastProcessed = null;

        public frmMain(string profileID)
        {
            InitializeComponent();
            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                profileID = "5";

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
                using (ProfileConfigFTPController controller = new ProfileConfigFTPController())
                {
                    if (controller.Get(new ProfileConfigFTPModel { ProfileID = _ProfileID }, ref msg))
                    {
                        if (controller.Count > 0)
                        {
                            ftpHost = controller[0].ServerAddress;
                            ftpUid = controller[0].UserName;
                            ftpPwd = controller[0].Password;
                            ftpFolder = controller[0].FtpFolder;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(ftpHost))
                {
                    using (ImportMessageController controller = new ImportMessageController())
                    {
                        if (controller.GetLast(new ImportMessageModel { ProfileID = _ProfileID }, ref msg))
                        {
                            if (controller.Count > 0)
                            {
                                // we have processed files previously so get last date
                                // messageDt field = last processed file creation date on FTP site
                                lastProcessed = controller[0].MessageDt;
                            }
                        }
                    }

                    EventLog.LogProfileEvent(_ProfileID, "Start Process Files", EventLogType.Information);

                    if (!ProcessFiles(lastProcessed))
                        hadError = true;

                    EventLog.LogProfileEvent(_ProfileID, "Finish Process Files", EventLogType.Information);

                }
                else
                {
                    EventLog.LogProfileEvent(_ProfileID, "Folder Details not found for this profile.", EventLogType.Error);
                    EventLog.LogProfileEvent(_ProfileID, "Processing Complete - With Errors", EventLogType.ProcessFailed);
                    this.Dispose();
                    return;
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
        private bool ProcessFiles(DateTime? lastProcessed)
        {
            bool result = true;
            List<RemoteFile> remoteFileList = new List<RemoteFile>();
            try
            {
                EventLog.LogProfileEvent(_ProfileID, "Get FTP Details", EventLogType.ProcessComplete);

                using (FTP ftpSite = new FTP())
                {
                    ftpSite.ExceptionRaised -= ftpSite_ExceptionRaised;
                    ftpSite.ExceptionRaised += new FTP.ExceptionRaisedDelegate(ftpSite_ExceptionRaised);

                    ftpSite.Host = ftpHost;
                    ftpSite.UserName = ftpUid;
                    ftpSite.Password = ftpPwd;

                    remoteFileList = ftpSite.ReadRemoteXML(ftpFolder, lastProcessed) as List<RemoteFile>;
                }

                if (remoteFileList.Count() == 0)
                {
                    // nothing to process
                    return result;
                }

                EventLog.LogProfileEvent(_ProfileID, "Found - " + Convert.ToString(remoteFileList.Count()) + " new file(s) to process", EventLogType.Information);

                foreach (RemoteFile processFile in remoteFileList)
                {
                    try
                    {
                        XDocument doc = XDocument.Parse(processFile.FileContents);
                        //we need to due some minor validations on the file
                        string msg = string.Empty;
                        bool validationPassed = true;
                        string validationResults = string.Empty;
                        string clientRef2 = string.Empty;
                        string vesselvisitID = string.Empty;
                        long? batchID = null;
                        int version = 1;

                        // get the date modified of the file
                        DateTime? messageDT = processFile.FileCreated;

                        List<ValidationError> valErrors = new List<ValidationError>();
                        using (SailingScheduleValidation validator = new SailingScheduleValidation())
                        {
                            validator.ProfileID = _ProfileID;
                            validationPassed = validator.ValidateStructure(doc, validationResults);
                            if (!validationPassed)
                                valErrors.Add(new ValidationError { Message = validationResults, MessageClass = MessageClass.FailedStructuraError });
                            else
                            {
                                validationPassed = validator.ValidateRequiredFields(doc, valErrors, true, ref vesselvisitID);
                                validationPassed = validationPassed && validator.GetMessageID(doc, ref clientRef2, valErrors);
                            }
                        }

                        //get the batch and version this file must be linked to
                        if (!string.IsNullOrEmpty(vesselvisitID))
                        {
                            using (ImportBatchController controller = new ImportBatchController())
                            {
                                if (controller.Get(vesselvisitID, ref msg))
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
                            model.ClientReference1 = processFile.FileName;
                            model.MessageTypeID = (byte)MessageType.SailingScheduleImport;
                            model.ProfileID = _ProfileID;
                            model.XMLMessage = doc.ToString();

                            // remove the namespace node for ease of SQL querying
                            string text = model.XMLMessage;
                            text = text.Remove(0, "<argo:snx xmlns:argo=\"http://www.navis.com/argo\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.navis.com/argo snx.xsd\">\r\n  ".Length);
                            text = text.Remove(text.Length - "\r\n</argo:snx>".Length, "\r\n</argo:snx>".Length);

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
                                    //insert was successful
                                    //delete remote file
                                    using (FTP ftpSite = new FTP())
                                    {
                                        ftpSite.ExceptionRaised -= ftpSite_ExceptionRaised;
                                        ftpSite.ExceptionRaised += new FTP.ExceptionRaisedDelegate(ftpSite_ExceptionRaised);

                                        ftpSite.Host = ftpHost;
                                        ftpSite.UserName = ftpUid;
                                        ftpSite.Password = ftpPwd;

                                        if (!ftpSite.DeleteRemoteFile(ftpFolder, processFile.FileName))
                                        {
                                            // file was not successfully deleted
                                            EventLog.LogEvent("SailingSchedule.XMLImport", "Delete remote file " + processFile.FileName + " failed.", EventLogType.Warning);

                                            // try moving to error folder
                                            if (!ftpSite.MoveRemoteFile(ftpFolder, processFile.FileName))
                                            {
                                                EventLog.LogEvent("SailingSchedule.XMLImport", "Move remote file " + processFile.FileName + " failed.", EventLogType.Warning);
                                            }
                                        }
                                    }

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
                                    // handle remote file
                                    using (FTP ftpSite = new FTP())
                                    {
                                        ftpSite.ExceptionRaised -= ftpSite_ExceptionRaised;
                                        ftpSite.ExceptionRaised += new FTP.ExceptionRaisedDelegate(ftpSite_ExceptionRaised);

                                        ftpSite.Host = ftpHost;
                                        ftpSite.UserName = ftpUid;
                                        ftpSite.Password = ftpPwd;

                                        // try moving to error folder
                                        if (!ftpSite.MoveRemoteFile(ftpFolder, processFile.FileName))
                                        {
                                            EventLog.LogEvent("SailingSchedule.XMLImport", "Move remote file " + processFile.FileName + " failed.", EventLogType.Warning);
                                        }
                                    }
                                    EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                                    result = false;
                                }
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        //handle remote file
                        using (FTP ftpSite = new FTP())
                        {
                            ftpSite.ExceptionRaised -= ftpSite_ExceptionRaised;
                            ftpSite.ExceptionRaised += new FTP.ExceptionRaisedDelegate(ftpSite_ExceptionRaised);

                            ftpSite.Host = ftpHost;
                            ftpSite.UserName = ftpUid;
                            ftpSite.Password = ftpPwd;

                            // try moving to error folder
                            if (!ftpSite.MoveRemoteFile(ftpFolder, processFile.FileName))
                            {
                                EventLog.LogEvent("SailingSchedule.XMLImport", "Move remote file " + processFile.FileName + " failed.", EventLogType.Warning);
                            }
                        }

                        //file is not a valid xml document
                        EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
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
        /// <param name="filePath">Fiel name and path</param>
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

        private void ftpSite_ExceptionRaised(string errorMsg)
        {
            valErrors.Add(new ValidationError { Message = errorMsg, MessageClass = MessageClass.FailedInternalError });
        }
    }
}
