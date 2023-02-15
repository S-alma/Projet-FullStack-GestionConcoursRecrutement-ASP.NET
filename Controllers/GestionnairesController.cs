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
    public class GestionnairesController : Controller
    {
        private Concours_recrutementEntities db = new Concours_recrutementEntities();

        // GET: Gestionnaires
        public ActionResult Index()
        {
            return View(db.Gestionnaires.ToList());
        }

        public ActionResult Choose()
        {
            return View(db.Gestionnaires.ToList());
        }

        public ActionResult Choose1()
        {
            return View(db.Gestionnaires.ToList());
        }

        public ActionResult Choose2()
        {
            return View(db.Gestionnaires.ToList());
        }

        public ActionResult Creategestionnaire()
        {
            return View();
        }

        // GET: Gestionnaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestionnaire gestionnaire = db.Gestionnaires.Find(id);
            if (gestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(gestionnaire);
        }

        // GET: Gestionnaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gestionnaires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_gestionnaire,Nom_gestionnaire,Prénom_gestionnaire,Adresse_mail,mot_de_passe")] Gestionnaire gestionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Gestionnaires.Add(gestionnaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gestionnaire);
        }

        // GET: Gestionnaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestionnaire gestionnaire = db.Gestionnaires.Find(id);
            if (gestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(gestionnaire);
        }

        // POST: Gestionnaires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_gestionnaire,Nom_gestionnaire,Prénom_gestionnaire,Adresse_mail,mot_de_passe")] Gestionnaire gestionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gestionnaire);
        }

        // GET: Gestionnaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gestionnaire gestionnaire = db.Gestionnaires.Find(id);
            if (gestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(gestionnaire);
        }

        // POST: Gestionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gestionnaire gestionnaire = db.Gestionnaires.Find(id);
            db.Gestionnaires.Remove(gestionnaire);
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
