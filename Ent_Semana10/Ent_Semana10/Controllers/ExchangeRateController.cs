using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ent_Semana10.Models;
using Ent_Semana10.Entities;
using System.Web.Mvc;

namespace Ent_Semana10.Controllers
{
    public class ExchangeRateController : Controller
    {
        ExchangeRateModel model = new ExchangeRateModel();

        [HttpGet]
        public ActionResult ConsultExchangeRates(float amount)
        {
            var result = model.GetEchangeRate(amount);

            return View(result);
        }
    }
}