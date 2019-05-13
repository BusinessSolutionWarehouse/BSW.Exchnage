using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
	public partial class ExportMessageController : List<ExportMessageModel>, IDisposable, IController
	{
		public bool Get(ExportMessageModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ExportMessageModel model, ExportMessageModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.ClientReference1))
				
				if (model.MessageID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageID", model.MessageID.Value, SqlDbType.BigInt));

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

                if (model.ProfileID.HasValue)
                    listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus, SqlDbType.TinyInt));

                
				
				result = ControllerManager.ExecuteSP("BSWXExportMessageGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ExportMessageModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ClientReference1", model.ClientReference1, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ClientReference2", model.ClientReference2, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ExportBatchID", model.ExportBatchID, SqlDbType.BigInt));
				listParameters.Add(ControllerManager.CreateParameter("@ExportDT", model.ExportDT, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@MessageDT", model.MessageDT, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@MessageTypeID", model.MessageTypeID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@MessageVersion", model.MessageVersion, SqlDbType.SmallInt));
				listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@XMLMessage", model.XMLMessage, SqlDbType.Xml));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BSWXExportMessageInsert", listParameters, ref value, ref msg);

				if (result)
					model.MessageID = ControllerManager.Converter.ToInt64(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool UpdateStatus(ExportMessageModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@MessageID", model.MessageID.Value, SqlDbType.BigInt));
                
                listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus.Value, SqlDbType.TinyInt));

              	result = ControllerManager.ExecuteSP("BSWXExportMessageUpdateStatus", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ExportMessageModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.ClientReference1))
					listParameters.Add(ControllerManager.CreateParameter("@ClientReference1", model.ClientReference1, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.ClientReference2))
					listParameters.Add(ControllerManager.CreateParameter("@ClientReference2", model.ClientReference2, SqlDbType.VarChar));

				if (model.ExportBatchID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ExportBatchID", model.ExportBatchID.Value, SqlDbType.BigInt));

				if (model.ExportDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ExportDT", model.ExportDT.Value, SqlDbType.DateTime));

				if (model.MessageDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageDT", model.MessageDT.Value, SqlDbType.DateTime));

				if (model.MessageID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageID", model.MessageID.Value, SqlDbType.BigInt));

				if (model.MessageStatus.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageStatus", model.MessageStatus.Value, SqlDbType.TinyInt));

				if (model.MessageTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageTypeID", model.MessageTypeID.Value, SqlDbType.TinyInt));

				if (model.MessageVersion.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MessageVersion", model.MessageVersion.Value, SqlDbType.SmallInt));

				if (model.ProfileID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID.Value, SqlDbType.TinyInt));

				if (model.XMLMessage == null)
					listParameters.Add(ControllerManager.CreateParameter("@XMLMessage", model.XMLMessage, SqlDbType.Xml));

				result = ControllerManager.ExecuteSP("BSWXExportMessageDelete", listParameters, ref msg);
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
				ExportMessageModel model = new ExportMessageModel();

				model.ClientReference1 = ControllerManager.Converter.ToString(reader["ClientReference1"]);
				model.ClientReference2 = ControllerManager.Converter.ToString(reader["ClientReference2"]);
				model.ExportBatchID = ControllerManager.Converter.ToInt64(reader["ExportBatchID"]);
				model.ExportDT = ControllerManager.Converter.ToDateTime(reader["ExportDT"]);
				model.MessageDT = ControllerManager.Converter.ToDateTime(reader["MessageDT"]);
				model.MessageID = ControllerManager.Converter.ToInt64(reader["MessageID"]);
				model.MessageStatus = ControllerManager.Converter.ToByte(reader["MessageStatus"]);
				model.MessageTypeID = ControllerManager.Converter.ToByte(reader["MessageTypeID"]);
				model.MessageVersion = ControllerManager.Converter.ToInt16(reader["MessageVersion"]);
				model.ProfileID = ControllerManager.Converter.ToByte(reader["ProfileID"]);
                model.XMLMessage = ControllerManager.Converter.ToString(reader["XMLMessage"]);

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
