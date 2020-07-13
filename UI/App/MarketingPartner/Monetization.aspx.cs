using System;
using System.Web.UI;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.MarketingPartner;
using Falcon.App.Lib;

public partial class App_MarketingPartner_Monetization : Page
{
    #region Events
    /// <summary>
    /// Page Load  Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "Monetize your Referrals";
        Customer_CustomerMaster objMaster = (Customer_CustomerMaster)Master;
        objMaster.SetPageView("AdvocateDashBoard");

    }
    /// <summary>
    /// Save button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {

        long intCustomerId = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

        var marketingPartnerDal = new MarketingPartnerDAL();
        marketingPartnerDal.ChangeIsMonetizedAdvocateStatus((int)intCustomerId, true);
        Response.RedirectUser("WelcomeMonetize.aspx", true);
    }
    #endregion
    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser(ResolveUrl("/App/MarketingPartner/AffiliateDashboard.aspx"));

    }
}
