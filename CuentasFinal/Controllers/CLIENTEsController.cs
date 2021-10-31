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
    public class CLIENTEsController : Controller
    {
        private pruebaEntities db = new pruebaEntities();

        // GET: CLIENTEs
        public ActionResult Index()
        {
            var cLIENTEs = db.CLIENTEs.Include(c => c.TIPOCLIENTE);
            return View(cLIENTEs.ToList());
        }

        // GET: CLIENTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoCliente = new SelectList(db.TIPOCLIENTEs, "IdTipoCliente", "TipoCliente1");
            return View();
        }

        // POST: CLIENTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nombre,Telefono,Nit,IdTipoCliente")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTEs.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoCliente = new SelectList(db.TIPOCLIENTEs, "IdTipoCliente", "TipoCliente1", cLIENTE.IdTipoCliente);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoCliente = new SelectList(db.TIPOCLIENTEs, "IdTipoCliente", "TipoCliente1", cLIENTE.IdTipoCliente);
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nombre,Telefono,Nit,IdTipoCliente")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoCliente = new SelectList(db.TIPOCLIENTEs, "IdTipoCliente", "TipoCliente1", cLIENTE.IdTipoCliente);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            db.CLIENTEs.Remove(cLIENTE);
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
