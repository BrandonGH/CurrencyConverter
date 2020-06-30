using System.Web.Mvc;
using CurrencyConverter.Models;
using CurrencyConverter.Controllers;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using CurrencyConverter.Repositories.Implementations;
using CurrencyConverter.Services.Implementations;
using CurrencyConverter.Services.Interfaces;
using System.Linq;

namespace CurrencyConverter.Tests.Controllers
{
    [TestFixture]
    public class ConverterControllerTest
    {
        Mock<IConverterService> _service;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IConverterService>();
        }

        [Test]
        public void Index()
        {
            // Arrange
            var controller = new ConverterController(_service.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void HomePageLoadsEveryConversionRatio()
        {
            // Arrange
            var fooRatio = new CurrencyConversionRatio() { OriginalCurrency = "GBP", TargetCurrency = "FOO", Ratio = 0.10 };
            var barRatio = new CurrencyConversionRatio() { OriginalCurrency = "GBP", TargetCurrency = "BAR", Ratio = 20.00 };
            var fakeRatios = new List<CurrencyConversionRatio>
            {
                fooRatio,
                barRatio
            };
            _service.Setup(x => x.GetConversionRatios()).Returns(fakeRatios);
            var controller = new ConverterController(_service.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result.ViewData.Model, Is.InstanceOf(typeof(List<CurrencyConversionRatio>)));
            var ratioList = result.ViewData.Model as List<CurrencyConversionRatio>;
            Assert.That(ratioList.Count, Is.EqualTo(2));
            Assert.That(ratioList.Contains(fooRatio), Is.True);
            Assert.That(ratioList.Contains(barRatio), Is.True);
        }

        [Test]
        [TestCase("GBP", "FOO", 1.00, 0.10)]
        [TestCase("GBP", "BAR", 1.00, 20.00)]
        public void HomePageConversionWithSelectionFieldsShowsCorrectValue(string originalCurrency, string targetCurrency, double amountToConvert, double convertedAmount)
        {
            // Arrange
            var fooRatio = new CurrencyConversionRatio() { OriginalCurrency = "GBP", TargetCurrency = "FOO", Ratio = 0.10 };
            var barRatio = new CurrencyConversionRatio() { OriginalCurrency = "GBP", TargetCurrency = "BAR", Ratio = 20.00 };
            var fakeRatios = new List<CurrencyConversionRatio>
            {
                fooRatio,
                barRatio
            };
            _service.Setup(x => x.GetConversionRatios()).Returns(fakeRatios);
            var controller = new ConverterController(_service.Object);

            // Act
            ViewResult result = controller.Index(originalCurrency, targetCurrency, amountToConvert) as ViewResult;

            // Assert
            Assert.That(result.ViewData["Result"], Is.EqualTo(convertedAmount));
        }
    }
}
