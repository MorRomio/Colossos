using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthSys.ViewModels
{
    public class RolesViewModel
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public SelectList list { get; set; }

        public int selectedItem { get; set; }
    }
}