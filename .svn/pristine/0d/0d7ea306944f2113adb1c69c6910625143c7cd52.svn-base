using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace PurchaseOrder.Data
{
	public partial class UnitTypeController : List<UnitTypeModel>, IController, IDisposable
	{
		public bool Get(UnitTypeModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(UnitTypeModel model, UnitTypeModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.IsActive.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@IsActive", model.IsActive.Value, SqlDbType.Bit));

				if (model.IsDefault.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@IsDefault", model.IsDefault.Value, SqlDbType.Bit));

				if (!string.IsNullOrEmpty(model.Name))
					listParameters.Add(ControllerManager.CreateParameter("@Name", model.Name, SqlDbType.VarChar));

				if (model.UnitTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitTypeID", model.UnitTypeID.Value, SqlDbType.Int));

				if (sortByField.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortByField", sortByField.Value.ToString(), SqlDbType.VarChar));

				if (sortOrder.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@SortOrder", sortOrder.Value, SqlDbType.SmallInt));

				result = ControllerManager.ExecuteSP("UnitTypeGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Insert(UnitTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@IsActive", model.IsActive, SqlDbType.Bit));
				listParameters.Add(ControllerManager.CreateParameter("@IsDefault", model.IsDefault, SqlDbType.Bit));
				listParameters.Add(ControllerManager.CreateParameter("@Name", model.Name, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("UnitTypeInsert", listParameters, ref value, ref msg);

				if (result)
					model.UnitTypeID = ControllerManager.Converter.ToInt32(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(UnitTypeModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@UnitTypeID", model.UnitTypeID.Value, SqlDbType.Int));

				if (dynamicUpdate)
				{
					if (model.IsActive.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@IsActive", model.IsActive.Value, SqlDbType.Bit));

					if (model.IsDefault.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@IsDefault", model.IsDefault.Value, SqlDbType.Bit));

					if (!string.IsNullOrEmpty(model.Name))
						listParameters.Add(ControllerManager.CreateParameter("@Name", model.Name, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@IsActive", model.IsActive, SqlDbType.Bit));
					listParameters.Add(ControllerManager.CreateParameter("@IsDefault", model.IsDefault, SqlDbType.Bit));
					listParameters.Add(ControllerManager.CreateParameter("@Name", model.Name, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("UnitTypeUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(UnitTypeModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (model.IsActive.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@IsActive", model.IsActive.Value, SqlDbType.Bit));

				if (model.IsDefault.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@IsDefault", model.IsDefault.Value, SqlDbType.Bit));

				if (!string.IsNullOrEmpty(model.Name))
					listParameters.Add(ControllerManager.CreateParameter("@Name", model.Name, SqlDbType.VarChar));

				if (model.UnitTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@UnitTypeID", model.UnitTypeID.Value, SqlDbType.Int));

				result = ControllerManager.ExecuteSP("UnitTypeDelete", listParameters, ref msg);
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
				UnitTypeModel model = new UnitTypeModel();

				model.IsActive = ControllerManager.Converter.ToBool(reader["IsActive"]);
				model.IsDefault = ControllerManager.Converter.ToBool(reader["IsDefault"]);
				model.Name = ControllerManager.Converter.ToString(reader["Name"]);
				model.UnitTypeID = ControllerManager.Converter.ToInt32(reader["UnitTypeID"]);

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
