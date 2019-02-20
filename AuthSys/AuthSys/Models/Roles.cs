using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AuthSys.Models
{
    public class Roles
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        //public IEnumerable<SelectListItem> RoleName { get; set; }

        public string RoleDescription { get; set; }
    }
}