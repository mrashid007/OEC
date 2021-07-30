using OnlineExamCenter.DAL;
using OnlineExamCenter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnlineExamCenter.Manager
{
    public class AccountManager
    {
        VoucherDB db = new VoucherDB();


        public List<AccountLedgerVM> GetAccountLedger(string accno,string fromdate, string todate)
        {

            List<AccountLedgerVM> list = new List<AccountLedgerVM>();
            DataTable dt = db.GetAccountLedger(accno,fromdate,todate);  
            for(int i=0; dt.Rows.Count>i;i++)
            {
                AccountLedgerVM item = new AccountLedgerVM
                {
                    AccountNo = dt.Rows[i]["AccountNo"].ToString(),
                    AccountTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    Particular = dt.Rows[i]["Particular"].ToString(),
                    DrAmount = dt.Rows[i]["DrAmount"].ToString(),
                    CrAmount = dt.Rows[i]["CrAmount"].ToString(),
                    TxnDate = dt.Rows[i]["TxnDate"].ToString(),
                    TxnType= dt.Rows[i]["TxnType"].ToString()
                };
                list.Add(item);
            }
            return list;
        }
    }
}