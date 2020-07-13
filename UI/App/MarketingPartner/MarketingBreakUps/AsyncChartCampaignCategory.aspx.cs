using System;
using System.Configuration;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MarketingPartner;

namespace Falcon.App.UI.App.MarketingPartner.MarketingBreakUps
{
    public partial class AsyncChartCampaignCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CategoryCustomer"] != null)
                {
                    if (Request.QueryString["Duration"] != null)
                    {
                        DataSet dsCategoryCustomer = GetCategoryCustomer(Request.QueryString["Duration"], Request.QueryString["startdate"], Request.QueryString["enddate"]);
                        grdCategoryCustomer.DataSource = dsCategoryCustomer;
                        grdCategoryCustomer.DataBind();

                        PrepareCategoryCustomerChart(dsCategoryCustomer, Request.QueryString["Duration"]);

                        var mediaLocation = IoC.Resolve<IMediaRepository>().GetTempJpgFileLocation();

                        chartCategoryCustomer.SaveImage(mediaLocation.PhysicalPath);

                        Response.Write(mediaLocation.Url + ",,");

                    }
                }

            }
        }

        private DataSet GetCategoryCustomer(string modestring, string strStartDate, string strEndDate)
        {
            var marketingPartnerDal = new MarketingPartnerDAL();
            switch (modestring)
            {
                case "Today":
                    return marketingPartnerDal.GetCategoryCustomer(0, strStartDate, strEndDate);

                case "Week":
                    return marketingPartnerDal.GetCategoryCustomer(1, strStartDate, strEndDate);

                case "Month":
                    return marketingPartnerDal.GetCategoryCustomer(2, strStartDate, strEndDate);

                case "All":
                    return marketingPartnerDal.GetCategoryCustomer(3, strStartDate, strEndDate);
            }
            return null;
        }


        private void PrepareCategoryCustomerChart(DataSet dsCategoryCustomer, string duration)
        {
            chartCategoryCustomer.ChartAreas["chartAreaCategoryCustomer"].Area3DStyle.Enable3D = true;
            chartCategoryCustomer.Series[0]["PieDrawingStyle"] = "Default";
            chartCategoryCustomer.Series[0]["PieLabelStyle"] = "Disabled";
            Series series1 = chartCategoryCustomer.Series[0];

            DataPoint pGrassroot = new DataPoint();
            double[] dpGrassroot = new double[1];
            dpGrassroot[0] = 0;
            pGrassroot.LegendText = "Grassroot";

            DataPoint pPrint = new DataPoint();
            double[] dpPrint = new double[1];
            dpPrint[0] = 0;
            pPrint.LegendText = "Print";

            DataPoint pAdvocateGroup = new DataPoint();
            double[] dpAdvocateGroup = new double[1];
            dpAdvocateGroup[0] = 0;
            pAdvocateGroup.LegendText = "Advocate Group";

            DataPoint pInternet = new DataPoint();
            double[] dpInternet = new double[1];
            dpInternet[0] = 0;
            pInternet.LegendText = "Internet";

            DataPoint pDirectMail = new DataPoint();
            double[] dpDirectMail = new double[1];
            dpDirectMail[0] = 0;
            pDirectMail.LegendText = "Direct Mail";

            DataPoint pOther = new DataPoint();
            double[] dpOther = new double[1];
            dpOther[0] = 0;
            pOther.LegendText = "Other";

            DataPoint pNotDefined = new DataPoint();
            double[] dpNotDefined = new double[1];
            dpNotDefined[0] = 0;
            pNotDefined.LegendText = "Not Defined";

            DataTable dtcategoryCustomer = dsCategoryCustomer.Tables[0];

            DataRow[] drRows = dtcategoryCustomer.Select("CategoryName = 'Grassroot'");
            if (drRows.Length > 0)
            {
                dpGrassroot[0] = Convert.ToDouble(drRows[0]["NoOfCustomers"]);
                pGrassroot.YValues = dpGrassroot;
                pGrassroot.Url = "CategoryCustomerDetails.aspx?CategoryId=" + Convert.ToString(drRows[0]["CategoryId"]) + "&CategoryName=" + Convert.ToString(drRows[0]["CategoryName"]);
                if ((dpGrassroot[0] == 0) || (dpGrassroot[0] == 1))
                    pGrassroot.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customer ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
                else
                    pGrassroot.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customers ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
            }

            drRows = dtcategoryCustomer.Select("CategoryName = 'Print'");
            if (drRows.Length > 0)
            {
                dpPrint[0] = Convert.ToDouble(drRows[0]["NoOfCustomers"]);
                pPrint.YValues = dpPrint;
                pPrint.Url = "CategoryCustomerDetails.aspx?CategoryId=" + Convert.ToString(drRows[0]["CategoryId"]) + "&CategoryName=" + Convert.ToString(drRows[0]["CategoryName"]);
                if ((dpPrint[0] == 0) || (dpPrint[0] == 1))
                    pPrint.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customer ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
                else
                    pPrint.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customers ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";

            }

            drRows = dtcategoryCustomer.Select("CategoryName = 'Advocate Group'");
            if (drRows.Length > 0)
            {
                dpAdvocateGroup[0] = Convert.ToDouble(drRows[0]["NoOfCustomers"]);
                pAdvocateGroup.YValues = dpAdvocateGroup;
                pAdvocateGroup.Url = "CategoryCustomerDetails.aspx?CategoryId=" + Convert.ToString(drRows[0]["CategoryId"]) + "&CategoryName=" + Convert.ToString(drRows[0]["CategoryName"]);
                if ((dpAdvocateGroup[0] == 0) || (dpAdvocateGroup[0] == 1))
                    pAdvocateGroup.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customer ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
                else
                    pAdvocateGroup.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customers ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";

            }

            drRows = dtcategoryCustomer.Select("CategoryName = 'Internet'");
            if (drRows.Length > 0)
            {
                dpInternet[0] = Convert.ToDouble(drRows[0]["NoOfCustomers"]);
                pInternet.YValues = dpInternet;
                pInternet.Url = "CategoryCustomerDetails.aspx?CategoryId=" + Convert.ToString(drRows[0]["CategoryId"]) + "&CategoryName=" + Convert.ToString(drRows[0]["CategoryName"]);
                if ((dpInternet[0] == 0) || (dpInternet[0] == 1))
                    pInternet.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customer ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
                else
                    pInternet.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customers ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";

            }

            drRows = dtcategoryCustomer.Select("CategoryName = 'Direct Mail'");
            if (drRows.Length > 0)
            {
                dpDirectMail[0] = Convert.ToDouble(drRows[0]["NoOfCustomers"]);
                pDirectMail.YValues = dpDirectMail;
                pDirectMail.Url = "CategoryCustomerDetails.aspx?CategoryId=" + Convert.ToString(drRows[0]["CategoryId"]) + "&CategoryName=" + Convert.ToString(drRows[0]["CategoryName"]);
                if ((dpDirectMail[0] == 0) || (dpDirectMail[0] == 1))
                    pDirectMail.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customer ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
                else
                    pDirectMail.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customers ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";

            }

            drRows = dtcategoryCustomer.Select("CategoryName = 'Other'");
            if (drRows.Length > 0)
            {
                dpOther[0] = Convert.ToDouble(drRows[0]["NoOfCustomers"]);
                pOther.YValues = dpOther;
                pOther.Url = "CategoryCustomerDetails.aspx?CategoryId=" + Convert.ToString(drRows[0]["CategoryId"]) + "&CategoryName=" + Convert.ToString(drRows[0]["CategoryName"]);
                if ((dpOther[0] == 0) || (dpOther[0] == 1))
                    pOther.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customer ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
                else
                    pOther.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customers ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";

            }

            drRows = dtcategoryCustomer.Select("CategoryName = 'Not Defined'");
            if (drRows.Length > 0)
            {
                dpNotDefined[0] = Convert.ToDouble(drRows[0]["NoOfCustomers"]);
                pNotDefined.YValues = dpNotDefined;
                pNotDefined.Url = "CategoryCustomerDetails.aspx?CategoryId=" + Convert.ToString(drRows[0]["CategoryId"]) + "&CategoryName=" + Convert.ToString(drRows[0]["CategoryName"]);
                if ((dpNotDefined[0] == 0) || (dpNotDefined[0] == 1))
                    pNotDefined.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customer ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
                else
                    pNotDefined.ToolTip = drRows[0]["NoOfCustomers"].ToString() + " Customers ecpa $" + drRows[0]["CostPerCustomer"].ToString() + "/customer";
            }



            series1.Points.Add(pGrassroot);
            series1.Points.Add(pPrint);
            series1.Points.Add(pAdvocateGroup);
            series1.Points.Add(pInternet);
            series1.Points.Add(pDirectMail);
            series1.Points.Add(pOther);
            series1.Points.Add(pNotDefined);

        }


    }
}
