using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ent_Semana10.Entities
{
    public class ExchangeRateInput
    {
        [JsonProperty("venta")]
        public Data Sale { get; set; }
        [JsonProperty("compra")]
        public Data Purchase { get; set; }
    }

    public class Data
    {
        [JsonProperty("fecha")]
        public string Date { get; set; }
        [JsonProperty("valor")]
        public float Value { get; set; }
    }

    public class ExchangeRateOutput
    {
        public float Sale { get; set; }
        public float SaleTransformed { get; set; }
        public float Purchase { get; set; }
        public float PurchaseTransformed { get; set; }

    }
}