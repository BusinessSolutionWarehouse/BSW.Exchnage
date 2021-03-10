using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BSW_ExchangeData;
using BSW_ExchangeShared;
using System.Configuration;
using System.Xml.Linq;

namespace OrderImportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Orders : IOrders
    {
        
        private byte profileID = 0;
 
        /// <summary>
        /// Import Mustek Orders - into BSW-Exchange Service
        /// </summary>
        /// <param name="xmlData">Cannonical XML import file</param>
        /// <returns>Response object - containint success indicator and failed reasons</returns>
        public Response PostOrder(string xmlData)
        {
            Response result = new Response();

            try
            {
                //we will update this if anything failes
                result.WasSuccessFull = true;
                result.ResponseMsg = "Data successfully received";

                //first we need to make sure we have a profile ID
                LoadSettings();
                if(profileID == 0 )
                {
                    result.WasSuccessFull = false;
                    result.ResponseMsg = "Service configuration error - linked profile id not found";
                    return result;
                }

                //load the xml string into stream
                XDocument doc = XDocument.Parse(xmlData);
                //we need to due some minor validations on the file
                string msg = string.Empty;
                bool validationPassed = true;
                string validationResults = string.Empty;
                DateTime messageDT = DateTime.Now;
                string clientRef2 = string.Empty;
                string orderNumber = string.Empty;
                long? batchID = null;
                int version = 1;

                List<ValidationError> valErrors = new List<ValidationError>();

                using (ImportOrderValidation validator = new ImportOrderValidation())
                {
                    validator.ProfileID = profileID;
                    validationPassed = validator.ValidateStructure(doc, validationResults);

                    if (!validationPassed)
                    {
                        valErrors.Add(new ValidationError { Message = validationResults, MessageClass = MessageClass.FailedStructuraError });
                        result.WasSuccessFull = false;
                        result.ResponseMsg = "Structure Validation Failed - " + validationResults;
                    }
                    else
                    {
                        validationPassed = validator.ValidateRequieredFields(doc, valErrors, true, ref orderNumber);
                        validationPassed = validationPassed && validator.GetMessageIDAndDate(doc, ref messageDT, ref clientRef2, valErrors);

                        if(!validationPassed)
                        {
                            result.WasSuccessFull = false;
                            foreach(ValidationError err in valErrors)
                            {
                                result.ResponseMsg = result.ResponseMsg + err.Message + Environment.NewLine;
                            }
                        }
                    }

                }

                //get the batch and version this file must be linked to
                if (!string.IsNullOrEmpty(orderNumber))
                {
                    using (ImportBatchController controller = new ImportBatchController())
                    {
                        if (controller.Get(orderNumber, ref msg))
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
                    model.ClientReference1 = orderNumber;
                    model.MessageTypeID = (byte)MessageType.MustekOrderImport;
                    model.ProfileID = profileID;
                    model.XMLMessage = doc.ToString();
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
                            EventLog.LogProfileEvent(profileID, msg, EventLogType.Error);
                            result.WasSuccessFull = false;
                            result.ResponseMsg = "Internal Error - " + msg;
                        }
                    }
                }

            }
            catch(Exception exp)
            {
                result.WasSuccessFull = false;
                result.ResponseMsg = "Error - " + exp.Message;
                //check if we have a profile id
                if(profileID > 0)
                {
                    EventLog.LogProfileEvent(profileID, exp.Message, EventLogType.Error);
                }
            }

            return result;
        }

        private void LoadSettings()
        {
            //we need to load some of the needed settings
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ProfileIDUnique"]))
                profileID = byte.Parse(ConfigurationManager.AppSettings["ProfileIDUnique"]);
        }

        
    }
}
