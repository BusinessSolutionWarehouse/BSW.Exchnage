using System;
using System.Collections.Generic;
using System.Text;


namespace BSW_ExchangeData
{
	public partial class ExportMessageBatchModel:ModelBase
	{
		private DateTime? _BatchCompleteDT;
		private DateTime? _BatchStartDT;
		private string _BatchUniqueKey;
		private Int64? _ExportBatchID;
		
		public ExportMessageBatchModel()
		{
		}

		public DateTime? BatchCompleteDT
		{
			get { return _BatchCompleteDT; }
			set { _BatchCompleteDT = value; }
		}

		public DateTime? BatchStartDT
		{
			get { return _BatchStartDT; }
			set { _BatchStartDT = value; }
		}

		public string BatchUniqueKey
		{
			get { return _BatchUniqueKey; }
			set { _BatchUniqueKey = value; }
		}

		public Int64? ExportBatchID
		{
			get { return _ExportBatchID; }
			set { _ExportBatchID = value; }
		}

		public enum Fields
		{
			BatchCompleteDT = 0,
			BatchStartDT = 1,
			BatchUniqueKey = 2,
			ExportBatchID = 3
		}
	}
}