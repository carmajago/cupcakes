using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CupcakeYPasteles.Models;

namespace CupcakeYPasteles.Controllers
{
    [Authorize]
    public class IngresosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ingresos
        public ActionResult Index()
        {
            var gastoes = db.Ingresoes.Include(g => g.producto);
            return View(db.Ingresoes.ToList());
        }



        // GET: Ingresos/Create
        public ActionResult Create()
        {
            ViewBag.productofk = new SelectList(db.Productoes, "id", "nombre");

            return View();
        }

        // POST: Ingresos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                int dinero = dineroAcomulado();
                DineroEnCaja caja = new DineroEnCaja();
                caja.fecha = DateTime.Now;
                caja.dinero = dinero + ingreso.valor;
                db.DineroEnCajas.Add(caja);

                ingreso.fecha = DateTime.Now;

                db.Ingresoes.Add(ingreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productofk = new SelectList(db.Productoes, "id", "nombre", ingreso.productofk);
            return View(ingreso);
        }

       

   

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingreso ingreso = db.Ingresoes.Find(id);
            if (ingreso == null)
            {
                return HttpNotFound();
            }
            return View(ingreso);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingreso ingreso = db.Ingresoes.Find(id);

            int dinero = dineroAcomulado();
            DineroEnCaja caja = new DineroEnCaja();
            caja.fecha = DateTime.Now;
            caja.dinero = dinero - ingreso.valor;
            db.DineroEnCajas.Add(caja);

            
            db.Ingresoes.Remove(ingreso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public int dineroAcomulado()
        {
            var query = "select * from dineroencajas where id=(select max(id) dinero from dineroencajas)";
            
            List<DineroEnCaja> lista = db.Database.SqlQuery<DineroEnCaja>(query).ToList();

            return lista.First().dinero;
        }

    }
}
