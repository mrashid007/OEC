using OnlineExamCenter.Manager;
using OnlineExamCenter.Models;
using OnlineExamCenter.ModelsVM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineExamCenter.Controllers
{
    public class LoginController : Controller
    {
        protected string UserID = "0";
        protected string Name = "";
        protected string AccessLevelID = "0";

        private readonly Random _random = new Random();
        public ActionResult Login(string ExpMsg = "")
        {

            ViewBag.ExpMsg = ExpMsg;
            ViewBag.Title = "User Login";
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(string userName, string userPassword)
        {
            LoginManager mgr = new LoginManager();
            EmpLoggedInDetails empDetails = new EmpLoggedInDetails();
            empDetails = mgr.UserLogin(userName, userPassword);
            


            if (empDetails.UserId!="" && empDetails.UserId != "0")
            {

                Session["UserID"] = empDetails.UserId;               
                Session["Name"]     = empDetails.Name;
                Session["LoginId"] = userName;
                Session["RoleName"] = empDetails.RoleName;
                Session["RoleCode"] = empDetails.RoleCode;
                Session["ProfilePic"] = empDetails.ProfilePic;
                Response.Cookies["EmpID"].Value = empDetails.UserId;
                Response.Cookies["Name"].Value = empDetails.Name;
                Response.Cookies["Country"].Value = empDetails.Country;
                Response.Cookies["CountryId"].Value = empDetails.CountryId;
                Response.Cookies["CurrencyCode"].Value = empDetails.CurrencyCode;
                Response.Cookies["DateOfExpiree"].Value = empDetails.DateOfExpiree;
                Response.Cookies["Email"].Value = empDetails.Email;
                Response.Cookies["PhoneNo"].Value = empDetails.PhoneNo;
                Response.Cookies["RoleId"].Value = empDetails.RoleId;
                Response.Cookies["Status"].Value = empDetails.Status;
                Response.Cookies["StatusId"].Value = empDetails.StatusId;
                Response.Cookies["Unit"].Value = empDetails.Unit;
                Response.Cookies["UnitPrice"].Value = empDetails.UnitPrice;
                ViewBag.LoginMSG = empDetails.ExpMsg;

                if (empDetails.NeedChangePassword)
                {
                    return RedirectToAction("ForgotPassword", "Login");
                }

                if (!empDetails.EmailVarified)
                {
                    return RedirectToAction("EmailVerification", "UserSecurity");
                }

                MenuActive.SetActiveMenu("Dashboard");
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                if(empDetails.ExpMsg!="")
                    ViewBag.LoginMSG = empDetails.ExpMsg;
                else
                    ViewBag.LoginMSG = "User Id or Password is Incorrect";

                return RedirectToAction("Login", "LogIn", new { ExpMsg = ViewBag.LoginMSG });
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut(); //you write this when you use FormsAuthentication
            return RedirectToAction("Login", "LogIn");
        }

        public ActionResult ChangePassword()
        {
            MenuActive.SetActiveMenu("Password");

            ViewBag.UserName = Session["UserName"].ToString();
            if (Session["UserType"] != null && Session["UserType"].ToString() == "EMP")
            {
                ViewBag.ProfileTitle = Session["OfficeName"].ToString();
            }
            else
            {
                ViewBag.ProfileTitle = Session["DepartmentName"].ToString();
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string password)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            LoginManager mgr = new LoginManager();
            Result result = mgr.ChangePassword(userId, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ChangePasswordWithOTP(string userid, string password,string otp)
        {
            int userId =Convert.ToInt32(Session["ForgotUserId"]);
            if (userid != "")
                userId =Convert.ToInt32(userid);
            LoginManager mgr = new LoginManager();
            Result result = mgr.ChangePasswordWithOTP(userId, password, otp);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult ForgotPassword(string ExpMsg = "")
        {
            ViewBag.ExpMsg = ExpMsg;
            ViewBag.Title = "Reset User Password";
            return View();
        }

        public ActionResult ForgotPasswordOTPConfirmation(string ExpMsg = "")
        {
            string loginId = Request.QueryString["userKey"];

            Session["ForgotUserId"] = loginId;

            ViewBag.ForgotUserId = loginId;
            ViewBag.ExpMsg = ExpMsg;
            ViewBag.Title = "OTP Confirmation";
            return View();
        }

        
        [HttpPost]
        public ActionResult ForgotUserPassword(string emailid, string registeredMobileNo)
        {
            CommonManager cmnMgr = new CommonManager();
            SecurityUserManager securityUserManager = new SecurityUserManager();
            List<string> strList = cmnMgr.GetUserContactNo(emailid, registeredMobileNo);

            if(strList==null|| strList.Count<1)
            {
               string msg = "Your given Email or 6 digits of mobile no is not matched to registered mobile no. Please contact with the system Administrator";
                return RedirectToAction("ForgotPassword", "LogIn", new { ExpMsg = msg });
            }

            string loginId= strList[0].ToString();
            string mobileNo = strList[1].ToString();
            string userId = strList[2].ToString();

            string ExpMsg = "";
            if (mobileNo.Contains(registeredMobileNo))//Substring((mobileNo.Length-6),6) == 
            {
                SecurityUserVM securityUserVM = securityUserManager.SelectSingleSecurityUser(Convert.ToInt32(userId));
                
                //Result result = new Result();
                bool response = false;
                try
                {
                    //SendEmailClass SendEmail = new SendEmail();
                    string OTP= RandomPassword();
                    string EmailBody = "Dear "+ securityUserVM.Name+ ",<br/>";
                    EmailBody = EmailBody + "A password reset request has been received from your www.cisspguru.com. <br/> Account: " + securityUserVM.Email + " (Your User ID :" + loginId + ") <br/>";
                    EmailBody = EmailBody + "Please use this code to reset the password.Here is your OTP:\t" + OTP+ " <br/> IMP: If you have not initiated this request,Please ignore it. <br/> <br/> Thanks, <br/> The CISSPGuru account team";
                    string emailSubject = "CISSPGuru User Password Reset Request";

                    response = SendMail(securityUserVM.Email, emailSubject, EmailBody);

                    if (response)
                    {
                        securityUserManager.UpdatePasswordResetOTP(userId, OTP);
                    }
                    ExpMsg = "Password Reset OTP code sent to your email. Please Check Your Email Inbox/Spam";
                    Session["ForgotUserId"] = loginId;
                    return RedirectToAction("ForgotPasswordOTPConfirmation", "LogIn", new { ExpMsg = ExpMsg, userKey= userId });
                }
                catch(Exception ex) {
                    ExpMsg = "OTP sending Error:"+ex.Message;
                    return RedirectToAction("ForgotPassword", "LogIn", new { ExpMsg = ExpMsg });
                }

            }
            else
            {
                ExpMsg = "Your given mobile no is not matched to registered mobile no. Please contact with the system Administrator";
                return RedirectToAction("ForgotPassword", "LogIn", new { ExpMsg = ExpMsg });
            }
        }
        public string RandomPassword()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case   
            passwordBuilder.Append(RandomString(4, true));

            // 4-Digits between 1000 and 9999  
            passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case  
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public ActionResult ResetPassword()
        {
            MenuActive.SetActiveMenu("Password");

            ViewBag.UserName = Session["UserName"].ToString();
            if (Session["UserType"] != null && Session["UserType"].ToString() == "EMP")
            {
                ViewBag.ProfileTitle = Session["OfficeName"].ToString();
            }
            else
            {
                ViewBag.ProfileTitle = Session["DepartmentName"].ToString();
            }
            return View();
        }
        public JsonResult ResetPasswordSave(string loginId)
        {
            CommonManager cmnMgr = new CommonManager();
            string defaultPass = ConfigurationManager.AppSettings["DefaultPass"].ToString();
            Result result = new Result();
            try
            {
                cmnMgr.ResetUserPassword(loginId, defaultPass);
                result.IsSuccess = true;
                result.Message = "Password Reset Successfully";
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public bool SendMail(string toEmail,string mailSubject, string messageBody)
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
                mail.IsBodyHtml = true;
                mail.Subject = mailSubject;

                mail.Body = messageBody;
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}