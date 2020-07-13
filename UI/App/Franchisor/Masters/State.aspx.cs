using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;

public partial class Franchisor_Masters_State : System.Web.UI.Page
{

    /// <summary>
    /// post back of page is checked.all the active State from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "State";
        errordiv.InnerHtml = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("State");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            var masterDAL = new MasterDAL();
            var country = masterDAL.GetCountry(string.Empty, 3).ToArray();

            ddlcountry.Items.Clear();
           
            if (country.Length > 0)
            {
                 ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
                for (int count = 0; count < country.Length; count++)
                {
                    ddlcountry.Items.Add(new ListItem(country[count].Name, country[count].CountryID.ToString()));
                }
            }
           
            ViewState["CountrySort"] = SortDirection.Ascending;
            ViewState["StateSort"] = SortDirection.Ascending;
            ViewState["SortExp"] = "name";
            if (Request.QueryString["searchtext"] != null)
            {
                SearchState(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetState();
            }
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + grdState.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + ddlcountry.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + hfStateID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtStateCode.ClientID + "'");
        grdState.Columns[2].Visible = false;
    }

    /// <summary>
    /// This method searches for the State by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchState(string searchtext)
    {
        MasterDAL masterDal = new MasterDAL();
        var state = masterDal.GetState(searchtext, 2);

        DataTable dtState = new DataTable();
        dtState.Columns.Add("StateID", typeof(int));
        dtState.Columns.Add("name");
        dtState.Columns.Add("description");
        dtState.Columns.Add("country");
        dtState.Columns.Add("active");
        dtState.Columns.Add("StateCode");

        if (state != null)
        {
            for (int icount = 0; icount < state.Count; icount++)
            {
                if (state[icount].Active.ToString().Equals("True"))
                {
                    dtState.Rows.Add(new object[]
                                         {
                                             state[icount].StateID, state[icount].Name, state[icount].Description,
                                             state[icount].Country.Name, "Active", state[icount].StateCode
                                         });
                }
                else
                    dtState.Rows.Add(new object[]
                                         {
                                             state[icount].StateID, state[icount].Name, state[icount].Description,
                                             state[icount].Country.Name, "Deactivated", state[icount].StateCode
                                         });
            }
        }

        grdState.DataSource = dtState;
        grdState.DataBind();
        ViewState["DSGRID"] = dtState;
                
        txtName.Text = "";
        txtDescription.Text = "";
        txtStateCode.Text = "";
        ddlcountry.SelectedIndex = 0;
        hfStateID.Value = "";
        
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the States. 
    /// </summary>
    private void GetState()
    {
        MasterDAL masterDal = new MasterDAL();
        var state = masterDal.GetState(string.Empty, 0);
        
        DataTable dtState = new DataTable();
        dtState.Columns.Add("StateID", typeof(int));
        dtState.Columns.Add("name");
        dtState.Columns.Add("description");
        dtState.Columns.Add("country");
        dtState.Columns.Add("active");
        dtState.Columns.Add("StateCode");

        if (state != null)
        {
            for (int icount = 0; icount < state.Count; icount++)
            {
                if (state[icount].Active.ToString().Equals("True"))
                {
                    dtState.Rows.Add(new object[] { state[icount].StateID, state[icount].Name, state[icount].Description, state[icount].Country.Name, "Active", state[icount].StateCode });
                }
                else
                    dtState.Rows.Add(new object[] { state[icount].StateID, state[icount].Name, state[icount].Description, state[icount].Country.Name, "Deactivated", state[icount].StateCode });
            }
        }

        if (ViewState["SortExp"].ToString() == "name")
        {
            if ((SortDirection)ViewState["StateSort"] == SortDirection.Ascending)
            {
                dtState.DefaultView.Sort = "name asc";
            }
            else
            {
                dtState.DefaultView.Sort = "name desc";
            }
        }
        else
        {
            if ((SortDirection)ViewState["CountrySort"] == SortDirection.Ascending)
            {
                dtState.DefaultView.Sort = "Country asc";
            }
            else
            {
                dtState.DefaultView.Sort = "Country desc";
            }
        }

        dtState = dtState.DefaultView.ToTable();

        grdState.DataSource = dtState;
        grdState.DataBind();
        ViewState["DSGRID"] = dtState;

        txtName.Text = "";
        txtDescription.Text = "";
        txtStateCode.Text = "";
        ddlcountry.SelectedIndex = 0;
        hfStateID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the State which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateState()
    {
        EState state = new EState
                           {
                               Description = txtDescription.Text,
                               Name = txtName.Text,
                               Active = true,
                               StateCode = txtStateCode.Text.ToUpper()
                           };

        var country = new ECountry();
        country.CountryID = Convert.ToInt32(ddlcountry.SelectedValue);

        state.Country = country;
        
        Int64 returnresult;
        MasterDAL masterDal = new MasterDAL();

        if (hfStateID.Value.Equals(""))
        {
            returnresult = masterDal.SaveState(state, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }
        }
        else
        {
            state.StateID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdState.Rows[Convert.ToInt32(hfStateID.Value)].DataItemIndex]["StateID"]);
            returnresult = masterDal.SaveState(state, Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }
        }

        errordiv.InnerHtml = (String) GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult);
        hfStateID.Value = "";
        GetState();
    }

    /// <summary>
    /// this method is called on save button click which calls UpdateState 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateState();
    }

    /// <summary>
    /// this method is used to delete the selected State(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedStateIDs = GetSelectedStateIDs();

        if (strSelectedStateIDs.Length > 0)
        {
            MasterDAL masterDAL = new MasterDAL();
            Int64 returnresult = masterDAL.SaveState(strSelectedStateIDs, Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }

            GetState();
            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfStateID.Value = "";
        }

    }

    /// <summary>
    /// this method is to get list of selected State(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    private string GetSelectedStateIDs()
    {
        string strSelectedStateIDs = "";

        for (int i = 0; i < grdState.Rows.Count; i++)
        {
            HtmlInputCheckBox chkStateSelecter = (HtmlInputCheckBox)grdState.Rows[i].FindControl("chkRowChild");

            if (chkStateSelecter.Checked)
            {
                strSelectedStateIDs +=
                    Convert.ToInt32(((DataTable) (ViewState["DSGRID"])).Rows[grdState.Rows[i].DataItemIndex]["StateID"]) +
                    ", ";
            }
        }

        if (strSelectedStateIDs.Length > 0)
            strSelectedStateIDs = strSelectedStateIDs.Remove(strSelectedStateIDs.LastIndexOf(", "));

        return strSelectedStateIDs;

    }

    /// <summary>
    /// this method is used for deactivating the selected State(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedStateIDs = GetSelectedStateIDs();
        if (strSelectedStateIDs.Length > 0)
        {
            MasterDAL masterDal = new MasterDAL();
            Int64 returnresult = masterDal.SaveState(strSelectedStateIDs, Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfStateID.Value = "";
            GetState();
        }

    }

    /// <summary>
    /// this method is used for activating the selected State(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedStateIDs = GetSelectedStateIDs();
        if (strSelectedStateIDs.Length > 0)
        {
            MasterDAL masterDal = new MasterDAL();
            Int64 returnresult = masterDal.SaveState(strSelectedStateIDs, Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }
            errordiv.InnerHtml =
                (String) GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfStateID.Value = "";
            GetState();
        }

    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdState_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void grdState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdState.PageIndex = e.NewPageIndex;
        grdState.DataSource = (DataTable)ViewState["DSGRID"];
        grdState.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit State";
        this.ModalPopupExtender.Show();
    }

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdState_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtstate = (DataTable)ViewState["DSGRID"];
        
        if (e.SortExpression == "Country")
        {
            if (((SortDirection)ViewState["CountrySort"] == SortDirection.Ascending) && (ViewState["SortExp"].ToString() != "name"))
            {
                dtstate.DefaultView.Sort = "Country desc";
                ViewState["CountrySort"] = SortDirection.Descending;
            }
            else
            {
                dtstate.DefaultView.Sort = "Country asc";
                ViewState["CountrySort"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = "Country";
            ViewState["StateSort"] = SortDirection.Ascending;
        }
        else
        {
            if (((SortDirection)ViewState["StateSort"] == SortDirection.Ascending)  && (ViewState["SortExp"].ToString() != "Country"))
            {
                dtstate.DefaultView.Sort = "name desc";
                ViewState["StateSort"] = SortDirection.Descending;
            }
            else
            {
                dtstate.DefaultView.Sort = "name asc";
                ViewState["StateSort"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = "name";
            ViewState["CountrySort"] = SortDirection.Ascending;
        }
        dtstate = dtstate.DefaultView.ToTable();
        ViewState["DSGRID"] = dtstate;
        grdState.DataSource = dtstate;
        grdState.DataBind();
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
