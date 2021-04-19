using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TestEmpIntegrationServices
{
    public class EmployeeAPIIntegrationTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            var empdata= new 
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/api/Employees");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
