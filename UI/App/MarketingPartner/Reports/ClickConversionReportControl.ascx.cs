using System;

namespace Falcon.App.UI.App.MarketingPartner.Reports
{    
    public partial class ClickConversionReportControl : System.Web.UI.UserControl
    {
        private int _defaultItemsPerPage = 20;
        public int DefaultItemsPerPage
        {
            get { return _defaultItemsPerPage; }
            set { _defaultItemsPerPage = value; }
        }

        public long? CampaignId { get; set; }

        public string MethodUrl { get; set; }
        public string CountMethodUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            MethodUrl = ResolveUrl("~/App/MarketingPartner/Reports/ClickConversionReportService.asmx/GetClicksInDateRange");
            CountMethodUrl = ResolveUrl("~/App/MarketingPartner/Reports/ClickConversionReportService.asmx/CountClicksInDateRange");
        }
    }

}