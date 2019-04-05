using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace WebAPI.xUnit
{
    public class ValuesTests
    {
        public ValuesTests(ITestOutputHelper outputHelper)
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());
            Client = server.CreateClient();
            Output = outputHelper;
        }

        public HttpClient Client { get; }
        public ITestOutputHelper Output { get; }
        [Fact]
        public async Task GetById_ShouldBe_Ok()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await Client.GetAsync($"/api/values/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldBe_OK()
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { Name = "cxt", Age = 22 }), Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await Client.PostAsync("/api/values", content);

            // Output
            var responseTest = await response.Content.ReadAsStringAsync();

            Output.WriteLine(responseTest);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
