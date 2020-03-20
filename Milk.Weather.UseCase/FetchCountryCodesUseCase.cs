using System.Collections.Generic;
using Milk.Weather.Domain.Classes;
using Milk.Weather.Domain.Interfaces;
using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Output;

namespace Milk.Weather.UseCase
{
    public class FetchCountryCodesUseCase: ICountryFetchCountryCodeUseCase
    {
        private readonly ICountryCodes _countryCodes;

        public FetchCountryCodesUseCase(ICountryCodes countryCodes)
        {
            _countryCodes = countryCodes;
        }

        public void Execute(CountryCodeRequest inputTo, IRespondWithSuccessOrError<string, ErrorOutput> presenter)
        {
            presenter.Respond(_countryCodes.FetchCountryCode(inputTo));
        }
    }
}