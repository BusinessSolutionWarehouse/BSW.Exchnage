using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ScheduleFrequencyTypeController : List<ScheduleFrequencyTypeModel>, IController
	{
		public bool Get(ScheduleFrequencyTypeModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ScheduleFrequencyTypeModel model, ScheduleFrequencyTypeModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				if (model.FrequencyTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID.Value, SqlDbType.TinyInt));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXScheduleFrequencyTypeGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ScheduleFrequencyTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXScheduleFrequencyTypeInsert", listParameters, ref value, ref msg);

				if (result)
					model.FrequencyTypeID = ControllerManager.Converter.ToByte(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ScheduleFrequencyTypeModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID.Value, SqlDbType.TinyInt));

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

				result = ControllerManager.ExecuteSP("BSWXScheduleFrequencyTypeUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ScheduleFrequencyTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				if (model.FrequencyTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID.Value, SqlDbType.TinyInt));

				result = ControllerManager.ExecuteSP("BSWXScheduleFrequencyTypeDelete", listParameters, ref msg);
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
				ScheduleFrequencyTypeModel model = new ScheduleFrequencyTypeModel();

				model.Description = ControllerManager.Converter.ToString(reader["Description"]);
				model.FrequencyTypeID = ControllerManager.Converter.ToByte(reader["FrequencyTypeID"]);

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
