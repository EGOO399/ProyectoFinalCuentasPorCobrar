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
    public class CREDITOesController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: CREDITOes
        public ActionResult Index()
        {
            var cREDITOes = db.CREDITOes.Include(c => c.CLIENTE).Include(c => c.ESTADOCREDITO);
            return View(cREDITOes.ToList());
        }

        // GET: CREDITOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CREDITO cREDITO = db.CREDITOes.Find(id);
            if (cREDITO == null)
            {
                return HttpNotFound();
            }
            return View(cREDITO);
        }

        // GET: CREDITOes/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre");
            ViewBag.IdEstado = new SelectList(db.ESTADOCREDITOes, "IdEstado", "Estado");
            return View();
        }

        // POST: CREDITOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCredito,IdEstado,Detalle,Fecha,IdCliente")] CREDITO cREDITO)
        {
            if (ModelState.IsValid)
            {
                db.CREDITOes.Add(cREDITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre", cREDITO.IdCliente);
            ViewBag.IdEstado = new SelectList(db.ESTADOCREDITOes, "IdEstado", "Estado", cREDITO.IdEstado);
            return View(cREDITO);
        }

        // GET: CREDITOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CREDITO cREDITO = db.CREDITOes.Find(id);
            if (cREDITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre", cREDITO.IdCliente);
            ViewBag.IdEstado = new SelectList(db.ESTADOCREDITOes, "IdEstado", "Estado", cREDITO.IdEstado);
            return View(cREDITO);
        }

        // POST: CREDITOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCredito,IdEstado,Detalle,Fecha,IdCliente")] CREDITO cREDITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cREDITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.CLIENTEs, "IdCliente", "Nombre", cREDITO.IdCliente);
            ViewBag.IdEstado = new SelectList(db.ESTADOCREDITOes, "IdEstado", "Estado", cREDITO.IdEstado);
            return View(cREDITO);
        }

        // GET: CREDITOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CREDITO cREDITO = db.CREDITOes.Find(id);
            if (cREDITO == null)
            {
                return HttpNotFound();
            }
            return View(cREDITO);
        }

        // POST: CREDITOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CREDITO cREDITO = db.CREDITOes.Find(id);
            db.CREDITOes.Remove(cREDITO);
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
