using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.MedicalVendor;
using Falcon.Entity.MedicalVendor;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
//using HealthYes.Web.UI.MVUserSpecializationService;
//using EUserShellModuleRole=HealthYes.Web.UI.MVUserSpecializationService.EUserShellModuleRole;

public partial class Franchisor_Masters_MVUserSpecialization : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active MVUserSpecialization from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Medical Vendor User Specialization";
        errordiv.InnerText = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("MVUserSpecialization");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortMVUserSpecialization"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchMVUserSpecialization(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetMVUserSpecialization();
            }

        }

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrmvusersspecializationelemclientid", "'" + grdMVUserSpecialization.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvusersspecializationelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvusersspecializationelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvusersspecializationelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvusersspecializationelemclientid", "'" + hfMVUserSpecializationID.ClientID + "'");

    }

    /// <summary>
    /// This method searches for the MVUserSpecialization by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchMVUserSpecialization(string searchtext)
    {
        //MVUserSpecializationService service = new MVUserSpecializationService();
        //HealthYes.Web.UI.MVUserSpecializationService.EMVUserSpecialization[] mvuserspecialization;
        //mvuserspecialization = service.GetMVUserSpecializationByName(searchtext);

        EMVUserSpecialization[] mvuserspecialization = null;

        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        // Mode '2' is used here to Fetch MV User specialisations acc. to a search text
        var listMVuserspecialization = medicalVendorDal.GetMVUserSpecialization(searchtext, 2);

        if (listMVuserspecialization != null) mvuserspecialization = listMVuserspecialization.ToArray();

        DataTable dtMVUserSpecialization = new DataTable();
        dtMVUserSpecialization.Columns.Add("MVUserSpecializationID", typeof(Int64));
        dtMVUserSpecialization.Columns.Add("name");
        dtMVUserSpecialization.Columns.Add("description");
        dtMVUserSpecialization.Columns.Add("Active");

        if (mvuserspecialization != null && mvuserspecialization.Length > 0)
        {
            for (int icount = 0; icount < mvuserspecialization.Length; icount++)
            {
                if (mvuserspecialization[icount].Active.ToString().Equals("True"))
                {
                    dtMVUserSpecialization.Rows.Add(new object[] { mvuserspecialization[icount].MVUserSpecilaizationID, mvuserspecialization[icount].Name, mvuserspecialization[icount].Description, "Active" });
                }
                else
                    dtMVUserSpecialization.Rows.Add(new object[] { mvuserspecialization[icount].MVUserSpecilaizationID, mvuserspecialization[icount].Name, mvuserspecialization[icount].Description, "Deactivated" });
            }
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
        if ((SortDirection)ViewState["SortMVUserSpecialization"] == SortDirection.Descending)
        {
            dtMVUserSpecialization.DefaultView.Sort = "name desc";
        }
        else
        {
            dtMVUserSpecialization.DefaultView.Sort = "name asc";
        }

        dtMVUserSpecialization = dtMVUserSpecialization.DefaultView.ToTable();

        grdMVUserSpecialization.DataSource = dtMVUserSpecialization;

        ViewState["DSGRID"] = dtMVUserSpecialization;

        grdMVUserSpecialization.DataBind();
        txtName.Text = "";
        txtDescription.Text = "";
        hfMVUserSpecializationID.Value = "";
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the MVUserSpecializations. 
    /// </summary>
    private void GetMVUserSpecialization()
    {
        //MVUserSpecializationService service = new MVUserSpecializationService();
        //HealthYes.Web.UI.MVUserSpecializationService.EMVUserSpecialization[] mvuserspecialization;
        //mvuserspecialization = service.GetAllMVUserSpecialization();
        
        EMVUserSpecialization[] mvuserspecialization = null;

        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        // Mode '0' is used here to Fetch ALL MV User specialisations.
        var listMVuserspecialization = medicalVendorDal.GetMVUserSpecialization(string.Empty, 0);

        if (listMVuserspecialization != null) mvuserspecialization = listMVuserspecialization.ToArray();
        
        DataTable dtMVUserSpecialization = new DataTable();
        dtMVUserSpecialization.Columns.Add("MVUserSpecializationID", typeof(Int64));
        dtMVUserSpecialization.Columns.Add("name");
        dtMVUserSpecialization.Columns.Add("description");
        dtMVUserSpecialization.Columns.Add("Active");

        if (mvuserspecialization != null && mvuserspecialization.Length > 0)
        {
            for (int icount = 0; icount < mvuserspecialization.Length; icount++)
            {
                if (mvuserspecialization[icount].Active.ToString().Equals("True"))
                {
                    dtMVUserSpecialization.Rows.Add(new object[] { mvuserspecialization[icount].MVUserSpecilaizationID, mvuserspecialization[icount].Name, mvuserspecialization[icount].Description, "Active" });
                }
                else
                    dtMVUserSpecialization.Rows.Add(new object[] { mvuserspecialization[icount].MVUserSpecilaizationID, mvuserspecialization[icount].Name, mvuserspecialization[icount].Description, "Deactivated" });
            }
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }

        if ((SortDirection)ViewState["SortMVUserSpecialization"] == SortDirection.Descending)
        {
            dtMVUserSpecialization.DefaultView.Sort = "name desc";
        }
        else
        {
            dtMVUserSpecialization.DefaultView.Sort = "name asc";
        }

        dtMVUserSpecialization = dtMVUserSpecialization.DefaultView.ToTable();

        grdMVUserSpecialization.DataSource = dtMVUserSpecialization;
        ViewState["DSGRID"] = dtMVUserSpecialization;

        grdMVUserSpecialization.DataBind();
        //grdCountry.Sort("name", SortDirection.Ascending);
        txtName.Text = "";
        txtDescription.Text = "";
        hfMVUserSpecializationID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the MVUserSpecialization which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateMVUserSpecialization()
    {
        EMVUserSpecialization mvuserspecialization = new EMVUserSpecialization();
        mvuserspecialization.Description = txtDescription.Text;
        mvuserspecialization.Name = txtName.Text;
        mvuserspecialization.Active = true;
        Int64 returnresult;
        
        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
            
        if (hfMVUserSpecializationID.Value.ToString().Equals(""))
        {
            returnresult = medicalVendorDal.SaveMVUserSpecialization(mvuserspecialization,
                                                                     Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }

        }
        else
        {
            mvuserspecialization.MVUserSpecilaizationID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdMVUserSpecialization.Rows[Convert.ToInt32(hfMVUserSpecializationID.Value)].DataItemIndex]["MVUserSpecializationID"]);

            returnresult = medicalVendorDal.SaveMVUserSpecialization(mvuserspecialization,
                                                                     Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }

        }
        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        errordiv.Visible = true;
        hfMVUserSpecializationID.Value = "";
        GetMVUserSpecialization();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateMVUserSpecialization 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateMVUserSpecialization();

        this.ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used to delete the selected MVUserSpecialization(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        string strSelectedMVUserSpecializationIDs = GetSelectedMVUserSpecializationIDs();

        
        if (strSelectedMVUserSpecializationIDs.Length > 0)
        {
            MedicalVendorDAL medicalvendorDAL = new MedicalVendorDAL();
            returnresult = medicalvendorDAL.SaveMVUserSpecialization(strSelectedMVUserSpecializationIDs,
                                                                     Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }
            GetMVUserSpecialization();
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfMVUserSpecializationID.Value = "";
        }
    }

    /// <summary>
    /// Gets the selected MV user specialization I ds.
    /// </summary>
    /// <returns></returns>
    private string GetSelectedMVUserSpecializationIDs()
    {
        string strSelectedMVUserSpecializationIDs = "";

        for (int i = 0; i < grdMVUserSpecialization.Rows.Count; i++)
        {
            HtmlInputCheckBox chkMVUserSpecializationSelecter = (HtmlInputCheckBox)grdMVUserSpecialization.Rows[i].FindControl("chkRowChild");
            if (chkMVUserSpecializationSelecter.Checked == true)
            {
                strSelectedMVUserSpecializationIDs +=
                    Convert.ToInt32(
                        ((DataTable) (ViewState["DSGRID"])).Rows[grdMVUserSpecialization.Rows[i].DataItemIndex][
                            "MVUserSpecializationID"]) + ", ";
            }
        }

        if (strSelectedMVUserSpecializationIDs.Length > 0)
            strSelectedMVUserSpecializationIDs = strSelectedMVUserSpecializationIDs.Remove(strSelectedMVUserSpecializationIDs.LastIndexOf(", "));


        return strSelectedMVUserSpecializationIDs;
    }

    /// <summary>
    /// this method is used for deactivating the selected MVUserSpecialization(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

       string strSelectedMVUserSpecializationIDs = GetSelectedMVUserSpecializationIDs();

        if (strSelectedMVUserSpecializationIDs.Length > 0)
        {
            MedicalVendorDAL medicalvendorDAL = new MedicalVendorDAL();
            returnresult = medicalvendorDAL.SaveMVUserSpecialization(strSelectedMVUserSpecializationIDs,
                                                                     Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfMVUserSpecializationID.Value = "";
            GetMVUserSpecialization();
        }
    }

    /// <summary>
    /// this method is used for activating the selected MVUserSpecialization(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        string strSelectedMVUserSpecializationIDs = GetSelectedMVUserSpecializationIDs();

        
        if (strSelectedMVUserSpecializationIDs.Length > 0)
        {
            MedicalVendorDAL medicalvendorDAL = new MedicalVendorDAL();
            returnresult = medicalvendorDAL.SaveMVUserSpecialization(strSelectedMVUserSpecializationIDs,
                                                                     Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfMVUserSpecializationID.Value = "";
            GetMVUserSpecialization();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMVUserSpecialization_RowDataBound(object sender, GridViewRowEventArgs e)
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
            LinkButton lnkBtnMVUserSpc = (LinkButton)e.Row.FindControl("lnkBtnMVUserSpc");
            lnkBtnMVUserSpc.OnClientClick = "return EditMVUser('" + lnkBtnMVUserSpc.ClientID + "')";
        }
    }

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMVUserSpecialization_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdMVUserSpecialization.PageIndex = e.NewPageIndex;
        grdMVUserSpecialization.DataSource = (DataTable)ViewState["DSGRID"];
        grdMVUserSpecialization.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit MV Specialization";
        this.ModalPopupExtender.Show();
    }

    /// <summary>
    /// this method is used to close the modular popup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMVUserSpecialization_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtmvuserspecialization = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortMVUserSpecialization"] == SortDirection.Descending)
        {
            dtmvuserspecialization.DefaultView.Sort = "name asc";
            ViewState["SortMVUserSpecialization"] = SortDirection.Ascending;
        }
        else
        {
            dtmvuserspecialization.DefaultView.Sort = "name desc";
            ViewState["SortMVUserSpecialization"] = SortDirection.Descending;
        }
        dtmvuserspecialization = dtmvuserspecialization.DefaultView.ToTable();

        grdMVUserSpecialization.DataSource = dtmvuserspecialization;
        ViewState["DSGRID"] = dtmvuserspecialization;

        grdMVUserSpecialization.DataBind();
    }
}
