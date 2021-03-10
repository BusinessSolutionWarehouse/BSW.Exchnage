using System;
using System.Collections.Generic;
using System.Text;


namespace TariffBook.Data
{
	public partial class TariffBookAuditModel
	{
		private string _Action;
		private DateTime? _ActionDate;
		private Int16? _ActionUserID;
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
		private int? _TariffBookAuditID;
		private string _TariffCode;
		private Byte? _TariffStatusID;
		private decimal? _TotalDue;
		private decimal? _TotalDuties;
		private decimal? _VatValue;
		
		public TariffBookAuditModel()
		{
		}

		public string Action
		{
			get { return _Action; }
			set { _Action = value; }
		}

		public DateTime? ActionDate
		{
			get { return _ActionDate; }
			set { _ActionDate = value; }
		}

		public Int16? ActionUserID
		{
			get { return _ActionUserID; }
			set { _ActionUserID = value; }
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

		public int? TariffBookAuditID
		{
			get { return _TariffBookAuditID; }
			set { _TariffBookAuditID = value; }
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

		public enum Fields
		{
			Action = 0,
			ActionDate = 1,
			ActionUserID = 2,
			LastUpdateDT = 3,
			s1P1Duty = 4,
			s1P2ACode = 5,
			s1P2ADuty = 6,
			s1P2BDuty = 7,
			s1P3ACode = 8,
			s1P3ADuty = 9,
			s1P3BCode = 10,
			s1P3BDuty = 11,
			s1P3CCode = 12,
			s1P3CDuty = 13,
			s1P3DCode = 14,
			s1P3DDuty = 15,
			s1P5ADuty = 16,
			s1P5BDuty = 17,
			s2P1Duty = 18,
			s2P1DutyCode = 19,
			s2P2Duty = 20,
			s2P2DutyCode = 21,
			s2P3Duty = 22,
			s2P3DutyCode = 23,
			TariffBookAuditID = 24,
			TariffCode = 25,
			TariffStatusID = 26,
			TotalDue = 27,
			TotalDuties = 28,
			VatValue = 29
		}
	}
}