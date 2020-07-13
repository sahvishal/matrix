using System;

public partial class App_Common_ApplyCoupon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Apply Source code";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Apply Source code");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Apply Coupon</a>";
        obj.hideucsearch();
    }
}
