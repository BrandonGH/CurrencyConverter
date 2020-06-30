using CurrencyConverter.Models;
using CurrencyConverter.Repositories.Implementations;
using System.Collections.Generic;

namespace CurrencyConverter.Repositories.Interfaces
{
    public class ConverterRepository : IConverterRepository
    {
        public IEnumerable<CurrencyConversionRatio> GetConversionRatios()
        {
            var conversionRatios = new List<CurrencyConversionRatio>()
            {
                new CurrencyConversionRatio(){OriginalCurrency = "GBP", TargetCurrency = "USD", Ratio = 1.23 },
                new CurrencyConversionRatio(){OriginalCurrency = "GBP", TargetCurrency = "AUD", Ratio = 1.79 },
                new CurrencyConversionRatio(){OriginalCurrency = "GBP", TargetCurrency = "EUR", Ratio = 1.09 }
            };

            return conversionRatios;
        }
    }
}