using System;
using System.Web;
using System.Web.UI;

namespace HealthYes.Web.App.MarketingPartner
{
    public partial class CategoryCustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hfCategoryID.Value = Convert.ToString(Request.QueryString["CategoryId"]);

            if (!Page.IsPostBack)
            {
                Title = "Marketing Break-Up Report for category";
                App_MarketingPartner_MarketingPartner obj;
               
                obj = (App_MarketingPartner_MarketingPartner)Master;
                obj.settitle("Marketing Break-Up Report for category");

                
                obj.SetBreadCrumbRoot = "<a href=\"/App/franchisor/dashboard.aspx\">Dashboard</a>";
               

                obj.hideucsearch();

                ClientScript.RegisterStartupScript(typeof(string), "jstrycb", "  StartGetChart('Today', 'imgCStoday',1); ", true);

                hfCategoryID.Value = Convert.ToString(Request.QueryString["CategoryId"]);

                if (Request.QueryString["Categoryname"] != null)
                {
                    spCategoryName.InnerHtml = HttpUtility.HtmlEncode(Convert.ToString(Request.QueryString["Categoryname"]));
                }

                #region "Grid Data"
                spStartDate.InnerHtml = DateTime.Now.ToString("mm/dd/yyyy");
                spEndDate.InnerHtml = DateTime.Now.ToString("mm/dd/yyyy");

               
              
                #endregion
            }

        }


        protected void ibtnFilter_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jstrycb", "  StartGetChartDateRange('All', 'imgCSAll',1); ", true);

        }



     

       

    }
}
