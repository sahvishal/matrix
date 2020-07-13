using System;
using System.Configuration;

public partial class App_MarketingPartner_PreviewMarketingMaterial : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        string serverName=string.Empty;
        string folderName = string.Empty;
        if (Request.QueryString["type"] == "1")
        {
            if (Request.QueryString["path"] != null)
            {
                if (Request.QueryString["path"] == "1")
                {
                     serverName = ConfigurationManager.AppSettings["MMVirtualPath"].ToString();
                     imgBanner.ImageUrl = serverName +  Request.QueryString["File"];
                }
                else
                {
                    serverName = ConfigurationManager.AppSettings["MMVirtualPath"].ToString();
                    imgBanner.ImageUrl = serverName + Request.QueryString["File"];
                    // serverName = ConfigurationManager.AppSettings["MMPath"].ToString();
                    // folderName = ConfigurationManager.AppSettings["MarketingmaterialImagesFolder"].ToString();
                    //imgBanner.ImageUrl = serverName + folderName + "/" + Request.QueryString["File"];
                }
           
            }
            else
            {
                serverName = ConfigurationManager.AppSettings["MMVirtualPath"].ToString();
                imgBanner.ImageUrl = serverName + Request.QueryString["File"];
                 //serverName = ConfigurationManager.AppSettings["MMPath"].ToString();
                 //folderName = ConfigurationManager.AppSettings["MarketingmaterialImagesFolder"].ToString();
                //imgBanner.ImageUrl = serverName + folderName + "/" + Request.QueryString["File"];
            }

            
            
            try
            {
                //imgBanner.Width = Convert.ToInt32(Request.QueryString["Width"]);
                //imgBanner.Height = Convert.ToInt32(Request.QueryString["height"]);
                divBanner.Style["display"] = "block";
            }
            catch (System.Exception)
            {
                Response.Write("Kindly specify valid height and width.");
            }
          
        }
        else if (Request.QueryString["type"] == "2")
        {

        }


    }
}
