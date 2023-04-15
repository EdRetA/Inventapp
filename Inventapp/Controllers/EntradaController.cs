using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Inventapp.Models;



namespace Inventapp.Controllers
{
    public class EntradaController : Controller
    {
        // GET: Prueba
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Comprobar()
        {
            CargaFaltantes();
            return View();
        }       

        public ActionResult Load()
        {
            PopulateDropDownList();
            return View();
        }

        

        [HttpPost]
        public ActionResult Agregar(entradaEnt entradaD)

        {

            if (ModelState.IsValid)
            {

                DateTime vencimiento = Convert.ToDateTime(entradaD.fvencimiento);
                if (vencimiento > DateTime.Today)
                {
                    entradaDAL entdb = new entradaDAL();
                    string resp = entdb.AgregarEntrada(entradaD);

                    //ViewBag.Mensaje = resp;
                    ViewBag.Estado = 1;
                    //PopulateDropDownList();
                    return View("Index");
                }
                else
                {
                    PopulateDropDownList();
                    ViewBag.Estado = 2;
                    return View("Load");
                }


            }
            else
            {
                PopulateDropDownList();
                ViewBag.Estado = 0;
                return View("Load");
            }
        }

        private void PopulateDropDownList()
        {
            entradaDAL entdb = new entradaDAL();
            List<string> items = entdb.BuscarProductos();
            ViewBag.Items = items;
        }

        private void CargaFaltantes()
        {
            entradaDAL entdb = new entradaDAL();
            List<Inventario> items = entdb.CargarFaltante();
          


           
          
           ViewBag.inventario = items;
                        
        }






        //public ActionResult Buscar()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Buscar(entradaEnt entradaD)
        //{
        //    entradaDAL entdb = new entradaDAL();
        //    DataTable resp = entdb.BuscarEntrada(entradaD);
        //    if (resp.Rows.Count > 0)
        //    {
        //        return View();
        //    }
        //    return View();
        //}
    }
}