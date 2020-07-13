using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.UI.Controllers;
using Falcon.App.Core.Extensions;
using System.Web.Script.Serialization;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class OrderSummary : System.Web.UI.UserControl
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        private RegistrationFlowModel RegistrationFlow
        {
            get
            {
                if (!string.IsNullOrEmpty(GuId))
                {
                    return Session[GuId] as RegistrationFlowModel;
                }
                return null;
            }
        }

        private Core.Marketing.Domain.Package _package;
        public long EventId { get; set; }
        public long RoleId { get; set; }
        public string AppointmentTime { get; set; }
        public string ShippingOption { get; set; }
        public decimal ShippingOptionPrice { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsSourceCodeApplied { get; set; }
        public decimal SourceCodeAmount { get; set; }
        public bool IsGiftCertificate { get { return !string.IsNullOrEmpty(Request.QueryString["gc"]) && Request.QueryString["gc"] == "gc" ? true : false; } }

        public string SourceCode
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCode : string.Empty;
            }

        }

        public bool IsFulfillmentOptionPurchase
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["CFO"]) && Request.QueryString["CFO"] == "true"
                           ? true
                           : false;
            }
        }

        public bool IsPurchaseImageOption
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["CPI"]) && Request.QueryString["CPI"] == "true"
                           ? true
                           : false;
            }
        }

        public long PackageId { get; set; }
        public List<long> TestIds { get; set; }

        public string SelectedPackage
        {
            get
            {
                if (PackageId > 0 && _package == null)
                {
                    var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                    var eventPackage = eventPackageRepository.GetByEventAndPackageIds(EventId, PackageId);
                    _package = eventPackage != null ? eventPackage.Package : null;
                }
                if (_package != null)
                {
                    var javaScriptSerializer = new JavaScriptSerializer();
                    return javaScriptSerializer.Serialize(_package);
                }
                return string.Empty;
            }
        }

        public List<Test> SelectedPackageTests
        {
            get
            {
                if (PackageId > 0 && _package == null)
                {
                    var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                    var eventPackage = eventPackageRepository.GetByEventAndPackageIds(EventId, PackageId);
                    _package = eventPackage != null ? eventPackage.Package : null;
                }
                return _package != null ? _package.Tests : new List<Test>();
            }
        }

        public List<Test> SelectedAddOnTests
        {
            get
            {
                var packageController = new PackageController();
                var tests = packageController.GetTests(EventId, RoleId);
                if (!tests.IsNullOrEmpty())
                {
                    if (!SelectedPackageTests.IsNullOrEmpty())
                    {
                        var selectedAddOnTestIds =
                            tests.Where(
                                t => TestIds.Contains(t.Id) && !SelectedPackageTests.Select(pt => pt.Id).Contains(t.Id))
                                .ToList();
                        return selectedAddOnTestIds;
                    }
                    return tests.Where(t => TestIds.Contains(t.Id)).ToList();
                }
                return new List<Test>();
            }
        }

        public short EventType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EventId > 0)
            {
                var eventService = IoC.Resolve<IEventService>();
                var eventData = eventService.GetById(EventId);
                EventNameLabel.Text = HttpUtility.HtmlEncode(eventData.OrganizationName);
                EventAddressLabel.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(CommonCode.AddressMultiLine(eventData.StreetAddressLine1,
                                                                     eventData.StreetAddressLine2, eventData.City,
                                                                     eventData.State, eventData.Zip), true);

                EventType = (short)(RegistrationMode)Enum.Parse(typeof(RegistrationMode), eventData.EventType);
                EventDateLabel.Text = eventData.EventDate.ToString("dddd, MMMM dd, yyyy");

                var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
                var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(EventId);
                if (hospitalPartnerId > 0)
                {
                    var organizationRepository = IoC.Resolve<IOrganizationRepository>();
                    var hospitalPartner = organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                    HospitalPartnerLabel.Text = hospitalPartner.Name;
                    SponsoredInfoDiv.Visible = true;
                }

                if (!SelectedPackageTests.IsNullOrEmpty() || !SelectedAddOnTests.IsNullOrEmpty())
                {
                    var javaScriptSerializer = new JavaScriptSerializer();

                    if (!SelectedPackageTests.IsNullOrEmpty())
                    {
                        foreach (var packageTest in SelectedPackageTests)
                        {


                            Page.ClientScript.RegisterArrayDeclaration("selectedPackageTests",
                                                                       javaScriptSerializer.Serialize(packageTest));
                        }
                    }
                    else
                        Page.ClientScript.RegisterArrayDeclaration("selectedPackageTests", string.Empty);
                    if (!SelectedAddOnTests.IsNullOrEmpty())
                    {
                        foreach (var addOnTest in SelectedAddOnTests)
                        {


                            Page.ClientScript.RegisterArrayDeclaration("selectedAddOnTests",
                                                                       javaScriptSerializer.Serialize(addOnTest));
                        }
                    }
                    else
                        Page.ClientScript.RegisterArrayDeclaration("selectedAddOnTests", string.Empty);
                    Page.ClientScript.RegisterArrayDeclaration("selectedPackages", SelectedPackage);
                }
            }
        }
    }
}