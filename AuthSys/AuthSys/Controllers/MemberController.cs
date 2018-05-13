using AuthSys.DataAccessLayer;
using AuthSys.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using AuthSys.ViewModels;
using System;
using System.Net;
using System.Linq;

namespace AuthSys.Controllers
{
    public class MemberController : Controller
    {
        private ColossosContext DBContext = new ColossosContext();


        public ActionResult SearchMembers(string searchString)
        {
            ViewBag.Message = "";

            if(String.IsNullOrEmpty(searchString))
            {
                ViewBag.Message = "Du skal angive en værdi";
                ViewBag.TextColor = "red";
                
                //return View("RegisteredMembers");
            }

            var members = DBContext.Members.Where(m => m.FirstName.Contains(searchString) || m.LastName.Contains(searchString));

            return View("RegisteredMembers", members);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent cross-site request forgery
        public ActionResult AddMember(MemberViewModel model)
        {
            ViewBag.Message = "";

            DateTime today = DateTime.Now;
            double days = today.Subtract(model.BirthDate).TotalDays;
            int memberAge = (int)Math.Truncate(days / 365);

            var member = new Member()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                ZipCode = model.ZipCode,
                City = model.City,
                Age = memberAge,
                BirthDate = model.BirthDate,
                SportTypes = model.SportTypes,
                DateCreate = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                DBContext.Members.Add(member);
                DBContext.SaveChanges();

                ViewBag.TextColor = "Green";
                ViewBag.Message = "Medlem tilføjet";
                return View(member);                
            }

            ViewBag.TextColor = "Red";
            ViewBag.Message = "Bruger ikke gemt";
            return View();
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View("AddMember");
        }       

        public ActionResult RegisteredMembers()
        {
            List<Member> members = new List<Member>();

            foreach (var m in DBContext.Members)
            {
                members.Add(m);
            }            
            
            return View(members);
        }

        [HttpGet]
        public ActionResult EditMember(EditMemberViewModel model) 
        {
            Member members = new Member();
            var member = DBContext.Members.Find(model.MemberID);

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent cross-site request forgery
        public ActionResult EditMember(Member model)
        {
            Member members = new Member();
            var member = DBContext.Members.Find(model.MemberID);

            DateTime today = DateTime.Now;
            double days = today.Subtract(model.BirthDate).TotalDays;
            int memberAge = (int)Math.Truncate(days / 365);

            if (member == null)
            {
                return HttpNotFound();
            }

            if(ModelState.IsValid)
            {
                member.MemberID = model.MemberID;
                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.Address = model.Address;
                member.ZipCode = model.ZipCode;
                member.City = model.City;
                member.BirthDate = model.BirthDate;
                member.SportTypes = model.SportTypes;
                member.Age = memberAge;
                            
                DBContext.SaveChanges();

                return View(member);
            }

            return View();
        }

        [HttpGet]
        public ActionResult DeleteMember(int? MemberID)
        {
            var member = DBContext.Members.Find(MemberID);

            return View(member);
        }

        [HttpPost, ActionName("DeleteMember")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMemberPost(int? MemberID)
        {
            ViewBag.Message = "";

            var member = DBContext.Members.Find(MemberID);

            if (MemberID == null)
            {
                ViewBag.TextColor = "Red";
                ViewBag.Message = "Medlem eksisterer ikke";

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                DBContext.Members.Remove(member);
                DBContext.SaveChanges();

                ViewBag.TextColor = "Green";
                ViewBag.Message = "Medlem slettet";

                return RedirectToAction("RegisteredMembers");
            }

            ViewBag.TextColor = "Red";
            ViewBag.Message = "Medlem blev ikke slettet. Prøv venlist igen";

            return View();
        }

        [HttpGet]
        public ActionResult MemberDetails(int MemberID)
        {
            var member = DBContext.Members.Find(MemberID);

            return View(member);
        }
    }
}