using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class RecensioniController : Controller
    {

        ModelDBContext db = new ModelDBContext();
        // GET: Recensioni
        public ActionResult Index()
        {
            return View(db.Recensioni.ToList());
        }

        public ActionResult Create()
        {
            var utente = db.Utenti.ToList();
            ViewBag.UtenteList = new SelectList(utente, "Id", "Nome");
            var evento = db.Evento.ToList();
            ViewBag.EventoList = new SelectList(evento, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Recensioni r)
        {
            if (ModelState.IsValid)
            {
                db.Recensioni.Add(r);
                db.SaveChanges();
                return RedirectToAction("DettaglioEvento", "Evento", new { id = r.FKEventi });

            }
            ViewBag.UtenteList = new SelectList(db.Utenti.ToList(), "Id", "Nome");
            ViewBag.EventoList = new SelectList(db.Evento.ToList(), "Id", "Nome");
            return View();
        }

        public ActionResult Delete(int id)
        {
            Recensioni recensioni = db.Recensioni.Find(id);
            db.Recensioni.Remove(recensioni);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ListUtenti()
        {
            return View(db.Utenti.ToList());
        }


        public ActionResult ListEvento()
        {
            return View(db.Evento.ToList());
        }

    }
}