using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using control_de_gastos.Data;
using control_de_gastos.Models;

namespace control_de_gastos.Controllers
{
    public class IngresoGastosJFsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: IngresoGastosJFs
        public ActionResult Index()
        {
            Double Ingresos, Gastos, Total;
            Ingresos = db.IngresoGastos.Where(m => m.EsIngreso == true).Select(p => p.Valor).Sum();
            Gastos = db.IngresoGastos.Where(m => m.EsIngreso == false).Select(p => p.Valor).Sum();
            Total = Ingresos - Gastos;
            ViewBag.Ingresos = Ingresos;
            ViewBag.Gastos = Gastos;
            ViewBag.Total = Total;

            return View(db.IngresoGastos.ToList());
        }

        // GET: IngresoGastosJFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastosJF ingresoGastosJF = db.IngresoGastos.Find(id);
            if (ingresoGastosJF == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastosJF);
        }

        // GET: IngresoGastosJFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngresoGastosJFs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastosJF ingresoGastosJF)
        {
            if (ModelState.IsValid)
            {
               // ingresoGastosJF.Fecha = DateTime.Now;
                db.IngresoGastos.Add(ingresoGastosJF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingresoGastosJF);
        }

        // GET: IngresoGastosJFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
               
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastosJF ingresoGastosJF = db.IngresoGastos.Find(id);
            if (ingresoGastosJF == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastosJF);
        }

        // POST: IngresoGastosJFs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastosJF ingresoGastosJF)
        {
            if (ModelState.IsValid)
            {
                ingresoGastosJF.Fecha = DateTime.Now;
                db.Entry(ingresoGastosJF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingresoGastosJF);
        }

        // GET: IngresoGastosJFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastosJF ingresoGastosJF = db.IngresoGastos.Find(id);
            if (ingresoGastosJF == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastosJF);
        }

        // POST: IngresoGastosJFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresoGastosJF ingresoGastosJF = db.IngresoGastos.Find(id);
            db.IngresoGastos.Remove(ingresoGastosJF);
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
