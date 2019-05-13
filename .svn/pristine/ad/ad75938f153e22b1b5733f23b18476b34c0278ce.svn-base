using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ProfileScheduleController : List<ProfileScheduleModel>, IController
	{
		public bool Get(ProfileScheduleModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ProfileScheduleModel model, ProfileScheduleModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (model.ScheduleID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleID", model.ScheduleID.Value, SqlDbType.TinyInt));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXProfileScheduleGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ProfileScheduleModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXProfileScheduleInsert", listParameters, ref value, ref msg);

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

		public bool Update(ProfileScheduleModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ScheduleID", model.ScheduleID.Value, SqlDbType.TinyInt));

				if (dynamicUpdate)
				{
					if (model.ProfileID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXProfileScheduleUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ProfileScheduleModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (model.ScheduleID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ScheduleID", model.ScheduleID.Value, SqlDbType.TinyInt));

				result = ControllerManager.ExecuteSP("BSWXProfileScheduleDelete", listParameters, ref msg);
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
				ProfileScheduleModel model = new ProfileScheduleModel();

				model.ProfileID = ControllerManager.Converter.ToByte(reader["ProfileID"]);
				model.ScheduleID = ControllerManager.Converter.ToByte(reader["ScheduleID"]);

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
