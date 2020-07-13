using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CheckCityZip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void State()
    {
        DataTable tblCity = (DataTable)Session["City"];
        int stateid = 0;
        stateid = Convert.ToInt32(Request.QueryString["State"]);
        if (stateid == 0)
            return;

        System.Text.StringBuilder chString = new System.Text.StringBuilder();
        tblCity.DefaultView.RowFilter = "StateID = " + stateid;
        DataView dvCity = tblCity.DefaultView;

        DataSet ds = new DataSet();
        tblCity = dvCity.ToTable();
        ds.Tables.Add(tblCity);
        ds.Prefix = "State";

        chString.Append(ds.GetXml());
        Response.Write(chString.ToString());
    }

    protected void Country()
    {
        DataTable tblState = (DataTable)Session["State"];
        int countryid = 0;
        countryid = Convert.ToInt32(Request.QueryString["Country"]);
        if (countryid == 0)
            return;

        System.Text.StringBuilder chString = new System.Text.StringBuilder();
        tblState.DefaultView.RowFilter = "CountryID = " + countryid;
        DataView dvState = tblState.DefaultView;
        DataSet ds = new DataSet();
        tblState = dvState.ToTable();
        ds.Tables.Add(tblState);
        chString.Append(ds.GetXml());
        Response.Write(chString.ToString());
    }
}
