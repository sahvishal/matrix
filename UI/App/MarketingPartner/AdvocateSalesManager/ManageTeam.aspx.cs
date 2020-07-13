using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
//using HealthYes.Web.UI.FranchiseeFranchiseeUserService;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisee;
using Falcon.Entity.Franchisee;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Lib;
using EUserShellModuleRole=Falcon.Entity.User.EUserShellModuleRole;

public partial class App_MarketingPartner_AdvocateSalesManager_ManageTeam : System.Web.UI.Page
{
    private Int64 intAdvocateSalesManagerId;

    /// <summary>
    /// post back of page is checked.all the active SecurityQuestion from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Manage Team";

        App_MarketingPartner_AdvocateSalesManager obj = (App_MarketingPartner_AdvocateSalesManager)Master;
        
     
        obj.settitle("Manage Team");
        obj.SetBreadCrumbRoot = "<a href=\"/App/MarketingPartner/AdvocateSalesManager/DashBoard.aspx\">DashBoard</a> ";
        obj.hideucsearch();
       
        intAdvocateSalesManagerId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

        if (IsPostBack) return;

        ViewState["SortDir"] = SortDirection.Ascending;
        getTeamForAdvocateSalesManager();
    }
   
    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdTeam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdTeam.PageIndex = e.NewPageIndex;
        grdTeam.DataSource = (DataTable)ViewState["DSGRID"];
        grdTeam.DataBind();
    }
    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdTeam_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtTeam = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtTeam.DefaultView.Sort = "name desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        else
        {
            dtTeam.DefaultView.Sort = "name asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        dtTeam = dtTeam.DefaultView.ToTable();
        grdTeam.DataSource = dtTeam;
        grdTeam.DataBind();
        ViewState["DSGRID"] = dtTeam;

    }
    /// <summary>
    /// Get the list of sales rep of the 
    /// advocate sales manager franchisee
    /// </summary>
    private void getTeamForAdvocateSalesManager()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        //FranchiseeFranchiseeUserService objFFService = new FranchiseeFranchiseeUserService();
        // Removed Franchisee Service
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();

        List<EFranchiseeFranchiseeUser> objFFUser = null;

        //objFFUser = objFFService.GetTeamForAdvocateSalesManager(1, true, intAdvocateSalesManagerId, true);
        objFFUser = franchiseeDAL.GetTeamForAdvocateSalesManager(1, intAdvocateSalesManagerId);
       
        DataTable dtSalesTeam = new DataTable();
        dtSalesTeam.Columns.Add("Sr");
        dtSalesTeam.Columns.Add("FranchiseeFranchiseeUserID");
        dtSalesTeam.Columns.Add("Name");
        dtSalesTeam.Columns.Add("Phone");
        dtSalesTeam.Columns.Add("Email");
        dtSalesTeam.Columns.Add("FranchiseeID");
        dtSalesTeam.Columns.Add("ManagerID");
        dtSalesTeam.Columns.Add("ManagerName");
        dtSalesTeam.Columns.Add("Status");
        Falcon.Entity.Other.EUser objuser;

        if (objFFUser != null)
        {
            for (int icount = 0; icount < objFFUser.Count; icount++)
            {
                string strName;
                 objuser= objFFUser[icount].FranchiseeUser.User;

                strName= CommonClass.FormatName(objuser.FirstName,objuser.MiddleName,objuser.LastName);

                string strStatus;

                if (objFFUser[icount].AdvocateSalesManagerID == 0)
                {
                     strStatus = "<a href='#'  onclick='return UpdateStatus(" + intAdvocateSalesManagerId + "," + objFFUser[icount].FranchiseeFranchiseeUserID + ",true)'>Add</a> ";
                  
                }
                else if (objFFUser[icount].AdvocateSalesManagerID == intAdvocateSalesManagerId)
                {
                    strStatus = "<a href='#'  onclick='return UpdateStatus(" + intAdvocateSalesManagerId + "," + objFFUser[icount].FranchiseeFranchiseeUserID + ",false)'>Remove</a> ";

                }
                else
                {
                    strStatus = objFFUser[icount].AdvocateSalesManager; 

                }

                if ((objFFUser[icount].FranchiseeUser.User.PhoneHome == "") || (objFFUser[icount].FranchiseeUser.User.PhoneHome == string.Empty))
                {
                    objFFUser[icount].FranchiseeUser.User.PhoneHome = "N/A";
                }
                else
                {
                    objFFUser[icount].FranchiseeUser.User.PhoneHome = objCommonCode.FormatPhoneNumberGet(objFFUser[icount].FranchiseeUser.User.PhoneHome);
                }
                if ((objFFUser[icount].FranchiseeUser.User.EMail1 == "") || (objFFUser[icount].FranchiseeUser.User.EMail1 == string.Empty))
                {
                    objFFUser[icount].FranchiseeUser.User.EMail1 = "N/A";
                }
                dtSalesTeam.Rows.Add(new object[] {icount+1, objFFUser[icount].FranchiseeFranchiseeUserID, 
                    strName  ,objFFUser[icount].FranchiseeUser.User.PhoneHome,objFFUser[icount].FranchiseeUser.User.EMail1, objFFUser[icount].Franchisee.FranchiseeID,objFFUser[icount].AdvocateSalesManagerID,objFFUser[icount].AdvocateSalesManager,strStatus  });
            }
        }


        grdTeam.DataSource = dtSalesTeam;
        ViewState["DSGRID"] = dtSalesTeam;
        grdTeam.DataBind();
    }

}
