using System;
using Falcon.App.UI.Extentions;

public partial class App_Franchisee_SalesRep_SalesRepCustomerDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Customer Details";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Customer Details");
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/SalesRep/Dashboard.aspx\">DashBoard</a>";

        if (Request.QueryString["CustomerID"] == null)
        {
            ClientScript.RegisterStartupScript(typeof(string), "JsCode", "alert('Not eligible to view this page');", true);
            Response.RedirectUser(this.ResolveUrl("/App/Franchisee/SalesRep/Dashboard.aspx/"));
        }
    }
}
