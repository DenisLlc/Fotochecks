//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IngresoPersonal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string DNI { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int idRol { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}
