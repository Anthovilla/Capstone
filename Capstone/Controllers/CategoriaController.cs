using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class CategoriaController : Controller
    {
        ModelDBContext db = new ModelDBContext();

        // GET: Categoria
        public ActionResult Index()
        {


            return View(db.Categoria.ToList());
        }

        [HttpGet]

        public ActionResult AddCate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCate(Categoria NuovaCate)
        {
            if (ModelState.IsValid)
            {
                db.Categoria.Add(NuovaCate);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }


        [HttpGet]
        public ActionResult EditCate(int id)
        {
            return View(db.Utenti.Find(id));
        }

        [HttpPost]
        public ActionResult EditCate(Categoria NuovaCate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(NuovaCate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}