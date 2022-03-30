using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMSMVC.Models;

namespace LibraryMSMVC.Controllers
{
    public class UserController : Controller
    {
        LibraryMVCEntities userDb = new LibraryMVCEntities();

        // Returns user login view, here admin can login.
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Checks user credentials, redirecting to admin section (index, tblBooks). 
        [HttpPost]
        public ActionResult Login(Registration registration)
        {
            var adm = userDb.Registrations.SingleOrDefault(a => a.UserEmail == registration.UserEmail && a.UserPass == registration.UserPass);
            if (adm != null)
            {
                Session["userId"] = adm.UserId;
                Session["userName"] = adm.UserName;
                return RedirectToAction("Index", "Borrow", new { userId = adm.UserId, userName = adm.UserName });
            }
            else if (registration.UserEmail == null && registration.UserPass == null)
            {
                return View();
            }
            ViewBag.Message = "User name and password are not matching";
            return View();
        }

      

        // User logout, redirect to main. 
        public ActionResult Logout()
        {
            Session.Remove("userId");
            Session.Remove("userName");
            return RedirectToAction("Home", "Main");
        }
    }
}
