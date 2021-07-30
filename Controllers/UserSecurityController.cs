using OnlineExamCenter.App_Start;
using OnlineExamCenter.DAL;
using OnlineExamCenter.Manager;
using OnlineExamCenter.Models;
using OnlineExamCenter.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamCenter.Controllers
{

    public class UserSecurityController : Controller
    {
        // GET: UserSecurity
        public ActionResult Index()
        {
            return View();
        }
        [SessionExpire]
        public ActionResult UserSecurityQuestionIndex()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("UserSecurityQuestion");
            SecurityUserManager mgr = new SecurityUserManager();
            List<SecurityQuestion> list = new List<SecurityQuestion>();
            list = mgr.SelectSecurityQuestion();
            return View(list);
        }
        [SessionExpire]
        public ActionResult UserSecurityQuestion()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("UserSecurityQuestion");
            return View();
        }
        [HttpPost]
        public ActionResult SaveUserSecurityQuestion( string question)
        {
            MenuActive.SetActiveMenu("UserSecurityQuestion");

            SecurityUserManager mgr = new SecurityUserManager();
            Result _result = new Result();
            try {
                int entryBy = Convert.ToInt32(Session["UserID"]);
                _result = mgr.SaveUserSecurityQuestion(question, entryBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateSecurityQuestion(int questiontid, string question,int statusId)
        {
            MenuActive.SetActiveMenu("UserSecurityQuestion");

            SecurityUserManager mgr = new SecurityUserManager();
            Result _result = new Result();
            try
            {
                int updatedBy = Convert.ToInt32(Session["UserID"]);

                _result = mgr.UpdateSecurityQuestion(questiontid, question, statusId, updatedBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }

        [SessionExpire]
        public ActionResult UserSecurityQuestionDetail(int questionId)
        {
            SecurityUserManager mgr = new SecurityUserManager();
            MenuActive.SetActiveMenu("UserSecurityQuestion");

            CommonManager cmgr = new CommonManager();
            ViewBag.StatusList = cmgr.SelectStatus();


            SecurityQuestion item = mgr.SelectSingleSecurityQuestion(questionId);

            return View(item);
        }
        public ActionResult SecurityUserIndex()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("NewSecurityUser");
            return View();
        }
        public ActionResult AppSecurityUserIndex()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("AppSecurityUser");
            return View();
        }
        public ActionResult SecurityUserPasswordPolicy()
        {
            MenuActive.SetActiveMenu("SecurityUserPasswordPolicy");
            return View();
        }
        public ActionResult SecurityUserVerification()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("SecurityUserVerification");
            return View();
        }
        public ActionResult EmailVerification()
        {
           // MenuActive.SetActiveMenu("SecurityUserVerification");
            return View();
        }
        [HttpPost]
        public JsonResult SaveSecurityPolicy(string PasswordLength,string emailVerify,string chkPhoneYes,string badAttmpt,string captchaValidation)
        {
            Result result = new Result();
            SecurityUserManager mgr = new SecurityUserManager();
            result = mgr.SaveSecurityPolicy(Convert.ToInt32(PasswordLength), Convert.ToInt32(emailVerify), Convert.ToInt32(chkPhoneYes), Convert.ToInt32(badAttmpt), Convert.ToInt32(captchaValidation));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChangePassword()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }
            return View();
        }
        public JsonResult LoadSecurityPolicy()
        {

            SecurityUserManager mgr = new SecurityUserManager();
            var item = mgr.SelectSecurityPolicy();
            return Json(item, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult UpdatePassword(string password,string confirmPassword)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            SecurityUserManager mgr = new SecurityUserManager();
           Result result= mgr.UpdateSecurityUserPassword(userId,password, confirmPassword);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult NewSecurityUser()
        {
            if (Session["RoleCode"] == null)
            {
                return RedirectToAction("Login", "LogIn", new { ExpMsg = "Session Expired" });
            }

            MenuActive.SetActiveMenu("NewSecurityUser");
            CommonManager mgr = new CommonManager();
            ViewBag.CountryList = mgr.SelectCountry();
            ViewBag.RoleList = mgr.SelectRole();
            ViewBag.Currency = mgr.SelectCurrency();
            ViewBag.UserType = mgr.SelectUserType();
            ViewBag.LocalCountryId = 15;
            return View();
        }
        [HttpPost]
        public ActionResult SaveNewSecurityUser(string Name,string phoneNo,string email,string countryId,string roleId, string loginId,string pass,string expiryDate,int questionUnit,string unitPrice,int currency,string userType)
        {
            Result _result = new Result();
            try
            {
                int userId = Convert.ToInt32(Session["UserID"]);

                SecurityUserManager mgr = new SecurityUserManager();

                _result = mgr.EmailPhoneDuplicateChecking(phoneNo, email);

                if (!_result.IsSuccess)
                {
                    _result = mgr.SaveSecurityUser(Name, phoneNo, email, loginId, pass, Convert.ToInt32(countryId), Convert.ToInt32(roleId), userId, expiryDate, questionUnit, unitPrice, currency, Convert.ToInt32(userType));
                }
                else
                {
                    _result.IsSuccess = false;
                    _result.Message = "Email Or Phone no Already Exist";
                }
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateSecurityUser(int userId, string Name, string phoneNo, string email, string countryId, string roleId, string loginId, string pass,string statusId,string expiryDate, int questionUnit, string unitPrice, int currency,int userType)
        {
            Result _result = new Result();
            try
            {
                int updatedBy = Convert.ToInt32(Session["UserID"]);

                SecurityUserManager mgr = new SecurityUserManager();
                _result = mgr.UpdateSecurityUser(userId,Name, phoneNo, email, loginId, pass, Convert.ToInt32(countryId), Convert.ToInt32(roleId), Convert.ToInt32(statusId),updatedBy, expiryDate, questionUnit, unitPrice, currency,userType);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SecurityUserDetail(int userid)
        {
            SecurityUserManager mgr = new SecurityUserManager();
            MenuActive.SetActiveMenu("NewSecurityUser");

            CommonManager cmgr = new CommonManager();
            ViewBag.CountryList = cmgr.SelectCountry();
            ViewBag.RoleList = cmgr.SelectRole();
            ViewBag.StatusList = cmgr.SelectStatus();
            ViewBag.Currency = cmgr.SelectCurrency();
            ViewBag.UserType = cmgr.SelectUserType();

            SecurityUserVM item = new SecurityUserVM();
            item = mgr.SelectSingleSecurityUser(userid);
            return View(item);
        }
        [HttpPost]
        public ActionResult UpdateSecurityUserOwnInfo(string Name, string phoneNo, string email, string countryId)
        {
            Result _result = new Result();
            try
            {
                int updatedBy = Convert.ToInt32(Session["UserID"]);

                SecurityUserManager mgr = new SecurityUserManager();
                _result = mgr.UpdateSecurityUserOwnInfo(updatedBy, Name, phoneNo, email, Convert.ToInt32(countryId), updatedBy);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.Message = ex.Message;
            }
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void UpdateSecurityUserProfileImage()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    Byte[] destination1 = new Byte[pic.ContentLength];
                    pic.InputStream.Position = 0;
                    pic.InputStream.Read(destination1, 0, pic.ContentLength);

                    Session["ProfilePic"] = destination1;

                    string _imgname = Session["UserID"].ToString();
                    var _comPath = Server.MapPath(@"\image\Profile\User\") + _imgname + ".jpg";

                    //var _comPath = "~/image/Profile/User/" +_imgname + ".jpg";

                    if (System.IO.File.Exists(_comPath))
                    {
                        System.IO.File.Delete(_comPath);
                    }
                    ViewBag.Msg = _comPath;
                    pic.SaveAs(_comPath);
                }
            }
        }
        public ActionResult ProfileDetail()
        {
            SecurityUserManager mgr = new SecurityUserManager();
            MenuActive.SetActiveMenu("NewSecurityUser");

            int userid = Convert.ToInt32(Session["UserID"]);

            CommonManager cmgr = new CommonManager();
            ViewBag.CountryList = cmgr.SelectCountry();
            ViewBag.RoleList = cmgr.SelectRole();
            ViewBag.StatusList = cmgr.SelectStatus();
            ViewBag.Currency = cmgr.SelectCurrency();

            SecurityUserVM item = new SecurityUserVM();
            item = mgr.SelectSingleSecurityUser(userid);
            return View(item);
        }
        public PartialViewResult _SecurityUserList(string usetType, int currentPage = 0)
        {
            SecurityUserManager mgr = new SecurityUserManager();
            List<SecurityUserVM> list = new List<SecurityUserVM>();
            list = mgr.SelectSecurityUser(usetType,0);

            int pageCount = list.Count / 5;
            pageCount += (list.Count % 5) > 0 ? 1 : 0;

            ViewBag.TotalPages = pageCount;
            ViewBag.CurrentPage = currentPage + 1;

            int nextCount = list.Count - currentPage * 5 < 5 ? list.Count - currentPage * 5 : 5;

            ViewBag.CountStart = currentPage * 5;

            return PartialView(list.GetRange(currentPage * 5, nextCount));
        }
        //[HttpPost]
        public ActionResult SearchSecurityUser(string searchstr)
        {
            SecurityUserManager mgr = new SecurityUserManager();
            List<SecurityUserVM> list = new List<SecurityUserVM>();
            list = mgr.SearchSecurityUser(searchstr);

            return PartialView("_SecurityUserList",list);

        }

        public JsonResult SecurityUserVerifyEmail()
        {
            Result result = new Result();
            string LoginId = Session["LoginId"].ToString();
            //SecurityUserManager mgr = new SecurityUserManager();
            CommonManager cmnMgr = new CommonManager();
            string emailId = cmnMgr.GetUserEmail(LoginId);
            SecurityUserManager securityUserManager = new SecurityUserManager();
           SecurityUserVM securityUserVM=securityUserManager.SelectSingleSecurityUser(Convert.ToInt32(Session["UserID"]));
            string emailBody = "Hello! "+ securityUserVM.Name + ", <br/> Please Click the bellow link to verify your email address.<br/> ";

            emailBody= emailBody+ "<a href=\"http://www.cisspguru.com/UserSecurity/VerifyEmailLink?LoginId=" + LoginId + "\"> Verify</a> <br/> Thanks, <br/> The CISSPGuru account team";

            SendMailForEmailVerification(emailId, emailBody);

            //result = mgr.SecurityUserEmailVerify(userid);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public bool SendMailForEmailVerification(string toEmail, string messageBody)
        {

            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("no-reply@cisspguru.com", "Cissp@321#");
                //smtpClient.Port = 587;
                smtpClient.Host = "www.cisspguru.com";
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("no-reply@cisspguru.com", "cisspguru");
                mail.To.Add(new MailAddress(toEmail));

                mail.Subject = "Email Verification";
                mail.IsBodyHtml = true;

                mail.Body = messageBody;

                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public JsonResult EmailPhoneDuplicateChecking(string phoneNo, string email)
        {
            Result result = new Result();
            SecurityUserManager mgr = new SecurityUserManager();

            result = mgr.EmailPhoneDuplicateChecking(phoneNo,email);

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult VerifyEmailLink(string LoginId)
        {
            SecurityUserManager mgr = new SecurityUserManager();
            mgr.SecurityUserEmailVerify(LoginId);
            return RedirectToAction("Login","Login");
        }

    }
}