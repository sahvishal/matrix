using System;

public partial class App_Franchisee_SalesRep_SalesRepProspectDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Type"] != null && Request["Type"] != "")
        {
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            if (Request["Type"] == "Prospect")
            {
                Page.Title = "Prospect Details";
                obj.settitle("Prospect Details");
                obj.hideucsearch();
                obj.SetBreadCrumbRoot = "<a href='/App/Franchisee/SalesRep/SalesRepManageProspects.aspx'>Manage Prospect</a>";
                
            }
            else
            {
                Page.Title = "Host Details";
                obj.settitle("Host Details");
                obj.hideucsearch();
                obj.SetBreadCrumbRoot = "<a href='/App/Franchisee/SalesRep/SalesRepManageHost.aspx'>Manage Host</a>";
            }
        }
    }
}
