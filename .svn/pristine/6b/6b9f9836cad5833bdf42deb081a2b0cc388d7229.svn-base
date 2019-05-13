using System;
using System.Data.SqlClient;

namespace PurchaseOrder.Data
{
    public interface IController:IDisposable
    {
        bool ReadModelData(SqlDataReader reader, ref string msg);
        void ClearModelData();
    }
}
