using System;

namespace Falcon.App.UI.App.Franchisor.Reports
{
    public partial class MetricDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Call Center Metrics Detail";
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            obj.settitle("Call Center Metrics Detail");
            obj.SetBreadCrumbRoot = "<a href=\"Metrics.aspx\">Call Center Rep Stats</a>";
            obj.hideucsearch();
        }
    }
}
