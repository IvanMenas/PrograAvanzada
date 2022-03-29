using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ent_Semana10.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ConsultarTipoCambio()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
