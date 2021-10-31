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
    public class MONTOCREDITOesController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: MONTOCREDITOes
        public ActionResult Index()
        {
            var mONTOCREDITOes = db.MONTOCREDITOes.Include(m => m.CREDITO);
            return View(mONTOCREDITOes.ToList());
        }

        // GET: MONTOCREDITOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONTOCREDITO mONTOCREDITO = db.MONTOCREDITOes.Find(id);
            if (mONTOCREDITO == null)
            {
                return HttpNotFound();
            }
            return View(mONTOCREDITO);
        }

        // GET: MONTOCREDITOes/Create
        public ActionResult Create()
        {
            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle");
            return View();
        }

        // POST: MONTOCREDITOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMonto,Monto,IdCredito")] MONTOCREDITO mONTOCREDITO)
        {
            if (ModelState.IsValid)
            {
                db.MONTOCREDITOes.Add(mONTOCREDITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle", mONTOCREDITO.IdCredito);
            return View(mONTOCREDITO);
        }

        // GET: MONTOCREDITOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONTOCREDITO mONTOCREDITO = db.MONTOCREDITOes.Find(id);
            if (mONTOCREDITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle", mONTOCREDITO.IdCredito);
            return View(mONTOCREDITO);
        }

        // POST: MONTOCREDITOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMonto,Monto,IdCredito")] MONTOCREDITO mONTOCREDITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mONTOCREDITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCredito = new SelectList(db.CREDITOes, "IdCredito", "Detalle", mONTOCREDITO.IdCredito);
            return View(mONTOCREDITO);
        }

        // GET: MONTOCREDITOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONTOCREDITO mONTOCREDITO = db.MONTOCREDITOes.Find(id);
            if (mONTOCREDITO == null)
            {
                return HttpNotFound();
            }
            return View(mONTOCREDITO);
        }

        // POST: MONTOCREDITOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MONTOCREDITO mONTOCREDITO = db.MONTOCREDITOes.Find(id);
            db.MONTOCREDITOes.Remove(mONTOCREDITO);
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
