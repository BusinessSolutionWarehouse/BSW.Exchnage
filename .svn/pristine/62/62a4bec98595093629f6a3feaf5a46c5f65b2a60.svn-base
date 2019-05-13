using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BSW_ExchangeData
{
    public class EventLogController:List<EventLogModel>,IController
    {

        public bool Insert(EventLogModel model, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@EventTypeID", model.EventTypeID, SqlDbType.TinyInt));
                listParameters.Add(ControllerManager.CreateParameter("@EventProcess", model.EventProcess, SqlDbType.VarChar));
                listParameters.Add(ControllerManager.CreateParameter("@EventDescription", model.EventDescription, SqlDbType.VarChar));

                object value = null;

                result = ControllerManager.ExecuteSPScalar("BSWXEventLogInsert", listParameters, ref value, ref msg);

                if (result)
                    model.EventID = ControllerManager.Converter.ToInt64(value);
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
                EventLogModel model = new EventLogModel();
                //TODO:Add loading code
               
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
