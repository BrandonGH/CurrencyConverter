using CurrencyConverter.Models;
using System.Collections.Generic;

namespace CurrencyConverter.Repositories.Implementations
{
    public interface IConverterRepository
    {
        IEnumerable<CurrencyConversionRatio> GetConversionRatios();
    }
}