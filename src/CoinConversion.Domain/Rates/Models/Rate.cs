using System;
using System.Collections.Generic;
using System.Text;

namespace CoinConversion.Domain.Rates.Models
{
    public class Rate
    {
        public double ValueOrigin { get; private set; }
        public string CurrencyOrigin { get; private set; }
        public string CurrencyDestination { get; private set; }
        public string FormatMsg { get; private set; }
        public string ApiKey { get; private set; }


        public Rate(double valueOrigin, string currencyOrigin, string currencyDestination, string formatMsg, string apiKey)
        {
            if(valueOrigin < 1)
                throw new ArgumentException("Invalid source value currency");

            if (string.IsNullOrEmpty(currencyOrigin))
                throw new ArgumentException("Invalid source currency");

            if (string.IsNullOrEmpty(currencyDestination))
                throw new ArgumentException("Invalid destination currency");

            if ( formatMsg != "1" && formatMsg != "0")
                throw new ArgumentException("Invalid format message");

            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Invalid ApiKey");

            ValueOrigin = valueOrigin;
            CurrencyOrigin = currencyOrigin;
            CurrencyDestination = currencyDestination;
            FormatMsg = formatMsg;
            ApiKey = apiKey;
        }
    }
}
