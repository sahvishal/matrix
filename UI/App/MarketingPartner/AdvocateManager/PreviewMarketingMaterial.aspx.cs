using System;
using System.Configuration;

public partial class App_MarketingPartner_AdvocateManager_PreviewMarketingMaterial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] == "1")
        {
            string serverName = ConfigurationManager.AppSettings["MMPath"];
            string folderName = ConfigurationManager.AppSettings["MarketingmaterialImagesFolder"];
            imgBanner.ImageUrl = serverName + folderName + "/" + Request.QueryString["File"];
            try
            {
                imgBanner.Width = Convert.ToInt32(Request.QueryString["Width"]);
                imgBanner.Height = Convert.ToInt32(Request.QueryString["height"]);
                divBanner.Style["display"] = "block";
            }
            catch (Exception)
            {
                Response.Write("Kindly specify valid height and width.");
            }
        }
        else if (Request.QueryString["type"] == "2")
        {
        }


    }
}
