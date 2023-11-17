using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        ModelDBContext db = new ModelDBContext();

        
        public ActionResult Index()
        {    

            return View();
        }

        public ActionResult Carrello() {
            
            return View();
        }



        //Login Register

        
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")]Utenti utente)
        {
            if( db.Utenti.Where(u => u.Username == utente.Username && u.Password == utente.Password).Count() > 0)
            {
                Session["IdUtente"] = utente.Id;
                FormsAuthentication.SetAuthCookie(utente.Username, true);
                return RedirectToAction("CercaEvento"); 
            }
            return View();     
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("CercaEvento");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Ruolo")]Utenti utente)
        {
            if(db.Utenti.Where(u => u.Username == utente.Username).Count() > 0)
            {
                ViewBag.Errore = "Username già in uso";
                return View();
            }

            db.Utenti.Add(new Utenti
            {
                Nome = utente.Nome,
                CF = utente.CF,
                Telefono = utente.Telefono,
                Email = utente.Email,
                Username = utente.Username,
                Password = utente.Password,
                Ruolo = "User"
            });
           

            db.SaveChanges();

            Login(utente);
            return RedirectToAction("CercaEvento");
        }


        public ActionResult CercaEvento()
        {
            return View();
        }

        public JsonResult CercaEventoNome(string nome)
        {
            Evento evento = db.Evento.Where(e => e.Nome == nome).FirstOrDefault();

            if (evento != null)
            {
                var resultato = new
                {
                    id = evento.Id,
                    img = evento.Foto,
                    Nome = evento.Nome,
                    Costo = evento.Costo,
                    Descrizione = evento.Description,
                };

                return Json(resultato, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);

            }
            
        }


        public ActionResult Dettagli(int id)
        {
            return View(db.Evento.Find(id));
        }




        public ActionResult Profilo()
        {
            Utenti utenti = db.Utenti.FirstOrDefault(u => u.Username == User.Identity.Name);
            if(utenti == null)
            {
                return View("Index");
            }
            return View(utenti);
        }

        [HttpPost]
        public ActionResult Profilo(Utenti aggiornaUtenti)
        {
            if(ModelState.IsValid)
            {
                Utenti utenti = db.Utenti.FirstOrDefault(u => u.Username == User.Identity.Name);

                utenti.Username = aggiornaUtenti.Username;
                utenti.Password = aggiornaUtenti.Password;
                utenti.Nome = aggiornaUtenti.Nome;
                utenti.CF = aggiornaUtenti.CF;
                utenti.Telefono = aggiornaUtenti.Telefono;
                utenti.Email = aggiornaUtenti.Email;

                db.SaveChanges();

                return RedirectToAction("Logout");

            }
            return View(aggiornaUtenti);
        }

    }
}
