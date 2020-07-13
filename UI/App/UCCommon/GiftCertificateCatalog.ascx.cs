using System;
using System.Web.UI;
using Falcon.App.Lib;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class GiftCertificateCatalog : System.Web.UI.UserControl
    {
        public bool IsOnlinePurchase { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HelperFunctions.TieButton(CustomAmountInputText, NextStepImageButton);
            Session["GiftCertificateId"] = null;
        }

        protected void SomeFunction(object sender, ImageClickEventArgs e)
        {

        }
    }
}