using System;
using System.Text;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MarketingPartner;
using Falcon.App.Lib;

public partial class App_MarketingPartner_ChangeAdvanceAdvocate : System.Web.UI.Page
{
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        var marketingPartnerDal = new MarketingPartnerDAL();
        marketingPartnerDal.ChangeExpressToAdvancedAdvocate((int)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, true);
        var sbScript = new StringBuilder();

        sbScript.Append("<script language='JavaScript' type='text/javascript'>");
        sbScript.Append("alert('You will not be able to manage camapigns from now.');window.location='AffiliateDashboard.aspx'");  // <--- be very careful here, as single quote ( ' ) use in parameter

        sbScript.Append("</script>");
        ClientScript.RegisterStartupScript(typeof(Page), "@@@@MyCallBackAlertScript", sbScript.ToString());
    }
}
