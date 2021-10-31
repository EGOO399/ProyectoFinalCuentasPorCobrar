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
    public class ABONOesController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: ABONOes
        public ActionResult Index()
        {
            var aBONOes = db.ABONOes.Include(a => a.CREDITO).Include(a => a.FACTURA);
            return View(aBONOes.ToList());
        }

        // GET: ABONOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABONO aBONO = db.ABONOes.Find(id);
            if (aBONO == null)
            {
                return HttpNotFound();
            }
            return View(aBONO);
        }

        // GET: ABONOes/Create
        public ActionResult Create()
        {
            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle");
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura");
            return View();
        }

        // POST: ABONOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAbono,Monto,Fecha,IdCredito,IdFactura")] ABONO aBONO)
        {
            if (ModelState.IsValid)
            {
                db.ABONOes.Add(aBONO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle", aBONO.IdCredito);
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", aBONO.IdFactura);
            return View(aBONO);
        }

        // GET: ABONOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABONO aBONO = db.ABONOes.Find(id);
            if (aBONO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle", aBONO.IdCredito);
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", aBONO.IdFactura);
            return View(aBONO);
        }

        // POST: ABONOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAbono,Monto,Fecha,IdCredito,IdFactura")] ABONO aBONO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aBONO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle", aBONO.IdCredito);
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", aBONO.IdFactura);
            return View(aBONO);
        }

        // GET: ABONOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABONO aBONO = db.ABONOes.Find(id);
            if (aBONO == null)
            {
                return HttpNotFound();
            }
            return View(aBONO);
        }

        // POST: ABONOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ABONO aBONO = db.ABONOes.Find(id);
            db.ABONOes.Remove(aBONO);
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
