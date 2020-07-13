using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Franchisee.Territory
{
    public partial class Manage : Page
    {
        protected long FranchiseeId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetFranchisorMasterPageOptions();
                FranchiseeId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
            }
        }

        private void SetFranchisorMasterPageOptions()
        {
            var masterPage = (Franchisor_FranchisorMaster)Master;
            masterPage.SetBreadCrumbRoot = "Territory";
            masterPage.settitle(Page.Title);
            masterPage.hideucsearch();
        }
        
    }
}
