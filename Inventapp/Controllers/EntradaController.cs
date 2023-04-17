using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Inventapp.Models;



namespace Inventapp.Controllers
{
    public class EntradaController : Controller
    {
        // GET:
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            return View();
        }
        
        public ActionResult BuscarEntrada()
        {
            return View();
        }

        public ActionResult Comprobar()
        {
            CargaFaltantes();
            return View();
        }

        public ActionResult Actualizar()

        {
            CargarEntrada();
            //   Actualizar2(entradaD);
            return View(ViewBag.Items[0]);
            
        }


        public ActionResult Load()
        {
            PopulateDropDownList();
            return View();
        }
        public ActionResult ListEntradas()
        {
            return View();
        }

        // POST:
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
                    ViewBag.Estado = 1;                    
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

        [HttpPost]
        public ActionResult ListEntradas(entradaEnt entradaD)
        {
            entradaDAL entdb = new entradaDAL();
            List<entradaEnt> items = entdb.BuscarEntrada(entradaD);
            ViewBag.entradas = items;
            return View();
        }

        [HttpPost]
        public ActionResult BuscarEntrada(entradaEnt entradaD)
        {
            entradaDAL entdb = new entradaDAL();
            List<entradaEnt> items = entdb.BuscarEntrada(entradaD);
            ViewBag.entradas = items;
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(entradaEnt entradaD)
        {
            {
                if (ModelState.IsValid)
                {
                    DateTime vencimiento = Convert.ToDateTime(entradaD.fvencimiento);
                    if (vencimiento > DateTime.Today)
                    {
                        entradaDAL entdb = new entradaDAL();
                        string resp = entdb.ActualizarEntrada(entradaD);
                        ViewBag.Estado = 2;
                        return View("Index");
                    }
                    else
                    {
                        PopulateDropDownList();
                        ViewBag.Estado = 2;
                        return View("Actualizar");
                    }
                }
                else
                {
                    PopulateDropDownList();
                    ViewBag.Estado = 0;
                    return View("Actualizar");
                }
            }
        }





        private void CargarEntrada()
        {
            entradaEnt entradaD = new entradaEnt();
            string producto= Request.QueryString["producto"];
            string cantidad= Request.QueryString["cantidad"];
            string lote = Request.QueryString["lote"];
            entradaD.producto = Convert.ToInt32(producto);
            entradaD.productoN = Request.QueryString["productoN"];
            entradaD.cantidad= Convert.ToInt32(cantidad);
            entradaD.lote= Convert.ToInt32(lote);
            entradaD.ffabricacion= Request.QueryString["ffabricacion"];
            entradaD.fvencimiento = Request.QueryString["fvencimiento"];
            entradaD.fingreso = Request.QueryString["fingreso"];
            entradaD.proveedor = Request.QueryString["proveedor"];

            List<entradaEnt> items = new List<entradaEnt>();
            items.Add(entradaD);
            ViewBag.Items = items;
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

        
    }
}