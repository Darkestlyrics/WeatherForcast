using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Milk.Weather.Domain.Classes;
using Milk.Weather.Domain.Interfaces;
using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Presenters;

namespace Milk.Weather.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastFetchWeatherByCityCodeUseCase _fetchWeatherByCityCodeUseCase;
        private readonly ICountryFetchCountryCodeUseCase _countryFetchCountryCodeUseCase;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICountryFetchCountryCodeUseCase countryFetchCountryCodeUseCase, IForecastFetchWeatherByCityCodeUseCase fetchWeatherByCityCodeUseCase)
        {
            _logger = logger;
            _countryFetchCountryCodeUseCase = countryFetchCountryCodeUseCase;
            _fetchWeatherByCityCodeUseCase = fetchWeatherByCityCodeUseCase;
        }

        [HttpGet]
        public async Task<List<Domain.Classes.Weather>> Get(CountryCodeRequest request)
        {
            var codePresenter = new PropertyPresenter<string, ErrorOutput>();
            var weatherPresenter = new PropertyPresenter<List<Domain.Classes.Weather>, ErrorOutput>();
            _countryFetchCountryCodeUseCase.Execute(request, codePresenter);
            var code = codePresenter.SuccessContent;
            await _fetchWeatherByCityCodeUseCase.Execute(code, weatherPresenter);
            var result = weatherPresenter.SuccessContent;
            return result;
        }
    }
}
