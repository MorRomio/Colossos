using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthSys.Models
{
    public class Admin
    {
        public string MemberID { get; set; }

        public string MemberEmail { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}