using AuthSys.DataAccessLayer;
using AuthSys.Models;
using AuthSys.Helpers;
using System.Collections.Generic;
using System.Web.Mvc;
using AuthSys.ViewModels;
using System;
using System.Net;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Microsoft.AspNet.SignalR;
using AuthSys.SignalRhub;

namespace AuthSys.Controllers
{
    public class MemberController : Controller
    {
        private ColossosContext DBContext = new ColossosContext();
        private HubSignalR signalR = new HubSignalR();       

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

            if (member.HasCard.Equals("Nej"))
            {
                ViewBag.CardAttached = "Nej";
            }
            else
            {
                ViewBag.CardAttached = "Ja";
            }   

            return View(member);
        }

        public void UseSignalRToNotifyClients(string msg)
        {
            GlobalHost.ConnectionManager.GetHubContext<HubSignalR>().Clients.All.addMessageToPage(msg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent cross-site request forgery
        public ActionResult EditMember(Member model)
        {
            var member = DBContext.Members.Find(model.MemberID);

            DateTime today = DateTime.Now;
            double days = today.Subtract(model.BirthDate).TotalDays;
            int memberAge = (int)Math.Truncate(days / 365);

            
            var thisMembersCard = DBContext.Cards.SingleOrDefault(x => x.MemberID == model.MemberID);

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

                if(!string.IsNullOrEmpty(model.AssociatedCard))
                {
                    member.AssociatedCard = model.AssociatedCard;
                    thisMembersCard.CreationDate = DateTime.Today;
                    member.HasCard = (model.HasCard.Equals("Ja") ? model.HasCard: "Nej");

                    //We have asked to remove card from user
                    if (!member.HasCard.Equals("Ja") && thisMembersCard != null)
                    {
                        DBContext.Cards.Remove(thisMembersCard);
                        member.AssociatedCard = null;
                        member.Card = null;

                        ViewBag.CardAttached = "Nej";
                    }
                    else
                    {
                        ViewBag.CardAttached ="Ja";
                    }
                }                
                            
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

        public ActionResult AttachCard(int MemberID)
        {
            var member = DBContext.Members.Find(MemberID);

            CardAndMemberViewModel viewModel = new CardAndMemberViewModel()
            {
                FirstName = member.FirstName,
                LastName = member.LastName
            };

            return View(viewModel);  
        }

        [HttpPost]
        public ActionResult AttachCard(Card model, int MemberID)
        {
            var card = new Card()
            {
                MemberID = MemberID,
                CreationDate = DateTime.Today,
                CardID = model.CardID
            };

            var member = DBContext.Members.Find(MemberID);

            if(ModelState.IsValid)
            {
                member.AssociatedCard = model.CardID;
                card.MemberID = MemberID;
                card.CardID = model.CardID;
                member.Card = card;
                member.HasCard = "Ja";

                try
                {
                    DBContext.Cards.Add(card);
                    DBContext.SaveChanges();

                    ViewBag.TextColor = "Green";
                    ViewBag.Message = "Kort tilføjet";

                    signalR.CardAdded();

                } catch(DbUpdateException dbe)
                {
                    //Vis dialog 
                    signalR.CardAdded();
                    ViewBag.TextColor = "Red";
                    ViewBag.Message = "Kort eksisterer allerede. Slet det først";

                } catch(DbEntityValidationException dde)
                {
                    ViewBag.TextColor = "Red";
                    ViewBag.Message = "Validation exception (No card was typed in)";
                    signalR.CardAdded();
                }
                
            }

            return View();                   
        }                
    }
}