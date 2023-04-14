using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventapp.Models
{
    public class Inventario
    {
        public int producto { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string productoN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public int cantidad { get; set; }
    }
}