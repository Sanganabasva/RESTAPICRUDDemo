using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class EmployeeAPIIntegrationTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("api/[controller]");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
