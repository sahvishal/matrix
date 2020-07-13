using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisor;
//using HealthYes.Web.UI.FranchisorService;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class App_Franchisee_ViewTerritory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Manage Existing Territory";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("View Territory");
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/Dashboard.aspx\">DashBoard</a>";
        obj.hideucsearch();
        txtZipCode.Attributes.Add("onKeyDown", "return txtkeypress(event);");
        if (!IsPostBack)
        {
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;

            FranchisorDAL franchisorDAL = new FranchisorDAL();

            int roleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);
            int franchiseeID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);

            var listTerritory = franchisorDAL.GetFranchiseeTerritory("", "", 2, franchiseeID, roleID,
                                                                     Convert.ToInt32(currentSession.UserId));

            ETerritory[] objTerritory = null;
            objTerritory = listTerritory.ToArray();

            //objTerritory = objFranchisorService.GetAllActiveTerritoryForFFU(franchiseeID, true, roleID, true, Convert.ToInt32(objUserRole.UserID),true);

            BindData(objTerritory);
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        int roleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);
        int franchiseeID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);

        FranchisorDAL franchisorDal = new FranchisorDAL();

        var listTerritory = franchisorDal.GetFranchiseeTerritory(txtSearch.Text.Trim(), txtZipCode.Text, 3, franchiseeID,
                                                                 roleID, Convert.ToInt32(currentSession.UserId));

        ETerritory[] objTerritory = null;

        if (listTerritory != null) objTerritory = listTerritory.ToArray();

        //objTerritory = objFranchisorService.SearchTerritoryForFFU(txtSearch.Text.Trim(),txtZipCode.Text, franchiseeID, true, roleID, true, Convert.ToInt32(objUserRole.UserID), true);
        BindData(objTerritory);
    }

    protected void grdvTerritory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvTerritory.PageIndex = e.NewPageIndex;
        DataTable dtTemp = (DataTable)ViewState["TerritoryTbl"];
        grdvTerritory.DataSource = dtTemp;
        grdvTerritory.DataBind();
    }

    protected void grdvTerritory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if (row.DataItem == null)
            return;
        GridView gvSalesRepTerritory = new GridView();
        gvSalesRepTerritory = (GridView)row.FindControl("grdvSalesRepTerritory");
        DataTable dt = (DataTable)ViewState["TerritoryTbl"];
        string TerritoryID = ((DataRowView)e.Row.DataItem)["TerritoryID"].ToString();
        dt.DefaultView.RowFilter = "ParentTerritoryID = " + TerritoryID;
        DataTable dtSalesRepTerritory = dt.DefaultView.ToTable();
        HtmlContainerControl divExpandCollapse = (HtmlContainerControl)row.FindControl("divExpandCollapse");
        if (dtSalesRepTerritory.Rows.Count > 0)
        {
            gvSalesRepTerritory.DataSource = dtSalesRepTerritory;
            gvSalesRepTerritory.DataBind();
            divExpandCollapse.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            gvSalesRepTerritory.DataSource = null;
            gvSalesRepTerritory.DataBind();
            divExpandCollapse.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }

    protected void lnkBtnRemove_Click(object sender, EventArgs e)
    {
        LinkButton lnkBtnRemove = (LinkButton)sender;
        string territoryid = lnkBtnRemove.CommandArgument;
        bool result = new bool();
        //bool temp = true;

        FranchisorDAL franchisorDal = new FranchisorDAL();
        result = franchisorDal.DeleteTerritory(territoryid, 0);

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;


        int roleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);
        int franchiseeID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);

        var listTerritory = franchisorDal.GetFranchiseeTerritory(txtSearch.Text.Trim(), txtZipCode.Text, 3, franchiseeID,
                                                                 roleID, Convert.ToInt32(currentSession.UserId));

        ETerritory[] objTerritory = null;

        if (listTerritory != null) objTerritory = listTerritory.ToArray();

        
        BindData(objTerritory);
    }
    # region "Methods"

    //private void BindData(HealthYes.Web.UI.FranchisorService.ETerritory[] objTerritory)
    private void BindData(ETerritory[] objTerritory)
    {
        DataTable dtTerritory = new DataTable();
        dtTerritory.Columns.Add("TerritoryID");
        dtTerritory.Columns.Add("TerritoryName");
        dtTerritory.Columns.Add("Description");
        dtTerritory.Columns.Add("Franchisee");
        dtTerritory.Columns.Add("ParentTerritoryID");
        dtTerritory.Columns.Add("TotalZipsCount");
        dtTerritory.Columns.Add("AssignedZipsCount");
        dtTerritory.Columns.Add("UnassignedZipCount");
        if (objTerritory != null && objTerritory.Length > 0)
        {
            for (int count = 0; count < objTerritory.Length; count++)
            {
                dtTerritory.Rows.Add(new object[] { objTerritory[count].TerritoryID,
                                                    objTerritory[count].Name,
                                                    objTerritory[count].Description,
                                                    objTerritory[count].FranchiseeName,
                                                    objTerritory[count].ParentTerritoryID,
                                                    objTerritory[count].TotalZipCount,
                                                    objTerritory[count].AssignedZipCount,
                                                    objTerritory[count].UnassignedZipCount
                                                    });
            }
            ViewState["TerritoryTbl"] = dtTerritory;
            dtTerritory.DefaultView.RowFilter = "ParentTerritoryID = 0";
            DataTable dtFTerritory = dtTerritory.DefaultView.ToTable();
            grdvTerritory.PageIndex = 0;
            grdvTerritory.DataSource = dtFTerritory;
            grdvTerritory.DataBind();
            divGrd.Visible = true;
            spNoResults.InnerHtml = dtFTerritory.Rows.Count.ToString();
        }
        else
        {
            divGrd.Visible = false;
            grdvTerritory.DataSource = null;
            grdvTerritory.DataBind();
            spNoResults.InnerHtml = "0";
        }


    }

    # endregion

    
    
}
