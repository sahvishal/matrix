using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Geo;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;

public partial class Franchisor_Masters_ContractDetails : Page
{
    /// <summary>
    /// post back of page is checked.all the active contract from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Contract";

        divErrorMsg.InnerText = "";
        var obj = (Franchisor_FranchisorMaster)Master;
        obj.settitle("Contract");
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

            ViewState["StateSort"] = SortDirection.Ascending;
            ViewState["ContractSort"] = SortDirection.Ascending;
            ViewState["SortExp"] = "name";
            if (Request.QueryString["searchtext"] != null)
            {
                SearchContract(Request.QueryString["searchtext"]);
            }
            else
            {
                GetContract();
            }
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrcontractelemclientid", "'" + grdContract.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcontractelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcontractelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcontractelemclientid", "'" + ddlstate.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcontractelemclientid", "'" + hfContractID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrcontractelemclientid", "'" + txtContract.ClientID + "'");
    }

    /// <summary>
    /// This method searches for the contract by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchContract(string searchtext)
    {
        var masterDal = new MasterDAL();
        var listContract = masterDal.GetContract(searchtext, 2);

        EContract[] contract = null;
        if (listContract != null)
            contract = listContract.ToArray();

        var dtContract = new DataTable();
        dtContract.Columns.Add("ContractID", typeof(int));
        dtContract.Columns.Add("contractname");
        dtContract.Columns.Add("description");
        dtContract.Columns.Add("state");
        dtContract.Columns.Add("active");
        dtContract.Columns.Add("contract");
        dtContract.Columns.Add("StartDate");
        dtContract.Columns.Add("EndDate");

        if (contract != null && contract.Length > 0)
        {
            for (int icount = 0; icount < contract.Length; icount++)
            {
                if (contract[icount].Active.ToString().Equals("True"))
                {
                    dtContract.Rows.Add(new object[]
                                            {
                                                contract[icount].ContractID, contract[icount].Name,
                                                contract[icount].Description, contract[icount].State.Name, "Active",
                                                contract[icount].Contract,
                                                Convert.ToDateTime(contract[icount].StartDate).ToString("MM/dd/yyyy"),
                                                Convert.ToDateTime(contract[icount].EndDate).ToString("MM/dd/yyyy")
                                            });
                }
                else
                    dtContract.Rows.Add(new object[]
                                            {
                                                contract[icount].ContractID, contract[icount].Name,
                                                contract[icount].Description, contract[icount].State.Name, "Deactivated",
                                                contract[icount].Contract,
                                                Convert.ToDateTime(contract[icount].StartDate).ToString("MM/dd/yyyy"),
                                                Convert.ToDateTime(contract[icount].EndDate).ToString("MM/dd/yyyy")
                                            });
            }

            grdContract.DataSource = dtContract;
            grdContract.DataBind();
            ViewState["DSGRID"] = dtContract;

            txtName.Text = "";
            txtDescription.Text = "";
            txtContract.Text = "";
            ddlstate.SelectedIndex = 0;
            hfContractID.Value = "";
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "No records Found";
            btnActivate.Enabled = false;
            btnDelete.Enabled = false;
            btnDeActivate.Enabled = false;
        }
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the contracts. 
    /// </summary>
    private void GetContract()
    {
        var masterDal = new MasterDAL();
        var listContract = masterDal.GetContract(string.Empty, 0);

        EContract[] contract = null;
        if (listContract != null)
            contract = listContract.ToArray();
      
        var dtContract = new DataTable();
        dtContract.Columns.Add("ContractID", typeof(int));
        dtContract.Columns.Add("contractname");
        dtContract.Columns.Add("description");
        dtContract.Columns.Add("state");
        dtContract.Columns.Add("active");
        dtContract.Columns.Add("contract");
        dtContract.Columns.Add("StartDate");
        dtContract.Columns.Add("EndDate");

        if (contract != null)
            if (contract.Length > 0)
            {
                for (int icount = 0; icount < contract.Length; icount++)
                {
                    if (contract[icount].Active.ToString().Equals("True"))
                    {
                        dtContract.Rows.Add(new object[] { contract[icount].ContractID, contract[icount].Name, contract[icount].Description, contract[icount].State.Name, "Active", contract[icount].Contract, Convert.ToDateTime(contract[icount].StartDate).ToString("MM/dd/yyyy"), Convert.ToDateTime(contract[icount].EndDate).ToString("MM/dd/yyyy") });
                    }
                    else
                        dtContract.Rows.Add(new object[] { contract[icount].ContractID, contract[icount].Name, contract[icount].Description, contract[icount].State.Name, "Deactivated", contract[icount].Contract, Convert.ToDateTime(contract[icount].StartDate).ToString("MM/dd/yyyy"), Convert.ToDateTime(contract[icount].EndDate).ToString("MM/dd/yyyy") });
                }


                if (ViewState["SortExp"].ToString() == "name")
                {
                    dtContract.DefaultView.Sort = (SortDirection)ViewState["ContractSort"] == SortDirection.Ascending ? "contractname asc" : "contractname desc";
                }
                else
                {
                    dtContract.DefaultView.Sort = (SortDirection)ViewState["StateSort"] == SortDirection.Ascending ? "State asc" : "State desc";
                }

                dtContract = dtContract.DefaultView.ToTable();

                grdContract.DataSource = dtContract;
                grdContract.DataBind();
                ViewState["DSGRID"] = dtContract;

                txtName.Text = "";
                txtDescription.Text = "";
                txtContract.Text = "";
                ddlstate.SelectedIndex = 0;
                hfContractID.Value = "";
            }
            else
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = "No records Found";
                btnActivate.Enabled = false;
                btnDelete.Enabled = false;
                btnDeActivate.Enabled = false;
            }
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the contract which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateContract()
    {
        var masterDal = new MasterDAL();

        var contract = new EContract
                           {
                               Description = txtDescription.Text,
                               Name = txtName.Text,
                               Contract = txtContract.Text,
                               Active = true
                           };
        var state = new EState {StateID = Convert.ToInt32(ddlstate.SelectedValue)};

        contract.State = state;
        contract.StartDate = txtStartDate.Text;
        contract.EndDate = txtEndDate.Text;
        Int64 returnresult;
        if (hfContractID.Value.Equals(""))
        {

            returnresult = masterDal.SaveContract(contract, Convert.ToInt32(EOperationMode.Insert));
            divErrorMsg.InnerText = returnresult == 0
                                        ? "Contract has been added successfully."
                                        : "Contract has been not added due to internal error.";
        }
        else
        {
            contract.ContractID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdContract.Rows[Convert.ToInt32(hfContractID.Value)].DataItemIndex]["ContractID"]);
           
            returnresult = masterDal.SaveContract(contract, Convert.ToInt32(EOperationMode.Update));
            divErrorMsg.InnerText = returnresult == 0
                                        ? "Contract has been updated successfully."
                                        : "Contract has been not updated due to internal error.";
        }
        divErrorMsg.Visible = true;
        hfContractID.Value = "";
        GetContract();
    }

    /// <summary>
    /// this method is called on save button click which calls UpdateContract
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateContract();
    }

    /// <summary>
    /// this method is used to delete the selected contract(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        var masterDal = new MasterDAL();
        string contracts = GetSelectedContractIDs();
       
        if (contracts.Length > 0)
        {
            var returnresult = masterDal.SaveContract(contracts, Convert.ToInt32(EOperationMode.Delete));
           
            GetContract();
            divErrorMsg.Visible = true;

            divErrorMsg.InnerText = returnresult == 0
                                       ? "Contract has been deleted successfully."
                                       : "Contract has been not deleted due to internal error.";
            hfContractID.Value = "";
        }

    }

    
    /// <summary>
    /// Gets the selected contract Ids.
    /// </summary>
    /// <returns></returns>
    private string GetSelectedContractIDs()
    {
        string strSelectedContracts = "";

        for (int i = 0; i < grdContract.Rows.Count; i++)
        {
            var chkContractSelecter = (HtmlInputCheckBox)grdContract.Rows[i].FindControl("chkRowChild");
            if (chkContractSelecter.Checked)
            {
                strSelectedContracts  += Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdContract.Rows[i].DataItemIndex]["ContractID"]) + ", ";
            }
        }

        if (strSelectedContracts.Length > 0)
            strSelectedContracts = strSelectedContracts.Remove(strSelectedContracts.LastIndexOf(", "));

        return strSelectedContracts;

    }


    /// <summary>
    /// this method is used for deactivating the selected Contract(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
       var masterDal = new MasterDAL();
        string contracts = GetSelectedContractIDs();
        
        if (contracts.Length > 0)
        {
            var returnresult = masterDal.SaveContract(contracts, Convert.ToInt32(EOperationMode.DeActivate));
            
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0
                                       ? "Contract has been deactivated successfully."
                                       : "Contract has been not deactivated due to internal error.";
            hfContractID.Value = "";
            GetContract();
        }

    }

    /// <summary>
    /// this method is used for activating the selected Contract(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        var masterDal = new MasterDAL();
        string contracts = GetSelectedContractIDs();
        
        if (contracts.Length > 0)
        {
            var returnresult = masterDal.SaveContract(contracts, Convert.ToInt32(EOperationMode.Activate));
           
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0
                                        ? "Contract has been activated successfully."
                                        : "Contract has been not activated due to internal error.";
            hfContractID.Value = "";
            GetContract();
        }

    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdContract_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                ViewState["mastercheckboxid"] = chktempheader.ClientID;
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                
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
    protected void grdContract_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdContract.PageIndex = e.NewPageIndex;
        grdContract.DataSource = (DataTable)ViewState["DSGRID"];
        grdContract.DataBind();
    }
    
    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdContract_Sorting(object sender, GridViewSortEventArgs e)
    {
        var dtContract = (DataTable)ViewState["DSGRID"];

        if (e.SortExpression == "State")
        {
            if (((SortDirection)ViewState["StateSort"] == SortDirection.Ascending) && (ViewState["SortExp"].ToString() != "contractname"))
            {
                dtContract.DefaultView.Sort = "State desc";
                ViewState["StateSort"] = SortDirection.Descending;
            }
            else
            {
                dtContract.DefaultView.Sort = "State asc";
                ViewState["StateSort"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = "State";
            ViewState["StateSort"] = SortDirection.Ascending;
        }
        else
        {
            if (((SortDirection)ViewState["ContractSort"] == SortDirection.Ascending) && (ViewState["SortExp"].ToString() != "State"))
            {
                dtContract.DefaultView.Sort = "contractname desc";
                ViewState["ContractSort"] = SortDirection.Descending;
            }
            else
            {
                dtContract.DefaultView.Sort = "contractname asc";
                ViewState["ContractSort"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = "contractname";
            ViewState["StateSort"] = SortDirection.Ascending;
        }
        dtContract = dtContract.DefaultView.ToTable();
        ViewState["DSGRID"] = dtContract;
        grdContract.DataSource = dtContract;
        grdContract.DataBind();
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
