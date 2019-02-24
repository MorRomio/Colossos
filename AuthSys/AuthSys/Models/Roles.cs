using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AuthSys.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }
    }
}