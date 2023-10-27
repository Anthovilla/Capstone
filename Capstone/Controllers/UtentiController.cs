using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class UtentiController : Controller
    {

        ModelDBContext db = new ModelDBContext();

        // GET: Utenti
        public ActionResult Index()
        {
            return View(db.Utenti.ToList());
        }

        public ActionResult Edit(int id)
        {

            List<SelectListItem> Ruoli = new List<SelectListItem>();
            Ruoli.Add(new SelectListItem() { Text = "Utente", Value = "User" });
            Ruoli.Add(new SelectListItem() { Text = "Amministratore", Value = "Admin" });
            this.ViewBag.Ruoli = new SelectList(Ruoli, "Value", "Text");

            return View(db.Utenti.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Utenti u) 
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(db.Utenti.Find(id));
        }

        public ActionResult Delete(int id)
        {
            Utenti utenti = db.Utenti.Find(id);

            db.Utenti.Remove(utenti);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        //public ActionResult Reset(int id)
        //{
        //    Utenti utenti = db.Utenti.Find(id);
        //    utenti.Password = "password1";
        //    db.Entry(utenti).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

    }
}