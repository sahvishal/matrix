using System;

public partial class App_Common_AddNewProspect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        if (Request.QueryString["ProspectID"] != null)
        {
            Page.Title = "Edit Prospect";
            obj.settitle("Edit Prospect");
            obj.SetBreadCrumbRoot = "<a href=\"#\">Manage Prospect</a>";
        }
        else
        {
            Page.Title = "Add New Prospect";
            obj.settitle("Add New Prospect");
            obj.SetBreadCrumbRoot = "<a href=\"#\">Manage Prospect</a>";
        }

        obj.hideucsearch();
        ucAddProspectHost1.SetViewType(false);
    }
}
