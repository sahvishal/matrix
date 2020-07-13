using System;
using System.Data;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.Entity.Other;

public partial class Franchisor_FranchisorMaster : System.Web.UI.MasterPage
{

    public bool HideLeftContainer
    {
        set
        {
            if (value == true)
                divleftcontainer.Style["Display"] = "none";
            else
                divleftcontainer.Style["Display"] = "block";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var sessionContext = IoC.Resolve<ISessionContext>();
        
        string strCurrentPath = Request.CurrentExecutionFilePath;
        strCurrentPath = strCurrentPath.Substring(strCurrentPath.LastIndexOf("/") + 1);
        if ((strCurrentPath == "ManageProspect.aspx") || (strCurrentPath == "SalesRepManageProspects.aspx"))
        {
            Ucsearchbox1.Visible = false;
        }

        Ucmenucontrol2.RoleName = sessionContext.UserSession.CurrentOrganizationRole.RoleAlias;
        if (IsPostBack != true)
        {
            spcurdate.InnerText = DateTime.Now.ToString("dddd, dd MMMM, yyyy");

            var orgUser = sessionContext.UserSession.CurrentOrganizationRole;
            Ucwelcomebox2.SetLinks((Roles)orgUser.GetSystemRoleId);

            SetLeftPanel(orgUser);
            SetRecentVisited(((Roles)orgUser.GetSystemRoleId).ToString());
        }
    }

    public void settitle(string title)
    {
        spchildname.InnerHtml = title;
        Ucsearchbox1.setuctitle(title);
    }

    public void setpoductitle(string title, string uctitle)
    {
        spchildname.InnerHtml = title;
        Ucsearchbox1.setuctitle(uctitle);
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

    public void hideucsearch()
    {
        Ucsearchbox1.Visible = false;
    }

    private void SetLeftPanel(OrganizationRoleUserModel orgUser)
    {
        string currenturl = Request.Url.ToString();
        int startpoint = currenturl.IndexOf("App");
        if (startpoint == 0)
            startpoint = currenturl.IndexOf("app");
        int endpoint = currenturl.IndexOf("aspx");
        int length = endpoint - startpoint;
        
        string url = currenturl.Substring(startpoint + 4, length);


        //var listModule = null;// userdal.GetLeftPanelLinks(url, role.ToString());
        EModule[] objModule = null;

        //if (listModule != null) objModule = listModule.ToArray();

        string links = string.Empty;

        DataTable dtLinks = new DataTable();
        dtLinks.Columns.Add("Name");
        dtLinks.Columns.Add("TargetURL");

        if (objModule != null && objModule.Length > 0)
        {
            for (int icount = 0; icount < objModule.Length; icount++)
            {
                dtLinks.Rows.Add(objModule[icount].Name, this.ResolveUrl(objModule[icount].TargetURL));                
            }
        }
        else
        {
            if (orgUser.CheckRole((long) Roles.SalesRep))
            {
                currenturl = this.ResolveUrl("/App/Franchisee/SalesRep/Dashboard.aspx");
            }
            else if (orgUser.CheckRole((long)Roles.FranchiseeAdmin))
            {
                currenturl = this.ResolveUrl("/App/Franchisee/Dashboard.aspx");
            }
            else if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
            {
                currenturl = this.ResolveUrl("/App/Franchisor/Dashboard.aspx");
            }


            dtLinks.Rows.Add("Home", currenturl);
        }

        Ucleftpanel1.SetLinks(dtLinks);
        UcleftCalendar.SetLinks(dtLinks);
    }

    private void SetRecentVisited(string role)
    {
        string currenturl = Request.Url.ToString();
        string pagename = this.Page.Title;
        
        DataTable dtVisit = new DataTable();
        dtVisit.Columns.Add("Name");
        dtVisit.Columns.Add("TargetURL");
        dtVisit.Columns.Add("Role");

        if (Session["RecentVisited"] != null)
        {
            DataTable dtRecent = (DataTable)Session["RecentVisited"];
            dtRecent.DefaultView.RowFilter = "TargetURL ='" + currenturl.Replace("'", "''") + "'";
            if (dtRecent.DefaultView.Count > 0)
            {
                dtRecent.DefaultView.RowFilter = "";
                DataTable dt = dtRecent; 
                Ucleftpanel1.SetRecent(dt);
                return;
            }
            else
            {
                string[,] recent = new string[6, 3];
                int count = 0;
                count = dtRecent.Rows.Count > 4 ? 4 : dtRecent.Rows.Count;

                recent[0, 0] = pagename;
                recent[0, 1] = currenturl;
                recent[0, 2] = role;
                for (int i = 1; i <= count; i++)
                {
                    recent[i, 0] = dtRecent.Rows[i - 1]["Name"].ToString();
                    recent[i, 1] = dtRecent.Rows[i - 1]["TargetURL"].ToString();
                    recent[i, 2] = dtRecent.Rows[i - 1]["Role"].ToString();
                }

                int arraycount = recent.Length / 3;

                for (int j = 0; j < arraycount; j++)
                {
                    if (recent[j, 0] != null && recent[j, 0].Length > 0)
                    {
                        dtVisit.Rows.Add(recent[j, 0], recent[j, 1], recent[j, 2]);
                    }
                }

                dtVisit.DefaultView.RowFilter = "Role='" + role + "'";
                dtVisit = dtVisit.DefaultView.ToTable();
                if (dtVisit.Rows.Count > 0)
                {
                    Session["RecentVisited"] = dtVisit;
                }
                else
                {
                    dtVisit.Rows.Add(pagename, currenturl, role);
                    Session["RecentVisited"] = dtVisit;
                }
                Ucleftpanel1.SetRecent(dtVisit);
            }
        }
        else
        {
            dtVisit.Rows.Add(pagename, currenturl, role);
            Session["RecentVisited"] = dtVisit;
            Ucleftpanel1.SetRecent(dtVisit);
        }

    }

    protected void ddlUserShellRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    public void setCalendarUC()
    {
        Ucleftpanel1.Visible = false;
        UcleftCalendar.Visible = true;

    }

    #region Property

    public Boolean YearView
    {

        set
        {

            ((CheckBox)UcleftCalendar.FindControl("chkViewTask")).Visible = !value;
            ((CheckBox)UcleftCalendar.FindControl("chkViewCall")).Visible = !value;
            ((CheckBox)UcleftCalendar.FindControl("chkViewMeeting")).Visible = !value;
            ((CheckBox)UcleftCalendar.FindControl("chkViewEvent")).Visible = !value;
            ((CheckBox)UcleftCalendar.FindControl("chkViewSeminar")).Visible = !value;

        }
    }
    #endregion
}