using OnlineExamCenter.DAL;
using OnlineExamCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineExamCenter.ModelsVM;
using System.Data;
using System.IO;

namespace OnlineExamCenter.Manager
{
    public class SecurityUserManager
    {
        UserDB db = new UserDB();
        public Result SaveSecurityUser(string Name, string phoneNo, string email, string loginId, string pass,int countryid,int roleId,int entryBy,string expiryDate, int questionUnit, string unitPrice, int currency,int userType)
        {
            Result result = new Result();
            try
            {
                result=db.SaveSecurityUser(Name, phoneNo, email, loginId, pass,countryid,roleId,entryBy, expiryDate, questionUnit, unitPrice, currency, userType);
            }
            catch( Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal List<SecurityUserVM> SelectSecurityUser(string usetType,int userId)
        {
            List<SecurityUserVM> list = new List<SecurityUserVM>();
            DataTable dt = new DataTable();
            dt = db.SelectSecurityUser(usetType, userId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SecurityUserVM vm = new SecurityUserVM
                {
                    Email = dt.Rows[i]["Email"].ToString(),
                    LoginId = dt.Rows[i]["LoginId"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    Password= dt.Rows[i]["Password"].ToString(),
                    PhoneNo = dt.Rows[i]["PhoneNo"].ToString(),
                    StatusName = dt.Rows[i]["StatusName"].ToString(),
                    UserId = Convert.ToInt16(dt.Rows[i]["Id"]),
                    CCY = Convert.ToInt16(dt.Rows[0]["StatusId"]),
                    Unit = Convert.ToInt16(dt.Rows[0]["Unit"]),
                    UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]),
                };
                list.Add(vm);

            }
            return list;
        }

        internal List<SecurityQuestion> SelectSecurityQuestion()
        {
            List<SecurityQuestion> list = new List<SecurityQuestion>();
            DataTable dt = new DataTable();
            dt = db.SelectSecurityQuestion();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SecurityQuestion vm = new SecurityQuestion
                {
                    QuestionId =Convert.ToInt32(dt.Rows[i]["QuestionId"]),
                    Question = dt.Rows[i]["Question"].ToString(),
                    StatusName= dt.Rows[i]["StatusName"].ToString(),
                    StatusId= Convert.ToInt32(dt.Rows[i]["StatusId"])
                };
                list.Add(vm);

            }
            return list;
        }

        internal Result UpdateSecurityQuestion(int questiontid, string question, int statusId,int updatedBy)
        {
            Result result = new Result();
            try
            {
                result = db.UpdateSecurityQuestion(questiontid, question, statusId, updatedBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal Result UpdateSecurityUserPassword(int userId, string password, string confirmPassword)
        {
            Result result = new Result();

            if (password != confirmPassword)
            {
                result.IsSuccess = false;
                result.Message = "Password not matched";
                return result;
            }


            try
            {
                result = db.UpdateSecurityUserPassword(userId, password);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal Result SaveSecurityPolicy(int passwordLength, int emailVerify, int chkPhoneYes, int badAttmpt,int captchaValidation)
        {
            Result result = new Result();
            try
            {
                result = db.SaveSecurityPolicy(passwordLength, emailVerify, chkPhoneYes, badAttmpt, captchaValidation);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public object SelectSecurityPolicy()
        {
            DataTable dt = new DataTable();
            dt = db.SelectSecurityPolicy();
            var vm = new SecurityPolicyVM
            {
                BadLoginAttampt= Convert.ToInt32(dt.Rows[0]["BadLoginAttampt"]),
                CaptchaValidation= Convert.ToBoolean(dt.Rows[0]["CaptchaValidation"]),
                EmailVarified= Convert.ToBoolean(dt.Rows[0]["EmailVerified"]),
                PasswordLength= Convert.ToInt32(dt.Rows[0]["PasswordLength"]),
                PhoneNoValidation= Convert.ToBoolean(dt.Rows[0]["PhoneNoValidation"])
            };

            return vm;
        }

        internal void UpdatePasswordResetOTP(string userId, string oTP)
        {
            Result result = new Result();

            try
            {
                result = db.UpdatePasswordResetOTP(userId, oTP);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
        }

        //internal void UpdateSecurityEmailValidationStatus(string userId, bool status)
        //{
        //    Result result = new Result();

        //    try
        //    {
        //        result = db.UpdateSecurityEmailValidationStatus(userId, status);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //        result.IsSuccess = false;
        //    }
        //}

        internal SecurityQuestion SelectSingleSecurityQuestion(int questionId)
        {
            DataTable dt = new DataTable();
            dt = db.SelectSingleSecurityQuestion(questionId);
                SecurityQuestion vm = new SecurityQuestion
                {
                    QuestionId = Convert.ToInt32(dt.Rows[0]["QuestionId"]),
                    Question = dt.Rows[0]["Question"].ToString(),
                    StatusName = dt.Rows[0]["StatusName"].ToString(),
                    StatusId = Convert.ToInt32(dt.Rows[0]["StatusId"])
                };
                        
            return vm;
        }

        internal Result SaveUserSecurityQuestion(string securityquestion,int entryBy)
        {
            Result result = new Result();
            try
            {
                result = db.SaveUserSecurityQuestion(securityquestion, entryBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal SecurityUserVM SelectSingleSecurityUser(int userid)
        {
            DataTable dt = new DataTable();
            dt = db.SelectSingleSecurityUser(userid);

            string url = @"\image\Profile\User\"+userid.ToString()+".jpg";

            if (!File.Exists(url))
            {
                url = @"\image\Profile\User\profile.jpg";
            }

            SecurityUserVM vm = new SecurityUserVM
            {
                Email = dt.Rows[0]["Email"].ToString(),
                LoginId = dt.Rows[0]["LoginId"].ToString(),
                Name = dt.Rows[0]["Name"].ToString(),
                Password = dt.Rows[0]["Password"].ToString(),
                PhoneNo = dt.Rows[0]["PhoneNo"].ToString(),
                StatusName = dt.Rows[0]["StatusName"].ToString(),
                UserId = Convert.ToInt16(dt.Rows[0]["Id"]),
                CountryId = Convert.ToInt16(dt.Rows[0]["CountryId"]),
                CountryName = dt.Rows[0]["CountryName"].ToString(),
                RoleId = Convert.ToInt16(dt.Rows[0]["RoleId"]),
                RoleName = dt.Rows[0]["RoleName"].ToString(),
                StatusId = Convert.ToInt16(dt.Rows[0]["StatusId"]),
                ExpiryDate = dt.Rows[0]["ExpiryDate"].ToString(),
                CCY = Convert.ToInt16(dt.Rows[0]["CCY"]),
                Unit = Convert.ToInt16(dt.Rows[0]["Unit"]),
                UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]),
                ImageUrl = url,
                UserTypeId= Convert.ToInt16(dt.Rows[0]["UserTypeId"])
            };
            return vm;
        }

        internal Result UpdateSecurityUserOwnInfo(int userId, string name, string phoneNo, string email, int countryid, int updatedBy)
        {
            Result result = new Result();
            try
            {
                result = db.UpdateSecurityUserOwnInfo(userId, name, phoneNo, email,  countryid, updatedBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal Result UpdateSecurityUser(int userId,string Name, string phoneNo, string email, string loginId, string pass, int countryid, int roleId,int statusId,
            int updatedBy,string expiryDate, int questionUnit, string unitPrice, int currency,int userType)
        {
            Result result = new Result();
            try
            {
                result = db.UpdateSecurityUser(userId,Name, phoneNo, email, loginId, pass, countryid, roleId, statusId, updatedBy, expiryDate,  questionUnit, unitPrice, currency, userType);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal List<SecurityUserVM> SearchSecurityUser(string searchstr)
        {
            List<SecurityUserVM> list = new List<SecurityUserVM>();
            DataTable dt = new DataTable();
            dt = db.SearchSecurityUser(searchstr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SecurityUserVM vm = new SecurityUserVM
                {
                    Email = dt.Rows[i]["Email"].ToString(),
                    LoginId = dt.Rows[i]["LoginId"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    PhoneNo = dt.Rows[i]["PhoneNo"].ToString(),
                    StatusName = dt.Rows[i]["StatusName"].ToString(),
                    UserId = Convert.ToInt16(dt.Rows[i]["Id"]),
                    CCY = Convert.ToInt16(dt.Rows[0]["StatusId"]),
                    Unit = Convert.ToInt16(dt.Rows[0]["Unit"]),
                    UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]),
                };
                list.Add(vm);

            }
            return list;
        }

        internal void SecurityUserEmailVerify(string LoginId)
        {

                db.SecurityUserEmailVerify(LoginId);
        }

        internal Result EmailPhoneDuplicateChecking(string phoneNo, string email)
        {
            Result result = new Result();
            try
            {
                result = db.EmailPhoneDuplicateChecking(phoneNo, email);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }

    internal class SecurityPolicyVM
    {
        public int PasswordLength { set; get; }
        public bool PhoneNoValidation { set; get; }
        public int BadLoginAttampt { set; get; }
        public bool EmailVarified { set; get; }
        public bool CaptchaValidation { set; get; }
    }
}