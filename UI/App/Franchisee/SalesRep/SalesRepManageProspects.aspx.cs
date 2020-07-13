using System;

public partial class App_Franchisee_SalesRep_SalesRepManageProspects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((App_UCCommon_UCManageProspects)UsCtrlManageProspects).FranchiseeView = false;
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.setpoductitle("Manage Prospects", "Prospects");
        obj.SetBreadCrumbRoot = "<a href='#'>Prospects</a>";
    }
}
