using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using HealthYes.Web.UI.ContactCallService;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;

public partial class App_Franchisor_ViewCall : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        this.Page.Title = "View Call";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("View Call");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();

        obj.setpoductitle("View Call", "Contact");


        if (!IsPostBack)
        {
            ViewState["SortExpr"] = "Subject";
            ViewState["SortDir"] = SortDirection.Ascending;

            if (Request["ProspectId"]!=null && Request["ProspectId"]!="")
            {
                ViewState["ProspectId"] = Request["ProspectId"].ToString();
            }

            if (Request.QueryString["searchtext"] != null)
            {
                SearchCall(Request.QueryString["searchtext"].ToString());
            }
            else if (Request.QueryString["Action"] != null)
            {
                if (Request.QueryString["Action"].ToString().Equals("Updated"))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('call updated Successfully');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Call added Successfully');", true);
                }
                loadcallgrid();

            }
            else
            {
                loadcallgrid();
            }


            

        }



    }

    protected void dgcalls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgcalls.PageIndex =e.NewPageIndex;
        dgcalls.DataSource = (DataTable)ViewState["DSGRID"];
        dgcalls.DataBind();
    }
    protected void dgcalls_Sorting(object sender, GridViewSortEventArgs e)
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
        dgcalls.DataSource = tbltemp;
        dgcalls.DataBind();
    }
    protected void btnAddCall_Click(object sender, EventArgs e)
    {
        Response.RedirectUser(ResolveUrl("~/App/Franchisor/AddCall.aspx")); 
    }
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchCall(txtSearchCall.Text);
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton tempButton = (ImageButton)sender;
        int ContactCallID = Convert.ToInt32(tempButton.CommandArgument);
        
        MasterDAL objMasterDal = new MasterDAL();
        objMasterDal.ChangeCallStatus(ContactCallID, 0);
        loadcallgrid();
    }

    private void loadcallgrid()
    {
        Int64 iProspectid=0;

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        MasterDAL objMasterDal = new MasterDAL();
        Falcon.Entity.Other.EContactCall[] Call = null;
        if (ViewState["ProspectId"] != null && (string) ViewState["ProspectId"]!="")
        {
            iProspectid = Convert.ToInt64(ViewState["ProspectId"].ToString());
            var listCall = objMasterDal.GetCalls(string.Empty, 4, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, iProspectid);
            if (listCall != null)
                Call = listCall.ToArray();
            if (Request["Type"] != null && Request["Type"] != "")
            {
                if (Call.Length > 0)
                {
                    if (Request["Type"].Equals("Prospect"))
                    {
                        sptitle.InnerHtml = "Calls for prospect:" + HttpUtility.HtmlEncode(Call[0].ProspectName);
                    }
                    else
                    {
                        sptitle.InnerHtml = "Calls for host:" + HttpUtility.HtmlEncode(Call[0].ProspectName);
                    }
                }
            }
            
        }
        else
        {
            //Call = service.GetAllActiveCalls(Convert.ToInt32(usershellmodulerole.UserID), true, Convert.ToInt32(usershellmodulerole.ShellID), true, Convert.ToInt32(usershellmodulerole.RoleID), true);
            var listCall = objMasterDal.GetCalls(string.Empty, 3, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, 0);
            if (listCall != null)
                Call = listCall.ToArray();
        }


        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("ContactCallID");
        tbltemp.Columns.Add("ContactName");
        tbltemp.Columns.Add("Subject");
        tbltemp.Columns.Add("Duration");
        tbltemp.Columns.Add("StartDate");
        tbltemp.Columns.Add("Accept");
        tbltemp.Columns.Add("AssignedTo");
        tbltemp.Columns.Add("Notes");


        if (Call != null && Call.Length > 0)
        {
            for (int i = 0; i < Call.Length; i++)
            {


                int time = Convert.ToInt32(Call[i].Duration);
                int hour = time / 60;
                int minute = time % 60;
                string startdate = "";
                if (Call[i].StartDate != null && Call[i].StartDate != "")
                    startdate = Convert.ToDateTime(Call[i].StartDate).ToString("MM/dd/yyyy");
                string strNotesToolTip = "";
                strNotesToolTip = "<table cellpadding='3' cellspacing='0' border='0' width='100%'>";
                //Date
                if ((Call[i].StartDate != null) && (Call[i].StartDate != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Date:</b> " + Convert.ToDateTime(Call[i].StartDate).ToString("MM/dd/yyyy") + "</td></tr>";

                }
                //Time
                if ((Call[i].StartTime != null) && (Call[i].StartTime != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Time:</b> " + Convert.ToDateTime(Call[i].StartTime).ToString("hh:mm tt") + "</td></tr>";

                }
                
                // Duration
                if (Call[i].Duration.ToString() != "")
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td ><b>Duration:</b> " + Call[i].Duration + " mins.</td></tr>";

                }
                //// Status
                if ((Call[i].CallStatus.Status != null) && (Call[i].CallStatus.Status != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Status:</b> " + Call[i].CallStatus.Status + "</td></tr>";

                }
                // Notes
                if ((Call[i].Notes != null) && (Call[i].Notes != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Notes:</b>" + Call[i].Notes + "</td></tr>";

                }
                strNotesToolTip = strNotesToolTip + "</table>";

                tbltemp.Rows.Add(Call[i].ContactCallID, Call[i].Contact.FirstName + " " + Call[i].Contact.LastName, Call[i].Subject, hour + "h" + " " + minute + "m", startdate, "accept?", Call[i].UserShellModule.UserName, strNotesToolTip);

            }
            divErrorMsg.Visible = false;
            Span2.InnerHtml = Call.Length.ToString() + " Results Found";
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
            dgcalls.DataSource = tbltemp;
            dgcalls.DataBind();
        }
        else
        {
            //divErrorMsg.Visible = true;//.Style["display"] = "block";
            //divErrorMsg.InnerHtml = "No Records Found ";
            Span2.InnerHtml = Call.Length.ToString() + " Results Found";
            divGrd.Style.Add(HtmlTextWriterStyle.Display, "none");
        }



    }


    private void SearchCall(string searchstring)
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        MasterDAL objMasterDal = new MasterDAL();
        Falcon.Entity.Other.EContactCall[] Call = null;
        Int64 iProspectid = 0;

        string strPropsectId=string.Empty;
        if (ViewState["ProspectId"] != null)
            strPropsectId = ViewState["ProspectId"].ToString();

        if (strPropsectId!="")
        {
            iProspectid = Convert.ToInt64(ViewState["ProspectId"].ToString());
            var listCall = objMasterDal.GetCalls(searchstring, 4, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, iProspectid);
            if (listCall != null)
                Call = listCall.ToArray();
        }
        else
        {
            var listCall = objMasterDal.GetCalls(searchstring, 2, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, 0);
            if (listCall != null)
                Call = listCall.ToArray();
        }


        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("ContactCallID");
        tbltemp.Columns.Add("ContactName");
        tbltemp.Columns.Add("Subject");
        tbltemp.Columns.Add("Duration");
        tbltemp.Columns.Add("StartDate");
        tbltemp.Columns.Add("Accept");
        tbltemp.Columns.Add("AssignedTo");
        tbltemp.Columns.Add("Notes");

        if (Call != null && Call.Length > 0)
        {

            for (int i = 0; i < Call.Length; i++)
            {


                int time = Convert.ToInt32(Call[i].Duration);
                int hour = time / 60;
                int minute = time % 60;
                string startdate = "";
                if (Call[i].StartDate != null && Call[i].StartDate != "")
                    startdate = Convert.ToDateTime(Call[i].StartDate).ToString("MM/dd/yyyy");
                string strNotesToolTip = "";
                strNotesToolTip = "<table cellpadding='3' cellspacing='0' border='0' width='100%'>";
                //Date
                if ((Call[i].StartDate != null) && (Call[i].StartDate != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Date:</b> " + Convert.ToDateTime(Call[i].StartDate).ToString("MM/dd/yyyy") + "</td></tr>";

                }
                //Time
                if ((Call[i].StartTime != null) && (Call[i].StartTime != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Time:</b> " + Convert.ToDateTime(Call[i].StartTime).ToString("hh:mm tt") + "</td></tr>";

                }
                // Duration
                if (Call[i].Duration.ToString() != "")
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td ><b>Duration:</b> " + Call[i].Duration + " mins.</td></tr>";

                }
                //// Status
                if ((Call[i].CallStatus.Status != null) && (Call[i].CallStatus.Status != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Status:</b> " + Call[i].CallStatus.Status + "</td></tr>";

                }
                // Notes
                if ((Call[i].Notes != null) && (Call[i].Notes != ""))
                {
                    strNotesToolTip = strNotesToolTip + "<tr><td><b>Notes:</b>" + Call[i].Notes + "</td></tr>";

                }
                strNotesToolTip = strNotesToolTip + "</table>";

                tbltemp.Rows.Add(Call[i].ContactCallID, Call[i].Contact.FirstName + " " + Call[i].Contact.LastName, Call[i].Subject, hour + "h" + " " + minute + "m", startdate, "accept?", Call[i].UserShellModule.UserName, strNotesToolTip);

            }
            divErrorMsg.Visible = false;

            Span2.InnerHtml = Call.Length.ToString() + " Results Found";
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
            dgcalls.DataSource = tbltemp;
            dgcalls.DataBind();
        }
        else
        {
            //divErrorMsg.Visible = true;
            //divErrorMsg.InnerHtml = "No Records Found ";
            Span2.InnerHtml = Call.Length.ToString() + " Results Found";
            divGrd.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        

    }

    protected void ibtnback_Click(object sender, ImageClickEventArgs e)
    {
    
        string strType = string.Empty;
        if (Request["Type"] != null && Request["Type"] != "")
        {
            strType = Request["Type"];
        }

        var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
        {
            if (!string.IsNullOrEmpty(strType) && strType.Equals("Prospect"))
            Response.RedirectUser("/App/Franchisor/ManageProspect.aspx");
            else if (!string.IsNullOrEmpty(strType) && strType.Equals("Host"))
                Response.RedirectUser("/App/Franchisor/ManageHost.aspx");
        }
        else if (orgUser.CheckRole((long)Roles.SalesRep))
        {
            string strPage = Request.Url.AbsoluteUri;
            strPage = strPage.Substring(strPage.LastIndexOf("/") + 1);
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
}
