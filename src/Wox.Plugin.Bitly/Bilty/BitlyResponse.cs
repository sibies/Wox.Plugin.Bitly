using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wox.Plugin.Bitly.Bilty
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class BitlyResponse
    {
        [System.Xml.Serialization.XmlElement("errorCode")]
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public BitlyResults results { get; set; }
        public string statusCode { get; set; }
    }
}
