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
    /// <summary>
    /// Clase controlador de acceso
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <example>
    /// <code>
    /// </code>
    /// <c>
    /// </c>
    /// </example>
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Logeo
        /// </summary>
        /// <param name="User">Recibe el valor del nombre de usuario logeado</param>
        /// <param name="Pass">Recibe el valor de la contraseña del usuario logeado</param>
        /// <returns>Devuelve una redirección a la página Index</returns>
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