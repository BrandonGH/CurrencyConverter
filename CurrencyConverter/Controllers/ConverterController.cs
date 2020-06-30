using CurrencyConverter.Repositories.Interfaces;
using CurrencyConverter.Services.Implementations;
using CurrencyConverter.Services.Interfaces;
using System.Web.Mvc;

namespace CurrencyConverter.Controllers
{
    public class ConverterController : Controller
    {
        IConverterService _converterService;

        public ConverterController()
        {
            _converterService = new ConverterService(new ConverterRepository());
        }

        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        // GET: Converter
        public ActionResult Index()
        {
            return View(_converterService.GetConversionRatios());
        }

        public ActionResult Index(string originalCurrency, string targetCurrency, double amountToConvert)
        {
            return View(_converterService.GetConversionRatios());
        }
    }
}
