using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using poligono.Models;

namespace poligono.Controllers
{
    public class PosizioniController : Controller
    {
        private PosizioniDB db = new PosizioniDB();

        // GET: Posizioni
        public ActionResult Index()
        {
            //ViewBag.coordinate = db.Posizioni.ToList();
            return View(db.Posizioni.ToList());
        }

        // GET: Posizioni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posizioni posizioni = db.Posizioni.Find(id);
            if (posizioni == null)
            {
                return HttpNotFound();
            }
            return View(posizioni);
        }

        // GET: Posizioni/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posizioni/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Lat,Lon")] Posizioni posizioni)
        {
            if (ModelState.IsValid)
            {
                db.Posizioni.Add(posizioni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posizioni);
        }

        // GET: Posizionis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posizioni posizioni = db.Posizioni.Find(id);
            if (posizioni == null)
            {
                return HttpNotFound();
            }
            return View(posizioni);
        }

        // POST: Posizionis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Lat,Lon")] Posizioni posizioni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posizioni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posizioni);
        }

        // GET: Posizionis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posizioni posizioni = db.Posizioni.Find(id);
            if (posizioni == null)
            {
                return HttpNotFound();
            }
            return View(posizioni);
        }

        // POST: Posizionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posizioni posizioni = db.Posizioni.Find(id);
            db.Posizioni.Remove(posizioni);
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
