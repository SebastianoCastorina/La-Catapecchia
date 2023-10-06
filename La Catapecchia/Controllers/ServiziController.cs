using La_Catapecchia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace La_Catapecchia.Controllers
{
    public class ServiziController : Controller
    {
        // GET: Servizi
        public ActionResult Index()
        {
            return View(DB.getAllServizi());
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Servizi s) 
        {
            DB.AddServizio(s.NomeServizio, s.CostoServizio);
            
                return RedirectToAction("Index");
                }
        public ActionResult Edit(int id) 
        { return View(DB.getServbyIdServizio(id)); 
        }
        [HttpPost] public ActionResult Edit(Servizi s) {

            DB.editServizio(s.IdServizio, s.NomeServizio, s.CostoServizio);
            return RedirectToAction("Index");
                }


        public ActionResult Delete()
        { return View(); }

        
    }

    
}