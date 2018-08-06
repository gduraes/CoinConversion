using CoinConversion.Domain.Rates.Models;

namespace CoinConversion.Domain.Rates.Services
{
    public class ConversionRate
    {
        private IRateService rateService;

        public ConversionRate(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public object CalculateRate(RateDto rateDto)
        {
            var rate = new Rate(
                rateDto.ValueOrigin, 
                rateDto.CurrencyOrigin, 
                rateDto.CurrencyDestination, 
                rateDto.FormatMsg, 
                rateDto.ApiKey);

            return rateService.Calculate(rate);
        }
    }
}
