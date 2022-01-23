using System;
using Xunit;
using SimpleAPI.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleAPI.Test
{
    public class ForecastControllerTests: IClassFixture<WebApplicationFactory<SimpleAPI.Startup>>
    {
        readonly HttpClient _client;
		public ForecastControllerTests(WebApplicationFactory<SimpleAPI.Startup> fixture)
		{
            _client = fixture.CreateClient();
		}


        [Fact]
        public async Task Get_RetrievedForecast_Success()
        {
            var response = await _client.GetAsync("/weatherforecast");
            response.StatusCode.Equals(System.Net.HttpStatusCode.OK);
        }

        [Fact()]
        public async Task Get_RetrievedForecastGetValue_Success()
        {
            var expectedResult = "returning value with ID 3";
            var response = await _client.GetAsync("/weatherforecast/value/3");

            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(content, expectedResult);
        }
    }
}
