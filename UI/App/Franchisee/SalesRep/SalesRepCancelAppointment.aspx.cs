using System;

public partial class App_Franchisee_SalesRep_SalesRepCancelAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Cancel Customer Appointment";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Cancel Customer Appointment");
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/SalesRep/SalesRepEventCustomerList.aspx\" >Customer List</a>";
    }
}
