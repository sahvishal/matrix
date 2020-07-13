using System;
using System.Configuration;
using System.Web;
using Falcon.App.Core.Enum;

public partial class ucamwelcomebox : System.Web.UI.UserControl
{
    protected Int32 mintTimeout = ((HttpContext.Current.Session.Timeout * 60) - 5) * 1000;

    #region "UC Events"

    /// <summary>
    /// Load Event sets role menu control for the user logged in
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Response.AppendHeader("Refresh", Convert.ToString(((HttpContext.Current.Session.Timeout * 60) - 5), System.Globalization.CultureInfo.CurrentCulture) + "; Url=" + ConfigurationManager.AppSettings["SessionExpireRedirectPage"]); 
            
        }
    }
   

    #endregion


    #region "User Built Functions"
    /// <summary>
    /// Sets link href's according to the role with which
    /// user is logged in.
    /// </summary>
    /// <param name="userrole"></param>
    public void SetLinks(ERoleType userrole)
    {
        pFranchiseeNameHeader.Visible = false;
    }

    #endregion
}
