using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AjouterConcoursController : Controller
    {
        private Concours_recrutementEntities db = new Concours_recrutementEntities();

        // GET: AjouterConcours
        public ActionResult Index()
        {
            var concours = db.Concours.Include(c => c.Grade);
            return View(concours.ToList());
        }

        // GET: AjouterConcours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concour concour = db.Concours.Find(id);
            if (concour == null)
            {
                return HttpNotFound();
            }
            return View(concour);
        }

        // GET: AjouterConcours/Create
        public ActionResult Create()
        {
            ViewBag.ID_grade = new SelectList(db.Grades, "ID_grade", "Nom_grade");
            return View();
        }

        // POST: AjouterConcours/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_concours,Nom_concours,Date_concours,Date_limite,Nombre_de_poste,ID_grade,Statut")] Concour concour)
        {
            if (ModelState.IsValid)
            {
                db.Concours.Add(concour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_grade = new SelectList(db.Grades, "ID_grade", "Nom_grade", concour.ID_grade);
            return View(concour);
        }

        // GET: AjouterConcours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concour concour = db.Concours.Find(id);
            if (concour == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_grade = new SelectList(db.Grades, "ID_grade", "Nom_grade", concour.ID_grade);
            return View(concour);
        }

        // POST: AjouterConcours/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_concours,Nom_concours,Date_concours,Date_limite,Nombre_de_poste,ID_grade,Statut")] Concour concour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_grade = new SelectList(db.Grades, "ID_grade", "Nom_grade", concour.ID_grade);
            return View(concour);
        }

        // GET: AjouterConcours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concour concour = db.Concours.Find(id);
            if (concour == null)
            {
                return HttpNotFound();
            }
            return View(concour);
        }

        // POST: AjouterConcours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Concour concour = db.Concours.Find(id);
            db.Concours.Remove(concour);
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
