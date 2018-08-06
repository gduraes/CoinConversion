using Bogus;
using CoinConversion.Domain.Rates.Models;
using CoinConversion.Domain.Tests._Builders;
using CoinConversion.Domain.Tests._Utils;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CoinConversion.Domain.Tests.Rates.Unit
{
    public class RateTest
    {
        readonly Faker faker;
        readonly double valueOrigin;
        readonly string currencyOrigin;
        readonly string currencyDestination;
        readonly string formatMsg;
        readonly string apiKey;

        public RateTest(ITestOutputHelper output)
        {

            faker = new Faker();

            valueOrigin = faker.Random.Double(1, 10000);
            currencyOrigin = "USD";
            currencyDestination = "BRL";
            formatMsg = faker.Random.Int(0,1).ToString();
            apiKey = faker.Random.Hash().ToString();

            output.WriteLine(formatMsg);
        }


        [Fact(DisplayName = "Deve criar uma taxa")]
        public void ShouldCreateRate()
        {

            Rate expectedRate = new Rate(
                valueOrigin,
                currencyOrigin,
                currencyDestination,
                formatMsg,
                apiKey
            );

            Rate rate = expectedRate;

            /*Assert.Equal(expectedRate.ValueOrigin, rate.ValueOrigin);
            Assert.Equal(expectedRate.CurrencyOrigin, rate.CurrencyOrigin);
            Assert.Equal(expectedRate.CurrencyDestination, rate.CurrencyDestination);
            Assert.Equal(expectedRate.FormatMsg, rate.FormatMsg);
            Assert.Equal(expectedRate.ApiKey, rate.ApiKey);*/

            expectedRate.ToExpectedObject().ShouldMatch(rate);
            
        }

        [Theory(DisplayName = "Não deve criar uma taxa com 'de' do tipo de Moeda nula ou vazia")]
        [InlineData("")]
        [InlineData(null)]
        public void RateCannotHaveEmptyOrNullCurrencyOrigin(string currencyOriginInvalid)
        {

            Assert.Throws<ArgumentException>(() =>
               RateBuilder.New().WithCurrencyOrigin(currencyOriginInvalid).Build()
            ).WithMessage("Invalid source currency");

        }

        [Theory(DisplayName = "Não deve criar uma taxa com 'para' do tipo de Moeda nula ou vazia")]
        [InlineData("")]
        [InlineData(null)]
        public void RateCannotHaveEmptyOrNullCurrencyDestination(string currencyDestinationInvalid)
        {

            Assert.Throws<ArgumentException>(() =>
               RateBuilder.New().WithCurrencyDestination(currencyDestinationInvalid).Build()
            ).WithMessage("Invalid destination currency");

        }

        [Theory(DisplayName = "Não deve criar uma taxa sem informar o formato da mensagem")]
        [InlineData("2")]
        [InlineData("-1")]
        public void RateCannotHaveFormatMessageInvalid(string formatMsgInvalid)
        {

            Assert.Throws<ArgumentException>(() =>
               RateBuilder.New().WithFormatMessage(formatMsgInvalid).Build()
            ).WithMessage("Invalid format message");

        }

        [Theory(DisplayName = "Não deve criar uma taxa sem informar a ApiKey")]
        [InlineData("")]
        [InlineData(null)]
        public void RateCannotHaveEmptyOrNullApiKey(string apiKeyInvalid)
        {

            Assert.Throws<ArgumentException>(() =>
               RateBuilder.New().WithApiKey(apiKeyInvalid).Build()
            ).WithMessage("Invalid ApiKey");

        }

        [Theory(DisplayName = "Não deve criar uma taxa sem informar a valor de origem")]
        [InlineData(0)]
        [InlineData(-2)]
        public void RateCannotHaveValueOriginInvalid(double valueOriginInvalid)
        {

            Assert.Throws<ArgumentException>(() =>
               RateBuilder.New().WithValueOrigin(valueOriginInvalid).Build()
            ).WithMessage("Invalid source value currency");

        }

    }


}
