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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha { get; set; }

        [Display(Name ="Dinero total")]
        public double dinero { get; set; }

    }
}