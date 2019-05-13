using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PurchaseOrder.Data
{
	public partial class ProductController : List<ProductModel>, IController
	{
        public bool GetByCode(string code, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@ProductCode",code, SqlDbType.VarChar));
                              
                result = ControllerManager.ExecuteSP("ProductGetByCode", listParameters, this, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        
		public bool Get(ProductModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ProductModel model, ProductModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				
                //if (model.ImporterID.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID.Value, SqlDbType.Int));

                //if (model.LatestUpdateDT.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@LatestUpdateDT", model.LatestUpdateDT.Value, SqlDbType.DateTime));

                //if (!string.IsNullOrEmpty(model.ProductCode))
                //    listParameters.Add(ControllerManager.CreateParameter("@ProductCode", model.ProductCode, SqlDbType.VarChar));

                //if (!string.IsNullOrEmpty(model.ProductDescription))
                //    listParameters.Add(ControllerManager.CreateParameter("@ProductDescription", model.ProductDescription, SqlDbType.VarChar));

                //if (model.ProductID.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@ProductID", model.ProductID.Value, SqlDbType.Int));

                //if (model.ProductStatusID.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@ProductStatusID", model.ProductStatusID.Value, SqlDbType.TinyInt));

                if (model.SupplierID.HasValue)
                    listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID.Value, SqlDbType.Int));

                //if (!string.IsNullOrEmpty(model.SupplierProductCode))
                //    listParameters.Add(ControllerManager.CreateParameter("@SupplierProductCode", model.SupplierProductCode, SqlDbType.VarChar));

                //if (!string.IsNullOrEmpty(model.TariffCode))
                //    listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));

                //if (model.UnitDim1_CM.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@UnitDim1_CM", model.UnitDim1_CM.Value, SqlDbType.Decimal));

                //if (model.UnitDim2_CM.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@UnitDim2_CM", model.UnitDim2_CM.Value, SqlDbType.Decimal));

                //if (model.UnitDim3_CM.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@UnitDim3_CM", model.UnitDim3_CM.Value, SqlDbType.Decimal));

                //if (model.UnitPackQty.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@UnitPackQty", model.UnitPackQty.Value, SqlDbType.SmallInt));

                //if (model.UnitPriceForeign.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@UnitPriceForeign", model.UnitPriceForeign.Value, SqlDbType.Money));

                //if (model.UnitWeight_KG.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@UnitWeight_KG", model.UnitWeight_KG.Value, SqlDbType.Decimal));

                //if (sortByField.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

                //if (sortOrder.HasValue)
                //    listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("ProductAZGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ProductModel model,int userID, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID, SqlDbType.Int));
				listParameters.Add(ControllerManager.CreateParameter("@ProductCode", model.ProductCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ProductDescription", model.ProductDescription, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@ProductStatusID", model.ProductStatusID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID, SqlDbType.Int));
				listParameters.Add(ControllerManager.CreateParameter("@SupplierProductCode", model.SupplierProductCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@UnitDim1_CM", model.UnitDim1_CM, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@UnitDim2_CM", model.UnitDim2_CM, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@UnitDim3_CM", model.UnitDim3_CM, SqlDbType.Decimal));
				listParameters.Add(ControllerManager.CreateParameter("@UnitPackQty", model.UnitPackQty, SqlDbType.Int));
				listParameters.Add(ControllerManager.CreateParameter("@UnitPriceForeign", model.UnitPriceForeign, SqlDbType.Money));
				listParameters.Add(ControllerManager.CreateParameter("@UnitWeight_KG", model.UnitWeight_KG, SqlDbType.Decimal));
                listParameters.Add(ControllerManager.CreateParameter("@UserID", userID, SqlDbType.Int));
                listParameters.Add(ControllerManager.CreateParameter("@CountryOfOriginID", model.CountryOfOrigin, SqlDbType.Int));

				object value = null;

                result = ControllerManager.ExecuteSPScalar("ProductInsert_Custom", listParameters, ref value, ref msg);

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

		public bool Update(ProductModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@ProductID", model.ProductID.Value, SqlDbType.Int));

				if (dynamicUpdate)
				{
					
					if (model.ImporterID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID.Value, SqlDbType.Int));

					if (model.LatestUpdateDT.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@LatestUpdateDT", model.LatestUpdateDT.Value, SqlDbType.DateTime));

					if (!string.IsNullOrEmpty(model.ProductCode))
						listParameters.Add(ControllerManager.CreateParameter("@ProductCode", model.ProductCode, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.ProductDescription))
						listParameters.Add(ControllerManager.CreateParameter("@ProductDescription", model.ProductDescription, SqlDbType.VarChar));

					if (model.ProductStatusID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@ProductStatusID", model.ProductStatusID.Value, SqlDbType.TinyInt));

					if (model.SupplierID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID.Value, SqlDbType.Int));

					if (!string.IsNullOrEmpty(model.SupplierProductCode))
						listParameters.Add(ControllerManager.CreateParameter("@SupplierProductCode", model.SupplierProductCode, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.TariffCode))
						listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));

					if (model.UnitDim1_CM.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UnitDim1_CM", model.UnitDim1_CM.Value, SqlDbType.Decimal));

					if (model.UnitDim2_CM.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UnitDim2_CM", model.UnitDim2_CM.Value, SqlDbType.Decimal));

					if (model.UnitDim3_CM.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UnitDim3_CM", model.UnitDim3_CM.Value, SqlDbType.Decimal));

					if (model.UnitPackQty.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UnitPackQty", model.UnitPackQty.Value, SqlDbType.Int));

					if (model.UnitPriceForeign.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UnitPriceForeign", model.UnitPriceForeign.Value, SqlDbType.Money));

					if (model.UnitWeight_KG.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@UnitWeight_KG", model.UnitWeight_KG.Value, SqlDbType.Decimal));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID, SqlDbType.Int));
					listParameters.Add(ControllerManager.CreateParameter("@LatestUpdateDT", model.LatestUpdateDT, SqlDbType.DateTime));
					listParameters.Add(ControllerManager.CreateParameter("@ProductCode", model.ProductCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ProductDescription", model.ProductDescription, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@ProductStatusID", model.ProductStatusID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID, SqlDbType.Int));
					listParameters.Add(ControllerManager.CreateParameter("@SupplierProductCode", model.SupplierProductCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@UnitDim1_CM", model.UnitDim1_CM, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@UnitDim2_CM", model.UnitDim2_CM, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@UnitDim3_CM", model.UnitDim3_CM, SqlDbType.Decimal));
					listParameters.Add(ControllerManager.CreateParameter("@UnitPackQty", model.UnitPackQty, SqlDbType.Int));
					listParameters.Add(ControllerManager.CreateParameter("@UnitPriceForeign", model.UnitPriceForeign, SqlDbType.Money));
					listParameters.Add(ControllerManager.CreateParameter("@UnitWeight_KG", model.UnitWeight_KG, SqlDbType.Decimal));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("ProductUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

        public bool UpdateUnitPriceOnly(decimal unitPrice,int productID,int userID, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@ProductID", productID, SqlDbType.Int));
                
                listParameters.Add(ControllerManager.CreateParameter("@UnitPriceForeign", unitPrice, SqlDbType.Money));
                listParameters.Add(ControllerManager.CreateParameter("@UserID", userID, SqlDbType.Int));
                
                result = ControllerManager.ExecuteSP("ProductUpdateUnitPrice", listParameters, ref msg);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

		public bool Delete(ProductModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				
				if (model.ImporterID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ImporterID", model.ImporterID.Value, SqlDbType.Int));

				if (model.LatestUpdateDT.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@LatestUpdateDT", model.LatestUpdateDT.Value, SqlDbType.DateTime));

				if (!string.IsNullOrEmpty(model.ProductCode))
					listParameters.Add(ControllerManager.CreateParameter("@ProductCode", model.ProductCode, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.ProductDescription))
					listParameters.Add(ControllerManager.CreateParameter("@ProductDescription", model.ProductDescription, SqlDbType.VarChar));

				if (model.ProductID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProductID", model.ProductID.Value, SqlDbType.Int));

				if (model.ProductStatusID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ProductStatusID", model.ProductStatusID.Value, SqlDbType.TinyInt));

				if (model.SupplierID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SupplierID", model.SupplierID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.SupplierProductCode))
					listParameters.Add(ControllerManager.CreateParameter("@SupplierProductCode", model.SupplierProductCode, SqlDbType.VarChar));

				if (!string.IsNullOrEmpty(model.TariffCode))
					listParameters.Add(ControllerManager.CreateParameter("@TariffCode", model.TariffCode, SqlDbType.VarChar));

				if (model.UnitDim1_CM.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitDim1_CM", model.UnitDim1_CM.Value, SqlDbType.Decimal));

				if (model.UnitDim2_CM.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitDim2_CM", model.UnitDim2_CM.Value, SqlDbType.Decimal));

				if (model.UnitDim3_CM.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitDim3_CM", model.UnitDim3_CM.Value, SqlDbType.Decimal));

				if (model.UnitPackQty.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitPackQty", model.UnitPackQty.Value, SqlDbType.Int));

				if (model.UnitPriceForeign.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitPriceForeign", model.UnitPriceForeign.Value, SqlDbType.Money));

				if (model.UnitWeight_KG.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitWeight_KG", model.UnitWeight_KG.Value, SqlDbType.Decimal));

				result = ControllerManager.ExecuteSP("ProductDelete", listParameters, ref msg);
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
				ProductModel model = new ProductModel();

				model.ImporterID = ControllerManager.Converter.ToInt32(reader["ImporterID"]);
				model.LatestUpdateDT = ControllerManager.Converter.ToDateTime(reader["LatestUpdateDT"]);
				model.ProductCode = ControllerManager.Converter.ToString(reader["ProductCode"]);
				model.ProductDescription = ControllerManager.Converter.ToString(reader["ProductDescription"]);
				model.ProductID = ControllerManager.Converter.ToInt32(reader["ProductID"]);
				model.ProductStatusID = ControllerManager.Converter.ToByte(reader["ProductStatusID"]);
				model.SupplierID = ControllerManager.Converter.ToInt32(reader["SupplierID"]);
				model.SupplierProductCode = ControllerManager.Converter.ToString(reader["SupplierProductCode"]);
				model.TariffCode = ControllerManager.Converter.ToString(reader["TariffCode"]);
				model.UnitDim1_CM = ControllerManager.Converter.ToDecimal(reader["UnitDim1_CM"]);
				model.UnitDim2_CM = ControllerManager.Converter.ToDecimal(reader["UnitDim2_CM"]);
				model.UnitDim3_CM = ControllerManager.Converter.ToDecimal(reader["UnitDim3_CM"]);
				model.UnitPackQty = ControllerManager.Converter.ToInt32(reader["UnitPackQty"]);
				model.UnitPriceForeign = ControllerManager.Converter.ToDecimal(reader["UnitPriceForeign"]);
				model.UnitWeight_KG = ControllerManager.Converter.ToDecimal(reader["UnitWeight_KG"]);

                model.SupplierCode = ControllerManager.Converter.ToString(reader["SupplierCode"]);
                model.SupplierName = ControllerManager.Converter.ToString(reader["SupplierName"]);

                model.FIFO = ControllerManager.Converter.ToDecimal(reader["FIFOPercentage"]);
                model.Contingency = ControllerManager.Converter.ToDecimal(reader["ContingencyPercentage"]);
                model.Marketing = ControllerManager.Converter.ToDecimal(reader["MarketingPercentage"]);
                model.Claims = ControllerManager.Converter.ToDecimal(reader["ClaimsPercentage"]);
                model.CountryOfOrigin = ControllerManager.Converter.ToInt32(reader["CountryOfOriginID"]);
                
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
