using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseOrderImport
{

    public enum PurchaseOrderStatus
    {
        Incomeplete = 1,
        Pending = 2,
        Approved = 3
    }

    public enum OrderLineStatus
    {
        Pending = 2,
        Approved = 3,
        Cancelled = 4
    }

    public enum ProductStatus
    {
        Approved = 1,
        Pending = 2,
        Removed = 3,
        PendingServiceValidation = 4
    }


    class PublicEnums
    {
    }
}
