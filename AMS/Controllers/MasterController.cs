using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;
using AMS.Models;

namespace AMS.Controllers
{
    [Authorize]
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        #region Vendor List
        public ActionResult VendorDet()
        {
            return View();
        }
        public ActionResult VendorList()
        {
            MasterContext msc = new MasterContext();
            IEnumerable<MsVendor> venlist = msc.VendorDet.ToList();
            return View(venlist);
        }
        public ActionResult VendorIns(MsVendor vend)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    MasterBL mbl = new MasterBL();
                    UpdateModel<MsVendor>(vend);
                    mbl.AddVendor(vend);
                    message = mbl.message;
                }

            }
            catch
            {
                message = "something went wrong,Contact Administrator";
                Response.Write(message);
            }
            ModelState.Clear();
            return Json(message);
        }
        public ActionResult VendorGet(string vendcode)
        {
            MasterContext mstrcontext = new MasterContext();
            MsVendor ven = mstrcontext.VendorDet.FirstOrDefault(x => x.VENDID == vendcode);
            //mst.DATELASTMN = mst.DATELASTMN.Substring(6, 2) + "-" + mst.DATELASTMN.Substring(4, 2) + "-" + mst.DATELASTMN.Substring(0, 4);
            return View("VendorDet", ven);
        }
        public ActionResult Deletevend(string id)
        {
            string message = "";
            MasterContext msc = new MasterContext();
            MasterBL mbl = new MasterBL();
            mbl.DelVendor(id);
            message = mbl.message;
            ModelState.Clear();
            //List<Vendor> lstvend = new List<Vendor>();
            return Json(message);
        }
        #endregion

        #region Category Master
        public ActionResult CatgDet()
        {
            return View();
        }
        public ActionResult CatgIns(MsCategory catins)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    MasterBL mbl = new MasterBL();
                    UpdateModel<MsCategory>(catins);
                    mbl.AddCatg(catins);
                    message = mbl.message;
                }

            }
            catch
            {
                message = "something went wrong,Contact Administrator";
                Response.Write(message);
            }
            ModelState.Clear();
            return Json(message);
        }
        public ActionResult CatgGet(string catcode)
        {
            MasterContext mstrcontext = new MasterContext();
            MsCategory catgdet = mstrcontext.CatgDet.FirstOrDefault(x => x.CATGNAME == catcode);
            //mst.DATELASTMN = mst.DATELASTMN.Substring(6, 2) + "-" + mst.DATELASTMN.Substring(4, 2) + "-" + mst.DATELASTMN.Substring(0, 4);
            return View("CatgDet", catgdet);
        }
        public ActionResult CatgList()
        {
            MasterContext msc = new MasterContext();
            IEnumerable<MsCategory> mscatg = msc.CatgDet.ToList();
            return View(mscatg);
        }
        public ActionResult DelCatg(string id)
        {
            string message = "";
            MasterContext msc = new MasterContext();
            MasterBL mbl = new MasterBL();
            mbl.DelCatg(id);
            message = mbl.message;
            ModelState.Clear();
            return Json(message);
        }
        #endregion

        #region Contract Type
        public ActionResult CntType()
        {
            return View();
        }

        public ActionResult CntIns(MsCnttype cntins)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    MasterBL mbl = new MasterBL();
                    UpdateModel<MsCnttype>(cntins);
                    mbl.AddCntType(cntins);
                    message = mbl.message;
                }

            }
            catch (Exception ex)
            {
                message = ex.ToString();
                Response.Write(message);
            }
            ModelState.Clear();
            return Json(message);
        }

        public ActionResult CntGet(string cntname)
        {
            MasterContext mstrcontext = new MasterContext();
            MsCnttype cntdet = mstrcontext.CntDet.FirstOrDefault(x => x.CNTTYPE == cntname);
            //mst.DATELASTMN = mst.DATELASTMN.Substring(6, 2) + "-" + mst.DATELASTMN.Substring(4, 2) + "-" + mst.DATELASTMN.Substring(0, 4);
            return View("CntType", cntdet);
        }

        public ActionResult CntList()
        {
            MasterContext msc = new MasterContext();
            IEnumerable<MsCnttype> mscnttype = msc.CntDet.ToList();
            return View(mscnttype);
        }

        public ActionResult DelCnttype(string cntname)
        {
            string message = "";
            MasterContext msc = new MasterContext();
            MasterBL mbl = new MasterBL();
            mbl.DelCntType(cntname);
            message = mbl.message;
            ModelState.Clear();
            return Json(message);
        }

        #endregion

        #region  Invoice Upload

        #region Upload Screen 
        public ActionResult InvUpload()
        {
            
            return View();

        }
        #endregion
                
        #region Auto Fill Master Get
        public JsonResult GetHwAstDet(string invvalue)
        {
            HardwareContext hw = new HardwareContext();
            var hardware = hw.hwdet;
            var invnumber = (from inv in hardware where inv.ASSETTAG.Contains(invvalue) || inv.INVOICENUMBER.Contains(invvalue) || inv.SLNO.Contains(invvalue) select new { inv.ASSETTAG, inv.INVOICENUMBER, inv.SLNO });
            return Json(invnumber, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSwAstDet(string invvalue)
        {
            SoftwareContext sw = new SoftwareContext();
            var software = sw.swdet;
            var invnumber = (from inv in software where inv.ASSETTAG.Contains(invvalue) || inv.INVOICENUMBER.Contains(invvalue) || inv.SLNO.Contains(invvalue) select new { inv.ASSETTAG, inv.INVOICENUMBER, inv.SLNO });
            return Json(invnumber, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Asset Get Information
        public JsonResult HwAstGet(string asttag)
        {
            HardwareContext hw = new HardwareContext();
            var hardware = hw.hwdet;
            var assetno = hw.hwdet.FirstOrDefault(x => x.ASSETTAG == asttag);
            return Json(assetno.INVOICENUMBER, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SwAstGet(string asttag)
        {
            SoftwareContext sw = new SoftwareContext();
            var software = sw.swdet;
            var assetno = sw.swdet.FirstOrDefault(x => x.ASSETTAG == asttag);
            return Json(assetno.INVOICENUMBER, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Invoice Upload
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile(string pdfvalue)
        {
            string _pdfname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pdf = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pdf.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pdf.FileName);
                    //string strName = empcodeval;
                    //var fileName = strName;
                    //var _ext = Path.GetExtension(pic.FileName);

                    _pdfname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/Images/Invoices/") + fileName; // + _ext;
                    _pdfname = fileName; // + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pdf.SaveAs(path);


                }
            }
            return Json(Convert.ToString(_pdfname), JsonRequestBehavior.AllowGet);
        }

        #region Invoice Insert
        public ActionResult InvIns(AstInvoice astinv)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    MasterBL mbl = new MasterBL();
                    UpdateModel<AstInvoice>(astinv);
                    mbl.InvUplInfo(astinv);
                    message = mbl.message;
                }

            }
            catch
            {
                message = "something went wrong,Contact Administrator";
                Response.Write(message);
            }
            ModelState.Clear();
            return Json(message);
        }
        #endregion


        #endregion

        #region Invoice View
        public ActionResult InvoiceView()
        {
            MasterContext msc = new MasterContext();
            IEnumerable<AstInvoice> astview = msc.astinv.ToList();
            return View(astview);
        }
        #endregion

        #region Asset Get
        public ActionResult AssetGet(string assetcode)
        {
            HardwareContext hwcontext = new HardwareContext();
            HwAsset hw = hwcontext.hwdet.FirstOrDefault(x => x.ASSETTAG == assetcode);
            MasterContext msc = new MasterContext();
            AstInvoice astinv = new AstInvoice();
            astinv.ASSETTAG = hw.ASSETTAG;
            astinv.INVOICENUMBER = hw.INVOICENUMBER;
            return View("InvUpload", astinv);
        }

        #endregion

        #endregion

    }
}