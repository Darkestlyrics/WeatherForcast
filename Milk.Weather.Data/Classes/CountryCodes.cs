using System.Collections.Generic;
using System.IO;
using System.Linq;
using Milk.Weather.Domain.Classes;
using Milk.Weather.Domain.Interfaces;
using Newtonsoft.Json;

namespace Milk.Weather.Data.Classes
{
    public class CountryCodes: ICountryCodes
    {

        private  List<Country> _countries;

        public CountryCodes()
        {
            LoadJson();
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("city.list.json"))
            {
                string json = r.ReadToEnd();
                 _countries = JsonConvert.DeserializeObject<List<Country>>(json);
            }
        }

        public string FetchCountryCode(CountryCodeRequest request)
        {
            return _countries.First(country =>
                request.State.Length > 0
                    ? country.country == request.Country && country.state == request.State && country.name == request.City
                    : country.country == request.Country && country.name == request.City).id.ToString();
        }
    }
}