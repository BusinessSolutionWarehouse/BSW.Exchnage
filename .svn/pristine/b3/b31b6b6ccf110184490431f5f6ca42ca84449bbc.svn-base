using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace AZROEImports
{
	public partial class ExchangeRateController : List<ExchangeRateModel>, IController
	{

		public bool Get(ExchangeRateModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(ExchangeRateModel model, ExchangeRateModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.ExchangeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@ExchangeID", model.ExchangeID.Value, SqlDbType.SmallInt));

				if (!string.IsNullOrEmpty(model.FromCurrency))
					listParameters.Add(ControllerManager.CreateParameter("@FromCurrency", model.FromCurrency, SqlDbType.Char));

				if (model.Rate.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@Rate", model.Rate.Value, SqlDbType.SmallMoney));

				if (!string.IsNullOrEmpty(model.ToCurrency))
					listParameters.Add(ControllerManager.CreateParameter("@ToCurrency", model.ToCurrency, SqlDbType.Char));

				if (model.UpdatedDt.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedDt", model.UpdatedDt.Value, SqlDbType.DateTime));

				if (model.UpdatedUserID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UpdatedUserID", model.UpdatedUserID.Value, SqlDbType.SmallInt));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("ExchangeRateGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(ExchangeRateModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@FromCurrency", model.FromCurrency, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@Rate", model.Rate, SqlDbType.SmallMoney));
				listParameters.Add(ControllerManager.CreateParameter("@ToCurrency", model.ToCurrency, SqlDbType.Char));
				listParameters.Add(ControllerManager.CreateParameter("@UpdatedUserID", model.UpdatedUserID, SqlDbType.SmallInt));
                listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityRoleLinkID", model.BusinessEntityRoleLinkID, SqlDbType.Int));

				object value = null;

                result = ControllerManager.ExecuteSPScalar("ExchangeRateInsert_Custom", listParameters, ref value, ref msg);

				if (result)
					model.ExchangeID = ControllerManager.Converter.ToInt16(value);
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
				ExchangeRateModel model = new ExchangeRateModel();

				model.ExchangeID = ControllerManager.Converter.ToInt16(reader["ExchangeID"]);
				model.FromCurrency = ControllerManager.Converter.ToString(reader["FromCurrency"]);
				model.Rate = ControllerManager.Converter.ToDecimal(reader["Rate"]);
				model.ToCurrency = ControllerManager.Converter.ToString(reader["ToCurrency"]);
				model.UpdatedDt = ControllerManager.Converter.ToDateTime(reader["UpdatedDt"]);
				model.UpdatedUserID = ControllerManager.Converter.ToInt16(reader["UpdatedUserID"]);
                model.UpdatedBy = ControllerManager.Converter.ToString(reader["UpdatedBy"]);
                model.FromCurrencyName = ControllerManager.Converter.ToString(reader["FromCurrenyName"]);

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
