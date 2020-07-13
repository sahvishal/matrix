using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Falcon.App.Core.Deprecated.Enum;
using Falcon.App.Core.Enum;

public partial class BulkPrintResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["EventID"] != null)
                hfEventID.Value = Request.QueryString["EventID"];

            string pdftypestring = EPDFType.ClinicalForm.ToString();
            if (Request.QueryString["PDFType"] != null)
            {
                pdftypestring = Request.QueryString["PDFType"].ToString();
            }

            ClientScript.RegisterStartupScript(typeof(string), "jscodeBPrint", " asynLoadBulkPDF('" + pdftypestring + "'); ", true);

        }

    }
}

