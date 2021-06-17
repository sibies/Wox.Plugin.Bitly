using System.Net;
using System.Web;
using System.Xml.Serialization;

namespace Wox.Plugin.Bitly.Core
{
    public class BitlyClient
    {
        readonly string _login;
        readonly string _apiKey;
        public BitlyClient(string login, string apiKey)
        {
            _login = login;
            _apiKey = apiKey;

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
