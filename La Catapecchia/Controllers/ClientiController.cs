using La_Catapecchia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace La_Catapecchia.Controllers
{
    public class ClientiController : Controller
    {
        // GET: Clienti
        public ActionResult Index()
        {
            return View(DB.getAllClienti());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.AddCliente(c.Cognome, c.Nome, c.CF, c.Provincia, c.Città, c.Email, c.Telefono, c.Cellulare);
                return RedirectToAction("Index");
            }
            else { return View(); }
        }
    }
}