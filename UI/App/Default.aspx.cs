using System;
using System.Web.UI;
using Falcon.App.UI.Extentions;


public partial class _Default : Page
{
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.RedirectUser("~/login");
    }

    

    
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        
    }

    

    
}
