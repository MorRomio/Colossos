﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthSys.ViewModels
{
    public class AdminViewModel
    {
        public int MemberID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MemberEmail { get; set; }

        public string Password { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public string RoleName { get; set; }
    }
}