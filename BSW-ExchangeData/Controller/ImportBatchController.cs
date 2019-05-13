using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
    public partial class ImportBatchController : List<ImportMessageBatchModel>, IController
    {
       
        public bool Get(string  bathcUniqueKey, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@BatchUniqueKey", bathcUniqueKey, SqlDbType.VarChar));

                result = ControllerManager.ExecuteSP("BSWXImportBatchInsertGet", listParameters, this, ref msg);
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
                ImportMessageBatchModel model = new ImportMessageBatchModel();

                model.ImportBatchID = ControllerManager.Converter.ToInt64(reader["ImportBatchID"]);
                model.Version = ControllerManager.Converter.ToInt32(reader["NextVersion"]);
               

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
