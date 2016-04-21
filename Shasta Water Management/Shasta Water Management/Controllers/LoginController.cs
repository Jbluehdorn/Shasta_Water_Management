using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shasta_Water_Management.Filters;
using Shasta_Water_Management.Models;
using Shasta_Water_Management.Properties;

namespace Shasta_Water_Management.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        [SkipLoginFilter]
        [HttpPost]
        public ActionResult LoginAttempt(string Username, string Password)
        {
            if (Username == Settings.Default.UserName && Password == Settings.Default.Password)
            {
                GlobalVariables.LoggedIn = "Y";
            }

            return Redirect("/");
            return Json("Log in failed!", JsonRequestBehavior.AllowGet);
        }
    }
}