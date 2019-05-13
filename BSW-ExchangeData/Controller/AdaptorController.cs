using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class AdaptorController : List<AdaptorModel>, IController
	{
		public bool Get(AdaptorModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(AdaptorModel model, AdaptorModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.AdaptorID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorID", model.AdaptorID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.AdaptorName))
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorName", model.AdaptorName, SqlDbType.VarChar));

				if (model.AdaptorType.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorType", model.AdaptorType.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ServiceName))
					listParameters.Add(ControllerManager.CreateParameter("@ServiceName", model.ServiceName, SqlDbType.VarChar));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXAdaptorGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(AdaptorModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@AdaptorName", model.AdaptorName, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@AdaptorType", model.AdaptorType, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@ServiceName", model.ServiceName, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXAdaptorInsert", listParameters, ref value, ref msg);

				if (result)
					model.AdaptorID = ControllerManager.Converter.ToByte(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(AdaptorModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@AdaptorID", model.AdaptorID.Value, SqlDbType.TinyInt));

				if (dynamicUpdate)
				{
					if (!string.IsNullOrEmpty(model.AdaptorName))
						listParameters.Add(ControllerManager.CreateParameter("@AdaptorName", model.AdaptorName, SqlDbType.VarChar));

					if (model.AdaptorType.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@AdaptorType", model.AdaptorType.Value, SqlDbType.TinyInt));

					if (!string.IsNullOrEmpty(model.ServiceName))
						listParameters.Add(ControllerManager.CreateParameter("@ServiceName", model.ServiceName, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorName", model.AdaptorName, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorType", model.AdaptorType, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@ServiceName", model.ServiceName, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXAdaptorUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(AdaptorModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.AdaptorID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorID", model.AdaptorID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.AdaptorName))
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorName", model.AdaptorName, SqlDbType.VarChar));

				if (model.AdaptorType.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@AdaptorType", model.AdaptorType.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ServiceName))
					listParameters.Add(ControllerManager.CreateParameter("@ServiceName", model.ServiceName, SqlDbType.VarChar));

				result = ControllerManager.ExecuteSP("BSWXAdaptorDelete", listParameters, ref msg);
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
				AdaptorModel model = new AdaptorModel();

				model.AdaptorID = ControllerManager.Converter.ToByte(reader["AdaptorID"]);
				model.AdaptorName = ControllerManager.Converter.ToString(reader["AdaptorName"]);
				model.AdaptorType = ControllerManager.Converter.ToByte(reader["AdaptorType"]);
				model.ServiceName = ControllerManager.Converter.ToString(reader["ServiceName"]);

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
