using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Models;
namespace AMS.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            DashboardContext msc = new DashboardContext();
            DBMultiview dmv = new DBMultiview();
            dmv.dbhwastdet = msc.dbhwastdetail.ToList();
            

            return View(dmv);
        }
        public ActionResult DashboardSoft()
        {
            DashboardContext msc = new DashboardContext();
            DBMultiview dmv = new DBMultiview();
            dmv.dbswastdet = msc.dbswastdetail.ToList();
            return View(dmv);
        }
    }
}