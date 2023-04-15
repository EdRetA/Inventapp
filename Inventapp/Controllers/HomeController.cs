using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventapp.Controllers
{
    public class HomeController : Controller
    {
        // GET:
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "INVENTAPP";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "CONTACTOS";

            return View();
        }
        
    }
}