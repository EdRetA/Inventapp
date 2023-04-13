using Inventapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventapp.Controllers
{
    public class PruebaController : Controller
    {
        // GET: Prueba
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(entradaEnt producto)
        {
            if (ModelState.IsValid)
            {
                entradaDAL con = new entradaDAL();
                con.AgregarEntrada(producto);
                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }
        }
    }
}