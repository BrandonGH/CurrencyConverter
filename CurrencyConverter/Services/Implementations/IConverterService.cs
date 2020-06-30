using CurrencyConverter.Models;
using System.Collections.Generic;

namespace CurrencyConverter.Services.Implementations
{
    public interface IConverterService
    {
        double Convert(double amountToConvert, string originalCurrency, string targetCurrency);
        List<CurrencyConversionRatio> GetConversionRatios();
    }
}