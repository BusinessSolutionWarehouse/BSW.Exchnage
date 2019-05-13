using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PurchaseOrder.Data
{
	public partial class BusinessEntityController : List<BusinessEntityModel>, IController
	{
        bool includeRole = false;

		public bool Get(BusinessEntityModel model, ref string msg)
		{
			return Get(model, null, null, ref msg);
		}

		public bool Get(BusinessEntityModel model, BusinessEntityModel.Fields? sortByField, SortOrder? sortOrder, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.BusinessEntityCode))
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityCode", model.BusinessEntityCode, SqlDbType.VarChar));

				if (model.BusinessEntityID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityID", model.BusinessEntityID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.BusinessEntityName))
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityName", model.BusinessEntityName, SqlDbType.VarChar));
                				
				
				result = ControllerManager.ExecuteSP("BusinessEntityGet", listParameters, this, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

        public bool GetImporter(BusinessEntityModel model,ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(model.BusinessEntityCode))
                    listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityCode", model.BusinessEntityCode, SqlDbType.VarChar));

                if (model.BusinessEntityID.HasValue)
                    listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityID", model.BusinessEntityID.Value, SqlDbType.Int));

                if (!string.IsNullOrEmpty(model.BusinessEntityName))
                    listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityName", model.BusinessEntityName, SqlDbType.VarChar));

                includeRole = true;
                result = ControllerManager.ExecuteSP("BusinessEntityImportersGet", listParameters, this, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

       
		public bool Insert(BusinessEntityModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityCode", model.BusinessEntityCode, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityName", model.BusinessEntityName, SqlDbType.VarChar));
				listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityStatusID", model.BusinessEntityStatusID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityTypeID", model.BusinessEntityTypeID, SqlDbType.TinyInt));
				listParameters.Add(ControllerManager.CreateParameter("@VatNumber", model.VatNumber, SqlDbType.VarChar));

				object value = null;

				result = ControllerManager.ExecuteSPScalar("BusinessEntityInsert", listParameters, ref value, ref msg);

				if (result)
					model.BusinessEntityID = ControllerManager.Converter.ToInt32(value);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Update(BusinessEntityModel model, bool dynamicUpdate, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityID", model.BusinessEntityID.Value, SqlDbType.Int));

				if (dynamicUpdate)
				{
					if (!string.IsNullOrEmpty(model.BusinessEntityCode))
						listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityCode", model.BusinessEntityCode, SqlDbType.VarChar));

					if (!string.IsNullOrEmpty(model.BusinessEntityName))
						listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityName", model.BusinessEntityName, SqlDbType.VarChar));

					if (model.BusinessEntityStatusID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityStatusID", model.BusinessEntityStatusID.Value, SqlDbType.TinyInt));

					if (model.BusinessEntityTypeID.HasValue)
						listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityTypeID", model.BusinessEntityTypeID.Value, SqlDbType.TinyInt));

					if (!string.IsNullOrEmpty(model.VatNumber))
						listParameters.Add(ControllerManager.CreateParameter("@VatNumber", model.VatNumber, SqlDbType.VarChar));

				}
				else
				{
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityCode", model.BusinessEntityCode, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityName", model.BusinessEntityName, SqlDbType.VarChar));
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityStatusID", model.BusinessEntityStatusID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityTypeID", model.BusinessEntityTypeID, SqlDbType.TinyInt));
					listParameters.Add(ControllerManager.CreateParameter("@VatNumber", model.VatNumber, SqlDbType.VarChar));
				}

				listParameters.Add(ControllerManager.CreateParameter("@CheckNull", dynamicUpdate ? 1 : 0, SqlDbType.Bit));

				result = ControllerManager.ExecuteSP("BusinessEntityUpdate", listParameters, ref msg);
			}
			catch (Exception ex)
			{
				msg = ex.Message;
				result = false;
			}

			return result;
		}

		public bool Delete(BusinessEntityModel model, ref string msg)
		{
			bool result = true;

			try
			{
				List<SqlParameter> listParameters = new List<SqlParameter>();

				if (!string.IsNullOrEmpty(model.BusinessEntityCode))
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityCode", model.BusinessEntityCode, SqlDbType.VarChar));

				if (model.BusinessEntityID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityID", model.BusinessEntityID.Value, SqlDbType.Int));

				if (!string.IsNullOrEmpty(model.BusinessEntityName))
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityName", model.BusinessEntityName, SqlDbType.VarChar));

				if (model.BusinessEntityStatusID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityStatusID", model.BusinessEntityStatusID.Value, SqlDbType.TinyInt));

				if (model.BusinessEntityTypeID.HasValue)
					listParameters.Add(ControllerManager.CreateParameter("@BusinessEntityTypeID", model.BusinessEntityTypeID.Value, SqlDbType.TinyInt));

				if (!string.IsNullOrEmpty(model.VatNumber))
					listParameters.Add(ControllerManager.CreateParameter("@VatNumber", model.VatNumber, SqlDbType.VarChar));

				result = ControllerManager.ExecuteSP("BusinessEntityDelete", listParameters, ref msg);
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
				BusinessEntityModel model = new BusinessEntityModel();

				model.BusinessEntityCode = ControllerManager.Converter.ToString(reader["BusinessEntityCode"]);
				model.BusinessEntityID = ControllerManager.Converter.ToInt32(reader["BusinessEntityID"]);
				model.BusinessEntityName = ControllerManager.Converter.ToString(reader["BusinessEntityName"]);
				model.BusinessEntityStatusID = ControllerManager.Converter.ToByte(reader["BusinessEntityStatusID"]);
				model.BusinessEntityTypeID = ControllerManager.Converter.ToByte(reader["BusinessEntityTypeID"]);
				model.VatNumber = ControllerManager.Converter.ToString(reader["VatNumber"]);
                
                if(includeRole)
                    model.BusinessEntityRoleLinkID = ControllerManager.Converter.ToInt32(reader["BusinessEntityRoleLinkID"]);
				
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
