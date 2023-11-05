using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class CommentiController : Controller
    {

        ModelDBContext db = new ModelDBContext();

        // GET: Commenti
        public ActionResult Index([Bind(Include = "Nome")] Evento evento, [Bind(Include = "Username")] Utenti utenti)
        {
            List<Commenti> commenti = db.Commenti.ToList();

            if(evento.Nome != null)
                commenti = commenti.Where(c => c.Evento.Nome.ToLower().Contains(evento.Nome.ToLower())).ToList();


            if (utenti.Username != null)
                commenti = commenti.Where(c => c.Utenti.Username.ToLower().Contains(utenti.Username.ToLower())).ToList();


            return View(commenti);
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
        public ActionResult Create(Commenti c)
        {
            if (ModelState.IsValid)
            {
                db.Commenti.Add(c);
                db.SaveChanges();
                return RedirectToAction("DettaglioEvento","Evento", new {id = c.FKEventi});

            }
            ViewBag.UtenteList = new SelectList(db.Utenti.ToList(), "Id", "Nome");
            ViewBag.EventoList = new SelectList(db.Evento.ToList(), "Id", "Nome");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var utente = db.Utenti.ToList();
            ViewBag.UtenteList = new SelectList(utente, "Id", "Nome");
            var evento = db.Evento.ToList();
            ViewBag.EventoList = new SelectList(evento, "Id", "Nome");
            var c = db.Commenti.Find(id);
            return View(c);

        }

        [HttpPost]
        public ActionResult Edit(Commenti c)
        {

            if (!ModelState.IsValid)
            {
                var commenti = db.Commenti.Find(c.Id);
                if (commenti != null)
                {
                    commenti.Data = c.Data;
                    commenti.Text = c.Text;
                    db.Entry(commenti).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DettaglioEvento", "Evento", new { id = c.FKEventi });
                }
                else { }               
            }
            ViewBag.UtenteList = new SelectList(db.Utenti.ToList(), "Id", "Nome");
            ViewBag.EventoList = new SelectList(db.Evento.ToList(), "Id", "Nome");
            return View();


        }



        public ActionResult ListUtenti()
        {
            return View(db.Utenti.ToList());
        }


        public ActionResult ListEvento()
        {
            return View(db.Evento.ToList());
        }

        public ActionResult Delete(int id)
        {
            Commenti commenti = db.Commenti.Find(id);
            db.Commenti.Remove(commenti);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    ViewBag.Utenti = GetUtenti;
        //    ViewBag.Eventos = GetEvento;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Commenti c)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.Commenti.Add(c);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");

        //        c.Data = DateTime.Today;
        //        db.Commenti.Add(c);
        //        db.SaveChanges();
        //        return RedirectToAction("DettaglioEvento", "Evento", new { id = c.FKEventi });

        //    }
        //    var utenti = new SelectList(db.Utenti.ToList(), "Id", "Nome");
        //    var eventos = new SelectList(db.Evento.ToList(), "Id", "Nome");
        //    return View(c);

        //}




        //public List<SelectListItem> GetUtenti
        //{
        //    get
        //    {
        //        List<SelectListItem> Utenti = new List<SelectListItem>();
        //        List<Utenti> ListUtenti = db.Utenti.ToList();

        //        foreach(Utenti utente in ListUtenti)
        //        {
        //            SelectListItem item = new SelectListItem { Text = utente.Nome, Value = utente.Id.ToString() };
        //            Utenti.Add(item);
        //        }
        //        return Utenti;

        //    }
        //}

        //public List<SelectListItem> GetEvento
        //{
        //    get
        //    {
        //        List<SelectListItem> Eventos = new List<SelectListItem>();
        //        List<Evento> ListEvento = db.Evento.ToList();

        //        foreach (Evento evento in ListEvento)
        //        {
        //            SelectListItem item = new SelectListItem { Text = evento.Nome, Value = evento.Id.ToString() };
        //            Eventos.Add(item);
        //        }
        //       return Eventos;

        //    }
        //}



    }
}