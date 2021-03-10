using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using BSW_ExchangeShared;
using BSW_ExchangeData;
using System.Configuration;

namespace VVExchange.ExchangePlugin.XMLImport
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;
        private List<ValidationError> valErrors = new List<ValidationError>();
        private DateTime? lastProcessed = null;

        public frmMain(string profileID)
        {
            InitializeComponent();
            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                profileID = "4";

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

                using (ImportMessageController controller = new ImportMessageController())
                {
                    if (controller.GetLast(new ImportMessageModel { ProfileID = _ProfileID }, ref msg))
                    {
                        if (controller.Count > 0)
                        {
                            // we have processed files previously so get last date
                            // messageDt field = last processed file creation date this profile
                            lastProcessed = controller[0].MessageDt;
                        }
                    }
                }

                EventLog.LogProfileEvent(_ProfileID, "Start Process VVExchange", EventLogType.Information);

                if (!ProcessFiles(lastProcessed))
                    hadError = true;

                EventLog.LogProfileEvent(_ProfileID, "Finish Process VVExchange", EventLogType.Information);

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

        private bool ProcessFiles(DateTime? MessageDT)
        {
            bool result = true;

            ServiceClient serviceClient = new ServiceClient();

            try
            {
                using (serviceClient)
                {
                    VVExchangeWCF.ImportMessageModel[] importMessageModel = new VVExchangeWCF.ImportMessageModel[0];
                    string msg = string.Empty;

                    byte ProfileID = Convert.ToByte(ConfigurationManager.AppSettings["RemoteProfileID"]);
                    int MaxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRows"]);

                    bool getMessageResult = serviceClient.GetMessages(ProfileID, MessageDT.HasValue ? MessageDT : new DateTime(2014, 01, 01), MaxRows, ref importMessageModel, ref msg);
                    if (getMessageResult)
                    {
                        foreach (VVExchangeWCF.ImportMessageModel item in importMessageModel)
                        {
                            if (item != null)
                            {
                                try
                                {
                                    XDocument doc = XDocument.Parse(item.XMLMessage);
                                    long? batchID = null;
                                    int version = 1;

                                    DateTime? messageDT = item.MessageDT;

                                    bool validationPassed = true;
                                    string validationResults = string.Empty;
                                    string vesselvisitID = string.Empty;
                                    string clientRef2 = string.Empty;

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

                                    using (ImportMessageModel model = new ImportMessageModel())
                                    {
                                        model.ClientReference1 = item.MessageID.ToString();
                                        model.ClientReference2 = clientRef2;
                                        model.ImportBatchID = batchID;
                                        model.MessageDt = messageDT;
                                        model.MessageTypeID = (byte)MessageType.VVExchangeImport;
                                        model.ProfileID = _ProfileID;
                                        model.Version = version;
                                        model.XMLMessage = doc.ToString();

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
                                }
                                catch (Exception ex)
                                {
                                    EventLog.LogProfileEvent(_ProfileID, ex.Message, EventLogType.Error);
                                    result = false;
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
            catch (Exception ex)
            {
                EventLog.LogProfileEvent(_ProfileID, ex.Message, EventLogType.Error);
                result = false;
            }

            return result;
        }
    }
}
