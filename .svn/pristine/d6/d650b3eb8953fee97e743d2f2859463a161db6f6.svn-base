using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ExportMessageBatchController : List<ExportMessageBatchModel>, IDisposable, IController
	{
		public bool Get(ExportMessageBatchModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ExportMessageBatchModel model, ExportMessageBatchModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.BatchCompleteDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BatchCompleteDT", model.BatchCompleteDT.Value, SqlDbType.DateTime));

				if (model.BatchStartDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BatchStartDT", model.BatchStartDT.Value, SqlDbType.DateTime));

				if (!string.IsNullOrEmpty(model.BatchUniqueKey))
					listParameters.Add(ControllerManager.CreateParameter("@BatchUniqueKey", model.BatchUniqueKey, SqlDbType.VarChar));

				if (model.ExportBatchID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ExportBatchID", model.ExportBatchID.Value, SqlDbType.BigInt));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXExportMessageBatchGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ExportMessageBatchModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@BatchUniqueKey", model.BatchUniqueKey, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXExportMessageBatchInsert", listParameters, ref value, ref msg);

				if (result)
					model.ExportBatchID = ControllerManager.Converter.ToInt64(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ExportMessageBatchModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ExportBatchID", model.ExportBatchID.Value, SqlDbType.BigInt));

				if (dynamicUpdate)
				{
					if (model.BatchCompleteDT.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@BatchCompleteDT", model.BatchCompleteDT.Value, SqlDbType.DateTime));

					if (model.BatchStartDT.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@BatchStartDT", model.BatchStartDT.Value, SqlDbType.DateTime));

					if (!string.IsNullOrEmpty(model.BatchUniqueKey))
						listParameters.Add(ControllerManager.CreateParameter("@BatchUniqueKey", model.BatchUniqueKey, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@BatchCompleteDT", model.BatchCompleteDT, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@BatchStartDT", model.BatchStartDT, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@BatchUniqueKey", model.BatchUniqueKey, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXExportMessageBatchUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ExportMessageBatchModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.BatchCompleteDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BatchCompleteDT", model.BatchCompleteDT.Value, SqlDbType.DateTime));

				if (model.BatchStartDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BatchStartDT", model.BatchStartDT.Value, SqlDbType.DateTime));

				if (!string.IsNullOrEmpty(model.BatchUniqueKey))
					listParameters.Add(ControllerManager.CreateParameter("@BatchUniqueKey", model.BatchUniqueKey, SqlDbType.VarChar));

				if (model.ExportBatchID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ExportBatchID", model.ExportBatchID.Value, SqlDbType.BigInt));

				result = ControllerManager.ExecuteSP("BSWXExportMessageBatchDelete", listParameters, ref msg);
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
				ExportMessageBatchModel model = new ExportMessageBatchModel();

				model.BatchCompleteDT = ControllerManager.Converter.ToDateTime(reader["BatchCompleteDT"]);
				model.BatchStartDT = ControllerManager.Converter.ToDateTime(reader["BatchStartDT"]);
				model.BatchUniqueKey = ControllerManager.Converter.ToString(reader["BatchUniqueKey"]);
				model.ExportBatchID = ControllerManager.Converter.ToInt64(reader["ExportBatchID"]);

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
