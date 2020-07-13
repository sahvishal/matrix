using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace HealthYes.Web.App.Customer
{
    public partial class OpenIdeas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Open for Ideas";
            Customer_CustomerMaster objMaster = (Customer_CustomerMaster)this.Master;
            objMaster.SetPageView("OpenforIdeas");
            if (!IsPostBack)
            {
                if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
                {
                    spLastLogin.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
                }
                else
                {
                    divLastLogin.Visible = false;
                }
            }
        }
        public void SetName(object sender, EventArgs e)
        {
            //spFullName.InnerHtml = uc1.CustName;

        }
    }
}
