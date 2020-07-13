using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MarketingPartner;
using Falcon.App.Lib;

public partial class App_MarketingPartner_AdvocateFAQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "Frequently Asked Question";
        Customer_CustomerMaster objMaster = (Customer_CustomerMaster)Master;
        objMaster.SetPageView("AdvocateDashBoard");

        if (IsPostBack) return;
        if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
        {
            spLastLogin.InnerHtml = "Your last login time: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
        }
        else
        {
            divLastLogin.Visible = false;
        }
        
        var marketingPartnerDal = new MarketingPartnerDAL();
        uc1.AdvocateView = !marketingPartnerDal.CheckExpressAdvocate((int)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId); ;
    }


}