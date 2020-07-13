using System;
using System.Web.UI;

namespace Falcon.App.UI.App.Franchisor.Reports
{
    public partial class MedicalVendorPaymentsByPod : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var masterPage = (Franchisor_FranchisorMaster)Master;
            masterPage.SetBreadCrumbRoot = "Medical Vendor Payment Reports";
            masterPage.settitle("By Pod");
            masterPage.hideucsearch();
        }
    }
}
