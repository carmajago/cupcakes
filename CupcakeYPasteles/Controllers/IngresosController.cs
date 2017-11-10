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
            return View(db.Ingresoes.ToList());
        }

        // GET: Ingresos/Details/5
        public ActionResult Details(int? id)
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

        // GET: Ingresos/Create
        public ActionResult Create()
        {
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
                double dinero = dineroAcomulado();
                DineroEnCaja caja = new DineroEnCaja();
                caja.fecha = DateTime.Now;
                caja.dinero = dinero + ingreso.valor;
                db.DineroEnCajas.Add(caja);

                ingreso.fecha = DateTime.Now;

                db.Ingresoes.Add(ingreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingreso);
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Ingresos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,fecha,valor")] Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                
                
                db.Entry(ingreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingreso);
        }

        // GET: Ingresos/Delete/5
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

        public double dineroAcomulado()
        {
            var query = "select * from dineroencajas where id=(select max(id) dinero from dineroencajas)";
            
            List<DineroEnCaja> lista = db.Database.SqlQuery<DineroEnCaja>(query).ToList();

            return lista.First().dinero;
        }

    }
}
