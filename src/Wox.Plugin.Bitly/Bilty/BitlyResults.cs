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
    public class BitlyResults
    {
        public BitlyNodeResults nodeKeyVal { get; set; }

    }
}
