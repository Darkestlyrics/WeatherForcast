using System.Collections.Generic;
using Milk.Weather.Domain.Classes;

namespace Milk.Weather.Domain.Interfaces
{
    public interface ICountryCodes
    {
        public string FetchCountryCode(CountryCodeRequest request);
    }
}