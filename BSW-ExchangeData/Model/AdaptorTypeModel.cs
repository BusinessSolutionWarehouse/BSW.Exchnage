using System;
using System.Collections.Generic;
using System.Text;


namespace BSW_ExchangeData
{
	public partial class AdaptorTypeModel
	{
		private Byte? _AdaptorTypeID;
		private string _Description;
		
		public AdaptorTypeModel()
		{
		}

		public Byte? AdaptorTypeID
		{
			get { return _AdaptorTypeID; }
			set { _AdaptorTypeID = value; }
		}

		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		public enum Fields
		{
			AdaptorTypeID = 0,
			Description = 1
		}
	}
}