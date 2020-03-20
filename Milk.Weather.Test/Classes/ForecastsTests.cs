using Milk.Weather.Data.Classes;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Milk.Weather.Test.Classes
{
    public class ForecastsTests
    {
        private MockRepository mockRepository;



        public ForecastsTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Forecasts CreateForecasts()
        {
            return new Forecasts();
        }

        [Fact]
        public async Task FetchForecast_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var forecasts = this.CreateForecasts();
            string countryCode = "953987";

            // Act
            var result = await forecasts.FetchForecast(
                countryCode);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
