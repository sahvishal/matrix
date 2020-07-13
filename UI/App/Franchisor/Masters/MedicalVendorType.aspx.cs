using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.MedicalVendor;
using Falcon.Entity.MedicalVendor;
using Falcon.App.Core.Enum;

//using HealthYes.Web.UI.MedicalVendorTypeService;

public partial class Franchisor_Masters_MedicalVendorType : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active medicalvendortype from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "MedicalVendorType";
        errordiv.InnerText = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Medical Vendor Type");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortDir"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchMedicalVendorType(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetMedicalVendorType();
            }
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrjsmedvendorelems", "'" + grdMedicalVendorType.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsmedvendorelems", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsmedvendorelems", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsmedvendorelems", "'" + hfMedicalVendorTypeID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsmedvendorelems", "'" + btnEdit.ClientID + "'");

    }

    /// <summary>
    /// This method searches for the medicalvendortype by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchMedicalVendorType(string searchtext)
    {
        //MedicalVendorTypeService service = new MedicalVendorTypeService();
        //HealthYes.Web.UI.MedicalVendorTypeService.EMedicalVendorType[] medicalvendortype;
        //medicalvendortype = service.GetMedicalVendorTypeByName(searchtext);

        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        // Mode '2' used for Fetching MedicalVendor Type records acc. to search Text.
        var listMedicalVendorType = medicalVendorDal.GetMedicalVendorType(searchtext, 2);

        EMedicalVendorType[] medicalvendortype = null;
        if (listMedicalVendorType != null) medicalvendortype = listMedicalVendorType.ToArray();

        DataTable dtMedicalVendorType = new DataTable();
        dtMedicalVendorType.Columns.Add("MedicalVendorTypeID");
        dtMedicalVendorType.Columns.Add("name");
        dtMedicalVendorType.Columns.Add("description");
        dtMedicalVendorType.Columns.Add("active");

        if (medicalvendortype != null && medicalvendortype.Length > 0)
        {
            for (int icount = 0; icount < medicalvendortype.Length; icount++)
            {
                if (medicalvendortype[icount].Active.ToString().Equals("True"))
                {
                    dtMedicalVendorType.Rows.Add(new object[] { medicalvendortype[icount].MedicalVendorTypeID, medicalvendortype[icount].Name, medicalvendortype[icount].Description, "Active" });
                }
                else
                    dtMedicalVendorType.Rows.Add(new object[] { medicalvendortype[icount].MedicalVendorTypeID, medicalvendortype[icount].Name, medicalvendortype[icount].Description, "Deactivated" });
            }
            divErrorMsg.Visible = false;
        }
        else
        {
            divErrorMsg.InnerText = "No Records Found";
            divErrorMsg.Visible = true;
        }

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtMedicalVendorType.DefaultView.Sort = "name asc";
        }
        else
        {
            dtMedicalVendorType.DefaultView.Sort = "name desc";
        }
        dtMedicalVendorType = dtMedicalVendorType.DefaultView.ToTable();

        grdMedicalVendorType.DataSource = dtMedicalVendorType;
        ViewState["DSGRID"] = dtMedicalVendorType;
        grdMedicalVendorType.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";
        hfMedicalVendorTypeID.Value = "";
        
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the medicalvendortypes. 
    /// </summary>
    private void GetMedicalVendorType()
    {
        //MedicalVendorTypeService service = new MedicalVendorTypeService();
        //HealthYes.Web.UI.MedicalVendorTypeService.EMedicalVendorType[] medicalvendortype;
        //medicalvendortype = service.GetAllMedicalVendorTypes();

        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        // Mode '0' used for Fetching All MedicalVendor Type records.
        var listMedicalVendorType = medicalVendorDal.GetMedicalVendorType(string.Empty, 0);

        EMedicalVendorType[] medicalvendortype = null;
        if (listMedicalVendorType != null) medicalvendortype = listMedicalVendorType.ToArray();

        DataTable dtMedicalVendorType = new DataTable();
        dtMedicalVendorType.Columns.Add("MedicalVendorTypeID");
        dtMedicalVendorType.Columns.Add("name");
        dtMedicalVendorType.Columns.Add("description");
        dtMedicalVendorType.Columns.Add("active");

        if (medicalvendortype != null && medicalvendortype.Length>0)
        {
            for (int icount = 0; icount < medicalvendortype.Length; icount++)
            {
                if (medicalvendortype[icount].Active.ToString().Equals("True"))
                {
                    dtMedicalVendorType.Rows.Add(new object[] { medicalvendortype[icount].MedicalVendorTypeID, medicalvendortype[icount].Name, medicalvendortype[icount].Description, "Active" });
                }
                else
                    dtMedicalVendorType.Rows.Add(new object[] { medicalvendortype[icount].MedicalVendorTypeID, medicalvendortype[icount].Name, medicalvendortype[icount].Description, "Deactivated" });
            }
            divErrorMsg.Visible = false;
        }
        else
        {
            divErrorMsg.InnerText = "No Records Found";
            divErrorMsg.Visible = true;
        }

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtMedicalVendorType.DefaultView.Sort = "name asc";
        }
        else
        {
            dtMedicalVendorType.DefaultView.Sort = "name desc";
        }
        dtMedicalVendorType = dtMedicalVendorType.DefaultView.ToTable();

        grdMedicalVendorType.DataSource = dtMedicalVendorType;
        ViewState["DSGRID"] = dtMedicalVendorType;
        grdMedicalVendorType.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";
        hfMedicalVendorTypeID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the MVType which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateMedicalVendorType()
    {
        //MedicalVendorTypeService service = new MedicalVendorTypeService();
        //HealthYes.Web.UI.MedicalVendorTypeService.EMedicalVendorType medicalvendortype = new HealthYes.Web.UI.MedicalVendorTypeService.EMedicalVendorType();

        EMedicalVendorType medicalvendortype = new EMedicalVendorType();

        medicalvendortype.Description = txtDescription.Text;
        medicalvendortype.Name = txtName.Text;

        medicalvendortype.Active = true;
        Int64 returnresult;

        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();

        if (hfMedicalVendorTypeID.Value.ToString().Equals(""))
        {
            returnresult = medicalVendorDal.SaveMedicalVendorType(medicalvendortype, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }

        }
        else
        {
            medicalvendortype.MedicalVendorTypeID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdMedicalVendorType.Rows[Convert.ToInt32(hfMedicalVendorTypeID.Value)].DataItemIndex]["MedicalVendorTypeID"]);

            returnresult = medicalVendorDal.SaveMedicalVendorType(medicalvendortype, Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }
        }
        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        hfMedicalVendorTypeID.Value = "";
        GetMedicalVendorType();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateMedicalVendorType 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateMedicalVendorType();
    }

    /// <summary>
    /// this method is used to delete the selected MedicalVendorType(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;


        string strSelectedMedicalVendorTypeIDs = GetSelectedMedicalVendorTypeIDs();

        if (strSelectedMedicalVendorTypeIDs.Length > 0)
        {
            MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
            returnresult = medicalVendorDal.SaveMedicalVendorType(strSelectedMedicalVendorTypeIDs,
                                                                  Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }
            GetMedicalVendorType();
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfMedicalVendorTypeID.Value = "";
        }
    }

    private string GetSelectedMedicalVendorTypeIDs()
    {
        string strSelectedMedicalVendorTypes = "";

        for (int i = 0; i < grdMedicalVendorType.Rows.Count; i++)
        {
            //HtmlInputCheckBox chkMedicalVendorTypeSelecter = new HtmlInputCheckBox();
            HtmlInputCheckBox chkMedicalVendorTypeSelecter = (HtmlInputCheckBox)grdMedicalVendorType.Rows[i].FindControl("chkRowChild");
            if (chkMedicalVendorTypeSelecter.Checked == true)
            {
                strSelectedMedicalVendorTypes +=
                    Convert.ToInt32(
                        ((DataTable) (ViewState["DSGRID"])).Rows[grdMedicalVendorType.Rows[i].DataItemIndex][
                            "MedicalVendorTypeID"]) + ", ";
            }
        }

        if (strSelectedMedicalVendorTypes.Length > 0)
            strSelectedMedicalVendorTypes =
                strSelectedMedicalVendorTypes.Remove(strSelectedMedicalVendorTypes.LastIndexOf(", "));

        return strSelectedMedicalVendorTypes;
    }

    /// <summary>
    /// this method is used for deactivating the selected MedicalVendorType(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        string strSelectedMedicalVendorTypeIDs = GetSelectedMedicalVendorTypeIDs();

        if (strSelectedMedicalVendorTypeIDs.Length > 0)
        {
            MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();

            returnresult = medicalVendorDal.SaveMedicalVendorType(strSelectedMedicalVendorTypeIDs, Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfMedicalVendorTypeID.Value = "";
            GetMedicalVendorType();
        }
    }

    /// <summary>
    /// this method is used for activating the selected MedicalVendorType(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        

        string strSelectedMedicalVendorTypeIDs = GetSelectedMedicalVendorTypeIDs();

        if (strSelectedMedicalVendorTypeIDs.Length > 0)
        {
            MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();

            returnresult = medicalVendorDal.SaveMedicalVendorType(strSelectedMedicalVendorTypeIDs, Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfMedicalVendorTypeID.Value = "";
            GetMedicalVendorType();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMedicalVendorType_RowDataBound(object sender, GridViewRowEventArgs e)
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


            LinkButton lnkbtnmedicaltype = (LinkButton)e.Row.FindControl("lnkbtnmedicaltype");
            lnkbtnmedicaltype.OnClientClick = "return EditMedical('" + lnkbtnmedicaltype.ClientID + "')";
        }
    }

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMedicalVendorType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdMedicalVendorType.PageIndex = e.NewPageIndex;
        grdMedicalVendorType.DataSource = (DataTable)ViewState["DSGRID"];
        grdMedicalVendorType.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit Medical Vendor Type";
        ModalPopupExtender.Show();
    }

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMedicalVendorType_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtmedicalvendortype = (DataTable)ViewState["DSGRID"];

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtmedicalvendortype.DefaultView.Sort = "name desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        else
        {
            dtmedicalvendortype.DefaultView.Sort = "name asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        dtmedicalvendortype = dtmedicalvendortype.DefaultView.ToTable();

        grdMedicalVendorType.DataSource = dtmedicalvendortype;
        grdMedicalVendorType.DataBind();

        ViewState["DSGRID"] = dtmedicalvendortype;

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

}
