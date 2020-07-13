using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Franchisee.Territory
{
    public partial class SalesRepAssignments : Page
    {
        private long? _franchiseeId;
        protected long FranchiseeId
        {
            get
            {
                if (!_franchiseeId.HasValue)
                {
                    _franchiseeId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
                }
                return _franchiseeId.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetFranchisorMasterPageOptions();
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
