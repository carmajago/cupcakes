using CupcakeYPasteles.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Net;
namespace CupcakeYPasteles.Controllers
{
    [Authorize]
    public class LogicaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Logica
        public ActionResult Ganancias()
        {

            ViewBag.total =String.Format("${0:#,0}", dineroAcomulado());         
         
            
            return View();
        }
        public int dineroAcomulado()
        {
            var query = "select * from dineroencajas where id=(select max(id) dinero from dineroencajas)";

            List<DineroEnCaja> lista = db.Database.SqlQuery<DineroEnCaja>(query).ToList();

            return lista.First().dinero;
        }


        public JsonResult getChar()
        {
            var query = "SELECT YEAR(fecha) ano,MONTH(fecha) mes,SUM(valor) valor from gastoes group by  MONTH(fecha),YEAR(fecha)";
            var query2 = "SELECT YEAR(fecha) ano,MONTH(fecha) mes,SUM(valor) valor from Ingresoes group by  MONTH(fecha),YEAR(fecha)  ";


            var gastos = db.Database.SqlQuery<VentasMes>(query).ToList();
            var ingresos = db.Database.SqlQuery<VentasMes>(query2).ToList();

            List<GraficaGanancias> lista=new List<GraficaGanancias>();

            DataTable datos = new DataTable();
            datos.Columns.Add(new DataColumn("Fecha", typeof(string)));
            datos.Columns.Add(new DataColumn("Ingresos", typeof(string)));
            datos.Columns.Add(new DataColumn("Gastos", typeof(string)));
            datos.Columns.Add(new DataColumn("Ganancias", typeof(string)));
            

            foreach (var item in gastos)
            {

                GraficaGanancias temp = new GraficaGanancias();
                temp.ano = item.ano.ToString();
                temp.mes = item.mes.ToString();
                temp.gasto = item.valor;
                temp.ingreso = 0;

                foreach (var item2 in ingresos)
                {
                    if (item.ano == item2.ano && item.mes == item2.mes)
                    {
                        temp.ingreso = item2.valor;
                    }
                }
                temp.ganancia = temp.ingreso - temp.gasto;
               
                datos.Rows.Add(new Object[] { "\""+temp.mes+"/"+temp.ano+ "\"", temp.ingreso, temp.gasto, temp.ganancia });
            }


            string strDatos = "[[\"Fecha\",\"Ingresos\",\"Gastos\",\"Ganancias\"],";
            
            foreach (DataRow dr in datos.Rows)
            {
                strDatos += "[";
                strDatos += "" +dr[0] + "," + dr[1] + "," + dr[2] + "," + dr[3];
                
                strDatos += "],";
            }
            strDatos = strDatos.Substring(0, strDatos.Length - 1);
            strDatos += "]";

            return new JsonResult { Data=strDatos ,JsonRequestBehavior=JsonRequestBehavior.AllowGet };


        }

        public JsonResult charGanancias()
        {
            DataTable datos = new DataTable();
            datos.Columns.Add(new DataColumn("Tareas", typeof(string)));
            datos.Columns.Add(new DataColumn("Horas por día", typeof(string)));

            
            var lista = db.Productoes.Include(xx=>xx.ingresos);
            string salida="[[\"Tareas\",\"Horas por dia\"],";


            foreach(var item in lista)
            {

                datos.Rows.Add(new Object[] { "\"" + item.nombre + "\"",item.cantidad});
            }

            foreach (DataRow dr in datos.Rows)
            {
                salida += "[";
                salida += "" + dr[0] + "," + dr[1];

                salida += "],";
            }



            salida = salida.Substring(0, salida.Length - 1);

            salida+="]";
            return new JsonResult { Data = salida, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}