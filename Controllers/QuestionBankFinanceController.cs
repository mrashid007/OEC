using OnlineExamCenter.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamCenter.Controllers
{
    //[SessionExpire]
    public class QuestionBankFinanceController : Controller
    {
        // GET: QuestionBankFinance
        public ActionResult Index()
        {
            return View();
        }

    }
}