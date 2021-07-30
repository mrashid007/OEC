using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineExamCenter.Models;
using OnlineExamCenter.DAL;
using OnlineExamCenter.ModelsVM;
using System.Data;

namespace OnlineExamCenter.Manager
{
    public class QuestionBankManager
    {
        internal Result SaveQuestionDomain(string Domain,string description,int questionweight, int entryBy)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.SaveQuestionDomain(Domain, description, questionweight, entryBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;           
            
        }

        internal List<UserBillVM> SelectUserBill(int userId,string fromDate,string toDate)
        {
            List<UserBillVM> list = new List<UserBillVM>();
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();

            if (fromDate == "")
                fromDate = DateTime.Now.AddDays(-1).ToString();

            if (toDate == "")
                toDate = DateTime.Now.ToString();



            dt = db.SelectUserBill(userId,Convert.ToDateTime(fromDate),Convert.ToDateTime(toDate));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserBillVM vm = new UserBillVM
                {
                    Unit = Convert.ToInt16(dt.Rows[i]["Unit"]),
                    UnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"]),
                    Amount = Convert.ToDecimal(dt.Rows[i]["Amount"]),
                    QuestionWeight = dt.Rows[i]["QuestionWeight"].ToString(),
                    QuestionDomin = dt.Rows[i]["QuestionDomin"].ToString(),
                    NumberOfQuestion =Convert.ToInt32(dt.Rows[i]["NumberOfQuestion"]),
                    QuestionType = dt.Rows[i]["QuestionType"].ToString(),
                    BillFor= dt.Rows[i]["BillFor"].ToString()
                };
                list.Add(vm);
            }
            return list;
        }

        internal decimal CalculateUserBalance(int userid, string drcr)
        {
            VoucherDB db = new VoucherDB();
            return db.CalculateUserBalance(userid, drcr);

        }

        internal List<QuestionWeightVM> SelectQuestionWeight()
        {
            QuestionDB db = new QuestionDB();
            List<QuestionWeightVM> list = new List<QuestionWeightVM>();
            DataTable dt = new DataTable();
            dt = db.SelectQuestionWeight();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                QuestionWeightVM vm = new QuestionWeightVM
                {
                    Id =Convert.ToInt32(dt.Rows[i]["Id"]),
                    StatusId = Convert.ToInt32(dt.Rows[i]["StatusId"]),
                    Weight = dt.Rows[i]["Weight"].ToString(),
                    StatusName = dt.Rows[i]["StatusName"].ToString()
                };
                list.Add(vm);
            }
            return list;
        }

        internal Result WithdrawBalance(int userId,decimal amount)
        {
            Result result = new Result();
            VoucherDB db = new VoucherDB();

            result = db.WithdrawBalance(userId,amount);

            return result;
        }

        internal List<Question> SelectUnApprovedQuestionList(int typeid, int domainid, int weightid, int statusid)
        {
            List<Question> list = new List<Question>();
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectUnApprovedQuestionList(typeid, domainid, weightid, statusid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Question vm = new Question
                {
                    QuestionId = Convert.ToInt16(dt.Rows[i]["QuestionId"]),
                    IsForPractise = Convert.ToInt16(dt.Rows[i]["IsForPractise"]),
                    Reference = dt.Rows[i]["Reference"].ToString(),
                    ExpiryDate = dt.Rows[i]["ExpiryDate"].ToString(),
                    WeightName = dt.Rows[i]["WeightName"].ToString(),
                    EntryDate = dt.Rows[i]["EntryDate"].ToString(),
                    UpdateDate = dt.Rows[i]["UpdateDate"].ToString(),
                    TypeName = dt.Rows[i]["TypeName"].ToString(),
                    QuestionStr = dt.Rows[i]["QuestionStr"].ToString(),
                    StatusName = dt.Rows[i]["StatusName"].ToString(),
                    DomainName = dt.Rows[i]["DomainName"].ToString()
                };
                list.Add(vm);
            }
            return list;
        }

        internal Result ApproveQuestion(string[] ids,int approveBy)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                for (int i = 0; i < ids.Length; i++)
                {
                     db.ApproveQuestion(Convert.ToInt32(ids[i]), approveBy);
                }
                
                //CreatePaymentVoucher();

                result.IsSuccess = true;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public Result AccountLedgerProcess() 
        {
            Result result = new Result();
            VoucherDB db = new VoucherDB();

            result=  db.InsertAccountLedger();

            return result;
        }

        internal Result InsertActivationKey(string newKey, string validDays)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.InsertActivationKey(newKey, validDays);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal Result SaveQuestionWeight(string weight, int entryBy)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.SaveQuestionWeight(weight, entryBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal List<QuestionDomainVM> SelectQuestionDomain()
        {
            QuestionDB db = new QuestionDB();
            List<QuestionDomainVM> list = new List<QuestionDomainVM>();
            DataTable dt = new DataTable();
            dt = db.SelectQuestionDomain();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                QuestionDomainVM vm = new QuestionDomainVM
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    StatusId = Convert.ToInt32(dt.Rows[i]["StatusId"]),
                    Description = dt.Rows[i]["Description"].ToString(),
                    DomainWeight = Convert.ToInt32(dt.Rows[i]["DomainWeight"]),
                    Domain = dt.Rows[i]["Domain"].ToString(),
                    StatusName = dt.Rows[i]["StatusName"].ToString(),
                    LastUpdate =Convert.ToDateTime(dt.Rows[i]["UpdateDate"]).ToShortDateString()
                    
                };
                list.Add(vm);

            }
            return list;
        }

        internal Result UpdateQuestionWeight(int weightId, string weight, int statusId,int entryBy)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.UpdateQuestionWeight(weightId, weight, statusId, entryBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal QuestionWeightVM SelectSingleQuestionWeight(int weightid)
        {
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectSingleQuestionWeight(weightid);
            QuestionWeightVM vm = new QuestionWeightVM
            {
                Weight = dt.Rows[0]["Weight"].ToString(),
                Id = Convert.ToInt16(dt.Rows[0]["Id"]),
                StatusName = dt.Rows[0]["StatusName"].ToString(),
                StatusId = Convert.ToInt16(dt.Rows[0]["StatusId"]),
            };
            return vm;
        }

        internal QuestionDomainVM SelectSingleQuestionDomain(int domainId)
        {
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectSingleQuestionDomain(domainId);
            QuestionDomainVM vm = new QuestionDomainVM
            {
                Domain = dt.Rows[0]["Domain"].ToString(),
                Description= dt.Rows[0]["Description"].ToString(),
                DomainWeight=Convert.ToInt32(dt.Rows[0]["DomainWeight"]),
                Id = Convert.ToInt16(dt.Rows[0]["Id"]),
                StatusName = dt.Rows[0]["StatusName"].ToString(),
                StatusId = Convert.ToInt16(dt.Rows[0]["StatusId"]),
                LastUpdate = dt.Rows[0]["UpdateDate"].ToString()
            };
            return vm;
        }

        internal Result UpdateQuestionDomain(int domainId, string domain, int statusId, int updateBy, string description, int questionweight)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.UpdateQuestionDomain(domainId, domain, statusId, updateBy, description, questionweight);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal List<QuestionTypeVM> SelectQuestionTye()
        {
            List<QuestionTypeVM> list = new List<QuestionTypeVM>();
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectQuestionTye();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                QuestionTypeVM vm = new QuestionTypeVM
                {
                    TypeName = dt.Rows[i]["TypeName"].ToString(),
                    Id = Convert.ToInt16(dt.Rows[i]["TypeId"]),
                    StatusName = dt.Rows[i]["StatusName"].ToString(),
                    StatusId = Convert.ToInt16(dt.Rows[i]["StatusId"]),
                };
                list.Add(vm);
            }
            return list;
        }

        internal Result SaveQuestionType(string questionType, int entryBy)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.SaveQuestionType(questionType, entryBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal Result UpdateQuestionType(int typeId, string questionType, int statusId, int updateBy)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.UpdateQuestionType(typeId, questionType, statusId, updateBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal QuestionTypeVM SelectSingleQuestionTye(int typeid)
        {
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectSingleQuestionTye(typeid);
            QuestionTypeVM vm = new QuestionTypeVM
            {
                TypeName = dt.Rows[0]["TypeName"].ToString(),
                Id = Convert.ToInt16(dt.Rows[0]["TypeId"]),
                StatusName = dt.Rows[0]["StatusName"].ToString(),
                StatusId = Convert.ToInt16(dt.Rows[0]["StatusId"]),
            };
            return vm;
        }

        internal Result SaveNewQuestion(int questiontypeid, int domainid, int questionweightid, string question, string expirydate, string explanation, string option1, string option2, string option3, string option4, int rdbOption1, int rdbOption2, int rdbOption3, int rdbOption4, int rdbOption5, int rdbOption6, int chkOption5, int chkOption6, string practise, string questionReference, int entryBy)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.SaveNewQuestion(questiontypeid, domainid, questionweightid, question,
                    expirydate, explanation, option1, option2, option3,
                    option4, rdbOption1, rdbOption2, rdbOption3, rdbOption4,
                    rdbOption5, rdbOption6, chkOption5, chkOption6, practise, questionReference, entryBy);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal List<Question> SelectQuestionList(int typeid,int domainid,int weightid,string dateFrom,string dateTo)
        {
            List<Question> list = new List<Question>();
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectQuestionList(typeid, domainid, weightid, dateFrom, dateTo);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Question vm = new Question
                {
                    QuestionId = Convert.ToInt16(dt.Rows[i]["QuestionId"]),
                    IsForPractise= Convert.ToInt16(dt.Rows[i]["IsForPractise"]),
                    Reference= dt.Rows[i]["Reference"].ToString(),
                    ExpiryDate = dt.Rows[i]["ExpiryDate"].ToString(),
                    WeightName = dt.Rows[i]["WeightName"].ToString(),
                    EntryDate = dt.Rows[i]["EntryDate"].ToString(),
                    UpdateDate = dt.Rows[i]["UpdateDate"].ToString(),
                    TypeName = dt.Rows[i]["TypeName"].ToString(),
                    QuestionStr= dt.Rows[i]["QuestionStr"].ToString(),
                    StatusName = dt.Rows[i]["StatusName"].ToString(),
                    DomainName= dt.Rows[i]["DomainName"].ToString()
                };
                list.Add(vm);
            }
            return list;
        }

        internal QuestionVM SelectSingleQuestion(int questionId)
        {
            List<Question> list = new List<Question>();
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectSingleQuestion(questionId);
            QuestionVM vm = new QuestionVM
            {
                QuestionNo= dt.Rows[0]["QuestionNo"].ToString(),
                QuestionId = Convert.ToInt16(dt.Rows[0]["QuestionId"]),
                IsForPractise = Convert.ToInt16(dt.Rows[0]["IsForPractise"]),
                Reference = dt.Rows[0]["Reference"].ToString(),
                ExpiryDate = dt.Rows[0]["ExpiryDate"].ToString(),
                WeightName = dt.Rows[0]["WeightName"].ToString(),
                EntryDate = dt.Rows[0]["EntryDate"].ToString(),
                UpdateDate = dt.Rows[0]["UpdateDate"].ToString(),
                TypeName = dt.Rows[0]["TypeName"].ToString(),
                QuestionStr = dt.Rows[0]["QuestionStr"].ToString(),
                StatusName = dt.Rows[0]["StatusName"].ToString(),
                DomainName = dt.Rows[0]["DomainName"].ToString(),
                AnswerPosition = Convert.ToInt16(dt.Rows[0]["AnswerPosition"]),
                Explanation = dt.Rows[0]["Explanation"].ToString(),
                DomainId = Convert.ToInt16(dt.Rows[0]["DomainId"]),
                Option1 = dt.Rows[0]["Option1"].ToString(),
                Option2 = dt.Rows[0]["Option2"].ToString(),
                Option3 = dt.Rows[0]["Option3"].ToString(),
                Option4 = dt.Rows[0]["Option4"].ToString(),
                Option5 = dt.Rows[0]["Option5"].ToString(),
                Option6 = dt.Rows[0]["Option6"].ToString(),
                StatusId = Convert.ToInt16(dt.Rows[0]["StatusId"]),
                TypeId  = Convert.ToInt16(dt.Rows[0]["TypeId"]),
                UpdateBy = Convert.ToInt16(dt.Rows[0]["UpdateBy"]),
                WeightId = Convert.ToInt16(dt.Rows[0]["WeightId"]),
            };
            return vm;
        }

        internal QuestionVM SelectSingleQuestion(string questionNo)
        {
            List<Question> list = new List<Question>();
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            dt = db.SelectSingleQuestion(questionNo);
            QuestionVM vm = new QuestionVM
            {
                QuestionNo = dt.Rows[0]["QuestionNo"].ToString(),
                QuestionId = Convert.ToInt16(dt.Rows[0]["QuestionId"]),
                IsForPractise = Convert.ToInt16(dt.Rows[0]["IsForPractise"]),
                Reference = dt.Rows[0]["Reference"].ToString(),
                ExpiryDate = dt.Rows[0]["ExpiryDate"].ToString(),
                WeightName = dt.Rows[0]["WeightName"].ToString(),
                EntryDate = dt.Rows[0]["EntryDate"].ToString(),
                UpdateDate = dt.Rows[0]["UpdateDate"].ToString(),
                TypeName = dt.Rows[0]["TypeName"].ToString(),
                QuestionStr = dt.Rows[0]["QuestionStr"].ToString(),
                StatusName = dt.Rows[0]["StatusName"].ToString(),
                DomainName = dt.Rows[0]["DomainName"].ToString(),
                AnswerPosition = Convert.ToInt16(dt.Rows[0]["AnswerPosition"]),
                Explanation = dt.Rows[0]["Explanation"].ToString(),
                DomainId = Convert.ToInt16(dt.Rows[0]["DomainId"]),
                Option1 = dt.Rows[0]["Option1"].ToString(),
                Option2 = dt.Rows[0]["Option2"].ToString(),
                Option3 = dt.Rows[0]["Option3"].ToString(),
                Option4 = dt.Rows[0]["Option4"].ToString(),
                Option5 = dt.Rows[0]["Option5"].ToString(),
                Option6 = dt.Rows[0]["Option6"].ToString(),
                StatusId = Convert.ToInt16(dt.Rows[0]["StatusId"]),
                TypeId = Convert.ToInt16(dt.Rows[0]["TypeId"]),
                UpdateBy = Convert.ToInt16(dt.Rows[0]["UpdateBy"]),
                WeightId = Convert.ToInt16(dt.Rows[0]["WeightId"]),
            };
            return vm;
        }

        internal QuestionVM SelectSingleQuestionByQuestionNo(string questionNo,int type)
        {
            List<Question> list = new List<Question>();
            DataTable dt = new DataTable();
            QuestionDB db = new QuestionDB();
            if (String.IsNullOrEmpty(questionNo))
            {
                QuestionVM vmmm = new QuestionVM();
                return vmmm;
            }

            dt = db.SelectSingleQuestionByQuestionNo(questionNo, type);
            if(dt.Rows.Count==0)
            {
                QuestionVM vmm = new QuestionVM();
                return vmm;
            }
            QuestionVM vm = new QuestionVM
            {
                QuestionNo = dt.Rows[0]["QuestionNo"].ToString(),
                QuestionId = Convert.ToInt16(dt.Rows[0]["QuestionId"]),
                IsForPractise = Convert.ToInt16(dt.Rows[0]["IsForPractise"]),
                Reference = dt.Rows[0]["Reference"].ToString(),
                ExpiryDate = dt.Rows[0]["ExpiryDate"].ToString(),
                WeightName = dt.Rows[0]["WeightName"].ToString(),
                EntryDate = dt.Rows[0]["EntryDate"].ToString(),
                UpdateDate = dt.Rows[0]["UpdateDate"].ToString(),
                TypeName = dt.Rows[0]["TypeName"].ToString(),
                QuestionStr = dt.Rows[0]["QuestionStr"].ToString(),
                StatusName = dt.Rows[0]["StatusName"].ToString(),
                DomainName = dt.Rows[0]["DomainName"].ToString(),
                AnswerPosition = Convert.ToInt16(dt.Rows[0]["AnswerPosition"]),
                Explanation = dt.Rows[0]["Explanation"].ToString(),
                DomainId = Convert.ToInt16(dt.Rows[0]["DomainId"]),
                Option1 = dt.Rows[0]["Option1"].ToString(),
                Option2 = dt.Rows[0]["Option2"].ToString(),
                Option3 = dt.Rows[0]["Option3"].ToString(),
                Option4 = dt.Rows[0]["Option4"].ToString(),
                Option5 = dt.Rows[0]["Option5"].ToString(),
                Option6 = dt.Rows[0]["Option6"].ToString(),
                StatusId = Convert.ToInt16(dt.Rows[0]["StatusId"]),
                TypeId = Convert.ToInt16(dt.Rows[0]["TypeId"]),
                UpdateBy = Convert.ToInt16(dt.Rows[0]["UpdateBy"]),
                WeightId = Convert.ToInt16(dt.Rows[0]["WeightId"]),
            };
            return vm;
        }

        internal Result UpdateNewQuestion(int questionId, int questiontypeid, int domainid, int questionweightid, string question, 
            string expirydate, string explanation, string option1, string option2, string option3, string option4, int rdbOption1, 
            int rdbOption2, int rdbOption3, int rdbOption4, int rdbOption5, int rdbOption6, int chkOption5, int chkOption6, 
            string practise, string questionReference, int updateBy,int statusid)
        {
            QuestionDB db = new QuestionDB();
            Result result = new Result();
            try
            {
                result = db.UpdateNewQuestion(questionId,questiontypeid, domainid, questionweightid, question,
                    expirydate, explanation, option1, option2, option3,
                    option4, rdbOption1, rdbOption2, rdbOption3, rdbOption4,
                    rdbOption5, rdbOption6, chkOption5, chkOption6, practise, questionReference, updateBy,statusid);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}