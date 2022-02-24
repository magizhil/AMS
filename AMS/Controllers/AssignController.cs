using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Models;
namespace AMS.Controllers
{
    public class AssignController : Controller
    {
        // GET: Assign
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AssignAsset()
        {
            initload();
            return View();
        }
        #region Intial Load
        public void initload()
        {

            AssignContext asg = new AssignContext();
            ViewBag.AssignDet1 = asg.astdet1.Where(x => x.MASSETTAG == "").ToList();
            ViewBag.AssignDet2 = asg.astdet2.Where(x => x.MASSETTAG == "").ToList();
            ViewBag.AssignDet3 = asg.astdet3.Where(x => x.MASSETTAG == "").ToList();

        }
        #endregion

        #region AssginRecord
        public void AssignDetRec(string asttag, AstAsgMultiview asgval)
        {
            HardwareContext hw = new HardwareContext();
            asgval.HwAssetDet = hw.hwdet.Where(x => x.SERIALIZED == 1 && x.HWSTS != 4).FirstOrDefault(x => x.ASSETTAG == asttag);
            AssignContext asgg = new AssignContext();
            ViewBag.AssignDet1 = asgg.astdet1.Where(x => x.MASSETTAG == asttag).ToList();
            ViewBag.AssignDet2 = asgg.astdet2.Where(x => x.MASSETTAG == asttag).ToList();
            ViewBag.AssignDet3 = asgg.astdet3.Where(x => x.MASSETTAG == asttag).ToList();
        }

        #endregion

        #region Asset Get
        public ActionResult AsgGet(string asttag, AstAsgMultiview asgval)
        {
            AssignDetRec(asttag, asgval);
            return View("AssignAsset", asgval);
        }
        #endregion

        #region Asset Get Det 1
        public ActionResult AsgGetD1(string asttag)
        {
            HardwareContext hwc = new HardwareContext();
            if (asttag != "")
            {

                HwAsset hwastdet = hwc.hwdet.FirstOrDefault(x => x.ASSETTAG == asttag);
                if (hwastdet != null)
                {
                    var divhwasg = new { hwcatgname = hwastdet.CATGNAME, hwbrand = hwastdet.BRAND, hwmdlname = hwastdet.MDLNAME, hwslno = hwastdet.SLNO, hwserialized = hwastdet.SERIALIZED , hwqty=hwastdet.QTY };
                    return Json(divhwasg, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Asset Get Det 2
        public ActionResult AsgGetD2(string asttag)
        {
            SoftwareContext swc = new SoftwareContext();
            if (asttag != "")
            {
                SwAsset swastdet = swc.swdet.FirstOrDefault(x => x.ASSETTAG == asttag);
                if (swastdet != null)
                {
                    var divswasg = new { swcatgname = swastdet.CATGNAME, swbrand = swastdet.BRAND, swmdlname = swastdet.MDLNAME, swslno = swastdet.SLNO, swqty = swastdet.USRLIC + swastdet.MACLIC };
                    return Json(divswasg, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Asset Get Det 3
        public ActionResult AsgGetD3(string empcode)
        {
            AssignContext asg = new AssignContext();
            if (empcode != "")
            {
                AstAsgDet3 asgdet3= asg.astdet3.FirstOrDefault(x => x.EMPCODE == empcode);
                if (asgdet3 != null)
                {
                    var divempasg = new { empasgcode = asgdet3.EMPCODE, empasgasset=asgdet3.MASSETTAG };
                    return Json(divempasg, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Assign Detail 1

        public ActionResult AsgHwIns(AstAsgMultiview asghwins)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    AssignBL ashwbl = new AssignBL();
                    UpdateModel<AstAsgMultiview>(asghwins);
                    ashwbl.AssignHw(asghwins);
                    message = ashwbl.message;
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                Response.Write(message);
            }
            ModelState.Clear();

            List<AstAsgMultiview> lstAsgMulView = new List<AstAsgMultiview>();
            AssignDetRec(asghwins.HwAssetDet.ASSETTAG, asghwins);
            lstAsgMulView.Add(asghwins);
            return View("_AssignHwDet", lstAsgMulView);
        }
        #endregion

        #region Assign Detail2
        public ActionResult AsgSwIns(AstAsgMultiview asgswins)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    AssignBL asswbl = new AssignBL();
                    UpdateModel<AstAsgMultiview>(asgswins);
                    asswbl.AssignSw(asgswins);
                    message = asswbl.message;
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                Response.Write(message);
            }
            ModelState.Clear();

            List<AstAsgMultiview> lstAsgMulViewsw = new List<AstAsgMultiview>();
            AssignDetRec(asgswins.HwAssetDet.ASSETTAG, asgswins);
            lstAsgMulViewsw.Add(asgswins);
            return View("_AssignSwDet", lstAsgMulViewsw);
        }
        #endregion

        #region Assign Detail3
        public ActionResult AsgEmpIns(AstAsgMultiview asgempins)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    AssignBL asbl = new AssignBL();
                    UpdateModel<AstAsgMultiview>(asgempins);
                    asbl.AssignEmp(asgempins);
                    message = asbl.message;
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                Response.Write(message);
            }
            ModelState.Clear();

            List<AstAsgMultiview> lstAsgMulView = new List<AstAsgMultiview>();
            AssignDetRec(asgempins.HwAssetDet.ASSETTAG, asgempins);
            lstAsgMulView.Add(asgempins);
            return View("_AssignEmpDet", lstAsgMulView);
        }
        #endregion

        #region Auto Fill Master Get
        public JsonResult GetMasteDet(string invvalue)
        {
            HardwareContext hw = new HardwareContext();
            var hardware = hw.hwdet.Where(a => a.SERIALIZED == 1 && a.HWSTS != 4);
            var invnumber = (from inv in hardware where inv.ASSETTAG.Contains(invvalue) || inv.CATGNAME.Contains(invvalue) || inv.SLNO.Contains(invvalue) select new { inv.ASSETTAG, inv.CATGNAME, inv.SLNO });
            return Json(invnumber, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Auto Fill Asset Get 1
        public JsonResult GetAssetDet1(string inhwval)
        {
            HardwareContext hw = new HardwareContext();
            var hardet = hw.hwdet.Where(a => a.HWSTS == 1);
            var invhwnumber= (from inv in hardet where inv.ASSETTAG.Contains(inhwval) || inv.CATGNAME.Contains(inhwval) || inv.SLNO.Contains(inhwval) select new { inv.ASSETTAG, inv.CATGNAME, inv.SLNO });
            return Json(invhwnumber, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Auto Fill Asset Get 2
        public JsonResult GetAssetDet2(string inswval)
        {
            SoftwareContext sw = new SoftwareContext();
            var softdet = sw.swdet.Where(a => a.SWSTS == 1);
            var invswnumber = (from inv in softdet where inv.ASSETTAG.Contains(inswval) || inv.CATGNAME.Contains(inswval) || inv.SLNO.Contains(inswval) select new { inv.ASSETTAG, inv.CATGNAME, inv.SLNO });
            return Json(invswnumber, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}