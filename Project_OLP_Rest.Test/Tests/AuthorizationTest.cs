using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class AuthorizationTest
    {
        //private readonly TestServer _server;
        //private readonly HttpClient _client;
        //private IConfiguration _configuration;
        //public AuthorizationTest()
        //{
        //    _configuration = new ConfigurationBuilder()
        //    .SetBasePath(Path.GetFullPath(@"../../.."))
        //    .AddJsonFile("appsettings.json", optional: false)
        //    .Build();

        //    _server = new TestServer(new WebHostBuilder()
        //        .UseStartup<Startup>()
        //        .UseConfiguration(_configuration));
        //    _client = _server.CreateClient();
        //}

        //[Fact]
        //public async Task UnAuthorizedAccess()
        //{
        //    var response = await _client.GetAsync("/api/books");

        //    Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        //}
    }
}
