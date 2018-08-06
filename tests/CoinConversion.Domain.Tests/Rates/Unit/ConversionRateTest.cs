using Bogus;
using CoinConversion.Domain.Rates.Models;
using CoinConversion.Domain.Rates.Services;
using Moq;
using Xunit;

namespace CoinConversion.Domain.Tests.Rates.Unit
{
    public class ConversionRateTest
    {
        private RateDto rateDto;
        private Mock<IRateService> rateServiceMock;
        private ConversionRate conversionRate;

        public ConversionRateTest()
        {
            var faker = new Faker();

            rateDto = new RateDto
            {
                ValueOrigin = faker.Random.Double(1, 10000),
                CurrencyOrigin = "USD",
                CurrencyDestination = "BRL",
                FormatMsg = faker.Random.Int(0, 1).ToString(),
                ApiKey = faker.Random.Hash().ToString()
            };

            rateServiceMock = new Mock<IRateService>();
            conversionRate = new ConversionRate(rateServiceMock.Object);
        }

        [Fact]
        public void MustDoRateConversion()
        {            
            conversionRate.CalculateRate(rateDto);

            rateServiceMock.Verify(
                r => r.Calculate(
                    It.Is<Rate>(
                        rt => rt.ValueOrigin == rateDto.ValueOrigin &&
                        rt.CurrencyOrigin == rateDto.CurrencyOrigin &&
                        rt.CurrencyDestination == rateDto.CurrencyDestination &&
                        rt.FormatMsg == rateDto.FormatMsg &&
                        rt.CurrencyDestination == rateDto.CurrencyDestination
                    )
                )
            );
           
        }

    }

   




}
