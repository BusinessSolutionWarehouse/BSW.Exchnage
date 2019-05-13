using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ExportMessageHistoryController : List<ExportMessageHistoryModel>, IDisposable, IController
	{
		public bool Get(ExportMessageHistoryModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ExportMessageHistoryModel model, ExportMessageHistoryModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				if (model.ExportMessageID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ExportMessageID", model.ExportMessageID.Value, SqlDbType.BigInt));

				if (model.HistoryDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@HistoryDT", model.HistoryDT.Value, SqlDbType.DateTime));

				if (model.MessageClass.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageClass", model.MessageClass.Value, SqlDbType.TinyInt));

				if (model.MessageHistoryID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageHistoryID", model.MessageHistoryID.Value, SqlDbType.BigInt));

				if (model.MessageStatus.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus.Value, SqlDbType.TinyInt));

				if (model.NotificationSend.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@NotificationSend", model.NotificationSend.Value, SqlDbType.Bit));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("BSWXExportMessageHistoryGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ExportMessageHistoryModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ExportMessageID", model.ExportMessageID, SqlDbType.BigInt));
				listParameters.Add(ControllerManager.CreateParameter("@MessageClass", model.MessageClass, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus, SqlDbType.TinyInt));
				
				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXExportMessageHistoryInsert", listParameters, ref value, ref msg);

				if (result)
					model.MessageHistoryID = ControllerManager.Converter.ToInt64(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ExportMessageHistoryModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@MessageHistoryID", model.MessageHistoryID.Value, SqlDbType.BigInt));

				if (dynamicUpdate)
				{
					if (!string.IsNullOrEmpty(model.Description))
						listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

					if (model.ExportMessageID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ExportMessageID", model.ExportMessageID.Value, SqlDbType.BigInt));

					if (model.HistoryDT.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@HistoryDT", model.HistoryDT.Value, SqlDbType.DateTime));

					if (model.MessageClass.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@MessageClass", model.MessageClass.Value, SqlDbType.TinyInt));

					if (model.MessageStatus.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus.Value, SqlDbType.TinyInt));

					if (model.NotificationSend.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@NotificationSend", model.NotificationSend.Value, SqlDbType.Bit));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ExportMessageID", model.ExportMessageID, SqlDbType.BigInt));
					listParameters.Add(ControllerManager.CreateParameter("@HistoryDT", model.HistoryDT, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@MessageClass", model.MessageClass, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@NotificationSend", model.NotificationSend, SqlDbType.Bit));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXExportMessageHistoryUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ExportMessageHistoryModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.Description))
					listParameters.Add(ControllerManager.CreateParameter("@Description", model.Description, SqlDbType.VarChar));

				if (model.ExportMessageID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ExportMessageID", model.ExportMessageID.Value, SqlDbType.BigInt));

				if (model.HistoryDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@HistoryDT", model.HistoryDT.Value, SqlDbType.DateTime));

				if (model.MessageClass.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageClass", model.MessageClass.Value, SqlDbType.TinyInt));

				if (model.MessageHistoryID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageHistoryID", model.MessageHistoryID.Value, SqlDbType.BigInt));

				if (model.MessageStatus.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus.Value, SqlDbType.TinyInt));

				if (model.NotificationSend.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@NotificationSend", model.NotificationSend.Value, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BSWXExportMessageHistoryDelete", listParameters, ref msg);
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
				ExportMessageHistoryModel model = new ExportMessageHistoryModel();

				model.Description = ControllerManager.Converter.ToString(reader["Description"]);
				model.ExportMessageID = ControllerManager.Converter.ToInt64(reader["ExportMessageID"]);
				model.HistoryDT = ControllerManager.Converter.ToDateTime(reader["HistoryDT"]);
				model.MessageClass = ControllerManager.Converter.ToByte(reader["MessageClass"]);
				model.MessageHistoryID = ControllerManager.Converter.ToInt64(reader["MessageHistoryID"]);
				model.MessageStatus = ControllerManager.Converter.ToByte(reader["MessageStatus"]);
				model.NotificationSend = ControllerManager.Converter.ToBool(reader["NotificationSend"]);

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
