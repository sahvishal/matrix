using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep
{
    public partial class Metrics : Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep))
                MetricsUserControl.UserRole = Roles.CallCenterRep;
            else
                MetricsUserControl.UserRole = Roles.CallCenterManager;

            if (!IsPostBack)
            {
                SetCallCenterRepMasterPageOptions();
            }
        }

        private void SetCallCenterRepMasterPageOptions()
        {
            var callCenterMasterPage = (CallCenter_CallCenterMaster)Master;
            callCenterMasterPage.settitle(Page.Title);
            callCenterMasterPage.ShowHideLeftPanel(false);
            callCenterMasterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
        }
    }
}