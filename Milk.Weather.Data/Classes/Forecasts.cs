
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Milk.Weather.Domain;
using Milk.Weather.Domain.Interfaces;

namespace Milk.Weather.Data.Classes
{
    public class Forecasts : IForecasts
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<List<Domain.Classes.Weather>> FetchForecast(string countryCode)
        {

            List<Domain.Classes.Weather> res = new List<Domain.Classes.Weather>();
            var mapper = Create_Mapper();
            string url = buildRequest(countryCode);
            var response = await Client.GetAsync(new Uri(url));
            var responseString = await response.Content.ReadAsStringAsync();
            Forecast forecast = JsonHelper.DeserializeObject<Forecast>(responseString);
            forecast.list.ToList().ForEach(o =>
            {
                o.weather.ToList().ForEach(weather => { res.Add(mapper.Map<Domain.Classes.Weather>(weather)); });
            });
            return res;

        }
        private string buildRequest(string CountryCode)
        {
            return $"http://samples.openweathermap.org/data/2.5/forecast/hourly?id={CountryCode}&appid=eeac5cfc311b31eee5b10a11a64ffded";
        }

        private IMapper Create_Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Classes.Weather, Weather>();
                cfg.CreateMap<Weather, Domain.Classes.Weather>();
            });

            return config.CreateMapper();
        }
    }
}