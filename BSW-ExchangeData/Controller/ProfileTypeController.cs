using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ProfileTypeController : List<ProfileTypeModel>, IController
	{
		public bool Get(ProfileTypeModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ProfileTypeModel model, ProfileTypeModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				if (model.ProfileTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileTypeID", model.ProfileTypeID.Value, SqlDbType.TinyInt));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXProfileTypeGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ProfileTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXProfileTypeInsert", listParameters, ref value, ref msg);

				if (result)
					model.ProfileTypeID = ControllerManager.Converter.ToByte(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ProfileTypeModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ProfileTypeID", model.ProfileTypeID.Value, SqlDbType.TinyInt));

				if (dynamicUpdate)
				{
					if (!string.IsNullOrEmpty(model.Description))
						listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXProfileTypeUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ProfileTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				if (model.ProfileTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileTypeID", model.ProfileTypeID.Value, SqlDbType.TinyInt));

				result = ControllerManager.ExecuteSP("BSWXProfileTypeDelete", listParameters, ref msg);
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
				ProfileTypeModel model = new ProfileTypeModel();

				model.Description = ControllerManager.Converter.ToString(reader["Description"]);
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
