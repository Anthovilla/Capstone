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

        [HttpGet]
        public ActionResult CreaEvento()
        {
            ViewBag.Categoria = GetCategoria;
            return View();

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