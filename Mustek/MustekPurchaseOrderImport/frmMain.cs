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
using PurchaseOrder.Data;

namespace MustekPurchaseOrderImport
{
    public partial class frmMain : Form
    {
        private byte _ProfileID = 0;
        private Timer _timer = null;
        private bool hadError = false;

        private List<ImportMessageModel> _FilesToProcess = new List<ImportMessageModel>();

        public frmMain(string profileID)
        {
            InitializeComponent();
            this.Text = "Purchase Order Import - Profile (Unknown)";
            try
            {
                //this line is only used for debugging - must be commented out - for full test cycle
                //profileID = "15"; 

                this.Text = "Purchase Order Import - Profile ( " + profileID + ")";

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
            _timer.Stop();
            _timer.Enabled = false;
            _timer.Dispose();


            string msg = string.Empty;
            try
            {
                //we first need to get all the files that where recieved and not yet processed - and purchase order format
                using (ImportMessageController controller = new ImportMessageController())
                {
                    //Check if there are any orders that we need to set for re-processing based on the linked produtc update
                    EventLog.LogProfileEvent(_ProfileID, "Update potential orders for re-processing", EventLogType.Information);
                    if (controller.UpdateReprocessingOrders(ref msg))
                    {
                        using (ImportMessageModel model = new ImportMessageModel())
                        {
                            model.MessageStatus = (byte)MessageStatus.ReceivedReady;
                            model.MessageTypeID = (byte)MessageType.MustekOrderImport;

                            if (controller.Get(model, ref msg))
                            {
                                EventLog.LogProfileEvent(_ProfileID, "Found - " + Convert.ToString(controller.Count) + " new file(s) to process", EventLogType.Information);
                                foreach (ImportMessageModel result in controller)
                                {
                                    _FilesToProcess.Add(result);
                                }
                            }
                            else
                            {
                                hadError = true;
                                EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                            }

                        }
                    }
                    else
                    {
                        hadError = true;
                        EventLog.LogProfileEvent(_ProfileID, msg, EventLogType.Error);
                    }
                }
                //lets process the files
                if (!hadError)
                {
                    foreach (ImportMessageModel activeFile in _FilesToProcess)
                    {
                        hadError = false;
                        ProcessFile(activeFile);
                    }
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

        /// <summary>
        /// Process the xml file
        /// </summary>
        /// <param name="activeFile"> Current xml file</param>
        private void ProcessFile(ImportMessageModel activeFile)
        {
            try
            {
                string msg = string.Empty;
                bool validationPassed = true;
                string validationResults = string.Empty;
                string orderNumber = string.Empty;

                List<ValidationError> valErrors = new List<ValidationError>();


                XDocument xdoc = XDocument.Load(new StringReader(activeFile.XMLMessage));
                //do some validation ons the xml file and the layout
                using (ImportOrderValidation validator = new ImportOrderValidation())
                {
                    validator.ProfileID = _ProfileID;
                    validationPassed = validator.ValidateStructure(xdoc, validationResults);
                    if (!validationPassed)
                        valErrors.Add(new ValidationError { Message = validationResults, MessageClass = MessageClass.FailedStructuraError });
                    else
                        validationPassed = validator.ValidateRequieredFields(xdoc, valErrors, true, ref orderNumber);

                }
                if (!validationPassed)
                {
                    hadError = true;
                    UpdateMessage(activeFile, valErrors, MessageStatus.ProcessedFailed);
                    return;
                }
                int _importerID = 0;
                int _importerRoleLinkeID = 0;
                SupplierModel supplierDetail = new SupplierModel();
                PurchaseOrderModel orderModel = new PurchaseOrderModel();
                List<OrderLineModel> orderLines = new List<OrderLineModel>();

                //we do data validation
                using (PurchaseOrderValidation dValidation = new PurchaseOrderValidation())
                {
                    validationPassed = validationPassed & dValidation.ValidateImporter(xdoc, ref _importerID, ref _importerRoleLinkeID, valErrors);
                    validationPassed = validationPassed & dValidation.ValidateSupplier(xdoc, ref supplierDetail, valErrors);

                    if (validationPassed) //no point to continue if we do not have a supplier or importer
                    {
                        //set all the Order values we already have
                        orderModel.ImporterID = _importerRoleLinkeID;
                        orderModel.SupplierID = supplierDetail.SupplierRoleLinkID;

                        if (string.IsNullOrEmpty(supplierDetail.IncoTermCode))
                            orderModel.INCOTermCode = "FOB"; //defaults to FOB - if no linked IncoTerm is found
                        else
                            orderModel.INCOTermCode = supplierDetail.IncoTermCode;

                        orderModel.TransportModeID = 1;//we default to Sea

                        if (supplierDetail.CountryOfOriginID != null)
                            orderModel.CountryOriginID = Convert.ToInt16(supplierDetail.CountryOfOriginID);

                        //if (string.IsNullOrEmpty(supplierDetail.DefaultPortCode))
                        //    orderModel.PortLoadingCode = "CNSHA"; //Default to SHANGHAI - if no port was linked
                        //else
                        orderModel.PortLoadingCode = supplierDetail.DefaultPortCode;

                        orderModel.PortDischargeCode = "ZADUR"; //we default this to Durban
                        orderModel.FinalDestinationCode = "ZAJNB"; //default to Johannesburg

                        if (supplierDetail.PaymentTermID != null)
                            orderModel.PaymentTermID = supplierDetail.PaymentTermID;
                        if (supplierDetail.PaymentTriggerID != null)
                            orderModel.PaymentTriggerID = supplierDetail.PaymentTriggerID;
                        if (supplierDetail.PaymentMethod != null)
                            orderModel.PaymentTypeID = supplierDetail.PaymentMethod;

                        //set the order date to the file date - that was done with the first import step
                        orderModel.OrderDt = activeFile.ImportDT;

                        orderModel.CreatedDt = DateTime.Now;
                        orderModel.CreatedUserID = 3; //System
                        orderModel.OrderStatusID = (byte)PurchaseOrderStatus.Incomeplete; //we always have incomplete orders - they cannot supply us with all the needed data

                        //get the rest of the details from the order tag
                        validationPassed = dValidation.ExtractOrderDetail(xdoc, ref orderModel, valErrors);
                        //get all the order lines
                        validationPassed = validationPassed & dValidation.ExtractOrderLines(xdoc, ref orderLines, _importerRoleLinkeID, supplierDetail, valErrors);

                        bool isNewOrder = true;

                        if (validationPassed)
                        {
                            //we first need to create the new order
                            using (PurchaseOrderController controller = new PurchaseOrderController())
                            {
                                //we need to check if we have not already processed this order
                                if (controller.Get(new PurchaseOrderModel { OrderNo = orderModel.OrderNo }, ref msg))
                                {
                                    if (controller.Count > 0) //we should only get 1 record back - or nothing
                                    {
                                        orderModel.OrderID = controller[0].OrderID;
                                        orderModel.OrderStatusID = controller[0].OrderStatusID;

                                        //we need to check if we can still update this order
                                        if (controller[0].OrderStatusID != 3)
                                            isNewOrder = false;
                                        else
                                        {
                                            hadError = true;
                                            valErrors.Add(new ValidationError { Message = "Order No(" + orderModel.OrderNo + ") is already approved - and cannot be updated. ", MessageClass = MessageClass.Sucess });
                                        }
                                    }
                                    else
                                        isNewOrder = true;
                                }
                                else
                                {
                                    hadError = true;
                                    valErrors.Add(new ValidationError { Message = "Validating Order No(" + orderModel.OrderNo + ") Failed. " + msg, MessageClass = MessageClass.FailedInternalError });

                                }

                                if (!hadError)
                                {
                                    //check if we need to update the order
                                    if (isNewOrder)
                                    {
                                        if (controller.Insert(orderModel, ref msg))
                                        {
                                            using (OrderLineController oLineController = new OrderLineController())
                                            {
                                                int lineC = 0;
                                                //now we can add all the order lines - linked to this order - no need to check if the order lien already exists
                                                foreach (OrderLineModel oLine in orderLines)
                                                {
                                                    lineC++;
                                                    oLine.OrderID = orderModel.OrderID;
                                                    if (!oLineController.Insert(oLine, ref msg))
                                                    {
                                                        hadError = true;
                                                        valErrors.Add(new ValidationError { Message = "Insert new OrderLine(" + orderModel.OrderNo + ":LineNo: " + lineC + ") Failed. " + msg, MessageClass = MessageClass.FailedInternalError });
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            hadError = true;
                                            valErrors.Add(new ValidationError { Message = "Insert new Order(" + orderModel.OrderNo + ") Failed. " + msg, MessageClass = MessageClass.FailedInternalError });
                                        }
                                    }
                                    else //update the order
                                    {
                                        orderModel.UpdatedDt = DateTime.Now;
                                        orderModel.UpdatedUserID = 3; //system

                                        if (controller.Update(orderModel, true, ref msg))
                                        {
                                            //we need to update the linked order lines
                                            using (OrderLineController lineCon = new OrderLineController())
                                            {
                                                int lineC = 0;
                                                foreach (OrderLineModel lineModel in orderLines)
                                                {
                                                    lineC++;
                                                    bool result = true;

                                                    //let first check we do not already have this order line for this order
                                                    lineModel.OrderID = orderModel.OrderID;
                                                    lineModel.UpdatedDt = DateTime.Now;
                                                    lineModel.UpdatedUserID = 3;//system

                                                    //we only check on the product and linked order 
                                                    if (lineCon.Get(new OrderLineModel { OrderID = lineModel.OrderID, ProductID = lineModel.ProductID }, ref msg))
                                                    {
                                                        if (lineCon.Count == 0)
                                                            result = lineCon.Insert(lineModel, ref msg);
                                                        else
                                                        {
                                                            lineModel.OrderLineID = lineCon[0].OrderLineID;

                                                            result = lineCon.Update(lineModel, true, ref msg);
                                                        }
                                                        if (!result)
                                                        {
                                                            hadError = true;
                                                            valErrors.Add(new ValidationError { Message = "Updating OrderLine(" + orderModel.OrderNo + ":LineNo: " + lineC + ") Failed. " + msg, MessageClass = MessageClass.FailedInternalError });
                                                        }
                                                    }
                                                    else
                                                    {
                                                        hadError = true;
                                                        valErrors.Add(new ValidationError { Message = "Checking OrderLine(" + orderModel.OrderNo + ":LineNo: " + lineC + ") Failed. " + msg, MessageClass = MessageClass.FailedInternalError });
                                                    }
                                                }

                                            }
                                        }
                                        else
                                        {
                                            hadError = true;
                                            valErrors.Add(new ValidationError { Message = "Updating Order(" + orderModel.OrderNo + ") Failed. " + msg, MessageClass = MessageClass.FailedInternalError });
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
                        else
                        {
                            hadError = true;
                            UpdateMessage(activeFile, valErrors, MessageStatus.ProcessedFailed);
                        }

                    }
                    else
                    {
                        hadError = true;
                        UpdateMessage(activeFile, valErrors, MessageStatus.ProcessedFailed);
                    }
                }


            }
            catch (Exception exp)
            {
                hadError = true;
                EventLog.LogProfileEvent(_ProfileID, exp.Message, EventLogType.Error);
            }
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
                                        Description = "File processed successfully",
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
