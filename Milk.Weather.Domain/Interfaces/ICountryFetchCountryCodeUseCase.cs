using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Milk.Weather.Domain.Classes;
using StoneAge.CleanArchitecture.Domain;

namespace Milk.Weather.Domain.Interfaces
{
    public interface ICountryFetchCountryCodeUseCase: IUseCase<CountryCodeRequest,string>
    {
        
    }
}