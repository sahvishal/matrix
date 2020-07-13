using System;
using Falcon.DataAccess.Other;

public partial class App_Franchisor_FranchisorEditCustomer : System.Web.UI.Page
{
    # region "Events"
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
                OtherDAL otherDal = new OtherDAL();
                UCEditCustomer1.UserID = Convert.ToInt32(otherDal.GetUid(Convert.ToInt32(Request.QueryString["CustomerID"])));
            }
        }
    }
    # endregion

    
}
