using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Models;
namespace AMS.Controllers
{
    public class HardwareController : Controller
    {
        // GET: Hardware
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HwAssetDetail()
        {
            MasterContext msc = new MasterContext();
            ViewBag.hwcatg = msc.CatgDet.Where(a => a.CATGTYPE == 1);
            ViewBag.vendor = msc.VendorDet;
            return View();
        }
        public ActionResult HwAssetIns(HwAsset hwast)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    HardwareBL mbl = new HardwareBL();
                    UpdateModel<HwAsset>(hwast);
                    mbl.AddHwAsset(hwast);
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
        public ActionResult HardwareGet(string hardcode)
        {

            HwAssetDetail();
            HardwareContext hwcontext = new HardwareContext();
            HwAsset hw = hwcontext.hwdet.FirstOrDefault(x => x.ASSETTAG == hardcode);
            //mst.DATELASTMN = mst.DATELASTMN.Substring(6, 2) + "-" + mst.DATELASTMN.Substring(4, 2) + "-" + mst.DATELASTMN.Substring(0, 4);
            return View("HwAssetDetail", hw);
        }
        public ActionResult HwSlnoVal(string slno)
        {
            HardwareContext hwc = new HardwareContext();
            HwAsset slno1 = hwc.hwdet.FirstOrDefault(x => x.SLNO == slno);
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
        public ActionResult HardwareList()
        {
            HardwareContext hwc = new HardwareContext();
            IEnumerable<HwAsset> hwasst = hwc.hwdet.ToList();
            return View(hwasst);
        }

    }
}