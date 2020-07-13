using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;

public partial class Franchisor_Masters_City : Page
{

    /// <summary>
    /// post back of page is checked.all the active cities from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "City";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("City");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        btnSave.Attributes["onClick"] = "return savecity();";
        txtMZipCode.Attributes.Add("onKeyDown", "return txtkeypress(event);");
        
        GetDropDownInfo();
        if (!IsPostBack)
        {
            ViewState["SortExp"] = "name";
            ViewState["SortDir"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchCity(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetCity();
            }
        }
        else
        {
            if (Request.Params != null)
            {
                if (Request.Params.Count > 0)
                {
                    ViewState["stateid"] = 0;
                    if (Request.Params["__EVENTTARGET"].ToString().Equals("save"))
                    {
                        ViewState["stateid"] = Request.Params["__EVENTARGUMENT"].ToString();
                        UpdateCity();
                    }
                }
            }
        }
        
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + grdCity.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + ddlcountry.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + ddlstate.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + hfCityID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrelemjscity", "'" + txtZip.ClientID + "'");
        
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        //hfZipFlag.Value = "";
        
    }

    private void GetDropDownInfo()
    {
        List<EState> state;

        if (!IsPostBack)
        {
            MasterDAL masterDal = new MasterDAL();
            ECountry[] country = masterDal.GetCountry(string.Empty, 3).ToArray();

            if (country.Length > 0)
            {
                ViewState["CountryID"] = country[0].CountryID.ToString();
                ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
                for (int count = 0; count < country.Length; count++)
                {
                    ddlcountry.Items.Add(new ListItem(country[count].Name, country[count].CountryID.ToString()));
                }
            }
            else
            {
                ddlcountry.Items.Add("Select");
            }

            state = masterDal.GetState(string.Empty, 3);

            ViewState["state"] = state;
            ddlMState.Items.Clear();
            ddlMState.Items.Add(new ListItem("Select State", "0"));
            for (int icount = 0; icount < state.Count; icount++)
            {
                ddlMState.Items.Add(new ListItem(state[icount].Name, state[icount].StateID.ToString()));
            }
        }
        else
        {
            state = (List<EState>)ViewState["state"];
        }

        ddlcountry.Attributes["onChange"] = "oncountrychange('" + ddlcountry.ClientID + "','" + ddlstate.ClientID + "' , false);";

        if (state.Count > 0)
        {
            for (int count = 0; count < state.Count; count++)
            {
                ClientScript.RegisterArrayDeclaration("arrjsstatenames", "'" + state[count].Name + "'");
                ClientScript.RegisterArrayDeclaration("arrjsstateids", "'" + state[count].StateID.ToString() + "'");
                ClientScript.RegisterArrayDeclaration("arrjsstatecntryids", "'" + state[count].StateID.ToString() + "-" + state[count].Country.CountryID + "'");
            }
        }
        else
        {
            ddlstate.Items.Add("Select");
        }

    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the cities. 
    /// </summary>
    private void GetCity()
    {
        //CityService service = new CityService();
        //HealthYes.Web.UI.CityService.ECity[] city;
        //city = service.GetAllCities();

        MasterDAL masterDAL = new MasterDAL();
        var city = masterDAL.GetCity(string.Empty, 0);
        
        DataTable dtCity = new DataTable();
        dtCity.Columns.Add("CityID", typeof(int));
        dtCity.Columns.Add("name");
        dtCity.Columns.Add("description");
        dtCity.Columns.Add("State");
        dtCity.Columns.Add("Country");
        dtCity.Columns.Add("active");
        // *** Viranjay [Manage City]
        dtCity.Columns.Add("Zipid");
        dtCity.Columns.Add("Zipcode");             

        if (city != null)
        {
            for (int icount = 0; icount < city.Count; icount++)
            {
                if (city[icount].Active.ToString().Equals("True"))
                {
                    dtCity.Rows.Add(new object[] { city[icount].CityID, city[icount].Name, city[icount].Description, city[icount].State.Name, city[icount].Country.Name, "Active", city[icount].Zipcode.ZipID, city[icount].Zipcode.ZipCode});
                }
                else
                    dtCity.Rows.Add(new object[] { city[icount].CityID, city[icount].Name, city[icount].Description, city[icount].State.Name, city[icount].Country.Name, "Deactivated", city[icount].Zipcode.ZipID, city[icount].Zipcode.ZipCode });

            }
        }
        
        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtCity.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
        }
        else
        {
            dtCity.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
        }
        dtCity = dtCity.DefaultView.ToTable();

        ViewState["DSGRID"] = dtCity;
        grdCity.DataSource = dtCity;
        grdCity.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";

        ddlstate.SelectedIndex = 0;
        ddlcountry.SelectedIndex = 0;
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the city which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateCity()
    {
        Int64 returnresult = 0;

        //CityService service = new CityService();

        string ZipCode = txtZip.Text;

        //HealthYes.Web.UI.CityService.ECity city = new HealthYes.Web.UI.CityService.ECity();
        var city = new ECity();
        city.Description = txtDescription.Text;
        city.Name = txtName.Text;

        //city.State = new HealthYes.Web.UI.CityService.EState();
        //city.Zipcode = new HealthYes.Web.UI.CityService.EZip();

        city.State = new EState();
        city.Zipcode = new EZip();

        if (ViewState["stateid"] != null)
            city.State.StateID = Convert.ToInt32(ViewState["stateid"]);

        //HealthYes.Web.UI.CityService.ECountry country = new HealthYes.Web.UI.CityService.ECountry();
        ECountry country = new ECountry();
        country.CountryID = Convert.ToInt32(ddlcountry.SelectedValue);
        city.Active = true;
        city.Country = country;

        city.Zipcode.ZipCode = ZipCode;

        MasterDAL masterDAL = new MasterDAL();

        if (hfCityID.Value.ToString().Equals(""))
        {
            city.Zipcode.ZipID = 0;
            //service.AddCity(city, "1", "1", "1", out returnresult, out temp);

            returnresult = masterDAL.SaveCity(city, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }
        }
        else
        {
            city.Zipcode.ZipID =
                Convert.ToInt32(
                    ((DataTable) (ViewState["DSGRID"])).Rows[grdCity.Rows[Convert.ToInt32(hfCityID.Value)].DataItemIndex
                        ]["ZipId"]);
            city.CityID =
                Convert.ToInt32(
                    ((DataTable) (ViewState["DSGRID"])).Rows[grdCity.Rows[Convert.ToInt32(hfCityID.Value)].DataItemIndex
                        ]["CityID"]);

            returnresult = masterDAL.SaveCity(city, Convert.ToInt32(EOperationMode.Update));
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }

            //service.UpdateCity(city, "1", "1", "1", out returnresult, out temp);
            hfCityID.Value = "";
        }

        errordiv.InnerHtml = (String) GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());

        if (Request.QueryString["searchtext"] != null)
        {
            SearchCity(Request.QueryString["searchtext"].ToString());
        }
        else
        {
            GetCity();
        }
        //GetCity();         

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateCity 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        //UpdateCity();
    }

    /// <summary>
    /// This method searches for the city by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchCity(string searchtext)
    {

        //CityService service = new CityService();
        //HealthYes.Web.UI.CityService.ECity[] city;
        //city = service.GetCityByName(searchtext);

        MasterDAL masterDAL = new MasterDAL();
        var city = masterDAL.GetCity(searchtext, 2);

        DataTable dtCity = new DataTable();
        dtCity.Columns.Add("CityID", typeof (int));
        dtCity.Columns.Add("name");
        dtCity.Columns.Add("description");
        dtCity.Columns.Add("State");
        dtCity.Columns.Add("Country");
        dtCity.Columns.Add("active");
        dtCity.Columns.Add("Zipid");
        dtCity.Columns.Add("Zipcode");


        if (city != null)
        {
            for (int icount = 0; icount < city.Count; icount++)
            {
                if (city[icount].Active.ToString().Equals("True"))
                {
                    dtCity.Rows.Add(new object[]
                                        {
                                            city[icount].CityID, city[icount].Name, city[icount].Description,
                                            city[icount].State.Name, city[icount].Country.Name, "Active",
                                            city[icount].Zipcode.ZipID, city[icount].Zipcode.ZipCode
                                        });
                }
                else
                    dtCity.Rows.Add(new object[]
                                        {
                                            city[icount].CityID, city[icount].Name, city[icount].Description,
                                            city[icount].State.Name, city[icount].Country.Name, "Deactivated",
                                            city[icount].Zipcode.ZipID, city[icount].Zipcode.ZipCode
                                        });
            }
        }

        if ((SortDirection) ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtCity.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
        }
        else
        {
            dtCity.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
        }
        dtCity = dtCity.DefaultView.ToTable();

        ViewState["DSGRID"] = dtCity;
        grdCity.DataSource = dtCity;
        grdCity.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";

        ddlstate.SelectedIndex = 0;
        ddlcountry.SelectedIndex = 0;

    }

    ///// <summary>
    ///// this method is used for deleting the selected City(s).
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    //{
    //    bool temp = false;
    //    Int64 returnresult;
    //    CityService.ECity[] Cities = GetSelectedCity();
    //    CityService.CityService service = new CityService.CityService();
    //    if (Cities.Length > 0)
    //    {
    //        service.RemoveCity(Cities, "1", "1", "1", out returnresult, out temp);

    //        if (Request.QueryString["searchtext"] != null)
    //        {
    //            SearchCity(Request.QueryString["searchtext"].ToString());
    //        }
    //        else
    //        {
    //            GetCity();
    //        }           
    //        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
    //        hfCityID.Value = "";
    //    }
    //}

    ///// <summary>
    ///// this method is to get list of selected city(s) in the grid. 
    ///// </summary>
    ///// <returns></returns>
    ///// 
    //private HealthYes.Web.UI.CityService.ECity[] GetSelectedCity()
    //{
    //    System.Collections.ArrayList ListCity = new ArrayList();


    //    for (int i = 0; i < grdCity.Rows.Count; i++)
    //    {
    //        HtmlInputCheckBox chkCitySelecter = new HtmlInputCheckBox();
    //        chkCitySelecter = (HtmlInputCheckBox)grdCity.Rows[i].FindControl("chkRowChild");
    //        if (chkCitySelecter.Checked == true)
    //        {
    //            HealthYes.Web.UI.CityService.ECity city = new HealthYes.Web.UI.CityService.ECity();
    //            city.CityID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdCity.Rows[i].DataItemIndex]["CityID"]);
    //            ListCity.Add(city);
    //        }
    //    }

    //    HealthYes.Web.UI.CityService.ECity[] Cities = new HealthYes.Web.UI.CityService.ECity[ListCity.Count];
    //    for (int i = 0; i < ListCity.Count; i++)
    //    {
    //        Cities[i] = new HealthYes.Web.UI.CityService.ECity();
    //        Cities[i] = (HealthYes.Web.UI.CityService.ECity)ListCity[i];
    //    }

    //    return Cities;

    //}

    /// <summary>
    /// this method is to get list of selected city(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    /// 
    private string GetSelectedCityIDs()
    {
        string strSelectedCityIDs = "";

        for (int i = 0; i < grdCity.Rows.Count; i++)
        {
            HtmlInputCheckBox chkCitySelecter = (HtmlInputCheckBox)grdCity.Rows[i].FindControl("chkRowChild");
            if (chkCitySelecter.Checked == true)
            {   
                strSelectedCityIDs += Convert.ToString(((DataTable)(ViewState["DSGRID"])).Rows[grdCity.Rows[i].DataItemIndex]["CityID"]);
            }
        }

        return strSelectedCityIDs;
    }

    /// <summary>
    /// this method is used for deactivating the selected City(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        //HealthYes.Web.UI.CityService.ECity[] Cities = GetSelectedCity();
        //CityService service = new CityService();

        string strSelectedCityIDs = GetSelectedCityIDs();

        //if (Cities.Length > 0)
        if (strSelectedCityIDs.Length > 0)
        {
            //service.DeactivateCity(Cities, "1", "1", "1", out returnresult, out temp);

            MasterDAL masterDAL = new MasterDAL();

            returnresult = masterDAL.SaveCity(strSelectedCityIDs, Convert.ToInt32(EOperationMode.DeActivate));
            
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfCityID.Value = "";
            if (Request.QueryString["searchtext"] != null)
            {
                SearchCity(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetCity();
            }      
            //GetCity();
        }

    }

    /// <summary>
    /// this method is used for activating the selected City(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;

        //HealthYes.Web.UI.CityService.ECity[] Cities = GetSelectedCity();
        //CityService service = new CityService();
        
        string strSelectedCityIDs = GetSelectedCityIDs();

        //if (Cities.Length > 0)
        if (strSelectedCityIDs.Length > 0)
        {
            
            //service.ActivateCity(Cities, "1", "1", "1", out returnresult, out temp);

            MasterDAL masterDAL = new MasterDAL();
            returnresult = masterDAL.SaveCity(strSelectedCityIDs, Convert.ToInt32(EOperationMode.Activate));
            if (returnresult == 0)
            {
                returnresult = 9999994;
            }

            errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfCityID.Value = "";
            if (Request.QueryString["searchtext"] != null)
            {
                SearchCity(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetCity();
            }
            //GetCity();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdCity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }

            //string strimgtag = "<img src='../../Images/up-arrow.gif' alt='' />";
            //grdCity.Columns[3].HeaderText = grdCity.Columns[3].HeaderText + strimgtag;

            //grdCity.Columns[5].HeaderText = grdCity.Columns[5].HeaderText + strimgtag;
            //grdCity.Columns[6].HeaderText = grdCity.Columns[6].HeaderText + strimgtag;

            //if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
            //    strimgtag = " <img src='../../Images/down-arrow.gif' alt='' />";

            //if (ViewState["SortExp"].ToString() == "name")
            //{
            //    e.Row.Cells[3].Text = e.Row.Cells[3].Text + strimgtag;
            //}
            //else if (ViewState["SortExp"].ToString() == "Country")
            //{
            //    e.Row.Cells[6].Text = e.Row.Cells[6].Text + strimgtag;
            //}
            //else if (ViewState["SortExp"].ToString() == "State")
            //{
            //    e.Row.Cells[5].Text = e.Row.Cells[5].Text + strimgtag;
            //}

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
    protected void grdCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCity.PageIndex = e.NewPageIndex;
        grdCity.DataSource = (DataTable)ViewState["DSGRID"];
        grdCity.DataBind();
    }

    /// <summary>
    /// this method is fired whenever the selected index of 
    /// country dropdown list is changed 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        var statearr = (List<EState>)ViewState["state"];
        ddlstate.Items.Clear();
        for (int count = 0; count < statearr.Count; count++)
        {
            if (statearr[count].Country.CountryID == Convert.ToInt32(ddlcountry.SelectedItem.Value))
                ddlstate.Items.Add(new ListItem(statearr[count].Name, statearr[count].StateID.ToString()));
        }

    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(string), "js", "<script language='javascript' type='text/javascript'>  oncountrychange('" + ddlcountry.ClientID + "','" + ddlstate.ClientID + "', true); </script>");
        ModalPopupExtender.Show();
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");

        
    }

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdCity_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtcity = (DataTable)ViewState["DSGRID"];
        
        if (e.SortExpression != ViewState["SortExp"].ToString())
        {
            dtcity.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtcity.DefaultView.Sort = e.SortExpression + " desc";
                ViewState["SortDir"] = SortDirection.Descending;
            }
            else
            {
                dtcity.DefaultView.Sort = e.SortExpression + " asc";
                ViewState["SortDir"] = SortDirection.Ascending;
            }
        }
                
        ViewState["SortExp"] = e.SortExpression;
        dtcity = dtcity.DefaultView.ToTable();

        grdCity.DataSource = dtcity;
        grdCity.DataBind();
        //string strimgtag = "<img src='../../Images/up-arrow.gif' alt='' />";
        //grdCity.Columns[3].HeaderText = grdCity.Columns[3].HeaderText + strimgtag;

        //grdCity.Columns[5].HeaderText = grdCity.Columns[5].HeaderText + strimgtag;
        //grdCity.Columns[6].HeaderText = grdCity.Columns[6].HeaderText + strimgtag;

        ViewState["DSGRID"] = dtcity;
    }

    /// <summary>
    /// this method is used to close the modular popup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender.Hide();
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
    }

    protected void iBtnSaveMultipleCity_Click(object sender, ImageClickEventArgs e)
    {
        hfCityName.Value = hfCityName.Value.Substring(0, hfCityName.Value.Length - 1);
        hfStateID.Value = hfStateID.Value.Substring(0, hfStateID.Value.Length - 1);
        char[] split = new char[1];
        split[0] = ',';
        string[] CityName = hfCityName.Value.Split(split);
        string[] StateID = hfStateID.Value.Split(split);

        Int64 returnresult;

        //CityService objCityService = new CityService();
        //HealthYes.Web.UI.CityService.ECity[] objCity = new HealthYes.Web.UI.CityService.ECity[CityName.Length];

        ECity[] objCity = new ECity[CityName.Length];

        for (int count = 0; count < CityName.Length; count++)
        {
            objCity[count] = new ECity();
            objCity[count].Description = "";
            objCity[count].Name = CityName[count];
            //objCity[count].State = new HealthYes.Web.UI.CityService.EState();
            objCity[count].State = new EState();
            objCity[count].State.StateID = Convert.ToInt32(StateID[count]);
            //objCity[count].Zipcode = new HealthYes.Web.UI.CityService.EZip();
            objCity[count].Zipcode = new EZip();
            objCity[count].Zipcode.ZipCode = txtMZipCode.Text;

            //objCity[count].Country = new HealthYes.Web.UI.CityService.ECountry();
            objCity[count].Country = new ECountry();
            if (ViewState["CountryID"] != null)
                objCity[count].Country.CountryID = Convert.ToInt32(ViewState["CountryID"]);
            else
                objCity[count].Country.CountryID = 68;
        }

        //objCityService.AddMultipleCities(objCity, "1", "1","1", out returnresult, out temp);

        MasterDAL masterDAL = new MasterDAL();
        returnresult = 0;
        foreach (ECity City in objCity)
        {
            returnresult = masterDAL.SaveCity(City, Convert.ToInt32(EOperationMode.Insert));
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }
        }

        errordiv.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());

        if (Request.QueryString["searchtext"] != null)
        {
            SearchCity(Request.QueryString["searchtext"].ToString());
        }
        else
        {
            GetCity();
        }
    }
}
