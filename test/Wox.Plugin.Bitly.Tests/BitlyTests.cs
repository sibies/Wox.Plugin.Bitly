using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wox.Plugin.Bitly.Core;

namespace Wox.Plugin.Bitly.Tests
{
    [TestClass]
    public class BitlyTests
    {
        private const string Login = "o_4cntrdegel";
        private const string ApiKey = "R_87c977a77dde4824bce2cb64e530bd5a";

        [TestMethod]
        public void TestMethod1()
        {
            var client = new BitlyClient(Login, ApiKey);
            var shorten = client.Shorten("http://google.com.ua/");
            //Assert.IsNotNull(shorten);
            shorten.Should().NotBeNull();
            //Assert.IsNull(_client.Authenticate(Login, WrongPassword).Data);
        }
    }
}
