using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Models;
namespace AMS.Controllers
{
    public class SoftwareController : Controller
    {
        //[Authorize]
        // GET: Software
        
        public ActionResult Index()
        {
            return View();
        }
        //Master Loading
        
        public ActionResult SwAssetDetail()
        {
            MasterContext msc = new MasterContext();
            ViewBag.swcatg = msc.CatgDet.Where(a => a.CATGTYPE == 2);
            ViewBag.vendor = msc.VendorDet;
            return View();
        }

        public ActionResult SwAssetIns(SwAsset swast)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    SoftwareBL mbl = new SoftwareBL();
                    UpdateModel<SwAsset>(swast);
                    mbl.AddSwAsset(swast);
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
        public ActionResult SoftwareGet(string softcode)
        {

            MasterContext msc = new MasterContext();
            ViewBag.swcatg = msc.CatgDet.Where(a => a.CATGTYPE == 2);
            ViewBag.vendor = msc.VendorDet;
            SoftwareContext swtrcontext = new SoftwareContext();
            SwAsset sw = swtrcontext.swdet.FirstOrDefault(x => x.ASSETTAG == softcode);
            //mst.DATELASTMN = mst.DATELASTMN.Substring(6, 2) + "-" + mst.DATELASTMN.Substring(4, 2) + "-" + mst.DATELASTMN.Substring(0, 4);
            return View("SwAssetDetail", sw);
        }

        public ActionResult SlnoVal(string slno)
        {
            SoftwareContext swc = new SoftwareContext();
            SwAsset slno1 = swc.swdet.FirstOrDefault(x => x.SLNO == slno);
            string divis;
            if (slno1 != null)
            {
                divis = "Serial Number already Exist";
                return Json(divis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                divis = "";
                return Json(divis, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SoftwareList()
        {
            SoftwareContext swc = new SoftwareContext();
            IEnumerable<SwAsset> swasst = swc.swdet.ToList();
            return View(swasst);
        }
    }
}