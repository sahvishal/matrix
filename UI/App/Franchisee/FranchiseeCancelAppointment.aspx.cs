using System;

public partial class App_Franchisee_FranchiseeCancelAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Cancel Customer Appointment";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Cancel Customer Appointment");
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/FranchiseeCustomerList.aspx\" >Customer List</a>";
    }
}
