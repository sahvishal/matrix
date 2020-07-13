using System;
using System.Configuration;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MarketingPartner;
using Falcon.Entity.Affiliate;
using Falcon.App.Lib;


public partial class App_UCCommon_ucHospitalPartnerBanner : System.Web.UI.UserControl
{
    private Int64 intCustomerId = 0;
    public Int64 CustomerID
    {
        get { return intCustomerId; }
        set { intCustomerId = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    public string LoadBanner()
    {
        // format phone no.
        var objCommonCode = new CommonCode();
        
        string serverName = ConfigurationManager.AppSettings["MMWebPath"];
        string strServerImagePath = ConfigurationManager.AppSettings["MMVirtualPath"];
        string strHPBanner;
        string strAssosiatedPhoneNumber = "";
        strHPBanner = GetHPBannerForCustomer(intCustomerId, serverName, strServerImagePath, out strAssosiatedPhoneNumber);

        if (strHPBanner != string.Empty)
        {
            spHPBanner.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(strHPBanner, true);
        }
        else
        {
            const string imagePathUrl = "/Config/Content/Images/CustomerBanner.jpg";
            if (File.Exists(Server.MapPath(imagePathUrl)))
            {
                spHPBanner.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode("<a href=\"SearchEvent.aspx\"><img src=\"" + imagePathUrl + "\"/></a>", true);
            }
        }
        return objCommonCode.FormatPhoneNumberGet(strAssosiatedPhoneNumber);
    }

    public String GetHPBannerForCustomer(Int64 intCustomerId, String strServerPath, String strServerImagePath, out string strassociatedphonenum)
    {
        string strHtmlString = string.Empty;
        strassociatedphonenum = string.Empty;
        var marketingPartnerDal = new MarketingPartnerDAL();
        Int64 intCampaignid;
        Int64 intAdvocateid;
        try
        {
            EMarketingMaterial bannerForCustomer = marketingPartnerDal.GetHPBannerForCustomer(intCustomerId, out intCampaignid, out intAdvocateid, out strassociatedphonenum);
            if (bannerForCustomer.MarketingMaterialId > 0)
            {
                marketingPartnerDal.UpdateClickImpressionCount(bannerForCustomer.MarketingMaterialId, intCampaignid, 0);
                var encryptionHelper = new EncryptionHelper();
                string authCode = encryptionHelper.Encrypt("mid=" + bannerForCustomer.MarketingMaterialId.ToString() + "//CId=" + intCampaignid.ToString() + "//aId=" + intAdvocateid.ToString());


                string nameHyparent = "<span id='hyParent' name='hyParent' >";
                nameHyparent = nameHyparent + "<input name='hdAuthKey' id='hdAuthKey' type='hidden'  value='" + authCode + "' />";

                nameHyparent = nameHyparent + "<script type='text/javascript'>var AuthKey = '" + authCode + "';</script>";
                string hyStyleend = "</span>";
                if ((bannerForCustomer.LeadingInURL == "http://") || (bannerForCustomer.LeadingInURL == string.Empty))
                {
                    bannerForCustomer.LeadingInURL = IoC.Resolve<ISettings>().SiteUrl;
                }

                strHtmlString = strHtmlString + "<a href='#' onclick='window.open(\"" + strServerPath + "OnlineAdvertisment/imp.ashx?AuthKey=" + authCode + "&Type=Click&LeadingUrl=" + bannerForCustomer.LeadingInURL + "\")'>";
                strHtmlString = strHtmlString + "<img src='" + strServerImagePath + bannerForCustomer.ImagePath.Substring(bannerForCustomer.ImagePath.LastIndexOf("\\") + 1) + "'  border='0' alt='" + bannerForCustomer.Text + "' /></a>";

                strHtmlString = nameHyparent + strHtmlString + hyStyleend;
            }
            return strHtmlString;
        }
        catch
        {
            return string.Empty;
        }

    }

    public void LoadDefaultBanner()
    {

        spHPBanner.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode("<a href=\"SearchEvent.aspx\"><img src=\"/App/Images/customer/NewCustomerhpBanner.jpg\"/></a>", true);


    }
}
