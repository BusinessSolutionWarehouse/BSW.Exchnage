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

namespace AZROEImports
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;
        private bool hadError = false;

        public frmMain(string profileID)
        {
            InitializeComponent();
            this.Text = "AutoZone ROE Update - Profile (Unknown)";
            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                profileID = "3";

                this.Text = "AutoZone ROE Update - Profile ( " + profileID + ")";

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
                lstInfo.Items.Add(exp.Message);
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
            long? _messageID = 0;
           
            string msg = string.Empty;
            try
            {
                               
                string uri = "http://feeds1.mcgbfa.com/engine.asmx/getPriceData?SubFeed=0&newfeed=true&CompanyKey=McGregorBFA";
                string result = string.Empty;

                //make the call to the web service and load the resulting xml into the result string
                using (WebClient wc = new WebClient())
                {
                    using (Stream st = wc.OpenRead(uri))
                    {

                        using (StreamReader sr = new StreamReader(st))
                        {
                            result = sr.ReadToEnd();
                        }
                    }
                }

                List<ValidationError> valErrors = new List<ValidationError>();

                if (!string.IsNullOrEmpty(result))
                {
                    long? batchID = null;
                    int version = 1;

                    result = result.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>",string.Empty);

                    //get the batch and version fo this message
                    //we use the date as the batch grouping - batch per day
                    using (ImportBatchController controller = new ImportBatchController())
                    {
                        if (controller.Get("AZROE - " + DateTime.Now.ToString("yyyyMMdd"), ref msg))
                        {
                            if (controller.Count > 0)
                            {
                                batchID = controller[0].ImportBatchID;
                                version = Convert.ToInt32(controller[0].Version);
                            }
                        }
                        else
                        {
                            valErrors.Add(new ValidationError { Message = msg, MessageClass = MessageClass.FailedInternalError });
                            hadError = true;
                        }
                    }

                    //save the new message to the import table
                    using (ImportMessageModel model = new ImportMessageModel())
                    {
                        model.ClientReference1 = "AZROEFeed";
                        model.MessageTypeID = (byte)MessageType.AZROEUpdate;
                        model.ProfileID = _ProfileID;
                        model.XMLMessage = result;
                        model.MessageDt = System.DateTime.Now;
                        model.ImportBatchID = batchID;
                        model.Version = version;
                        model.MessageStatus = (byte)MessageStatus.ReceivedReady;


                        using (ImportMessageController controller = new ImportMessageController())
                        {
                            if (controller.Insert(model, ref msg))
                            {
                                _messageID = model.MessageID;
                                //check what history do we need to log
                                using (ImportMessageHistoryController histcont = new ImportMessageHistoryController())
                                {
                                    ImportMessageHistoryModel histModel = new ImportMessageHistoryModel
                                    {
                                        Description = "ROE feed received successfully",
                                        ImportMessageID = model.MessageID,
                                        MessageStatus = (byte)MessageStatus.ReceivedReady,
                                        MessageClass = (byte)MessageClass.Sucess
                                    };
                                    histcont.Insert(histModel, ref msg);
                                }
                            }
                            else
                            {
                                EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                                hadError = true;
                            }
                        }
                    }

                    //process the new feed
                    if (!hadError)
                    {
                        hadError = ProcessFeed(ref valErrors);
                    }

                }
                else
                {
                    //nothing was found!
                    EventLog.LogProfileEvent(_ProfileID,"Empty result was retunred from the web service", EventLogType.Warning);
                }
            }
            catch (Exception exp)
            {
                hadError = true;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }

            if (hadError)
                EventLog.LogProfileEvent(_ProfileID, "Process Failed - view message history for detail", EventLogType.ProcessFailed);
            else
                EventLog.LogProfileEvent(_ProfileID, "Process Successfully complete", EventLogType.ProcessComplete);

            //we make sure the application is closed - no matter what happend in the processing
            this.Dispose();


        }

        private bool ProcessFeed(ref List<ValidationError> valErrors)
        {
            bool hadError = false;
            string msg = string.Empty;
            List<ImportMessageModel> _FilesToProcess = new List<ImportMessageModel>();

            try
            {
                //we first need to get all the files that where recieved and not yet processed - and purchase order format
                using (ImportMessageController controller = new ImportMessageController())
                {
                    using (ImportMessageModel model = new ImportMessageModel())
                    {
                        model.MessageStatus = (byte)MessageStatus.ReceivedReady;
                        model.MessageTypeID = (byte)MessageType.AZROEUpdate;

                        if (controller.Get(model, ref msg))
                        {
                            EventLog.LogProfileEvent(_ProfileID, "Found - " + Convert.ToString(controller.Count) + " new file(s) to process", EventLogType.Information);

                            _FilesToProcess.AddRange(controller);
                        }
                        else
                        {
                            hadError = true;
                            EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                        }

                    }

                }

                //lets process the files
                if (!hadError)
                {
                    foreach (ImportMessageModel activeFile in _FilesToProcess)
                    {
                        hadError = false;

                        XDocument xdoc = XDocument.Load(new StringReader(activeFile.XMLMessage));
                        //get the new rates
                        var records = from d in xdoc.Elements("data").Elements("record") select d;
                        foreach (var record in records)
                        {
                            string currency = record.Element("Ticker").Value;
                            decimal price = Convert.ToDecimal(record.Element("PriceInRands").Value);
                            //get the currency
                            string[] cur = currency.Split(Convert.ToChar("/"));
                            currency = cur[1];
                            using (ExchangeRateController controller = new ExchangeRateController())
                            {
                                using (ExchangeRateModel model = new ExchangeRateModel())
                                {
                                    model.FromCurrency = currency;
                                    model.BusinessEntityRoleLinkID = 1; //Auto Zone is ID 1
                                    model.ToCurrency = "ZAR"; //ZAR
                                    model.Rate = price;
                                    model.UpdatedUserID = 3; //System user

                                    if (!controller.Insert(model, ref msg))
                                    {
                                        hadError = true;
                                        valErrors.Add(new ValidationError { Message = msg, MessageClass = MessageClass.FailedInternalError });
                                    }
                                }
                            }

                        }

                        if (!hadError)
                        {
                            //the order was processed without any issues
                            UpdateMessage(activeFile, valErrors, MessageStatus.ProcessedSuccess);
                        }
                        else
                            UpdateMessage(activeFile, valErrors, MessageStatus.ProcessedFailed);
                    }
                }
                
            }
            catch (Exception exp)
            {
                hadError = true;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }

            return hadError;
        }

        /// <summary>
        /// Update the current message
        /// </summary>
        /// <param name="activeMessage">Current message details</param>
        /// <param name="valErrors">List of validation errors</param>
        /// <param name="msgStatus">New status of the message</param>
        private void UpdateMessage(ImportMessageModel activeMessage, List<ValidationError> valErrors, MessageStatus msgStatus)
        {
            try
            {
                string msg = string.Empty;

                using (ImportMessageModel model = new ImportMessageModel())
                {
                    model.MessageID = activeMessage.MessageID;
                    model.MessageStatus = (byte)msgStatus;

                    using (ImportMessageController controller = new ImportMessageController())
                    {
                        if (controller.Update(model, true, ref msg))
                        {
                            //check what history do we need to log
                            using (ImportMessageHistoryController histcont = new ImportMessageHistoryController())
                            {
                                if (msgStatus == MessageStatus.ProcessedSuccess)
                                {
                                    ImportMessageHistoryModel histModel = new ImportMessageHistoryModel
                                    {
                                        Description = "Feed processed successfully",
                                        ImportMessageID = model.MessageID,
                                        MessageStatus = (byte)MessageStatus.ProcessedSuccess,
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
                                            MessageStatus = (byte)MessageStatus.ProcessedFailed,
                                            MessageClass = (byte)err.MessageClass
                                        };
                                        histcont.Insert(histModel, ref msg);
                                    }
                                }
                            }
                        }
                        else
                        {
                            EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                hadError = true;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }
        }


    }
}
