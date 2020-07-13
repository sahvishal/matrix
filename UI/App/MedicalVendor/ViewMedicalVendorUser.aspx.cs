using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.MedicalVendor;
using Falcon.Entity.MedicalVendor;
using Falcon.Entity.User;
using Falcon.App.Core.Enum;

public partial class MedicalVendor_ViewMedicalVendorUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Medical Vendor User";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Medical Vendor User");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Other Management</a>";

        if (!IsPostBack)
        {
            ViewState["SortExp"] = "Name";
            ViewState["SortDir"] = SortDirection.Descending;

            if (Request.QueryString["Action"] != null)
            {
                ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Medical Vendor User(Physician)" + " " + Request.QueryString["Action"].ToString() + " " + "successfully.');", true);
            }


            if (Request.QueryString["searchtext"] != null)
            {
                SearchMedicalVendorUserData(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetMedicalVendorUserData();
            }
        }

        ClientScript.RegisterArrayDeclaration("arrjscallcenterelementid", "'" + grdMVUser.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjscallcenterelementid", "'" + btnEdit.ClientID + "'");
    }
    private void SearchMedicalVendorUserData(string searchtext)
    {
        var medicalVendorDal = new MedicalVendorDAL();
        List<EMVMVUser> emvmvUsers = medicalVendorDal.GetMedicalVendorMVUser(searchtext, 5);

        DataTable tblmv = new DataTable();

        tblmv.Columns.Add("MedicalVendorMVUserID", typeof(Int32));
        tblmv.Columns.Add("BusinessName");
        tblmv.Columns.Add("Name");

        if (emvmvUsers != null && emvmvUsers.Count > 0)
        {
            foreach (EMVMVUser objEMVMVUser in emvmvUsers)
            {
                string fullname = string.Empty;
                if (objEMVMVUser.MVUser.User.MiddleName != null && objEMVMVUser.MVUser.User.MiddleName != "")
                    fullname = objEMVMVUser.MVUser.User.FirstName + " " + objEMVMVUser.MVUser.User.MiddleName + " " + objEMVMVUser.MVUser.User.LastName;
                else
                    fullname = fullname = objEMVMVUser.MVUser.User.FirstName + " " + objEMVMVUser.MVUser.User.LastName;

                tblmv.Rows.Add(objEMVMVUser.MedicalVendorMVUserID, objEMVMVUser.MedicalVendor.BusinessName, fullname);
            }
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                tblmv.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                tblmv.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            tblmv = tblmv.DefaultView.ToTable();
            ViewState["DSGRID"] = tblmv;
            grdMVUser.DataSource = tblmv;
            grdMVUser.DataBind();

            divErrorMsg.Visible = false;
        }
        else
        {
            divErrorMsg.InnerHtml = "No Records Found";
            divErrorMsg.Visible = true;
        }
    }
    private void GetMedicalVendorUserData()
    {

        var medicalVendorDal = new MedicalVendorDAL();
        List<EMVMVUser> emvmvUsers = medicalVendorDal.GetMedicalVendorMVUser(string.Empty, 3);

        DataTable tblmv = new DataTable();

        tblmv.Columns.Add("MedicalVendorMVUserID", typeof(Int32));
        tblmv.Columns.Add("BusinessName");
        tblmv.Columns.Add("Name");

        if (emvmvUsers != null && emvmvUsers.Count > 0)
        {
            foreach (EMVMVUser objEMVMVUser in emvmvUsers)
            {
                string fullname = string.Empty;
                if (objEMVMVUser.MVUser.User.MiddleName != null && objEMVMVUser.MVUser.User.MiddleName != "")
                    fullname = objEMVMVUser.MVUser.User.FirstName + " " + objEMVMVUser.MVUser.User.MiddleName + " " + objEMVMVUser.MVUser.User.LastName;
                else
                    fullname = fullname = objEMVMVUser.MVUser.User.FirstName + " " + objEMVMVUser.MVUser.User.LastName;

                tblmv.Rows.Add(objEMVMVUser.MedicalVendorMVUserID, objEMVMVUser.MedicalVendor.BusinessName, fullname);
            }

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                tblmv.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
            }
            else
            {
                tblmv.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
            }
            tblmv = tblmv.DefaultView.ToTable();
            ViewState["DSGRID"] = tblmv;
            grdMVUser.DataSource = tblmv;
            grdMVUser.DataBind();

            divErrorMsg.Visible = false;
        }
        else
        {
            divErrorMsg.InnerHtml = "No Records Found";
            divErrorMsg.Visible = true;
        }
    }
    protected void lbtnNewMedicalVendorUser_Click(object sender, EventArgs e)
    {
        Response.RedirectUser("AddMedicalVendorUser.aspx");
    }
    protected void grdMVUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                chktemprow.Attributes["onClick"] = "checkallboxes()";
            }
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        var listMedicalVendorMvUser = new ArrayList();

        for (int i = 0; i < grdMVUser.Rows.Count; i++)
        {
            HtmlInputCheckBox chkRowTemp = new HtmlInputCheckBox();
            chkRowTemp = (HtmlInputCheckBox)grdMVUser.Rows[i].FindControl("chkRowChild");
            if (chkRowTemp.Checked == true)
            {
                EMVMVUser mvmvUser = new EMVMVUser();
                mvmvUser.MedicalVendorMVUserID = Convert.ToInt32(grdMVUser.DataKeys[i].Value);
                listMedicalVendorMvUser.Add(mvmvUser);
            }
        }

        var arrMvmvUser = new EMVMVUser[listMedicalVendorMvUser.Count];
        for (int i = 0; i < listMedicalVendorMvUser.Count; i++)
        {
            arrMvmvUser[i] = new EMVMVUser();
            arrMvmvUser[i] = (EMVMVUser)listMedicalVendorMvUser[i];
        }

        var strMvmvUserId = new StringBuilder(String.Empty);

        foreach (EMVMVUser oMvmvUser in arrMvmvUser)
        {
            strMvmvUserId.Append("," + oMvmvUser.MedicalVendorMVUserID.ToString());
        }

        strMvmvUserId.Remove(0, 1);

        var medicalVendorDal = new MedicalVendorDAL();

        var returnresult = medicalVendorDal.SaveMedicalVendorMVUser(strMvmvUserId.ToString(), Convert.ToInt32(EOperationMode.DeActivate));
        if (returnresult == 0)
        {
            returnresult = 9999993;
        }

        this.GetMedicalVendorUserData();
        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        errordiv.Visible = true;
        ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Physician(s) deleted successfully.');", true);
    }
    protected void lnkMedicalVendorMVUserEdit_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;

        int mvmvuserId = 0;
        mvmvuserId = Convert.ToInt32(grdMVUser.DataKeys[grdrow.RowIndex].Value);

        if (mvmvuserId > 0)
        {
            Response.RedirectUser("AddMedicalVendorUser.aspx?MedicalVendorMVUserID=" + mvmvuserId.ToString());
        }
    }
    protected void grdMVUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMVUser.PageIndex = e.NewPageIndex;
        grdMVUser.DataSource = (DataTable)ViewState["DSGRID"];
        grdMVUser.DataBind();
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int mvmvuserId = 0;
        for (int i = 0; i < grdMVUser.Rows.Count; i++)
        {
            HtmlInputCheckBox chkPackageSelecter = new HtmlInputCheckBox();
            chkPackageSelecter = (HtmlInputCheckBox)grdMVUser.Rows[i].FindControl("chkRowChild");

            if (chkPackageSelecter.Checked == true)
            {
                mvmvuserId = Convert.ToInt32(grdMVUser.DataKeys[i].Value);
            }
        }
        if (mvmvuserId > 0)
        {
            Response.RedirectUser("AddMedicalVendorUser.aspx?MedicalVendorMVUserID=" + mvmvuserId.ToString());
        }
    }
    protected void grdMVUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtMVUser = (DataTable)ViewState["DSGRID"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtMVUser.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtMVUser.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtMVUser = dtMVUser.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["DSGRID"] = dtMVUser;
        grdMVUser.DataSource = dtMVUser;
        grdMVUser.DataBind();
    }
}
