using System;
using System.Data.SqlClient;

namespace BMWCN2Extract
{
    public interface IController:IDisposable
    {
        bool ReadModelData(SqlDataReader reader, ref string msg);
        void ClearModelData();
    }
}
