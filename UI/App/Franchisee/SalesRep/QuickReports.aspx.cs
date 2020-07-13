using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class Franchisee_SalesRep_QuickReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Quick Reports";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Quick Report");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Reports</a>";
        obj.hideucsearch();
        if (!IsPostBack)
        {
            ViewState["SortEvent"] = SortDirection.Ascending;
            FillReport();
        }

    }

    protected void FillReport()
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        int roleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);
        int shellID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);
        int userID = Convert.ToInt32(currentSession.UserId);

        var masterDal = new MasterDAL();
        List<EEvent> eevent = masterDal.GetEventsByUserID(userID, roleID, shellID);

        string status = string.Empty;
        

        DataTable dtEvent = new DataTable();
        dtEvent.Columns.Add("EventID", typeof(Int32));
        dtEvent.Columns.Add("Date",typeof(DateTime));
        dtEvent.Columns.Add("EventName");
        dtEvent.Columns.Add("Status");
        dtEvent.Columns.Add("CustomerCount");
        dtEvent.Columns.Add("Pod");

        if (eevent != null)
        {

            for (int icount = 0; icount < eevent.Count; icount++)
            {
                string pod = string.Empty;
                if (eevent[icount].EventDate.Equals(DateTime.Now.ToShortDateString()) && eevent[icount].EventEndTime.Equals(DateTime.Now.ToShortTimeString()))
                {
                    status = "Ended";
                }
                else if ((Convert.ToDateTime(eevent[icount].EventDate).Day == DateTime.Now.Day) && (Convert.ToDateTime(eevent[icount].EventDate).Month == DateTime.Now.Month))
                {
                    status = "InProgress";
                }
                else if (Convert.ToDateTime(eevent[icount].EventDate).Month < DateTime.Now.Month)
                {
                    status = "Held";
                  
                }
                else if (Convert.ToDateTime(eevent[icount].EventDate).Month >= DateTime.Now.Month )
                {
                    if (Convert.ToDateTime(eevent[icount].EventDate).Day > DateTime.Now.Day)
                    {
                        status = "Pending";
                    }
                    else
                    {
                        status = "Held";
                    }
                    
                }
                
                if (eevent[icount].EventPod.Count > 0)
                {
                    for (int podcount = 0; podcount < eevent[icount].EventPod.Count; podcount++)
                    {
                        pod = pod + eevent[icount].EventPod[podcount].Pod.Name;

                        if ((podcount + 1)< eevent[icount].EventPod.Count)
                        {
                            pod = pod + ",";
                        }

                    }
                }
                else
                {
                    pod = "N/A";
                }
                if (eevent[icount].Active.ToString().Equals("True"))
                {
                    dtEvent.Rows.Add(new object[] { eevent[icount].EventID, Convert.ToDateTime(eevent[icount].EventDate) , eevent[icount].Name, status, eevent[icount].CustomerCount, pod });
                }
                else
                    dtEvent.Rows.Add(new object[] { eevent[icount].EventID, Convert.ToDateTime(eevent[icount].EventDate), eevent[icount].Name, status, eevent[icount].CustomerCount, pod });
            }
        }
        if ((SortDirection)ViewState["SortEvent"] == SortDirection.Descending)
        {
            dtEvent.DefaultView.Sort = "eventname desc";
        }
        else
        {
            dtEvent.DefaultView.Sort = "eventname asc";
        }

        dtEvent = dtEvent.DefaultView.ToTable();
        ViewState["DSGRID"] = dtEvent;
        gridquickreports.DataSource = dtEvent;
        gridquickreports.DataBind(); 
    }

    protected void gridquickreports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridquickreports.PageIndex = e.NewPageIndex;
        gridquickreports.DataSource = (DataTable)ViewState["DSGRID"];
        gridquickreports.DataBind();
    }
    protected void gridquickreports_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtEvent = (DataTable)ViewState["DSGRID"];
        if (e.SortExpression.ToString() == "eventname desc")
        {
            if ((SortDirection)ViewState["SortEvent"] == SortDirection.Descending)
            {
                dtEvent.DefaultView.Sort = "eventname asc";
                ViewState["SortEvent"] = SortDirection.Ascending;
            }
            else
            {
                dtEvent.DefaultView.Sort = "eventname desc";
                ViewState["SortEvent"] = SortDirection.Descending;
            }
        }
        else if (e.SortExpression == "Date desc")
        {
            if ((SortDirection)ViewState["SortEvent"] == SortDirection.Descending)
            {
                dtEvent.DefaultView.Sort = "Date asc";
                ViewState["SortEvent"] = SortDirection.Ascending;
            }
            else
            {
                dtEvent.DefaultView.Sort = "Date desc";
                ViewState["SortEvent"] = SortDirection.Descending;
            }
        }
        dtEvent = dtEvent.DefaultView.ToTable();

        gridquickreports.DataSource = dtEvent;
        ViewState["DSGRID"] = dtEvent;

        gridquickreports.DataBind();
    }
    
}
