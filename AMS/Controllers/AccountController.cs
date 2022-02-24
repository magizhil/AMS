using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AMS.Models;
using System.Web.Security;

namespace AMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogVal()
        {
            string username = User.Identity.GetUserName();
            AccountContext act = new AccountContext();
            Users usrdet = act.usrdet.FirstOrDefault(x => x.Name == username );
            if (username != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);

                var authTicket = new FormsAuthenticationTicket(1, usrdet.Name, DateTime.Now, DateTime.Now.AddMinutes(20), false, usrdet.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                return RedirectToAction("DashboardSoft", "Dashboard");
            }
            
        }
    }
}