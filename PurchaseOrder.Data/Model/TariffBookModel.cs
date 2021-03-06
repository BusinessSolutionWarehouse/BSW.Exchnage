using System;
using System.Collections.Generic;
using System.Text;


namespace PurchaseOrder.Data
{
	public partial class TariffBookModel
	{
		private DateTime? _LastUpdateDT;
		private decimal? _s1P1Duty;
		private string _s1P2ACode;
		private decimal? _s1P2ADuty;
		private decimal? _s1P2BDuty;
		private string _s1P3ACode;
		private decimal? _s1P3ADuty;
		private string _s1P3BCode;
		private decimal? _s1P3BDuty;
		private string _s1P3CCode;
		private decimal? _s1P3CDuty;
		private string _s1P3DCode;
		private decimal? _s1P3DDuty;
		private decimal? _s1P5ADuty;
		private decimal? _s1P5BDuty;
		private decimal? _s2P1Duty;
		private string _s2P1DutyCode;
		private decimal? _s2P2Duty;
		private string _s2P2DutyCode;
		private decimal? _s2P3Duty;
		private string _s2P3DutyCode;
		private string _TariffCode;
		private Byte? _TariffStatusID;
		private decimal? _TotalDue;
		private decimal? _TotalDuties;
		private decimal? _VatValue;
        private decimal? _SADCDuty;
        private decimal? _EUDuty;
        private decimal? _GenDuty;
        private decimal? _EFTADuty;

		
		public TariffBookModel()
		{
		}

		public DateTime? LastUpdateDT
		{
			get { return _LastUpdateDT; }
			set { _LastUpdateDT = value; }
		}

		public decimal? s1P1Duty
		{
			get { return _s1P1Duty; }
			set { _s1P1Duty = value; }
		}

		public string s1P2ACode
		{
			get { return _s1P2ACode; }
			set { _s1P2ACode = value; }
		}

		public decimal? s1P2ADuty
		{
			get { return _s1P2ADuty; }
			set { _s1P2ADuty = value; }
		}

		public decimal? s1P2BDuty
		{
			get { return _s1P2BDuty; }
			set { _s1P2BDuty = value; }
		}

		public string s1P3ACode
		{
			get { return _s1P3ACode; }
			set { _s1P3ACode = value; }
		}

		public decimal? s1P3ADuty
		{
			get { return _s1P3ADuty; }
			set { _s1P3ADuty = value; }
		}

		public string s1P3BCode
		{
			get { return _s1P3BCode; }
			set { _s1P3BCode = value; }
		}

		public decimal? s1P3BDuty
		{
			get { return _s1P3BDuty; }
			set { _s1P3BDuty = value; }
		}

		public string s1P3CCode
		{
			get { return _s1P3CCode; }
			set { _s1P3CCode = value; }
		}

		public decimal? s1P3CDuty
		{
			get { return _s1P3CDuty; }
			set { _s1P3CDuty = value; }
		}

		public string s1P3DCode
		{
			get { return _s1P3DCode; }
			set { _s1P3DCode = value; }
		}

		public decimal? s1P3DDuty
		{
			get { return _s1P3DDuty; }
			set { _s1P3DDuty = value; }
		}

		public decimal? s1P5ADuty
		{
			get { return _s1P5ADuty; }
			set { _s1P5ADuty = value; }
		}

		public decimal? s1P5BDuty
		{
			get { return _s1P5BDuty; }
			set { _s1P5BDuty = value; }
		}

		public decimal? s2P1Duty
		{
			get { return _s2P1Duty; }
			set { _s2P1Duty = value; }
		}

		public string s2P1DutyCode
		{
			get { return _s2P1DutyCode; }
			set { _s2P1DutyCode = value; }
		}

		public decimal? s2P2Duty
		{
			get { return _s2P2Duty; }
			set { _s2P2Duty = value; }
		}

		public string s2P2DutyCode
		{
			get { return _s2P2DutyCode; }
			set { _s2P2DutyCode = value; }
		}

		public decimal? s2P3Duty
		{
			get { return _s2P3Duty; }
			set { _s2P3Duty = value; }
		}

		public string s2P3DutyCode
		{
			get { return _s2P3DutyCode; }
			set { _s2P3DutyCode = value; }
		}

		public string TariffCode
		{
			get { return _TariffCode; }
			set { _TariffCode = value; }
		}

		public Byte? TariffStatusID
		{
			get { return _TariffStatusID; }
			set { _TariffStatusID = value; }
		}

		public decimal? TotalDue
		{
			get { return _TotalDue; }
			set { _TotalDue = value; }
		}

		public decimal? TotalDuties
		{
			get { return _TotalDuties; }
			set { _TotalDuties = value; }
		}

		public decimal? VatValue
		{
			get { return _VatValue; }
			set { _VatValue = value; }
		}

        public Int32 UpdatedBy { get; set; }

        public decimal? SADCDuty
        {
            get {return _SADCDuty;}
            set{_SADCDuty = value;}
        }

        public decimal? EUDuty
        {
            get{return _EUDuty;}
            set{_EUDuty = value;}
        }

        public decimal? GenDuty
        {
            get{return _GenDuty;}
            set{_GenDuty = value;}
        }

        public decimal? EFTADuty
        {
            get { return _EFTADuty; }
            set { _EFTADuty = value; }
        }

		public enum Fields
		{
			LastUpdateDT = 0,
			s1P1Duty = 1,
			s1P2ACode = 2,
			s1P2ADuty = 3,
			s1P2BDuty = 4,
			s1P3ACode = 5,
			s1P3ADuty = 6,
			s1P3BCode = 7,
			s1P3BDuty = 8,
			s1P3CCode = 9,
			s1P3CDuty = 10,
			s1P3DCode = 11,
			s1P3DDuty = 12,
			s1P5ADuty = 13,
			s1P5BDuty = 14,
			s2P1Duty = 15,
			s2P1DutyCode = 16,
			s2P2Duty = 17,
			s2P2DutyCode = 18,
			s2P3Duty = 19,
			s2P3DutyCode = 20,
			TariffCode = 21,
			TariffStatusID = 22,
			TotalDue = 23,
			TotalDuties = 24,
			VatValue = 25
		}
	}
}