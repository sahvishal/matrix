using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.Entity.User;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Lib;

public partial class App_MedicalVendor_AsyncCallSupport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["EvaluationScreenSummary"] != null)
        {

            long roleShellId = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            IMedicalVendorEarningRepository medicalVendorEarningRepository = new MedicalVendorEarningRepository();
            List<MedicalVendorEarning> earnings = medicalVendorEarningRepository.GetEarningsForMedicalVendorUser(roleShellId, new DateTime(1900, 1, 1), DateTime.Now);

            Func<MedicalVendorEarning, decimal> amountEarnedSum = earning => earning.MedicalVendorUserAmountEarned;
            int numberOfRecordsAllTime = earnings.Count();
            decimal amountEarnedAllTime = earnings.Sum(amountEarnedSum);

            Func<MedicalVendorEarning, bool> thisMonthFilter = earning => earning.DataRecorderMetaData.DateCreated >= DateTime.Today.GetFirstDayOfMonth()
                && earning.DataRecorderMetaData.DateCreated <= DateTime.Now;
            int numberOfRecordsThisMonth = earnings.Where(thisMonthFilter).Count();
            decimal amountEarnedThisMonth = earnings.Where(thisMonthFilter).Sum(amountEarnedSum);

            Func<MedicalVendorEarning, bool> thisWeekFilter = earning => earning.DataRecorderMetaData.DateCreated >= DateTime.Today.GetFirstDayOfWeek()
                && earning.DataRecorderMetaData.DateCreated <= DateTime.Now;
            int numberOfRecordsThisWeek = earnings.Where(thisWeekFilter).Count();
            decimal amountEarnedThisWeek = earnings.Where(thisWeekFilter).Sum(amountEarnedSum);

            Func<MedicalVendorEarning, bool> todayFilter = earning => earning.DataRecorderMetaData.DateCreated >= DateTime.Today &&
                earning.DataRecorderMetaData.DateCreated <= DateTime.Now;
            int numberOfRecordsToday = earnings.Where(todayFilter).Count();
            decimal amountEarnedToday = earnings.Where(todayFilter).Sum(amountEarnedSum);

            string responseString = "ReviewAll=" + numberOfRecordsAllTime + ", ";
            responseString += "EarningAll=" + string.Format("{0:c}, ", amountEarnedAllTime);
            responseString += "ReviewMonth=" + numberOfRecordsThisMonth + ", ";
            responseString += "EarningMonth=" + string.Format("{0:c}, ", amountEarnedThisMonth);
            responseString += "ReviewWeek=" + numberOfRecordsThisWeek + ", ";
            responseString += "EarningWeek=" + string.Format("{0:c}, ", amountEarnedThisWeek);
            responseString += "ReviewToday=" + numberOfRecordsToday + ", ";
            responseString += "EarningToday=" + string.Format("{0:c}, ", amountEarnedToday);

            if (responseString.Trim().Length > 1)
            {
                responseString = responseString.Trim().Remove(responseString.LastIndexOf(","));
            }

            Response.Write(responseString);
            Response.End();
        }
    }
}
