using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthYes.App.Common
{
    public partial class PreviewGiftCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GiftCertificatePreview.IsCallCenterPurchase = false;
            GiftCertificatePreview.IsOnlinePurchase = false;
        }
    }
}
