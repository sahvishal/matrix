using System;
using Falcon.DataAccess.Other;

public partial class App_Franchisee_SalesRep_SalesRepEditCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Edit Customer";
        Franchisor_FranchisorMaster objMaster = (Franchisor_FranchisorMaster)this.Master;
        objMaster.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/Dashboard.aspx\">DashBoard</a>";
        objMaster.settitle("Customer Profile");
        objMaster.hideucsearch();
        if (!IsPostBack)
        {
            if (Request.QueryString["UserID"] != null)
            {
                UCEditCustomer1.UserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            }
            else if (Request.QueryString["CustomerID"] != null)
            {
                var otherDal = new OtherDAL();

                Int64 returnresult = otherDal.GetUid(Convert.ToInt32(Request.QueryString["CustomerID"]));
                UCEditCustomer1.UserID = Convert.ToInt32(returnresult);
            }
        }
    }
}
