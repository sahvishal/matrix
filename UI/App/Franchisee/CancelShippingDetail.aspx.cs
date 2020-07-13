using System.Web.UI;
using System;

namespace Falcon.App.UI.App.Franchisee
{
    public partial class CancelShippingDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var franchisorFranchisorMaster = (Franchisor_FranchisorMaster) Master;
            franchisorFranchisorMaster.settitle("Cancel Shipping Details");
            franchisorFranchisorMaster.SetBreadCrumbRoot = "";
            franchisorFranchisorMaster.hideucsearch();
        }
    }
}