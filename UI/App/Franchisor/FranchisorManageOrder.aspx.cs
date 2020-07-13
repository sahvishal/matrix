using System;

public partial class App_Franchisor_FranchisorManageOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Manage Orders";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Manage Orders");
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/Dashboard.aspx\">DashBoard</a>";
    }
}
