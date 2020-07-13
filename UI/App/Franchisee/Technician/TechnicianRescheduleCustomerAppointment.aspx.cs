using System;

public partial class App_Franchisee_Technician_TechnicianRescheduleCustomerAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Reschedule Customer Appointment";
        Franchisee_Technician_TechnicianMaster objmaster = (Franchisee_Technician_TechnicianMaster)this.Master;
        objmaster.SetBreadcrumb = "Customer List";
    }
}
