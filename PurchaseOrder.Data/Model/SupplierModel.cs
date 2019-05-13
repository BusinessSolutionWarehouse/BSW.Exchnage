﻿using System;
using System.Collections.Generic;
using System.Text;


namespace PurchaseOrder.Data
{
    public class SupplierModel:ModelBase
    {
        public SupplierModel()
        {
        }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public int? SupplierID { get; set; }

        public string DefaultPortCode { get; set; }

        public int? CountryOfOriginID { get; set; }

        public string IncoTermCode { get; set; }

        public byte? TransportModeID { get; set; }

        public byte? PaymentTermID { get; set; }

        public int? DefaultCurrencyID { get; set; }

        public byte? PaymentTriggerID { get; set; }

        public int? SupplierRoleLinkID { get; set; }

        public byte? PaymentMethod { get; set; }

    }
}
