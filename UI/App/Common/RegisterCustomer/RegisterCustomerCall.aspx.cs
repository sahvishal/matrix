using System;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Lib;
using System.Linq;

public partial class App_Common_RegisterCustomer_RegisterCustomerCall : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        if (Request["CheckUserName"] != null)
        {
            Response.Write(CheckUniqueName(Request["CheckUserName"].ToString()));
            Response.End();
        }
        //////////////////////////////////////////
        if (Request.QueryString["CouponCode"] != null)
        {
            System.Text.StringBuilder strResponse = new System.Text.StringBuilder();
            
            string PackageCost = Request.QueryString["PackageCost"].Replace("$", "");
            
            Response.Write(strResponse.ToString());
            Response.End();
        }
        //////////////////////////////////////////
        if (Request.QueryString["CallStart"] == "True")
        {            
            Response.Write(DateTime.Now.ToString());
            Response.End();
        }
        /// end the call
        if (Request.QueryString["CallEnd"] == "True")
        {
            CommonCode objCommoncode = new CommonCode();
            objCommoncode.EndCCRepCall(this.Page);
        }

    }
    private Boolean CheckUniqueName(String strUserName)
    {
        var otherDal = new OtherDAL();

        return otherDal.CheckUniqueUserName(strUserName, 0);
    }

}
