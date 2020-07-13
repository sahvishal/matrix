using System;
using System.Web.UI;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class LastLogin : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
            {
                LastLoginSpan.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).
                    ToString("MMMM dd, yyyy, hh:mm tt");
            }
            else
            {
                LastLoginDiv.Visible = false;
            }
        }
    }
}