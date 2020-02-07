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
    public class PosizionisController : Controller
    {
        private Posizioni db = new Posizioni();

        // GET: Posizionis
        public ActionResult Index()
        {
            return View(db.Posizionis.ToList());
        }

        // GET: Posizionis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posizionis posizionis = db.Posizionis.Find(id);
            if (posizionis == null)
            {
                return HttpNotFound();
            }
            return View(posizionis);
        }

        // GET: Posizionis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posizionis/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Lat,Lon,Tipo")] Posizionis posizionis)
        {
            if (ModelState.IsValid)
            {
                db.Posizionis.Add(posizionis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posizionis);
        }

        // GET: Posizionis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posizionis posizionis = db.Posizionis.Find(id);
            if (posizionis == null)
            {
                return HttpNotFound();
            }
            return View(posizionis);
        }

        // POST: Posizionis/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Lat,Lon,Tipo")] Posizionis posizionis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posizionis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posizionis);
        }

        // GET: Posizionis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posizionis posizionis = db.Posizionis.Find(id);
            if (posizionis == null)
            {
                return HttpNotFound();
            }
            return View(posizionis);
        }

        // POST: Posizionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posizionis posizionis = db.Posizionis.Find(id);
            db.Posizionis.Remove(posizionis);
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
