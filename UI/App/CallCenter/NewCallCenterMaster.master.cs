using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Enum;

public partial class CallCenter_CallCenterMaster1 : System.Web.UI.MasterPage
{
    public string CustomerNameReferral
    {
        get { return Ucleftpanel1.CustomerName; }
    }
    public string CustomerId
    {
        get
        {
            return Ucleftpanel1.CustomerId_Old;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var sessionContext = IoC.Resolve<ISessionContext>();
        
        dvcurrentTime.InnerHtml = DateTime.Now.ToString();
        if (IsPostBack != true)
        {
            //Save CCMonitor Details
            spcurdate.InnerText = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
            Ucmenucontrol2.RoleName = sessionContext.UserSession.CurrentOrganizationRole.RoleAlias;

            var currentRole = (Roles)sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId;
            switch (currentRole)
            {
                case Roles.CallCenterRep:
                    Ucwelcomebox2.SetLinks(Roles.CallCenterRep);
                    break;
                case Roles.CallCenterManager:
                    Ucwelcomebox2.SetLinks(Roles.CallCenterManager);
                    break;
                default:
                    break;
            }
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                divNewucCallCenterLeftPanel.Style.Add(HtmlTextWriterStyle.Display, "block");
                divNewucCallCenterLeftPanel.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

                divucCallCenterLeftPanel.Style.Add(HtmlTextWriterStyle.Display, "none");
                divucCallCenterLeftPanel.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
        }
    }

    public void SetTitle(string title)
    {
        spchildname.InnerHtml = title;
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

    public void HideBreadCrum()
    {
        BreadCrumContainer.Style[HtmlTextWriterStyle.Display] = "none";
    }

    public void hideucsearch()
    {

    }

    protected void ddlUserShellRole_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}
