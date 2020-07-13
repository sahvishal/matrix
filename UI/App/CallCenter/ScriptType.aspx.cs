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
//using HealthYes.Web.UI.CallCenterService;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;

public partial class CallCenter_ScriptType : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active scripttype from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Page.Title = "ScriptType";
        errordiv.InnerHtml = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("ScriptType");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortScriptType"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchScriptType(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetScriptType();
            }

        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + grdScriptType.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + hfScriptTypeID.ClientID + "'");

    }

    /// <summary>
    /// This method searches for the scripttype by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchScriptType(string searchtext)
    {
        CallCenterDAL callCenterDal = new CallCenterDAL();
        var scripttype = callCenterDal.GetScriptType(searchtext, 2);

        DataTable dtScriptType = new DataTable();
        dtScriptType.Columns.Add("ScriptTypeID", typeof(Int64));
        dtScriptType.Columns.Add("name");
        dtScriptType.Columns.Add("description");
        dtScriptType.Columns.Add("Active");

        if (scripttype != null && scripttype.Count > 0)
        {
            for (int icount = 0; icount < scripttype.Count; icount++)
            {
                if (scripttype[icount].Active.ToString().Equals("True"))
                {
                    dtScriptType.Rows.Add(new object[] { scripttype[icount].ScriptTypeID, scripttype[icount].ScriptName, scripttype[icount].Description, "Active" });
                }
                else
                    dtScriptType.Rows.Add(new object[] { scripttype[icount].ScriptTypeID, scripttype[icount].ScriptName, scripttype[icount].Description, "Deactivated" });
            }
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
        if ((SortDirection)ViewState["SortScriptType"] == SortDirection.Descending)
        {
            dtScriptType.DefaultView.Sort = "name desc";
        }
        else
        {
            dtScriptType.DefaultView.Sort = "name asc";
        }

        dtScriptType = dtScriptType.DefaultView.ToTable();

        grdScriptType.DataSource = dtScriptType;

        ViewState["DSGRID"] = dtScriptType;

        grdScriptType.DataBind();
        txtName.Text = "";
        txtDescription.Text = "";
        hfScriptTypeID.Value = "";
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the scripttypes. 
    /// </summary>
    private void GetScriptType()
    {
        CallCenterDAL callCenterDal = new CallCenterDAL();
        var scripttype = callCenterDal.GetScriptType(string.Empty, 0);

        DataTable dtScriptType = new DataTable();
        dtScriptType.Columns.Add("ScriptTypeID", typeof(Int64));
        dtScriptType.Columns.Add("name");
        dtScriptType.Columns.Add("description");
        dtScriptType.Columns.Add("Active");

        if (scripttype != null && scripttype.Count > 0)
        {
            for (int icount = 0; icount < scripttype.Count; icount++)
            {
                if (scripttype[icount].Active.ToString().Equals("True"))
                {
                    dtScriptType.Rows.Add(new object[] { scripttype[icount].ScriptTypeID, scripttype[icount].ScriptName, scripttype[icount].Description, "Active" });
                }
                else
                    dtScriptType.Rows.Add(new object[] { scripttype[icount].ScriptTypeID, scripttype[icount].ScriptName, scripttype[icount].Description, "Deactivated" });
            }
            
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
        if ((SortDirection)ViewState["SortScriptType"] == SortDirection.Descending)
        {
            dtScriptType.DefaultView.Sort = "name desc";
        }
        else
        {
            dtScriptType.DefaultView.Sort = "name asc";
        }

        dtScriptType = dtScriptType.DefaultView.ToTable();

        grdScriptType.DataSource = dtScriptType;
        ViewState["DSGRID"] = dtScriptType;

        grdScriptType.DataBind();
        txtName.Text = "";
        txtDescription.Text = "";
        hfScriptTypeID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the scripttype which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateScriptType()
    {

        EScriptType scripttype = new EScriptType();
        scripttype.Description = txtDescription.Text;
        scripttype.ScriptName = txtName.Text;

        scripttype.Active = true;
        Int64 returnresult;

        CallCenterDAL callCenterDal = new CallCenterDAL();
        if (hfScriptTypeID.Value.Equals(""))
        {
            returnresult = callCenterDal.SaveScriptType(scripttype, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }

        }
        else
        {
            scripttype.ScriptTypeID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdScriptType.Rows[Convert.ToInt32(hfScriptTypeID.Value)].DataItemIndex]["ScriptTypeID"]);
            returnresult = callCenterDal.SaveScriptType(scripttype, Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }

        }
        errordiv.Visible = true;
        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());        
        hfScriptTypeID.Value = "";
        GetScriptType();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateScriptType 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateScriptType();

        this.ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used to delete the selected scripttype(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedScriptTypeIDs = GetSelectedScriptTypeIDs();
        

        if (strSelectedScriptTypeIDs.Length > 0)
        {
            CallCenterDAL callCenterDal = new CallCenterDAL();
            Int64 returnresult = callCenterDal.SaveScriptType(strSelectedScriptTypeIDs,
                                                          Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }

            GetScriptType();
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfScriptTypeID.Value = "";
        }
    }

    /// this method is to get list of selected scripttype(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    private string GetSelectedScriptTypeIDs()
    {
        string strSelectedScriptTypeIDs = "";

        for (int i = 0; i < grdScriptType.Rows.Count; i++)
        {
            HtmlInputCheckBox chkScriptTypeSelecter = (HtmlInputCheckBox)grdScriptType.Rows[i].FindControl("chkRowChild");
            if (chkScriptTypeSelecter.Checked == true)
            {
                strSelectedScriptTypeIDs += Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdScriptType.Rows[i].DataItemIndex]["ScriptTypeID"]) + ", ";
            }
        }

        if (strSelectedScriptTypeIDs.Length > 0)
            strSelectedScriptTypeIDs = strSelectedScriptTypeIDs.Remove(strSelectedScriptTypeIDs.LastIndexOf(", "));

        return strSelectedScriptTypeIDs;
    }

    /// <summary>
    /// this method is used for deactivating the selected ScriptType(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedScriptTypeIDs = GetSelectedScriptTypeIDs();


        if (strSelectedScriptTypeIDs.Length > 0)
        {
            CallCenterDAL callCenterDal = new CallCenterDAL();
            Int64 returnresult = callCenterDal.SaveScriptType(strSelectedScriptTypeIDs,
                                                          Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }

            //service.DeactivateScriptType(ScriptTypes, usershellmodulerole1, out returnresult, out temp);

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfScriptTypeID.Value = "";
            GetScriptType();
        }
    }

    /// <summary>
    /// this method is used for activating the selected ScriptType(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedScriptTypeIDs = GetSelectedScriptTypeIDs();

        if (strSelectedScriptTypeIDs.Length > 0)
        {
            CallCenterDAL callCenterDal = new CallCenterDAL();
            Int64 returnresult = callCenterDal.SaveScriptType(strSelectedScriptTypeIDs,
                                                          Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }
            
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfScriptTypeID.Value = "";
            GetScriptType();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdScriptType_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void grdScriptType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdScriptType.PageIndex = e.NewPageIndex;
        grdScriptType.DataSource = (DataTable)ViewState["DSGRID"];
        grdScriptType.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit Script Type";
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
    protected void grdScriptType_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtScriptType = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortScriptType"] == SortDirection.Descending)
        {
            dtScriptType.DefaultView.Sort = "name asc";
            ViewState["SortScriptType"] = SortDirection.Ascending;
        }
        else
        {
            dtScriptType.DefaultView.Sort = "name desc";
            ViewState["SortScriptType"] = SortDirection.Descending;
        }
        dtScriptType = dtScriptType.DefaultView.ToTable();

        grdScriptType.DataSource = dtScriptType;
        ViewState["DSGRID"] = dtScriptType;

        grdScriptType.DataBind();
    }
}
