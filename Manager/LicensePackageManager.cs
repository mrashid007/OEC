using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineExamCenter.ModelsVM;
using System.Data;
using OnlineExamCenter.DAL;
using OnlineExamCenter.Models;

namespace OnlineExamCenter.Manager
{
    public class LicensePackageManager
    {
        internal List<LicensePackageVM> SelectLicensePackage(int packageId)
        {
            List<LicensePackageVM> list = new List<LicensePackageVM>();
            DataTable dt = new DataTable();
            LicensePackageDB db = new LicensePackageDB();

            dt = db.SelectLicensePackageList(packageId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LicensePackageVM vm = new LicensePackageVM
                {
                    PackageId=Convert.ToInt32(dt.Rows[i]["PackageId"].ToString()),
                    PackageName = dt.Rows[i]["PackageName"].ToString(),
                    DaysValidity = dt.Rows[i]["DaysValidity"].ToString(),
                    Price = Convert.ToDecimal(dt.Rows[i]["Price"])
                };
                list.Add(vm);
            }
            return list;
        }

        internal Result InsertLicensePackage(string packageName, string validDays, string price)
        {
            LicensePackageDB db = new LicensePackageDB();
            Result result = new Result();
            try
            {
                result = db.InsertLicensePackage(packageName, validDays, price);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        internal Result UpdateLicensePackage(int packageId,string packageName, string validDays, string price)
        {
            LicensePackageDB db = new LicensePackageDB();
            Result result = new Result();
            try
            {
                result = db.UpdateLicensePackage(packageId,packageName, validDays, price);
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