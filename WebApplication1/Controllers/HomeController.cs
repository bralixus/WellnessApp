using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AboutMassages()
        {
            ViewBag.Message = "Zapoznaj się z naszą ofertą masaży";

            return View();
        }
        public ActionResult AboutSauna()
        {
            ViewBag.Message = "Poznaj nasz świat saun";

            return View();
        }
        public ActionResult Sauna()
        {
            return View();
        }
        public ActionResult Pool()
        {
            return View();
        }


    }
}