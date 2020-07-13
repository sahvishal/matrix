using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;

public partial class App_Franchisor_Masters_MarketingSource : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active MarketingSource from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Marketing Source";
        divErrorMsg.InnerText = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Marketing Source");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortSource"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchSource(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetSource();
            }
        }

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");

    }


    /// <summary>
    /// This method searches for the MarketingSource by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchSource(string searchtext)
    {
        OtherDAL otherDal = new OtherDAL();
        EMarketingSource[] objMarketing = otherDal.GetMarketingSource(searchtext, 2).ToArray();

        DataTable dtMarketingSource = new DataTable();
        dtMarketingSource.Columns.Add("MarketingSourceID");
        dtMarketingSource.Columns.Add("Source");
        dtMarketingSource.Columns.Add("notes");
        dtMarketingSource.Columns.Add("Active");

        if (objMarketing.Length > 0 && objMarketing.Length > 0)
        {
            for (int icount = 0; icount < objMarketing.Length; icount++)
            {
                if (objMarketing[icount].IsActive.ToString().Equals("True"))
                {
                    dtMarketingSource.Rows.Add(new object[] { objMarketing[icount].MarketingSourceID, objMarketing[icount].Label, objMarketing[icount].Notes, "Active" });
                }
                else
                    dtMarketingSource.Rows.Add(new object[] { objMarketing[icount].MarketingSourceID, objMarketing[icount].Label, objMarketing[icount].Notes, "Deactivated" });
            }


            if ((SortDirection)ViewState["SortSource"] == SortDirection.Descending)
            {
                dtMarketingSource.DefaultView.Sort = "Source desc";
            }
            else
            {
                dtMarketingSource.DefaultView.Sort = "Source asc";
            }

            dtMarketingSource = dtMarketingSource.DefaultView.ToTable();

            grdMarketingSource.DataSource = dtMarketingSource;
            ViewState["DSGRID"] = dtMarketingSource;

            grdMarketingSource.DataBind();

            txtName.Text = "";
            txtNotes.Text = "";
            hfMarketingSourceID.Value = "";
            grdMarketingSource.Visible = true;
            btnActivate.Enabled = true;
            btnDeActivate.Enabled = true;
            btnDelete.Enabled = true;
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "No Records Found";
            //ClientScript.RegisterStartupScript(typeof(string), "jscode", "DisableAll();", true);
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnDelete.Enabled = false;
            grdMarketingSource.Visible = false;
        }
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the MarketingSources. 
    /// </summary>
    private void GetSource()
    {
        OtherDAL otherDal = new OtherDAL();
        EMarketingSource[] objMarketing = otherDal.GetMarketingSource(string.Empty, 0).ToArray();

        DataTable dtMarketingSource = new DataTable();
        dtMarketingSource.Columns.Add("MarketingSourceID");
        dtMarketingSource.Columns.Add("Source");
        dtMarketingSource.Columns.Add("notes");
        dtMarketingSource.Columns.Add("Active");

        if (objMarketing.Length > 0 && objMarketing.Length > 0)
        {
            for (int icount = 0; icount < objMarketing.Length; icount++)
            {
                if (objMarketing[icount].IsActive.ToString().Equals("True"))
                {
                    dtMarketingSource.Rows.Add(new object[] { objMarketing[icount].MarketingSourceID, objMarketing[icount].Label, objMarketing[icount].Notes, "Active" });
                }
                else
                    dtMarketingSource.Rows.Add(new object[] { objMarketing[icount].MarketingSourceID, objMarketing[icount].Label, objMarketing[icount].Notes, "Deactivated" });
            }
            
            grdMarketingSource.DataSource = dtMarketingSource;
            ViewState["DSGRID"] = dtMarketingSource;

            grdMarketingSource.DataBind();

            txtName.Text = "";
            txtNotes.Text = "";
            hfMarketingSourceID.Value = "";
            grdMarketingSource.Visible = true;
            btnActivate.Enabled = true;
            btnDeActivate.Enabled = true;
            btnDelete.Enabled = true;
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "No Records Found";
            //ClientScript.RegisterStartupScript(typeof(string), "jscode", "DisableAll();", true);
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnDelete.Enabled = false;
            grdMarketingSource.Visible = false;
        }
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the MarketingSource which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateSource()
    {

        OtherDAL otherDal = new OtherDAL();
        EMarketingSource objMarketing = new EMarketingSource {Notes = txtNotes.Text, Label = txtName.Text};
                
        objMarketing.IsActive = true;
        
        Int64 returnresult;
        if (hfMarketingSourceID.Value.ToString().Equals(""))
        {
            returnresult = otherDal.SaveMarketingSource(objMarketing, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }
        }
        else
        {
            objMarketing.MarketingSourceID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdMarketingSource.Rows[Convert.ToInt32(hfMarketingSourceID.Value)].DataItemIndex]["MarketingSourceID"]);
            returnresult = otherDal.SaveMarketingSource(objMarketing, Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }
        }
        divErrorMsg.Visible = true;
        divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        hfMarketingSourceID.Value = "";
        GetSource();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateSource 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateSource();

        this.ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used to delete the selected MarketingSource(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        EMarketingSource[] marketingSource = GetSelectedSource();
        OtherDAL otherDal = new OtherDAL();
        
        
        if (marketingSource.Length > 0)
        {
            StringBuilder strMarketingSourceId = new StringBuilder(String.Empty);
            foreach (EMarketingSource oMarketingSource in marketingSource)
            {
                strMarketingSourceId.Append("," + oMarketingSource.MarketingSourceID.ToString());
            }
            strMarketingSourceId.Remove(0, 1);

            Int64 returnresult = otherDal.SaveMarketingSource(strMarketingSourceId.ToString(), Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }
            
            GetSource();
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfMarketingSourceID.Value = "";
        }
    }

    /// <summary>
    /// this method is to get list of selected MarketingSource(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    private EMarketingSource[] GetSelectedSource()
    {
        System.Collections.ArrayList ListMarketingSource = new ArrayList();


        for (int i = 0; i < grdMarketingSource.Rows.Count; i++)
        {
            HtmlInputCheckBox chkMSSelecter = new HtmlInputCheckBox();
            chkMSSelecter = (HtmlInputCheckBox)grdMarketingSource.Rows[i].FindControl("chkRowChild");
            if (chkMSSelecter.Checked == true)
            {
                EMarketingSource objMarketing = new EMarketingSource();
                objMarketing.MarketingSourceID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdMarketingSource.Rows[i].DataItemIndex]["MarketingSourceID"]);
                ListMarketingSource.Add(objMarketing);
            }
        }

        EMarketingSource[] MarketingSource = new EMarketingSource[ListMarketingSource.Count];
        for (int i = 0; i < ListMarketingSource.Count; i++)
        {
            MarketingSource[i] = new EMarketingSource();
            MarketingSource[i] = (EMarketingSource)ListMarketingSource[i];
        }

        return MarketingSource;
    }

    /// <summary>
    /// this method is used for deactivating the selected MarketingSource(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        EMarketingSource[] marketingSource = GetSelectedSource();
        OtherDAL otherDal = new OtherDAL();
        
        if (marketingSource.Length > 0)
        {
            StringBuilder strMarketingSourceId = new StringBuilder(String.Empty);
            foreach (EMarketingSource oMarketingSource in marketingSource)
            {
                strMarketingSourceId.Append("," + oMarketingSource.MarketingSourceID.ToString());
            }
            strMarketingSourceId.Remove(0, 1);

            Int64 returnresult = otherDal.SaveMarketingSource(strMarketingSourceId.ToString(), Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfMarketingSourceID.Value = "";
            GetSource();
        }
    }

    /// <summary>
    /// this method is used for activating the selected MarketingSource(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        EMarketingSource[] marketingSource = GetSelectedSource();
        OtherDAL otherDal = new OtherDAL();
        
        if (marketingSource.Length > 0)
        {

            StringBuilder strMarketingSourceId = new StringBuilder(String.Empty);
            foreach (EMarketingSource oMarketingSource in marketingSource)
            {
                strMarketingSourceId.Append("," + oMarketingSource.MarketingSourceID.ToString());
            }
            strMarketingSourceId.Remove(0, 1);

            Int64 returnresult = otherDal.SaveMarketingSource(strMarketingSourceId.ToString(), Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfMarketingSourceID.Value = "";
            GetSource();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMarketingSource_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "GridMasterCheck()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                chktemprow.Attributes["onClick"] = "GridChildCheck()";
            }

            LinkButton lnkBtnMarketingSource = (LinkButton)e.Row.FindControl("lnkBtnMarketingSource");
            lnkBtnMarketingSource.OnClientClick = "return EditMarketingSource('" + lnkBtnMarketingSource.ClientID + "')";

        }
    }

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMarketingSource_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdMarketingSource.PageIndex = e.NewPageIndex;
        grdMarketingSource.DataSource = (DataTable)ViewState["DSGRID"];
        grdMarketingSource.DataBind();
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
    protected void grdMarketingSource_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtMarketingSource = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortSource"] == SortDirection.Descending)
        {
            dtMarketingSource.DefaultView.Sort = "Source asc";
            ViewState["SortSource"] = SortDirection.Ascending;
        }
        else
        {
            dtMarketingSource.DefaultView.Sort = "Source desc";
            ViewState["SortSource"] = SortDirection.Descending;
        }
        dtMarketingSource = dtMarketingSource.DefaultView.ToTable();

        grdMarketingSource.DataSource = dtMarketingSource;
        ViewState["DSGRID"] = dtMarketingSource;

        grdMarketingSource.DataBind();
    }
}
