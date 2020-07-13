using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Geo;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;

public partial class BMSMastersCommon_VanDetails : Page
{
    /// <summary>
    /// post back of page is checked.all the active van from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender,EventArgs e)
    {
        Page.Title = "Manage Van/Vehicles";
        divErrorMsg.InnerHtml = "";
        var obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Van");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var states = stateRepository.GetAllStates();

            var fillState = new Func<DropDownList, DropDownList>(ddl =>
            {
                ddl.Items.Clear();

                ddl.DataSource = states;
                ddl.DataTextField = "Name";
                ddl.DataValueField = "Id";
                ddl.DataBind();

                ddl.Items.Insert(0, new ListItem("Select State", "0"));
                return ddl;
            });

            ddlstate = fillState(ddlstate);

            ViewState["SortDir"] = SortDirection.Ascending;
            ViewState["SortExp"] = "name";
            if (Request.QueryString["searchtext"] != null)
            {
                SearchVan(Request.QueryString["searchtext"]);
            }
            else
            {
                GetVan();
            }
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + grdVanDetails.ClientID + "'");        
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + ddlstate.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + hfVanID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtVIN.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtMake.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrstateelemclientid", "'" + txtReg.ClientID + "'");
    }

    /// <summary>
    /// This method searches for the van by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchVan(string searchtext)
    {
        var masterDal = new MasterDAL();
        EVan[] van = masterDal.GetVan(searchtext, 2).ToArray();

        var dtVanDetails = new DataTable();
        dtVanDetails.Columns.Add("VanID", typeof(int));
        dtVanDetails.Columns.Add("name");
        dtVanDetails.Columns.Add("description");
        dtVanDetails.Columns.Add("State");
        dtVanDetails.Columns.Add("active");
        dtVanDetails.Columns.Add("VIN");
        dtVanDetails.Columns.Add("Make");
        dtVanDetails.Columns.Add("RegistrationNumber");

        if (van.Length > 0)
        {
            for (int icount = 0; icount < van.Length; icount++)
            {
                if (van[icount].Active.ToString().Equals("True"))
                {
                    dtVanDetails.Rows.Add(new object[] { van[icount].VanID, van[icount].Name, van[icount].Description, van[icount].State.Name, "Active", van[icount].VIN, van[icount].Make, van[icount].RegistrationNumber });
                }
                else
                    dtVanDetails.Rows.Add(new object[] { van[icount].VanID, van[icount].Name, van[icount].Description, van[icount].State.Name, "Deactivated", van[icount].VIN, van[icount].Make, van[icount].RegistrationNumber });
            }


            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtVanDetails.DefaultView.Sort = ViewState["SortExp"] + " asc";
            }
            else
            {
                dtVanDetails.DefaultView.Sort = ViewState["SortExp"] + " desc";
            }
            dtVanDetails = dtVanDetails.DefaultView.ToTable();

            grdVanDetails.DataSource = dtVanDetails;
            ViewState["DSGRID"] = dtVanDetails;
            grdVanDetails.DataBind();

            txtName.Text = "";
            txtDescription.Text = "";
            txtVIN.Text = "";
            txtMake.Text = "";
            txtReg.Text = "";
            ddlstate.SelectedIndex = 0;
            hfVanID.Value = "";
            btnActivate.Enabled = true;
            btnDeActivate.Enabled = true;
            btnDelete.Enabled = true;            
            grdVanDetails.Visible = true;
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "No Records Found";
            grdVanDetails.Visible = false;
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnDelete.Enabled = false;            
        }
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the vans. 
    /// </summary>
    private void GetVan()
    {
        var masterDal = new MasterDAL();
        EVan[] van = masterDal.GetVan(string.Empty, 0).ToArray();

        var dtVanDetails = new DataTable();
        dtVanDetails.Columns.Add("VanID", typeof(int));
        dtVanDetails.Columns.Add("name");
        dtVanDetails.Columns.Add("description");
        dtVanDetails.Columns.Add("State");
        dtVanDetails.Columns.Add("active");
        dtVanDetails.Columns.Add("VIN");
        dtVanDetails.Columns.Add("Make");
        dtVanDetails.Columns.Add("RegistrationNumber");
        if (van.Length > 0)
        {
            for (int icount = 0; icount < van.Length; icount++)
            {
                if (van[icount].Active.ToString().Equals("True"))
                {
                    dtVanDetails.Rows.Add(new object[] { van[icount].VanID, van[icount].Name, van[icount].Description, van[icount].State.Name, "Active", van[icount].VIN, van[icount].Make, van[icount].RegistrationNumber });
                }
                else
                    dtVanDetails.Rows.Add(new object[] { van[icount].VanID, van[icount].Name, van[icount].Description, van[icount].State.Name, "Deactivated", van[icount].VIN, van[icount].Make, van[icount].RegistrationNumber });
            }

            grdVanDetails.DataSource = dtVanDetails;
            ViewState["DSGRID"] = dtVanDetails;
            grdVanDetails.DataBind();

            txtName.Text = "";
            txtDescription.Text = "";
            txtVIN.Text = "";
            txtMake.Text = "";
            txtReg.Text = "";
            ddlstate.SelectedIndex = 0;
            hfVanID.Value = "";
            btnActivate.Enabled = true;
            btnDeActivate.Enabled = true;
            btnDelete.Enabled = true;            
            grdVanDetails.Visible = true;
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "No Records Found";
            grdVanDetails.Visible = false;
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnDelete.Enabled = false;            
        }
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the van which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateVan()
    {
        var masterDal = new MasterDAL();
        var van = new EVan
        {
            Description = txtDescription.Text,
            Name = txtName.Text,
            VIN = txtVIN.Text,
            Make = txtMake.Text,
            RegistrationNumber = txtReg.Text,
            Active = true
        };
        var state = new EState {StateID = Convert.ToInt32(ddlstate.SelectedValue)};

        van.State = state;
        Int64 returnresult;
        if (hfVanID.Value.Equals(""))
        {
            returnresult = masterDal.SaveVan(van, Convert.ToInt32(EOperationMode.Insert));
            divErrorMsg.Visible = true;
            if (returnresult == 999998)
            {
                divErrorMsg.InnerText = "Name already exists";
            }
            else if (returnresult == -5)
            {
                divErrorMsg.InnerText = "Van with same registration number exists";
            }
            else
            {
                divErrorMsg.InnerText = "You have added a Van, please use the search at the top to retrieve the recently added van";
            }
        }
        else
        {
            van.VanID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdVanDetails.Rows[Convert.ToInt32(hfVanID.Value)].DataItemIndex]["VanID"]);
            masterDal.SaveVan(van, Convert.ToInt32(EOperationMode.Update));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Van details has been updated.";
        }
        
        hfVanID.Value = "";
        GetVan();
    }

    /// <summary>
    /// this method is called on save button click which calls UpdateVan 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateVan();
    }

    /// <summary>
    /// this method is used to delete the selected van(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        EVan[] Vans = GetSelectedVan();
        if (Vans.Length > 0)
        {
            var masterDal = new MasterDAL();
            var strVanId = new StringBuilder(String.Empty);
            foreach (EVan oVan in Vans)
            {
                strVanId.Append("," + oVan.VanID);
            }
            strVanId.Remove(0, 1);
            returnresult = masterDal.SaveVan(strVanId.ToString(), Convert.ToInt32(EOperationMode.Delete));
            GetVan();
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0 ? "Van has been deleted." : "Van can not be deleted since it is in use";
            hfVanID.Value = "";
        }

    }

    /// <summary>
    /// this method is to get list of selected van(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    private EVan[] GetSelectedVan()
    {
        var ListVan = new ArrayList();


        for (int i = 0; i < grdVanDetails.Rows.Count; i++)
        {
            var chkStateSelecter = new HtmlInputCheckBox();
            chkStateSelecter = (HtmlInputCheckBox)grdVanDetails.Rows[i].FindControl("chkRowChild");
            if (chkStateSelecter.Checked == true)
            {
                EVan van = new EVan();
                van.VanID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdVanDetails.Rows[i].DataItemIndex]["VanID"]);
                ListVan.Add(van);
            }
        }

        EVan[] Vans = new EVan[ListVan.Count];
        for (int i = 0; i < ListVan.Count; i++)
        {
            Vans[i] = new EVan();
            Vans[i] = (EVan)ListVan[i];
        }

        return Vans;

    }

    /// <summary>
    /// this method is used for deactivating the selected Van(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        EVan[] Vans = GetSelectedVan();
        
        if (Vans.Length > 0)
        {
            var strVanID = new StringBuilder(String.Empty);
            foreach (EVan oVan in Vans)
            {
                strVanID.Append("," + oVan.VanID);
            }
            strVanID.Remove(0, 1);
            var masterDal = new MasterDAL();
            returnresult = masterDal.SaveVan(strVanID.ToString(), Convert.ToInt32(EOperationMode.DeActivate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0 ? "Van has been deactivated." : "Van can not be deactivated since it is in use";
            hfVanID.Value = "";
            GetVan();
        }

    }

    /// <summary>
    /// this method is used for activating the selected Van(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        EVan[] Vans = GetSelectedVan();
        
        if (Vans.Length > 0)
        {
            var strVanID = new StringBuilder(String.Empty);
            foreach (EVan oVan in Vans)
            {
                strVanID.Append("," + oVan.VanID);
            }
            strVanID.Remove(0, 1);
            var masterDAL = new MasterDAL();
            returnresult = masterDAL.SaveVan(strVanID.ToString(), Convert.ToInt32(EOperationMode.Activate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0 ? "Van has been activated." : "Van can not be activated due to some internal error.";
            hfVanID.Value = "";
            GetVan();
        }

    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdVanDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
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
    protected void grdVanDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdVanDetails.PageIndex = e.NewPageIndex;
        grdVanDetails.DataSource = (DataTable)ViewState["DSGRID"];
        grdVanDetails.DataBind();
    }

    

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdVanDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        var dtvandetails = (DataTable)ViewState["DSGRID"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtvandetails.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtvandetails.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtvandetails = dtvandetails.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;

        grdVanDetails.DataSource = dtvandetails;
        grdVanDetails.DataBind();
    }
    
}
