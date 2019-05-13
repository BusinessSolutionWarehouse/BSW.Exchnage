using System;
using System.Collections.Generic;
using System.Text;


namespace PurchaseOrder.Data
{
	public partial class OrderLineModel
	{
        private decimal? _ClaimsPercentage;
        private decimal? _ContingencyPercentage;
        private DateTime? _CreatedDt;
        private Int16? _CreatedUserID;
        private string _Description;
        private decimal? _FIFOPercentage;
        private decimal? _MarketingPercentage;
        private DateTime? _OnSiteDt;
        private int? _OrderID;
        private int? _OrderLineID;
        private Int16? _OrderLineStatusID;
        private int? _ProductID;
        private string _SupplierRefNo;
        private string _TariffCode;
        private decimal? _TotalVolume;
        private decimal? _TotalWeight;
        private Int16? _UnitCurrencyID;
        private decimal? _UnitPrice;
        private int? _UnitQuantity;
        private Byte? _UnitTypeID;
        private DateTime? _UpdatedDt;
        private Int16? _UpdatedUserID;

        public OrderLineModel()
        {
        }

        public decimal? ClaimsPercentage
        {
            get { return _ClaimsPercentage; }
            set { _ClaimsPercentage = value; }
        }

        public decimal? ContingencyPercentage
        {
            get { return _ContingencyPercentage; }
            set { _ContingencyPercentage = value; }
        }

        public DateTime? CreatedDt
        {
            get { return _CreatedDt; }
            set { _CreatedDt = value; }
        }

        public Int16? CreatedUserID
        {
            get { return _CreatedUserID; }
            set { _CreatedUserID = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public decimal? FIFOPercentage
        {
            get { return _FIFOPercentage; }
            set { _FIFOPercentage = value; }
        }

        public decimal? MarketingPercentage
        {
            get { return _MarketingPercentage; }
            set { _MarketingPercentage = value; }
        }

        public DateTime? OnSiteDt
        {
            get { return _OnSiteDt; }
            set { _OnSiteDt = value; }
        }

        public int? OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        public int? OrderLineID
        {
            get { return _OrderLineID; }
            set { _OrderLineID = value; }
        }

        public Int16? OrderLineStatusID
        {
            get { return _OrderLineStatusID; }
            set { _OrderLineStatusID = value; }
        }

        public int? ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        public string SupplierRefNo
        {
            get { return _SupplierRefNo; }
            set { _SupplierRefNo = value; }
        }

        public string TariffCode
        {
            get { return _TariffCode; }
            set { _TariffCode = value; }
        }

        public decimal? TotalVolume
        {
            get { return _TotalVolume; }
            set { _TotalVolume = value; }
        }

        public decimal? TotalWeight
        {
            get { return _TotalWeight; }
            set { _TotalWeight = value; }
        }

        public Int16? UnitCurrencyID
        {
            get { return _UnitCurrencyID; }
            set { _UnitCurrencyID = value; }
        }

        public decimal? UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        public int? UnitQuantity
        {
            get { return _UnitQuantity; }
            set { _UnitQuantity = value; }
        }

        public Byte? UnitTypeID
        {
            get { return _UnitTypeID; }
            set { _UnitTypeID = value; }
        }

        public DateTime? UpdatedDt
        {
            get { return _UpdatedDt; }
            set { _UpdatedDt = value; }
        }

        public Int16? UpdatedUserID
        {
            get { return _UpdatedUserID; }
            set { _UpdatedUserID = value; }
        }

        public enum Fields
        {
            ClaimsPercentage = 0,
            ContingencyPercentage = 1,
            CreatedDt = 2,
            CreatedUserID = 3,
            Description = 4,
            FIFOPercentage = 5,
            MarketingPercentage = 6,
            OnSiteDt = 7,
            OrderID = 8,
            OrderLineID = 9,
            OrderLineStatusID = 10,
            ProductID = 11,
            SupplierRefNo = 12,
            TariffCode = 13,
            TotalVolume = 14,
            TotalWeight = 15,
            UnitCurrencyID = 16,
            UnitPrice = 17,
            UnitQuantity = 18,
            UnitTypeID = 19,
            UpdatedDt = 20,
            UpdatedUserID = 21
        }
    }
}