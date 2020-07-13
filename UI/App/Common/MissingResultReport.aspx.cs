using System;

public partial class App_Common_MissingResultReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.hideucsearch();
        obj.settitle("Missing Result Report");
        this.Page.Title = "Missing Result Report";
    }
}
