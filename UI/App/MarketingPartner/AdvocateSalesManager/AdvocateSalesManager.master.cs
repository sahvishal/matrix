using System;
using System.Collections.Generic;
using System.Data;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.User;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
using Falcon.App.Core.Application.Impl;
//using HealthYes.Web.UI.UserService;
public partial class App_MarketingPartner_AdvocateSalesManager : System.Web.UI.MasterPage
{
    /// <summary>
    /// Property to set breadcrumb's root name and link
    /// value should be like 
    /// <a href="/App/Franchisor/ViewProspects.aspx">Prospect</a>
    /// </summary>
    /// 
    public void setpoductitle(string title, string uctitle)
    {
        spchildname.InnerHtml = title;
        Ucsearchbox1.setuctitle(uctitle);
    }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Ucleftpanel1.Redirect = false;
        //After postback menu could rebind itself
        Ucmenucontrol2.RoleName = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias;
        if (IsPostBack != true)
        {
            //lblYear.Text = "2007 - " + DateTime.Today.Year.ToString();

            spcurdate.InnerText = DateTime.Now.ToString("dddd, dd MMMM, yyyy");

            var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            
            if (orgUser.CheckRole((long) Roles.SalesRep))
            {
                Ucwelcomebox2.SetLinks(Roles.SalesRep);
            }
            else if (orgUser.CheckRole((long)Roles.AdvocateSalesManager))
            {
                Ucwelcomebox2.SetLinks(Roles.AdvocateSalesManager);
            }
            else if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
            {
                Ucwelcomebox2.SetLinks(Roles.FranchisorAdmin);
            }

            SetLeftPanel(((Roles)orgUser.RoleId).ToString());
            SetRecentVisited(((Roles)orgUser.RoleId).ToString());
        }
    }
    public void settitle(string title)
    {
        spchildname.InnerHtml = title;
        Ucsearchbox1.setuctitle(title);
    }
    private void SetLeftPanel(string role)
    {
        string currenturl = Request.Url.ToString();
        int startpoint = currenturl.IndexOf("App");
        if (startpoint == 0)
            startpoint = currenturl.IndexOf("app");
        int endpoint = currenturl.IndexOf("aspx");
        int length = (currenturl.Length - 1) - (startpoint + 3);

        string url = currenturl.Substring(startpoint + 4, length);

        //UserService service = new UserService();
        // remove user service
        List<EModule> objModule = null; //userdal.GetLeftPanelLinks(url, role);

        //EModule[] objModule = service.GetLeftPanelLinks(url, role);

        string links = string.Empty;

        DataTable dtLinks = new DataTable();
        dtLinks.Columns.Add("Name");
        dtLinks.Columns.Add("TargetURL");

        if (objModule != null && objModule.Count > 0)
        {
            for (int icount = 0; icount < objModule.Count; icount++)
            {
                dtLinks.Rows.Add(objModule[icount].Name, this.ResolveUrl(objModule[icount].TargetURL));
                //links = links + "<a href=" + objModule[icount].TargetURL + ">" + objModule[icount].Name + "</a><br>";
            }
        }
        else
        {
            dtLinks.Rows.Add("Home", currenturl);
        } 
        //dtLinks.Rows.Add("Home", "Dashboard.aspx");
        //dtLinks.Rows.Add("Create New Campaign", "CreateNewCampaign.aspx");
        //dtLinks.Rows.Add("Manage Campaign", "ViewCampaigns.aspx");
        //dtLinks.Rows.Add("Create New Advocate", "AddNewAffiliate.aspx");
        //dtLinks.Rows.Add("Manage Advocate", "ViewAffiliate.aspx");
        //dtLinks.Rows.Add("Create Marketing Material", "MarketingMaterial.aspx");
        //dtLinks.Rows.Add("Manage Marketing Material", "ViewMarketingMaterial.aspx");

        Ucleftpanel1.SetLinks(dtLinks);
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
            //string [,] recent=new string[5][5];
            DataTable dtRecent = (DataTable)Session["RecentVisited"];
            dtRecent.DefaultView.RowFilter = "TargetURL ='" + currenturl + "'";
            if (dtRecent.DefaultView.Count > 0)
            {
                dtRecent.DefaultView.RowFilter = "";
                DataTable dt = dtRecent; //(DataTable)Session["RecentVisited"];
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

}

