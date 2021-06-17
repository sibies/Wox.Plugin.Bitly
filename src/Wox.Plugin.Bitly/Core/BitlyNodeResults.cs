using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Wox.Plugin.Bitly.Core
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BitlyNodeResults
    {
        [XmlElement("shortKeywordUrl")]
        public string ShortKeywordUrl { get; set; }
        [XmlElement("hash")]
        public string Hash { get; set; }
        [XmlElement("userHash")]
        public string UserHash { get; set; }
        [XmlElement("nodeKey")]
        public string NodeKey { get; set; }
        [XmlElement("shortUrl")]
        public string ShortUrl { get; set; }
        [XmlElement("shortCNAMEUrl")]
        public string ShortCnameUrl { get; set; }
    }
}
