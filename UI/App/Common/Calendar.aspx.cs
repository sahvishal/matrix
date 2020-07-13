using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using EFranchisee = Falcon.Entity.Franchisee.EFranchisee;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.Core.Users.Enum;

// TODO: Remove unnecessary try catch blocks just for error tracing.
public partial class App_Common_Calander : Page
{

    public string FranchiseeId
    {
        get
        {
            return CurrentRole == Roles.FranchisorAdmin ? "0" : IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId.ToString();
        }
    }

    public string SalesRepId
    {
        get { return CurrentRole != Roles.SalesRep ? "0" : IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId.ToString(); }
    }

    public Roles CurrentRole
    {
        get
        {
            return (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId;
        }
    }

    #region Events

    /// <summary>
    /// Loads the appointment page and fill the appointments of the current moth
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    void Page_Load(Object o, EventArgs e)
    {
        var franchisorMaster = (Franchisor_FranchisorMaster)this.Master;
        this.Page.Title = "View Calendar";
        franchisorMaster.settitle("View Calendar");
        franchisorMaster.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        franchisorMaster.setCalendarUC();
        franchisorMaster.hideucsearch();

        if (!IsPostBack)
        {
            var strJs = new System.Text.StringBuilder();
            strJs.Append(" <script language = 'Javascript'>setContextMenu('Year'); </script>");
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "JSCode", strJs.ToString(), false);

            var tbltemp = new DataTable();
            tbltemp.Columns.Add("Name");
            tbltemp.Columns.Add("Address");
            tbltemp.Columns.Add("FranchiseeID");

            OrganizationListModel eFranchisees = null;
            OrganizationEditModel eFranchisee = null;

            if (CurrentRole == Roles.FranchisorAdmin)
            {

                var listFranchisee = IoC.Resolve<IOrganizationService>().GetOrganizationListModel(OrganizationType.Franchisee);
                if (listFranchisee != null)
                {
                    eFranchisees = listFranchisee;
                    foreach (OrganizationBasicInfoModel franchisee in eFranchisees.Organizations)
                    {
                        tbltemp.Rows.Add(new object[] {franchisee.Name, franchisee.Address.ToString(), franchisee.Id});

                    }
                }
            }
            else //if (_userShellModuleRole.ShellType == "Franchisee")
            {
                grdFranchisee.Enabled = false;
                // Need to replace t with the ListModel instead of Edit Model
                OrganizationEditModel listFranchisee = IoC.Resolve<IOrganizationService>().GetOrganizationCreateModel(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId);
                if (listFranchisee != null)
                {
                    eFranchisee = listFranchisee;

                    tbltemp.Rows.Add(new object[] {eFranchisee.Name, eFranchisee.BusinessAddress.ToString(), eFranchisee.Id});
                }
            }

            if (CurrentRole == Roles.SalesRep)
            {
                sBloack.Visible = false;
                pnlAddFranchisee.Visible = false;
            }

            grdFranchisee.DataSource = tbltemp;
            grdFranchisee.DataBind();
            if (CurrentRole == Roles.SalesRep || CurrentRole == Roles.FranchiseeAdmin)
            {
                ((CheckBox)grdFranchisee.Rows[0].Cells[0].FindControl("chkboxitem")).Checked = true;
            }
            SetPageForRole();
        }
    }

    private void SetPageForRole()
    {
        switch (CurrentRole)
        {
            case Roles.FranchisorAdmin:
                BindFranchiseeDropDown();
                BindSalesRepresentativeDropDown();
                SalesRepSpan.Visible = true;
                FranchiseeSpan.Visible = true;
                break;
            case Roles.FranchiseeAdmin:
                BindSalesRepresentativeDropDown();
                SalesRepSpan.Visible = true;
                FranchiseeSpan.Visible = false;
                break;
            case Roles.SalesRep:
                SalesRepSpan.Visible = false;
                FranchiseeSpan.Visible = false;
                break;
        }
    }

    private void BindSalesRepresentativeDropDown()
    {
        ISalesRepresentativeRepository salesRepresentativeRepository = new SalesRepresentativeRepository();
        SalesRepDropDown.DataSource = CurrentRole == Roles.FranchisorAdmin ? salesRepresentativeRepository.GetAllSalesRepresentatives() : GetSalesRepresentativesForFranchisee(Convert.ToInt64(FranchiseeId));
        SalesRepDropDown.DataTextField = "Name";
        SalesRepDropDown.DataValueField = "SalesRepresentativeId";
        SalesRepDropDown.DataBind();
        SalesRepDropDown.Items.Insert(0, new ListItem("--All--", "0"));
    }

    private void BindFranchiseeDropDown()
    {
        IOrganizationRepository franchiseeRepository = new OrganizationRepository();
        FranchiseeDropDown.DataSource = franchiseeRepository.GetOrganizationCollection(OrganizationType.Franchisee);
        FranchiseeDropDown.DataTextField = "Name";
        FranchiseeDropDown.DataValueField = "Id";
        FranchiseeDropDown.DataBind();
        FranchiseeDropDown.Items.Insert(0, new ListItem("--All--", "0"));
    }

    private List<SalesRepresentative> GetSalesRepresentativesForFranchisee(long franchiseeId)
    {
        ISalesRepresentativeRepository salesRepresentativeRepository = new SalesRepresentativeRepository();
        return franchiseeId == 0 ? salesRepresentativeRepository.GetAllSalesRepresentatives() : salesRepresentativeRepository.GetSalesRepresentativesForFranchisee(franchiseeId);
    }

    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        var otherDal = new OtherDAL();
        EBlockedDay objBlockday = new EBlockedDay
                                      {
                                          BlockedDate = hfBlockDate.Value,
                                          BlockedReason = txtBlockReason.Text,
                                          IsActive = true
                                      };

        var sessionContext = IoC.Resolve<ISessionContext>();

        //TODO: call by javascript
        EBlockedDayFranchisee[] objBlockdayFranchisee = GetSelectedFranchisee();


        if ((sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin)) && ((objBlockdayFranchisee.Length == grdFranchisee.Rows.Count) || (objBlockdayFranchisee.Length == 0)))
        {
            objBlockday.IsGlobal = true;
        }
        else if (sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            objBlockday.IsGlobal = false;
        }


        objBlockday.BlockDayFranchisee = objBlockdayFranchisee.ToList();

        Int64 returnresult = otherDal.SaveBlockedDay(objBlockday, Convert.ToInt32(EOperationMode.Insert));
        if (returnresult == 0)
        {
            returnresult = 9999990;
        }

        hfBlockDate.Value = "";
        txtBlockDate.Text = "";
        txtBlockReason.Text = "";
        //setView(ViewState["ViewType"].ToString());

        CheckBox chk = (CheckBox)grdFranchisee.HeaderRow.FindControl("chkboxheader");

        System.Text.StringBuilder strJsCloseWindow = new System.Text.StringBuilder();
        strJsCloseWindow.Append(" <script language = 'Javascript'> document.getElementById('" + chk.ClientID + "').checked=false;GridMasterCheck(); </script>");
        ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdFranchisee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkitemtemp = (CheckBox)e.Row.FindControl("chkboxitem");
            if (chkitemtemp != null)
            {
                chkitemtemp.Attributes["onClick"] = "GridChildCheck();";
            }
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chkheader = (CheckBox)e.Row.FindControl("chkboxheader");
            if (chkheader != null)
            {
                chkheader.Attributes["onClick"] = "GridMasterCheck();";
            }

        }
    }
    #endregion

    # region "Methods"


    /// <summary>
    /// Get the list of Franchisee 
    /// </summary>
    /// <returns></returns>
    private EBlockedDayFranchisee[] GetSelectedFranchisee()
    {
        ArrayList ListFranchisee = new ArrayList();

        for (int i = 0; i < grdFranchisee.Rows.Count; i++)
        {
            CheckBox chkTestSelecter = new CheckBox();
            chkTestSelecter = (CheckBox)grdFranchisee.Rows[i].Cells[0].FindControl("chkboxitem");
            if (chkTestSelecter.Checked && grdFranchisee != null && grdFranchisee.DataKeys != null)
            {

                EBlockedDayFranchisee objBlockedFranchisee = new EBlockedDayFranchisee
                {
                    Franchisee = new EFranchisee
                    {
                        FranchiseeID = Convert.ToInt32(grdFranchisee.DataKeys[grdFranchisee.Rows[i].DataItemIndex].Value)
                    },
                    IsActive = true
                };
                ListFranchisee.Add(objBlockedFranchisee);
            }
        }

        EBlockedDayFranchisee[] objBlockedDayFranchisee = new EBlockedDayFranchisee[ListFranchisee.Count];
        for (int i = 0; i < ListFranchisee.Count; i++)
        {
            objBlockedDayFranchisee[i] = new EBlockedDayFranchisee();
            objBlockedDayFranchisee[i] = (EBlockedDayFranchisee)ListFranchisee[i];
        }

        return objBlockedDayFranchisee;
    }

    # endregion



}
