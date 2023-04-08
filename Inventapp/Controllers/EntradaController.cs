using System.Collections.Generic;
using System.Web.Mvc;
using Inventapp.Models;



namespace Inventapp.Controllers
{
    public class EntradaController : Controller
    {
        // GET: entrada
        
        public ActionResult Load()
        {
            PopulateDropDownList();
            return View();
        }

        [HttpPost]
        public ActionResult Load(entradaEnt entradaD)
        
        {
            entradaDAL entdb = new entradaDAL();
            string resp = entdb.AgregarEntrada(entradaD);

            ViewBag.Mensaje = resp;
            return View("Load");
        }

        private void PopulateDropDownList()
        {
            entradaDAL entdb = new entradaDAL();
            List<string> items = entdb.BuscarProductos();
            ViewBag.Items = items;
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