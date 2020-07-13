using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.UI.Extentions;

public partial class Customer_CustomerMaster : MasterPage
{

    public string SetBreadcrumb
    {
        get { return spnRoot.InnerHtml; }
        set { spnRoot.InnerHtml = value; }
    }

    public string ViewType { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        YearLiteral.Text = DateTime.Today.Year.ToString();

        ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
        VersionNumberLiteral.Text = systemInformationRepository.GetSystemVersionNumber();

        if (IsPostBack == true) return;
        spcurdate.InnerText = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
        Ucmenucontrol1.RoleName = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias;

        Ucwelcomebox1.SetLinks(Roles.Customer);
        SetCobranding();
    }

    protected void imgPageView_Click(object sender, ImageClickEventArgs e)
    {



    }
    public void SetPageView(string strViewType)
    {
        ViewType = strViewType;
        var imgAdvocateDashBoard = (ImageButton)this.FindControl("imgAdvocateDashBoard");


        if ((ConfigurationManager.AppSettings["isTesting"] != null) && (ConfigurationManager.AppSettings["isTesting"] == "Yes"))
        {
            // need to check whether this customer have advocate account or not
        }
        else
        {
            imgAdvocateDashBoard.Visible = false;
        }
    }

    protected void PageView_Click(object sender, EventArgs e)
    {
        var imgSender = (Button)sender;
        switch (imgSender.CommandArgument)
        {
            case "DashBoard":
                Response.RedirectUser("~/App/Customer/HomePage.aspx");
                break;

            case "EventRegistration":
                Response.RedirectUser("~/App/Customer/SearchEvent.aspx");
                break;
            case "AdvocateDashBoard":
                Response.RedirectUser("~/App/MarketingPartner/AffiliateDashboard.aspx");
                break;
            case "AdvocateCampaign":
                Response.RedirectUser("~/App/MarketingPartner/CreateNewCampaign.aspx");
                break;

            case "AdvocatePayhistory":
                Response.RedirectUser("~/App/MarketingPartner/SearchEvent.aspx");
                break;

            case "HealthTools":
                Response.RedirectUser("~/App/Customer/HealthTools.aspx");
                break;

            case "OpenforIdeas":
                Response.RedirectUser("~/App/Customer/OpenIdeas.aspx");
                break;

        }
    }

    public void SetCobranding()
    {
        CobrandingDiv.Style.Add(HtmlTextWriterStyle.Display, "none");

        var eventService = IoC.Resolve<IEventService>();
        var events = eventService.GetEventsByCustomerId(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        if (!events.IsNullOrEmpty())
        {
            var recentEvent = events.Select(e => e).First();
            var fileDate = DateTime.Today; 

            var min = Math.Abs(fileDate.Ticks - recentEvent.EventDate.Ticks);
            foreach (var eventData in events)
            {
                var diff = Math.Abs(fileDate.Ticks - eventData.EventDate.Ticks);
                if (diff < min)
                {
                    min = diff;
                    recentEvent = eventData;
                }
            }

            if(recentEvent.EventType == EventType.Corporate)
            {
                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = corporateAccountRepository.GetbyEventId(recentEvent.Id);
                if(account.AllowCobranding)
                {
                    var organization = IoC.Resolve<IOrganizationRepository>().GetOrganizationbyId(account.Id);
                    if(organization.LogoImageId>0)
                    {
                        var file = IoC.Resolve<IUniqueItemRepository<File>>().GetById(organization.LogoImageId);
                        var mediaLocation = IoC.Resolve<IMediaRepository>().GetOrganizationLogoImageFolderLocation();

                        CobrandingDiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                        CobrandingLogo.Src = mediaLocation.Url + file.Path;
                    }
                }
            }
        }

    }
}
