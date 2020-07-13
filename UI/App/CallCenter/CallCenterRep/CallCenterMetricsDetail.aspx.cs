using System;
using System.Web.UI;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep
{
    public partial class CallCenterMetricsDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Call Center Rep Metric Detail";

            var callCenterMasterPage = (CallCenter_CallCenterMaster)Master;
            callCenterMasterPage.settitle(Page.Title);
            callCenterMasterPage.SetBreadCrumbRoot = "<a href=\"/App/CallCenter/CallCenterRep/Metrics.aspx\">Call Center Rep Stats</a>";
        }
    }
}
