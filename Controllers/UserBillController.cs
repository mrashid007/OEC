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
    public class UserBillController : Controller
    {
        // GET: UserBill
        public ActionResult UserBill()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("UserBill");
            SecurityUserManager mgr = new SecurityUserManager();
            int userId=Convert.ToInt32(Session["UserID"].ToString());
            
            string rolecode=Session["RoleCode"].ToString();
            ViewBag.Disable ="false";

            if (rolecode != "ADM")
            {
                ViewBag.Disable = "true";                
            }
            else
            {
                userId = 0;
            }
            ViewBag.UserId = userId;
            ViewBag.UserList = mgr.SelectSecurityUser("Web", userId);

            return View();
        }
        public PartialViewResult _UserBillDetail()
        {
            List<UserBillVM> list = new List<UserBillVM>();
            QuestionBankManager mgr = new QuestionBankManager();
            list=mgr.SelectUserBill(0,"","");
            ViewBag.GrandTotal = list.Sum(x => x.Amount);

           
            ViewBag.Balance = 0;
            ViewBag.TotalEarn = 0;
            ViewBag.TotalWithdraw = 0;
            return PartialView(list);
        }
        [HttpPost]
        public ActionResult UserBillDetailSearch(int userid,string startDate,string endDate)
        {
            List<UserBillVM> list = new List<UserBillVM>();
            QuestionBankManager mgr = new QuestionBankManager();
            list = mgr.SelectUserBill(userid, startDate, endDate);

            ViewBag.GrandTotal = list.Sum(x => x.Amount);

            decimal totalEarn = mgr.CalculateUserBalance(userid, "Cr");
            decimal totalWithdraw = mgr.CalculateUserBalance(userid, "Dr");
            ViewBag.Balance = totalEarn - totalWithdraw;
            ViewBag.TotalEarn = totalEarn;
            ViewBag.TotalWithdraw = totalWithdraw;

            return PartialView("_UserBillDetail", list);
        }
        public ActionResult UserBillWithdrow()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("UserBillWithdrow");
            int userId = Convert.ToInt32(Session["UserID"].ToString());           
            QuestionBankManager mgr = new QuestionBankManager();
            decimal totalEarn = mgr.CalculateUserBalance(userId, "Cr");
            decimal totalWithdraw = mgr.CalculateUserBalance(userId, "Dr");
            ViewBag.Balance = totalEarn - totalWithdraw;
            ViewBag.TotalEarn = totalEarn;
            ViewBag.TotalWithdraw = totalWithdraw;

            return View();
        }
        public ActionResult WithdrawBalance(string withdrawalAmount)
        {
            Result result = new Result();
            QuestionBankManager mgr = new QuestionBankManager();
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            result = mgr.WithdrawBalance(userId,Convert.ToDecimal(withdrawalAmount));

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}