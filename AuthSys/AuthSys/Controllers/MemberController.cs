using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthSys.Controllers
{
    public class MemberController : Controller
    {        
        // GET: Member
        public ActionResult AddMember(/*string fName, string lName, string sportTypes, int age, DateTime birthDate*/)
        {
            return View();
        }

        public ActionResult RegisteredMembers()
        {
            return View();
        }

        public ActionResult EditMember()
        {
            return View();
        }
    }
}