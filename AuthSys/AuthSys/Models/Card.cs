using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthSys.Models
{
    public class Card
    {
        public string CardID { get; set; }

        public int MemberID { get; set; }

        public DateTime CreationDate { get; set; } 
    }
}

