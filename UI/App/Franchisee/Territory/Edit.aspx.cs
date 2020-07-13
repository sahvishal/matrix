using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users.Domain;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Franchisee.Territory
{
    public partial class Edit : Page
    {
        private const string REDIRECT_URL = "~/App/Franchisee/Dashboard.aspx";
        private static readonly IZipCodeRepository _zipCodeRepository = new ZipCodeRepository();
        private readonly ITerritoryRepository _territoryRepository = new TerritoryRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ftid"]))
                {
                    long franchiseeTerritoryId;
                    long.TryParse(Request.QueryString["ftid"], out franchiseeTerritoryId);
                    Core.Geo.Domain.Territory franchiseeTerritory = GetFranchiseeTerritory(franchiseeTerritoryId);
                    ParentTerritoryNameLiteral.Text = franchiseeTerritory.Name;
                    List<Core.Geo.Domain.Territory> childTerritories = _territoryRepository.GetChildTerritories(franchiseeTerritory.Id);
                    long territoryId = 0;
                    if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
                    {
                        long.TryParse(Request.QueryString["tid"], out territoryId);
                        if (territoryId != 0)
                        {
                            Page.Title = "Edit Subterritory";
                            TerritoryTypeDDL.Enabled = false;
                            WhyTypeDDLIsDisabledLabel.Visible = true;
                            TerritoryTypeDDL.Enabled = false;
                            WhyTypeDDLIsDisabledLabel.Visible = true;
                            LoadTerritoryFields(territoryId);
                        }
                    }
                    List<string> childTerritoryZipCodes = childTerritories.Where(ct => ct.Id != territoryId).
                        Select(ct => ct.ZipCodes.Select(zc => zc.Zip)).SelectMany(zc => zc).Distinct().ToList();
                    SetFranchisorMasterPageOptions();
                    LoadTerritoryTypeDDL();
                    LoadAvailableZipCodesTextBox(franchiseeTerritory.ZipCodes.Where(z => !childTerritoryZipCodes.Contains(z.Zip)));
                }
                else
                {
                    Response.RedirectUser(REDIRECT_URL);
                }
            }
        }

        private void SetFranchisorMasterPageOptions()
        {
            var masterPage = (Franchisor_FranchisorMaster)Master;
            masterPage.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/Territory/Manage.aspx\">Manage Territories</a>";
            masterPage.settitle(Page.Title);
            masterPage.hideucsearch();
        }

        private void LoadAvailableZipCodesTextBox(IEnumerable<ZipCode> zipCodes)
        {
            var availableZipCodes = string.Empty;
            if (!zipCodes.IsEmpty())
            {
                foreach (var zipCode in zipCodes)
                {
                    availableZipCodes += string.Format("{0}, ", zipCode.Zip);
                }
                availableZipCodes = availableZipCodes.Substring(0, availableZipCodes.Length - 2);
            }
            else
            {
                availableZipCodes = "There are no more zip codes available for assignment. If you would like to assign zip codes to this territory, please remove them from other subterritories first.";
            }
            AvailableZipCodesTextBox.Text = availableZipCodes;
        }

        private Core.Geo.Domain.Territory GetFranchiseeTerritory(long franchiseeTerritoryId)
        {
            try
            {
                Core.Geo.Domain.Territory franchiseeTerritory = _territoryRepository.GetTerritory(franchiseeTerritoryId);
                var allowableTerritories = new List<TerritoryType> {TerritoryType.Franchisee, TerritoryType.SalesRep};
                if (!allowableTerritories.Contains(franchiseeTerritory.TerritoryType))
                {
                    Response.RedirectUser(REDIRECT_URL);
                }
                return franchiseeTerritory;
            }
            catch (ObjectNotFoundInPersistenceException<Core.Geo.Domain.Territory>)
            {
                Response.RedirectUser(REDIRECT_URL);
            }
            return null;
        }

        private void LoadTerritoryFields(long territoryId)
        {
            try
            {
                Core.Geo.Domain.Territory territory;
                try
                {
                    territory = _territoryRepository.GetTerritory(territoryId);
                }
                catch (ObjectNotFoundInPersistenceException<Core.Geo.Domain.Territory>)
                {
                    Response.RedirectUser(REDIRECT_URL);
                    return;
                }
                IZipCodeParser zipCodeParser = new ZipCodeParser();
                TerritoryNameTextBox.Text = territory.Name;
                TerritoryDescriptionTextBox.Text = territory.Description;
                TerritoryZipCodesTextBox.Text = zipCodeParser.ParseZipCodesIntoString(territory.ZipCodes);
                TerritoryTypeDDL.SelectedValue = ((byte)territory.TerritoryType).ToString();
                switch (territory.TerritoryType)
                {
                    case TerritoryType.SalesRep:
                        break;
                    default:
                        Response.RedirectUser(REDIRECT_URL);
                        break;
                }
            }
            catch (ObjectNotFoundInPersistenceException<Core.Geo.Domain.Territory>)
            {
                Response.RedirectUser("Edit.aspx");
            }
        }

        protected void SubmitButtonClick(object sender, EventArgs e)
        {
            IZipCodeParser zipCodeParser = new ZipCodeParser();
            IEnumerable<string> selectedZipCodes = zipCodeParser.ParseStringIntoZipCodes(TerritoryZipCodesTextBox.Text).Distinct();
            IEnumerable<string> availableZipCodes = zipCodeParser.ParseStringIntoZipCodes(AvailableZipCodesTextBox.Text).Distinct();
            IEnumerable<string> invalidZipCodes = selectedZipCodes.Where(zc => !availableZipCodes.Contains(zc));
            if (invalidZipCodes.IsEmpty())
            {
                IEnumerable<ZipCode> zipCodesToSave = _zipCodeRepository.GetAllExistingZipCodes(selectedZipCodes.ToList());
                bool shouldStayOnPageAfterPersistence = ((Button)sender).CommandArgument == "RefreshPage";
                SaveTerritory(GetTerritory(), zipCodesToSave, shouldStayOnPageAfterPersistence);
            }
            else
            {
                string invalidZipCodesString = String.Join(", ", invalidZipCodes.ToArray());
                string errorMessage = "The following zip code(s) need to be removed from the selection as they are out of this territory or are already in use:<br />"
                    + invalidZipCodesString;
                MessageControl1.ShowErrorMessage(errorMessage);
            }
        }

        private Core.Geo.Domain.Territory GetTerritory()
        {
            long territoryId;
            long parentTerritoryId;
            long.TryParse(Request.QueryString["tid"], out territoryId);
            long.TryParse(Request.QueryString["ftid"], out parentTerritoryId);

            switch ((TerritoryType)(byte.Parse(TerritoryTypeDDL.SelectedValue)))
            {
                case TerritoryType.SalesRep:
                    var salesRepTerritory = new SalesRepTerritory(territoryId)
                        { SalesRepTerritoryAssignments = new List<SalesRepTerritoryAssignment>(), ParentTerritoryId = parentTerritoryId};
                    return salesRepTerritory;
            }
            return null;
        }

        private void SaveTerritory(Core.Geo.Domain.Territory territory, IEnumerable<ZipCode> zipCodes, bool shouldStayOnPageAfterPersistence)
        {
            if (TerritoryNameTextBox.Text.Length == 0)
            {
                MessageControl1.ShowErrorMessage("A territory name is required.");
                return;
            }
            if (zipCodes.IsEmpty())
            {
                MessageControl1.ShowErrorMessage("At least one valid zip code is required.");
                return;
            }
            if (territory != null)
            {
                territory.Description = TerritoryDescriptionTextBox.Text;
                territory.Name = TerritoryNameTextBox.Text;
                territory.ZipCodes = zipCodes.ToList();
                territory.DataRecorderMetadata = new DataRecorderMetaData()
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                };
                try
                {
                    long savedTerritoryId = _territoryRepository.SaveTerritory(territory);
                    if (shouldStayOnPageAfterPersistence)
                    {
                        MessageControl1.EnqueueSuccessMessage(string.Format
                            ("The territory '{0}' has been saved successfully. You may continue editing it below.", territory.Name));
                        RefreshPage(territory, savedTerritoryId);
                    }
                    else
                    {
                        Response.RedirectUser("Manage.aspx");
                    }
                }
                catch (PersistenceFailureException)
                {
                    MessageControl1.ShowErrorMessage("The territory could not saved due to a system error. Please try again.");
                }
            }
        }

        private void RefreshPage(Core.Geo.Domain.Territory territory, long savedTerritoryId)
        {
            var redirectUrlStringBuilder = new StringBuilder();
            redirectUrlStringBuilder.AppendFormat("Edit.aspx?tid={0}", savedTerritoryId);
            if (territory.ParentTerritoryId != null)
            {
                redirectUrlStringBuilder.AppendFormat("&ftid={0}", territory.ParentTerritoryId);
            }
            Response.RedirectUser(ResolveUrl(redirectUrlStringBuilder.ToString()));
        }

        private void LoadTerritoryTypeDDL()
        {
            IEnumerable<TerritoryType> territoryTypesToAdd = new List<TerritoryType> { TerritoryType.SalesRep /*, TerritoryType.Pod */ };
            foreach (var territoryType in territoryTypesToAdd)
            {
                TerritoryTypeDDL.Items.Add(new ListItem(territoryType.ToString(), ((byte)territoryType).ToString()));
            }
        }
    }
}
