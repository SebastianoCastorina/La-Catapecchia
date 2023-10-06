using La_Catapecchia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace La_Catapecchia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Utente u)
        {
            Utente user = DB.GetUserByUsername(u.Username);
            if (user.Username != null)
            {
                if (user.Password == u.Password)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    return RedirectToAction("Index", "Camere");
                }
                else
                {
                    ViewBag.ErrorMessage = "Password Errata";
                    return View();
                }

            }
            else
            {
                ViewBag.ErrorMessage = "L'Username inserito non è valido";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}

