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
    public class BitlyNodeResults
    {
        public string shortKeywordUrl { get; set; }
        public string hash { get; set; }
        public string userHash { get; set; }
        public string nodeKey { get; set; }
        public string shortUrl { get; set; }
        public string shortCNAMEUrl { get; set; }
    }
}
