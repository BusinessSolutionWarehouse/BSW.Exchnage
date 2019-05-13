using System;
using System.Collections.Generic;
using System.Text;


namespace BSW_ExchangeData
{
	public partial class ProfileConfigFTPModel
	{
		private Int16? _FTPConfigID;
		private string _Password;
		private Byte? _ProfileID;
		private string _ServerAddress;
		private string _UserName;
		
		public ProfileConfigFTPModel()
		{
		}

		public Int16? FTPConfigID
		{
			get { return _FTPConfigID; }
			set { _FTPConfigID = value; }
		}

		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}

		public Byte? ProfileID
		{
			get { return _ProfileID; }
			set { _ProfileID = value; }
		}

		public string ServerAddress
		{
			get { return _ServerAddress; }
			set { _ServerAddress = value; }
		}

		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}

        public string FtpFolder { get; set; }

		public enum Fields
		{
			FTPConfigID = 0,
			Password = 1,
			ProfileID = 2,
			ServerAddress = 3,
			UserName = 4
		}
	}
}