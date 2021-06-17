using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Wox.Plugin.Bitly.Core
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BitlyResults
    {
        [XmlElement("nodeKeyVal")]
        public BitlyNodeResults NodeKeyVal { get; set; }

    }
}
