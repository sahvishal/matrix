using System;

public partial class App_Franchisee_SalesRep_SalesRepHostDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Host Details";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Host Details");
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href='#'>Manage Host</a>";
    }
}
