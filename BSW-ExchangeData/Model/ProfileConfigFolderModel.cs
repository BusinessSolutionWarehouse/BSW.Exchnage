using System;
using System.Collections.Generic;
using System.Text;


namespace BSW_ExchangeData
{
	public partial class ProfileConfigFolderModel
	{
		private string _ErrorFolder;
		private string _FileExtention;
		private Int16? _FolderConfigID;
		private string _ProcessedFolder;
		private Byte? _ProfileID;
		private string _SourceFolder;
		
		public ProfileConfigFolderModel()
		{
		}

		public string ErrorFolder
		{
			get { return _ErrorFolder; }
			set { _ErrorFolder = value; }
		}

		public string FileExtention
		{
			get { return _FileExtention; }
			set { _FileExtention = value; }
		}

		public Int16? FolderConfigID
		{
			get { return _FolderConfigID; }
			set { _FolderConfigID = value; }
		}

		public string ProcessedFolder
		{
			get { return _ProcessedFolder; }
			set { _ProcessedFolder = value; }
		}

		public Byte? ProfileID
		{
			get { return _ProfileID; }
			set { _ProfileID = value; }
		}

		public string SourceFolder
		{
			get { return _SourceFolder; }
			set { _SourceFolder = value; }
		}

		public enum Fields
		{
			ErrorFolder = 0,
			FileExtention = 1,
			FolderConfigID = 2,
			ProcessedFolder = 3,
			ProfileID = 4,
			SourceFolder = 5
		}
	}
}