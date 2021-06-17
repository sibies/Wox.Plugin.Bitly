using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Wox.Plugin.Bitly.Core
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class BitlyResponse
    {
        [XmlElement("errorCode")]
        public int ErrorCode { get; set; }
        [XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }
        [XmlElement("results")]
        public BitlyResults Results { get; set; }
        [XmlElement("statusCode")]
        public string StatusCode { get; set; }
    }
}
