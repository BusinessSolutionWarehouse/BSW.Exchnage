using System;
using System.Collections.Generic;
using System.Text;


namespace PurchaseOrder.Data
{
	public partial class CountryModel
	{
		private string _CountryCode;
		private int? _CountryID;
		private string _CountryName;
		private int? _CurrencyID;
		private bool? _IsDeleted;
		private int? _OldCurrencyID;
		
		public CountryModel()
		{
		}

        public static bool FilterPredicate(string search, object item)
        {
            var obj = item as CountryModel;
            if (obj != null)
            {
                search = search.ToUpper();
                return (
                    obj.CountryCode.ToUpper().Contains(search.ToUpper()) ||
                    obj.CountryName.ToUpper().Contains(search.ToUpper())
                    );
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", CountryName.Trim(), CountryCode.Trim());
        }

		public string CountryCode
		{
			get { return _CountryCode; }
			set { _CountryCode = value; }
		}

		public int? CountryID
		{
			get { return _CountryID; }
			set { _CountryID = value; }
		}

		public string CountryName
		{
			get { return _CountryName; }
			set { _CountryName = value; }
		}

		public int? CurrencyID
		{
			get { return _CurrencyID; }
			set { _CurrencyID = value; }
		}

		public bool? IsDeleted
		{
			get { return _IsDeleted; }
			set { _IsDeleted = value; }
		}

		public int? OldCurrencyID
		{
			get { return _OldCurrencyID; }
			set { _OldCurrencyID = value; }
		}

        public string UnionCode { get; set; }

		public enum Fields
		{
			CountryCode = 0,
			CountryID = 1,
			CountryName = 2,
			CurrencyID = 3,
			IsDeleted = 4,
			OldCurrencyID = 5
		}
	}
}