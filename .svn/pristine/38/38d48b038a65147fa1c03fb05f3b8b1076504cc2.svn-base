using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ProfileConfigFolderController : List<ProfileConfigFolderModel>, IController
	{
		public bool Get(ProfileConfigFolderModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ProfileConfigFolderModel model, ProfileConfigFolderModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.ErrorFolder))
					listParameters.Add(ControllerManager.CreateParameter("@ErrorFolder", model.ErrorFolder, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.FileExtention))
					listParameters.Add(ControllerManager.CreateParameter("@FileExtention", model.FileExtention, SqlDbType.Char));

				if (model.FolderConfigID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FolderConfigID", model.FolderConfigID.Value, SqlDbType.SmallInt));

				if (!string.IsNullOrEmpty(model.ProcessedFolder))
					listParameters.Add(ControllerManager.CreateParameter("@ProcessedFolder", model.ProcessedFolder, SqlDbType.VarChar));

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.SourceFolder))
					listParameters.Add(ControllerManager.CreateParameter("@SourceFolder", model.SourceFolder, SqlDbType.VarChar));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXProfileConfigFolderGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ProfileConfigFolderModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ErrorFolder", model.ErrorFolder, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@FileExtention", model.FileExtention, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@ProcessedFolder", model.ProcessedFolder, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@SourceFolder", model.SourceFolder, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXProfileConfigFolderInsert", listParameters, ref value, ref msg);

				if (result)
					model.FolderConfigID = ControllerManager.Converter.ToInt16(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ProfileConfigFolderModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@FolderConfigID", model.FolderConfigID.Value, SqlDbType.SmallInt));

				if (dynamicUpdate)
				{
					if (!string.IsNullOrEmpty(model.ErrorFolder))
						listParameters.Add(ControllerManager.CreateParameter("@ErrorFolder", model.ErrorFolder, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.FileExtention))
						listParameters.Add(ControllerManager.CreateParameter("@FileExtention", model.FileExtention, SqlDbType.Char));

					if (!string.IsNullOrEmpty(model.ProcessedFolder))
						listParameters.Add(ControllerManager.CreateParameter("@ProcessedFolder", model.ProcessedFolder, SqlDbType.VarChar));

					if (model.ProfileID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

					if (!string.IsNullOrEmpty(model.SourceFolder))
						listParameters.Add(ControllerManager.CreateParameter("@SourceFolder", model.SourceFolder, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@ErrorFolder", model.ErrorFolder, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@FileExtention", model.FileExtention, SqlDbType.Char));
					listParameters.Add(ControllerManager.CreateParameter("@ProcessedFolder", model.ProcessedFolder, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@SourceFolder", model.SourceFolder, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXProfileConfigFolderUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ProfileConfigFolderModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.ErrorFolder))
					listParameters.Add(ControllerManager.CreateParameter("@ErrorFolder", model.ErrorFolder, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.FileExtention))
					listParameters.Add(ControllerManager.CreateParameter("@FileExtention", model.FileExtention, SqlDbType.Char));

				if (model.FolderConfigID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FolderConfigID", model.FolderConfigID.Value, SqlDbType.SmallInt));

				if (!string.IsNullOrEmpty(model.ProcessedFolder))
					listParameters.Add(ControllerManager.CreateParameter("@ProcessedFolder", model.ProcessedFolder, SqlDbType.VarChar));

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.SourceFolder))
					listParameters.Add(ControllerManager.CreateParameter("@SourceFolder", model.SourceFolder, SqlDbType.VarChar));

				result = ControllerManager.ExecuteSP("BSWXProfileConfigFolderDelete", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool ReadModelData(SqlDataReader reader, ref string msg)
		{
			try
			{
				ProfileConfigFolderModel model = new ProfileConfigFolderModel();

				model.ErrorFolder = ControllerManager.Converter.ToString(reader["ErrorFolder"]);
				model.FileExtention = ControllerManager.Converter.ToString(reader["FileExtention"]);
				model.FolderConfigID = ControllerManager.Converter.ToInt16(reader["FolderConfigID"]);
				model.ProcessedFolder = ControllerManager.Converter.ToString(reader["ProcessedFolder"]);
				model.ProfileID = ControllerManager.Converter.ToByte(reader["ProfileID"]);
				model.SourceFolder = ControllerManager.Converter.ToString(reader["SourceFolder"]);

				this.Add(model);

				return true;
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				return false;
			}
		}

		public void ClearModelData()
		{
			Clear();
		}

		#region - Methods : Dispose -

		private bool _disposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					ClearModelData();
				}
			}
			_disposed = true;
		}

		#endregion
	}
}
