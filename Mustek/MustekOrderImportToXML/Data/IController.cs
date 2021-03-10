using System;
using System.Data.SqlClient;

namespace MustekOrderImportToXML
{
    public interface IController:IDisposable
    {
        bool ReadModelData(SqlDataReader reader, ref string msg);
        void ClearModelData();
    }
}
