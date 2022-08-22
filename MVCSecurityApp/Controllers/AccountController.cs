using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSecurityApp.Models;
using System.Web.Security;//namespace for Security related classes/interfaces

namespace MVCSecurityApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        CollegeDbEntities1 db = new CollegeDbEntities1();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        //For login
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                Login luser=db.Logins
                              .SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                if (luser != null)
                {
                    //Generate Authentication Ticket after user Authentication from DB
                    // FormsAuthentication.SetAuthCookie(login.Username, true);
                    FormsAuthentication.SetAuthCookie(login.Username, false);
                    //default URL/Action to redirect
                    return RedirectToAction("Index", "Students");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username/Password");
                    return View(login);
                }
            }
            return View(login);
        }


        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        //for signout
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            //return View("Login");
            return RedirectToAction("Login");
        }
    }
}