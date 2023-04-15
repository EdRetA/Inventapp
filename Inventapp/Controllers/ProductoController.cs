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
        // GET: Producto
        public ActionResult ProductoNuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductoNuevo(ProductoEnt productoD)

        {

            if (ModelState.IsValid)
            {
                ProductoDAL entdb = new ProductoDAL();
                string resp = entdb.AgregarProducto(productoD);

                //ViewBag.Mensaje = resp;
                ViewBag.Estado = 5;
                //PopulateDropDownList();
                return View("Load", "Entrada");

            }
            else
            {               
                
                return View("ProductoNuevo");
            }
        }

    }
}