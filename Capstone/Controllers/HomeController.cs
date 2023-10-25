﻿using Capstone.Models.DbModels;
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
                return RedirectToAction("Index"); 
            }
            return View();     
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Ruolo")]Utenti utente)
        {
            if(db.Utenti.Where(u => utente.Username == utente.Username).Count() > 0)
            {
                ViewBag.Errore = "Username già in uso";
                return View();
            }

            db.Utenti.Add(new Utenti
            {
                Username = utente.Username,
                Password = utente.Password,
                Nome = utente.Nome,
                CF = utente.CF,
                Telefono = utente.Telefono,
                Email = utente.Email,              
                Ruolo = "User"
            });

            db.SaveChanges();

            Login(utente);
            return RedirectToAction("Index");
        }
    }
}
