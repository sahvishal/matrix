using System;
using Roles = Falcon.App.Core.Enum.Roles;

namespace Falcon.App.UI.App.Franchisor.Reports
{
    public partial class Metrics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MetricsUserControl.UserRole = Roles.FranchisorAdmin;

            this.Page.Title = "Call Center Metrics";
            var obj = (Franchisor_FranchisorMaster)this.Master;
            obj.settitle("Call Center Metrics");
            obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
            obj.hideucsearch();
            obj.HideLeftContainer = true;
        }
    }
}
