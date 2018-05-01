using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuthSys.Models
{
    public class Member //Implementing IEnumerable makes sure we can loop over the members in the View
    {     
        public int MemberID { get; set; }

        [Display(Name = "Medlemskort")]
        public string AssociatedCard { get; set; }

        [Display(Name="Fornavn")]
        public string FirstName { get; set; }

        [Display(Name="Efternavn")]
        public string LastName { get; set; }

        [Display(Name="Fødselsdato")]        
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name="Medlem siden")]
        [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Alder")]
        public int Age { get; set; }

        [Display(Name="Sportsgren")]
        public string SportType { get; set; }

        [Display(Name="Tilføj kort")]
        public bool AddCard { get; set; }

        public string imageReference { get; set; }

        //Type ICollection allows entries to be added, deleted and updated
        public virtual ICollection<Card> cards { get; set; }  //Making a relation to the Card table
        
    }
}