using Inventapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventapp.Controllers
{
    public class ProductoController : Controller
    {
        // GET:
        public ActionResult ProductoNuevo()
        {
            return View();
        }

        // POST:
        [HttpPost]
        public ActionResult ProductoNuevo(ProductoEnt productoD)
        {
            if (ModelState.IsValid)
            {
                ProductoDAL entdb = new ProductoDAL();
                string resp = entdb.AgregarProducto(productoD);                
                ViewBag.Estado = 1;                
                return View();
            }
            else
            {                               
                return View("ProductoNuevo");
            }
        }
    }
}