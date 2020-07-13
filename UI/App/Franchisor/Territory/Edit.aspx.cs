using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Franchisor.Territory
{
    public partial class Edit : Page
    {
        private static readonly IZipCodeRepository _zipCodeRepository = new ZipCodeRepository();
        private readonly ITerritoryRepository _territoryRepository = new TerritoryRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTerritoryTypeDDL();
                LoadFranchiseeDDL();
                LoadHospitalPartnerCBL();
                LoadStateDDL();
                LoadTerritoryPackageCBL();
                if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
                {
                    long territoryId;
                    long.TryParse(Request.QueryString["tid"], out territoryId);
                    if (territoryId != 0)
                    {
                        Page.Title = "Edit Territory";
                        TerritoryTypeDDL.Enabled = false;
                        TerritoryFranchiseeOwnerDDL.Enabled = false;
                        TerritoryHospitalPartnerOwnersCBL.Enabled = false;
                        WhyOwnerSelectionIsDisabledLabel.Visible = true;
                        WhyTypeDDLIsDisabledLabel.Visible = true;
                        LoadTerritoryFields(territoryId);
                    }
                }
                SetFranchisorMasterPageOptions();
            }
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
                    Response.RedirectUser("~/App/Franchisor/Dashboard.aspx");
                    return;
                }
                IZipCodeParser zipCodeParser = new ZipCodeParser();
                TerritoryNameTextBox.Text = territory.Name;
                TerritoryDescriptionTextBox.Text = territory.Description;
                TerritoryZipCodesTextBox.Text = zipCodeParser.ParseZipCodesIntoString(territory.ZipCodes);
                TerritoryTypeDDL.SelectedValue = ((byte)territory.TerritoryType).ToString();
                switch(territory.TerritoryType)
                {
                    case TerritoryType.Franchisee:
                        TerritoryFranchiseeOwnerDDL.SelectedValue = ((FranchiseeTerritory) territory).FranchiseeOwnerId.ToString();
                        break;
                    case TerritoryType.HospitalPartner:
                        foreach (ListItem item in TerritoryHospitalPartnerOwnersCBL.Items)
                        {
                            if (((HospitalPartnerTerritory)territory).HospitalPartnerOwnerIds.Contains(long.Parse(item.Value)))
                            {
                                item.Selected = true;
                            }
                        }
                        break;
                    case TerritoryType.ReadingPhysician:
                        break;
                    case TerritoryType.Advertiser:
                        break;
                    case TerritoryType.Pod:
                        foreach (ListItem item in TerritoryPackageCBL.Items)
                        {
                            if (((PodTerritory)territory).PackageIds.Contains(long.Parse(item.Value)))
                            {
                                item.Selected = true;
                            }
                        }
                        break;
                    default:
                        Response.RedirectUser("~/App/Franchisor/Dashboard.aspx");
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
            bool shouldStayOnPageAfterPersistence = ((Button) sender).CommandArgument == "RefreshPage";
            SaveTerritory(GetTerritory(), GetZipCodes(), shouldStayOnPageAfterPersistence);
        }

        private List<ZipCode> GetZipCodes()
        {
            IZipCodeParser zipCodeParser = new ZipCodeParser();
            List<string> zipCodeStrings = zipCodeParser.ParseStringIntoZipCodes(TerritoryZipCodesTextBox.Text).Distinct().ToList();
            return _zipCodeRepository.GetAllExistingZipCodes(zipCodeStrings).Distinct().ToList();
        }

        private Core.Geo.Domain.Territory GetTerritory()
        {
            long territoryId;
            long parentTerritoryId;
            long.TryParse(Request.QueryString["tid"], out territoryId);
            long.TryParse(Request.QueryString["pid"], out parentTerritoryId);

            switch((TerritoryType)(byte.Parse(TerritoryTypeDDL.SelectedValue)))
            {
                case TerritoryType.Franchisee:
                    var franchiseeTerritory = new FranchiseeTerritory(territoryId) { FranchiseeOwnerId = long.Parse(TerritoryFranchiseeOwnerDDL.SelectedValue) };
                    if (parentTerritoryId != 0)
                    {
                        franchiseeTerritory.ParentTerritoryId = parentTerritoryId;
                    }
                    return franchiseeTerritory;
                case TerritoryType.HospitalPartner:
                    var hospitalPartnerOwnerIds = new List<long>();
                    foreach (ListItem item in TerritoryHospitalPartnerOwnersCBL.Items)
                    {
                        if (item.Selected)
                        {
                            hospitalPartnerOwnerIds.Add(long.Parse(item.Value));
                        }
                    }
                    if (!hospitalPartnerOwnerIds.IsEmpty())
                    {
                        var hospitalPartnerTerritory = new HospitalPartnerTerritory(territoryId) { HospitalPartnerOwnerIds = hospitalPartnerOwnerIds };
                        if (parentTerritoryId != 0)
                        {
                            hospitalPartnerTerritory.ParentTerritoryId = parentTerritoryId;
                        }
                        return hospitalPartnerTerritory;
                    }
                    MessageControl1.ShowErrorMessage("At least one hospital partner must be selected.");
                    break;
                case TerritoryType.ReadingPhysician:
                    var readingPhysicianTerritory = new ReadingPhysicianTerritory(territoryId);
                    if (parentTerritoryId != 0)
                    {
                        readingPhysicianTerritory.ParentTerritoryId = parentTerritoryId;
                    }
                    return readingPhysicianTerritory;
                case TerritoryType.Advertiser:
                    var advertiserTerritory = new AdvertiserTerritory(territoryId);
                    if (parentTerritoryId != 0)
                    {
                        advertiserTerritory.ParentTerritoryId = parentTerritoryId;
                    }
                    return advertiserTerritory;
                case TerritoryType.Pod:
                    var podTerritory = new PodTerritory(territoryId);
                    if (parentTerritoryId != 0)
                    {
                        podTerritory.ParentTerritoryId = parentTerritoryId;
                    }
                    var packageIds =
                        (from ListItem item in TerritoryPackageCBL.Items
                         where item.Selected
                         select Convert.ToInt64(item.Value)).ToList();
                    podTerritory.PackageIds = packageIds;
                    return podTerritory;
            }
            return null;
        }

        private void SaveTerritory(Core.Geo.Domain.Territory territory, List<ZipCode> zipCodes, bool shouldStayOnPageAfterPersistence)
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
                territory.ZipCodes = zipCodes;
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
                redirectUrlStringBuilder.AppendFormat("&pid={0}", territory.ParentTerritoryId);
            }
            Response.RedirectUser(ResolveUrl(redirectUrlStringBuilder.ToString()));
        }

        private void SetFranchisorMasterPageOptions()
        {
            var masterPage = (Franchisor_FranchisorMaster)Master;
            masterPage.SetBreadCrumbRoot = "Territory";
            masterPage.settitle(Page.Title);
            masterPage.hideucsearch();
        }

        private void LoadTerritoryTypeDDL()
        {
            IEnumerable<TerritoryType> territoryTypesToAdd = new List<TerritoryType>
                { TerritoryType.Franchisee, TerritoryType.HospitalPartner, TerritoryType.ReadingPhysician, TerritoryType.Advertiser,TerritoryType.Pod };
            foreach (var territoryType in territoryTypesToAdd)
            {
                TerritoryTypeDDL.Items.Add(new ListItem(territoryType.ToString(), ((byte)territoryType).ToString()));
            }

        }

        private void LoadFranchiseeDDL()
        {
            IOrganizationRepository franchiseeRepository = new OrganizationRepository();
            TerritoryFranchiseeOwnerDDL.DataSource = franchiseeRepository.GetOrganizationCollection(OrganizationType.Franchisee);

            TerritoryFranchiseeOwnerDDL.DataTextField = "Name";
            TerritoryFranchiseeOwnerDDL.DataValueField = "Id";
            TerritoryFranchiseeOwnerDDL.DataBind();
        }

        private void LoadHospitalPartnerCBL()
        {
            IHospitalPartnerRepository hospitalPartnerRepository = new HospitalPartnerRepository();
            TerritoryHospitalPartnerOwnersCBL.DataSource = hospitalPartnerRepository.GetIdNamePairsforHospitalPartners();
            TerritoryHospitalPartnerOwnersCBL.DataTextField = "SecondValue";
            TerritoryHospitalPartnerOwnersCBL.DataValueField = "FirstValue";
            TerritoryHospitalPartnerOwnersCBL.DataBind();
        }

        private void LoadStateDDL()
        {
            IStateRepository stateRepository = new StateRepository();
            StateDDL.DataSource = stateRepository.GetAllStates().OrderBy(s => s.Name);
            StateDDL.DataTextField = "Name";
            StateDDL.DataValueField = "Id";
            StateDDL.DataBind();
        }

        private void LoadTerritoryPackageCBL()
        {
            var packageRepository = IoC.Resolve<IPackageRepository>();
            var packages = packageRepository.GetAll();
            TerritoryPackageCBL.DataSource = packages;
            TerritoryPackageCBL.DataTextField = "Name";
            TerritoryPackageCBL.DataValueField = "Id";
            TerritoryPackageCBL.DataBind();
            TerritoryPackageCBL.RepeatColumns = 2;
        }

        [WebMethod (EnableSession = true)]
        public static List<ZipCode> GetZipCodesByState(long stateId)
        {
            return _zipCodeRepository.GetZipCodesForState(stateId).OrderBy(z => z.Zip).ToList();
        }

        [WebMethod (EnableSession = true)]
        public static List<ZipCode> GetZipCodesInRange(string originatingZipCode, int rangeInMiles)
        {
            return _zipCodeRepository.GetZipCodesInRadius(originatingZipCode, rangeInMiles).OrderBy(z => z.Zip).ToList();
        }
    }
}