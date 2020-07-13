using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Lib;

namespace HealthYes.Web.App.MarketingPartner
{
    public partial class CategoryCustomerReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Title = "Marketing Break-Up Report";
                App_MarketingPartner_MarketingPartner obj;
                obj = (App_MarketingPartner_MarketingPartner)Master;
                obj.settitle("Marketing Break-Up Report");

                
                obj.SetBreadCrumbRoot = "<a href=\"/App/franchisor/dashboard.aspx\">Dashboard</a>";
                

                obj.hideucsearch();

                ClientScript.RegisterStartupScript(typeof(string), "jstrycb", "  StartGetChart('Today', 'imgCStoday'); ", true);

                hfCategoryID.Value = "0";


                #region "Grid Data"
                spStartDate.InnerHtml = DateTime.Now.ToString("mm/dd/yyyy");
                spEndDate.InnerHtml = DateTime.Now.ToString("mm/dd/yyyy");

               
              
                #endregion
            }

        }


        protected void ibtnFilter_Click(object sender, ImageClickEventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jstrycb", "  StartGetChartDateRange('All', 'imgCSAll'); ", true);

        }




       

    }
}
