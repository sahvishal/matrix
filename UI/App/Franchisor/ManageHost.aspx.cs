using System;
public partial class App_Franchisor_ManageHost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Manage Hosts";
        ((App_UCCommon_ucManageHost)UsCtrlManageHosts).FranchiseeView = true;
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.hideucsearch();
        obj.setpoductitle("Manage Hosts", "Host");
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ManageHost.aspx\">Hosts</a>";
    }
}
