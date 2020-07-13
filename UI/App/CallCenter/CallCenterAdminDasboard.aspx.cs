using System;

public partial class App_CallCenter_CallCenterAdminDasboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Call Center Admin DashBoard";
        CallCenter_CallCenterMaster obj;

        obj = (CallCenter_CallCenterMaster)this.Master;
        obj.settitle("DashBoard");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Call Center Admin</a>";
    }
}
