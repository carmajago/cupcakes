using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CupcakeYPasteles.Models
{
    public class Ingreso
    {
        [Key]
        public int id { get; set; }


        [Display(Name ="Nombre")]
        [ForeignKey("producto")]
        public int productofk { get; set; }


        [Display(Name ="Descripción")]
        public string descripcion { get; set; }

        [Display(Name ="Fecha")]
        public DateTime fecha { get; set; }

        [Display(Name ="Valor")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "$ {0:#,0}")]
        public double valor { get; set; }


        [Display(Name = "Nombre")]
        public Producto producto { get; set; }


    }
}