using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamCenter.App_Start;
using OnlineExamCenter.DAL;
using OnlineExamCenter.Manager;
using OnlineExamCenter.Models;

namespace OnlineExamCenter.Controllers
{
    [SessionExpire]
    public class AccountReportController : Controller
    {
        AccountManager mgr = new AccountManager();
        CommonManager cmnmgr = new CommonManager(); 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountSetting()
        {
            MenuActive.SetActiveMenu("AccountSetting");
            return View();
        }
        public ActionResult AccountLedger()
        {
            MenuActive.SetActiveMenu("AccountLedger");

            ViewBag.AccountList=cmnmgr.GetAccountList(0);
            ViewBag.TxnTypeList = cmnmgr.GetTxnTypeList();
            return View();
        }

        public ActionResult AccountLedgerProcess()
        {
            MenuActive.SetActiveMenu("AccountingProcess");
            return View();
        }

        public JsonResult GetAccountListJson(int typeid)
        {  
           var list=cmnmgr.GetAccountList(typeid);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetAccountLedger(string accountno,string fromdate,string todate)
        {
            List<AccountLedgerVM> list = mgr.GetAccountLedger(accountno, fromdate, todate);

            return PartialView(list);
        }
        [HttpPost]
        public ActionResult RunAccountLedgerProcess()
        {
            QuestionBankManager manager = new QuestionBankManager();
            Result result= manager.AccountLedgerProcess();

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}