using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Linq;
using BSW_ExchangeData;
using BSW_ExchangeShared;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using BSWFTPClient;


namespace BMWCN2Extract
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;
        private bool hadError = false;
        private List<ValidationError> valErrors = new List<ValidationError>();
        private string ftpHost = string.Empty;
        private string ftpUid = string.Empty;
        private string ftpPwd = string.Empty;
        private string ftpFolder = string.Empty;

        public frmMain(string profileID)
        {
            InitializeComponent();

            this.Text = "BMW CN2 Data Export - Profile (Unknown)";
            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                //profileID = "4";

                this.Text = "BMW CN2 Data Export - Profile ( " + profileID + ")";

                //try to parse the prfile id string to byte
                _ProfileID = byte.Parse(profileID);

                //lest start the timer - we use this only to give the application some time to load firts
                _timer = new Timer();
                _timer.Tick += new EventHandler(_timer_Tick);
                _timer.Interval = 100;
                _timer.Enabled = true;
                _timer.Start();

            }
            catch (Exception exp)
            {
                //no need to do any error handeling at this point
                this.Dispose();
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            //stop and disable the timer
            _timer.Stop();
            _timer.Enabled = false;
            _timer.Dispose();

            string msg = string.Empty;
            bool result = true;
            try
            {
                //get the profile details
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

                if (string.IsNullOrEmpty(ftpHost))
                {
                    EventLog.LogProfileEvent(_ProfileID, "FTP Details not found for this profile.", EventLogType.Error);
                    EventLog.LogProfileEvent(_ProfileID, "Processing Complete - With Errors", EventLogType.ProcessFailed);
                    this.Dispose();
                    return;
                }
                EventLog.LogProfileEvent(_ProfileID,"Processing Start. Extracting CN2 data from Newtrack and Compu-Clearing..", EventLogType.ProcessStart);
                //we first extract any new data..
                List<NTCN2DataModel> lstManifest = new List<NTCN2DataModel>();
                using (NTCN2DataController controller = new NTCN2DataController())
                {
                    result = controller.LoadManifests(ref msg);
                    if (result)
                    {
                        lstManifest.AddRange(controller);
                        EventLog.LogProfileEvent(_ProfileID, "Found " + lstManifest.Count + " manifest to process", EventLogType.Information);
                    }
                    else
                    {
                        hadError = true;
                        EventLog.LogProfileEvent(_ProfileID, "Error loading manifests - " + msg, EventLogType.Error);
                    }
                }

                if (!hadError)
                {
                    foreach (NTCN2DataModel model in lstManifest)
                    {
                        Application.DoEvents();
                        ExtractData(model.ManifestNo);
                        //we need to wait atleast 1 second before processing the next manifest - due to the file naming reqierment
                        System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
                    }
                    EventLog.LogProfileEvent(_ProfileID, "Data extract complete. Processing export messages..", EventLogType.Information);
                    //Send the new file/ files to the FTP Folder
                    ProcessMessage();
                }
            }
            catch (Exception exp)
            {
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
                hadError = true;
            }

            //Finally update the profile
            if (hadError)
            {
                EventLog.LogProfileEvent(_ProfileID, "Processing Complete - With Errors", EventLogType.ProcessFailed);
            }
            else
            {
                EventLog.LogProfileEvent(_ProfileID, "Processing Complete.", EventLogType.ProcessComplete);
            }

            //we close the applicaiton no matter what
            this.Dispose();
        }

        /// <summary>
        /// Extract Data from Newtrack and Convert into xml Format
        /// </summary>
        private void ExtractData(string manifestNo)
        {
            try
            {
                string msg = string.Empty;
                bool result = true;
                //get all the new data to bew extracted
                List<NTCN2DataModel> lstData = new List<NTCN2DataModel>();
                using (NTCN2DataController controller = new NTCN2DataController())
                {
                    result = controller.Get(manifestNo, ref msg);
                    if (result)
                        lstData.AddRange(controller);
                    else
                    {
                        hadError = true;
                        valErrors.Add(new ValidationError { Message = msg, MessageClass = MessageClass.FailedInternalError });
                    }
                }
                //create a new batch for this data(BatchNumber = File name)
                if (result)
                {
                    
                    //lest first see if we found any thing
                    if (lstData.Count > 0)
                    {
                        using (ExportMessageModel newMessage = new ExportMessageModel())
                        {
                            //convert the list object to XMl
                            var serializer = new XmlSerializer(typeof(List<NTCN2DataModel>), new XmlRootAttribute("CN2Data"));
                            using (var stream = new StringWriter())
                            {
                                serializer.Serialize(stream, lstData);
                                newMessage.XMLMessage = stream.ToString();
                            }

                            //we need to create a new export batch
                            string clientRef = string.Empty;
                            using (ExportMessageBatchModel batchModel = new ExportMessageBatchModel())
                            {
                                clientRef = "VCN2" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".DAT";
                                batchModel.BatchUniqueKey = clientRef;
                                using (ExportMessageBatchController controller = new ExportMessageBatchController())
                                {
                                    result = controller.Insert(batchModel, ref msg);
                                    if (result)
                                    {
                                        newMessage.ExportBatchID = batchModel.ExportBatchID;
                                        newMessage.MessageVersion = 1;
                                    }
                                    else
                                    {
                                        hadError = true;
                                        valErrors.Add(new ValidationError { Message = msg, MessageClass = MessageClass.FailedInternalError });
                                    }
                                }
                            }
                            //if we had no errors - we can finally create the new export message
                            newMessage.ProfileID = _ProfileID;
                            newMessage.MessageTypeID = 5; //BMW CN2 Export
                            if (hadError)
                                newMessage.MessageStatus = 2; //Received - with Errors
                            else
                                newMessage.MessageStatus = 1; //Received - Ready to process
                            newMessage.MessageDT = DateTime.Now;
                            
                            newMessage.ClientReference1 = clientRef;

                            using (ExportMessageController controller = new ExportMessageController())
                            {
                                result = controller.Insert(newMessage, ref msg);
                                if (result)
                                {
                                    //update the Message History
                                    //check if we have any errors
                                    if (valErrors.Count > 0)
                                    {
                                        using (ExportMessageHistoryController histCont = new ExportMessageHistoryController())
                                        {
                                            foreach (ValidationError err in valErrors)
                                            {
                                                result = histCont.Insert(new ExportMessageHistoryModel
                                                {
                                                    ExportMessageID = newMessage.MessageID,
                                                    MessageStatus = 2,
                                                    MessageClass = (byte)err.MessageClass,
                                                    Description = err.Message
                                                }, ref msg);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        using (ExportMessageHistoryController histCont = new ExportMessageHistoryController())
                                        {
                                            result = histCont.Insert(new ExportMessageHistoryModel
                                            {
                                                ExportMessageID = newMessage.MessageID,
                                                MessageStatus = 1,
                                                MessageClass = 4,
                                                Description = "File recieved"
                                            }, ref msg);

                                        }
                                    }
                                }
                                else
                                {
                                    hadError = true;
                                    EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                                }
                            }

                            //we now need to update the newtrack data
                            if (result)
                            {
                                using (NTCN2DataController controller = new NTCN2DataController())
                                {
                                    result = controller.Update(manifestNo, clientRef, ref msg);
                                }
                            }
                        }
                    }
                    else
                    {
                        //nothing was found!
                        EventLog.LogProfileEvent(_ProfileID, "No new data was found in Newtrack and Compu-Clearing", EventLogType.Warning);
                    }
                }
            }
            catch (Exception exp)
            {
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
                hadError = true;
            }
        }

        /// <summary>
        /// Process all the Export Messages linked to the active profile - that is ready to be processed
        /// </summary>
        private void ProcessMessage()
        {
            string msg = string.Empty;
            bool result = true;
            
            try
            {
                //we first need to get all the messages that can be processed
                List<ExportMessageModel> lstMessage = new List<ExportMessageModel>();
                using (ExportMessageController controller = new ExportMessageController())
                {
                    result = controller.Get(new ExportMessageModel { ProfileID = _ProfileID,MessageStatus = 1 }, ref msg);
                    if (result)
                        lstMessage.AddRange(controller);
                    else
                    {
                        hadError = true;
                        EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                    }
                }

                if (lstMessage.Count == 0)
                {
                    EventLog.LogProfileEvent(_ProfileID, "No new messages to process.", EventLogType.Warning);
                    return;
                }

                //work thru each message
                foreach (ExportMessageModel message in lstMessage)
                {
                    valErrors = new List<ValidationError>();
                    bool messageHadError = false;
                    try
                    {
                        LogMessageHistory(message.MessageID, "Extracting xml and converting to BWM CN2 format...", MessageClass.Sucess, MessageStatus.ReceivedReady);

                        XDocument xDoc = XDocument.Load(new StringReader(message.XMLMessage));
                        var cn2 = from d in xDoc.Element("CN2Data").Elements("NTCN2DataModel") select d;

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (StreamWriter tw = new StreamWriter(memoryStream))
                            {
                                foreach (var data in cn2)
                                {
                                    XElement ManifestNo = data.Element("ManifestNo");
                                    XElement ManifestDate = data.Element("ManifestDate");
                                    XElement RefeNo = data.Element("RefeNo");
                                    XElement MRNNumber = data.Element("MRNNumber");
                                    XElement TruckReg = data.Element("TruckReg");
                                    XElement UCRNo = data.Element("UCRNo");
                                    XElement CustomsValue = data.Element("CustomsValue");
                                    XElement VehiclesInManifest = data.Element("VehiclesInManifest");
                                    XElement ManifestCode = data.Element("ManifestCode");
                                    XElement AgentCode = data.Element("AgentCode");
                                    XElement ManifestStatus = data.Element("ManifestStatus");


                                    //write the line to memory
                                    tw.WriteLine(MRNNumber.Value + "," + RefeNo.Value + "," + ManifestNo.Value + "," + ManifestCode.Value + "," + VehiclesInManifest.Value + ",," + AgentCode.Value + ",,," + ManifestStatus.Value + "," + TruckReg.Value + "," + Convert.ToDateTime(ManifestDate.Value).ToString("yyyyMMdd") + ",,," + UCRNo.Value + ",,," + CustomsValue.Value + ",,,,,,,,,");
                                }
                                tw.Flush();

                                //try to FTP the file
                                using (FTP ftpFile = new FTP())
                                {
                                    ftpFile.ExceptionRaised -= ftpFile_ExceptionRaised;
                                    ftpFile.ExceptionRaised += new FTP.ExceptionRaisedDelegate(ftpFile_ExceptionRaised);

                                    ftpFile.Host = ftpHost;
                                    ftpFile.UserName = ftpUid;
                                    ftpFile.Password = ftpPwd;
                                    
                                    LogMessageHistory(message.MessageID, "Starting FTP process...", MessageClass.Sucess, MessageStatus.ReceivedReady);

                                    string remoteFile = string.Empty;

                                    if (!string.IsNullOrEmpty(ftpFolder))
                                        remoteFile = ftpFolder + "/" + message.ClientReference1;
                                    else
                                        remoteFile = message.ClientReference1;

                                    result = ftpFile.UploadFile(remoteFile, memoryStream);

                                    if (!result)
                                    {
                                        messageHadError = true;
                                        LogMessageHistory(message.MessageID, "Problem sending file to Grindrod via FTP", MessageClass.FailedInternalError, MessageStatus.ProcessedFailed);
                                    }
                                    else
                                    {
                                        LogMessageHistory(message.MessageID, "File was successfully send to Grindrod.", MessageClass.Sucess, MessageStatus.ReceivedReady);
                                    }
                                }

                                memoryStream.Flush();
                            }
                        }
                                           
                    }
                    catch (Exception exp)
                    {
                        hadError = true;
                        messageHadError = true;
                        valErrors.Add(new ValidationError { Message = exp.Message, MessageClass = MessageClass.FailedInternalError });
                    }
                    //update the message
                    if (messageHadError)
                    {
                        using (ExportMessageController controller = new ExportMessageController())
                        {
                            message.MessageStatus = 4; //Failed
                            result = controller.UpdateStatus(message,ref msg);
                        }
                        foreach (ValidationError err in valErrors)
                        {
                            LogMessageHistory(message.MessageID, err.Message, err.MessageClass, MessageStatus.ProcessedFailed);
                        }
                        LogMessageHistory(message.MessageID, "Message failed!", MessageClass.FailedInternalError, MessageStatus.ProcessedFailed);
                    }
                    else
                    {
                        //update the message and the message history
                        using (ExportMessageController controller = new ExportMessageController())
                        {
                            message.MessageStatus = 3; //success
                            result = controller.UpdateStatus(message,ref msg);
                        }
                        //update the message history
                        LogMessageHistory(message.MessageID, "Message was successfully processed", MessageClass.Sucess, MessageStatus.ProcessedSuccess);
                    }
                }
            }
            catch (Exception exp)
            {
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
                hadError = true;
            }
        }

        private void ftpFile_ExceptionRaised(string errorMsg)
        {
            valErrors.Add(new ValidationError { Message = errorMsg, MessageClass = MessageClass.FailedInternalError });
        }

        private void LogMessageHistory(long? id,string desc,MessageClass mclass,MessageStatus st)
        {
            string msg = string.Empty;
            try
            {
                using (ExportMessageHistoryModel model = new ExportMessageHistoryModel())
                {
                    model.Description = desc;
                    model.ExportMessageID = id;
                    model.MessageClass = (byte)mclass;
                    model.MessageStatus = (byte)st;

                    using (ExportMessageHistoryController controller = new ExportMessageHistoryController())
                    {
                        controller.Insert(model, ref msg);
                    }
                }
            }
            catch
            {
                //no need to do any thing - only updating history
            }
        }


    }
}
