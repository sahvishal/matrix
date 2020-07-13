using System;
using System.Web.UI;

namespace Falcon.App.UI.App.MedicalVendor
{
    public partial class MedicalVendorDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMasterPageTitleAndBreadCrumbRoot();
        }

        private void SetMasterPageTitleAndBreadCrumbRoot()
        {
            var medicalVendorMasterPage = (MedicalVendor_MedicalVendorMaster)Master;
            medicalVendorMasterPage.SetBreadCrumbRoot = Page.Title;
        }
    }
}