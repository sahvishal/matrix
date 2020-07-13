using System;

namespace Falcon.App.UI.Public.GiftCertificates
{
    public partial class CustomerDetailStep2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        
        protected void ErrorGeneratedOnClick(string errorMessage)
        {
            spErrorMsgtop.InnerHtml = errorMessage;
            spErrorMsgbottom.InnerHtml = errorMessage;
            divErrortop.Visible = true;
            divErrorbottom.Visible = true;
        }
    }
}
