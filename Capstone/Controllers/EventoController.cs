using Capstone.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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

        [HttpGet]
        public ActionResult CreaEvento()
        {
            ViewBag.Categoria = GetCategoria;
            return View();

        }

        public ActionResult CreaEvento(Evento evento)
        {
            ViewBag.Categoria = GetCategoria;

            if (ModelState.IsValid)
            {
                if (evento.FotoFile != null && evento.FotoFile.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Imgs/"), evento.FotoFile.FileName);
                    evento.FotoFile.SaveAs(path);

                    evento.Foto = evento.FotoFile.FileName;

                }
                evento.Data = DateTime.Today;


                db.Evento.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }


        [HttpGet]
        public ActionResult ModificaEvento(int id)
        {
            ViewBag.Categoria = GetCategoria;
            var evento = db.Evento.Find(id);
            return View(evento);   
        }

        [HttpPost]
        public ActionResult ModificaEvento(Evento evento)
        {
            ViewBag.Categoria = GetCategoria;

            if(ModelState.IsValid)
            {
                if(evento.FotoFile != null && evento.FotoFile.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Imgs/"), evento.FotoFile.FileName);
                    evento.FotoFile.SaveAs (path);

                    evento.Foto = evento.FotoFile.FileName;
                }

                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(evento);

        }

        public ActionResult DettaglioEvento(int id)
        {
            return View(db.Evento.Find(id));

        }


        public ActionResult EliminaEvento(int id)
        {

            Evento evento = db.Evento.Find(id);
            if (evento != null)
            {

            }


            db.Evento.Remove(evento);
            db.SaveChanges();

            return RedirectToAction("Index");
        }




        //Inserimento Comment , Recensioni
        public PartialViewResult Comment(int id)
        {
            ViewBag.Id = id;
            return PartialView(db.Commenti.Where(c => c.FKEventi == id).OrderByDescending(o => o.Data));

        }

        public PartialViewResult Recension(int id)
        {
            ViewBag.Id = id;
            return PartialView(db.Recensioni.Where(r => r.FKEventi == id).OrderByDescending(o => o.Rating));
        }


        public PartialViewResult Prenotazion(int id)
        {

            ViewBag.Id = id;
            return PartialView(db.Prenotazione.Where(p => p.FKEventi == id).OrderByDescending(o => o.Data));
        }





        public List<SelectListItem> GetCategoria
        {
            
           get
                {

                List<SelectListItem> Categoria = new List<SelectListItem>();
                List<Categoria> ListCate = db.Categoria.ToList();

                foreach (Categoria cate in ListCate)
                {
                    SelectListItem item = new SelectListItem { Text = cate.Nome, Value = cate.Id.ToString()};
                    Categoria.Add(item);
                }
                return Categoria;
            }


        }
    }
}