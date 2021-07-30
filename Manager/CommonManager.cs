using OnlineExamCenter.DAL;
using OnlineExamCenter.Models;
using OnlineExamCenter.ModelsVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnlineExamCenter.Manager
{
    public class CommonManager
    {
        CommonDB db = new CommonDB();
        public List<UserRole> SelectRole()
        {
            List<UserRole> list = new List<UserRole>();
            DataTable dt = new DataTable();
            dt = db.SelectRole();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserRole status = new UserRole
                {
                    RoleId = Convert.ToInt16(dt.Rows[i]["Id"]),
                    RoleCode= dt.Rows[i]["Code"].ToString(),
                    RoleName = dt.Rows[i]["RoleName"].ToString()
                };
                list.Add(status);

            }
            return list;
        }

        internal dynamic GetTxnTypeList()
        {
            List<SelectItem> list = new List<SelectItem>();
            SelectItem status = new SelectItem
            {
                Value = "Dr",
                Name = "Debit"
            };
            list.Add(status);

            SelectItem status1 = new SelectItem
            {
                Value = "Cr",
                Name = "Credit"
            };
            list.Add(status1);


            return list;
        }

        internal List<SelectItem> GetAccountList(int typeid)
        {
            List<SelectItem> list = new List<SelectItem>();
            DataTable dt = new DataTable();
            dt = db.SelectAccountList(typeid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SelectItem status = new SelectItem
                {
                    Value = dt.Rows[i]["AccountNo"].ToString(),
                    Name = dt.Rows[i]["AccountName"].ToString()
                };
                list.Add(status);
            }
            return list;
        }

        public List<Status> SelectStatus()
        {
            List<Status> list = new List<Status>();
            DataTable dt = new DataTable();
            dt=db.SelectCommonStatus();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                Status status = new Status
                {
                    StatusId = Convert.ToInt16(dt.Rows[i]["Id"]),
                    StatusName = dt.Rows[i]["Status"].ToString()
                };
                list.Add(status);

            }
            return list;
        }
        public List<Country> SelectCountry()
        {
            List<Country> list = new List<Country>();
            DataTable dt = new DataTable();
            dt = db.SelectCountry();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Country country = new Country
                {
                    Id = Convert.ToInt16(dt.Rows[i]["Id"]),
                    Name = dt.Rows[i]["Country"].ToString()
                };
                list.Add(country);

            }
            return list;
        }

        internal dynamic SelectCurrency()
        {
            List<Currency> list = new List<Currency>();
            DataTable dt = new DataTable();
            dt = db.SelectCurrency();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Currency country = new Currency
                {
                    CurrencyId = Convert.ToInt16(dt.Rows[i]["CurrencyId"]),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString()
                };
                list.Add(country);

            }
            return list;
        }

        internal dynamic SelectUserType()
        {
            List<UserType> list = new List<UserType>();

            UserType itemWeb = new UserType
            {
                TypeId = 1,
                TypeName = "WEB"
            };
            list.Add(itemWeb);
            UserType itemApp = new UserType
            {
                TypeId = 2,
                TypeName = "APP"
            };
            list.Add(itemApp);

            return list;
        }
        internal DataTable GetEmailAddressForMail(int officeId)
        {
            CommonDB mgr = new CommonDB();
            return mgr.GetEmailAddressForMail(officeId);
        }

        internal List<string> GetUserContactNo(string emailid, string phoneNo)
        {
            CommonDB db = new CommonDB();
            return db.GetUserContactNo(emailid, phoneNo);
        }

        internal void ResetUserPassword(string loginId,string defaultPass)
        {
            CommonDB db = new CommonDB();
            db.ResetUserPassword(loginId, defaultPass);
        }

        internal string GetUserEmail(string userid)
        {
            CommonDB db = new CommonDB();
            return db.GetUserEmail(userid);
        }
    }
}