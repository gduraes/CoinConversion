namespace CoinConversion.Domain.Rates.Services
{
    public class RateDto
    {
        public double ValueDestination { get; set; }
        public double ValueOrigin { get; set; }
        public string ApiKey { get; set; }
        public string FormatMsg { get; set; }
        public string CurrencyDestination { get; set; }
        public string CurrencyOrigin { get; set; }
    }

}
