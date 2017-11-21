using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CupcakeYPasteles.Models
{
    public class GraficaGanancias
    {
        public string ano { get; set; }
        public string mes { get; set; }
        public int gasto { get; set; }
        public int ingreso { get; set; }
        public int ganancia { get; set; }
    }
}