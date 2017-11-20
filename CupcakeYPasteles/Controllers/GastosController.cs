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
    public class GastosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gastos
        public ActionResult Index()
        {
            var gastoes = db.Gastoes.Include(g => g.material);
            return View(gastoes.ToList());
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gastoes.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            return View(gasto);
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            ViewBag.materialFK = new SelectList(db.Materials, "id", "nombre");
            return View();
        }

        // POST: Gastos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gasto gasto)
        {
            if (ModelState.IsValid)
            {

                double dinero = dineroAcomulado();
                DineroEnCaja caja = new DineroEnCaja();
                caja.fecha = DateTime.Now;
                caja.dinero = dinero - gasto.valor;
                db.DineroEnCajas.Add(caja);


                gasto.fecha = DateTime.Now;

                db.Gastoes.Add(gasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.materialFK = new SelectList(db.Materials, "id", "nombre", gasto.materialFK);
            return View(gasto);
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gastoes.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            ViewBag.materialFK = new SelectList(db.Materials, "id", "nombre", gasto.materialFK);
            return View(gasto);
        }

        // POST: Gastos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,materialFK,cantidad,descripcion,fecha,valor")] Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.materialFK = new SelectList(db.Materials, "id", "nombre", gasto.materialFK);
            return View(gasto);
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gasto gasto = db.Gastoes.Find(id);
            if (gasto == null)
            {
                return HttpNotFound();
            }
            return View(gasto);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gasto gasto = db.Gastoes.Find(id);

            double dinero = dineroAcomulado();
            DineroEnCaja caja = new DineroEnCaja();
            caja.fecha = DateTime.Now;
            caja.dinero = dinero + gasto.valor;
            db.DineroEnCajas.Add(caja);
            db.Gastoes.Remove(gasto);
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
