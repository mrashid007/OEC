using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineExamCenter.Models;
using System.Data;
using OnlineExamCenter.ModelsVM;
using OnlineExamCenter.DAL;

namespace OnlineExamCenter.Manager
{
    public class LoginManager
    {
        //internal EmpLoggedInDetails UserLogin(string userName, string userPassword)
        //{
        //    UserDB db = new UserDB();
        //    return db.Login2(userName,userPassword);
        //}

        internal Result ChangePassword(int userId, string password)
        {
            UserDB db = new UserDB();
            db.UpdatePassword(userId, password, password);
            Result result = new Result
            {
                IsSuccess = true,
                Message = "Successfully Changed"
            };
            return result;
        }

        internal EmpLoggedInDetails UserLogin(string userName, string userPassword)
        {
            UserDB db = new UserDB();
            //EmpLoggedInDetails item = new EmpLoggedInDetails();
            return db.UserLogin(userName,userPassword);
        }
        internal Result ResetPassword(string loginId)
        {
            UserDB db = new UserDB();

            Result result = db.ResetPassword(loginId, "1");

            return result;
        }

        internal Result ChangePasswordWithOTP(int userId, string password, string otp)
        {
            UserDB db = new UserDB();

            Result result = db.ChangePasswordWithOTP(userId, password,otp);

            return result;
        }
    }
}