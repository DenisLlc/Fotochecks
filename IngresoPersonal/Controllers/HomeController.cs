using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using IngresoPersonal.Permissions;

namespace IngresoPersonal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [PermissionsRolAttibute(Models.RolesInd.User)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [PermissionsRolAttibute(Models.RolesInd.Admin)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Usted no cuenta con permiso para este módulo.";

            return View();

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            Session["username"] = null;

            return RedirectToAction("Login", "Access");
        }
    }
}