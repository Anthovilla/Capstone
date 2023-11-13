using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class PrenotazioniController : Controller
    {
        ModelDBContext db = new ModelDBContext();
       

        // GET: Prenotazioni
        public ActionResult Index(int?id, string action)
        {

            if (ModelState.IsValid)
            {

                var reserva = db.Prenotazione.Find(id);
               
                if (reserva != null) 
                {
                    if (action== "confirm")
                    {
                        reserva.Status = "Confermata";
                    }
                    else if (action == "attesa")
                    {
                        reserva.Status = "In attesa";
                    }
                    db.SaveChanges();
                }
            }

            return View(db.Prenotazione.ToList());
        }


        //public ActionResult Create(int id)
        //{
        //    ViewBag.Id = id;
        //    return View();

        //}

        //[HttpPost]
        //public ActionResult Create(Prenotazione prenota)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Prenotazione.Add(prenota);
        //        db.SaveChanges();
        //        return RedirectToAction("DettaglioEvento", "Evento", new { id = prenota.FKEventi });

        //    }

        //    ViewBag.Id = prenota.FKEventi; 
        //    return View();

        //}





        public ActionResult Create()
        {
            var utente = db.Utenti.ToList();
            ViewBag.UtenteList = new SelectList(utente, "Id", "Nome");
            var evento = db.Evento.ToList();
            ViewBag.EventoList = new SelectList(evento, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prenotazione c)
        {
            ViewBag.UtenteList = new SelectList(db.Utenti.ToList(), "Id", "Nome");
            ViewBag.EventoList = new SelectList(db.Evento.ToList(), "Id", "Nome");

            var utente = User.Identity.Name;
            var user = db.Utenti.Where(us => us.Username == utente).FirstOrDefault();
            c.FKUtente = user.Id;
            c.Data = DateTime.Now;

            db.Prenotazione.Add(c);
                db.SaveChanges();
                return RedirectToAction("DettaglioEvento", "Evento", new { id = c.FKEventi });            
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