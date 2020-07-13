using System;
using System.Web;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;

//using HealthYes.Web.UI.UserService;

public partial class ucwelcomebox : System.Web.UI.UserControl
{
    protected Int32 mintTimeout = ((HttpContext.Current.Session.Timeout * 60) - 5) * 1000;

    

    /// <summary>
    /// Load Event sets role menu control for the user logged in
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{

        //    Response.AppendHeader("Refresh", Convert.ToString(((HttpContext.Current.Session.Timeout * 60) - 5), System.Globalization.CultureInfo.CurrentCulture) + "; Url=" + ResolveUrl("~/APP/Logoff.aspx?st=st"));
        //    //Response.AppendHeader("Refresh", Convert.ToString(((HttpContext.Current.Session.Timeout * 60) - 5), System.Globalization.CultureInfo.CurrentCulture) + "; Url=javascript: var abc = confirm('Do you want to logout or stay back?'); debugger; if(abc == true) window.location.pathname = '" + ResolveUrl("~/APP/Logoff.aspx?st=st") + "'; else { window.location.reload(); }"); 

        //}
    }
    #region "User Built Functions"
    /// <summary>
    /// Sets link href's according to the role with which
    /// user is logged in.
    /// </summary>
    /// <param name="userrole"></param>
    public void SetLinks(Roles userrole)
    {                
        // Nullified when role is changed
        Session["ViewTypeContact"] = null; // This is used for controlling View of Manage Contact Screen.
        var orgName = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationName;

        switch (userrole)
        {                
            case Roles.FranchiseeAdmin:               
                pFranchiseeNameHeader.Visible = true;
                sFranchiseeNameHeader.InnerHtml = "&nbsp;Franchisee:";
                dvFranchiseeNameHeader.InnerText = orgName;
                break;

            case Roles.Technician:               
                pFranchiseeNameHeader.Visible = true;
                sFranchiseeNameHeader.InnerHtml = "&nbsp;Franchisee:";
                dvFranchiseeNameHeader.InnerText = orgName;
                break;

            case Roles.SalesRep:               
                pFranchiseeNameHeader.Visible = true;
                sFranchiseeNameHeader.InnerHtml = "&nbsp;Franchisee:";
                dvFranchiseeNameHeader.InnerText = orgName;
                break;

            case Roles.MedicalVendorAdmin:               
                pFranchiseeNameHeader.Visible = true;
                sFranchiseeNameHeader.InnerHtml = "&nbsp;Medical Vendor:";
                dvFranchiseeNameHeader.InnerText = orgName;
                break;

            case Roles.FranchisorAdmin:               
                pFranchiseeNameHeader.Visible = false;
                break;

            case Roles.Customer:                
                pFranchiseeNameHeader.Visible = false;
                pBeta.Style["display"] = "none";
                break;

            case Roles.OperationManager:
                break;

            case Roles.CallCenterRep:               
                pFranchiseeNameHeader.Visible = false;
                break;

            case Roles.CallCenterManager:                
                pFranchiseeNameHeader.Visible = true;
                sFranchiseeNameHeader.InnerHtml = "&nbsp;Call Center:";
                dvFranchiseeNameHeader.InnerText = orgName;
                break;

            case Roles.MedicalVendorUser:                
                pFranchiseeNameHeader.Visible = true;
                sFranchiseeNameHeader.InnerHtml = "&nbsp;Medical Vendor:";
                dvFranchiseeNameHeader.InnerText = orgName;
                pBeta.Style["display"] = "none";
                break;

            case Roles.AdvocateSalesManager:
                pFranchiseeNameHeader.Visible = true;
                sFranchiseeNameHeader.InnerHtml = "&nbsp;Franchisee:";
                dvFranchiseeNameHeader.InnerText = orgName;
                break;
        }
        // BEGIN code to show beta version logo for only pie chart pages
        if ( (Request.Url.ToString().IndexOf("CategoryCustomerReport.aspx") > 0)
            ||(Request.Url.ToString().IndexOf("CategoryCustomerDetails.aspx") > 0) 
            || (Request.Url.ToString().IndexOf("AdvocateCustomerDetails.aspx") > 0))
        {
            pBeta.Style["display"] = "none";
        }
        // END code to show beta version logo for only pie chart pages

    }

    #endregion

}
