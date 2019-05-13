using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BSW_ExchangeShared
{
    public class PackListValidation :IDisposable
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

        public PackListValidation()
        {
        }

        #endregion

        public byte ProfileID { get; set; }

        /// <summary>
        /// Validate the main structure of the xml file
        /// </summary>
        /// <param name="doc">Active xml document</param>
        /// <param name="result">Validation results</param>
        /// <returns></returns>
        public bool ValidateStructure(XDocument doc, string result)
        {
            bool results = true;

            try
            {
                // add validations in here once we have a packlist XML document
            }
            catch (Exception exp)
            {
                results = false;
                EventLog.LogProfileEvent(ProfileID, exp.Message, EventLogType.Error);
            }

            return results;
        }

        /// <summary>
        /// Validate all the required fields
        /// </summary>
        /// <param name="xdoc">Active xml document</param>
        /// <param name="lstValError">List of missing required values</param>
        /// <returns>Overall result of the validation</returns>
        public bool ValidateRequiredFields(XDocument xdoc, List<ValidationError> valErrors, bool isAdaptor, ref string ID)
        {
            bool result = true;

            try
            {
                // Pack List Message Header
                var messageHeader = from d in xdoc.Elements("Message").Elements("MessageHeader") select d;

                XElement messageID = messageHeader.FirstOrDefault().Element("MessageID");
                if (messageID == null) valErrors.Add(new ValidationError { Message = @"This XML element is missing '<MessageID>' ", MessageClass = MessageClass.FailedStructuraError });
                ID = messageID.Value.ToString();

                XElement messageDate = messageHeader.FirstOrDefault().Element("MessageDate");
                if (messageDate == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<MessageDate>' ", MessageClass = MessageClass.FailedStructuraError }); }

                XElement senderID = messageHeader.FirstOrDefault().Element("SenderID");
                if (senderID == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<SenderID>' ", MessageClass = MessageClass.FailedStructuraError }); }

                // Pack List Message Body
                var messageBody = from d in xdoc.Elements("Message").Elements("MessageBody") select d;

                XElement exporterName = messageBody.FirstOrDefault().Element("Exporter").Element("Name");
                if (exporterName == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Exporter><Name>' ", MessageClass = MessageClass.FailedStructuraError }); }

                XElement exporterCode = messageBody.FirstOrDefault().Element("Exporter").Element("Code");
                if (exporterCode == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Exporter><Code>' ", MessageClass = MessageClass.FailedStructuraError }); }

                XElement hellmannRef = messageBody.FirstOrDefault().Element("HellmannRef");
                if (hellmannRef == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<HellmanRef>' ", MessageClass = MessageClass.FailedStructuraError }); }

                // Containers
                var containers = from d in xdoc.Element("Message").Elements("MessageBody").Elements("Container") select d;

                foreach (var container in containers)
                {
                    XElement exporterRef = container.Element("ExporterRef");
                    if (exporterRef == null) valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Container><ExporterRef>' ", MessageClass = MessageClass.FailedStructuraError });

                    XElement containerNo = container.Element("ContainerNo");
                    if (containerNo == null) valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Container><ContainerNo>' ", MessageClass = MessageClass.FailedStructuraError });
                    
                    XElement size = container.Element("Size");
                    if (size == null) valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Container><Size>' ", MessageClass = MessageClass.FailedStructuraError });
                    
                    XElement type = container.Element("Type");
                    if (type == null) valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Container><Type>' ", MessageClass = MessageClass.FailedStructuraError });
                    
                    // Pallets
                    var pallets = from d in container.Elements("Pallet") select d;

                    foreach (var pallet in pallets)
                    {
                        XElement qtyInCarton = pallet.Element("QtyInCarton");
                        if (qtyInCarton == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Pallet><QtyInCarton>' ", MessageClass = MessageClass.FailedStructuraError }); }

                        XElement noOfCartons = pallet.Element("NoOfCartons");
                        if (noOfCartons == null) { valErrors.Add(new ValidationError { Message = @"This XML element is missing '<Pallet><NoOfCartons>' ", MessageClass = MessageClass.FailedStructuraError }); }
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
        /// Get and validate the message id 
        /// </summary>
        /// <param name="xdoc">XML Document</param>
        /// <param name="messageDT">return message date</param>
        /// <param name="valErrors">List of errors - if any</param>
        /// <returns></returns>
        public bool GetMessageID(XDocument xdoc, ref string messageID, List<ValidationError> valErrors)
        {
            bool result = true;
            try
            {
                var packList = from d in xdoc.Descendants("MessageHeader") select d;
                messageID = packList.FirstOrDefault().Element("MessageID").Value;
                if (string.IsNullOrEmpty(messageID)) { valErrors.Add(new ValidationError { Message = "Invalid xml file structure - missing <MessageHeader><MessageID> tag.", MessageClass = MessageClass.FailedStructuraError }); result = false; }
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
