using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using poligono.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace poligono.Controllers
{
    public class PosizionisController : Controller
    {
        private PosizioniEntities2 db = new PosizioniEntities2();

        PosizioniEntities2 context = new PosizioniEntities2();  

        // GET: Posizionis
        public ActionResult Index()
        {
            return View(db.Posizionis.ToList());
        }

        [HttpPost]
        public ActionResult CreateArea(StringheMouse str)
        {
            context.StringheMouse.Add(str);
            context.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult GetArea(string id)
        {
            List<StringheMouse> StringheMouse = new List<StringheMouse>();
            StringheMouse = context.StringheMouse.ToList();
            return Json(StringheMouse, JsonRequestBehavior.AllowGet);
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
