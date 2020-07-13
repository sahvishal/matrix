using System;

public partial class App_Franchisee_Technician_MissingResultReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Missing Result Report";
        Franchisee_Technician_TechnicianMaster objmaster = (Franchisee_Technician_TechnicianMaster)this.Master;
        objmaster.SetBreadcrumb = "Missing Result Report";

    }
}
