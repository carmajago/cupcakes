using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CupcakeYPasteles.Models
{
    public class Producto
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Nombre")]
        [Required]
        public string nombre { get; set; }



        public virtual List<Ingreso> ingresos { get; set; }
        
    }
}