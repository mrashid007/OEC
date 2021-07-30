using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamCenter.Controllers
{
    public static class MenuActive
    {
       public static void SetActiveMenu(string menu)
        {

            if (menu.ToLower() == "dashboard")
            {
                HttpContext.Current.Session["DashBoard"] = "active";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "UserBill")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["UserBill"] = "active";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "QuestionManagement")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "active";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "QuestionWeightSetup")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "active";
                HttpContext.Current.Session["QuestionWeightSetup"] = "active";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "QuestionDomainSetup")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "active";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "active";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "QuestionTypeSetup")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "active";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "active";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "NewQuestion")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "active";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "active";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "FlashCard")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "active";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "UserSecurityQuestion")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "active";
                HttpContext.Current.Session["UserSecurityQuestion"] = "active";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "SecurityUserVerification")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "active";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "active";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "NewSecurityUser")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "active";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "active";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "AppSecurityUser")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "active";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "active";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "SecurityUserPasswordPolicy")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "active";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "active";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "KeyGeneration")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "active";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "QuestionApproval")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "active";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "LicensePackage")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "active";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "AccountLedger")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "active";
                HttpContext.Current.Session["AccountLedger"] = "active";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if (menu == "AccountSetting")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "active";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "active";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if(menu== "AccountingProcess")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "Active";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "";
            }
            else if(menu== "UserBill")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "Active";
                HttpContext.Current.Session["UserBillWithdrow"] = "Active";
            }
            else if(menu== "UserBillWithdrow")
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["UserBillWithdrow"] = "Active";
            }           
            else
            {
                HttpContext.Current.Session["DashBoard"] = "";
                HttpContext.Current.Session["QuestionManagement"] = "";
                HttpContext.Current.Session["QuestionWeightSetup"] = "";
                HttpContext.Current.Session["QuestionDomainSetup"] = "";
                HttpContext.Current.Session["QuestionTypeSetup"] = "";
                HttpContext.Current.Session["NewQuestion"] = "";
                HttpContext.Current.Session["UserBill"] = "";
                HttpContext.Current.Session["FlashCard"] = "";
                HttpContext.Current.Session["KeyGeneration"] = "";
                HttpContext.Current.Session["UserSecurity"] = "";
                HttpContext.Current.Session["UserSecurityQuestion"] = "";
                HttpContext.Current.Session["SecurityUserPasswordPolicy"] = "";
                HttpContext.Current.Session["SecurityUserVerification"] = "";
                HttpContext.Current.Session["NewSecurityUser"] = "";
                HttpContext.Current.Session["AppSecurityUser"] = "";
                HttpContext.Current.Session["QuestionApproval"] = "";
                HttpContext.Current.Session["LicensePackage"] = "";
                HttpContext.Current.Session["Report"] = "";
                HttpContext.Current.Session["AccountLedger"] = "";
                HttpContext.Current.Session["AccountSetting"] = "";
                HttpContext.Current.Session["AccountingProcess"] = "";
            }
        }
    }
}