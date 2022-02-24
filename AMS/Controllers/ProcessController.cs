using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Models;
namespace AMS.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PrsGrp()
        {
            ProcessContext prs = new ProcessContext();
            IEnumerable<ProcessGrp> prsgrpdet = prs.prsgrp.OrderBy(a=>a.SORTORD).ToList();
            return View(prsgrpdet);
        }
        public ActionResult PrsGrpAdd()
        {
            return View();
        }
        public ActionResult prsgrpIns(ProcessGrp prsgrpins)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    ProcessBL mbl = new ProcessBL();
                    UpdateModel<ProcessGrp>(prsgrpins);
                    mbl.AddGrp(prsgrpins);
                    message = mbl.message;
                }

            }
            catch (Exception ex)
            {
                message = ex.ToString();
                //message = "something went wrong,Contact Administrator";
                Response.Write(message);
            }
            ModelState.Clear();
            return Json(message);
        }
        public ActionResult prsgrpGet(string grpname)
        {
            ProcessContext pscont = new ProcessContext();
            ProcessGrp psgrp = pscont.prsgrp.FirstOrDefault(x => x.CHKGRPNAME == grpname);
            return View("PrsGrpAdd", psgrp);
        }
        public ActionResult prslist()
        {
            ProcessContext prs = new ProcessContext();
            //ViewBag.grpdet = prs.prsgrp.Where(a => a.INACTIVE == 0);
            IEnumerable<ProcessGrp> prslst = prs.prsgrp.ToList();
            return View(prslst);
        }
        public ActionResult prslistview(string grpid)
        {
            ProcessContext prs = new ProcessContext();
            IEnumerable<ProcessGrp> ggval = prs.prsgrp.ToList();
            var selectedCourseId = (from c in ggval where c.CHKGRPNAME == grpid select c.CHKGRPID).FirstOrDefault();

            IEnumerable<ProcessList> ppval = prs.prslist.ToList();
            var studentsInCourse = ppval.Where(c => c.CHKGRPID == selectedCourseId).OrderBy(a=>a.SORTORD).ToList();

            return PartialView("_ListView", studentsInCourse);
        }
        public ActionResult prslistAdd()
        {
            ProcessContext prs = new ProcessContext();
            ViewBag.grpdet = prs.prsgrp.Where(a => a.INACTIVE == 0);
            return View();
        }
        public ActionResult prslistIns(ProcessList listname)
        {
            ProcessContext prs = new ProcessContext();
            ViewBag.grpdet = prs.prsgrp.Where(a => a.INACTIVE == 0);
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    ProcessBL mbl = new ProcessBL();
                    UpdateModel<ProcessList>(listname);
                    mbl.AddList(listname);
                    message = mbl.message;
                }

            }
            catch (Exception ex)
            {
                message = ex.ToString();
                //message = "something went wrong,Contact Administrator";
                Response.Write(message);
            }
            ModelState.Clear();
            return Json(message);
        }
        public ActionResult prslistGet(string listname)
        {
            ProcessContext pscont = new ProcessContext();
            ViewBag.grpdet = pscont.prsgrp.Where(a => a.INACTIVE == 0);
            ProcessList pslst = pscont.prslist.FirstOrDefault(x => x.CHKLISTTIT == listname);
            return View("prslistAdd", pslst);
        }
        public ActionResult ProcessView()
        {
            ProcessContext prs = new ProcessContext();
            IEnumerable<ProcessGrp> prsview = prs.prsgrp.ToList();
            return View(prsview);
        }
        public ActionResult ProcessGet(int grpid)
        {
            ProcessContext prs = new ProcessContext();
            IEnumerable<ProcessGrp> ggval = prs.prsgrp.ToList();
            var selectedCourseId = (from c in ggval where c.CHKGRPID == grpid select c.CHKGRPID).FirstOrDefault();

            IEnumerable<ProcessList> ppval = prs.prslist.ToList();
            var studentsInCourse = ppval.Where(c => c.CHKGRPID == selectedCourseId).ToList();

            return PartialView("_ProcessList", studentsInCourse);
        }
        public ActionResult Delprslist(string id)
        {
            string message = "";
            ProcessContext msc = new ProcessContext();
            ProcessBL mbl = new ProcessBL();
            mbl.DeleteList(id);
            message = "Data Deleted Sucessfully";
            ModelState.Clear();
            //List<Vendor> lstvend = new List<Vendor>();
            return Json(message);
        }
        public ActionResult userack(string name)
        {
            string message = "";
            ProcessContext msc = new ProcessContext();
            ProcessBL mbl = new ProcessBL();
            mbl.userack(name);
            message = mbl.message;
            ModelState.Clear();
            return Json(message);
        }
        public ActionResult SuggBox()
        {
            return View();
        }
        public ActionResult SuggBoxIns(string sugg)
        {
            string message = "";
            ProcessContext msc = new ProcessContext();
            ProcessBL mbl = new ProcessBL();
            mbl.usrsugg(sugg);
            message = "Thanks for your valuable feedback";
            ModelState.Clear();
            return Json(message);
        }
        public ActionResult SuggBoxList()
        {
            ProcessContext prs = new ProcessContext();
            //ViewBag.grpdet = prs.prsgrp.Where(a => a.INACTIVE == 0);
            IEnumerable<PrsUsersug> suglist = prs.prsusrsug.Where(a=>a.READED==0).ToList();
            return View(suglist);

        }
        public ActionResult SuggBoxRmv(int id)
        {
            string message = "";
            ProcessContext msc = new ProcessContext();
            ProcessBL mbl = new ProcessBL();
            mbl.usrsugupd(id);
            message = "Data Readed";
            ModelState.Clear();
            return Json(message);
        }
        public ActionResult UserCount()
        {
            ProcessContext prs = new ProcessContext();
            //ViewBag.grpdet = prs.prsgrp.Where(a => a.INACTIVE == 0);
            IEnumerable<ProcessGrp> prslst = prs.prsgrp.ToList();
            return View(prslst);
        }
        public ActionResult UserCountview(string grpid)
        {
            ProcessContext prs = new ProcessContext();
            IEnumerable<ProcessGrp> ggval = prs.prsgrp.ToList();
            var selectedCourseId = (from c in ggval where c.CHKGRPNAME == grpid select c.CHKGRPNAME).FirstOrDefault();

            IEnumerable<PrsUserread> ppval = prs.prsusrread.ToList();
            var studentsInCourse = ppval.Where(c => c.CHKGRPNAME == selectedCourseId).ToList();

            return PartialView("_UserCount", studentsInCourse);
        }
    }
}