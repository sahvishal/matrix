using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class CallCenter_ucSearchCustomer : System.Web.UI.UserControl
{
    #region "Variables"
    enum SearchCustomerType { SEARCH_CUSTOMER = 0, SEARCH_ADVANCE_CUSTOMER = 1 };

    private string strCallType;
#endregion    

    #region "Form Events"
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            //this.GetDropDownInfo();
            ViewState["CallType"] = CallType;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnsearch_Click(object sender, ImageClickEventArgs e)
    {
        GetCustomerList(SearchCustomerType.SEARCH_CUSTOMER);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnadvsearch_Click(object sender, ImageClickEventArgs e)
    {
        GetCustomerList(SearchCustomerType.SEARCH_ADVANCE_CUSTOMER);
    }
    
    
    protected void grdsearchcustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdsearchcustomers.PageIndex = e.NewPageIndex;
        grdsearchcustomers.DataSource = (DataTable)ViewState["DSGRID"];
        grdsearchcustomers.DataBind();
    }

    
    protected void grdsearchcustomers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="Page")
        { return; }
        CallType = ViewState["CallType"].ToString();
        if (CallType == "'ResetPassword'")
        {
            Response.RedirectUser("ResetPassword.aspx?CustomerID=" + e.CommandName.ToString());
        }
        else if (CallType == "'ExistingCustomer'")
        {
            // fill the customer information
            Int32 intCustomerID = 0;
            Int32.TryParse(e.CommandName, out intCustomerID);
            if (intCustomerID == 0)
            { return; }


            Response.RedirectUser("../Wizard/ExistingCustomer/PersonalInformation.aspx?CustomerID=" + e.CommandName.ToString());
            
        }
        else if (CallType == "'NewCustomer'")
        {
            Response.RedirectUser("Customer.aspx");
        }
        else if (CallType == "'ReportStatus'")
        {
            Response.RedirectUser("ReportStatus.aspx?CustomerID=" + e.CommandName.ToString());
        }
        
    }
   
    #endregion

    #region "User Functions"
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tempchoice"></param>
    private void GetCustomerList(SearchCustomerType tempchoice)
    {
        var masterDal = new MasterDAL();
        
        var customers = new List<Falcon.Entity.Other.ECustomers>();

        switch (tempchoice)
        {
            case SearchCustomerType.SEARCH_CUSTOMER:
                customers = masterDal.SearchCustomers(0, txtcustomername.Text, "", "", "", "", 0, null, "", "");
                break;

            case SearchCustomerType.SEARCH_ADVANCE_CUSTOMER:
                int customerid = 0;
                if (txtcustomerid.Text.Trim().Length > 0)
                {
                    Int32.TryParse(txtcustomerid.Text.Trim(), out customerid);
                }

                customers = masterDal.SearchCustomers(customerid, txtadvcustomername.Text, txtstate.Text, txtcity.Text, txtzip.Text, txtregdate.Text, 1, null, "", ""); 
                break;
        }
        BindCustomerList(customers);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="customers"></param>
    private void BindCustomerList(List<Falcon.Entity.Other.ECustomers> customers)
    {
        errordiv.InnerText = "";
        grdsearchcustomers.DataSource =null;
        grdsearchcustomers.DataBind();
        DataTable dtcustomerlist = new DataTable("CustomerList");
        dtcustomerlist.Columns.Add("CustomerID");
        dtcustomerlist.Columns.Add("CustomerName");
        dtcustomerlist.Columns.Add("Address");
        dtcustomerlist.Columns.Add("State");
        dtcustomerlist.Columns.Add("City");
        dtcustomerlist.Columns.Add("Zip");
       

        for (int icount = 0; icount < customers.Count; icount++)
        {
            string address = customers[icount].User.HomeAddress.Address1;
            if (customers[icount].User.HomeAddress.Address2.Length > 0)
                address += ", " + customers[icount].User.HomeAddress.Address2;

            string customername = customers[icount].User.FirstName;
            if (customers[icount].User.MiddleName.Length > 0)
                customername += " " + customers[icount].User.MiddleName;
            customername += " " + customers[icount].User.LastName;

            dtcustomerlist.Rows.Add(new object[] { customers[icount].CustomerID, customername, address, customers[icount].User.HomeAddress.State, customers[icount].User.HomeAddress.City, customers[icount].User.HomeAddress.Zip });
        }


        DataView dv = new DataView();
        dv.Table = dtcustomerlist;
        DataTable dt =  dv.ToTable(true, new String[]{"CustomerID","CustomerName","Address","State","City","Zip"});
        if (dt.Rows.Count > 0)
        {
            ViewState["DSGRID"] = dt;
            grdsearchcustomers.DataSource = dt;
            grdsearchcustomers.DataBind();
        }
        else
        {
            errordiv.InnerText = "No record found";
        }
    }

    #endregion

    #region "Property"
    public  string CallType
    {
        get { return strCallType; }
        set { strCallType = value; }
    }
    #endregion
}
