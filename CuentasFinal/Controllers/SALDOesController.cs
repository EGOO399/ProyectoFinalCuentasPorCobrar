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
    public class SALDOesController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: SALDOes
        public ActionResult Index()
        {
            var sALDOes = db.SALDOes.Include(s => s.ABONO).Include(s => s.FACTURA).Include(s => s.MONTOCREDITO);
            return View(sALDOes.ToList());
        }

        // GET: SALDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALDO sALDO = db.SALDOes.Find(id);
            if (sALDO == null)
            {
                return HttpNotFound();
            }
            return View(sALDO);
        }

        // GET: SALDOes/Create
        public ActionResult Create()
        {
            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono");
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura");
            ViewBag.IdMonto = new SelectList(db.MONTOCREDITOes, "IdMonto", "IdMonto");
            return View();
        }

        // POST: SALDOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSaldo,Monto,IdMonto,IdFactura,IdAbono")] SALDO sALDO)
        {
            if (ModelState.IsValid)
            {
                db.SALDOes.Add(sALDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono", sALDO.IdAbono);
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", sALDO.IdFactura);
            ViewBag.IdMonto = new SelectList(db.MONTOCREDITOes, "IdMonto", "IdMonto", sALDO.IdMonto);
            return View(sALDO);
        }

        // GET: SALDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALDO sALDO = db.SALDOes.Find(id);
            if (sALDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono", sALDO.IdAbono);
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", sALDO.IdFactura);
            ViewBag.IdMonto = new SelectList(db.MONTOCREDITOes, "IdMonto", "IdMonto", sALDO.IdMonto);
            return View(sALDO);
        }

        // POST: SALDOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSaldo,Monto,IdMonto,IdFactura,IdAbono")] SALDO sALDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAbono = new SelectList(db.ABONOes, "IdAbono", "IdAbono", sALDO.IdAbono);
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", sALDO.IdFactura);
            ViewBag.IdMonto = new SelectList(db.MONTOCREDITOes, "IdMonto", "IdMonto", sALDO.IdMonto);
            return View(sALDO);
        }

        // GET: SALDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALDO sALDO = db.SALDOes.Find(id);
            if (sALDO == null)
            {
                return HttpNotFound();
            }
            return View(sALDO);
        }

        // POST: SALDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALDO sALDO = db.SALDOes.Find(id);
            db.SALDOes.Remove(sALDO);
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
