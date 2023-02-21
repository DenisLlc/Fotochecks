using IngresoPersonal.Logic;
using IngresoPersonal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IngresoPersonal.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            UsersInd obj = new LO_User().FindUser(User, Pass);

            if(obj.name != null)
            {
                FormsAuthentication.SetAuthCookie(obj.username, false);

                //Guarda el objeto de tipo UderInd que servira para recuperar el rol del usuario logeado
                Session["User"] = obj;
                //Guarda el nombre del usuario logeado
                Session["username"] = obj.name;

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}