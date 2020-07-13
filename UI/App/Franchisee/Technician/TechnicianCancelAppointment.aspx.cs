using System;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class TechnicianCancelAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var franchiseeTechnicianMasterPage = (Franchisee_Technician_TechnicianMaster)Master;
            franchiseeTechnicianMasterPage.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/TechnicianCustomerList.aspx\">Customer List</a>";
        }
    }
}