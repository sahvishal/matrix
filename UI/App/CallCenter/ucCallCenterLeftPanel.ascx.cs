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
using Falcon.App.Lib;

public partial class ucCallCenterLeftPanel : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void SetRecent(string data)
    {
        spRecentCalls.InnerHtml = data;
    }

    public void SetStats(string data)
    {
        spStats.InnerHtml = data;
    }
    
}
