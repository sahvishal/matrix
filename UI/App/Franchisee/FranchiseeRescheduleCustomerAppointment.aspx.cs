using System;

public partial class App_Franchisee_FranchiseeRescheduleCustomerAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Reschedule Customer Appointment";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Reschedule Customer Appointment");
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/FranchiseeCustomerList.aspx\" >Customer List</a>";
    }
}
