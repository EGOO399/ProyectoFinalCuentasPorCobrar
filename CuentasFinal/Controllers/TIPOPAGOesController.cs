using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuentasFinal.Models;

namespace CuentasFinal.Controllers
{
    public class TIPOPAGOesController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: TIPOPAGOes
        public ActionResult Index()
        {
            return View(db.TIPOPAGOes.ToList());
        }

        // GET: TIPOPAGOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOPAGO tIPOPAGO = db.TIPOPAGOes.Find(id);
            if (tIPOPAGO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOPAGO);
        }

        // GET: TIPOPAGOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOPAGOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPago,TipoPago1")] TIPOPAGO tIPOPAGO)
        {
            if (ModelState.IsValid)
            {
                db.TIPOPAGOes.Add(tIPOPAGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOPAGO);
        }

        // GET: TIPOPAGOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOPAGO tIPOPAGO = db.TIPOPAGOes.Find(id);
            if (tIPOPAGO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOPAGO);
        }

        // POST: TIPOPAGOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPago,TipoPago1")] TIPOPAGO tIPOPAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOPAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOPAGO);
        }

        // GET: TIPOPAGOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOPAGO tIPOPAGO = db.TIPOPAGOes.Find(id);
            if (tIPOPAGO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOPAGO);
        }

        // POST: TIPOPAGOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOPAGO tIPOPAGO = db.TIPOPAGOes.Find(id);
            db.TIPOPAGOes.Remove(tIPOPAGO);
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
