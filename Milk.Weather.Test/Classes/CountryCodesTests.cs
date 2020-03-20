using Milk.Weather.Data.Classes;
using System;
using Milk.Weather.Domain.Classes;
using Xunit;

namespace Milk.Weather.Test.Classes
{
    public class CountryCodesTests
    {
        [Fact]
        public void FetchCountryCode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var countryCodes = new CountryCodes();
            CountryCodeRequest request = new CountryCodeRequest()
            {
                Country = "ZA",
                State = "",
                City = "Johannesburg"
            };

            // Act
            var result = countryCodes.FetchCountryCode(
                request);

            // Assert
            Assert.True(false);
        }
    }
}
