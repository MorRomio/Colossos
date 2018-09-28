using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public DateTime BirthDate { get; set; }

        [Display(Name="Adresse")]
        public string Address { get; set; }

        [Display(Name="Postnummer")]
        public int ZipCode { get; set; }

        [Display(Name="By")]
        public string City { get; set; }

        [Display(Name="Medlem siden")]      
        public DateTime DateCreate { get; set; }

       // [Display(Name ="Udløbsdato af medlemskab")]
       // public DateTime ExpirationOfMembership { get; set; }

        [Display(Name = "Alder")]
        public int Age { get; set; }

        [Display(Name="Sportsgren")]
        public string SportTypes { get; set; }

        public string imageReference { get; set; }

        //Type ICollection allows entries to be added, deleted and updated
        public virtual Card Card { get; set; }  //Making a relation to the Card table
        
    }
}