﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CupcakeYPasteles.Models
{
    public class Gasto
    {

        [Key]
        public int id { get; set; }

        [ForeignKey("material")]
 
        public int materialFK { get; set; }

        [Display(Name ="Cantidad")]
        public int cantidad { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "$ {0:#,0}")]
        public int valor { get; set; }

       
        public virtual Material material { get; set; }

    }
}