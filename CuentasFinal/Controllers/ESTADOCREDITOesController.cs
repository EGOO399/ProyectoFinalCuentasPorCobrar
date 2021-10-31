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
    public class ESTADOCREDITOesController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: ESTADOCREDITOes
        public ActionResult Index()
        {
            return View(db.ESTADOCREDITOes.ToList());
        }

        // GET: ESTADOCREDITOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCREDITO eSTADOCREDITO = db.ESTADOCREDITOes.Find(id);
            if (eSTADOCREDITO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCREDITO);
        }

        // GET: ESTADOCREDITOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADOCREDITOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstado,Estado")] ESTADOCREDITO eSTADOCREDITO)
        {
            if (ModelState.IsValid)
            {
                db.ESTADOCREDITOes.Add(eSTADOCREDITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADOCREDITO);
        }

        // GET: ESTADOCREDITOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCREDITO eSTADOCREDITO = db.ESTADOCREDITOes.Find(id);
            if (eSTADOCREDITO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCREDITO);
        }

        // POST: ESTADOCREDITOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstado,Estado")] ESTADOCREDITO eSTADOCREDITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADOCREDITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADOCREDITO);
        }

        // GET: ESTADOCREDITOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOCREDITO eSTADOCREDITO = db.ESTADOCREDITOes.Find(id);
            if (eSTADOCREDITO == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOCREDITO);
        }

        // POST: ESTADOCREDITOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADOCREDITO eSTADOCREDITO = db.ESTADOCREDITOes.Find(id);
            db.ESTADOCREDITOes.Remove(eSTADOCREDITO);
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
