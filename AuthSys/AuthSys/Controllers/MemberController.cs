using AuthSys.DataAccessLayer;
using AuthSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthSys.Controllers
{
    public class MemberController : Controller
    {
        private ColossosContext coloContext = new ColossosContext();

        public ActionResult AddMemberInit()
        {
            return View("AddMember");
        }

        public ActionResult AddMember(string firstName, string lastName, DateTime birthDate, int age, string sportType)
        {
            var member = new Member() { FirstName = firstName, LastName = lastName, Age = age, SportType = sportType, BirthDate = birthDate };

            coloContext.Members.Add(member);
            coloContext.SaveChanges();  
         
            return View();
        }

        public ActionResult RegisteredMembers()
        {
            List<Member> members = new List<Member>();

            foreach (var m in coloContext.Members)
            {
                members.Add(m);
            }            
            
            return View(members);
        }

        public ActionResult EditMember(int? id)
        {
            return View();
        }
    }
}