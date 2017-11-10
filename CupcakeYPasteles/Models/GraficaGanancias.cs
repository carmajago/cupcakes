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
        public double gasto { get; set; }
        public double ingreso { get; set; }
        public double ganancia { get; set; }
    }
}