using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Enum;
using Falcon.App.UI.Extentions;

public partial class App_MarketingPartner_AdvocateSalesManager_ucleftpanel : System.Web.UI.UserControl
{
    private bool reDirect = true;
    public bool Redirect
    {
        set { reDirect = value; }
        get { return reDirect; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        if (currentOrgRole.CheckRole((long)Roles.SalesRep))
        {
            ListItem obj = ddlSearch.Items.FindByValue("Customer");
            if (obj != null)
                ddlSearch.Items.Remove(obj);
        }
    }

    public void SetLinks(DataTable dtTable)
    {
        grdLinks.DataSource = dtTable;
        grdLinks.DataBind();
    }

    public void SetRecent(DataTable dtTable)
    {
        grdVisit.DataSource = null;
      
        grdVisit.DataSource = dtTable;
        grdVisit.DataBind();
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
     
            if (txtSearch.Text.Length > 0)
            {
                if (ddlSearch.Text.CompareTo("Advocate") == 0)
                {
                    Response.RedirectUser("~/App/MarketingPartner/AdvocateManager/ViewAffiliate.aspx?searchTag=" + txtSearch.Text);
                }
                else if(ddlSearch.Text.CompareTo("Campaign") == 0)
                    Response.RedirectUser("~/App/MarketingPartner/AdvocateManager/ViewCampaigns.aspx?searchTag=" + txtSearch.Text);
                else if (ddlSearch.Text.CompareTo("Marketing Material") == 0)
                    Response.RedirectUser("~/App/MarketingPartner/AdvocateManager/ViewMarketingMaterial.aspx?searchTag=" + txtSearch.Text);
            }
       
            
        
    }
}
