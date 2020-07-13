using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
//using HealthYes.Web.UI.ContactCallService;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

public partial class App_Franchisor_ViewMeetings : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
      

        this.Page.Title = "View Meeting";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("View Meeting");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();
        obj.setpoductitle("View Meeting","Contact");


        if (!IsPostBack)
        {
            ViewState["SortExpr"] = "Subject";
            ViewState["SortDir"] = SortDirection.Ascending;

            if (Request["ProspectId"] != null && Request["ProspectId"] != "")
            {
                ViewState["ProspectId"] = Request["ProspectId"].ToString();
            }

            if (Request.QueryString["searchtext"] != null)
            {
                SearchContact(Request.QueryString["searchtext"].ToString());
            }
            else if (Request.QueryString["Action"] != null)
            {
                if (Request.QueryString["Action"].ToString().Equals("Updated"))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Meeting updated Successfully');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Meeting added Successfully');", true);
                }

                loadmeetinggrid();
            }
            else
            {
                loadmeetinggrid();
            }

        }
    }

    protected void dgmeetings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgmeetings.PageIndex =e.NewPageIndex;
        dgmeetings.DataSource = (DataTable)ViewState["DSGRID"];
        dgmeetings.DataBind();
    }
    
    protected void dgmeetings_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tbltemp = (DataTable)ViewState["DSGRID"];
        if (e.SortExpression != ViewState["SortExpr"].ToString() || (SortDirection)ViewState["SortDir"] == SortDirection.Descending)
        {
            tbltemp.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            tbltemp.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }

        ViewState["SortExpr"] = e.SortExpression;
        tbltemp = tbltemp.DefaultView.ToTable();
        ViewState["DSGRID"] = tbltemp;
        dgmeetings.DataSource = tbltemp;
        dgmeetings.DataBind();

    }
    
    protected void btnAddMeeting_Click(object sender, EventArgs e)
    {
        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/AddMeeting.aspx"));
    }
    
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchContact(txtSearchMeeting.Text);
    }

    protected void ibtnback_Click(object sender, ImageClickEventArgs e)
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        string strType = string.Empty;

        string strPage = Request.Url.AbsoluteUri;
        strPage = strPage.Substring(strPage.LastIndexOf("/") + 1);
        if (strPage.Equals("ViewMeetings.aspx"))
            return;

        if (Request["Type"] != null && Request["Type"] != "")
        {
            strType = Request["Type"];
        }
        if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            if (!string.IsNullOrEmpty(strType) && strType.Equals("Prospect"))
                Response.RedirectUser("/App/Franchisor/ManageProspect.aspx");
            else if (!string.IsNullOrEmpty(strType) && strType.Equals("Host"))
                Response.RedirectUser("/App/Franchisor/ManageHost.aspx");
        }
        else if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
        {
            strPage = strPage.Substring(0, strPage.IndexOf('?'));
            if (strPage == "SalesRepHostDetails.aspx")
            {
                Response.RedirectUser("/App/Franchisee/SalesRep/SalesRepManageHost.aspx");
            }
            else if (!string.IsNullOrEmpty(strType) && strType.Equals("Host"))
            {
                Response.RedirectUser("/App/Franchisee/SalesRep/SalesRepManageHost.aspx");
            }
            else
            {
                Response.RedirectUser("/App/Franchisee/SalesRep/SalesRepManageProspects.aspx");
            }
        }

    }

    #endregion

    #region Method

    private void loadmeetinggrid()
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        Int64 iProspectid = 0;

        List<EContactMeeting> Meeting = null;
        MasterDAL masterDal = new MasterDAL();
        if (ViewState["ProspectId"] != null && (string) ViewState["ProspectId"] != "")
        {
            iProspectid = Convert.ToInt64(ViewState["ProspectId"].ToString());

            // Mode '4' is used here for Fetching All Prospect Meetings
            Meeting = masterDal.GetMeetings(string.Empty, 4, Convert.ToInt32(currentSession.UserId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId), iProspectid);


            if (Request["Type"] != null && Request["Type"] != "")
            {
                if (Meeting.Count > 0)
                {
                    if (Request["Type"].Equals("Prospect"))
                    {
                        sptitle.InnerText = "Meetings for prospect:" + Meeting[0].ProspectName;
                    }
                    else
                    {
                        sptitle.InnerText = "Meetings for host:" + Meeting[0].ProspectName;
                    }
                }
            }
        }
        else
        {
            // Mode '0' is used here to fetch All Active Meetings
            Meeting = masterDal.GetMeetings(string.Empty, 3, Convert.ToInt32(currentSession.UserId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId), 0);

        }

        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("ContactMeetingID");
        tbltemp.Columns.Add("ContactName");
        tbltemp.Columns.Add("Subject");
        tbltemp.Columns.Add("Duration");
        tbltemp.Columns.Add("StartDate");
        tbltemp.Columns.Add("StartTime");
        tbltemp.Columns.Add("Status");
        tbltemp.Columns.Add("Venue");
        tbltemp.Columns.Add("ProspectName");
        

        if (Meeting != null && Meeting.Count > 0)
        {
            for (int i = 0; i < Meeting.Count; i++)
            {

                int time = Convert.ToInt32(Meeting[i].Duration);
                int hour = time / 60;
                int minute = time % 60;
                string startTime = "";
                string startDate = "";
                if (Meeting[i].StartDate != null && Meeting[i].StartDate != "")
                    startDate = Convert.ToDateTime(Meeting[i].StartDate).ToString("MM/dd/yyyy");
                if (Meeting[i].StartTime != null && Meeting[i].StartTime != "")
                    startTime = Convert.ToDateTime(Meeting[i].StartTime).ToString("hh:mm tt");
                tbltemp.Rows.Add(Meeting[i].ContactMeetingID, 
                                    Meeting[i].Contact.FirstName + " " + Meeting[i].Contact.LastName, 
                                    Meeting[i].Subject, 
                                    hour + "h" + " " + minute + "m", 
                                    startDate,
                                    startTime,
                                    Meeting[i].CallStatus.Status,
                                    Meeting[i].Venue,Meeting[i].ProspectName);

            }
            //divErrorMsg.Visible = false;
            Span2.InnerText = Meeting.Count.ToString() + " Results Found";
            divGrd.Style.Add(HtmlTextWriterStyle.Display, "block");
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
            {
                tbltemp.DefaultView.Sort = ViewState["SortExpr"].ToString() + " desc";
            }
            else
            {
                tbltemp.DefaultView.Sort = ViewState["SortExpr"].ToString() + " asc";
            }

            tbltemp = tbltemp.DefaultView.ToTable();
            ViewState["DSGRID"] = tbltemp;
            dgmeetings.DataSource = tbltemp;
            dgmeetings.DataBind();
        }
        else
        {
            Span2.InnerText = Meeting.Count.ToString() + " Results Found";
            divGrd.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

    }

    private void SearchContact(string SearchString)
    {

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        Int64 iProspectid = 0;

        EContactMeeting[] Meeting = null;
        MasterDAL masterDal = new MasterDAL();

        if (ViewState["ProspectId"] != null && (string) ViewState["ProspectId"] != "")
        {
            iProspectid = Convert.ToInt64(ViewState["ProspectId"].ToString());

            var listContactMeeting = masterDal.GetMeetings(SearchString, 4, Convert.ToInt32(currentSession.UserId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId), iProspectid);

            if (listContactMeeting != null) Meeting = listContactMeeting.ToArray();

            //Meeting = service.GetProspectMeetings(Convert.ToInt32(usershellmodulerole.UserID), true, Convert.ToInt32(usershellmodulerole.ShellID), true, Convert.ToInt32(usershellmodulerole.RoleID), true,SearchString, iProspectid, true);

            if (Meeting.Length > 0)
                sptitle.InnerText = "Meetings for prospect:" + Meeting[0].ProspectName;
        }
        else
        {
            var listContactMeeting = masterDal.GetMeetings(SearchString, 2, Convert.ToInt32(currentSession.UserId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId),
                                                           Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId), 0);

            if (listContactMeeting != null) Meeting = listContactMeeting.ToArray();

            //Meeting = service.GetMeetingBycontact(SearchString, Convert.ToInt32(usershellmodulerole.UserID), true, Convert.ToInt32(usershellmodulerole.ShellID), true, Convert.ToInt32(usershellmodulerole.RoleID), true);
        }


        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("ContactMeetingID");
        tbltemp.Columns.Add("ContactName");
        tbltemp.Columns.Add("Subject");
        tbltemp.Columns.Add("Duration");
        tbltemp.Columns.Add("StartDate");
        tbltemp.Columns.Add("StartTime");
        tbltemp.Columns.Add("Status");
        tbltemp.Columns.Add("Venue");
        tbltemp.Columns.Add("ProspectName");

        if (Meeting != null && Meeting.Length > 0)
        {

            for (int i = 0; i < Meeting.Length; i++)
            {

                int time = Convert.ToInt32(Meeting[i].Duration);
                int hour = time / 60;
                int minute = time % 60;
                string startTime = "";
                string startDate = "";
                if (!string.IsNullOrEmpty(Meeting[i].StartDate))
                    startDate = Convert.ToDateTime(Meeting[i].StartDate).ToString("MM/dd/yyyy");
                if (!string.IsNullOrEmpty(Meeting[i].StartTime))
                    startTime = Convert.ToDateTime(Meeting[i].StartTime).ToString("hh:mm tt");
                tbltemp.Rows.Add(Meeting[i].ContactMeetingID,
                                    Meeting[i].Contact.FirstName + " " + Meeting[i].Contact.LastName,
                                    Meeting[i].Subject,
                                    hour + "h" + " " + minute + "m",
                                    startDate,
                                    startTime,
                                    Meeting[i].CallStatus.Status,
                                    Meeting[i].Venue,Meeting[i].ProspectName.ToString());
            }
            //divErrorMsg.Visible=false;
            Span2.InnerText = Meeting.Length.ToString() + " Results Found";
            divGrd.Style.Add(HtmlTextWriterStyle.Display, "block");
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
            {
                tbltemp.DefaultView.Sort = ViewState["SortExpr"].ToString() + " desc";
            }
            else
            {
                tbltemp.DefaultView.Sort = ViewState["SortExpr"].ToString() + " asc";
            }
            tbltemp = tbltemp.DefaultView.ToTable();
            ViewState["DSGRID"] = tbltemp;
            dgmeetings.DataSource = tbltemp;
            dgmeetings.DataBind();
        }
        else
        {
            if (Meeting!=null)
                Span2.InnerText = Meeting.Length.ToString() + " Results Found";
            divGrd.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

    }

    #endregion
}
