using System;
using System.Data.SqlClient;
namespace BSW_ExchangeData
{
    public interface IController:IDisposable
    {
        bool ReadModelData(SqlDataReader reader, ref string msg);
        void ClearModelData();
    }
}
