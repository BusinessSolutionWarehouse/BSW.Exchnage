using System;
using System.Data.SqlClient;

namespace AZROEImports
{
    public interface IController:IDisposable
    {
        bool ReadModelData(SqlDataReader reader, ref string msg);
        void ClearModelData();
    }
}
