using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BMWCN2Extract
{
    [XmlRoot("CN2Data")]
    public class NTCN2DataModel:ModelBase
    {
        public long CNID { get; set; }

        [XmlElement("ManifestNo")]
        public string ManifestNo { get; set; }

        [XmlElement("ManifestDate")]
        public DateTime ManifestDate { get; set; }

        [XmlElement("RefeNo")]
        public string RefNo { get; set; }

        public string FileName { get; set; }

        [XmlElement("MRNNumber")]
        public string MnrNo { get; set; }

        [XmlElement("TruckReg")]
        public string TruckRegNo { get; set; }

        [XmlElement("UCRNo")]
        public string UCRNo { get; set; }

        [XmlElement("CustomsValue")]
        public decimal CustomsValue { get; set; }

        [XmlElement("VehiclesInManifest")]
        public byte VehiclesInManifest { get; set; }

        [XmlElement("ManifestCode")]
        public string ManifestCode { get; set; }

        [XmlElement("AgentCode")]
        public string AgentNo { get; set; }

        [XmlElement("ManifestStatus")]
        public string Status { get; set; }

    }
}
