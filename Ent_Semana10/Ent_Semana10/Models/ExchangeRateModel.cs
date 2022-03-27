using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Ent_Semana10.Entities;



namespace Ent_Semana10.Models
{
    public class ExchangeRateModel
    {
        public ExchangeRateOutput GetEchangeRate(float amountColones)
        {
            ExchangeRateOutput exchangeRateOutput = new ExchangeRateOutput();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.hacienda.go.cr/");

                var responseTask = client.GetAsync("indicadores/tc/dolar");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ExchangeRateInput>();
                    readTask.Wait();

                    var exhangeRateInput = readTask.Result;

                    var sale = Transform(amountColones, exhangeRateInput.Sale.Value);
                    exchangeRateOutput.Sale = sale;

                    var Purchase = Transform(amountColones, exhangeRateInput.Purchase.Value);
                    exchangeRateOutput.Purchase = Purchase;
                }
            }

            return exchangeRateOutput;
        }

        public float Transform(float amountColones, float amountDolars)
        {
            return amountColones / amountDolars;
        }
    }
}