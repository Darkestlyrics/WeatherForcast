using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Milk.Weather.Domain.Interfaces;
using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Output;

namespace Milk.Weather.UseCase
{

    public class FetchWeatherByCityCodeUseCase: IForecastFetchWeatherByCityCodeUseCase
    {
        private readonly IForecasts _forecasts;

        public FetchWeatherByCityCodeUseCase(IForecasts forecasts)
        {
            _forecasts = forecasts;
        }


        public async Task Execute(string inputTo, IRespondWithSuccessOrError<List<Domain.Classes.Weather>, ErrorOutput> presenter)
        {
            var res = await _forecasts.FetchForecast(inputTo);
            presenter.Respond(res);
        }
    }
}
