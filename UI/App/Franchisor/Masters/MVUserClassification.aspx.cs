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
//using HealthYes.Web.UI.MVUserClassificationService;
//using EUserShellModuleRole=HealthYes.Web.UI.MVUserClassificationService.EUserShellModuleRole;

public partial class Franchisor_Masters_MVUserClassification : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active MVUserClassification from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Medical Vendor User Classification";
        errordiv.InnerText = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("MVUserClassification");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortMVUserClassification"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchMVUserClassification(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetMVUserClassification();
            }

        }

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrmvuserclassificationelemclientid", "'" + grdMVUserClassification.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvuserclassificationelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvuserclassificationelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvuserclassificationelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrmvuserclassificationelemclientid", "'" + hfMVUserClassificationID.ClientID + "'");

    }

    /// <summary>
    /// This method searches for the MVUserClassification by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchMVUserClassification(string searchtext)
    {
        //MVUserClassificationService service = new MVUserClassificationService();
        //HealthYes.Web.UI.MVUserClassificationService.EMVUserClassification[] mvuserclassification;
        //mvuserclassification = service.GetMVUserClassificationByName(searchtext);

        EMVUserClassification[] mvuserclassification = null;
        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        // Mode 2 is used here for fetching Classifications Acc. to the Search text
        var listMVClassification = medicalVendorDal.GetMVUserClassification(searchtext, 2);

        if (listMVClassification != null) mvuserclassification = listMVClassification.ToArray();

        DataTable dtMVUserClassification = new DataTable();
        dtMVUserClassification.Columns.Add("MVUserClassificationID", typeof(Int64));
        dtMVUserClassification.Columns.Add("name");
        dtMVUserClassification.Columns.Add("description");
        dtMVUserClassification.Columns.Add("Active");

        if (mvuserclassification != null && mvuserclassification.Length > 0)
        {
            for (int icount = 0; icount < mvuserclassification.Length; icount++)
            {
                if (mvuserclassification[icount].Active.ToString().Equals("True"))
                {
                    dtMVUserClassification.Rows.Add(new object[] { mvuserclassification[icount].MVUserClassificationID, mvuserclassification[icount].Name, mvuserclassification[icount].Description, "Active" });
                }
                else
                    dtMVUserClassification.Rows.Add(new object[] { mvuserclassification[icount].MVUserClassificationID, mvuserclassification[icount].Name, mvuserclassification[icount].Description, "Deactivated" });
            }
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
        if ((SortDirection)ViewState["SortMVUserClassification"] == SortDirection.Descending)
        {
            dtMVUserClassification.DefaultView.Sort = "name desc";
        }
        else
        {
            dtMVUserClassification.DefaultView.Sort = "name asc";
        }

        dtMVUserClassification = dtMVUserClassification.DefaultView.ToTable();

        grdMVUserClassification.DataSource = dtMVUserClassification;

        ViewState["DSGRID"] = dtMVUserClassification;

        grdMVUserClassification.DataBind();
        txtName.Text = "";
        txtDescription.Text = "";
        hfMVUserClassificationID.Value = "";
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the MVUserClassifications. 
    /// </summary>
    private void GetMVUserClassification()
    {
        //MVUserClassificationService service = new MVUserClassificationService();
        //HealthYes.Web.UI.MVUserClassificationService.EMVUserClassification[] mvuserclassification;
        //mvuserclassification = service.GetAllMVUserClassification();


        EMVUserClassification[] mvuserclassification = null;
        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        // Mode '0' is used here for fetching All Classifications 
        var listMVClassification = medicalVendorDal.GetMVUserClassification(string.Empty, 0);

        if (listMVClassification != null) mvuserclassification = listMVClassification.ToArray();


        DataTable dtMVUserClassification = new DataTable();
        dtMVUserClassification.Columns.Add("MVUserClassificationID", typeof(Int64));
        dtMVUserClassification.Columns.Add("name");
        dtMVUserClassification.Columns.Add("description");
        dtMVUserClassification.Columns.Add("Active");

        if (mvuserclassification != null && mvuserclassification.Length > 0)
        {
            for (int icount = 0; icount < mvuserclassification.Length; icount++)
            {
                if (mvuserclassification[icount].Active.ToString().Equals("True"))
                {
                    dtMVUserClassification.Rows.Add(new object[] { mvuserclassification[icount].MVUserClassificationID, mvuserclassification[icount].Name, mvuserclassification[icount].Description, "Active" });
                }
                else
                    dtMVUserClassification.Rows.Add(new object[] { mvuserclassification[icount].MVUserClassificationID, mvuserclassification[icount].Name, mvuserclassification[icount].Description, "Deactivated" });
            }
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }

        if ((SortDirection)ViewState["SortMVUserClassification"] == SortDirection.Descending)
        {
            dtMVUserClassification.DefaultView.Sort = "name desc";
        }
        else
        {
            dtMVUserClassification.DefaultView.Sort = "name asc";
        }

        dtMVUserClassification = dtMVUserClassification.DefaultView.ToTable();

        grdMVUserClassification.DataSource = dtMVUserClassification;
        ViewState["DSGRID"] = dtMVUserClassification;

        grdMVUserClassification.DataBind();
        //grdCountry.Sort("name", SortDirection.Ascending);
        txtName.Text = "";
        txtDescription.Text = "";
        hfMVUserClassificationID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the MVUserClassification which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateMVUserClassification()
    {

        EMVUserClassification mvuserclassification = new EMVUserClassification();

        mvuserclassification.Description = txtDescription.Text;
        mvuserclassification.Name = txtName.Text;

        mvuserclassification.Active = true;
        Int64 returnresult;
        
        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();

        if (hfMVUserClassificationID.Value.ToString().Equals(""))
        {
            returnresult = medicalVendorDal.SaveMVUserClassification(mvuserclassification,
                                                                     Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }

        }
        else
        {
            mvuserclassification.MVUserClassificationID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdMVUserClassification.Rows[Convert.ToInt32(hfMVUserClassificationID.Value)].DataItemIndex]["MVUserClassificationID"]);

            returnresult = medicalVendorDal.SaveMVUserClassification(mvuserclassification,
                                                                     Convert.ToInt32(EOperationMode.Update));

            if (returnresult == 0)
            {
                returnresult = 9999991;
            }
        }

        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        errordiv.Visible = true;
        hfMVUserClassificationID.Value = "";
        GetMVUserClassification();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateMVUserClassification 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateMVUserClassification();

        this.ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used to delete the selected MVUserClassification(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        string strSelectedMVUserclassificationIDs = GetSelectedMVUserClassification();


        if (strSelectedMVUserclassificationIDs.Length > 0)
        {
            MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
            returnresult = medicalVendorDal.SaveMVUserClassification(strSelectedMVUserclassificationIDs,
                                                                     Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }

            GetMVUserClassification();
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfMVUserClassificationID.Value = "";
        }
    }

    /// <summary>
    /// Gets the selected MV user classification.
    /// </summary>
    /// <returns></returns>
    private string GetSelectedMVUserClassification()
    {
        string strSelectedMVuserClassifications = "";

        for (int i = 0; i < grdMVUserClassification.Rows.Count; i++)
        {
            //HtmlInputCheckBox chkMVUserClassificationSelecter = new HtmlInputCheckBox();
            HtmlInputCheckBox chkMvUserClassificationSelecter = (HtmlInputCheckBox)grdMVUserClassification.Rows[i].FindControl("chkRowChild");
            if (chkMvUserClassificationSelecter.Checked == true)
            {
                //grdCountry.Rows[i].RowState = DataControlRowState.Selected;
                //HealthYes.Web.UI.MVUserClassificationService.EMVUserClassification mvuserclassification = new HealthYes.Web.UI.MVUserClassificationService.EMVUserClassification();
                //country.CountryID = Convert.ToInt32(grdCountry.DataKeys[grdCountry.PageSize * (grdCountry.PageIndex) + i].Value);
                strSelectedMVuserClassifications +=
                    Convert.ToInt32(
                        ((DataTable)(ViewState["DSGRID"])).Rows[grdMVUserClassification.Rows[i].DataItemIndex][
                            "MVUserClassificationID"]) + ", ";
                //ListMVUserClassification.Add(mvuserclassification);
            }
        }

        if (strSelectedMVuserClassifications.Length > 0)
            strSelectedMVuserClassifications = strSelectedMVuserClassifications.Remove(strSelectedMVuserClassifications.LastIndexOf(", "));

        return strSelectedMVuserClassifications;
    }

    /// <summary>
    /// this method is used for deactivating the selected MVUserClassification(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        string strSelectedMVUserclassificationIDs = GetSelectedMVUserClassification();

        

        //if (MVUserClassifications.Length > 0)
        if (strSelectedMVUserclassificationIDs.Length > 0)
        {
            MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();

            returnresult = medicalVendorDal.SaveMVUserClassification(strSelectedMVUserclassificationIDs,
                                                                     Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfMVUserClassificationID.Value = "";
            GetMVUserClassification();
        }
    }

    /// <summary>
    /// this method is used for activating the selected MVUserClassification(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        
        string strSelectedMVUserclassificationIDs = GetSelectedMVUserClassification();

        
        if (strSelectedMVUserclassificationIDs.Length > 0)
        {
            var medicalVendorDal = new MedicalVendorDAL();
            returnresult = medicalVendorDal.SaveMVUserClassification(strSelectedMVUserclassificationIDs,
                                                                     Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfMVUserClassificationID.Value = "";
            GetMVUserClassification();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMVUserClassification_RowDataBound(object sender, GridViewRowEventArgs e)
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

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMVUserClassification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdMVUserClassification.PageIndex = e.NewPageIndex;
        grdMVUserClassification.DataSource = (DataTable)ViewState["DSGRID"];
        grdMVUserClassification.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit MV Classification";
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
    protected void grdMVUserClassification_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtmvuserclassification = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortMVUserClassification"] == SortDirection.Descending)
        {
            dtmvuserclassification.DefaultView.Sort = "name asc";
            ViewState["SortMVUserClassification"] = SortDirection.Ascending;
        }
        else
        {
            dtmvuserclassification.DefaultView.Sort = "name desc";
            ViewState["SortMVUserClassification"] = SortDirection.Descending;
        }
        dtmvuserclassification = dtmvuserclassification.DefaultView.ToTable();

        grdMVUserClassification.DataSource = dtmvuserclassification;
        ViewState["DSGRID"] = dtmvuserclassification;

        grdMVUserClassification.DataBind();
    }
}
