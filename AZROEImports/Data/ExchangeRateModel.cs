using System;
using System.Collections.Generic;
using System.Text;


namespace AZROEImports
{
	public partial class ExchangeRateModel:ModelBase
	{

        public enum RowStatus
        {
            Unchanged = 1,
            Update = 2,
            New = 3,
            Remove = 4
        }

		private Int16? _ExchangeID;
		private string _FromCurrency;
		private decimal? _Rate;
		private string _ToCurrency;
		private DateTime? _UpdatedDt;
		private Int16? _UpdatedUserID;
        private RowStatus _rowStatus = RowStatus.Unchanged;
        private decimal _Inverse = 0;
        private bool _bEditFromCurrencyDisabled = true;
		
		public ExchangeRateModel()
		{
		}

		public Int16? ExchangeID
		{
			get { return _ExchangeID; }
			set { _ExchangeID = value; }
		}

        public bool EditFromCurrencyDisabled
        {
            get
            {
                return _bEditFromCurrencyDisabled;
            }
            set
            {
                _bEditFromCurrencyDisabled = value;
            }
        }

        public bool EditFromCurrencyEnabled
        {
            get
            { return !_bEditFromCurrencyDisabled; }
        }

        public virtual string FromCurrency
		{
			get { return _FromCurrency; }
            set { _FromCurrency = value; }
		}

		public virtual decimal? Rate
		{
			get { return _Rate; }
            set { _Rate = value; }
		}

		public string ToCurrency
		{
			get { return _ToCurrency; }
			set { _ToCurrency = value; }
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

        public string UpdatedBy { get; set; }

        public decimal Inverse 
        {
            get
            {
                if (!Rate.HasValue || Rate == 0)
                    _Inverse = Convert.ToDecimal(0.000);
                else
                {
                    _Inverse = 1 / Convert.ToDecimal(Rate);
                }

                return decimal.Round(_Inverse,4);
            }
            set
            {
                _Inverse = value;
            }
        }

        public RowStatus LineStatus
        {
            get { return _rowStatus; }
            set { _rowStatus = value; }
        }

        public string DisplayUpdateDT
        {
            get
            {
                if (UpdatedDt.HasValue)
                    return Convert.ToDateTime(UpdatedDt).ToString("yyyy-MM-dd HH:mm");
                else
                    return "";
            }
        }

        public string FromCurrencyName { get; set; }

        public string FromCurrencyCodeAndName
        {
            get { return string.Format("{0} ({1})", FromCurrency, FromCurrencyName); }
        }

        public int? BusinessEntityRoleLinkID { get; set; }


		public enum Fields
		{
			ExchangeID = 0,
			FromCurrency = 1,
			Rate = 2,
			ToCurrency = 3,
			UpdatedDt = 4,
			UpdatedUserID = 5
		}
	}
}