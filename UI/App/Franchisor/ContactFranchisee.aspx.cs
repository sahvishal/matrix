using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisee;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Lib;
using Falcon.App.Core.Enum;

public partial class Franchisor_ContactFranchisee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Contact Franchisee";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Contact Franchisee");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Details</a>";
        obj.hideucsearch();
        if (!IsPostBack)
        {
            ViewState["SortContactFranchisee"] = SortDirection.Ascending;
            GetContactFranchisee();
        }
    }

    private void GetContactFranchisee()
    {
        List<Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser> franchiseefranchiseeuser=null;
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        if (currentOrgRole.CheckRole((long)Roles.SalesRep))
            franchiseefranchiseeuser = franchiseeDAL.ContactFranchisee(currentSession.CurrentOrganizationRole.OrganizationId.ToString(), 2);
        else            
            franchiseefranchiseeuser = franchiseeDAL.ContactFranchisee(string.Empty, 0);
     
         DataTable dtFranchiseeUser = new DataTable();
        dtFranchiseeUser.Columns.Add("FranhiseeFranchiseeUserID");
        dtFranchiseeUser.Columns.Add("Name");
        dtFranchiseeUser.Columns.Add("Address");
        dtFranchiseeUser.Columns.Add("Phone");
        dtFranchiseeUser.Columns.Add("Email");

        if (franchiseefranchiseeuser != null)
        {
            for (int icount = 0; icount < franchiseefranchiseeuser.Count; icount++)
            {
                string Name = CommonClass.FormatName(franchiseefranchiseeuser[icount].FranchiseeUser.User.FirstName, "", franchiseefranchiseeuser[icount].FranchiseeUser.User.LastName);
                string Address = CommonClass.FormatAddress(franchiseefranchiseeuser[icount].FranchiseeUser.User.HomeAddress.Address1, franchiseefranchiseeuser[icount].FranchiseeUser.User.HomeAddress.Address2, franchiseefranchiseeuser[icount].FranchiseeUser.User.HomeAddress.City, franchiseefranchiseeuser[icount].FranchiseeUser.User.HomeAddress.State, franchiseefranchiseeuser[icount].FranchiseeUser.User.HomeAddress.Country, franchiseefranchiseeuser[icount].FranchiseeUser.User.HomeAddress.Zip);
                dtFranchiseeUser.Rows.Add(new object[] { franchiseefranchiseeuser[icount].FranchiseeFranchiseeUserID,Name, Address, objCommonCode.FormatPhoneNumberGet(franchiseefranchiseeuser[icount].FranchiseeUser.User.PhoneOffice), franchiseefranchiseeuser[icount].FranchiseeUser.User.EMail1 });
                
            }
        }

        if ((SortDirection)ViewState["SortContactFranchisee"] == SortDirection.Descending)
        {
            dtFranchiseeUser.DefaultView.Sort = "name desc";
        }
        else
        {
            dtFranchiseeUser.DefaultView.Sort = "name asc";
        }

        dtFranchiseeUser = dtFranchiseeUser.DefaultView.ToTable();

        gridcontactfranchisee.DataSource = dtFranchiseeUser;
        ViewState["DSGRID"] = dtFranchiseeUser;
        gridcontactfranchisee.DataBind();

    }

    protected void gridcontactfranchisee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridcontactfranchisee.PageIndex = e.NewPageIndex;
        gridcontactfranchisee.DataSource = (DataTable)ViewState["DSGRID"];
        gridcontactfranchisee.DataBind();
    }

    protected void gridcontactfranchisee_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtFranchiseeUser = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortContactFranchisee"] == SortDirection.Descending)
        {
            dtFranchiseeUser.DefaultView.Sort = "name asc";
            ViewState["SortContactFranchisee"] = SortDirection.Ascending;
        }
        else
        {
            dtFranchiseeUser.DefaultView.Sort = "name desc";
            ViewState["SortContactFranchisee"] = SortDirection.Descending;
        }
        dtFranchiseeUser = dtFranchiseeUser.DefaultView.ToTable();

        gridcontactfranchisee.DataSource = dtFranchiseeUser;
        ViewState["DSGRID"] = dtFranchiseeUser;

        gridcontactfranchisee.DataBind();
    }
}
