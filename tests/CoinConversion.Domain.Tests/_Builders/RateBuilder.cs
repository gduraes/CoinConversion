using CoinConversion.Domain.Rates.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinConversion.Domain.Tests._Builders
{
    public class RateBuilder
    {
        string currencyOrigin = "USD";
        string currencyDestination = "BRL";
        string formatMsg = "1";
        string apiKey = "7795e574f6c9677966aeacf39e496503";
        double valueOrigin = 10;
        double valueDestination;

        public static RateBuilder New()
        {
            return new RateBuilder();
        }

        public RateBuilder WithCurrencyOrigin(string currencyOrigin)
        {
            this.currencyOrigin = currencyOrigin;
            return this;
        }

        public RateBuilder WithCurrencyDestination(string currencyDestination)
        {
            this.currencyDestination = currencyDestination;
            return this;
        }

        public RateBuilder WithFormatMessage(string formatMsg)
        {
            this.formatMsg = formatMsg;
            return this;
        }


        public RateBuilder WithApiKey(string apiKey)
        {
            this.apiKey = apiKey;
            return this;
        }

        public RateBuilder WithValueOrigin(double valueOrigin)
        {
            this.valueOrigin = valueOrigin;
            return this;
        }

        public RateBuilder WithValueDestination(double valueDestination)
        {
            this.valueDestination = valueDestination;
            return this;
        }

        public Rate Build()
        {
            return new Rate(
                valueOrigin,
                currencyOrigin,
                currencyDestination,
                formatMsg,
                apiKey);

        }

    }
}
