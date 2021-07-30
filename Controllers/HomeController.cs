using OnlineExamCenter.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamCenter.Controllers
{
    //[SessionExpire]
    public class HomeController : Controller
    {
        [ChildActionOnly]
        public ActionResult _EmployeeMenu()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult _ModuleSampleMenu()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            return PartialView();
        }
        public ActionResult DashBoard()
        {
            if (Request.Cookies["EmpID"] == null)
                return RedirectToAction("Login", "LogIn");

            MenuActive.SetActiveMenu("DashBoard");

            ViewBag.UserName = Session["Name"].ToString();
            ViewBag.ProfileTitle = Session["RoleName"].ToString();

            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            if (Session["UserType"] != null && Session["UserType"].ToString() == "EMP")
            {
                return RedirectToAction("VendorBoard", "Home");
            }
            else
            {
                return RedirectToAction("CustomerBoard", "Home");
            }
        }
        public ActionResult Tab()
        {
            return View();
        }
        public ActionResult Form()
        {
            ViewBag.Title = "Sample Page";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Sample Page";

            return View();
        }
        public ActionResult BasicTable()
        {
            ViewBag.Title = "Sample Page";

            return View();
        }
        [ChildActionOnly]
        public ActionResult Modal()
        {
            ViewBag.Title = "Sample Page";

            return View();
        }
    }
}