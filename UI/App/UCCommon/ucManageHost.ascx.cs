using System;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisee;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Other;
using System.Web.UI;
using Falcon.App.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Users.Repositories;

public partial class App_UCCommon_ucManageHost : System.Web.UI.UserControl
{
    /// <summary>
    /// Get the boolean value to display salesperson dropdown
    /// </summary>
    public bool FranchiseeView { get; set; }
    protected string QuickSearch { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(Request["Action"]))
        {
            if (!string.IsNullOrEmpty(Request["Type"]))
            {
                // host
                if (Request.UrlReferrer != null && Request.UrlReferrer.AbsolutePath.IndexOf("AddNewHost.aspx") >= 0)//this message should appear only when a host is added.
                {
                    if (Request["Type"].Equals("Host") && Request["Action"].Equals("Added"))
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), "jscodealertmessage", "alert('Host added successfully!');", true);
                    }
                }

            }
        }
        if (!string.IsNullOrEmpty(Request["Parent"]))
        {
            if (Request["Parent"].Equals("Host"))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "jscodealertmessage", "alert('Host details updated successfully!');", true);
            }
        }

        BindSalesRepDropDown();
        BindDropDown();
        if (!IsPostBack)
        {
            txtZipcode.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            ddlProspectRecords.Attributes.Add("onchange", "return LoadProspectTableonPageSizeChange();");

            //Sets the visibility of salesperson dropdown according to salesrep or franchisor login
            if (FranchiseeView == false)
            {
                ddlFranchisee.SelectedValue = "0";
                ddlFranchisee.Visible = false;
                spanFranchisee.Visible = false;
            }
            else
            {

                var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
                
                if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    spanFranchisee.Visible = true;
                    ddlFranchisee.Visible = true;
                }
                else if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    spanFranchisee.Visible = false;
                    ddlFranchisee.Visible = false;
                    ddlFranchisee.SelectedValue = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId.ToString();
                    SpanDistanceDrpoDown.Style.Add(HtmlTextWriterStyle.MarginLeft, "50px");
                }
            }

            BindMiles();
            // Bind all salesRep for the same territory as this SalesRep.
            BindSalesRepOnTerritory();

            // check when came from redirected page
            if (!string.IsNullOrEmpty(Request["hostname"]))
            {
                if (Session["ParameterStringHost"] != null)
                {
                    var parameterString = (string[])Session["ParameterStringHost"];
                    parameterString[0] = Request["hostname"];
                    Session["ParameterStringHost"] = parameterString;
                }
                else
                {
                    var parameterString = new string[17];
                    parameterString[0] = Request["hostname"];
                    Session["ParameterStringHost"] = parameterString;
                }
                QuickSearch = Request.QueryString["QuickSearch"] != null ? "True" : "False";
            }

            //Setting the Search Parameter
            if (Session["ParameterStringHost"] != null)
            {
                var parameterString = (string[])Session["ParameterStringHost"];
                txtProspectName.Text = parameterString[0];//Name
                txtStartDate.Text = parameterString[1];//Start date
                txtEndDate.Text = parameterString[2];//End date
                if (!string.IsNullOrEmpty(parameterString[3]))
                    ddlSalesPerson.SelectedIndex = Convert.ToInt32(parameterString[3]);//Sales Person

                ddlDistance.SelectedValue = parameterString[4];//Distace
                txtZipcode.Text = parameterString[5];//ZipCode

                if (!string.IsNullOrEmpty(parameterString[6]))
                    ddlStatus.SelectedValue = parameterString[6];// Host Status

                if (!string.IsNullOrEmpty(parameterString[7]))
                    ddlEvents.SelectedValue = parameterString[7];// Has event

                ddlTerritory.SelectedValue = parameterString[8];//Territory

                hidPageNumber.Value = !string.IsNullOrEmpty(parameterString[9]) ? parameterString[9] : "1";

                hidPageSize.Value = !string.IsNullOrEmpty(parameterString[10]) ? parameterString[10] : "10";

                if (!string.IsNullOrEmpty(parameterString[16]))         // Assigned To
                    _assignedTo.SelectedValue = parameterString[16]; // 
            }


            //Set all tab enable when page first loaded
            ibtnEToday.ImageUrl = "~/App/Images/MarketingPartner/today-tab-off_mp.gif";
            ibtnEThisWeek.ImageUrl = "~/App/Images/MarketingPartner/thisweek-tab-off_mp.gif";
            ibtnEThisMonth.ImageUrl = "~/App/Images/MarketingPartner/thismonth-tab-off_mp.gif";
            ibtnEAll.ImageUrl = "~/App/Images/MarketingPartner/All-tab-active_mp.gif";

            Page.ClientScript.RegisterStartupScript(typeof(string), "jscodestartprospect", "GetProspectGridTable('All');", true);
        }
    }

    /// <summary>
    /// Binds all dropdown (Status,Type and SalesRep)
    /// </summary>
    private void BindDropDown()
    {
        //Fill status dropdown
        GetStatus();


        IOrganizationRepository repository = new OrganizationRepository();
        var franchisees = repository.GetOrganizationIdNamePairs(Falcon.App.Core.Users.Enum.OrganizationType.Franchisee);

        if (franchisees != null)
        {
            ddlFranchisee.DataSource = franchisees;
            ddlFranchisee.DataTextField = "FirstValue";
            ddlFranchisee.DataValueField = "SecondValue";
            ddlFranchisee.DataBind();
            ddlFranchisee.Items.Insert(0, new ListItem("ALL", "0"));
        }

        //Fill Events dropdown
        var li = new ListItem { Text = "All", Value = "0" };
        ddlEvents.Items.Add(li);
        li = new ListItem { Text = "Yes", Value = "1" };
        ddlEvents.Items.Add(li);
        li = new ListItem { Text = "No", Value = "2" };
        ddlEvents.Items.Add(li);

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        var franchisorDal = new FranchisorDAL();
        var listTerritory = franchisorDal.GetFranchiseeTerritory("", "", 4,
            currentSession.CurrentOrganizationRole.OrganizationRoleUserId, currentSession.CurrentOrganizationRole.RoleId, currentSession.UserId);

        ETerritory[] objTerritory = null;
        if (listTerritory != null) objTerritory = listTerritory.ToArray();
        if (objTerritory != null && objTerritory.Length > 0)
        {
            for (int count = 0; count < objTerritory.Length; count++)
            {
                ddlTerritory.Items.Add(new ListItem(objTerritory[count].Name, objTerritory[count].TerritoryID.ToString()));
            }
        }
        ddlTerritory.Items.Insert(0, new ListItem("Select Territory", "0"));

        //Fill type dropdown      
        var franchiseeDal = new FranchiseeDAL();
        var listProspectKeyPairValue = franchiseeDal.GetProspectTypeKeyValue();

        if (listProspectKeyPairValue != null)
        {
            EKeyValuepair[] prospectType = listProspectKeyPairValue.ToArray();
            if (prospectType.Length > 0)
            {
                _hostType.Items.Add(new ListItem("ALL", "0"));
                for (int count = 0; count < prospectType.Length; count++)
                {
                    _hostType.Items.Add(new ListItem(prospectType[count].Value, prospectType[count].Key.ToString()));
                }
            }
        }

    }

    /// <summary>
    /// Add the items in status dropdown
    /// </summary>
    private void GetStatus()
    {
        ddlStatus.Items.Insert(0, new ListItem("Unknown", "0"));
        ddlStatus.Items.Insert(1, new ListItem("Hot", "1"));
        ddlStatus.Items.Insert(2, new ListItem("Warm", "3"));
        ddlStatus.Items.Insert(3, new ListItem("Cold", "2"));
    }

    /// <summary>
    /// Method to display the miles for distance
    /// </summary>    
    private void BindMiles()
    {
        // Bind Default Listitem
        ddlDistance.Items.Add(new ListItem("Select Distance", "0"));
        ddlDistance.Items.Add(new ListItem("Exact Matching", "1"));
        for (int i = 5; i <= 50; i += 5)
        {
            ddlDistance.Items.Add(new ListItem(i + " Miles ", i.ToString()));
        }
    }

    /// <summary>
    /// Binds all Sales Rep Drop Down
    /// </summary>
    private void BindSalesRepDropDown()
    {
        //Fill salesrep dropdown

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin) || currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            spanSalesPerson.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else spanSalesPerson.Style.Add(HtmlTextWriterStyle.Display, "none");

        ISalesRepresentativeRepository salesRepRepo = new SalesRepresentativeRepository();
        List<SalesRepresentative> salesReps = null;
        if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            salesReps = salesRepRepo.GetSalesRepresentativesForFranchisee(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId);
        else if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            salesReps = salesRepRepo.GetAllSalesRepresentatives();

        if (salesReps != null)
        {
            ddlSalesPerson.DataSource = salesReps;
            ddlSalesPerson.DataTextField = "NameAsString";
            ddlSalesPerson.DataValueField = "Id";
            ddlSalesPerson.DataBind();
            ddlSalesPerson.Items.Insert(0, new ListItem("All", "0"));
        }

        hidUserId.Value = IoC.Resolve<ISessionContext>().UserSession.UserId.ToString();
        if (FranchiseeView == false)
        {
            if (ddlSalesPerson.Items.FindByValue(hidUserId.Value) != null)
            {
                ddlSalesPerson.Items.FindByValue(hidUserId.Value).Selected = true;
                ddlSalesPerson.Enabled = false;
                _spnDistance.Attributes["class"] = "titletext_default";
            }
        }
        hidRole.Value = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias;
    }

    private void BindSalesRepOnTerritory()
    {
        long franchiseeId = 0;

        var userSession = IoC.Resolve<ISessionContext>().UserSession;

        if (userSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
        {
            var franchiseeDAL = new FranchiseeDAL();
            var franchisee = franchiseeDAL.GetAllSalesRepOnTerritory(userSession.CurrentOrganizationRole.OrganizationRoleUserId);

            if (franchisee.Count > 0)
            {
                _assignedTo.Items.Add(new ListItem("ALL", "0"));
                foreach (EFranchiseeFranchiseeUser t in franchisee)
                {
                    _assignedTo.Items.Add(new ListItem(t.FranchiseeUser.User.FirstName + " " + t.FranchiseeUser.User.LastName, t.FranchiseeFranchiseeUserID.ToString()));
                }
            }
            else
            {

                franchiseeId = userSession.CurrentOrganizationRole.OrganizationId;

                _assignedTo.Items.Add(new ListItem("ALL", "0"));
                try
                {
                    ISalesRepresentativeRepository _salesRepresentativeRepository = new SalesRepresentativeRepository();
                    List<SalesRepresentative> salesRepresentatives = _salesRepresentativeRepository.
                    GetSalesRepresentativesForFranchisee(franchiseeId).OrderBy(sr => sr.Name.FullName).ToList();
                    for (int count = 0; count < salesRepresentatives.Count; count++)
                    {
                        _assignedTo.Items.Add(new ListItem(salesRepresentatives[count].Name.FullName, salesRepresentatives[count].SalesRepresentativeId.ToString()));
                    }
                }
                catch
                { }
            }
            _spnAssignedTo.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            // Hide drop down
            _spnAssignedTo.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

    }
}
