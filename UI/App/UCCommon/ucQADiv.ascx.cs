using System;
using System.Web.UI;
using Falcon.DataAccess.Other;

public partial class App_UCCommon_ucQADiv : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Flag to display the QA Bar or Not
            string strQaBar = string.Empty;
            var otherDal = new OtherDAL();
            strQaBar = otherDal.GetConfigurationValue("DisplayBarOnQA");

            if (strQaBar != null && strQaBar != "")
            {
                divQAMain.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(strQaBar, true);
                divQA.Style.Add(HtmlTextWriterStyle.Display, "block");
                divQA.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            }
            else
            {
                
                divQA.Style.Add(HtmlTextWriterStyle.Display, "none");
                divQA.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
        }
    }
}
