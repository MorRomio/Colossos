using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthSys.Models
{
    public class Tansactions
    {
        public int TransactionID { get; set; }

        public Member member { get; set; }

        public int AmountPayed { get; set; }

        //public DateTime TransactionDate { get; set;  }
    }
}