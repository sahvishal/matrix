using System;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.Public.GiftCertificates
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Form["__EVENTTARGET"] != null)
                {
                    string queryString = Request.Form["__EVENTARGUMENT"].ToString();
                    Response.RedirectUser("Details.aspx?Amount=" + queryString);
                }
            }
            giftCertificateCatalog.IsOnlinePurchase = true;
        }
    }
}
