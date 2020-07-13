using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.DependencyResolution;
using TemplateTypeEnum = Falcon.App.Core.Communication.Enum.TemplateType;


public partial class App_Franchisor_Admin_ManageEmailTemplate : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Manage Email Templates";

        Franchisor_FranchisorMaster obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Manage Email Templates");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                ViewState["TemplateType"] = 0;
                ViewState["CoverLetterType"] = 0;
                if (Session["EmailSubject"] != null && (string)Session["EmailSubject"] != "")
                {
                    txtEmailSubject.Text = Session["EmailSubject"].ToString();
                    ViewState["EmailSubject"] = Session["EmailSubject"].ToString();
                    ViewState["SearchStatus"] = "No";
                    ViewState["SortExpression"] = "EmailSubject";
                    ViewState["SortDir"] = "asc";
                }
                else
                {
                    ViewState["EmailSubject"] = txtEmailSubject.Text;
                    ViewState["SearchStatus"] = "No";
                    ViewState["SortExpression"] = "EmailSubject";
                    ViewState["SortDir"] = "asc";
                }
            }
            else
            {
                ViewState["EmailSubject"] = txtEmailSubject.Text;
                ViewState["SearchStatus"] = "No";
                ViewState["SortExpression"] = "EmailSubject";
                ViewState["SortDir"] = "asc";
                ViewState["TemplateType"] = rbtLstTemplateType.SelectedValue;
                ViewState["CoverLetterType"] = rbtLstCoverLetterType.SelectedValue;
            }
            grdManageEmailTemplate.PageSize = Convert.ToInt32(ddlRecords.SelectedValue);
            GetEmailTemplate("", 0, 0);
        }
        if (Page.IsPostBack)
        {
            string eventArg = Request["__EVENTARGUMENT"];
            if (eventArg.Equals("Reset"))
            {
                ViewState["EmailSubject"] = txtEmailSubject.Text;
                ViewState["SearchStatus"] = "No";
                ViewState["SortExpression"] = "EmailSubject";
                ViewState["SortDir"] = "asc";
                txtEmailSubject.Text = "";
                GetEmailTemplate("", 0, 0);
                Session["EmailSubject"] = null;
                ViewState["TemplateType"] = rbtLstTemplateType.SelectedValue;
                ViewState["CoverLetterType"] = rbtLstCoverLetterType.SelectedValue;
                rbtLstTemplateType.SelectedValue = "0";
                rbtLstCoverLetterType.SelectedValue = "0";
            }
        }
    }

    #region Get Email Template
    private void GetEmailTemplate(string EmailSubject, Int64 TemplateType, Int64 CoverLetterType)
    {
        if (ViewState["EmailSubject"] != null && (string)ViewState["EmailSubject"] != "")
        {
            EmailSubject = ViewState["EmailSubject"].ToString();
        }
        if (ViewState["TemplateType"] != null && (string)ViewState["TemplateType"] != "0")
        {
            TemplateType = Convert.ToInt64(ViewState["TemplateType"]);
        }

        if (ViewState["CoverLetterType"] != null && (string)ViewState["CoverLetterType"] != "0")
        {
            CoverLetterType = Convert.ToInt64(ViewState["CoverLetterType"]);
        }

        var emailTemplateRepository = IoC.Resolve<IEmailTemplateRepository>();
        var emailTemplates = emailTemplateRepository.GetEmailTemplates(EmailSubject, TemplateType, CoverLetterType);

        if (emailTemplates != null)
        {
            var dtEmailTemplate = new DataTable();

            dtEmailTemplate.Columns.Add("EmailTemplateID", typeof(Int64));
            dtEmailTemplate.Columns.Add("EmailTitle");
            dtEmailTemplate.Columns.Add("EmailTemplateTitle");
            dtEmailTemplate.Columns.Add("EmailSubject");
            dtEmailTemplate.Columns.Add("EmailBody");
            dtEmailTemplate.Columns.Add("TemplateType");
            if (dtEmailTemplate != null)
            {
                foreach (var emailTemplate in emailTemplates)
                {
                    var templateTypeColumnValue = string.Empty;

                    var emailTemplateEnum = (TemplateTypeEnum)emailTemplate.TemplateType;
                    templateTypeColumnValue = emailTemplateEnum.GetDescription();

                    dtEmailTemplate.Rows.Add(new object[] { emailTemplate.Id, emailTemplate.Alias, emailTemplate.Alias, emailTemplate.Subject, emailTemplate.Body, templateTypeColumnValue });
                }
            }
            if (ViewState["SortDir"] != null && (string)ViewState["SortDir"] != "")
            {
                if (ViewState["SortDir"].ToString().Equals("asc"))
                {
                    dtEmailTemplate.DefaultView.Sort = " " + ViewState["SortExpression"] + " asc";

                }
                else
                {
                    dtEmailTemplate.DefaultView.Sort = " " + ViewState["SortExpression"] + " desc";
                }
            }
            grdManageEmailTemplate.DataSource = dtEmailTemplate.DefaultView;
            grdManageEmailTemplate.DataBind();
            if (ViewState["SearchStatus"].ToString().Equals("No"))
            {
                spnRecords.InnerText = "Found Total " + dtEmailTemplate.Rows.Count + " Email Templates";
            }
            else if (ViewState["SearchStatus"].ToString().Equals("Yes"))
            {
                spnRecords.InnerText = "Found " + dtEmailTemplate.Rows.Count + " Email Templates Matching Criteria";
            }
        }

    }
    #endregion

    #region Serach Email Template
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        // Search Records.
        ViewState["EmailSubject"] = txtEmailSubject.Text;
        ViewState["TemplateType"] = rbtLstTemplateType.SelectedValue;
        ViewState["CoverLetterType"] = rbtLstCoverLetterType.SelectedValue;

        ViewState["SearchStatus"] = "Yes";
        if (!string.IsNullOrEmpty(txtEmailSubject.Text))
        {
            Session["EmailSubject"] = txtEmailSubject.Text;
        }

        else Session["EmailSubject"] = null;
        Session["TemplateType"] = rbtLstTemplateType.SelectedValue;
        GetEmailTemplate("", 0, 0);
    }

    #endregion

    #region Grid Page Size SelectedIndexChanged
    protected void ddlRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdManageEmailTemplate.PageSize = Convert.ToInt32(ddlRecords.SelectedValue);
        GetEmailTemplate("", 0, 0);
    }
    #endregion

    #region Grid Sorting
    protected void grdManageEmailTemplate_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("EmailSubject"))
        {
            ViewState["SortExpression"] = "EmailSubject";
        }
        if (e.SortExpression.Equals("TemplateType"))
        {
            ViewState["SortExpression"] = "TemplateType";
        }

        if (ViewState["SortDir"].ToString().Equals("asc"))
        {
            ViewState["SortDir"] = "desc";
        }
        else
        {
            ViewState["SortDir"] = "asc";
        }
        GetEmailTemplate("", 0, 0);
    }
    #endregion

    #region Grid PageIndexChanging
    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdManageEmailTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdManageEmailTemplate.PageIndex = e.NewPageIndex;
        GetEmailTemplate("", 0, 0);
    }
    #endregion


}
