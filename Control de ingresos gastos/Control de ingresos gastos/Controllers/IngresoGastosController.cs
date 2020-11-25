using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Control_de_ingresos_gastos.Data;
using Control_de_ingresos_gastos.Models;

namespace Control_de_ingresos_gastos.Controllers
{
    public class IngresoGastosController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: IngresoGastos
        public ActionResult Index()
        {
            Double Ingresos, Gastos, Total;
            Ingresos = db.IngresosGastos.Where(m => m.EsIngreso == true).Select(p => p.Valor).Sum();
            Gastos = db.IngresosGastos.Where(m => m.EsIngreso == false).Select(p => p.Valor).Sum();
            Total = Ingresos - Gastos;
            ViewBag.Ingresos = Ingresos;
            ViewBag.Gastos = Gastos;
            ViewBag.Total = Total;

            return View(db.IngresosGastos.ToList());
        }

        // GET: IngresoGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastos ingresoGastos = db.IngresosGastos.Find(id);
            if (ingresoGastos == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastos);
        }

        // GET: IngresoGastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngresoGastos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastos ingresoGastos)
        {
            if (ModelState.IsValid)
            {
                db.IngresosGastos.Add(ingresoGastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingresoGastos);
        }

        // GET: IngresoGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastos ingresoGastos = db.IngresosGastos.Find(id);
            if (ingresoGastos == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastos);
        }

        // POST: IngresoGastos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresoGastos ingresoGastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresoGastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingresoGastos);
        }

        // GET: IngresoGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresoGastos ingresoGastos = db.IngresosGastos.Find(id);
            if (ingresoGastos == null)
            {
                return HttpNotFound();
            }
            return View(ingresoGastos);
        }

        // POST: IngresoGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresoGastos ingresoGastos = db.IngresosGastos.Find(id);
            db.IngresosGastos.Remove(ingresoGastos);
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
