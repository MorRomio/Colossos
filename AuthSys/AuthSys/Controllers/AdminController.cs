using AuthSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthSys.ViewModels;
using System.Data.Entity;
using AuthSys.DataAccessLayer;

namespace AuthSys.Controllers
{
    public class AdminController : Controller
    {
        private ColossosContext DBContext = new ColossosContext();

        [HttpGet]
        public ActionResult AddAdmin()
        {
            DataAccessLayer.ColossosContext col = new DataAccessLayer.ColossosContext();

            List<Roles> list = new List<Roles>(col.Roles.ToList());
            AdminViewModel viewMod = new AdminViewModel();                         

            //viewMod.Roles = new SelectList(list);

            viewMod.Roles = col.Roles.ToList().Select(x => new SelectListItem()
            {
                 Value = x.RoleName,
                 Text = "Vælg en rolle..."
            }).ToList();
            
            return View(viewMod);
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminViewModel model)
        {
            //var selectedVal = new SelectList(model.Roles);
            var admin = new Admin();

            if(ModelState.IsValid) 
            {
                 admin = new Admin()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MemberEmail = model.MemberEmail,
                    Password = "Test",
                    RoleName = model.RoleName                    
                };

                DBContext.Admin.Add(admin);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditAdmin(EditMemberViewModel model)
        {
            Admin admin = new Admin();
           

            return View(admin);
        }

        [HttpGet]
        public ActionResult DeleteAdmin(int? MemberID)
        {
            

            return View();
        }
    }
}