using OnlineExamCenter.App_Start;
using OnlineExamCenter.Manager;
using OnlineExamCenter.Models;
using OnlineExamCenter.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamCenter.Controllers
{
    //[SessionExpire]
    public class KeyGenerationController : Controller
    {
        // GET: KeyGeneration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewKeyGeneration()
        {
            MenuActive.SetActiveMenu("KeyGeneration");
            return View();
        }
        public JsonResult GenerateActivationKey()
        {

            Result result = new Result();
            result.IsSuccess = true;
            result.ItemNo = RandomString(6,false);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public string RandomString(int size, bool lowerCase)
        {
            string key = "";
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                key=builder.ToString().ToLower();
            key=builder.ToString();

           return DateTime.Now.Year.ToString()+DateTime.Now.Hour.ToString() + DateTime.Now.Month.ToString()+DateTime.Now.Minute.ToString() + DateTime.Now.Day.ToString()+DateTime.Now.Second.ToString() + key;
        }
        [HttpPost]
        public JsonResult SaveActivationKey(string newKey,string validDays)
        {
            Result result = new Result();
            QuestionBankManager mgr = new QuestionBankManager();
            result = mgr.InsertActivationKey(newKey,validDays);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivationKeyDashboard()
        {
            SecurityUserManager mgr = new SecurityUserManager();

            if(Session["UserID"]==null)
            {
               return RedirectToAction("Logout","Login");
            }

            MenuActive.SetActiveMenu("KeyGeneration");

            int userid = Convert.ToInt32(Session["UserID"]);

            CommonManager cmgr = new CommonManager();
            ViewBag.StatusList = cmgr.SelectStatus();

            return View();
        }
        public PartialViewResult _ActivationKeyList(int currentPage = 0)
        {
            List<ActivationKey> list = new List<ActivationKey>();
            QuestionBankManager mgr = new QuestionBankManager();
           /* list = mgr.SelectQuestionList(0, 0, 0, "", "");*/

            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5) > 0 ? 1 : 0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage + 1;

            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;

            ViewBag.CountStart = currentPage * 5;

            return PartialView(list.GetRange(currentPage * 5, nextCount));
        }
        public ActionResult QuestionListSearch(int statusId, string dateFrom, string dateTo)
        {
            List<ActivationKey> list = new List<ActivationKey>();
            //QuestionBankManager mgr = new QuestionBankManager();
            //list = mgr.SelectQuestionList(typeid, domainid, weightid, dateFrom, dateTo);

            int currentPage = 0;
            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5) > 0 ? 1 : 0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage + 1;

            ViewBag.CountStart = currentPage * 5;

            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;
            return PartialView("_ActivationKeyList", list.GetRange(currentPage * 5, nextCount));

        }
    }
}