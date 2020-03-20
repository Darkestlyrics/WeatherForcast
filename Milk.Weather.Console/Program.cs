using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Milk.Weather.Data.Classes;
using Milk.Weather.Domain.Classes;
using Milk.Weather.Domain.Interfaces;
using Milk.Weather.UseCase;
using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Presenters;

namespace Milk.Weather.Console
{
    class Program
    {
        private static readonly CountryCodes Codes = new CountryCodes();
        private static readonly Forecasts Forecasts = new Forecasts();
        private static readonly PropertyPresenter<string, ErrorOutput> CodePresenter = new PropertyPresenter<string, ErrorOutput>();
        private static readonly PropertyPresenter<List<Domain.Classes.Weather>, ErrorOutput> WeatherPresenter = new PropertyPresenter<List<Domain.Classes.Weather>, ErrorOutput>();
        static async Task Main(string[] args)
        { 
            System.Console.WriteLine("Enter Country");
            string country = System.Console.ReadLine();
            System.Console.WriteLine("Enter State");
            string state = System.Console.ReadLine();
            System.Console.WriteLine("Enter City");
            string city = System.Console.ReadLine();
            string code = GetCountryCode(new CountryCodeRequest()
            {
                Country = country,
                City = city,
                State = state
            });
            var weather = await GetWeather(code);
            System.Console.WriteLine(makeHumanReadable(weather));
        }

        private  static string GetCountryCode(CountryCodeRequest request)
        {
            ICountryFetchCountryCodeUseCase usecase = new FetchCountryCodesUseCase(Codes);
            usecase.Execute(request,CodePresenter);
            return CodePresenter.SuccessContent;
        }

        private static async Task<List<Domain.Classes.Weather>> GetWeather(string code)
        {
            IForecastFetchWeatherByCityCodeUseCase usecase = new FetchWeatherByCityCodeUseCase(Forecasts);
            await usecase.Execute(code, WeatherPresenter);
            return WeatherPresenter.SuccessContent;
        }

        private static string makeHumanReadable(List<Domain.Classes.Weather> input)
        {
            StringBuilder sb = new StringBuilder();
            input.ForEach(weather =>
            {
                sb.AppendLine("Weather: " + weather.main);
                sb.AppendLine("Description: " + weather.description);
                sb.AppendLine();
            });
            return sb.ToString();
        }
    }
}
