using System;
using System.Web.UI;

namespace Falcon.App.UI.App.Franchisor.Territory
{
    public partial class Manage : Page
    {
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
            masterPage.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/Dashboard.aspx\">DashBoard</a>";
            masterPage.settitle(Title);
            masterPage.hideucsearch();
        }
    }
}
