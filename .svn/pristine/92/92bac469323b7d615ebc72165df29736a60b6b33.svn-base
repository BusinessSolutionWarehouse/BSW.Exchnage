using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace PurchaseOrder.Data
{
	public partial class CountryController : List<CountryModel>, IController
	{
		public bool Get(CountryModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(CountryModel model, CountryModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.CountryCode))
					listParameters.Add(ControllerManager.CreateParameter("@CountryCode", model.CountryCode, SqlDbType.VarChar));

				if (model.CountryID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CountryID", model.CountryID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.CountryName))
					listParameters.Add(ControllerManager.CreateParameter("@CountryName", model.CountryName, SqlDbType.VarChar));

				if (model.CurrencyID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@CurrencyID", model.CurrencyID.Value, SqlDbType.Int));

				if (model.IsDeleted.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@IsDeleted", model.IsDeleted.Value, SqlDbType.Bit));

				if (model.OldCurrencyID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@OldCurrencyID", model.OldCurrencyID.Value, SqlDbType.Int));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("CountryGet", listParameters, this, ref msg);
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
				CountryModel model = new CountryModel();

				model.CountryCode = ControllerManager.Converter.ToString(reader["CountryCode"]);
				model.CountryID = ControllerManager.Converter.ToInt32(reader["CountryID"]);
				model.CountryName = ControllerManager.Converter.ToString(reader["CountryName"]);
				model.CurrencyID = ControllerManager.Converter.ToInt32(reader["CurrencyID"]);
				model.IsDeleted = ControllerManager.Converter.ToBool(reader["IsDeleted"]);
				model.OldCurrencyID = ControllerManager.Converter.ToInt32(reader["OldCurrencyID"]);
                model.UnionCode = ControllerManager.Converter.ToString(reader["UnionCode"]);

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
