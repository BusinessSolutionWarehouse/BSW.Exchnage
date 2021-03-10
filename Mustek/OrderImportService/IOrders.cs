using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OrderImportService
{
   
    [ServiceContract]
    public interface IOrders
    {
        [OperationContract]
        Response PostOrder(string xmlData);

    }

   
}
