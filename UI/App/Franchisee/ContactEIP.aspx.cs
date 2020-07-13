using System;
using System.Data;
using System.Web.UI.WebControls;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Franchisor;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Lib;

//using HealthYes.Web.UI.FranchisorUserService;

public partial class Franchisee_ContactEIP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Contact EIP";
        Franchisor_FranchisorMaster obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Contact EIP");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Details</a>";
        obj.hideucsearch();
        if (!IsPostBack)
        {
            ViewState["SortContact"] = SortDirection.Ascending;
            GetContactEIP();
        }
    }

    private void GetContactEIP()
    {
        //FranchisorUserService service = new FranchisorUserService();
        //EFranchisorUser[] franchisoruser = service.ContactEIP();

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        FranchisorDAL franchisorDAL = new FranchisorDAL();
        var listFranchisorUser = franchisorDAL.ContactEIP();
        EFranchisorUser[] franchisoruser = null;

        if (listFranchisorUser != null) franchisoruser = listFranchisorUser.ToArray();

        DataTable dtFranchisorUser = new DataTable();
        dtFranchisorUser.Columns.Add("Name");
        dtFranchisorUser.Columns.Add("Address");
        dtFranchisorUser.Columns.Add("Country");
        dtFranchisorUser.Columns.Add("PhoneDirect");
        dtFranchisorUser.Columns.Add("PhoneOther");
        dtFranchisorUser.Columns.Add("Email");
        
        if (franchisoruser != null)
        {
            for (int icount = 0; icount < franchisoruser.Length; icount++)
            {
                string Name = CommonClass.FormatName(franchisoruser[icount].User.FirstName, "", franchisoruser[icount].User.LastName);
                string Address = CommonClass.FormatAddress(franchisoruser[icount].User.HomeAddress.Address1, franchisoruser[icount].User.HomeAddress.Address2, franchisoruser[icount].User.HomeAddress.City, franchisoruser[icount].User.HomeAddress.State, franchisoruser[icount].User.HomeAddress.Zip);
                dtFranchisorUser.Rows.Add(new object[] { Name, Address,franchisoruser[icount].User.HomeAddress.Country,objCommonCode.FormatPhoneNumberGet(franchisoruser[icount].User.PhoneCell), objCommonCode.FormatPhoneNumberGet(franchisoruser[icount].User.PhoneOffice), franchisoruser[icount].User.EMail1});

            }
        }
        switch ((SortDirection)ViewState["SortContact"])
        {
            case SortDirection.Descending:
                dtFranchisorUser.DefaultView.Sort = "name desc";
                break;
            default:
                dtFranchisorUser.DefaultView.Sort = "name asc";
                break;
        }

        dtFranchisorUser = dtFranchisorUser.DefaultView.ToTable();
        ViewState["DSGRID"] = dtFranchisorUser;
        gridcontacteip.DataSource = dtFranchisorUser;
        gridcontacteip.DataBind(); 

    }
    protected void gridcontacteip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridcontacteip.PageIndex = e.NewPageIndex;
        gridcontacteip.DataSource = ViewState["DSGRID"];
        gridcontacteip.DataBind();
    }
    protected void gridcontacteip_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtFranchisorUser = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortContact"] == SortDirection.Descending)
        {
            dtFranchisorUser.DefaultView.Sort = "name asc";
            ViewState["SortContact"] = SortDirection.Ascending;
        }
        else
        {
            dtFranchisorUser.DefaultView.Sort = "name desc";
            ViewState["SortContact"] = SortDirection.Descending;
        }
        dtFranchisorUser = dtFranchisorUser.DefaultView.ToTable();

        gridcontacteip.DataSource = dtFranchisorUser;
        ViewState["DSGRID"] = dtFranchisorUser;

        gridcontacteip.DataBind();
    }
}
