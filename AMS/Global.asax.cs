﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using System.Web.Security;

namespace AMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<AMS.Models.MasterContext>(null);
            Database.SetInitializer<AMS.Models.SoftwareContext>(null);
            Database.SetInitializer<AMS.Models.HardwareContext>(null);
            Database.SetInitializer<AMS.Models.AssignContext>(null);
            Database.SetInitializer <AMS.Models.DashboardContext>(null);
            Database.SetInitializer<AMS.Models.ContractContext>(null);
        }

        //protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        //{
        //    var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        //    if (authCookie != null)
        //    {
        //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        //        if (authTicket != null && !authTicket.Expired)
        //        {
        //            var roles = authTicket.UserData.Split(',');
        //            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
        //        }
        //    }
        //}
    }
}
