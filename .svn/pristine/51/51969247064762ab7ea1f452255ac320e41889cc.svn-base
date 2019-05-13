using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ScheduleController : List<ScheduleModel>, IController
	{
        public bool GetProfileSchedule(int profileID, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@ProfileID", profileID, SqlDbType.TinyInt));

                result = ControllerManager.ExecuteSP("BSWXProfileScheduleGet", listParameters, this, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

		public bool Get(ScheduleModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ScheduleModel model, ScheduleModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.FrequencyTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID.Value, SqlDbType.TinyInt));

				if (model.OccursEveryHour.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OccursEveryHour", model.OccursEveryHour.Value, SqlDbType.TinyInt));

				if (model.OccursEveryMinute.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OccursEveryMinute", model.OccursEveryMinute.Value, SqlDbType.TinyInt));

				listParameters.Add(ControllerManager.CreateParameter("@OccursOnce", model.OccursOnce, SqlDbType.Bit));

				if (model.OccursOnceAt == null)
					listParameters.Add(ControllerManager.CreateParameter("@OccursOnceAt", model.OccursOnceAt, SqlDbType.Time));

				if (model.RecursEvery.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@RecursEvery", model.RecursEvery.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ScheduleDescription))
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleDescription", model.ScheduleDescription, SqlDbType.VarChar));

				if (model.ScheduleID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleID", model.ScheduleID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ScheduleName))
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleName", model.ScheduleName, SqlDbType.VarChar));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXScheduleGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ScheduleModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@OccursEveryHour", model.OccursEveryHour, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@OccursEveryMinute", model.OccursEveryMinute, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@OccursOnce", model.OccursOnce, SqlDbType.Bit));
				listParameters.Add(ControllerManager.CreateParameter("@OccursOnceAt", model.OccursOnceAt, SqlDbType.Time));
				listParameters.Add(ControllerManager.CreateParameter("@RecursEvery", model.RecursEvery, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@ScheduleDescription", model.ScheduleDescription, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ScheduleName", model.ScheduleName, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXScheduleInsert", listParameters, ref value, ref msg);

				if (result)
					model.ScheduleID = ControllerManager.Converter.ToByte(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ScheduleModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ScheduleID", model.ScheduleID.Value, SqlDbType.TinyInt));

				if (dynamicUpdate)
				{
					if (model.FrequencyTypeID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID.Value, SqlDbType.TinyInt));

					if (model.OccursEveryHour.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@OccursEveryHour", model.OccursEveryHour.Value, SqlDbType.TinyInt));

					if (model.OccursEveryMinute.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@OccursEveryMinute", model.OccursEveryMinute.Value, SqlDbType.TinyInt));

					listParameters.Add(ControllerManager.CreateParameter("@OccursOnce", model.OccursOnce, SqlDbType.Bit));

					if (model.OccursOnceAt == null)
						listParameters.Add(ControllerManager.CreateParameter("@OccursOnceAt", model.OccursOnceAt, SqlDbType.Time));

					if (model.RecursEvery.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@RecursEvery", model.RecursEvery.Value, SqlDbType.TinyInt));

					if (!string.IsNullOrEmpty(model.ScheduleDescription))
						listParameters.Add(ControllerManager.CreateParameter("@ScheduleDescription", model.ScheduleDescription, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.ScheduleName))
						listParameters.Add(ControllerManager.CreateParameter("@ScheduleName", model.ScheduleName, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@OccursEveryHour", model.OccursEveryHour, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@OccursEveryMinute", model.OccursEveryMinute, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@OccursOnce", model.OccursOnce, SqlDbType.Bit));
					listParameters.Add(ControllerManager.CreateParameter("@OccursOnceAt", model.OccursOnceAt, SqlDbType.Time));
					listParameters.Add(ControllerManager.CreateParameter("@RecursEvery", model.RecursEvery, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleDescription", model.ScheduleDescription, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleName", model.ScheduleName, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXScheduleUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ScheduleModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.FrequencyTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FrequencyTypeID", model.FrequencyTypeID.Value, SqlDbType.TinyInt));

				if (model.OccursEveryHour.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OccursEveryHour", model.OccursEveryHour.Value, SqlDbType.TinyInt));

				if (model.OccursEveryMinute.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OccursEveryMinute", model.OccursEveryMinute.Value, SqlDbType.TinyInt));

				listParameters.Add(ControllerManager.CreateParameter("@OccursOnce", model.OccursOnce, SqlDbType.Bit));

				if (model.OccursOnceAt == null)
					listParameters.Add(ControllerManager.CreateParameter("@OccursOnceAt", model.OccursOnceAt, SqlDbType.Time));

				if (model.RecursEvery.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@RecursEvery", model.RecursEvery.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ScheduleDescription))
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleDescription", model.ScheduleDescription, SqlDbType.VarChar));

				if (model.ScheduleID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleID", model.ScheduleID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.ScheduleName))
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleName", model.ScheduleName, SqlDbType.VarChar));

				result = ControllerManager.ExecuteSP("BSWXScheduleDelete", listParameters, ref msg);
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
				ScheduleModel model = new ScheduleModel();

				model.FrequencyTypeID = ControllerManager.Converter.ToByte(reader["FrequencyTypeID"]);
				model.OccursEveryHour = ControllerManager.Converter.ToByte(reader["OccursEveryHour"]);
				model.OccursEveryMinute = ControllerManager.Converter.ToByte(reader["OccursEveryMinute"]);
				model.OccursOnce = Convert.ToBoolean(reader["OccursOnce"]);
				model.OccursOnceAt = ControllerManager.Converter.ToString(reader["OccursOnceAt"]);
				model.RecursEvery = ControllerManager.Converter.ToByte(reader["RecursEvery"]);
				model.ScheduleDescription = ControllerManager.Converter.ToString(reader["ScheduleDescription"]);
				model.ScheduleID = ControllerManager.Converter.ToByte(reader["ScheduleID"]);
				model.ScheduleName = ControllerManager.Converter.ToString(reader["ScheduleName"]);
                model.StartDate = ControllerManager.Converter.ToDateTime(reader["StartDate"]);
                model.EndDate = ControllerManager.Converter.ToDateTime(reader["EndDate"]);
                model.StartTime  = ControllerManager.Converter.ToString(reader["StartTime"]);
                model.EndTime = ControllerManager.Converter.ToString(reader["EndTime"]);

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
