using System;
using System.Web.UI;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.Public.GiftCertificates
{
    public partial class Details : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NavigateOnChangeAmountClick()
        {
            Response.RedirectUser("Catalog.aspx?gc=gc", false);
        }

        protected void NavigateOnSubmitClick()
        {
            Response.RedirectUser("CustomerDetailStep1.aspx?gc=gc");
        }
    }
}
