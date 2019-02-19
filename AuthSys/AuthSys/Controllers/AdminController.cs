using AuthSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthSys.ViewModels;

namespace AuthSys.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAdmin()
        {
            return View("AddAdmin");
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminViewModel model)
        {
            return View("AddAdmin");
        }
    }
}