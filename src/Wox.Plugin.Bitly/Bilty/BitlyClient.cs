using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Wox.Plugin.Bitly.Bilty;

namespace Wox.Plugin.Bitly
{
    public class BitlyClient
    {
        string _login = string.Empty;
        string _apiKey = string.Empty;
        public BitlyClient(string Login, string APIKey)
        {
            _login = Login;
            _apiKey = APIKey;

        }

        public BitlyResponse Shorten(string urlToShorten)
        {
            string address = string.Format("http://api.bit.ly/shorten?format={3}&version=2.0.1&longUrl={2}&login={0}&apiKey={1}",
               _login,                                     // Your username
               _apiKey,                                    // Your API key
                      HttpUtility.UrlEncode(urlToShorten), // Encode the url we want to shorten
               "xml");

            using (WebClient client = new WebClient())
            using (var stream = client.OpenRead(address))
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "bitly";
                // xRoot.Namespace = "http://www.totpe.ro";
                xRoot.IsNullable = true;
                XmlSerializer serializer = new XmlSerializer(typeof(BitlyResponse), xRoot);
                return (BitlyResponse)serializer.Deserialize(stream);
            }
        }
    }
}
