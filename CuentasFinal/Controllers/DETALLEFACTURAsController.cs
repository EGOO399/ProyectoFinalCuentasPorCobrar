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
    public class DETALLEFACTURAsController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: DETALLEFACTURAs
        public ActionResult Index()
        {
            var dETALLEFACTURAs = db.DETALLEFACTURAs.Include(d => d.FACTURA).Include(d => d.PRODUCTO);
            return View(dETALLEFACTURAs.ToList());
        }

        // GET: DETALLEFACTURAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEFACTURA dETALLEFACTURA = db.DETALLEFACTURAs.Find(id);
            if (dETALLEFACTURA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEFACTURA);
        }

        // GET: DETALLEFACTURAs/Create
        public ActionResult Create()
        {
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura");
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre");
            return View();
        }

        // POST: DETALLEFACTURAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalle,IdFactura,IdProducto,CantidadProducto")] DETALLEFACTURA dETALLEFACTURA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLEFACTURAs.Add(dETALLEFACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", dETALLEFACTURA.IdFactura);
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLEFACTURA.IdProducto);
            return View(dETALLEFACTURA);
        }

        // GET: DETALLEFACTURAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEFACTURA dETALLEFACTURA = db.DETALLEFACTURAs.Find(id);
            if (dETALLEFACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", dETALLEFACTURA.IdFactura);
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLEFACTURA.IdProducto);
            return View(dETALLEFACTURA);
        }

        // POST: DETALLEFACTURAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalle,IdFactura,IdProducto,CantidadProducto")] DETALLEFACTURA dETALLEFACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLEFACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFactura = new SelectList(db.FACTURAs, "IdFactura", "IdFactura", dETALLEFACTURA.IdFactura);
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLEFACTURA.IdProducto);
            return View(dETALLEFACTURA);
        }

        // GET: DETALLEFACTURAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEFACTURA dETALLEFACTURA = db.DETALLEFACTURAs.Find(id);
            if (dETALLEFACTURA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEFACTURA);
        }

        // POST: DETALLEFACTURAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLEFACTURA dETALLEFACTURA = db.DETALLEFACTURAs.Find(id);
            db.DETALLEFACTURAs.Remove(dETALLEFACTURA);
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
