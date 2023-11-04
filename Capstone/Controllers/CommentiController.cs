using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
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


        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag = id; 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Commenti c)
        {

            if (ModelState.IsValid)
            {
                c.Data = DateTime.Today;
                db.Commenti.Add(c);
                db.SaveChanges();
                return RedirectToAction("DettaglioEvento", "Evento", new {id = c.});
      
            }
            ViewBag.Id = c.FKEventi;
            return View(c);

        }


        public ActionResult Edit(int id)
        {
            ViewBag.Utenti = GetUtenti;
            ViewBag.Eventos = GetEvento;
            var commento = db.Commenti.Find(id);

            return View(commento);
        }

        [HttpPost]
        public ActionResult Edit(Commenti c)
        {
            ViewBag.Utenti = GetUtenti;
            ViewBag.Eventos = GetEvento;

            if (ModelState.IsValid)
            {
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Delete(int id)
        {
            Commenti commenti = db.Commenti.Find(id);
            db.Commenti.Remove(commenti);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        



        public List<SelectListItem> GetUtenti
        {
            get
            {
                List<SelectListItem> Utenti = new List<SelectListItem>();
                List<Utenti> ListUtenti = db.Utenti.ToList();

                foreach(Utenti utente in ListUtenti)
                {
                    SelectListItem item = new SelectListItem { Text = utente.Nome, Value = utente.Id.ToString() };
                    Utenti.Add(item);
                }
                return Utenti;

            }
        }

        public List<SelectListItem> GetEvento
        {
            get
            {
                List<SelectListItem> Eventos = new List<SelectListItem>();
                List<Evento> ListEvento = db.Evento.ToList();

                foreach (Evento evento in ListEvento)
                {
                    SelectListItem item = new SelectListItem { Text = evento.Nome, Value = evento.Id.ToString() };
                    Eventos.Add(item);
                }
               return Eventos;

            }
        }



    }
}