using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CupcakeYPasteles.Models
{
    public class DineroEnCaja
    {
        [Key]
        public int id { get; set; }


        [Display(Name ="Fecha")]
        
        public DateTime fecha { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "$ {0:#,0}")]
        [Display(Name ="Dinero total")]
        public int dinero { get; set; }

    }
}