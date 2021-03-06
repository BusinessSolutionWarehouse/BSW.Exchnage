﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using BSW_ExchangeShared;
using System.Globalization;

namespace BSW_ExchangeShared
{
    

    public class ImportOrderValidation:IDisposable
    {

        public static string[] DateFormats = new string[] { "yyyyMMdd", "yyyy/MM/dd", "yyyy-MM-dd", "yyyy/MM/dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss.fff", "yyyy-MM-ddTHH:mm:ss.fff" };

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

        public ImportOrderValidation()
        {

        }

        #endregion

        public byte ProfileID { get; set; }

        /// <summary>
        /// Validate the main structure of the xml file
        /// </summary>
        /// <param name="doc">active xml document</param>
        /// <param name="result">Validation results</param>
        /// <returns></returns>
        public bool ValidateStructure(XDocument doc,string result)
        {
            bool results = true;
            try
            {
               //Check if we have a messageHeader
               var messageHeader = from d in doc.Elements("Message").Elements("MessageHeader") select d;
               if (messageHeader == null)
               {
                   results = false;
                   result = "Invalid xml file structure - missing <MessageHeader> tag.";
                   return results;
               }
                //check the message body tag
               var messageBody = from d in doc.Elements("Message").Elements("MessageBody") select d;
               if (messageBody == null)
               {
                   results = false;
                   result = "Invalid xml file structure - missing <MessageBody> tag.";
                   return results;
               }

               //once we checked th main tags - we now check the requiered tags in the body
               var order = from d in doc.Element("Message").Elements("MessageBody").Elements("Order") select d;
               if (order == null)
               {
                   results = false;
                   result = "Invalid xml file structure - missing <Order> tag.";
                   return results;
               }
                //finally we check the tags with in the order tag
               var supplier = from d in order.Elements("Supplier") select d;
               if (supplier == null)
               {
                   results = false;
                   result = "Invalid xml file structure - missing <Supplier> tag.";
                   return results;
               }
                var routing = from d in order.Elements("Routing") select d;
                if (routing == null)
                {
                    results = false;
                    result = "Invalid xml file structure - missing <Routing> tag.";
                    return results;
                }
                var letterCredit = from d in order.Elements("LetterOfCredit") select d;
                if (letterCredit == null)
                {
                    results = false;
                    result = "Invalid xml file structure - missing <LetterOfCredit> tag.";
                    return results;
                }
                var orderLines = from d in order.Elements("OrderLine") select d;
                if (orderLines == null)
                {
                    results = false;
                    result = "Invalid xml file structure - missing <OrderLine> tag.";
                    return results;
                }
            }
            catch (Exception exp)
            {
                results = false;
                EventLog.LogProfileEvent(ProfileID, exp.Message, EventLogType.Error);
            }
            return results;
        }

        /// <summary>
        /// Validate all the requiered fields
        /// </summary>
        /// <param name="xdoc">Active xml document</param>
        /// <param name="lstValError">List of missing requiered values</param>
        /// <returns>Overall result of the validation</returns>
        public bool ValidateRequieredFields(XDocument xdoc, List<ValidationError> valErrors,bool isAdaptor,ref string orderNumber)
        {
            bool result = true;

            try
            {
                
                //MessageHeader
                var messageHeader = from d in xdoc.Elements("Message").Elements("MessageHeader") select d;

                XElement messageID = messageHeader.FirstOrDefault().Element("MessageID");
                if (messageID == null)
                {
                    valErrors.Add(new ValidationError { Message = @"This XML element is missing '<MessageID>' ",MessageClass = MessageClass.FailedStructuraError });
                }

                XElement messageDate = messageHeader.FirstOrDefault().Element("MessageDate");
                if (messageDate == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<MessageDate>' ", MessageClass = MessageClass.FailedStructuraError }); }

                XElement senderID = messageHeader.FirstOrDefault().Element("SenderID");
                if (senderID == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<SenderID>' ", MessageClass = MessageClass.FailedStructuraError }); }


                //Orders
                var orders = from d in xdoc.Element("Message").Elements("MessageBody").Elements("Order") select d;

                foreach (var order in orders)
                {
                    XElement orderNo = order.Element("OrderNo");
                    if (orderNo == null)
                    {
                        valErrors.Add(new ValidationError { Message = @"This XML element is missing '<OrderNo>' ", MessageClass = MessageClass.FailedStructuraError });
                    }
                    else
                        orderNumber = orderNo.Value;

                    if (!isAdaptor)
                    {
                        XElement orderDate = order.Element("OrderDate");
                        if (orderDate == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<OrderDate>' ", MessageClass = MessageClass.FailedStructuraError }); }
                    }
                    if (!isAdaptor)
                    {
                        XElement incoTerm = order.Element("INCOTerm");
                        if (incoTerm == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<INCOTerm>' ", MessageClass = MessageClass.FailedStructuraError }); }
                    }
                    if (!isAdaptor) //Routing - ot requiered
                    {
                        XElement transportMode = order.Element("Routing").Element("TransportMode");
                        if (transportMode == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Routing><TransportMode>' ", MessageClass = MessageClass.FailedStructuraError }); }

                        XElement placeOfReceipt = order.Element("Routing").Element("PlaceOfReceipt");
                        if (placeOfReceipt == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Routing><PlaceOfReceipt>' ", MessageClass = MessageClass.FailedStructuraError }); }

                        XElement finalDestination = order.Element("Routing").Element("FinalDestination");
                        if (finalDestination == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Routing><FinalDestination>' ", MessageClass = MessageClass.FailedStructuraError }); }

                    }
                    //Supplier tag                    
                    XElement supplierCode = order.Element("Supplier").Element("SupplierCode");
                    if (supplierCode == null)
                    {
                        valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Supplier><SupplierCode>' ", MessageClass = MessageClass.FailedStructuraError });
                    }

                    //Orders lines
                    var orderLines = from d in order.Elements("OrderLine") select d;

                    foreach (var orderLine in orderLines)
                    {
                        XAttribute attribute = orderLine.Attribute("UniqueID");
                        if ((attribute == null) || (attribute.Value == string.Empty))
                        {
                            valErrors.Add(new ValidationError { Message = @"This XML element attribute is missing. <OrderLine UniqueID>' ", MessageClass = MessageClass.FailedStructuraError });
                        }

                        XElement description = orderLine.Element("Description");
                        if (description == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<OrderLine><Description>' ", MessageClass = MessageClass.FailedStructuraError }); }

                        XElement itemcode = orderLine.Element("ItemCode");
                        if (itemcode == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<OrderLine><ItemCode>' ", MessageClass = MessageClass.FailedStructuraError }); }

                    }
                
                }

            }
            catch (Exception ex)
            {
                result = false;
                EventLog.LogProfileEvent(ProfileID, ex.Message, EventLogType.Error);
            }

            return result;
        }

        /// <summary>
        /// Get and validate the message id and Message date
        /// </summary>
        /// <param name="xdoc">XML Document</param>
        /// <param name="messageDT">return message date</param>
        /// <param name="messageID">return message id</param>
        /// <param name="valErrors">List of errors - if any</param>
        /// <returns></returns>
        public bool GetMessageIDAndDate(XDocument xdoc, ref DateTime messageDT, ref string messageID, List<ValidationError> valErrors)
        {
            bool result = true;
            try
            {
                var messageHeader = from d in xdoc.Elements("Message").Elements("MessageHeader") select d;

                messageID = messageHeader.FirstOrDefault().Element("MessageID").Value;
                if (string.IsNullOrEmpty(messageID)) { valErrors.Add(new ValidationError { Message = "Invalid xml file structure - missing <MessageHeader><MessageID> tag.", MessageClass = MessageClass.FailedStructuraError }); result = false; }

                //validate the date
                bool success = DateTime.TryParseExact(messageHeader.FirstOrDefault().Element("MessageDate").Value, DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out messageDT);
                if (!success) { valErrors.Add(new ValidationError { Message = "Date format must be 'yyyy/MM/dd' or 'yyyy-MM-dd HH:mm:ss' (Error Line: <MessageHeader><MessageDate>) ", MessageClass = MessageClass.FailedStructuraError }); result = false; }

            }
            catch (Exception exp)
            {
                result = false;
                valErrors.Add(new ValidationError { Message = exp.Message });
            }

            return result;
        }
    }
}
