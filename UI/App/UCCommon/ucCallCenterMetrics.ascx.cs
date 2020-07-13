using System;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Roles = Falcon.App.Core.Enum.Roles;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class ucCallCenterMetrics : System.Web.UI.UserControl
    {
        public Roles UserRole { get; set; }

        private long? _callCenterCallCenterUserId;
        protected long CallCenterCallCenterUserId
        {
            get
            {
                if (UserRole == Roles.CallCenterRep)
                {
                    if (!_callCenterCallCenterUserId.HasValue)
                    {
                       _callCenterCallCenterUserId = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                    }
                }
                else
                    _callCenterCallCenterUserId = 0;

                return _callCenterCallCenterUserId.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserRole == Roles.CallCenterManager || UserRole == Roles.CallCenterRep)
                this.Page.ClientScript.RegisterHiddenField("MetricDetailLinkInputHidden", "/App/CallCenter/CallCenterRep/CallCenterMetricsDetail.aspx");
            else if (UserRole == Roles.FranchisorAdmin)
                this.Page.ClientScript.RegisterHiddenField("MetricDetailLinkInputHidden", "/App/Franchisor/Reports/MetricDetail.aspx");
        }
    }
}