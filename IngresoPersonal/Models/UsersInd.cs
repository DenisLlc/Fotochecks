﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngresoPersonal.Models
{
    public class UsersInd
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string DNI { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public RolesInd idRol { get; set; }
    }
}