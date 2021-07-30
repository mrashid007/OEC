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
    public class QuestionBankController : Controller
    {
        // GET: QuestionBank
        public ActionResult Index()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            return View();
        }
        public ActionResult QuestionWeightIndex()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("QuestionWeightSetup");
            QuestionBankManager mgr = new QuestionBankManager();
            List<QuestionWeightVM> list = new List<QuestionWeightVM>();
            list = mgr.SelectQuestionWeight();
            return View(list);
        }
        public ActionResult QuestionWeightSetup()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("QuestionWeightSetup");
            return View();
        }
        [HttpPost]
        public ActionResult SaveQuestionWeight(string weight)
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int entryBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.SaveQuestionWeight(weight, entryBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveQuestionDomain(string domain,string description,int questionweight)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int entryBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.SaveQuestionDomain(domain, description, questionweight, entryBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        
       [HttpPost]
        public ActionResult UpdateQuestionWeight(int weightId,string Weight,int statusId)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int entryBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.UpdateQuestionWeight(weightId, Weight, statusId, entryBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QuestionWeightDetail(int weightid)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            CommonManager cmgr = new CommonManager();
            MenuActive.SetActiveMenu("QuestionWeightSetup");
            QuestionWeightVM item = mgr.SelectSingleQuestionWeight(weightid);
            ViewBag.StatusList = cmgr.SelectStatus();
            return View(item);
        }
        public ActionResult QuestionDomainIndex(int currentPage=0)
        {
            MenuActive.SetActiveMenu("QuestionDomainSetup");
            QuestionBankManager mgr = new QuestionBankManager();
            List<QuestionDomainVM> list = new List<QuestionDomainVM>();
            list = mgr.SelectQuestionDomain();


            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5)>0?1:0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage+1;



            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;

            return View(list.GetRange(currentPage*5, nextCount));
        }
        public ActionResult QuestionDomainSetup()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("QuestionDomainSetup");
            return View();
        }
        public ActionResult QuestionDomainDetail(int domainId)
        {
            MenuActive.SetActiveMenu("QuestionDomainSetup");
            QuestionBankManager mgr = new QuestionBankManager();
            CommonManager cmgr = new CommonManager();
            QuestionDomainVM item = mgr.SelectSingleQuestionDomain(domainId);
            ViewBag.StatusList = cmgr.SelectStatus();
            return View(item);
        }
        [HttpPost]
        public ActionResult UpdateQuestionDomain(int domainId, string domain, int statusId,string description,int questionweight)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int updateBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.UpdateQuestionDomain(domainId, domain, statusId, updateBy, description, questionweight);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QuestionTypeIndex()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("QuestionTypeSetup");
            QuestionBankManager mgr = new QuestionBankManager();
            List<QuestionTypeVM> list = mgr.SelectQuestionTye();
            return View(list);
        }
        public ActionResult QuestionTypeSetup()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            MenuActive.SetActiveMenu("QuestionTypeSetup");
            return View();
        }
        [HttpPost]
        public ActionResult SaveQuestionType(string questionType)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int entryBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.SaveQuestionType(questionType, entryBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult QuestionQuestionType(int typeId)
        {
            MenuActive.SetActiveMenu("QuestionTypeSetup");
            QuestionBankManager mgr = new QuestionBankManager();
            CommonManager cmgr = new CommonManager();
            QuestionTypeVM item = mgr.SelectSingleQuestionTye(typeId);
            ViewBag.StatusList = cmgr.SelectStatus();
            return View(item);
        }
        [HttpPost]
        public ActionResult UpdateQuestionType(int typeId, string questionType, int statusId)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int updateBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.UpdateQuestionType(typeId, questionType, statusId, updateBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QuestionTypeDetail(int typeid)
        {
            MenuActive.SetActiveMenu("QuestionTypeSetup");
            CommonManager cmgr = new CommonManager();
            ViewBag.StatusList = cmgr.SelectStatus();
            QuestionBankManager mgr = new QuestionBankManager();
            QuestionTypeVM item = mgr.SelectSingleQuestionTye(typeid); 
            return View(item);
        }

        public ActionResult QuestionDashboard()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("NewQuestion");
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
            list = mgr.SelectQuestionList(0, 0, 0, "","");

            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5) > 0 ? 1 : 0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage + 1;

            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;

            ViewBag.CountStart = currentPage*5 ;

            return PartialView(list.GetRange(currentPage * 5, nextCount));
        }
        public ActionResult QuestionListSearch(int typeid, int domainid, int weightid,string dateFrom,string dateTo)
        {
            List<Question> list = new List<Question>();
            QuestionBankManager mgr = new QuestionBankManager();
            list = mgr.SelectQuestionList(typeid, domainid, weightid, dateFrom, dateTo);

            int currentPage = 0;
            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5) > 0 ? 1 : 0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage + 1;

            ViewBag.CountStart = currentPage * 5;

            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;
            return PartialView("_QuestionList",list.GetRange(currentPage * 5, nextCount));

            //return PartialView("_QuestionList", list);
        }
        public ActionResult NewQuestion()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("NewQuestion");
            CommonManager cmgr = new CommonManager();
            ViewBag.StatusList = cmgr.SelectStatus();

            QuestionBankManager mgr = new QuestionBankManager();
            ViewBag.QuestionTypeList = mgr.SelectQuestionTye();
            ViewBag.DomainList = mgr.SelectQuestionDomain();
            ViewBag.QuestionWeightList = mgr.SelectQuestionWeight();

            return View();
        }
        [HttpPost]
        public ActionResult SaveNewQuestion(int questiontypeid,int domainid,int questionweightid,string question,
                    string expirydate,string explanation,string option1,string option2,string option3,
                    string option4,int rdbOption1,int rdbOption2,int rdbOption3,int rdbOption4,
                    int rdbOption5,int rdbOption6,int chkOption5,int chkOption6,string practise,string questionReference)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int entryBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.SaveNewQuestion(questiontypeid, domainid, questionweightid, question,
                    expirydate, explanation, option1, option2, option3,
                    option4, rdbOption1, rdbOption2, rdbOption3, rdbOption4,
                    rdbOption5, rdbOption6, chkOption5, chkOption6, practise, questionReference, entryBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateNewQuestion(int questionId,int questiontypeid, int domainid, int questionweightid, string question,
                    string expirydate, string explanation, string option1, string option2, string option3,
                    string option4, int rdbOption1, int rdbOption2, int rdbOption3, int rdbOption4,
                    int rdbOption5, int rdbOption6, int chkOption5, int chkOption6, string practise, string questionReference,int statusId)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            Result _result = new Result();
            try
            {
                int updateBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.UpdateNewQuestion(questionId,questiontypeid, domainid, questionweightid, question,
                    expirydate, explanation, option1, option2, option3,
                    option4, rdbOption1, rdbOption2, rdbOption3, rdbOption4,
                    rdbOption5, rdbOption6, chkOption5, chkOption6, practise, questionReference, updateBy,statusId);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QuestionDetail(int QuestionId)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            QuestionVM question = new QuestionVM();
            question = mgr.SelectSingleQuestion(QuestionId);

            CommonManager cmgr = new CommonManager();
            ViewBag.StatusList = cmgr.SelectStatus();

            ViewBag.QuestionTypeList = mgr.SelectQuestionTye();
            ViewBag.DomainList = mgr.SelectQuestionDomain();
            ViewBag.QuestionWeightList = mgr.SelectQuestionWeight();

            return View(question);
        }
        public ActionResult _ShowQuestionDetail(int QuestionId)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            QuestionVM question = new QuestionVM();
            question = mgr.SelectSingleQuestion(QuestionId);

            return PartialView(question);
        }
        public ActionResult QuestionDetailView(int QuestionId)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            QuestionVM question = new QuestionVM();
            question = mgr.SelectSingleQuestion(QuestionId);
            if (question.QuestionId < 1)
            {
                @ViewBag.Message = "No Record Found";
            }
            else
            {
                @ViewBag.Message = "";
            }
            return View(question);
        }

        public ActionResult QuestionDetailViewPrev(string QuestionNo)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            QuestionVM question = new QuestionVM();
            question = mgr.SelectSingleQuestionByQuestionNo(QuestionNo,0);
            if (question.QuestionId < 1)
            {
                @ViewBag.Message = "This is the last Question in Previous Queue";
                question = mgr.SelectSingleQuestion(QuestionNo);
            }
            else
            {
                @ViewBag.Message = "";
            }
            return View("QuestionDetailView",question);
        }
        public ActionResult QuestionDetailViewNext(string QuestionNo)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            QuestionVM question = new QuestionVM();
            question = mgr.SelectSingleQuestionByQuestionNo(QuestionNo, 1);
            if(question.QuestionId<1)
            {
                @ViewBag.Message = "This is the last Question in Next Queue";
                question = mgr.SelectSingleQuestion(QuestionNo);
            }
            else
            {
                @ViewBag.Message = "";
            }
            return View("QuestionDetailView", question);
        }
        public ActionResult QuestionSearchByQuestionNo(string QuestionNo)
        {
            QuestionBankManager mgr = new QuestionBankManager();
            QuestionVM question = new QuestionVM();
            question = mgr.SelectSingleQuestion(QuestionNo);
            return View(question);
        }
    }
}