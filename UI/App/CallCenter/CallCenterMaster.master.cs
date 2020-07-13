using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Enum;


public partial  class CallCenter_CallCenterMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        var sessionContext = IoC.Resolve<ISessionContext>();
        dvcurrentTime.InnerHtml = DateTime.Now.ToString();
        if (IsPostBack != true)
        {
            //Save CCMonitor Details
            spcurdate.InnerHtml = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
            var orgRoleUser = sessionContext.UserSession.CurrentOrganizationRole;
            Ucmenucontrol2.RoleName = orgRoleUser.RoleAlias;

            var currentRole = (Roles)orgRoleUser.GetSystemRoleId;
            switch (currentRole)
            {
                //case Roles.CallCenterAdmin:
                //    Ucwelcomebox2.SetLinks(Roles.CallCenterAdmin);
                //    break;
                case Roles.CallCenterRep:
                    Ucwelcomebox2.SetLinks(Roles.CallCenterRep);
                    //GetCallDetails(sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    break;
                case Roles.CallCenterManager:
                    Ucwelcomebox2.SetLinks(Roles.CallCenterManager);
                    break;
                default:
                    break;
            }
        }
    }

    public void settitle(string title)
    {
        spchildname.InnerHtml = title;
        Ucsearchbox1.setuctitle(title);
    }

    /// <summary>
    /// Property to set breadcrumb's root name and link
    /// value should be like 
    /// <a href="/App/Franchisor/ViewProspects.aspx">Prospect</a>
    /// </summary>
    public string SetBreadCrumbRoot
    {
        set
        {
            spnRoot.InnerHtml = value;
        }
    }

    public void showsearch()
    {
        Ucsearchbox1.Visible = true;
    }

    private void GetCallDetails(long intCCUserID)
    {

        CallCenterDAL objCCRepDAL = new CallCenterDAL();
        List<ECall> objCalls = objCCRepDAL.GetCalls(intCCUserID, 1);

        string totalCall;
        string averageCall;
        string maxCall;
        string minCall;
        string Recent1 = "-N/A-";
        string Recent2 = "-N/A-";
        if (objCalls != null && objCalls.Count > 0)
        {
            int hours = 0;
            int min = 0;
            int sec = 0;
            int TotalTime = 0;
            int totalHrs = 0;
            int totalMin = 0;
            int totalSec = 0;
            int avgMin = 0;
            int avghr = 0;
            int avgSec = 0;

            TimeSpan MinDuartion = new TimeSpan();
            TimeSpan MaxDuartion = new TimeSpan();
            TimeSpan callDuration = new TimeSpan();
            

            totalCall = objCalls[0].TotalCalls.ToString();
            string status = objCalls[0].CallStatus.Length > 0 ? objCalls[0].CallStatus : "Interupted";
            Recent1 = "Call for " + status + " on " + Convert.ToDateTime(objCalls[0].DateCreated).ToShortDateString() + " at " + Convert.ToDateTime(objCalls[0].DateCreated).ToShortTimeString();
            if (objCalls.Count > 1)
            {
                status = objCalls[1].CallStatus.Length > 0 ? objCalls[1].CallStatus : "Interupted";
                Recent2 = "Call for " + status + " on " + Convert.ToDateTime(objCalls[1].DateCreated).ToShortDateString() + " at " + Convert.ToDateTime(objCalls[1].DateCreated).ToShortTimeString();
            }

            for (int i = 0; i < objCalls.Count; i++)
            {
                callDuration = Convert.ToDateTime(objCalls[i].TimeEnd).Subtract(Convert.ToDateTime(objCalls[i].TimeCreated));
                hours = hours + Convert.ToInt32(callDuration.Hours.ToString());
                min = min + Convert.ToInt32(callDuration.Minutes.ToString());
                sec = sec + Convert.ToInt32(callDuration.Seconds.ToString());
                if (callDuration > MaxDuartion)
                {
                    MaxDuartion = callDuration;
                }

                if (i == 0)
                {
                    MinDuartion = callDuration;
                }

                if (callDuration < MinDuartion)
                {
                    MinDuartion = callDuration;
                }
            }


            TotalTime = (hours * 3600) + (min * 60) + sec;

            totalHrs = TotalTime / 3600;
            totalMin = (TotalTime % 3600) / 60;
            totalSec = (TotalTime % 3600) % 60;

            TotalTime = TotalTime / objCalls.Count;
            avghr = TotalTime / 3600;
            avgMin = (TotalTime % 3600) / 60;
            avgSec = (TotalTime % 3600) % 60;

            if (avghr > 0)
            {
                averageCall = avghr + "." + avgMin + "." + avgSec + "H";
            }
            else
            {
                averageCall = avgMin + "." + avgSec + "M";
            }

            
            if (Convert.ToInt32(MaxDuartion.Hours.ToString()) > 0)
            {
                maxCall = MaxDuartion.Hours.ToString() + "." + MaxDuartion.Minutes.ToString() + "." + MaxDuartion.Seconds.ToString() + "H";
            }
            else
            {
                maxCall = MaxDuartion.Minutes.ToString() + "." + MaxDuartion.Seconds.ToString() + "M";
            }

            if (Convert.ToInt32(MinDuartion.Hours.ToString()) > 0)
            {
                minCall = MinDuartion.Hours.ToString() + "." + MinDuartion.Minutes.ToString() + "." + MinDuartion.Seconds.ToString() + "H";
            }
            else
            {
                minCall = MinDuartion.Minutes.ToString() + "." + MinDuartion.Seconds.ToString() + "M";
            }
        }
        else
        {
            averageCall = "-N/A-";
            totalCall = "-N/A-";
            minCall = "-N/A-";
            maxCall = "-N/A-";
        }

        Ucleftpanel1.SetDetails(totalCall, averageCall, maxCall, minCall);
        Ucleftpanel1.SetRecentCalls(Recent1, Recent2);

    }

    public void ShowHideLeftPanel(bool showHideFlag)
    {
        LeftNavDiv.Visible = showHideFlag;
    }

    protected void ddlUserShellRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

}
