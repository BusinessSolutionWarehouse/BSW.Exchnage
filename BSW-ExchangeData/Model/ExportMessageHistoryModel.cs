using System;
using System.Collections.Generic;
using System.Text;


namespace BSW_ExchangeData
{
	public partial class ExportMessageHistoryModel:ModelBase
	{
		private string _Description;
		private Int64? _ExportMessageID;
		private DateTime? _HistoryDT;
		private Byte? _MessageClass;
		private Int64? _MessageHistoryID;
		private Byte? _MessageStatus;
		private bool? _NotificationSend;
		
		public ExportMessageHistoryModel()
		{
		}

		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		public Int64? ExportMessageID
		{
			get { return _ExportMessageID; }
			set { _ExportMessageID = value; }
		}

		public DateTime? HistoryDT
		{
			get { return _HistoryDT; }
			set { _HistoryDT = value; }
		}

		public Byte? MessageClass
		{
			get { return _MessageClass; }
			set { _MessageClass = value; }
		}

		public Int64? MessageHistoryID
		{
			get { return _MessageHistoryID; }
			set { _MessageHistoryID = value; }
		}

		public Byte? MessageStatus
		{
			get { return _MessageStatus; }
			set { _MessageStatus = value; }
		}

		public bool? NotificationSend
		{
			get { return _NotificationSend; }
			set { _NotificationSend = value; }
		}

		public enum Fields
		{
			Description = 0,
			ExportMessageID = 1,
			HistoryDT = 2,
			MessageClass = 3,
			MessageHistoryID = 4,
			MessageStatus = 5,
			NotificationSend = 6
		}
	}
}