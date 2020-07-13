using System;

namespace Falcon.App.UI.Public.GiftCertificates
{
    public partial class GiftCertificateSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GiftCertificatePreview.IsCallCenterPurchase = false;
            GiftCertificatePreview.IsOnlinePurchase = true;
        }
    }
}
