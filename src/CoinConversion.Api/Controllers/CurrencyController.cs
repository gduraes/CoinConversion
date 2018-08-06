using CoinConversion.Domain.Rates.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoinConversion.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    public class CurrencyController : Controller
    {
        
        private readonly RateService rateService;

        public CurrencyController()
        {
            rateService = new RateService();
        }

        public IActionResult GetAllCurrencies()
        {
            return View();
        }

        [HttpPost]
        [Route("api/calculaterates")]
        public object PostCalculateRates([FromBody] RateDto rate)
        {
            object response = string.Empty;
            try
            {
                response = rateService.Calculate(rate);
            }
            catch (Exception ex)
            {
                response = ex.ToString();
            }

            return response;
            
        }

    }
}