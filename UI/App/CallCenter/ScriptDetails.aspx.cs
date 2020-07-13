using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Enum;
using System.Collections.Generic;

public partial class CallCenter_ScriptDetails : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active script from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Script";
        errordiv.InnerText = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Script");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {

            CallCenterDAL callCenterDal = new CallCenterDAL();
            List<EScriptType> scriptTypes = callCenterDal.GetScriptType(string.Empty, 3);
            List<EScript> scripts = callCenterDal.GetScript(string.Empty, 3);

            if (scriptTypes.Count > 0)
            {
                ddlscripttype.Items.Add(new ListItem("Select Script Type", "0"));
                for (int count = 0; count < scriptTypes.Count; count++)
                {
                    ddlscripttype.Items.Add(new ListItem(scriptTypes[count].ScriptName, scriptTypes[count].ScriptTypeID.ToString()));
                }
            }
            else
            {
                ddlscripttype.Items.Add("Select");
            }

            ViewState["SortDir"] = SortDirection.Ascending;
            ViewState["SortExp"] = "name";
            if (Request.QueryString["searchtext"] != null)
            {
                SearchScript(Request.QueryString["searchtext"]);
            }
            else
            {
                GetScript();
            }
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + grdScript.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + ddlscripttype.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + hfScriptID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + chkIsDefault.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrscriptelemclientid", "'" + txtScriptText.ClientID + "'");
    }

    /// <summary>
    /// This method searches for the script by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchScript(string searchtext)
    {
        var callCenterDal = new CallCenterDAL();
        List<EScript> scripts = callCenterDal.GetScript(searchtext, 2);

        var dtScript = new DataTable();
        dtScript.Columns.Add("ScriptID", typeof(int));
        dtScript.Columns.Add("name");
        dtScript.Columns.Add("description");
        dtScript.Columns.Add("type");
        dtScript.Columns.Add("scripttext");
        dtScript.Columns.Add("default");
        dtScript.Columns.Add("active");

        if (scripts != null && scripts.Count > 0)
        {
            for (int icount = 0; icount < scripts.Count; icount++)
            {
                if (scripts[icount].Active.ToString().Equals("True"))
                {
                    dtScript.Rows.Add(new object[] { scripts[icount].ScriptID, scripts[icount].Name, scripts[icount].Description, scripts[icount].ScriptType.ScriptName, scripts[icount].ScriptText, scripts[icount].Default, "Active" });
                }
                else
                    dtScript.Rows.Add(new object[] { scripts[icount].ScriptID, scripts[icount].Name, scripts[icount].Description, scripts[icount].ScriptType.ScriptName, scripts[icount].ScriptText, scripts[icount].Default, "Deactivated" });
            }
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtScript.DefaultView.Sort = ViewState["SortExp"] + " asc";
        }
        else
        {
            dtScript.DefaultView.Sort = ViewState["SortExp"] + " desc";
        }

        grdScript.DataSource = dtScript;
        grdScript.DataBind();
        ViewState["DSGRID"] = dtScript;

        txtName.Text = "";
        txtDescription.Text = "";
        ddlscripttype.SelectedIndex = 0;
        hfScriptID.Value = "";

    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the scripts. 
    /// </summary>
    private void GetScript()
    {
        var callCenterDal = new CallCenterDAL();
        List<EScript> scripts = callCenterDal.GetScript(string.Empty, 0);

        var dtScript = new DataTable();
        dtScript.Columns.Add("ScriptID", typeof(int));
        dtScript.Columns.Add("name");
        dtScript.Columns.Add("description");
        dtScript.Columns.Add("type");
        dtScript.Columns.Add("scripttext");
        dtScript.Columns.Add("default");
        dtScript.Columns.Add("active");

        if (scripts != null && scripts.Count > 0)
        {
            for (int icount = 0; icount < scripts.Count; icount++)
            {
                if (scripts[icount].Active.ToString().Equals("True"))
                {
                    dtScript.Rows.Add(new object[] { scripts[icount].ScriptID, scripts[icount].Name, scripts[icount].Description, scripts[icount].ScriptType.ScriptName, scripts[icount].ScriptText, scripts[icount].Default, "Active" });
                }
                else
                    dtScript.Rows.Add(new object[] { scripts[icount].ScriptID, scripts[icount].Name, scripts[icount].Description, scripts[icount].ScriptType.ScriptName,scripts[icount].ScriptText, scripts[icount].Default, "Deactivated" });
            }
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtScript.DefaultView.Sort = ViewState["SortExp"] + " asc";
        }
        else
        {
            dtScript.DefaultView.Sort = ViewState["SortExp"] + " desc";
        }


        dtScript = dtScript.DefaultView.ToTable();

        grdScript.DataSource = dtScript;
        grdScript.DataBind();
        ViewState["DSGRID"] = dtScript;

        txtName.Text = "";
        txtDescription.Text = "";
        ddlscripttype.SelectedIndex = 0;
        hfScriptID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the script which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateScript()
    {

        var script = new EScript();
        script.Description = txtDescription.Text;
        script.Name = txtName.Text;
        script.Active = true;
        script.Default = chkIsDefault.Checked;
        script.ScriptText = Server.HtmlDecode(txtScriptText.Text);
        var scripttype = new EScriptType();
        scripttype.ScriptTypeID = Convert.ToInt32(ddlscripttype.SelectedValue);

        script.ScriptType = scripttype;
        Int64 returnresult;

        var callCenterDal = new CallCenterDAL();

        if (hfScriptID.Value.Equals(""))
        {
            returnresult = callCenterDal.SaveScript(script, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }
        }
        else
        {
            script.ScriptID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdScript.Rows[Convert.ToInt32(hfScriptID.Value)].DataItemIndex]["ScriptID"]);
            returnresult = callCenterDal.SaveScript(script, Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }
        }
        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        errordiv.Visible = true;
        hfScriptID.Value = "";
        GetScript();
    }

    /// <summary>
    /// this method is called on save button click which calls UpdateScript
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateScript();
    }

    /// <summary>
    /// this method is used to delete the selected script(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        //CallCenterService.
        EScript[] Scripts = GetSelectedScript();

        if (Scripts.Length > 0)
        {
            var callCenterDal = new CallCenterDAL();

            var strScriptID = new StringBuilder(String.Empty);
            foreach (EScript oScript in Scripts)
            {
                strScriptID.Append("," + oScript.ScriptID.ToString());
            }
            strScriptID.Remove(0, 1);

            returnresult = callCenterDal.SaveScript(strScriptID.ToString(), Convert.ToInt32(EOperationMode.Delete));
            GetScript();
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfScriptID.Value = "";
        }

    }

    /// <summary>
    /// this method is to get list of selected script(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    private EScript[] GetSelectedScript()
    {
        System.Collections.ArrayList ListScript = new ArrayList();

        for (int i = 0; i < grdScript.Rows.Count; i++)
        {
            HtmlInputCheckBox chkScriptSelecter = new HtmlInputCheckBox();
            chkScriptSelecter = (HtmlInputCheckBox)grdScript.Rows[i].FindControl("chkRowChild");
            if (chkScriptSelecter.Checked == true)
            {
                EScript script = new EScript();
                script.ScriptID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdScript.Rows[i].DataItemIndex]["ScriptID"]);
                ListScript.Add(script);
            }
        }

        EScript[] Scripts = new EScript[ListScript.Count];
        for (int i = 0; i < ListScript.Count; i++)
        {
            Scripts[i] = new EScript();
            Scripts[i] = (EScript)ListScript[i];
        }

        return Scripts;

    }

    /// <summary>
    /// this method is used for deactivating the selected Script(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        EScript[] Scripts = GetSelectedScript();

        if (Scripts.Length > 0)
        {
            CallCenterDAL callCenterDal = new CallCenterDAL();

            StringBuilder strScriptID = new StringBuilder(String.Empty);
            foreach (EScript oScript in Scripts)
            {
                strScriptID.Append("," + oScript.ScriptID.ToString());
            }
            strScriptID.Remove(0, 1);

            returnresult = callCenterDal.SaveScript(strScriptID.ToString(), Convert.ToInt32(EOperationMode.DeActivate));

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfScriptID.Value = "";
            GetScript();
        }

    }

    /// <summary>
    /// this method is used for deactivating the selected Script(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        EScript[] Scripts = GetSelectedScript();

        if (Scripts.Length > 0)
        {
            StringBuilder strScriptID = new StringBuilder(String.Empty);
            foreach (EScript oScript in Scripts)
            {
                strScriptID.Append("," + oScript.ScriptID.ToString());
            }
            strScriptID.Remove(0, 1);

            CallCenterDAL callCenterDal = new CallCenterDAL();

            returnresult = callCenterDal.SaveScript(strScriptID.ToString(), Convert.ToInt32(EOperationMode.Activate));

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            errordiv.Visible = true;
            hfScriptID.Value = "";
            GetScript();
        }

    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdScript_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                ViewState["mastercheckboxid"] = chktempheader.ClientID;
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                //ClientScript.RegisterArrayDeclaration("arrcheckboxids", "'" + chktemprow.ClientID + "'");
                if (ViewState["mastercheckboxid"] != null)
                    chktemprow.Attributes["onClick"] = "checkallboxes()";

            }

        }
    }

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdScript_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdScript.PageIndex = e.NewPageIndex;
        grdScript.DataSource = (DataTable)ViewState["DSGRID"];
        grdScript.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit Script Details";
        this.ModalPopupExtender.Show();
    }

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdScript_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtScript = (DataTable)ViewState["DSGRID"];


        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtScript.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtScript.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        ViewState["SortExp"] = e.SortExpression;

        dtScript = dtScript.DefaultView.ToTable();
        ViewState["DSGRID"] = dtScript;
        grdScript.DataSource = dtScript;
        grdScript.DataBind();
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
