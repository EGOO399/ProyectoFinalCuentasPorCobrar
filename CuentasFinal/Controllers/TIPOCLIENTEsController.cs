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
    public class TIPOCLIENTEsController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: TIPOCLIENTEs
        public ActionResult Index()
        {
            return View(db.TIPOCLIENTEs.ToList());
        }

        // GET: TIPOCLIENTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCLIENTE tIPOCLIENTE = db.TIPOCLIENTEs.Find(id);
            if (tIPOCLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCLIENTE);
        }

        // GET: TIPOCLIENTEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOCLIENTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoCliente,TipoCliente1")] TIPOCLIENTE tIPOCLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.TIPOCLIENTEs.Add(tIPOCLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOCLIENTE);
        }

        // GET: TIPOCLIENTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCLIENTE tIPOCLIENTE = db.TIPOCLIENTEs.Find(id);
            if (tIPOCLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCLIENTE);
        }

        // POST: TIPOCLIENTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoCliente,TipoCliente1")] TIPOCLIENTE tIPOCLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOCLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOCLIENTE);
        }

        // GET: TIPOCLIENTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCLIENTE tIPOCLIENTE = db.TIPOCLIENTEs.Find(id);
            if (tIPOCLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCLIENTE);
        }

        // POST: TIPOCLIENTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOCLIENTE tIPOCLIENTE = db.TIPOCLIENTEs.Find(id);
            db.TIPOCLIENTEs.Remove(tIPOCLIENTE);
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
