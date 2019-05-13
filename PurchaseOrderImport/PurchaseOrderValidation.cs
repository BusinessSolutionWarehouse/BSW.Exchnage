﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PurchaseOrder.Data;
using System.Xml.Linq;
using BSW_ExchangeShared;

namespace PurchaseOrderImport
{
    public class PurchaseOrderValidation:IDisposable
    {

        List<CCLTariffCodeValidationModel> validatedCodes = new List<CCLTariffCodeValidationModel>();

        #region IDisposable/Construction Members

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }
            }
            _disposed = true;
        }

        public PurchaseOrderValidation()
        {

        }

        #endregion

        /// <summary>
        /// Validate the Importer - SenderID
        /// </summary>
        /// <param name="xdoc">Current xml document</param>
        /// <param name="importerID">Resolved importer id</param>
        /// <param name="valErrors">List of errors</param>
        /// <returns></returns>
        public bool ValidateImporter(XDocument xdoc, ref Int32 importerID,ref Int32 importerRoleID, List<ValidationError> valErrors)
        {
            bool result = true;
            try
            {
                var messageHeader = from d in xdoc.Elements("Message").Elements("MessageHeader") select d;
                string importerCode = messageHeader.FirstOrDefault().Element("SenderID").Value;
                if (string.IsNullOrEmpty(importerCode))
                {
                    valErrors.Add(new ValidationError { Message = "SenderID was not found or was missing a value", MessageClass = MessageClass.FailedStructuraError });
                    return false;
                }
                string msg = string.Empty;
                //lets see if we can get the business entity id
                using (BusinessEntityController controller = new BusinessEntityController())
                {
                    result = controller.GetImporter(new BusinessEntityModel { BusinessEntityCode = importerCode }, ref msg);
                    if (result)
                    {
                        if (controller.Count > 0)
                        {
                            importerID = Convert.ToInt32(controller[0].BusinessEntityID);
                            importerRoleID = Convert.ToInt32(controller[0].BusinessEntityRoleLinkID);
                        }
                        else
                        {
                            result = false;
                            valErrors.Add(new ValidationError { Message = "Importer was not Found - SenderID(" + importerCode + ")", MessageClass = MessageClass.FailedDataValidationError });
                        }
                    }
                    else
                        valErrors.Add(new ValidationError { Message = "Error loading SenderID(" + importerCode + ") - " + msg, MessageClass = MessageClass.FailedInternalError});
                }
            }
            catch (Exception exp)
            {
                result = false;
                result = false;
                valErrors.Add(new ValidationError { Message = exp.Message, MessageClass = MessageClass.FailedInternalError });
            }
            return result;

        }

        /// <summary>
        /// validate the supplier code - and load all the needed supplier detail
        /// </summary>
        /// <param name="xdoc">Current xml Document</param>
        /// <param name="supplierInfo">Supplier Detail </param>
        /// <param name="valErrors">List of validation errors</param>
        /// <returns></returns>
        public bool ValidateSupplier(XDocument xdoc, ref SupplierModel supplierInfo, List<ValidationError> valErrors)
        {
            bool result = true;
            try
            {
                var supplier = from d in xdoc.Elements("Message").Elements("MessageBody").Elements("Order").Elements("Supplier") select d;
                
                string supplierCode = supplier.FirstOrDefault().Element("SupplierCode").Value;
                if (string.IsNullOrEmpty(supplierCode))
                {
                    valErrors.Add(new ValidationError { Message = "Supplier Code was not found or was missing a value", MessageClass = MessageClass.FailedStructuraError });
                    return false;
                }
                string msg = string.Empty;
                //lets see if we can get the business entity id
                using (SupplierController controller = new SupplierController())
                {
                    result = controller.GetDetail(new SupplierModel { SupplierCode = supplierCode }, ref msg);
                    if (result)
                    {
                        if (controller.Count > 0)
                        {
                            //we need to set each value - because the controller will be disposed
                            supplierInfo = new SupplierModel
                            {
                                SupplierCode = controller[0].SupplierCode,
                                SupplierName = controller[0].SupplierName,
                                SupplierID = controller[0].SupplierID,
                                CountryOfOriginID = controller[0].CountryOfOriginID,
                                DefaultCurrencyID = controller[0].DefaultCurrencyID,
                                DefaultPortCode = controller[0].DefaultPortCode,
                                IncoTermCode = controller[0].IncoTermCode,
                                PaymentTermID = controller[0].PaymentTermID,
                                PaymentTriggerID = controller[0].PaymentTriggerID,
                                TransportModeID = controller[0].TransportModeID,
                                SupplierRoleLinkID = controller[0].SupplierRoleLinkID,
                                PaymentMethod = controller[0].PaymentMethod

                            };
                        }
                        else
                        {
                            result = false;
                            valErrors.Add(new ValidationError { Message = "Supplier was not Found - SupplierCode(" + supplierCode + ")", MessageClass = MessageClass.FailedDataValidationError});
                        }
                    }
                    else
                        valErrors.Add(new ValidationError { Message = "Error loading Supplier(" + supplierCode + ") - " + msg, MessageClass = MessageClass.FailedInternalError});
                }
            }
            catch (Exception exp)
            {
                result = false;
                result = false;
                valErrors.Add(new ValidationError { Message = exp.Message, MessageClass = MessageClass.FailedInternalError});
            }
            return result;
        }

        /// <summary>
        /// Extract all the order detials in the Order tag
        /// </summary>
        /// <param name="xdoc">Active XML document</param>
        /// <param name="orderModel">Purchage Order Model</param>
        /// <param name="valErrors">List possible errors</param>
        /// <returns></returns>
        public bool ExtractOrderDetail(XDocument xdoc, ref PurchaseOrderModel orderModel, List<ValidationError> valErrors)
        {
            bool result = true;
            try
            {
                var orders = from d in xdoc.Elements("Message").Elements("MessageBody").Elements("Order") select d;

                foreach (var order in orders)
                {
                    XElement orderNo = order.Element("OrderNo");
                    if (orderNo != null && !string.IsNullOrEmpty(orderNo.Value))
                    {
                        orderModel.OrderNo = orderNo.Value;
                    }
                    else
                    {
                        result = false;
                        valErrors.Add(new ValidationError { Message = "The OrderNo value is missing", MessageClass = MessageClass.FailedStructuraError });
                    }
                    //Imprter ref is not Requiered - so if we do have it - no worries
                    XElement impRef = order.Element("ImporterRef");
                    if (impRef != null && !String.IsNullOrEmpty(impRef.Value))
                        orderModel.ImporterRef = impRef.Value;

                    break; //we should only ever get 1 order in a message
                }
               
            }
            catch (Exception exp)
            {
                result = false;
                result = false;
                valErrors.Add(new ValidationError { Message = exp.Message, MessageClass = MessageClass.FailedInternalError});
            }
            return result;
        }

        /// <summary>
        /// Extract all the linked order lines and product information
        /// </summary>
        /// <param name="xdoc">XML Document</param>
        /// <param name="orderLines">List of linked order line details</param>
        /// <param name="valErrors">List of possable errors</param>
        /// <returns></returns>
        public bool ExtractOrderLines(XDocument xdoc, ref List<OrderLineModel> orderLineModels,int importerID,SupplierModel supplierDetail, List<ValidationError> valErrors)
        {
            bool result = true;
            try
            {
                var orders = from d in xdoc.Elements("Message").Elements("MessageBody").Elements("Order") select d;
                bool hasTargetDate = false;
                DateTime targetDt = DateTime.Now;
                //we need to get the TagetDelivery Date - on the Order Tag
                foreach (var order in orders)
                {
                    XElement targetDate = order.Element("TargetDeliveryDate");
                    if (targetDate != null && !string.IsNullOrEmpty(targetDate.Value))
                    {
                        try
                        {
                            DateTime.TryParse(targetDate.Value, out targetDt);
                            hasTargetDate = true;
                        }
                        catch
                        {
                            //taget date is not requierd - so not to worry if we get an error
                        }
                    }
                    break; //we should only ever get 1 order in a message
                }
                var orderLines = from d in orders.Elements("OrderLine") select d;
                
                int iLineCount = 1;
                
                foreach (var orderline in orderLines)
                {
                    OrderLineModel newLine = new OrderLineModel();
                    bool haserror = false;
                    try
                    {
                        ProductModel productModel = new ProductModel();
                        if (hasTargetDate)
                            newLine.OnSiteDt = targetDt;

                        productModel.ImporterID = importerID;
                        productModel.SupplierID = supplierDetail.SupplierRoleLinkID;

                        if (supplierDetail.DefaultCurrencyID.HasValue)
                            newLine.UnitCurrencyID = Convert.ToInt16(supplierDetail.DefaultCurrencyID);
                         
                        productModel.ProductDescription = orderline.Element("Description").Value.Trim();
                        newLine.Description = productModel.ProductDescription;
                        
                        if (string.IsNullOrEmpty(productModel.ProductDescription))
                        {
                            valErrors.Add(new ValidationError { Message = "OrderLine " + iLineCount + " - Missing Description", MessageClass = MessageClass.FailedStructuraError });
                            haserror = true;
                        }
                        if (string.IsNullOrEmpty(orderline.Element("ItemCode").Value))
                        {
                            valErrors.Add(new ValidationError { Message = "OrderLine " + iLineCount + " - Missing ItemCode", MessageClass = MessageClass.FailedStructuraError });
                            haserror = true;
                        }
                        else
                            productModel.ProductCode = orderline.Element("ItemCode").Value;

                        if (string.IsNullOrEmpty(orderline.Element("Qty").Value))
                        {
                            valErrors.Add(new ValidationError { Message = "OrderLine " + iLineCount + " - Missing Qty", MessageClass = MessageClass.FailedStructuraError });
                            haserror = true;
                        }
                        else
                            newLine.UnitQuantity = Int32.Parse(orderline.Element("Qty").Value);

                        newLine.UnitTypeID = LookupUnitType(orderline.Element("UnitType").Value);

                        if (!string.IsNullOrEmpty(orderline.Element("UnitPrice").Value))
                        {
                            productModel.UnitPriceForeign = decimal.Parse(orderline.Element("UnitPrice").Value);
                            newLine.UnitPrice = productModel.UnitPriceForeign;
                        }
                        if (!string.IsNullOrEmpty(orderline.Element("UnitsPerPackage").Value))
                            productModel.UnitPackQty = int.Parse(orderline.Element("UnitsPerPackage").Value);
                        else
                            productModel.UnitPackQty = 1;

                        if (!string.IsNullOrEmpty(orderline.Element("SupplierRef").Value))
                        {
                            newLine.SupplierRefNo = orderline.Element("SupplierRef").Value;
                            productModel.SupplierProductCode = orderline.Element("SupplierRef").Value;
                        }

                        int countryID = 0;

                        if (supplierDetail.CountryOfOriginID != null)
                            countryID = Convert.ToInt32(supplierDetail.CountryOfOriginID);

                        //validate the product info
                        if (ValidateProduct(ref productModel, valErrors,Convert.ToInt32(supplierDetail.SupplierRoleLinkID),countryID))
                        {
                            newLine.ProductID = productModel.ProductID;
                            newLine.TariffCode = productModel.TariffCode;

                            newLine.FIFOPercentage = productModel.FIFO;
                            newLine.ContingencyPercentage = productModel.Contingency;
                            newLine.MarketingPercentage = productModel.Marketing;
                            newLine.ClaimsPercentage = productModel.Claims;

                            if (productModel.UnitDim1_CM.HasValue && productModel.UnitDim2_CM.HasValue && productModel.UnitDim3_CM.HasValue)
                                newLine.TotalVolume =  newLine.UnitQuantity * (productModel.UnitDim1_CM * productModel.UnitDim2_CM * productModel.UnitDim3_CM);
                            else
                                newLine.TotalVolume = 0;
                            
                            if (productModel.UnitWeight_KG.HasValue)
                                newLine.TotalWeight = newLine.UnitQuantity * productModel.UnitWeight_KG;

                            newLine.CreatedDt = DateTime.Now;
                            newLine.CreatedUserID = 3;//system
                            newLine.OrderLineStatusID = (byte)OrderLineStatus.Pending;

                            orderLineModels.Add(newLine);
                        }
                        else
                        {
                            result = false;
                            haserror = true;
                        }

                    }
                    catch (Exception exp)
                    {
                        result = false;
                        valErrors.Add(new ValidationError { Message = "Order Line Error: " + exp.Message, MessageClass = MessageClass.FailedInternalError});
                    }
                    iLineCount++;
                }

            }
            catch (Exception exp)
            {
                result = false;
                valErrors.Add(new ValidationError { Message = exp.Message, MessageClass = MessageClass.FailedInternalError});
            }
            return result;
        }

        /// <summary>
        /// Validate the product information
        /// </summary>
        /// <param name="productModel">Product Detail</param>
        /// <param name="azProduct">AutoZone product detail</param>
        /// <param name="valErrors">List of errors</param>
        /// <returns></returns>
        private bool ValidateProduct(ref ProductModel productModel,List<ValidationError> valErrors, int ordersupplierID,int countryOfOrigin)
        {
            bool result = true;
            try
            {
                string msg = string.Empty;
                using (ProductController controller = new ProductController())
                {
                    if (controller.GetByCode(productModel.ProductCode,ref msg))
                    {
                        //update the values - and update the unit price in the database
                        if (controller.Count > 0)
                        {
                            productModel.ProductID = controller[0].ProductID;
                            productModel.UnitWeight_KG = controller[0].UnitWeight_KG;
                            productModel.TariffCode = controller[0].TariffCode;
                            productModel.ProductStatusID = controller[0].ProductStatusID;
                            productModel.SupplierID = controller[0].SupplierID;
                            productModel.SupplierCode = controller[0].SupplierCode;
                            productModel.SupplierName = controller[0].SupplierName;

                            productModel.FIFO = controller[0].FIFO;
                            productModel.Contingency = controller[0].Contingency;
                            productModel.Marketing = controller[0].Marketing;
                            productModel.Claims = controller[0].Claims;


                            if (controller[0].CountryOfOrigin.HasValue)
                            {
                                countryOfOrigin = Convert.ToInt32(controller[0].CountryOfOrigin);
                                productModel.CountryOfOrigin = controller[0].CountryOfOrigin;
                            }
                            else
                                productModel.CountryOfOrigin = countryOfOrigin;


                            //we first need to check if the product is linked to the same supplier as the order
                            if (productModel.SupplierID != ordersupplierID)
                            {
                                //log the error, and exit - no need to carry on
                                valErrors.Add(new ValidationError { Message = "Product: " + productModel.ProductCode + " is linked to a different supplier [ " + productModel.SupplierName + " (" + productModel.SupplierCode + ") ] than this order.", MessageClass = MessageClass.FailedDataValidationError });
                                return false;
                            }

                            //update the unit price only - we do not care about the product status at this point - we also do not change the product status from the import
                            controller.UpdateUnitPriceOnly(Convert.ToDecimal(productModel.UnitPriceForeign), Convert.ToInt32(productModel.ProductID), 3, ref msg);

                            //check what the status is on this product
                            if (productModel.ProductStatusID == (byte)ProductStatus.Approved)
                            {

                                //check if this product has a tariff code
                                if (!string.IsNullOrEmpty(productModel.TariffCode))
                                {
                                    //we fist need to check if we dit not already validation this tariff code - the same code can be used on more then one product
                                    //no need to validate the same code more then once
                                    bool validateCode = true;

                                    if (validatedCodes.Count > 0)
                                    {
                                        foreach (CCLTariffCodeValidationModel m in validatedCodes)
                                        {
                                            if (m.TariffCode.Equals(productModel.TariffCode, StringComparison.CurrentCultureIgnoreCase))
                                            {
                                                validateCode = false;
                                                if (!m.Success)
                                                {
                                                    if (m.ResultMSG.Contains("on product"))
                                                    {
                                                        //we need to replace the product code whit tne new product code
                                                        string newMsg = m.ResultMSG;
                                                        int i = newMsg.IndexOf("on product");
                                                        newMsg = newMsg.Substring(0, newMsg.Length - ((newMsg.Length - (i + 10))));

                                                        result = false;
                                                        valErrors.Add(new ValidationError { Message = newMsg + " " + productModel.ProductCode, MessageClass = MessageClass.FailedDataValidationError });

                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }

                                    if (validateCode)
                                    {
                                        //we need to validate the tariff code lenght - must be 9 chars
                                        if (productModel.TariffCode.Trim().Length == 9)
                                        {
                                            //validate the linked products tariff Code
                                            result = ValidateTariffCode(productModel.TariffCode, productModel.ProductCode, valErrors,countryOfOrigin);
                                        }
                                        else
                                        {
                                            //do a diget look up
                                            result = LookupTCodeDiget(productModel.TariffCode, productModel.ProductCode, valErrors);
                                            if (!result)
                                                valErrors.Add(new ValidationError { Message = "Invalid tariff code " + productModel.TariffCode + " - code must be 9 characters, on product " + productModel.ProductCode, MessageClass = MessageClass.FailedDataValidationError });
                                            else
                                                result = ValidateTariffCode(productModel.TariffCode, productModel.ProductCode, valErrors,countryOfOrigin);
                                        }

                                        //add the validation results - may be used later if we get the same tariff code again in this file
                                        if (!result)
                                            validatedCodes.Add(new CCLTariffCodeValidationModel { TariffCode = productModel.TariffCode, Success = result, ResultMSG = valErrors[valErrors.Count - 1].Message });
                                        else
                                            validatedCodes.Add(new CCLTariffCodeValidationModel { TariffCode = productModel.TariffCode, Success = result });
                                    }
                                }
                                else
                                {
                                    result = false;
                                    valErrors.Add(new ValidationError { Message = "No Tariff Code linked to product " + productModel.ProductCode, MessageClass = MessageClass.FailedDataValidationError });
                                }
                            }
                            else
                            {
                                result = false;
                                valErrors.Add(new ValidationError { Message = "Product not yet Approved - Code: " + productModel.ProductCode + " Desc: " + productModel.ProductDescription, MessageClass = MessageClass.FailedDataValidationError });
                            }
                        }
                        else
                        {
                           //Create a new product - and mark the product as Pending - user will have to complete the missing detail firts
                            using (ProductModel newProd = new ProductModel())
                            {
                                newProd.ImporterID = productModel.ImporterID;
                                newProd.SupplierID = productModel.SupplierID;
                                newProd.SupplierProductCode = productModel.SupplierProductCode;
                                newProd.ProductCode = productModel.ProductCode;
                                newProd.ProductDescription = productModel.ProductDescription;
                                newProd.UnitPackQty = productModel.UnitPackQty;
                                newProd.UnitPriceForeign = productModel.UnitPriceForeign;
                                newProd.UnitWeight_KG = 0;
                                newProd.UnitDim1_CM = 0;
                                newProd.UnitDim2_CM = 0;
                                newProd.UnitDim3_CM = 0;
                                newProd.ProductStatusID = (byte)ProductStatus.Pending;
                                newProd.CountryOfOrigin = countryOfOrigin;

                                if (controller.Insert(newProd, 3, ref msg))
                                {
                                    valErrors.Add(new ValidationError { Message = "Product not found - Code: " + productModel.ProductCode + " Desc: " + productModel.ProductDescription + " New Product Created as Pending.", MessageClass = MessageClass.FailedDataValidationError });
                                }
                                else
                                {
                                    valErrors.Add(new ValidationError { Message = "Product ( " + productModel.ProductCode + ") - " + msg, MessageClass = MessageClass.FailedInternalError });
                                }
                                result = false; //if we need t add a new product we always set the result to fase - and add a error
                            }
                            
                        }
                    }
                    else
                    {
                        result = false;
                        valErrors.Add(new ValidationError { Message = "Product ( " + productModel.ProductCode + ") - " + msg, MessageClass = MessageClass.FailedInternalError});
                    }
                }
            }
            catch (Exception exp)
            {
                result = false;
                valErrors.Add(new ValidationError { Message = "Product ( " + productModel.ProductCode + ") - " + exp.Message, MessageClass = MessageClass.FailedInternalError});
            }

            return result;
        }

        /// <summary>
        /// Look up the corresonding unit type id
        /// </summary>
        /// <param name="unitType">Uit type description</param>
        /// <returns>Unit type id</returns>
        private byte? LookupUnitType(string unitType)
        {
            byte? result = null;
            try
            {
                string msg = string.Empty;
                using (UnitTypeController controller = new UnitTypeController())
                {
                    if (controller.Get(new UnitTypeModel { Name = unitType }, ref msg))
                    {
                        if (controller.Count > 0)
                            result = Convert.ToByte(controller[0].UnitTypeID);
                        else
                        {
                            //unit type is not found - lets add it
                            using (UnitTypeModel model = new UnitTypeModel())
                            {
                                model.Name = unitType;
                                model.IsActive = true;
                                model.IsDefault = false;
                                if (controller.Insert(model, ref msg))
                                    result = Convert.ToByte(model.UnitTypeID);
                            }
                        }
                    }
                }
            }
            catch
            {
                //unit type is not requierd - no need to worrie about errors
                result = null;
            }

            return result;

        }

        /// <summary>
        /// Validate the tariff Code against Compu-Clearing, update duty values
        /// </summary>
        /// <param name="tariffCode">Tariff Code to be validated</param>
        /// <returns>Bool value indicating success</returns>
        private bool ValidateTariffCode(string tariffCode,string productCode,List<ValidationError> valErrors,int countryID)
        {
            bool result = true;
            string msg = string.Empty;
            string tradeunion = "B";
            bool canUpdate = false;

            try
            {
                TariffBookModel model = new TariffBookModel();

                using (CCLTariffCodeValidationController cclCon = new CCLTariffCodeValidationController())
                {
                    //we first do a call to the general trade union - if not found - then thsi is a invalida tariff code
                    result = cclCon.Get(tariffCode, tradeunion, ref msg);

                    if (result)
                    {
                        //check the results
                        if (!cclCon[0].Success)
                        {
                            result = false;
                            valErrors.Add(new ValidationError { Message = "Tariff Code validation failed for code " + tariffCode + " on tradeunion - " + tradeunion + " for product " + productCode + " - " + cclCon[0].ResultMSG, MessageClass = MessageClass.FailedDataValidationError });
                            return result;
                        }
                        else
                        {
                            //get all the new values
                            model.TariffCode = cclCon[0].TariffCode;
                            model.LastUpdateDT = DateTime.Now;
                            model.s1P1Duty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P1Duty);
                            model.s1P2ACode = cclCon[0].s1P2ACode;
                            model.s1P2ADuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P2ADuty);
                            model.s1P2BDuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P2BDuty);
                            model.s1P3ACode = cclCon[0].s1P3ACode;
                            model.s1P3ADuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P3ADuty);
                            model.s1P3BCode = cclCon[0].s1P3BCode;
                            model.s1P3BDuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P3BDuty);
                            model.s1P3CCode = cclCon[0].s1P3CCode;
                            model.s1P3CDuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P3CDuty);
                            model.s1P3DCode = cclCon[0].s1P3DCode;
                            model.s1P3DDuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P3DDuty);
                            model.s1P5ADuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P5ADuty);
                            model.s1P5BDuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P5BDuty);
                            model.s2P1Duty = ControllerManager.Converter.ToDecimal(cclCon[0].s2P1Duty);
                            model.s2P1DutyCode = cclCon[0].s2P1DutyCode;
                            model.s2P2Duty = ControllerManager.Converter.ToDecimal(cclCon[0].s2P2Duty);
                            model.s2P2DutyCode = cclCon[0].s2P2DutyCode;
                            model.s2P3Duty = ControllerManager.Converter.ToDecimal(cclCon[0].s2P3Duty);
                            model.s2P3DutyCode = cclCon[0].s2P3DutyCode;
                            model.TotalDue = ControllerManager.Converter.ToDecimal(cclCon[0].TotalDue);
                            model.TotalDuties = ControllerManager.Converter.ToDecimal(cclCon[0].TotalDuties);
                            model.VatValue = ControllerManager.Converter.ToDecimal(cclCon[0].VatValue);

                            model.GenDuty = ControllerManager.Converter.ToDecimal(cclCon[0].s1P1Duty);

                            canUpdate = true;
                            //now we need to do the call to check the rest of the trade unions
                            for (int i = 0; i < 3; i++)
                            {
                                switch (i) //by defaul we set all the union values the same as the general duty - if values is found then it will override
                                {
                                    case 0:
                                        tradeunion = "S";
                                        model.SADCDuty = model.GenDuty;
                                        break;
                                    case 1:
                                        tradeunion = "F";
                                        model.EFTADuty = model.GenDuty;
                                        break;
                                    case 2:
                                        tradeunion = "E";
                                        model.EUDuty = model.GenDuty;
                                        break;
                                }

                                //do the call - we dont care if any of these calls fail - as some tariff codes do not have values in these unions
                                result = cclCon.Get(tariffCode, tradeunion, ref msg);
                                if (result)
                                {
                                    if (cclCon.Count > 0)
                                    {
                                        if (cclCon[0].Success)
                                        {
                                            switch (tradeunion)
                                            {
                                                case "E":
                                                    model.EUDuty = Convert.ToDecimal(cclCon[0].s1P1Duty);
                                                    break;
                                                case "F":
                                                    model.EFTADuty = Convert.ToDecimal(cclCon[0].s1P1Duty);
                                                    break;
                                                case "S":
                                                    model.SADCDuty = Convert.ToDecimal(cclCon[0].s1P1Duty);
                                                    break;
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }
                    else
                    {
                        result = false;
                        valErrors.Add(new ValidationError { Message = "Tariff Code validation failed for code " + tariffCode + " on product " + productCode + " - " + msg, MessageClass = MessageClass.FailedInternalError });
                    }
                }

                //update the current tariff code details
                if (canUpdate)
                {
                    using (TariffBookController controller = new TariffBookController())
                    {
                        model.TariffStatusID = 1;
                        model.UpdatedBy = 3;//system
                        //check if we must add the new code - or simply update existing code
                        result = controller.Get(new TariffBookModel { TariffCode = model.TariffCode }, ref msg);
                        if (result)
                        {
                            if (controller.Count > 0)
                                result = controller.Update(model, true, ref msg);
                            else
                                result = controller.Insert(model, ref msg);
                        }
                        if (!result)
                        {
                            canUpdate = false;
                            result = false;
                            valErrors.Add(new ValidationError { Message = "Updating Tariff Code " + tariffCode + " Failed - " + msg, MessageClass = MessageClass.FailedInternalError });
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                result = false;
                valErrors.Add(new ValidationError { Message = "Tariff Code validation failed for code " + tariffCode + " on product " + productCode + " - " + exp.Message, MessageClass = MessageClass.FailedInternalError});
            }

            return result;

        }

        /// <summary>
        /// Do a lookup on Compu-Clearing to find the missing diget for this code
        /// </summary>
        /// <param name="tariffCode"></param>
        /// <param name="productCode"></param>
        /// <param name="valErrors"></param>
        /// <returns></returns>
        private bool LookupTCodeDiget(string tariffCode, string productCode, List<ValidationError> valErrors)
        {
            bool result = true;
            string msg = string.Empty;
            string oldTariffCode = tariffCode;

            try
            {
                
                using (CCLTariffCodeValidationController cclCon = new CCLTariffCodeValidationController())
                {
                    result = cclCon.GetFinalDiget(tariffCode, ref msg);
                    if (result)
                    {
                        //check the results
                        if (!cclCon[0].Success)
                        {
                              result = false;
                        }
                        else
                        {
                            if (cclCon.Count > 0)
                            {
                                tariffCode = cclCon[0].TariffCode;
                            }
                            else
                                result = false;
                        }
                    }
                    else
                    {
                        result = false;
                        valErrors.Add(new ValidationError { Message = "Tariff Code validation failed for code " + tariffCode + " on product " + productCode + " - " + msg, MessageClass = MessageClass.FailedInternalError });
                    }

                    if (result)
                    {
                        //we need to update all the tariff codes
                        cclCon.UpdateProductTariffCode(oldTariffCode, tariffCode, ref msg);
                    }
                }
            }
            catch (Exception exp)
            {
                result = false;
                valErrors.Add(new ValidationError { Message = "Tariff Code validation failed for code " + tariffCode + " on product " + productCode + " - " + exp.Message, MessageClass = MessageClass.FailedInternalError });
            }

            return result;
        }
    }
}
