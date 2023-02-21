using IngresoPersonal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IngresoPersonal.Permissions
{
    public class PermissionsRolAttibute : ActionFilterAttribute
    {
        //Solo asignar un rol para un módulo
        //private RolesInd idrol;

        //lista de roles que puede tener un modulo
        public RolesInd[] rolList;

        //public PermissionsRolAttibute(RolesInd _idrol)
        //{
        //    idrol = _idrol;
        //}

        public PermissionsRolAttibute(params RolesInd[] _roles)
        {
            rolList = _roles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                UsersInd user = HttpContext.Current.Session["User"] as UsersInd;

                if (!rolList.Contains(user.idRol))
                {
                    filterContext.Result = new RedirectResult("~/Home/Error");
                }

                //if(user.idRol != this.idrol)
                //{
                //    filterContext.Result = new RedirectResult("~/Home/Error");
                //}
            }


            base.OnActionExecuting(filterContext);
        }
    }
}