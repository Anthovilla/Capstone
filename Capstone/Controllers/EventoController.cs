using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class EventoController : Controller
    {

        ModelDBContext db = new ModelDBContext();

        // GET: Evento
        public ActionResult Index()
        {
            return View(db.Evento.ToList());
        }

        //[HttpGet]
        //public ActionResult CreaEvento()
        //{
  
        //}
    }
}