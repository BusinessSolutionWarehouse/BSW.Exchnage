using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PurchaseOrder.Data
{
	public partial class ProductDetailAZController : List<ProductDetailAZModel>, IController
	{
		public bool Get(ProductDetailAZModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ProductDetailAZModel model, ProductDetailAZModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.BuyerID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BuyerID", model.BuyerID.Value, SqlDbType.SmallInt));

				if (model.ClaimsPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ClaimsPercentage", model.ClaimsPercentage.Value, SqlDbType.Decimal));

				if (model.ContingencyPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ContingencyPercentage", model.ContingencyPercentage.Value, SqlDbType.Decimal));

				if (model.FIFOPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FIFOPercentage", model.FIFOPercentage.Value, SqlDbType.Decimal));

				if (model.IsHouse.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@IsHouse", model.IsHouse.Value, SqlDbType.Bit));

				if (model.MarketingPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MarketingPercentage", model.MarketingPercentage.Value, SqlDbType.Decimal));

				if (model.ProductID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProductID", model.ProductID.Value, SqlDbType.Int));

				if (model.UnitCDCPrice_ZAR.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitCDCPrice_ZAR", model.UnitCDCPrice_ZAR.Value, SqlDbType.Money));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("ProductDetailAZGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ProductDetailAZModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@BuyerID", model.BuyerID, SqlDbType.SmallInt));
				listParameters.Add(ControllerManager.CreateParameter("@ClaimsPercentage", model.ClaimsPercentage, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@ContingencyPercentage", model.ContingencyPercentage, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@FIFOPercentage", model.FIFOPercentage, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@IsHouse", model.IsHouse, SqlDbType.Bit));
				listParameters.Add(ControllerManager.CreateParameter("@MarketingPercentage", model.MarketingPercentage, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@UnitCDCPrice_ZAR", model.UnitCDCPrice_ZAR, SqlDbType.Money));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("ProductDetailAZInsert", listParameters, ref value, ref msg);

				if (result)
					model.ProductID = ControllerManager.Converter.ToInt32(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(ProductDetailAZModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ProductID", model.ProductID.Value, SqlDbType.Int));

				if (dynamicUpdate)
				{
					if (model.BuyerID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@BuyerID", model.BuyerID.Value, SqlDbType.SmallInt));

					if (model.ClaimsPercentage.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ClaimsPercentage", model.ClaimsPercentage.Value, SqlDbType.Decimal));

					if (model.ContingencyPercentage.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ContingencyPercentage", model.ContingencyPercentage.Value, SqlDbType.Decimal));

					if (model.FIFOPercentage.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@FIFOPercentage", model.FIFOPercentage.Value, SqlDbType.Decimal));

					if (model.IsHouse.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@IsHouse", model.IsHouse.Value, SqlDbType.Bit));

					if (model.MarketingPercentage.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@MarketingPercentage", model.MarketingPercentage.Value, SqlDbType.Decimal));

					if (model.UnitCDCPrice_ZAR.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UnitCDCPrice_ZAR", model.UnitCDCPrice_ZAR.Value, SqlDbType.Money));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@BuyerID", model.BuyerID, SqlDbType.SmallInt));
					listParameters.Add(ControllerManager.CreateParameter("@ClaimsPercentage", model.ClaimsPercentage, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@ContingencyPercentage", model.ContingencyPercentage, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@FIFOPercentage", model.FIFOPercentage, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@IsHouse", model.IsHouse, SqlDbType.Bit));
					listParameters.Add(ControllerManager.CreateParameter("@MarketingPercentage", model.MarketingPercentage, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@UnitCDCPrice_ZAR", model.UnitCDCPrice_ZAR, SqlDbType.Money));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("ProductDetailAZUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(ProductDetailAZModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.BuyerID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BuyerID", model.BuyerID.Value, SqlDbType.SmallInt));

				if (model.ClaimsPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ClaimsPercentage", model.ClaimsPercentage.Value, SqlDbType.Decimal));

				if (model.ContingencyPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ContingencyPercentage", model.ContingencyPercentage.Value, SqlDbType.Decimal));

				if (model.FIFOPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@FIFOPercentage", model.FIFOPercentage.Value, SqlDbType.Decimal));

				if (model.IsHouse.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@IsHouse", model.IsHouse.Value, SqlDbType.Bit));

				if (model.MarketingPercentage.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@MarketingPercentage", model.MarketingPercentage.Value, SqlDbType.Decimal));

				if (model.ProductID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProductID", model.ProductID.Value, SqlDbType.Int));

				if (model.UnitCDCPrice_ZAR.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitCDCPrice_ZAR", model.UnitCDCPrice_ZAR.Value, SqlDbType.Money));

				result = ControllerManager.ExecuteSP("ProductDetailAZDelete", listParameters, ref msg);
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
				ProductDetailAZModel model = new ProductDetailAZModel();

				model.BuyerID = ControllerManager.Converter.ToInt16(reader["BuyerID"]);
				model.ClaimsPercentage = ControllerManager.Converter.ToDecimal(reader["ClaimsPercentage"]);
				model.ContingencyPercentage = ControllerManager.Converter.ToDecimal(reader["ContingencyPercentage"]);
				model.FIFOPercentage = ControllerManager.Converter.ToDecimal(reader["FIFOPercentage"]);
				model.IsHouse = ControllerManager.Converter.ToBool(reader["IsHouse"]);
				model.MarketingPercentage = ControllerManager.Converter.ToDecimal(reader["MarketingPercentage"]);
				model.ProductID = ControllerManager.Converter.ToInt32(reader["ProductID"]);
				model.UnitCDCPrice_ZAR = ControllerManager.Converter.ToDecimal(reader["UnitCDCPrice_ZAR"]);

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
