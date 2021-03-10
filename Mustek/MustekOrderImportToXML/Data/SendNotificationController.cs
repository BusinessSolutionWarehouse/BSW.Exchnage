using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MustekOrderImportToXML
{
    public class SendNotificationController:IController
    {

        public bool SendNotification(ref string msg)
        {
            bool result = true;

            try
            {
                //set the connection string to be used
                ControllerManager.ConnectionName = "BSWExchange";

                List<SqlParameter> listParameters = new List<SqlParameter>();

                result = ControllerManager.ExecuteSP("MS_OrderReceiveNotificationSend", listParameters, ref msg);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        //These function are not needed - as thsi controller will never return anything
        public bool ReadModelData(System.Data.SqlClient.SqlDataReader reader, ref string msg)
        {
            return true;
        }

        public void ClearModelData()
        {
           
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
