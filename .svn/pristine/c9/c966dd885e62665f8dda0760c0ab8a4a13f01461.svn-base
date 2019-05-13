using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PurchaseOrder.Data
{
	public partial class PurchaseOrderController : List<PurchaseOrderModel>, IController
	{
		public bool Get(PurchaseOrderModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(PurchaseOrderModel model, PurchaseOrderModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.CountryOriginID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CountryOriginID", model.CountryOriginID.Value, SqlDbType.SmallInt));

				if (model.CreatedDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CreatedDt", model.CreatedDt.Value, SqlDbType.DateTime));

				if (model.CreatedUserID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CreatedUserID", model.CreatedUserID.Value, SqlDbType.SmallInt));

				if (!string.IsNullOrEmpty(model.FinalDestinationCode))
					listParameters.Add(ControllerManager.CreateParameter("@FinalDestinationCode", model.FinalDestinationCode, SqlDbType.Char));

				if (model.ImporterID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.ImporterRef))
					listParameters.Add(ControllerManager.CreateParameter("@ImporterRef", model.ImporterRef, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.INCOTermCode))
					listParameters.Add(ControllerManager.CreateParameter("@INCOTermCode", model.INCOTermCode, SqlDbType.Char));

				if (model.OrderDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OrderDt", model.OrderDt.Value, SqlDbType.DateTime));

				if (model.OrderID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OrderID", model.OrderID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.OrderNo))
					listParameters.Add(ControllerManager.CreateParameter("@OrderNo", model.OrderNo, SqlDbType.VarChar));

				if (model.OrderStatusID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OrderStatusID", model.OrderStatusID.Value, SqlDbType.TinyInt));

				if (model.PaymentDate.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentDate", model.PaymentDate.Value, SqlDbType.DateTime));

				if (model.PaymentTermID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTermID", model.PaymentTermID.Value, SqlDbType.TinyInt));

				if (model.PaymentTriggerID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTriggerID", model.PaymentTriggerID.Value, SqlDbType.TinyInt));

				if (model.PaymentTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTypeID", model.PaymentTypeID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.PlaceReceiptCode))
					listParameters.Add(ControllerManager.CreateParameter("@PlaceReceiptCode", model.PlaceReceiptCode, SqlDbType.Char));

				if (model.PlannedDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PlannedDt", model.PlannedDt.Value, SqlDbType.DateTime));

				if (!string.IsNullOrEmpty(model.PortDischargeCode))
					listParameters.Add(ControllerManager.CreateParameter("@PortDischargeCode", model.PortDischargeCode, SqlDbType.Char));

				if (!string.IsNullOrEmpty(model.PortLoadingCode))
					listParameters.Add(ControllerManager.CreateParameter("@PortLoadingCode", model.PortLoadingCode, SqlDbType.Char));

				if (model.SpotROE.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SpotROE", model.SpotROE.Value, SqlDbType.Decimal));

				if (model.SupplierID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.SupplierRef))
					listParameters.Add(ControllerManager.CreateParameter("@SupplierRef", model.SupplierRef, SqlDbType.VarChar));

				if (model.TransportModeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TransportModeID", model.TransportModeID.Value, SqlDbType.TinyInt));

				if (model.UpdatedDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedDt", model.UpdatedDt.Value, SqlDbType.DateTime));

				if (model.UpdatedUserID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedUserID", model.UpdatedUserID.Value, SqlDbType.SmallInt));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("OrderGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(PurchaseOrderModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@CountryOriginID", model.CountryOriginID, SqlDbType.SmallInt));
				listParameters.Add(ControllerManager.CreateParameter("@CreatedDt", model.CreatedDt, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@CreatedUserID", model.CreatedUserID, SqlDbType.SmallInt));
				listParameters.Add(ControllerManager.CreateParameter("@FinalDestinationCode", model.FinalDestinationCode, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID, SqlDbType.Int));
				listParameters.Add(ControllerManager.CreateParameter("@ImporterRef", model.ImporterRef, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@INCOTermCode", model.INCOTermCode, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@OrderDt", model.OrderDt, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@OrderNo", model.OrderNo, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@OrderStatusID", model.OrderStatusID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@PaymentDate", model.PaymentDate, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@PaymentTermID", model.PaymentTermID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@PaymentTriggerID", model.PaymentTriggerID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@PaymentTypeID", model.PaymentTypeID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@PlaceReceiptCode", model.PlaceReceiptCode, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@PlannedDt", model.PlannedDt, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@PortDischargeCode", model.PortDischargeCode, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@PortLoadingCode", model.PortLoadingCode, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@SpotROE", model.SpotROE, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID, SqlDbType.Int));
				listParameters.Add(ControllerManager.CreateParameter("@SupplierRef", model.SupplierRef, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@TransportModeID", model.TransportModeID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@UpdatedDt", model.UpdatedDt, SqlDbType.DateTime));
				listParameters.Add(ControllerManager.CreateParameter("@UpdatedUserID", model.UpdatedUserID, SqlDbType.SmallInt));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("OrderInsert", listParameters, ref value, ref msg);

				if (result)
					model.OrderID = ControllerManager.Converter.ToInt32(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(PurchaseOrderModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@OrderID", model.OrderID.Value, SqlDbType.Int));

				if (dynamicUpdate)
				{
					if (model.CountryOriginID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@CountryOriginID", model.CountryOriginID.Value, SqlDbType.SmallInt));

					if (model.CreatedDt.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@CreatedDt", model.CreatedDt.Value, SqlDbType.DateTime));

					if (model.CreatedUserID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@CreatedUserID", model.CreatedUserID.Value, SqlDbType.SmallInt));

					if (!string.IsNullOrEmpty(model.FinalDestinationCode))
						listParameters.Add(ControllerManager.CreateParameter("@FinalDestinationCode", model.FinalDestinationCode, SqlDbType.Char));

					if (model.ImporterID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID.Value, SqlDbType.Int));

					if (!string.IsNullOrEmpty(model.ImporterRef))
						listParameters.Add(ControllerManager.CreateParameter("@ImporterRef", model.ImporterRef, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.INCOTermCode))
						listParameters.Add(ControllerManager.CreateParameter("@INCOTermCode", model.INCOTermCode, SqlDbType.Char));

					if (model.OrderDt.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@OrderDt", model.OrderDt.Value, SqlDbType.DateTime));

					if (!string.IsNullOrEmpty(model.OrderNo))
						listParameters.Add(ControllerManager.CreateParameter("@OrderNo", model.OrderNo, SqlDbType.VarChar));

					if (model.OrderStatusID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@OrderStatusID", model.OrderStatusID.Value, SqlDbType.TinyInt));

					if (model.PaymentDate.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@PaymentDate", model.PaymentDate.Value, SqlDbType.DateTime));

					if (model.PaymentTermID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@PaymentTermID", model.PaymentTermID.Value, SqlDbType.TinyInt));

					if (model.PaymentTriggerID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@PaymentTriggerID", model.PaymentTriggerID.Value, SqlDbType.TinyInt));

					if (model.PaymentTypeID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@PaymentTypeID", model.PaymentTypeID.Value, SqlDbType.TinyInt));

					if (!string.IsNullOrEmpty(model.PlaceReceiptCode))
						listParameters.Add(ControllerManager.CreateParameter("@PlaceReceiptCode", model.PlaceReceiptCode, SqlDbType.Char));

					if (model.PlannedDt.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@PlannedDt", model.PlannedDt.Value, SqlDbType.DateTime));

					if (!string.IsNullOrEmpty(model.PortDischargeCode))
						listParameters.Add(ControllerManager.CreateParameter("@PortDischargeCode", model.PortDischargeCode, SqlDbType.Char));

					if (!string.IsNullOrEmpty(model.PortLoadingCode))
						listParameters.Add(ControllerManager.CreateParameter("@PortLoadingCode", model.PortLoadingCode, SqlDbType.Char));

					if (model.SpotROE.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@SpotROE", model.SpotROE.Value, SqlDbType.Decimal));

					if (model.SupplierID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID.Value, SqlDbType.Int));

					if (!string.IsNullOrEmpty(model.SupplierRef))
						listParameters.Add(ControllerManager.CreateParameter("@SupplierRef", model.SupplierRef, SqlDbType.VarChar));

					if (model.TransportModeID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@TransportModeID", model.TransportModeID.Value, SqlDbType.TinyInt));

					if (model.UpdatedDt.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UpdatedDt", model.UpdatedDt.Value, SqlDbType.DateTime));

					if (model.UpdatedUserID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UpdatedUserID", model.UpdatedUserID.Value, SqlDbType.SmallInt));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@CountryOriginID", model.CountryOriginID, SqlDbType.SmallInt));
					listParameters.Add(ControllerManager.CreateParameter("@CreatedDt", model.CreatedDt, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@CreatedUserID", model.CreatedUserID, SqlDbType.SmallInt));
					listParameters.Add(ControllerManager.CreateParameter("@FinalDestinationCode", model.FinalDestinationCode, SqlDbType.Char));
					listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID, SqlDbType.Int));
					listParameters.Add(ControllerManager.CreateParameter("@ImporterRef", model.ImporterRef, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@INCOTermCode", model.INCOTermCode, SqlDbType.Char));
					listParameters.Add(ControllerManager.CreateParameter("@OrderDt", model.OrderDt, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@OrderNo", model.OrderNo, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@OrderStatusID", model.OrderStatusID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@PaymentDate", model.PaymentDate, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTermID", model.PaymentTermID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTriggerID", model.PaymentTriggerID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTypeID", model.PaymentTypeID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@PlaceReceiptCode", model.PlaceReceiptCode, SqlDbType.Char));
					listParameters.Add(ControllerManager.CreateParameter("@PlannedDt", model.PlannedDt, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@PortDischargeCode", model.PortDischargeCode, SqlDbType.Char));
					listParameters.Add(ControllerManager.CreateParameter("@PortLoadingCode", model.PortLoadingCode, SqlDbType.Char));
					listParameters.Add(ControllerManager.CreateParameter("@SpotROE", model.SpotROE, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID, SqlDbType.Int));
					listParameters.Add(ControllerManager.CreateParameter("@SupplierRef", model.SupplierRef, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@TransportModeID", model.TransportModeID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedDt", model.UpdatedDt, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedUserID", model.UpdatedUserID, SqlDbType.SmallInt));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("OrderUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(PurchaseOrderModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.CountryOriginID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CountryOriginID", model.CountryOriginID.Value, SqlDbType.SmallInt));

				if (model.CreatedDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CreatedDt", model.CreatedDt.Value, SqlDbType.DateTime));

				if (model.CreatedUserID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CreatedUserID", model.CreatedUserID.Value, SqlDbType.SmallInt));

				if (!string.IsNullOrEmpty(model.FinalDestinationCode))
					listParameters.Add(ControllerManager.CreateParameter("@FinalDestinationCode", model.FinalDestinationCode, SqlDbType.Char));

				if (model.ImporterID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.ImporterRef))
					listParameters.Add(ControllerManager.CreateParameter("@ImporterRef", model.ImporterRef, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.INCOTermCode))
					listParameters.Add(ControllerManager.CreateParameter("@INCOTermCode", model.INCOTermCode, SqlDbType.Char));

				if (model.OrderDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OrderDt", model.OrderDt.Value, SqlDbType.DateTime));

				if (model.OrderID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OrderID", model.OrderID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.OrderNo))
					listParameters.Add(ControllerManager.CreateParameter("@OrderNo", model.OrderNo, SqlDbType.VarChar));

				if (model.OrderStatusID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OrderStatusID", model.OrderStatusID.Value, SqlDbType.TinyInt));

				if (model.PaymentDate.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentDate", model.PaymentDate.Value, SqlDbType.DateTime));

				if (model.PaymentTermID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTermID", model.PaymentTermID.Value, SqlDbType.TinyInt));

				if (model.PaymentTriggerID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTriggerID", model.PaymentTriggerID.Value, SqlDbType.TinyInt));

				if (model.PaymentTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PaymentTypeID", model.PaymentTypeID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.PlaceReceiptCode))
					listParameters.Add(ControllerManager.CreateParameter("@PlaceReceiptCode", model.PlaceReceiptCode, SqlDbType.Char));

				if (model.PlannedDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@PlannedDt", model.PlannedDt.Value, SqlDbType.DateTime));

				if (!string.IsNullOrEmpty(model.PortDischargeCode))
					listParameters.Add(ControllerManager.CreateParameter("@PortDischargeCode", model.PortDischargeCode, SqlDbType.Char));

				if (!string.IsNullOrEmpty(model.PortLoadingCode))
					listParameters.Add(ControllerManager.CreateParameter("@PortLoadingCode", model.PortLoadingCode, SqlDbType.Char));

				if (model.SpotROE.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SpotROE", model.SpotROE.Value, SqlDbType.Decimal));

				if (model.SupplierID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.SupplierRef))
					listParameters.Add(ControllerManager.CreateParameter("@SupplierRef", model.SupplierRef, SqlDbType.VarChar));

				if (model.TransportModeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@TransportModeID", model.TransportModeID.Value, SqlDbType.TinyInt));

				if (model.UpdatedDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedDt", model.UpdatedDt.Value, SqlDbType.DateTime));

				if (model.UpdatedUserID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedUserID", model.UpdatedUserID.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("OrderDelete", listParameters, ref msg);
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
				PurchaseOrderModel model = new PurchaseOrderModel();

				model.CountryOriginID = ControllerManager.Converter.ToInt16(reader["CountryOriginID"]);
				model.CreatedDt = ControllerManager.Converter.ToDateTime(reader["CreatedDt"]);
				model.CreatedUserID = ControllerManager.Converter.ToInt16(reader["CreatedUserID"]);
				model.FinalDestinationCode = ControllerManager.Converter.ToString(reader["FinalDestinationCode"]);
				model.ImporterID = ControllerManager.Converter.ToInt32(reader["ImporterID"]);
				model.ImporterRef = ControllerManager.Converter.ToString(reader["ImporterRef"]);
				model.INCOTermCode = ControllerManager.Converter.ToString(reader["INCOTermCode"]);
				model.OrderDt = ControllerManager.Converter.ToDateTime(reader["OrderDt"]);
				model.OrderID = ControllerManager.Converter.ToInt32(reader["OrderID"]);
				model.OrderNo = ControllerManager.Converter.ToString(reader["OrderNo"]);
				model.OrderStatusID = ControllerManager.Converter.ToByte(reader["OrderStatusID"]);
				model.PaymentDate = ControllerManager.Converter.ToDateTime(reader["PaymentDate"]);
				model.PaymentTermID = ControllerManager.Converter.ToByte(reader["PaymentTermID"]);
				model.PaymentTriggerID = ControllerManager.Converter.ToByte(reader["PaymentTriggerID"]);
				model.PaymentTypeID = ControllerManager.Converter.ToByte(reader["PaymentTypeID"]);
				model.PlaceReceiptCode = ControllerManager.Converter.ToString(reader["PlaceReceiptCode"]);
				model.PlannedDt = ControllerManager.Converter.ToDateTime(reader["PlannedDt"]);
				model.PortDischargeCode = ControllerManager.Converter.ToString(reader["PortDischargeCode"]);
				model.PortLoadingCode = ControllerManager.Converter.ToString(reader["PortLoadingCode"]);
				model.SpotROE = ControllerManager.Converter.ToDecimal(reader["SpotROE"]);
				model.SupplierID = ControllerManager.Converter.ToInt32(reader["SupplierID"]);
				model.SupplierRef = ControllerManager.Converter.ToString(reader["SupplierRef"]);
				model.TransportModeID = ControllerManager.Converter.ToByte(reader["TransportModeID"]);
				model.UpdatedDt = ControllerManager.Converter.ToDateTime(reader["UpdatedDt"]);
				model.UpdatedUserID = ControllerManager.Converter.ToInt16(reader["UpdatedUserID"]);

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
