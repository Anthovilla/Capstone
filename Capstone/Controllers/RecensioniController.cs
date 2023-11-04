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
    }
}