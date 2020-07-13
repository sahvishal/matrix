using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MarketingPartner;

namespace Falcon.App.UI.App.MarketingPartner.AdvocateSalesManager
{
    public partial class AsyncChartCampaignCustomer : System.Web.UI.Page
    {
        const Int16 IntPageSize = 5;
        int _intPageNumber;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["CampaignCustomer"] != null)
                {
                    if (Request.QueryString["Duration"] != null)
                    {
                        DataSet dsCampaignCustomer = GetCampaignCustomer(Request.QueryString["Duration"], Convert.ToInt64(Request.QueryString["AdvocateId"]), Request.QueryString["startdate"], Request.QueryString["enddate"], Convert.ToInt32(Request.QueryString["PageNumber"]), IntPageSize);
                        grdCampaignCustomer.DataSource = dsCampaignCustomer;
                        grdCampaignCustomer.DataBind();

                        String strPageNumber = string.IsNullOrEmpty(Request.QueryString["PageNumber"]) ? "1" : Request.QueryString["PageNumber"];
                        _intPageNumber = Convert.ToInt32(strPageNumber);

                        tblCampaignCustomerGridPaging.InnerHtml = ImplementPaging(_intPageNumber, IntPageSize, Convert.ToInt32(dsCampaignCustomer.Tables[1].Rows[0][0]), "CampaignCustomer", Request.QueryString["Duration"], Request.QueryString["selimage"]);


                        PrepareCampaignCustomerChart(Request.QueryString["Duration"]);

                        var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempJpgFileLocation();

                        chartCampaignCustomer.SaveImage(mediaLocation.PhysicalPath);

                        Response.Write(mediaLocation .Url+ ",,");

                    }
                }
                else if (Request.QueryString["CategoryCustomer"] != null)
                {
                    if (Request.QueryString["Duration"] != null)
                    {
                        DataSet dsAdvocateCustomer = GetCategoryAdvocateCustomer(Request.QueryString["Duration"], Convert.ToInt64(Request.QueryString["CategoryId"]), Request.QueryString["startdate"], Request.QueryString["enddate"], Convert.ToInt32(Request.QueryString["PageNumber"]), IntPageSize);
                        grdAdvocateCustomer.DataSource = dsAdvocateCustomer;
                        grdAdvocateCustomer.DataBind();

                        String strPageNumber = string.IsNullOrEmpty(Request.QueryString["PageNumber"]) ? "1" : Request.QueryString["PageNumber"];
                        _intPageNumber = Convert.ToInt32(strPageNumber);

                        tblAdvocateCustomerGridPaging.InnerHtml = ImplementPaging(_intPageNumber, IntPageSize, Convert.ToInt32(dsAdvocateCustomer.Tables[1].Rows[0][0]), "CategoryCustomer", Request.QueryString["Duration"], Request.QueryString["selimage"]);


                        PrepareAdvocateCustomerChart(Request.QueryString["Duration"]);

                        var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempJpgFileLocation();

                        chartCampaignCustomer.SaveImage(mediaLocation.PhysicalPath);

                        Response.Write(mediaLocation .Url+ ",,");

                    }
                }

            }
        }

        private DataSet GetCampaignCustomer(string mode, Int64 intAdvocateId, string strStartdate, string strEndDate, int pagenumber, int pagesize)
        {
            var marketingPartnerDal = new MarketingPartnerDAL();
            switch (mode)
            {
                case "Today":
                    return marketingPartnerDal.GetCampaignCustomer(0, intAdvocateId, strStartdate, strEndDate, pagenumber, pagesize);

                case "Week":
                    return marketingPartnerDal.GetCampaignCustomer(1, intAdvocateId, strStartdate, strEndDate, pagenumber, pagesize);

                case "Month":
                    return marketingPartnerDal.GetCampaignCustomer(2, intAdvocateId, strStartdate, strEndDate, pagenumber, pagesize);

                case "All":
                    return marketingPartnerDal.GetCampaignCustomer(3, intAdvocateId, strStartdate, strEndDate, pagenumber, pagesize);
            }
            return null;
        }

        private DataSet GetCategoryAdvocateCustomer(string mode, Int64 intCategoryId, string strStartdate, string strEndDate, int pagenumber, int pagesize)
        {
            var marketingPartnerDal = new MarketingPartnerDAL();
            switch (mode)
            {
                case "Today":
                    return marketingPartnerDal.GetCategoryAdvocateCustomer(0, intCategoryId, strStartdate, strEndDate, pagenumber, pagesize);

                case "Week":
                    return marketingPartnerDal.GetCategoryAdvocateCustomer(1, intCategoryId, strStartdate, strEndDate, pagenumber, pagesize);

                case "Month":
                    return marketingPartnerDal.GetCategoryAdvocateCustomer(2, intCategoryId, strStartdate, strEndDate, pagenumber, pagesize);

                case "All":
                    return marketingPartnerDal.GetCategoryAdvocateCustomer(3, intCategoryId, strStartdate, strEndDate, pagenumber, pagesize);
            }
            return null;
        }

        private void PrepareCampaignCustomerChart(string duration)
        {
            DataSet dsCampaignCustomer = GetCampaignCustomer(Request.QueryString["Duration"], Convert.ToInt64(Request.QueryString["AdvocateId"]), Request.QueryString["startdate"], Request.QueryString["enddate"], 1, 0);

            chartCampaignCustomer.ChartAreas["chartAreaCampaignCustomer"].Area3DStyle.Enable3D = true;
            chartCampaignCustomer.Series[0]["PieDrawingStyle"] = "Default";
            chartCampaignCustomer.Series[0]["PieLabelStyle"] = "Disabled";
            Series series1 = chartCampaignCustomer.Series[0];

            if (dsCampaignCustomer.Tables[0].Rows.Count > 0)
            {
                int increasedHeight = dsCampaignCustomer.Tables[0].Rows.Count / 2;
                int mod = dsCampaignCustomer.Tables[0].Rows.Count % 2;
                if (mod > 0)
                    increasedHeight = increasedHeight + 1;


                chartCampaignCustomer.Height = Unit.Pixel((increasedHeight * 27) + Convert.ToInt32(chartCampaignCustomer.Height.Value));
            }
            for (int i = 0; i < dsCampaignCustomer.Tables[0].Rows.Count; i++)
            {
                DataPoint point = new DataPoint();
                double[] dbPoinrValue = new double[1];
                dbPoinrValue[0] = Convert.ToDouble(dsCampaignCustomer.Tables[0].Rows[i]["NoOfCustomers"]);
                point.YValues = dbPoinrValue;
                point.LegendText = Convert.ToString(dsCampaignCustomer.Tables[0].Rows[i]["CampaignName"]);
                point.ToolTip = dsCampaignCustomer.Tables[0].Rows[i]["NoOfCustomers"].ToString() + " Customers ecpa $" + dsCampaignCustomer.Tables[0].Rows[i]["CostPerCustomer"].ToString() + "/customer";
                series1.Points.Add(point);
            }




        }


        private void PrepareAdvocateCustomerChart(string duration)
        {

            DataSet dsAdvocateCustomer = GetCategoryAdvocateCustomer(Request.QueryString["Duration"], Convert.ToInt64(Request.QueryString["CategoryId"]), Request.QueryString["startdate"], Request.QueryString["enddate"], 1, 0);

            chartCampaignCustomer.ChartAreas["chartAreaCampaignCustomer"].Area3DStyle.Enable3D = true;
            chartCampaignCustomer.Series[0]["PieDrawingStyle"] = "Default";
            chartCampaignCustomer.Series[0]["PieLabelStyle"] = "Disabled";
            Series series1 = chartCampaignCustomer.Series[0];

            if (dsAdvocateCustomer.Tables[0].Rows.Count > 0)
            {
                int increasedHeight = dsAdvocateCustomer.Tables[0].Rows.Count / 2;
                int mod = dsAdvocateCustomer.Tables[0].Rows.Count % 2;
                if (mod > 0)
                    increasedHeight = increasedHeight + 1;


                chartCampaignCustomer.Height = Unit.Pixel((increasedHeight * 40) + Convert.ToInt32(chartCampaignCustomer.Height.Value));
            }
            for (int i = 0; i < dsAdvocateCustomer.Tables[0].Rows.Count; i++)
            {
                DataPoint point = new DataPoint();
                double[] dbPoinrValue = new double[1];
                dbPoinrValue[0] = Convert.ToDouble(dsAdvocateCustomer.Tables[0].Rows[i]["NoOfCustomers"]);
                point.YValues = dbPoinrValue;
                point.Url = "AdvocateCustomerDetails.aspx?AffiliateId=" + Convert.ToString(dsAdvocateCustomer.Tables[0].Rows[i]["AffiliateId"]); ;
                point.LegendText = Convert.ToString(dsAdvocateCustomer.Tables[0].Rows[i]["FullName"]);
                point.ToolTip = dsAdvocateCustomer.Tables[0].Rows[i]["NoOfCustomers"].ToString() + " Customers ecpa $" + dsAdvocateCustomer.Tables[0].Rows[i]["CostPerCustomer"].ToString() + "/customer";
                series1.Points.Add(point);
            }




        }

        private string ImplementPaging(int pagenumber, short pagesize, int recordcount, string strType, string strDuration, string strSelImage)
        {
            //StartGetChart('Today', 'imgCStoday',3245,1);
            string strPagingMethod = string.Empty;
            switch (strType)
            {
                case "CampaignCustomer":
                    strPagingMethod = "onclick=\"GetCampaignPaging('" +  HttpUtility.HtmlEncode(strDuration) + "','" + HttpUtility.HtmlEncode(strSelImage) + "',";
                    break;
                case "CategoryCustomer":
                    strPagingMethod = "onclick=\"GetCategoryPaging('" + HttpUtility.HtmlEncode(strDuration) + "','" + HttpUtility.HtmlEncode(strSelImage) + "',";
                    break;
                default:
                    break;
            }

            if (recordcount <= pagesize) return "";

            // Calculates Total number of pages possible
            int numberofpages = recordcount / pagesize;
            if ((pagesize * numberofpages) != recordcount) numberofpages++;

            int minpagenumtodisplay, maxpagenumtodisplay;

            //Calculates first and last page number to display in paging tab, so as to decide whole range
            minpagenumtodisplay = (pagenumber % IntPageSize) > 0 ? (((pagenumber / IntPageSize) * IntPageSize) + 1) : ((((pagenumber / IntPageSize) - 1) * IntPageSize) + 1);
            maxpagenumtodisplay = (pagenumber % IntPageSize) > 0 ? (((pagenumber / IntPageSize) * IntPageSize) + IntPageSize) : ((pagenumber / IntPageSize) * IntPageSize);

            if (maxpagenumtodisplay > numberofpages)
            {
                if ((maxpagenumtodisplay - numberofpages) < minpagenumtodisplay) minpagenumtodisplay = minpagenumtodisplay - (maxpagenumtodisplay - numberofpages);
                maxpagenumtodisplay = numberofpages;
            }

            // Forms the paging tab string
            string pagingtableHtml = "<table  style=\"border:none; float:left; \"><tr> ";

            if (recordcount > IntPageSize && minpagenumtodisplay > 1) // Applied if number of pages are greater than 10 and number of records are more than page size
            {
                pagingtableHtml += "<td><a href='javascript:void(0)' " + strPagingMethod + HttpUtility.HtmlEncode(Convert.ToString(minpagenumtodisplay - 1)) + ")\">...</a></td>";
            }

            // Forms the Paging Number HTML .... for the range
            for (int icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
            {
                if (pagenumber == icount)
                    pagingtableHtml += "<td style=\" padding:4px; \">" + HttpUtility.HtmlEncode(Convert.ToString(icount)) + "</td>";
                else
                    pagingtableHtml += "<td style=\" padding:4px;\"><a href='javascript:void(0)' " + strPagingMethod + HttpUtility.HtmlEncode(Convert.ToString(icount)) + ")\">" + HttpUtility.HtmlEncode(Convert.ToString(icount)) + "</a></td>";
            }

            if (numberofpages > IntPageSize && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
            {
                pagingtableHtml += "<td><a href='javascript:void(0)' " + strPagingMethod + HttpUtility.HtmlEncode(Convert.ToString(maxpagenumtodisplay + 1)) + ")\">...</a></td>";
            }

            pagingtableHtml += " </tr></table>";
            return pagingtableHtml;
        }

    }
}
