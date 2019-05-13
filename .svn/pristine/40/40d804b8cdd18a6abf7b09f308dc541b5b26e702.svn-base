using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BMWCN2Extract
{
    public class NTCN2DataController : List<NTCN2DataModel>, IController
    {
        private bool LoadManifestOnly = false;

        public bool Get(string manifestNo,ref string msg)
        {
            bool result = true;

            try
            {
                LoadManifestOnly = false;

                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@ManifestNo", manifestNo, SqlDbType.VarChar));

                result = ControllerManager.ExecuteSP("BMW_CN2DataExtract", listParameters, this, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        public bool Update(string manifestNo,string fileName, ref string msg)
        {
            bool result = true;

            try
            {
                List<SqlParameter> listParameters = new List<SqlParameter>();

                listParameters.Add(ControllerManager.CreateParameter("@FileName", fileName, SqlDbType.VarChar));
                listParameters.Add(ControllerManager.CreateParameter("@ManifestNo", manifestNo, SqlDbType.VarChar));

                result = ControllerManager.ExecuteSP("BMW_CN2DataUpdate", listParameters, ref msg);
                            
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = false;
            }

            return result;
        }

        public bool LoadManifests(ref string msg)
        {
            
            bool result = true;

            try
            {
                LoadManifestOnly = true;

                List<SqlParameter> listParameters = new List<SqlParameter>();

                result = ControllerManager.ExecuteSP("BMW_CN2ManifestGet", listParameters, this, ref msg);
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
                NTCN2DataModel model = new NTCN2DataModel();

                model.ManifestNo = Convert.ToString(reader["ManifestNo"]);
                if (!LoadManifestOnly)
                {

                    model.ManifestDate = Convert.ToDateTime(reader["ManifestDate"]);
                    model.RefNo = Convert.ToString(reader["ReferenceNo"]);
                    model.MnrNo = Convert.ToString(reader["Mrn_Number"]);
                    model.ManifestCode = Convert.ToString(reader["ManifestCode"]);
                    model.VehiclesInManifest = Convert.ToByte(reader["VehiclesInManifest"]);
                    model.Status = Convert.ToString(reader["Status"]);
                    model.AgentNo = Convert.ToString(reader["AgentNo"]);
                    model.TruckRegNo = Convert.ToString(reader["TruckRegNo"]);
                    model.UCRNo = Convert.ToString(reader["UCR"]);
                    model.CustomsValue = Convert.ToDecimal(reader["CustomsValue"]);

                }
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
