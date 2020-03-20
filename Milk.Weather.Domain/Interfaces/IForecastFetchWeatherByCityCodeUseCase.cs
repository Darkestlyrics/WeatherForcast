using System.Collections.Generic;
using Milk.Weather.Domain.Classes;
using StoneAge.CleanArchitecture.Domain;

namespace Milk.Weather.Domain.Interfaces
{
    public interface IForecastFetchWeatherByCityCodeUseCase: IUseCaseAsync<string,List<Classes.Weather>>
    {
        
    }
}