using System;
using Falcon.DataAccess.Other;

public partial class App_Franchisee_Technician_TechnicianEditCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Edit Customer";
        Franchisee_Technician_TechnicianMaster objMaster = (Franchisee_Technician_TechnicianMaster)this.Master;
        objMaster.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/HomePage.aspx\">DashBoard></a>";
        objMaster.settitle("Customer Profile");
        if (!IsPostBack)
        {
            if (Request.QueryString["UserID"] != null)
            {
                UCEditCustomer1.UserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            }
            else if (Request.QueryString["CustomerID"] != null)
            {
                OtherDAL otherDal = new OtherDAL();
                UCEditCustomer1.UserID = Convert.ToInt32(otherDal.GetUid(Convert.ToInt32(Request.QueryString["CustomerID"])));
            }
        }
    }
}
