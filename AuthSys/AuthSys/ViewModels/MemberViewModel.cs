using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthSys.ViewModels
{
    public class MemberViewModel
    {
        public string FirstName { get; set; }   
     
        public string LastName { get; set; }  
      
        public DateTime BirthDate { get; set; }       
                
        public DateTime DateCreate { get; set; }      
  
        public int? Age { get; set; }        

        public string SportTypes { get; set; }
    }
}