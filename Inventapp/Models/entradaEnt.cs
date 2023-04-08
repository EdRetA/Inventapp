using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventapp.Models
{
    public class entradaEnt
    {
        public int producto { get; set; }
        public string productoN { get; set; }
        public int lote { get; set; }
        public string ffabricacion { get; set; }
        public string fvencimiento { get; set; }
        public string fingreso { get; set; }
        public int cantidad { get; set; }
        public string proveedor { get; set; }
        
    }
}