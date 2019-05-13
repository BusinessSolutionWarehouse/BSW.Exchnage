using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ProfileConfigFTPController : List<ProfileConfigFTPModel>, IDisposable, IController
	{
		public bool Get(ProfileConfigFTPModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ProfileConfigFTPModel model, ProfileConfigFTPModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.FTPConfigID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FTPConfigID", model.FTPConfigID.Value, SqlDbType.SmallInt));

				if (!string.IsNullOrEmpty(model.Password))
					listParameters.Add(ControllerManager.CreateParameter("@Password", model.Password, SqlDbType.VarChar));

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ServerAddress))
					listParameters.Add(ControllerManager.CreateParameter("@ServerAddress", model.ServerAddress, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.UserName))
					listParameters.Add(ControllerManager.CreateParameter("@UserName", model.UserName, SqlDbType.VarChar));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXProfileConfigFTPGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ProfileConfigFTPModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@Password", model.Password, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@ServerAddress", model.ServerAddress, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@UserName", model.UserName, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXProfileConfigFTPInsert", listParameters, ref value, ref msg);

				if (result)
					model.FTPConfigID = ControllerManager.Converter.ToInt16(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ProfileConfigFTPModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@FTPConfigID", model.FTPConfigID.Value, SqlDbType.SmallInt));

				if (dynamicUpdate)
				{
					if (!string.IsNullOrEmpty(model.Password))
						listParameters.Add(ControllerManager.CreateParameter("@Password", model.Password, SqlDbType.VarChar));

					if (model.ProfileID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

					if (!string.IsNullOrEmpty(model.ServerAddress))
						listParameters.Add(ControllerManager.CreateParameter("@ServerAddress", model.ServerAddress, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.UserName))
						listParameters.Add(ControllerManager.CreateParameter("@UserName", model.UserName, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@Password", model.Password, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@ServerAddress", model.ServerAddress, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@UserName", model.UserName, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXProfileConfigFTPUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ProfileConfigFTPModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.FTPConfigID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FTPConfigID", model.FTPConfigID.Value, SqlDbType.SmallInt));

				if (!string.IsNullOrEmpty(model.Password))
					listParameters.Add(ControllerManager.CreateParameter("@Password", model.Password, SqlDbType.VarChar));

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ServerAddress))
					listParameters.Add(ControllerManager.CreateParameter("@ServerAddress", model.ServerAddress, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.UserName))
					listParameters.Add(ControllerManager.CreateParameter("@UserName", model.UserName, SqlDbType.VarChar));

				result = ControllerManager.ExecuteSP("BSWXProfileConfigFTPDelete", listParameters, ref msg);
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
				ProfileConfigFTPModel model = new ProfileConfigFTPModel();

				model.FTPConfigID = ControllerManager.Converter.ToInt16(reader["FTPConfigID"]);
				model.Password = ControllerManager.Converter.ToString(reader["Password"]);
				model.ProfileID = ControllerManager.Converter.ToByte(reader["ProfileID"]);
				model.ServerAddress = ControllerManager.Converter.ToString(reader["ServerAddress"]);
				model.UserName = ControllerManager.Converter.ToString(reader["UserName"]);
                model.FtpFolder = ControllerManager.Converter.ToString(reader["Folder"]);

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
