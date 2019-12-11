using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCore.Starter.Tests
{
    public class ControllerWeatherForecastTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _fixture;
        private readonly HttpClient _client;

        public ControllerWeatherForecastTests(WebApplicationFactory<Program> fixture)
        {
            _fixture = fixture;
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task TestGetWeatherForecast()
        {
            var response = await _client.GetAsync("/weatherforecast").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var weatherForecasts = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherForecast[]>
                (await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.NotNull(weatherForecasts);
            Assert.NotEmpty(weatherForecasts);
            Assert.Equal(5, weatherForecasts.Length);
        }

        [Fact]
        public async Task TestErrorPage()
        {
            var response = await _client.GetAsync("/error").ConfigureAwait(false);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
