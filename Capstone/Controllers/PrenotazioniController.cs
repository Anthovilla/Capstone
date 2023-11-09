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

            if (!ModelState.IsValid)
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

       

    }
}