using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//////using HealthYes.Web.UI.CountryService;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using System.Text;
using Falcon.App.Core.Enum;

public partial class Franchisor_Masters_Country : System.Web.UI.Page
{

    /// <summary>
    /// post back of page is checked.all the active countries from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
       

        Page.Title = "Country";
        divErrorMsg.InnerText = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Country");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortCountry"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchCountry(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetCountry();
            }
            
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        
        //ClientScript.RegisterArrayDeclaration("arrvalidations", "'" + CountryRequiredValidator.ClientID + "'");
        //ClientScript.RegisterArrayDeclaration("arrvalidations", "'" + CountrySpecialValidator.ClientID + "'");
        //ClientScript.RegisterArrayDeclaration("arrvalidations", "'" + ErrorSummary.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcountryelemclientid", "'" + grdCountry.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcountryelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcountryelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcountryelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcountryelemclientid", "'" + hfCountryID.ClientID + "'");

    }

    /// <summary>
    /// This method searches for the country by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchCountry(string searchtext)
    {
        //CountryService service = new CountryService();
        //HealthYes.Web.UI.CountryService.ECountry[] country;
        //country = service.GetCountryByName(searchtext);

        MasterDAL masterDAL = new MasterDAL();
        ECountry[] country;
        country = masterDAL.GetCountry(searchtext, 2).ToArray(); 


        DataTable dtCountry = new DataTable();
        dtCountry.Columns.Add("CountryID", typeof(Int64));
        dtCountry.Columns.Add("name");
        dtCountry.Columns.Add("description");
        dtCountry.Columns.Add("Active");
        dtCountry.Columns.Add("CountryCode");

        if (country.Length > 0)
        {
            for (int icount = 0; icount < country.Length; icount++)
            {
                if (country[icount].Active.ToString().Equals("True"))
                {
                    dtCountry.Rows.Add(new object[] { country[icount].CountryID, country[icount].Name, country[icount].Description, "Active", country[icount].CountryCode });
                }
                else
                    dtCountry.Rows.Add(new object[] { country[icount].CountryID, country[icount].Name, country[icount].Description, "Deactivated", country[icount].CountryCode });

            }
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "No Records Found";
            btnActivate.Visible = false;
            btnDeActivate.Visible = false;
            btnDelete.Visible = false;
            btnEdit.Visible = false;
        }

        if ((SortDirection)ViewState["SortCountry"] == SortDirection.Descending)
        {
            dtCountry.DefaultView.Sort = "name desc";
        }
        else
        {
            dtCountry.DefaultView.Sort = "name asc";
        }

        dtCountry = dtCountry.DefaultView.ToTable();
        
        grdCountry.DataSource = dtCountry;

        ViewState["DSGRID"] = dtCountry;
        
        grdCountry.DataBind();
        //grdCountry.Sort("name", SortDirection.Ascending);
        txtName.Text = "";
        txtDescription.Text = "";
        txtCountryCode.Text = "";
        hfCountryID.Value = "";
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the countries. 
    /// </summary>
    private void GetCountry()
    {
        //CountryService service = new CountryService();
        //HealthYes.Web.UI.CountryService.ECountry[] country;
        //country = service.GetAllCountries();
        
        MasterDAL masterDAL = new MasterDAL();
        ECountry[] country;
        country = masterDAL.GetCountry(string.Empty, 0).ToArray(); 
        
        DataTable dtCountry = new DataTable();
        dtCountry.Columns.Add("CountryID", typeof(Int64));
        dtCountry.Columns.Add("name");
        dtCountry.Columns.Add("description");
        dtCountry.Columns.Add("Active");
        dtCountry.Columns.Add("CountryCode");

        if (country != null)
        {
            for (int icount = 0; icount < country.Length; icount++)
            {
                if (country[icount].Active.ToString().Equals("True"))
                {
                    dtCountry.Rows.Add(new object[] { country[icount].CountryID, country[icount].Name, country[icount].Description, "Active", country[icount].CountryCode });
                }
                else
                    dtCountry.Rows.Add(new object[] { country[icount].CountryID, country[icount].Name, country[icount].Description, "Deactivated", country[icount].CountryCode });
            }
        }

        if ((SortDirection)ViewState["SortCountry"] == SortDirection.Descending)
        {
            dtCountry.DefaultView.Sort = "name desc";
        }
        else
        {
            dtCountry.DefaultView.Sort = "name asc";
        }

        dtCountry = dtCountry.DefaultView.ToTable();

        grdCountry.DataSource = dtCountry;
        ViewState["DSGRID"] = dtCountry;

        grdCountry.DataBind();
        //grdCountry.Sort("name", SortDirection.Ascending);
        txtName.Text = "";
        txtDescription.Text = "";
        txtCountryCode.Text = "";
        hfCountryID.Value = "";
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the country which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateCountry()
    {

        MasterDAL masterDAL = new MasterDAL();
        ECountry country= new ECountry();
         

        country.Description = txtDescription.Text;
        country.Name = txtName.Text;
        country.CountryCode = txtCountryCode.Text.ToUpper();
        country.Active = true;
        Int64 returnresult;
        if (hfCountryID.Value.ToString().Equals(""))
        {
            
             returnresult = masterDAL.SaveCountry(country, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }
        }
        else
        {
            country.CountryID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdCountry.Rows[Convert.ToInt32(hfCountryID.Value)].DataItemIndex]["CountryID"]);
            
             returnresult = masterDAL.SaveCountry(country, Convert.ToInt32(EOperationMode.Update));
             if (returnresult == 0)
             {
                 returnresult = 9999991;
             }
        }
        divErrorMsg.Visible = true;
        divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        hfCountryID.Value = "";
        GetCountry();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateCountry 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateCountry();

        this.ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used for deleting the selected country(s)from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        //HealthYes.Web.UI.CountryService.ECountry[] Countries = GetSelectedCountry();
        //CountryService service = new CountryService();
        MasterDAL masterDAL = new MasterDAL();
        ECountry[] Countries = GetSelectedCountry();
        if (Countries.Length > 0)
        {
            ///service.DeleteCountry(Countries, "1", "1", "1", out returnresult, out temp);
            StringBuilder strCountryID = new StringBuilder(String.Empty);
            foreach (ECountry oCountry in Countries)
            {
                strCountryID.Append("," + oCountry.CountryID.ToString());
            }
            strCountryID.Remove(0, 1);
            
            returnresult = masterDAL.SaveCountry(strCountryID.ToString(), Convert.ToInt32(EOperationMode.Delete));
            if (returnresult == 0)
            {
                returnresult = 9999992;
            }
            GetCountry();
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfCountryID.Value = "";
        }
    }

    /// <summary>
    /// this method is to get list of selected country(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    private ECountry[] GetSelectedCountry()
    {
        System.Collections.ArrayList ListCountry = new ArrayList();


        for (int i = 0; i < grdCountry.Rows.Count; i++)
        {
            HtmlInputCheckBox chkCountrySelecter = new HtmlInputCheckBox();
            chkCountrySelecter = (HtmlInputCheckBox)grdCountry.Rows[i].FindControl("chkRowChild");
            if (chkCountrySelecter.Checked == true)
            {
                //grdCountry.Rows[i].RowState = DataControlRowState.Selected;
                ECountry country = new ECountry();
                //country.CountryID = Convert.ToInt32(grdCountry.DataKeys[grdCountry.PageSize * (grdCountry.PageIndex) + i].Value);
                country.CountryID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdCountry.Rows[i].DataItemIndex]["CountryID"]);
                ListCountry.Add(country);
            }
        }

        ECountry[] Countries = new ECountry[ListCountry.Count];
        for (int i = 0; i < ListCountry.Count; i++)
        {
            Countries[i] = new ECountry();
            Countries[i] = (ECountry)ListCountry[i];
        }

        return Countries;
    }

    /// <summary>
    /// this method is used for deactivating the selected country(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        ////HealthYes.Web.UI.CountryService.ECountry[] Countries = GetSelectedCountry();
        ECountry[] Countries = GetSelectedCountry();
        ///CountryService service = new CountryService();
        if (Countries.Length > 0)
        {
            //service.DeactivateCountry(Countries, "1", "1", "1", out returnresult, out temp);
            StringBuilder strCountryID = new StringBuilder(String.Empty);
            foreach (ECountry oCountry in Countries)
            {
                strCountryID.Append("," + oCountry.CountryID.ToString());
            }
            strCountryID.Remove(0, 1);
            MasterDAL masterDAL = new MasterDAL();
             returnresult = masterDAL.SaveCountry(strCountryID.ToString(), Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }
            
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfCountryID.Value = "";
            GetCountry();
        }
    }

    /// <summary>
    /// this method is used for activating the selected country(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        ///HealthYes.Web.UI.CountryService.ECountry[] Countries = GetSelectedCountry();

        ECountry[] Countries = GetSelectedCountry();
        ///CountryService service = new CountryService();
       
        if (Countries.Length > 0)
        {

            ///service.ActivateCountry(Countries, "1", "1", "1", out returnresult, out temp);
            StringBuilder strCountryID = new StringBuilder(String.Empty);
            foreach (ECountry oCountry in Countries)
            {
                strCountryID.Append("," + oCountry.CountryID.ToString());
            }
            strCountryID.Remove(0, 1);
            MasterDAL masterDAL = new MasterDAL();
             returnresult = masterDAL.SaveCountry(strCountryID.ToString(), Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfCountryID.Value = "";
            GetCountry();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdCountry_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void grdCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdCountry.PageIndex = e.NewPageIndex;
        grdCountry.DataSource = (DataTable)ViewState["DSGRID"];
        grdCountry.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit Country";
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
    protected void grdCountry_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtcountry = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortCountry"] == SortDirection.Descending)
        {
            dtcountry.DefaultView.Sort = "name asc";
            ViewState["SortCountry"] = SortDirection.Ascending;
        }
        else
        {
            dtcountry.DefaultView.Sort = "name desc";
            ViewState["SortCountry"] = SortDirection.Descending;
        }
        dtcountry = dtcountry.DefaultView.ToTable();

        grdCountry.DataSource = dtcountry;
        ViewState["DSGRID"] = dtcountry;

        grdCountry.DataBind();
    }

}
