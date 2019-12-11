using Xunit;

namespace AspNetCore.Starter.Tests
{
    public class WeatherForecastTests
    {
        [Theory]
        [InlineData(0, 32)]
        [InlineData(10, 49)]
        [InlineData(20, 67)]
        [InlineData(30, 85)]
        [InlineData(40, 103)]
        [InlineData(50, 121)]
        [InlineData(60, 139)]
        [InlineData(70, 157)]
        public void TestCelsiusToFahrenheitConverter(int tempInCelsius, int tempFahrenheit)
        {
            var weather = new WeatherForecast
            {
                TemperatureC = tempInCelsius
            };
            Assert.Equal(tempFahrenheit, weather.TemperatureF);
        }
    }
}
