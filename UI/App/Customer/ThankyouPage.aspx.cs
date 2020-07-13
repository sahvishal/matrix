using System;

public partial class App_Customer_ThankyouPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void SetName(object sender, EventArgs e)
    {
        spFullName.InnerText = uc1.CustName;
    }
}
