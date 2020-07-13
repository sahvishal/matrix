using System;
using System.Data;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Enum;

public partial class Franchisee_Technician_TechnicianMaster : MasterPage
{

    public bool HideLeftContainer
    {
        set 
        {
            if (value == true)
                divleftcontainer.Visible = false;
            else
                divleftcontainer.Visible = true;
        }
    }

    public string SetBreadcrumb
    {
        get { return spnRoot.InnerHtml; }
        set { spnRoot.InnerHtml = value; }
    }

    public void settitle(string title)
    {
        spchildname.InnerHtml = title;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Ucmenucontrol1.RoleName = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias; 
        if (IsPostBack != true)
        {
            spcurdate.InnerText = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
            
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;


            if (currentOrgRole.CheckRole((long)Roles.Technician) && !this.Request.Url.ToString().Contains("EventCustomerList.aspx"))
            {
                divleftcontainer.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                divleftcontainer.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            Ucwelcomebox1.SetLinks(Roles.Technician);
            //SetRecentVisited(role.ToString());
        }
    }
    protected void ddlUserShellRole_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void SetRecentVisited(string role)
    {
        string currenturl = Request.Url.ToString();
        string pagename = this.Page.Title;

        DataTable dtVisit = new DataTable();
        dtVisit.Columns.Add("Name");
        dtVisit.Columns.Add("TargetURL");
        dtVisit.Columns.Add("Role");

        if (Session["RecentTechnician"] != null)
        {
            //string [,] recent=new string[5][5];
            DataTable dtRecent = (DataTable)Session["RecentTechnician"];
            dtRecent.DefaultView.RowFilter = "TargetURL ='" + currenturl.Replace("'", "''") + "'";
            if (dtRecent.DefaultView.Count > 0)
            {
                dtRecent.DefaultView.RowFilter = "";
                DataTable dt = dtRecent; //(DataTable)Session["RecentVisited"];
                //Uctechnicianleftpanel1.SetRecent(dt);
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
                    Session["RecentTechnician"] = dtVisit;
                }
                else
                {
                    dtVisit.Rows.Add(pagename, currenturl, role);
                    Session["RecentTechnician"] = dtVisit;
                }
            }
        }
        else
        {
            dtVisit.Rows.Add(pagename, currenturl, role);
            Session["RecentTechnician"] = dtVisit;
        }
        //Uctechnicianleftpanel1.SetRecent(dtVisit);
    }

}
