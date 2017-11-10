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
    public class DineroEnCajaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DineroEnCaja
        public ActionResult Index()
        {
            return View(db.DineroEnCajas.ToList());
        }

        // GET: DineroEnCaja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DineroEnCaja dineroEnCaja = db.DineroEnCajas.Find(id);
            if (dineroEnCaja == null)
            {
                return HttpNotFound();
            }
            return View(dineroEnCaja);
        }

        // GET: DineroEnCaja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DineroEnCaja/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,dinero")] DineroEnCaja dineroEnCaja)
        {
            if (ModelState.IsValid)
            {
                dineroEnCaja.fecha = DateTime.Now;
                db.DineroEnCajas.Add(dineroEnCaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dineroEnCaja);
        }

        // GET: DineroEnCaja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DineroEnCaja dineroEnCaja = db.DineroEnCajas.Find(id);
            if (dineroEnCaja == null)
            {
                return HttpNotFound();
            }
            return View(dineroEnCaja);
        }

        // POST: DineroEnCaja/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,dinero")] DineroEnCaja dineroEnCaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dineroEnCaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dineroEnCaja);
        }

        // GET: DineroEnCaja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DineroEnCaja dineroEnCaja = db.DineroEnCajas.Find(id);
            if (dineroEnCaja == null)
            {
                return HttpNotFound();
            }
            return View(dineroEnCaja);
        }

        // POST: DineroEnCaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DineroEnCaja dineroEnCaja = db.DineroEnCajas.Find(id);
            db.DineroEnCajas.Remove(dineroEnCaja);
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


    }
}
