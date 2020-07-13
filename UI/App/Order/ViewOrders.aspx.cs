using System;
using System.Web.UI;

namespace Falcon.App.UI.App.Order
{
    public partial class ViewOrders : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var franchisorMasterPage = (Franchisor_FranchisorMaster)Master;
            franchisorMasterPage.settitle(Page.Title);
            franchisorMasterPage.hideucsearch();
        }
    }
}
