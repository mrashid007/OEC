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
    public class QuestionApprovalController : Controller
    {
        // GET: QuestionApproval
        public ActionResult Index()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            return View();
        }
        public ActionResult QuestionApprovalPanel()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            CommonManager cmgr = new CommonManager();
            QuestionBankManager mgr = new QuestionBankManager();
            ViewBag.StatusList = cmgr.SelectStatus();
            ViewBag.QuestionTypeList = mgr.SelectQuestionTye();
            ViewBag.DomainList = mgr.SelectQuestionDomain();
            ViewBag.QuestionWeightList = mgr.SelectQuestionWeight();
            return View();
        }
        public PartialViewResult _QuestionList(int currentPage = 0)
        {
            List<Question> list = new List<Question>();
            QuestionBankManager mgr = new QuestionBankManager();
            list = mgr.SelectUnApprovedQuestionList(0, 0, 0, 0);

            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5) > 0 ? 1 : 0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage + 1;

            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;

            return PartialView(list.GetRange(currentPage * 5, nextCount));
        }
        public ActionResult QuestionListSearch(int typeid, int domainid, int weightid, int statusid)
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            List<Question> list = new List<Question>();
            QuestionBankManager mgr = new QuestionBankManager();
            list = mgr.SelectUnApprovedQuestionList(typeid, domainid, weightid, statusid);

            return PartialView("_QuestionList", list);
        }
        public ActionResult ApproveQuestion(string values)
        {
            string[] ids = values.Split(',');
            Result result = new Result();
            QuestionBankManager mgr = new QuestionBankManager();

            try
            {
                int entryBy = Convert.ToInt32(Session["UserID"]);
                result = mgr.ApproveQuestion(ids, entryBy);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}