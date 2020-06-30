using CurrencyConverter.Models;
using CurrencyConverter.Repositories.Implementations;
using CurrencyConverter.Services.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Services.Interfaces
{
    public class ConverterService : IConverterService
    {
        IConverterRepository _repository;

        public ConverterService(IConverterRepository converterRepository)
        {
            _repository = converterRepository;
        }

        public double Convert(double amountToConvert, string originalCurrency, string targetCurrency)
        {
            var conversionRatios = _repository.GetConversionRatios();

            var matchingConversionRatio = conversionRatios.SingleOrDefault(x => x.OriginalCurrency.Equals(originalCurrency) && x.TargetCurrency.Equals(targetCurrency));

            return amountToConvert * matchingConversionRatio.Ratio;
        }

        public List<CurrencyConversionRatio> GetConversionRatios()
        {
            return _repository.GetConversionRatios().ToList();
        }
    }
}