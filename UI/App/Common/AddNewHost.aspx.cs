using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;

public partial class App_Common_AddNewHost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        if (Request.QueryString["HostID"] != null && Request.QueryString["Action"] != null)
        {
            if (Request.QueryString["Action"].Equals("ConvertToHost"))
            {
                Page.Title = "Convert To Host";
                obj.settitle("Convert To Host");

                var role = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

                if (role.CheckRole((long)Roles.FranchisorAdmin))
                    obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ManageProspect.aspx\">Manage Prospect</a>";
                else if (role.CheckRole((long)Roles.SalesRep))
                    obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/SalesRep/SalesRepManageProspects.aspx\">Manage Prospect</a>";
            }
        }
        else if (Request.QueryString["HostID"] != null)
        {
            Page.Title = "Edit Host";
            obj.settitle("Edit Host");
            obj.SetBreadCrumbRoot = "<a href=\"#\">Manage Host</a>";
        }
        
        else
        {
            Page.Title = "Add New Host";
            obj.settitle("Add New Host");
            obj.SetBreadCrumbRoot = "<a href=\"#\">Manage Host</a>";
        }
        
        obj.hideucsearch();
        ucAddProspectHost1.SetViewType(true);
    }
}
