using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BSW_ExchangeData
{
    public class ProfileHistoryController:List<ProfileHistoryModel>,IController
    {

        public bool GetLastRunTime(byte profileID, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@ProfileID", profileID, SqlDbType.TinyInt));

                result = ControllerManager.ExecuteSP("BSWXProfileHistoryLastRunGet", listParameters, this, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        public bool Insert(ProfileHistoryModel model, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@ProfileID", model.ProfileID, SqlDbType.TinyInt));
                listParameters.Add(ControllerManager.CreateParameter("@EventDescription", model.Eventdescription, SqlDbType.VarChar));
                listParameters.Add(ControllerManager.CreateParameter("@EventTypeID", model.EventTypeID, SqlDbType.TinyInt));

                object value = null;

                result = ControllerManager.ExecuteSPScalar("BSWXProfileHistoryInsert", listParameters, ref value, ref msg);

                if (result)
                    model.ProfileHistoryID = ControllerManager.Converter.ToInt64(value);
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
                ProfileHistoryModel model = new ProfileHistoryModel();

                model.ProfileHistoryID = ControllerManager.Converter.ToInt64(reader["ProfileHistoryID"]);
                model.ProfileID = ControllerManager.Converter.ToByte(reader["ProfileID"]);
                model.EventDT = ControllerManager.Converter.ToDateTime(reader["EventDT"]);
                model.Eventdescription = ControllerManager.Converter.ToString(reader["EventDescription"]);
                model.EventTypeID = ControllerManager.Converter.ToByte(reader["EventTypeID"]);

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
