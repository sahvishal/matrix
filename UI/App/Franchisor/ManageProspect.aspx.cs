using System;
public partial class App_Franchisor_ManageProspect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((App_UCCommon_UCManageProspects)UsCtrlManageProspects).FranchiseeView = true;
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.setpoductitle("Manage Prospects", "Prospects");
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ManageProspect.aspx\">Prospects</a>";
        
    }
}
