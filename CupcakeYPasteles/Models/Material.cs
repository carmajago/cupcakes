using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CupcakeYPasteles.Models
{
    public class Material
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Nombre")]
        [Required]
        public string nombre { get; set; }



        
        public virtual List<Gasto> gastos { get; set; }

    }
}