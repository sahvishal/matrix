using System;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class GiftCertificateApply : System.Web.UI.UserControl
    {

        public string GiftCertificateBalanceAmount
        {
            get { return _gcPaidAmount.Value; }
            
        }
        public string GiftCertificateId
        {
            get { return _gcId.Value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

    }
}