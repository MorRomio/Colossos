using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthSys.Models
{
    public class Card
    {
        public int CardID { get; set; }

        public int MemberID { get; set; }

        public DateTime CreationDate { get; set; }
    }
}