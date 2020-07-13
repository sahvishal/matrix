using System.Web.UI;
using System;

namespace Falcon.App.UI.App.Franchisor
{
    public partial class CancelShippingDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            obj.settitle("Cancel Shipping Details");
            obj.SetBreadCrumbRoot = "";
            obj.hideucsearch();
        }
    }
}