using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

public partial class App_Franchisee_Technician_GenerateDepositeSlip : System.Web.UI.Page
{
    string TotalAmount = string.Empty;
    string TotalAmountCash = string.Empty;
    string TotalAmountCheck = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDepositeSlip();
            lbldate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }

    private void GetDepositeSlip()
    {
        if (Request.QueryString["EventID"] != null)
        {
            Int32 eventid = Convert.ToInt32(Request.QueryString["EventID"]);
            var masterDal = new MasterDAL();
            List<EDepositeSlip> objEDepositeSlip = masterDal.GetDepositeSlip(eventid);

            DataTable dtDepositeSlip = new DataTable();

            dtDepositeSlip.Columns.Add("SerialNo", typeof(Int64));
            dtDepositeSlip.Columns.Add("Name");
            dtDepositeSlip.Columns.Add("PaymentMode");
            dtDepositeSlip.Columns.Add("Amount", typeof(Double));
            dtDepositeSlip.Columns.Add("ChequeNumber");
            dtDepositeSlip.Columns.Add("RoutingNumber");
            dtDepositeSlip.Columns.Add("AccountNumber");
            if (objEDepositeSlip != null)
            {
                for (int icount = 0; icount < objEDepositeSlip.Count; icount++)
                {
                    dtDepositeSlip.Rows.Add(new object[] { objEDepositeSlip[icount].SerialNo, 
                                                            objEDepositeSlip[icount].CustomerName, 
                                                            objEDepositeSlip[icount].PaymentType, 
                                                            objEDepositeSlip[icount].PaymentAmount, 
                                                            objEDepositeSlip[icount].ChequeNumber,
                                                            objEDepositeSlip[icount].RoutingNumber,
                                                            objEDepositeSlip[icount].AccountNumber});                    
                }
            }
            if (objEDepositeSlip != null)
                if (objEDepositeSlip.Count > 0)
                {
                    TotalAmount = objEDepositeSlip[0].TotalAmount;
                    TotalAmountCash = objEDepositeSlip[0].TotalAmountCash;
                    TotalAmountCheck = objEDepositeSlip[0].TotalAmountCheck;

                    grdDepositeSlip.DataSource = dtDepositeSlip;
                    grdDepositeSlip.DataBind();

                    // If deposit slip have only cash payments
                    if (TotalAmountCheck.Length <= 0)
                    {
                        grdDepositeSlip.Rows[0].Style.Add(HtmlTextWriterStyle.Display, "none");
                        grdDepositeSlip.Rows[0].Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    }

                    StringBuilder sb = new StringBuilder();
                    string[] MainDigit = TotalAmount.Split('.');
                    if (MainDigit[0] != "")
                    {
                        for (int i = 0; i < MainDigit[0].Length; i++)
                        {
                            sb.Append("<img src=" + ImageName(MainDigit[0].Substring(i, 1)) + " alt='' />");
                        }
                        sb.Append("<img src='/App/Images/dott-bs.gif' alt='' />");
                        for (int i = 0; i < MainDigit[1].Length; i++)
                        {
                            sb.Append("<img src=" + ImageName(MainDigit[1].Substring(i, 1)) + " alt='' />");
                        }
                    }
                    spnTotalImageAmount.InnerHtml = sb.ToString();
                    // For total cash
                    if (TotalAmountCash != "")
                    {
                        string[] strTotalAmountCash = TotalAmountCash.Split('.');
                        if (strTotalAmountCash.Length >= 1)
                            tdCashDollar.InnerHtml = strTotalAmountCash[0];
                        if (strTotalAmountCash.Length >= 2)
                            tdCashCent.InnerHtml = strTotalAmountCash[1];
                    }
                    // For total checks
                    if (TotalAmountCheck != "")
                    {
                        string[] strTotalAmountCheck = TotalAmountCheck.Split('.');
                        if (strTotalAmountCheck.Length >= 1)
                            tdChequeDollar.InnerHtml = strTotalAmountCheck[0];
                        if (strTotalAmountCheck.Length >= 2)
                            tdChequeCent.InnerHtml = strTotalAmountCheck[1];
                    }

                }
                else
                {
                    spnNoRecord.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                    spnNoRecord.Style.Add(HtmlTextWriterStyle.Display, "block");
                    grdDepositeSlip.Visible = false;
                }
        }
    }
/*
    private void CreateSlip()
    {
        if (Request.QueryString["EventID"] != null && Request.QueryString["PrintDepositSlip"] != null)
        {
            string redirecturl = "GenerateDepositeSlip.aspx";
            string pdfname = "DepositSlip_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
            string servermappath = Server.MapPath("../../../pdf/" + pdfname);
            string PdfPath = string.Empty;
            string newpdfpath = Request.Url.OriginalString.Replace(Request.Url.AbsolutePath, "/App/Franchisee/Technician/" + redirecturl);
            if (newpdfpath.IndexOf('?') >= 0)
            {
                newpdfpath = newpdfpath.Substring(0, newpdfpath.IndexOf('?'));
                newpdfpath = newpdfpath + "?EventID=" + Request.QueryString["EventID"];
                PdfPath = newpdfpath.Replace(Request.Url.AbsolutePath, "/pdf");
            }
            if (PdfPath.IndexOf('?') >= 0)
            {
                PdfPath = PdfPath.Substring(0, PdfPath.IndexOf('?'));
            }

            HealthYes.Utility.CommonClass.GeneratePDF(newpdfpath, servermappath);
            ClientScript.RegisterStartupScript(typeof(string), "JSCode", "popupmenu2('" + PdfPath + "/" + pdfname + "',520,620);", true);

        }
    }
*/
/*
    private void WritePDF()
    {
        string pdfname = "DepositSlip_" + DateTime.Now.ToFileTimeUtc() + ".pdf";

        if (!Directory.Exists(Server.MapPath("/pdf/")))
        {
            Directory.CreateDirectory(Server.MapPath("/pdf/"));
        }
        string servermappath = Server.MapPath("/pdf/" + pdfname);
        //BMSSessionManagement objSession = new BMSSessionManagement();
        //objSession.GetBMSSessionObject();
        //string rolename = objSession.GetUserShellRole()[objSession.GetUserShellRoleSelectedIndex()].RoleName;

        string newpdfpath = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "/App/Franchisee/Technician/GenerateDepositeSlip.aspx");

        //// Replace the query string in case it already cames from url
        //if (newpdfpath.IndexOf('?') >= 0)
        //{
        //    newpdfpath = newpdfpath.Substring(0, newpdfpath.IndexOf('?'));
        //}

        //if (ViewState["ParameterString"] != null && ViewState["ParameterString"].ToString().Length > 0)
        //    newpdfpath = newpdfpath + "?" + ViewState["ParameterString"].ToString() + "&RoleName=" + rolename;
        //else
        //    newpdfpath = newpdfpath + "?" + "RoleName=" + rolename;


        string strURL = string.Empty;
        if (Request.Url.AbsoluteUri.IndexOf('?') >= 0)
        {
            strURL = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf('?')).Replace(Request.Url.AbsolutePath, "/pdf") + "/" + pdfname;
        }
        else
        {
            strURL = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "/pdf") + "/" + pdfname;
        }
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "javascript:popupmenu2('" + strURL + "',680,700);", true);

        HealthYes.Utility.CommonClass.GeneratePDF(newpdfpath, servermappath);

    }
*/
    protected string ChequeNumber(object ChequeNumber)
    {
        string strResult = string.Empty;
        Int64 iChecqueNumber = 0;
        iChecqueNumber = (Int64)ChequeNumber;
        if (iChecqueNumber != 0)
        {
            strResult = " / " + iChecqueNumber.ToString();            
        }
        return strResult;
    }
    protected string DollarAmount(object Amount)
    {
        
        string strAmount = string.Empty;
     
        strAmount = Amount.ToString();
        string[] strMainAmount=null;
        if (strAmount != "0.00")
        {
            strMainAmount = Amount.ToString().Split('.');
        }
        if (strMainAmount.Length >= 1)
            return strMainAmount[0];
       return "0";        
    }
    protected string CentAmount(object Amount)
    {
        string strAmount = string.Empty;
      
        strAmount = Amount.ToString();
        string[] strMainAmount = null;        
        if (strAmount != "0.00")
        {
            strMainAmount = Amount.ToString().Split('.');
        }
        if (strMainAmount.Length >= 2)
            return strMainAmount[1];
      
            return "00";
    }
    private string ImageName(string ImagePoint)
    {
        string strImageName = string.Empty;
        if (ImagePoint == ",")
        {
            strImageName = "/App/Images/comma-bs.gif";
        }
        else if (ImagePoint == "-")
        {
            strImageName = "/App/Images/txtcode_minus.gif";
        }
        else
        {
            strImageName = "/App/Images/txtcode_" + ImagePoint + ".gif";
        }
        return strImageName;
    }

    protected void grdDepositeSlip_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string []Amount = TotalAmount.Split('.');

            HtmlContainerControl spnTotalAmountDollarFooter = (HtmlContainerControl)e.Row.FindControl("spnTotalAmountDollarFooter");
            HtmlContainerControl spnTotalAmountCentFooter = (HtmlContainerControl)e.Row.FindControl("spnTotalAmountCentFooter");
            if (spnTotalAmountDollarFooter != null && Amount.Length >=1)
                spnTotalAmountDollarFooter.InnerHtml = Amount[0];

            if (spnTotalAmountCentFooter != null && Amount.Length >=2)
                spnTotalAmountCentFooter.InnerHtml = Amount[1];
        }
    }
}
