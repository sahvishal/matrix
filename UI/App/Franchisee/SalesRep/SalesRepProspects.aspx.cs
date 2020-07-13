using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using HealthYes.Web.UI.FranchisorService;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class Franchisee_SalesRep_SalesRepProspects : System.Web.UI.Page
{
    #region Protected Methods
    /// <summary>
    /// Page Load Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Prospects");
        Page.Title = "View Prospects";

        btnConvertHost.Enabled = false;
        if (!IsPostBack)
        {

            ViewState["SortProspect"] = SortDirection.Ascending;
            if (Request.QueryString["Action"] != null)
            {
                if (Request.QueryString["Action"].ToString().Equals("Updated"))
                {
                    errordiv.Visible = true;
                    errordiv.InnerHtml = "Prospect updated Successfully";
                    //ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Prospect updated Successfully');", true);
                }
                else
                {
                    errordiv.Visible = true;
                    errordiv.InnerHtml = "Prospect added Successfully";
                    //ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Prospect added Successfully');", true);
                }
            }
            if (Request.QueryString["searchtext"] != null)
            {
                SearchProspect(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                LoadGrid();
            }
        }
    }

    #endregion

    #region Private Methods

    void LoadGrid()
    {

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        //FranchisorService service = new FranchisorService();
        FranchisorDAL objFranchisorDal=new FranchisorDAL();

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var listProspect = objFranchisorDal.GetUserProspect(string.Empty, Convert.ToInt32(currentSession.UserId), Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId), Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId), 0);
        EProspect[] arrProspect = null;
        if (listProspect != null)
            arrProspect = listProspect.ToArray();
        if (arrProspect.Length > 0)
        {
            DataTable tblProspect = new DataTable();

            tblProspect.Columns.Add("ProspectID", typeof(Int32));
            tblProspect.Columns.Add("Name");
            tblProspect.Columns.Add("Address");
            tblProspect.Columns.Add("Phone");
            tblProspect.Columns.Add("Email");

            foreach (EProspect objProspect in arrProspect)
            {
                string address = objProspect.Address.Address1 + " " + objProspect.Address.City + " " + objProspect.Address.State + " " + objProspect.Address.Country + " " + objProspect.Address.ZipID.ToString();
                tblProspect.Rows.Add(objProspect.ProspectID, objProspect.OrganizationName, address,
                                        objCommonCode.FormatPhoneNumberGet(objProspect.PhoneOffice), objProspect.EMailID);
            }

            //if ((SortDirection)ViewState["SortProspect"] == SortDirection.Descending)
            //{
            //    tblProspect.DefaultView.Sort = "name desc";
            //}
            //else
            //{
            //    tblProspect.DefaultView.Sort = "name asc";
            //}
            dgProspects.Visible = true;
            tblProspect = tblProspect.DefaultView.ToTable();
            dgProspects.DataSource = tblProspect;
            ViewState["DSGRID"] = tblProspect;
            dgProspects.DataBind();
            //errordiv.Visible = false;
        }
        else
        {
            dgProspects.Visible = false;
            errordiv.Visible = true;
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgNoRecordFound");
            btnConvertHost.Enabled = false;
            btnDelete.Enabled = false;
            divGrdProspect.Visible = false;
        }
    }

    private void SearchProspect(string searchtext)
    {
        //FranchisorService service = new FranchisorService();
        FranchisorDAL objFranchisorDAL=new FranchisorDAL();

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var listProspect = objFranchisorDAL.GetUserProspect(searchtext, Convert.ToInt32(currentSession.UserId), Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId), Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId), 1);
        EProspect[] arrProspect = null;
        if (listProspect != null)
            arrProspect = listProspect.ToArray();

        if (arrProspect!=null && arrProspect.Length > 0)
        {
            DataTable tblProspect = new DataTable();

            tblProspect.Columns.Add("ProspectID", typeof(Int32));
            tblProspect.Columns.Add("Name");
            tblProspect.Columns.Add("Address");
            tblProspect.Columns.Add("Phone");
            tblProspect.Columns.Add("Email");

            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            foreach (EProspect objProspect in arrProspect)
            {

                string address = objProspect.Address.Address1 + " " + objProspect.Address.City + " " + objProspect.Address.State + " " + objProspect.Address.Country + " " + objProspect.Address.ZipID.ToString();

                tblProspect.Rows.Add(objProspect.ProspectID, objProspect.OrganizationName, address,
                                        objCommonCode.FormatPhoneNumberGet(objProspect.PhoneOffice), objProspect.EMailID);
            }

            tblProspect = tblProspect.DefaultView.ToTable();
            dgProspects.DataSource = tblProspect;
            ViewState["DSGRID"] = tblProspect;
            dgProspects.DataBind();
            dgProspects.Visible = true;
            errordiv.Visible = false;
        }
        else
        {
            dgProspects.Visible = false;
            errordiv.Visible = true;
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgNoRecordFound");
            btnConvertHost.Enabled = false;
            btnDelete.Enabled = false;
            divGrdProspect.Visible = false;
        }
    }

    #endregion

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        //FranchisorService service = new FranchisorService();
        FranchisorDAL objFranchisorDAL=new FranchisorDAL();

        for (int i = 0; i < dgProspects.Rows.Count; i++)
        {
            HtmlInputCheckBox chkRowTemp = new HtmlInputCheckBox();
            chkRowTemp = (HtmlInputCheckBox)dgProspects.Rows[i].FindControl("chkRowChild");

            if (chkRowTemp.Checked == true)
            {
                Int32 prospectId = Convert.ToInt32(dgProspects.DataKeys[i].Value);
                //service.RemoveProspectDetails(prospectId, true, usershellmodulerole1, out tempResult, out tempResultBool);
                //mode - 5 for Remove Prospect Details
            }
        }
        //ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Record Deleted Successfully');", true);
        errordiv.Visible = true;
        errordiv.InnerHtml = "Record Deleted Successfully";
        LoadGrid();
    }

    protected void lbtNewProspect_Click(object sender, EventArgs e)
    {
        Response.RedirectUser("/App/Franchisor/NewAddProspect.aspx");
    }

    protected void btnConvertHost_Click(object sender, ImageClickEventArgs e)
    {
        //FranchisorService.FranchisorService service = new FranchisorService.FranchisorService();
        //UserService.EUserShellModuleRole usershellmodulerole = new UserService.EUserShellModuleRole();
        //usershellmodulerole = BMSSessionManagement.GetUserShellRole()[BMSSessionManagement.GetUserShellRoleSelectedIndex()];

        for (int i = 0; i < dgProspects.Rows.Count; i++)
        {
            HtmlInputCheckBox chkRowTemp = new HtmlInputCheckBox();
            chkRowTemp = (HtmlInputCheckBox)dgProspects.Rows[i].FindControl("chkRowChild");

            if (chkRowTemp.Checked == true)
            {
                Int32 prospectId = Convert.ToInt32(dgProspects.DataKeys[i].Value);
                //long tempResult;
                //bool tempResultBool;
                Response.RedirectUser(this.ResolveUrl("~/App/Franchisee/SalesRep/AddNewHost.aspx?HostID=" + prospectId + "&Action=ConvertToHost"));
                //service.ConvertProspectToHost(Convert.ToInt32(usershellmodulerole.UserID), true, prospectId, true, out tempResult, out tempResultBool);
            }
        }

        
    }

    protected void dgProspects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chklistname1");
        if (chktempheader != null)
        {
            chktempheader.Attributes["onClick"] = "GridMasterCheck()";
        }

        HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
        if (chktemprow != null)
        {
            chktemprow.Attributes["onClick"] = "GridChildCheck()";
        }
    }

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgProspects_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        dgProspects.PageIndex = e.NewPageIndex;
        dgProspects.DataSource = (DataTable)ViewState["DSGRID"];
        dgProspects.DataBind();
    }
    protected void dgProspects_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tblProspect = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortProspect"] == SortDirection.Descending)
        {
            tblProspect.DefaultView.Sort = "name asc";
            ViewState["SortProspect"] = SortDirection.Ascending;
        }
        else
        {
            tblProspect.DefaultView.Sort = "name desc";
            ViewState["SortProspect"] = SortDirection.Descending;
        }
        tblProspect = tblProspect.DefaultView.ToTable();

        dgProspects.DataSource = tblProspect;
        ViewState["DSGRID"] = tblProspect;

        dgProspects.DataBind();
    }
}
