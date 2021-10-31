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
    public class FACTURAsController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: FACTURAs
        public ActionResult Index()
        {
            var fACTURAs = db.FACTURAs.Include(f => f.CLIENTE).Include(f => f.TIPOPAGO);
            return View(fACTURAs.ToList());
        }

        // GET: FACTURAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // GET: FACTURAs/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre");
            ViewBag.IdTipoPago = new SelectList(db.TIPOPAGOes, "IdTipoPago", "TipoPago1");
            return View();
        }

        // POST: FACTURAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFactura,IdTipoPago,Fecha,Total,IdCliente")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.FACTURAs.Add(fACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre", fACTURA.IdCliente);
            ViewBag.IdTipoPago = new SelectList(db.TIPOPAGOes, "IdTipoPago", "TipoPago1", fACTURA.IdTipoPago);
            return View(fACTURA);
        }

        // GET: FACTURAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre", fACTURA.IdCliente);
            ViewBag.IdTipoPago = new SelectList(db.TIPOPAGOes, "IdTipoPago", "TipoPago1", fACTURA.IdTipoPago);
            return View(fACTURA);
        }

        // POST: FACTURAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFactura,IdTipoPago,Fecha,Total,IdCliente")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre", fACTURA.IdCliente);
            ViewBag.IdTipoPago = new SelectList(db.TIPOPAGOes, "IdTipoPago", "TipoPago1", fACTURA.IdTipoPago);
            return View(fACTURA);
        }

        // GET: FACTURAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // POST: FACTURAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACTURA fACTURA = db.FACTURAs.Find(id);
            db.FACTURAs.Remove(fACTURA);
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
