using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AuthSys.Models
{
    public class Admin
    {
        public int MemberID { get; set; }

        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternavn")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string MemberEmail { get; set; }

        [Display(Name = "Kode")]
        public string Password { get; set; }

        [Display(Name = "Rolle")]
        public string RoleName { get; set; }


        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}