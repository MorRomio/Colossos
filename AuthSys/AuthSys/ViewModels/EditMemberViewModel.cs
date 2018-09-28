using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthSys.ViewModels
{
    public class EditMemberViewModel
    {
        public int MemberID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string SportType { get; set; }

        public string HasCard { get; set; }

        //public string CreationDate { get; set; }
    }
}