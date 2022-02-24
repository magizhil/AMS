using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Hosting;
using AMS.Models;
namespace AMS.Controllers
{
    public class ContractController : Controller
    {
        // GET: Contract
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CntTypeDet()
        {
            
            List<int> Years = new List<int>();
            int i;

            DateTime startyr = DateTime.Now;
            for (i = startyr.Year; i >= startyr.Year - 10; i--)
            {
                Years.Add(i);
            }
            ViewBag.Years = Years;
            MasterContext msc = new MasterContext();
            ViewBag.cnttype = msc.CntDet;
            return View();
        }
        public ActionResult ContractDet()
        {
            CntTypeDet();
            return View();
        }

        #region Auto Fill Vendor Get
        public JsonResult GetVendorDet(string vendid)
        {
            MasterContext msc = new MasterContext();
            HardwareContext hw = new HardwareContext();
            var vendor = msc.VendorDet.Where(a => a.INACTIVE == 0);
            var venddetail = (from ven in vendor where ven.VENDID.Contains(vendid) || ven.VENDNAME.Contains(vendid) select new { ven.VENDID, ven.VENDNAME });
            return Json(venddetail, JsonRequestBehavior.AllowGet);
        }

        public JsonResult VendorGet(string venid) {
            MasterContext msc = new MasterContext();
            var vendor = msc.VendorDet.FirstOrDefault(a => a.VENDID == venid);
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CntIns(CntDetails cntins)
        {
            string message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    ContractBL mbl = new ContractBL();
                    UpdateModel<CntDetails>(cntins);
                    mbl.AddCnt(cntins);
                    message = mbl.message;
                    string temp = Server.MapPath("~/Images/Invoices/"+ message.Substring(0, 13));
                    Directory.CreateDirectory(temp);

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

        public ActionResult ContractGet(string cntnumber)
        {
            List<int> Years = new List<int>();
            int i;

            DateTime startyr = DateTime.Now;
            for (i = startyr.Year; i >= startyr.Year - 10; i--)
            {
                Years.Add(i);
            }
            ViewBag.Years = Years;
            MasterContext msc = new MasterContext();
            ViewBag.cnttype = msc.CntDet;
            ContractContext cntcont = new ContractContext();
            CntDetails cntvalue = cntcont.cntdetail.FirstOrDefault(x => x.CNTNUMBER == cntnumber);
            return View("ContractDet", cntvalue);
        }

        
        public ActionResult CntDocLoad(string cntno)
        {
            ContractContext cntcont = new ContractContext();
            CntDetails cntval = cntcont.cntdetail.FirstOrDefault(x => x.CNTNUMBER == cntno);
            return View("CntDocLoad",cntval);
        }
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
                    var _comPath = Server.MapPath("/Images/Invoices/") + pdf.FileName; // + _ext;
                    _pdfname = fileName; // + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pdf.SaveAs(path);


                }
            }
            return Json(Convert.ToString(_pdfname), JsonRequestBehavior.AllowGet);
        }

        public List<CntFileInfo> GetFiles(string cntno)
        {
            List<CntFileInfo> lstfiles = new List<CntFileInfo>();
            DirectoryInfo dirinfo = new DirectoryInfo(HostingEnvironment.MapPath("~/Images/Invoices/"+cntno));
            int i = 0;
            foreach (var item in dirinfo.GetFiles())
            {
                lstfiles.Add(new CntFileInfo()
                {

                    fileId = i + 1,
                    filename = item.Name,
                    filepath = dirinfo.FullName + @"\" + item.Name
                });
                i = i + 1;
            }
            return lstfiles;
        }
        public ActionResult FileView(string cntnumber)
        {
            var filecollection = GetFiles(cntnumber);
            return View(filecollection);
        }

        public FileResult Download(string FileName)
        {
            //    int CurrentFileID = Convert.ToInt32(FileID);
            //var filesCol = obj.GetFiles();
            string CurrentFileName = FileName;


            string contentType = string.Empty;

            if (CurrentFileName.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }

            else if (CurrentFileName.Contains(".docx"))
            {
                contentType = "application/docx";
            }
            return File(CurrentFileName, contentType, "CntDocument.pdf");
        }

        #endregion

        public ActionResult ContractView()
        {
            ContractContext cntcont = new ContractContext();
            IEnumerable<CntDetails> cnt = cntcont.cntdetail.ToList();
            return View(cnt);
        }
        public ActionResult ContractHistory()
        {
            ContractContext cntcont = new ContractContext();
            IEnumerable<CntHistory> cnhist = cntcont.cnthist.ToList();
            return View(cnhist);
        }
    }
}