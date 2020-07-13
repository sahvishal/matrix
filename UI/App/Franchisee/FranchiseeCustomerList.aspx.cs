using System;

public partial class App_Franchisee_FranchiseeCustomerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Customer List";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Customer List");
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/Dashboard.aspx\">DashBoard</a>";
        if (!IsPostBack)
        {
            
        }
       

    }

    
}
