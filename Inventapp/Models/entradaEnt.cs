using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventapp.Models
{
    public class entradaEnt
    {
        
        public int producto { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string productoN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public int cantidad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public int lote { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string ffabricacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")] 
        public string fvencimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")] 
        public string fingreso { get; set; }           

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")] 
        public string proveedor { get; set; }
        
    }
}