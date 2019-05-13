using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class AdaptorTypeController : List<AdaptorTypeModel>, IController
	{
		public bool Get(AdaptorTypeModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(AdaptorTypeModel model, AdaptorTypeModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.AdaptorTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorTypeID", model.AdaptorTypeID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXAdaptorTypeGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(AdaptorTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXAdaptorTypeInsert", listParameters, ref value, ref msg);

				if (result)
					model.AdaptorTypeID = ControllerManager.Converter.ToByte(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(AdaptorTypeModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@AdaptorTypeID", model.AdaptorTypeID.Value, SqlDbType.TinyInt));

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

				result = ControllerManager.ExecuteSP("BSWXAdaptorTypeUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(AdaptorTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.AdaptorTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorTypeID", model.AdaptorTypeID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				result = ControllerManager.ExecuteSP("BSWXAdaptorTypeDelete", listParameters, ref msg);
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
				AdaptorTypeModel model = new AdaptorTypeModel();

				model.AdaptorTypeID = ControllerManager.Converter.ToByte(reader["AdaptorTypeID"]);
				model.Description = ControllerManager.Converter.ToString(reader["Description"]);

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
