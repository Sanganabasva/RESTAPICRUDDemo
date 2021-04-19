﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RESTAPICRUDDemo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestEmpIntegrationServices
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}
