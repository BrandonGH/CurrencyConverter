using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CurrencyConverter.Models
{
    public class CurrencyConversionRatio
    {
        [Display(Name = "Original Currency")]
        public string OriginalCurrency { get; set; }
        [Display(Name = "Target Currency")]
        public string TargetCurrency { get; set; }
        public double Ratio { get; set; }
    }

    //public class DBContextCurrencyConversionRatio : DbContext
    //{
    //    public DbSet<CurrencyConversionRatio> CurrencyConversionRatios { get; set; }
    //}
}