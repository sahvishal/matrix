using System;
using Falcon.DataAccess.Other;

namespace Falcon.App.UI.App.Common
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Edit Customer";
            if (!IsPostBack)
            {
                if (Request.QueryString["CustomerID"] != null)
                {
                    var otherDal = new OtherDAL();
                    Int64 returnresult = otherDal.GetUid(Convert.ToInt32(Request.QueryString["CustomerID"]));
                    UCEditCustomer1.UserID = Convert.ToInt32(returnresult);
                }
            }
        }
    }
}
