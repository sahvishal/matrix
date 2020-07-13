using System;

public partial class CallCenterManager_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CallCenter_CallCenterMaster obj;
        obj = (CallCenter_CallCenterMaster)this.Master;
        obj.settitle("Dashboard");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";

        Session["CCName"] = null;
        Session["CCNo"] = null;
        Session["CCType"] = null;
        Session["CCExpire"] = null;
        Session["CCSecurityCode"] = null;
        Session["SearchCustomerID"] = null;
        Session["SourceCode"] = null;
        Session["ProspectCustomerId"] = null;
        Session["CustomerId"] = null;
        Session["CallId"] = null;
        Session["EventId"] = null;
                
    }

}
