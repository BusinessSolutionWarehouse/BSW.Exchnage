using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSW_ExchangeData
{
    public class ProfileHistoryModel:ModelBase
    {
        public Int64? ProfileHistoryID { get; set; }

        public byte? ProfileID { get; set; }

        public DateTime? EventDT { get; set; }

        public string Eventdescription { get; set; }

        public byte? EventTypeID { get; set; }

    }
}
