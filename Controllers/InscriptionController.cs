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
    public class InscriptionController : Controller
    {
        private Concours_recrutementEntities db = new Concours_recrutementEntities();

        // GET: Inscription
        public ActionResult Index()
        {
            var inscriptions = db.Inscriptions.Include(i => i.Concour).Include(i => i.Gestionnaire).Include(i => i.Profil);
            return View(inscriptions.ToList());
        }

        public ActionResult Connect()
        {
            return View();
        }
        public ActionResult Choose()
        {
            return View();
        }

        // GET: Inscription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // GET: Inscription/Create
        public ActionResult Create()
        {
            ViewBag.ID_concours = new SelectList(db.Concours, "ID_concours", "Nom_concours");
            ViewBag.ID_gestionnaire = new SelectList(db.Gestionnaires, "ID_gestionnaire", "Nom_gestionnaire");
            ViewBag.ID_profil = new SelectList(db.Profils, "ID_profil", "Nom_profil");
            return View();
        }

        // POST: Inscription/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_inscription,Curriculum_vitae,Diplome,Date_dépot,Nom,Prénom,Numéro_CIN,Téléphone,Date_naissance,Lieu_naissance,code_postal,Sexe,Ville,ID_profil,ID_gestionnaire,ID_concours,Statut")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                db.Inscriptions.Add(inscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_concours = new SelectList(db.Concours, "ID_concours", "Nom_concours", inscription.ID_concours);
            ViewBag.ID_gestionnaire = new SelectList(db.Gestionnaires, "ID_gestionnaire", "Nom_gestionnaire", inscription.ID_gestionnaire);
            ViewBag.ID_profil = new SelectList(db.Profils, "ID_profil", "Nom_profil", inscription.ID_profil);
            return View(inscription);
        }

        // GET: Inscription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_concours = new SelectList(db.Concours, "ID_concours", "Nom_concours", inscription.ID_concours);
            ViewBag.ID_gestionnaire = new SelectList(db.Gestionnaires, "ID_gestionnaire", "Nom_gestionnaire", inscription.ID_gestionnaire);
            ViewBag.ID_profil = new SelectList(db.Profils, "ID_profil", "Nom_profil", inscription.ID_profil);
            return View(inscription);
        }

        // POST: Inscription/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_inscription,Curriculum_vitae,Diplome,Date_dépot,Nom,Prénom,Numéro_CIN,Téléphone,Date_naissance,Lieu_naissance,code_postal,Sexe,Ville,ID_profil,ID_gestionnaire,ID_concours,Statut")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_concours = new SelectList(db.Concours, "ID_concours", "Nom_concours", inscription.ID_concours);
            ViewBag.ID_gestionnaire = new SelectList(db.Gestionnaires, "ID_gestionnaire", "Nom_gestionnaire", inscription.ID_gestionnaire);
            ViewBag.ID_profil = new SelectList(db.Profils, "ID_profil", "Nom_profil", inscription.ID_profil);
            return View(inscription);
        }

        // GET: Inscription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // POST: Inscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscription inscription = db.Inscriptions.Find(id);
            db.Inscriptions.Remove(inscription);
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
