using System;
using Falcon.DataAccess.Other;
using Falcon.App.Lib;

public partial class App_CallCenter_CallCenterRep_ExistingCustomer_ExistingCustomerCall : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";
        // To check the Valid user name ////////
        
        if (Request["CheckUserName"] != null)
        {
            Response.Write(CheckUniqueName(Request["CheckUserName"]).ToString());
            
            Response.End();
        }
        
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
