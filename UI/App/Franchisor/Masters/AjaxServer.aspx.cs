using System;
using Falcon.DataAccess.Master;

using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Franchisor_Masters_AjaxServer : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        int mode = Convert.ToInt32(Request["mode"]);
        if (mode == 1)
        {
            Response.Clear(); // Initially clear the response.
            //System.Threading.Thread.Sleep(20000000);
            Response.ContentType = "text/xml"; // Set the content type for response

            string xmlDeclartion = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            var zipCode = Convert.ToInt64(Request["zipcode"]);

            //CityService service = new CityService();
            //service.CheckForValidZipcode(ZipCode, temp, out returnresult, out temp);

            var masterDal = new MasterDAL();
            long returnResult = masterDal.GetZipCodeId(zipCode);  

            returnResult = returnResult == -1 ? 1 : 0;
            xmlDeclartion = xmlDeclartion + "<result>" + returnResult.ToString() +"</result>";
            Response.Write(xmlDeclartion);
        }
        else if (mode == 2)
        {
            if (Request.QueryString["zipcode"] != null)
            {
                var zipCode = Request.QueryString["zipcode"];

                //CityService objCityService = new CityService();
                //HealthYes.Web.UI.CityService.ECity[] objLCity;
                //objLCity = objCityService.GetZipDetails(zipCode);

                var masterDal = new MasterDAL();
                var cities = masterDal.GetZipDetails(zipCode, 4);

                if (cities != null && cities.Count > 0)
                {
                    spZipAvail.InnerText = "Zip Available";

                    divZipDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                    spLatitude.InnerText = cities[0].Zipcode.Latitude;
                    spLongitude.InnerText = cities[0].Zipcode.Longitude;
                    spTimeZone.InnerText = cities[0].Zipcode.TimeZone;

                    divCityStateGrd.Style.Add(HtmlTextWriterStyle.Display, "block");
                    var dt = new DataTable();
                    dt.Columns.Add("ZipCode");
                    dt.Columns.Add("City");
                    dt.Columns.Add("State");
                    for (int count = 0; count < cities.Count; count++)
                    {
                        dt.Rows.Add(new object[] { cities[count].Zipcode.ZipCode, cities[count].Name, cities[count].State.Name });
                    }
                    grdCityDetails.DataSource = dt;
                    grdCityDetails.DataBind();
                                        
                }
                else
                {
                    spZipAvail.InnerText = "Zip Not Available";
                    spZipAvail.Style.Add(HtmlTextWriterStyle.Color, "red");

                    divZipDetails.Style.Add(HtmlTextWriterStyle.Display, "none");

                    divCityStateGrd.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                HtmlForm newForm = this.form1;
                newForm.Controls.Clear();
                newForm.Controls.Add(divZip);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                HtmlTextWriter htWriter = new HtmlTextWriter(new System.IO.StringWriter(sb));

                newForm.RenderControl(htWriter);

                string strRenderedHtml = sb.ToString();
                strRenderedHtml = strRenderedHtml.Substring(strRenderedHtml.IndexOf("<div id=\"divZip\""), strRenderedHtml.LastIndexOf("</div") - strRenderedHtml.IndexOf("<div id=\"divZip\"") + 6);
                Response.Write(strRenderedHtml);
            }
        }
        Response.End();
    }
}
