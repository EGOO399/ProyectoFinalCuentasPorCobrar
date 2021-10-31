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
    public class RECIBOCAJAsController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: RECIBOCAJAs
        public ActionResult Index()
        {
            var rECIBOCAJAs = db.RECIBOCAJAs.Include(r => r.ABONO);
            return View(rECIBOCAJAs.ToList());
        }

        // GET: RECIBOCAJAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECIBOCAJA rECIBOCAJA = db.RECIBOCAJAs.Find(id);
            if (rECIBOCAJA == null)
            {
                return HttpNotFound();
            }
            return View(rECIBOCAJA);
        }

        // GET: RECIBOCAJAs/Create
        public ActionResult Create()
        {
            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono");
            return View();
        }

        // POST: RECIBOCAJAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRecibo,Monto,Fecha,IdAbono")] RECIBOCAJA rECIBOCAJA)
        {
            if (ModelState.IsValid)
            {
                db.RECIBOCAJAs.Add(rECIBOCAJA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono", rECIBOCAJA.IdAbono);
            return View(rECIBOCAJA);
        }

        // GET: RECIBOCAJAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECIBOCAJA rECIBOCAJA = db.RECIBOCAJAs.Find(id);
            if (rECIBOCAJA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono", rECIBOCAJA.IdAbono);
            return View(rECIBOCAJA);
        }

        // POST: RECIBOCAJAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRecibo,Monto,Fecha,IdAbono")] RECIBOCAJA rECIBOCAJA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECIBOCAJA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono", rECIBOCAJA.IdAbono);
            return View(rECIBOCAJA);
        }

        // GET: RECIBOCAJAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECIBOCAJA rECIBOCAJA = db.RECIBOCAJAs.Find(id);
            if (rECIBOCAJA == null)
            {
                return HttpNotFound();
            }
            return View(rECIBOCAJA);
        }

        // POST: RECIBOCAJAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECIBOCAJA rECIBOCAJA = db.RECIBOCAJAs.Find(id);
            db.RECIBOCAJAs.Remove(rECIBOCAJA);
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
