using OnlineExamCenter.App_Start;
using OnlineExamCenter.Manager;
using OnlineExamCenter.Models;
using OnlineExamCenter.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamCenter.Controllers
{
    //[SessionExpire]
    public class LicensePackageController : Controller
    {
        // GET: LicensePackage
        public ActionResult Index()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("LicensePackage");
            return View();
        }

        public PartialViewResult _LicensePackageList(int currentPage = 0)
        {
            LicensePackageManager mgr = new LicensePackageManager();
            List<LicensePackageVM> list = new List<LicensePackageVM>();
            list = mgr.SelectLicensePackage(0);

            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5) > 0 ? 1 : 0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage + 1;

            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;

            ViewBag.CountStart = currentPage * 5;

            return PartialView(list.GetRange(currentPage * 5, nextCount));
        }

        // GET: LicensePackage
        public ActionResult CreatePackage()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("LicensePackage");
            return View();
        }


        [HttpPost]
        public JsonResult SaveLicensePackage(string packageName, string validDays, string price)
        {
            Result result = new Result();
            LicensePackageManager mgr = new LicensePackageManager();
            result = mgr.InsertLicensePackage(packageName, validDays, price);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LicensePackageEdit(int PackageId)
        {
            LicensePackageManager mgr = new LicensePackageManager();
            List<LicensePackageVM> list = new List<LicensePackageVM>();
            list = mgr.SelectLicensePackage(PackageId);

            LicensePackageVM item = new LicensePackageVM();
            if (list != null && list.Count > 0)
                item = list[0];

            return View(item);
        }

        [HttpPost]
        public JsonResult UpdateLicensePackage(string packageId,string packageName, string validDays, string price)
        {
            Result result = new Result();
            LicensePackageManager mgr = new LicensePackageManager();
            result = mgr.UpdateLicensePackage(Convert.ToInt32(packageId),packageName, validDays, price);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}