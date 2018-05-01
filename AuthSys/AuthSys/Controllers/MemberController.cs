using AuthSys.DataAccessLayer;
using AuthSys.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using AuthSys.ViewModels;
using System.Threading;
using System.Globalization;

namespace AuthSys.Controllers
{
    public class MemberController : Controller
    {
        private ColossosContext coloContext = new ColossosContext();

        public ActionResult AddMemberInit()
        {
            return View("AddMember");
        }

        [HttpPost]
        public ActionResult AddMember(MemberViewModel model)
        {
            var member = new Member() {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                BirthDate = model.BirthDate,
                SportType = model.SportType
            };

            coloContext.Members.Add(member);
            coloContext.SaveChanges();  
         
            return View(member);
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