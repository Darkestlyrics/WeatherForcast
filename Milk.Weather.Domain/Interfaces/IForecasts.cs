using System.Collections.Generic;
using System.Threading.Tasks;
using Milk.Weather.Domain.Classes;

namespace Milk.Weather.Domain.Interfaces
{
    public interface IForecasts
    {
        public Task<List<Classes.Weather>> FetchForecast(string countryCode);
    }
}