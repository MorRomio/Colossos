using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthSys.Models
{
    public class Member
    {     
        public int MemberID { get; set; }

        public Card card;

        [Display(Name="Fornavn")]
        public string FirstName { get; set; }

        [Display(Name="Efternavn")]
        public string LastName { get; set; }

        [Display(Name="Fødselsdato")]
        public DateTime BirthDate { get; set; }

        [Display(Name="Medlem siden")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Alder")]
        public Int16 Age { get; set; }

        [Display(Name="Sportsgren")]
        public string SportType { get; set; }

        [Display(Name="Tilføj kort")]
        public bool AddCard { get; set; }

        [Display(Name = "Medlemskort")]
        public string AssociatedCard { get; set; }
        
    }
}