using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.DataAccess.MarketingPartner;

public partial class App_MarketingPartner_AdvocateSalesManager_Dashboard : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        App_MarketingPartner_AdvocateSalesManager objmaster = (App_MarketingPartner_AdvocateSalesManager)this.Master;
        Title = "Advocate Manager Dashboard";
        objmaster.settitle("Advocate Manager Dashboard");
        objmaster.SetBreadCrumbRoot = "<a href=\"/App/MarketingPartner/AdvocateSalesManager/DashBoard.aspx\">DashBoard</a> ";
        objmaster.hideucsearch();
        if (!IsPostBack)
        {
            SetAdvocateDetails(string.Empty, string.Empty);
            ibtnEAll.ImageUrl = "~/App/Images/MarketingPartner/All-tab-active_mp.gif";
        }
    }
    /// <summary>
    /// Set differentg timespan for searching affiliate
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnCampaign_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgSender = (ImageButton)sender;

        DateTime dtDate = DateTime.Now;

        ibtnEToday.ImageUrl = "~/App/Images/MarketingPartner/today-tab-off_mp.gif";
        ibtnEThisWeek.ImageUrl = "~/App/Images/MarketingPartner/thisweek-tab-off_mp.gif";
        ibtnEThisMonth.ImageUrl = "~/App/Images/MarketingPartner/thismonth-tab-off_mp.gif";
        ibtnEAll.ImageUrl = "~/App/Images/MarketingPartner/All-tab-off_mp.gif";

        string strStartdate = string.Empty;
        string strEnddate = string.Empty;
        switch (imgSender.CommandName)
        {
            case "Today":                
                strStartdate = dtDate.ToShortDateString();
                strEnddate = dtDate.AddDays(1).ToShortDateString();
                imgSender.ImageUrl = "~/App/Images/MarketingPartner/today-tab-active_mp.gif";
                break;
            case "ThisWeek":              
                strStartdate = dtDate.AddDays(0 - Convert.ToInt32(dtDate.DayOfWeek)).ToShortDateString();
                strEnddate = dtDate.AddDays(6 - Convert.ToInt32(dtDate.DayOfWeek)).ToShortDateString();
                imgSender.ImageUrl = "~/App/Images/MarketingPartner/thisweek-tab-active_mp.gif";
                break;
            case "ThisMonth":              
                strStartdate = new DateTime(dtDate.Year, dtDate.Month, 1).AddDays(0).ToShortDateString();
                strEnddate = new DateTime(dtDate.AddMonths(1).Year, dtDate.AddMonths(1).Month, 1).AddDays(0).ToShortDateString();
                imgSender.ImageUrl = "~/App/Images/MarketingPartner/thismonth-tab-active_mp.gif";
                break;
            case "All":
                imgSender.ImageUrl = "~/App/Images/MarketingPartner/All-tab-active_mp.gif";
                break;
        }
        SetAdvocateDetails(strStartdate, strEnddate);

    }

    private void SetAdvocateDetails(string startDate, string endDate)
    {
        var marketingPartnerDal = new MarketingPartnerDAL();
        string advocateManagerData = marketingPartnerDal.GetAdvocateManagerData(startDate, endDate);
        spCampaignCount.InnerText= string.Empty;
        spExpressAdvocateCount.InnerText = "0";
        spAdvancedAdvocateCount.InnerText = "0";
        spMarketingMaterialCount.InnerText = "0";
        spCommission.InnerText = "0";
        
        if (!string.IsNullOrEmpty(advocateManagerData))
        {
            string[] advocateManager = advocateManagerData.Split(new char[] { ',' });
            spCampaignCount.InnerText = advocateManager[0].Split(new char[] { '=' })[1];
            spExpressAdvocateCount.InnerText = advocateManager[1].Split(new char[] { '=' })[1];
            spAdvancedAdvocateCount.InnerText = advocateManager[2].Split(new char[] { '=' })[1];
            spMarketingMaterialCount.InnerText = advocateManager[3].Split(new char[] { '=' })[1];
            spCommission.InnerText = advocateManager[4].Split(new char[] { '=' })[1];

            spTotalClient.InnerText = Convert.ToString(Convert.ToInt32(spExpressAdvocateCount.InnerHtml) + Convert.ToInt32(spAdvancedAdvocateCount.InnerHtml));
        }
    }
}
