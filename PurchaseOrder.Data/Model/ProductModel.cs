using System;
using System.Collections.Generic;
using System.Text;


namespace PurchaseOrder.Data
{
	public partial class ProductModel:ModelBase
	{
		private int? _ImporterID;
		private DateTime? _LatestUpdateDT;
		private string _ProductCode;
		private string _ProductDescription;
		private int? _ProductID;
		private Byte? _ProductStatusID;
		private int? _SupplierID;
		private string _SupplierProductCode;
		private string _TariffCode;
		private decimal? _UnitDim1_CM = 0;
		private decimal? _UnitDim2_CM = 0;
		private decimal? _UnitDim3_CM = 0;
		private int? _UnitPackQty = 1;
		private decimal? _UnitPriceForeign;
		private decimal? _UnitWeight_KG = 0;
		
		public ProductModel()
		{
		}

		public int? ImporterID
		{
			get { return _ImporterID; }
			set { _ImporterID = value; }
		}

		public DateTime? LatestUpdateDT
		{
			get { return _LatestUpdateDT; }
			set { _LatestUpdateDT = value; }
		}

		public string ProductCode
		{
			get { return _ProductCode; }
			set { _ProductCode = value; }
		}

		public string ProductDescription
		{
			get { return _ProductDescription; }
			set { _ProductDescription = value; }
		}

		public int? ProductID
		{
			get { return _ProductID; }
			set { _ProductID = value; }
		}

		public Byte? ProductStatusID
		{
			get { return _ProductStatusID; }
			set { _ProductStatusID = value; }
		}

		public int? SupplierID
		{
			get { return _SupplierID; }
			set { _SupplierID = value; }
		}

		public string SupplierProductCode
		{
			get { return _SupplierProductCode; }
			set { _SupplierProductCode = value; }
		}

		public string TariffCode
		{
			get { return _TariffCode; }
			set { _TariffCode = value; }
		}

		public decimal? UnitDim1_CM
		{
			get { return _UnitDim1_CM; }
			set { _UnitDim1_CM = value; }
		}

		public decimal? UnitDim2_CM
		{
			get { return _UnitDim2_CM; }
			set { _UnitDim2_CM = value; }
		}

		public decimal? UnitDim3_CM
		{
			get { return _UnitDim3_CM; }
			set { _UnitDim3_CM = value; }
		}

		public int? UnitPackQty
		{
			get { return _UnitPackQty; }
			set { _UnitPackQty = value; }
		}

		public decimal? UnitPriceForeign
		{
			get { return _UnitPriceForeign; }
			set { _UnitPriceForeign = value; }
		}

		public decimal? UnitWeight_KG
		{
			get { return _UnitWeight_KG; }
			set { _UnitWeight_KG = value; }
		}

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public decimal? FIFO { get; set; }

        public decimal? Contingency { get; set; }

        public decimal? Marketing { get; set; }

        public decimal? Claims { get; set; }

        public int? CountryOfOrigin { get; set; }

		public enum Fields
		{
			DurtyPercentage = 0,
			ImporterID = 1,
			LatestUpdateDT = 2,
			ProductCode = 3,
			ProductDescription = 4,
			ProductID = 5,
			ProductStatusID = 6,
			SupplierID = 7,
			SupplierProductCode = 8,
			TariffCode = 9,
			UnitDim1_CM = 10,
			UnitDim2_CM = 11,
			UnitDim3_CM = 12,
			UnitPackQty = 13,
			UnitPriceForeign = 14,
			UnitWeight_KG = 15
		}
	}
}