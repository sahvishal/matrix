using System;

public partial class App_Franchisee_SalesRep_SalesRepManageHost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Manage Hosts";
        ((App_UCCommon_ucManageHost)UsCtrlManageHosts).FranchiseeView = false;
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.hideucsearch();
        obj.setpoductitle("Manage Hosts", "Host");
        obj.SetBreadCrumbRoot = "<a href='#'>Hosts</a>";
    }
}
