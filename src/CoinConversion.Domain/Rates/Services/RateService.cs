using CoinConversion.Domain.Rates.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CoinConversion.Domain.Rates.Services
{
    public class RateService : IRateService
    {
        public object Calculate(Rate rate)
        {
            object response = string.Empty;
            try
            {
                Rate rateValues = GetRatesInstance(rate);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://apilayer.net/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //currencylayer only supports USD as the source/from currency
                HttpResponseMessage apiResponse = client.GetAsync(
                    "api/live?" + "access_key=" + rateValues.ApiKey + "&currencies=" + rateValues.CurrencyOrigin).Result;  // Blocking call 

                if (apiResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = apiResponse.Content.ReadAsStringAsync().Result;
                    var data = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                    response = data.Last.First.First.Last.Value<object>();
                }
            }
            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }

        public object Calculate(RateDto rateDto)
        {
            object response = string.Empty;
            try
            {
                Rate rateValues = GetRatesInstance(rateDto);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://free.currencyconverterapi.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //currencylayer only supports USD as the source/from currency
                HttpResponseMessage apiResponse = client.GetAsync("api/v5/convert?" + "q=" + rateValues.CurrencyOrigin + "_" + rateValues.CurrencyDestination).Result;  // Blocking call

                if (apiResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = apiResponse.Content.ReadAsStringAsync().Result;
                    var data = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                    response = data.Last.First.First.Last.SelectToken("val").Value<object>();
                }
            }
            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }

        public static Rate GetRatesInstance(Rate inputRates)
        {
            Rate resultRates = null;
            try
            {
                //Get query string values
                string apikey = inputRates.ApiKey;
                double valueOrigin = inputRates.ValueOrigin;
                //string provider = inputRates.Provider;
                string currency = inputRates.CurrencyOrigin;
                string symbol = inputRates.CurrencyDestination;
                string format = inputRates.FormatMsg;

                /*if (string.IsNullOrEmpty(provider))
                {
                    provider = "Fixer";
                }*/

                if (string.IsNullOrEmpty(currency))
                {
                    currency = "USD";
                }
                if (string.IsNullOrEmpty(symbol))
                {
                    symbol = "BRL";
                }
                if (string.IsNullOrEmpty(format))
                {
                    format = "text";
                }

                //provider = provider.Trim().ToUpper();
                currency = currency.Trim().ToUpper();
                symbol = symbol.Trim().ToUpper();
                format = format.Trim().ToUpper();

                resultRates = new Rate(valueOrigin, currency, symbol, format, apikey);
                /*resultRates.ApiKey = apikey;
                resultRates.Format = format;
                resultRates.Fr = currency;
                resultRates.To = symbol;
                resultRates.Format = format;
                resultRates.Provider = provider;*/
            }
            catch
            {
                resultRates = null;
            }

            return resultRates;
        }

        public static Rate GetRatesInstance(RateDto inputRates)
        {
            Rate resultRates = null;
            try
            {
                //Get query string values
                string apikey = inputRates.ApiKey;
                double valueOrigin = inputRates.ValueOrigin;
                //string provider = inputRates.Provider;
                string currency = inputRates.CurrencyOrigin;
                string symbol = inputRates.CurrencyDestination;
                string format = inputRates.FormatMsg;

                /*if (string.IsNullOrEmpty(provider))
                {
                    provider = "Fixer";
                }*/

                if (string.IsNullOrEmpty(currency))
                {
                    currency = "USD";
                }
                if (string.IsNullOrEmpty(symbol))
                {
                    symbol = "BRL";
                }
                if (string.IsNullOrEmpty(format))
                {
                    format = "text";
                }

                //provider = provider.Trim().ToUpper();
                currency = currency.Trim().ToUpper();
                symbol = symbol.Trim().ToUpper();
                format = format.Trim().ToUpper();

                resultRates = new Rate(valueOrigin, currency, symbol, format, apikey);
                /*resultRates.ApiKey = apikey;
                resultRates.Format = format;
                resultRates.Fr = currency;
                resultRates.To = symbol;
                resultRates.Format = format;
                resultRates.Provider = provider;*/
            }
            catch
            {
                resultRates = null;
            }

            return resultRates;
        }

        public List<Rate> GetAllRates()
        {
            throw new NotImplementedException();
        }
    }
}
