using Milk.Weather.UseCase;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Milk.Weather.Domain.Classes;
using StoneAge.CleanArchitecture.Domain.Output;
using Xunit;

namespace Milk.Weather.Test
{
    public class FetchWeatherByCityCodeUseCaseTests
    {
        private MockRepository mockRepository;



        public FetchWeatherByCityCodeUseCaseTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private FetchWeatherByCityCodeUseCase CreateFetchWeatherByCityCodeUseCase()
        {
            return new FetchWeatherByCityCodeUseCase();
        }

        [Fact]
        public async Task Execute_StateUnderTest_ExpectedBehavior()
        {
            //// Arrange
            //var fetchWeatherByCityCodeUseCase = this.CreateFetchWeatherByCityCodeUseCase();
            //string inputTo = null;
            //IRespondWithSuccessOrError<string,List<Domain.Classes.Weather> presenter = new ;

            //// Act
            //await fetchWeatherByCityCodeUseCase.Execute(
            //    inputTo,
            //    presenter);

            //// Assert
            //Assert.True(false);
            //this.mockRepository.VerifyAll();
        }
    }
}
