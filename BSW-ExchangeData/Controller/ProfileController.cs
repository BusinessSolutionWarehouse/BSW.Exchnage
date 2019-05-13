using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ProfileController : List<ProfileModel>, IController
	{
		
		public bool Get(ProfileModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@IsActive", model.IsActive, SqlDbType.TinyInt));
                				
				result = ControllerManager.ExecuteSP("BSWXProfileGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ProfileModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@AdaptorID", model.AdaptorID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@ProfileDescription", model.ProfileDescription, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ProfileName", model.ProfileName, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ProfileTypeID", model.ProfileTypeID, SqlDbType.TinyInt));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXProfileInsert", listParameters, ref value, ref msg);

				if (result)
					model.ProfileID = ControllerManager.Converter.ToByte(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ProfileModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (dynamicUpdate)
				{
					if (model.AdaptorID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@AdaptorID", model.AdaptorID.Value, SqlDbType.TinyInt));

					if (!string.IsNullOrEmpty(model.ProfileDescription))
						listParameters.Add(ControllerManager.CreateParameter("@ProfileDescription", model.ProfileDescription, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.ProfileName))
						listParameters.Add(ControllerManager.CreateParameter("@ProfileName", model.ProfileName, SqlDbType.VarChar));

					if (model.ProfileTypeID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ProfileTypeID", model.ProfileTypeID.Value, SqlDbType.TinyInt));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorID", model.AdaptorID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@ProfileDescription", model.ProfileDescription, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ProfileName", model.ProfileName, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ProfileTypeID", model.ProfileTypeID, SqlDbType.TinyInt));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXProfileUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ProfileModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.AdaptorID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorID", model.AdaptorID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ProfileDescription))
					listParameters.Add(ControllerManager.CreateParameter("@ProfileDescription", model.ProfileDescription, SqlDbType.VarChar));

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ProfileName))
					listParameters.Add(ControllerManager.CreateParameter("@ProfileName", model.ProfileName, SqlDbType.VarChar));

				if (model.ProfileTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileTypeID", model.ProfileTypeID.Value, SqlDbType.TinyInt));

				result = ControllerManager.ExecuteSP("BSWXProfileDelete", listParameters, ref msg);
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
				ProfileModel model = new ProfileModel();

				model.AdaptorID = ControllerManager.Converter.ToByte(reader["AdaptorID"]);
				model.ProfileDescription = ControllerManager.Converter.ToString(reader["ProfileDescription"]);
				model.ProfileID = ControllerManager.Converter.ToByte(reader["ProfileID"]);
				model.ProfileName = ControllerManager.Converter.ToString(reader["ProfileName"]);
				model.ProfileTypeID = ControllerManager.Converter.ToByte(reader["ProfileTypeID"]);

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
