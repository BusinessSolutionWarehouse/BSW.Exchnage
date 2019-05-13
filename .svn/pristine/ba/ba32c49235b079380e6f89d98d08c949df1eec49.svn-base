using System;
using System.Collections.Generic;
using System.Text;


namespace PurchaseOrder.Data
{
	public partial class UnitTypeModel:ModelBase
	{
		private bool? _IsActive;
		private bool? _IsDefault;
		private string _Name;
		private int? _UnitTypeID;
		
		public UnitTypeModel()
		{
		}

		public bool? IsActive
		{
			get { return _IsActive; }
			set { _IsActive = value; }
		}

		public bool? IsDefault
		{
			get { return _IsDefault; }
			set { _IsDefault = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public int? UnitTypeID
		{
			get { return _UnitTypeID; }
			set { _UnitTypeID = value; }
		}

		public enum Fields
		{
			IsActive = 0,
			IsDefault = 1,
			Name = 2,
			UnitTypeID = 3
		}
	}
}