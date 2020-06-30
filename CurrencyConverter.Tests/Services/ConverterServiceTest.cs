using CurrencyConverter.Models;
using CurrencyConverter.Repositories.Implementations;
using CurrencyConverter.Services.Implementations;
using CurrencyConverter.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CurrencyConverter.Tests.Services
{
    [TestFixture]
    class ConverterServiceTest
    {
        Mock<IConverterRepository> _repository;
        IConverterService _service;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IConverterRepository>();
        }

        [Test]
        [TestCase(10.00, "GBP", "FOO", 1.00)]
        [TestCase(10.00, "GBP", "BAR", 200.00)]
        public void ConvertCorrectlyCalculates(double amountToConvert, string originalCurrency, string targetCurrency, double convertedAmount)
        {
            // Arrange
            var fakeRatios = new List<CurrencyConversionRatio>
            {
                new CurrencyConversionRatio(){OriginalCurrency = "GBP", TargetCurrency = "FOO", Ratio = 0.10 },
                new CurrencyConversionRatio(){OriginalCurrency = "GBP", TargetCurrency = "BAR", Ratio = 20.00 }
            };
            _repository.Setup(x => x.GetConversionRatios()).Returns(fakeRatios);
            _service = new ConverterService(_repository.Object);

            // Act
            var result = _service.Convert(amountToConvert, originalCurrency, targetCurrency);

            // Assert
            Assert.That(result, Is.EqualTo(convertedAmount));
        }
    }
}
