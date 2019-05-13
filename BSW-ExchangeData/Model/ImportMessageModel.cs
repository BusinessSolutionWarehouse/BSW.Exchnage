using System;
using System.Collections.Generic;
using System.Text;


namespace BSW_ExchangeData
{
	public partial class ImportMessageModel:ModelBase
	{
		private string _ClientReference;
		private DateTime? _ImportDT;
		private Int64? _MessageID;
		private Byte? _MessageStatus;
		private Byte? _MessageTypeID;
		private Byte? _ProfileID;
		private string _XMLMessage;
		
		public ImportMessageModel()
		{
		}

		public string ClientReference1
		{
			get { return _ClientReference; }
			set { _ClientReference = value; }
		}

		public DateTime? ImportDT
		{
			get { return _ImportDT; }
			set { _ImportDT = value; }
		}

		public Int64? MessageID
		{
			get { return _MessageID; }
			set { _MessageID = value; }
		}

		public Byte? MessageStatus
		{
			get { return _MessageStatus; }
			set { _MessageStatus = value; }
		}

		public Byte? MessageTypeID
		{
			get { return _MessageTypeID; }
			set { _MessageTypeID = value; }
		}

		public Byte? ProfileID
		{
			get { return _ProfileID; }
			set { _ProfileID = value; }
		}

		public string XMLMessage
		{
			get { return _XMLMessage; }
			set { _XMLMessage = value; }
		}

        public string ClientReference2 { get; set; }

        public DateTime? MessageDt { get; set; }

        public long? ImportBatchID { get; set; }

        public int? Version { get; set; }

		
	}
}