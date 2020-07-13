using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.Core.Extensions;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class OrderItemCart : UserControl
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

        public long PackageId { get; set; }
        public long PreApprovedPackageId { get; set; }

        public List<long> TestIds { get; set; }

        public string SelectedPackageTestIds
        {
            get
            {
                if (PackageId > 0)
                {
                    var packageRepository = IoC.Resolve<IEventPackageRepository>();
                    var eventPackage = packageRepository.GetByEventAndPackageIds(EventId, PackageId);
                    _package = eventPackage != null ? eventPackage.Package : null;

                }
                if (_package != null)
                {
                    return string.Join(",", _package.Tests.Select(t => t.Id.ToString()).ToArray());
                }

                return "0";
            }
        }

        public string PreApprovedPackageTestIds
        {
            get
            {
                if (PreApprovedPackageId > 0)
                {
                    var packageRepository = IoC.Resolve<IEventPackageRepository>();
                    var eventPackage = packageRepository.GetByEventAndPackageIds(EventId, PreApprovedPackageId);
                    if (eventPackage != null)
                    {
                        return string.Join(",", eventPackage.Package.Tests.Select(t => t.Id.ToString()).ToArray());
                    }

                    return "0";
                }
                return "0";
            }
        }

        public string MensBloodPanelTestIds
        {
            get
            {
                return string.Join(",", TestGroup.MensBloodPanelTestIds.Select(t => t.ToString()));
            }
        }
        public string WomensBloodPanelTestIds
        {
            get
            {
                return string.Join(",", TestGroup.WomenBloodPanelTestIds.Select(t => t.ToString()));
            }
        }

        public string SelectedIndependentTestIds
        {
            get
            {
                var packageTestIds = new List<long>();
                if (PackageId > 0)
                {
                    var packageRepository = IoC.Resolve<IEventPackageRepository>();
                    var eventPackage = packageRepository.GetByEventAndPackageIds(EventId, PackageId);
                    _package = eventPackage != null ? eventPackage.Package : null;
                    if (_package != null)
                        packageTestIds = _package.Tests.Select(t => t.Id).ToList();
                }
                if (!packageTestIds.IsNullOrEmpty())
                {
                    var selectedIndependentTestIds = TestIds.Where(t => !packageTestIds.Contains(t)).Select(t => t.ToString()).ToList();
                    return !selectedIndependentTestIds.IsNullOrEmpty() ? string.Join(",", selectedIndependentTestIds.Select(t => t.ToString()).ToArray()) : "0";
                }
                return !TestIds.IsNullOrEmpty() ? string.Join(",", TestIds.Select(t => t.ToString()).ToArray())
                           : "0";
            }
        }

        public string PreApprovedIndependentTestIds { get; set; }

        //public string RequiredTestIds { get; set; }

        public string PrequalifedTestIds { get; set; }

        public short RegistrationMode { get; set; }
        protected EventType EventType { get; set; }
        protected bool EnableAlaCarte { get; set; }
        protected long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        protected long Age { get; set; }
        public bool UpsellTest { get; set; }
        protected bool AllowPrequalifiedTestOnly { get; set; }

        public bool SingleTestOverride { get; set; }

        protected bool PreApprovedPackage { get; set; }

        private IEnumerable<long> _disqualifiedTestIds;
        private IEnumerable<long> DisqualifiedTestIds
        {
            get
            {
                //var disqualifiedTestString = RegistrationFlow != null ? RegistrationFlow.DisqualifiedTest : string.Empty;
                //if (string.IsNullOrEmpty(disqualifiedTestString))
                //    return new List<long>();
                //var disqualifiedTests = disqualifiedTestString.Split('|');

                //var disqualifiedTestIds = new List<long>();
                //foreach (var disqualifiedTest in disqualifiedTests)
                //{
                //    var dtArray = disqualifiedTest.Split(',');
                //    var disqualifiedTestId = Convert.ToInt64(dtArray[0]);
                //    disqualifiedTestIds.Add(disqualifiedTestId);
                //}

                //if (RegistrationFlow != null && !RegistrationFlow.DependentDisqualifiedTests.IsNullOrEmpty())
                //    disqualifiedTestIds.AddRange(RegistrationFlow.DependentDisqualifiedTests);

                //return disqualifiedTestIds;
                if (_disqualifiedTestIds == null)
                {
                    var disqualifiedTestIds = IoC.Resolve<Core.Medical.IDisqualifiedTestRepository>().GetLatestVersionTestId(_customerId, EventId);
                    var dependentDisqualifiedTestIds = IoC.Resolve<Core.Medical.IDependentDisqualifiedTestRepository>().GetLatestVersionTestId(_customerId, EventId);
                    _disqualifiedTestIds = (disqualifiedTestIds.Concat(dependentDisqualifiedTestIds)).Distinct();
                }
                return _disqualifiedTestIds;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PackageAndTestItems();

        }

        private long _customerId;
        public void PackageAndTestItems()
        {
            UpsellTest = true;
            //int forYear = 0;
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;
            if (EventId > 0)
            {
                var eventRepository = IoC.Resolve<IEventRepository>();
                var theEvent = eventRepository.GetById(EventId);
                if (theEvent != null)
                {
                    EventType = theEvent.EventType;
                    EventDateLabel.Text = theEvent.EventDate.ToString("dddd, MMMM dd, yyyy");
                    RegistrationMode = (short)theEvent.RegistrationMode;

                    //forYear = theEvent.EventDate.Year;

                    //var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                    var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
                    EnableAlaCarte =
                        Convert.ToBoolean(
                            configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));
                    if (EnableAlaCarte)
                    {
                        if (currentSession != null && currentSession.CurrentOrganizationRole.CheckRole((long)Roles.Customer))
                            EnableAlaCarte = theEvent.EnableAlaCarteOnline;
                        else if (currentSession != null &&
                                 currentSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep) ||
                                 currentSession != null &&
                                 currentSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterManager))
                            EnableAlaCarte = theEvent.EnableAlaCarteCallCenter;
                        else if (currentSession != null &&
                                 (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.Technician) ||
                                  currentSession.CurrentOrganizationRole.CheckRole((long)Roles.NursePractitioner)))
                            EnableAlaCarte = theEvent.EnableAlaCarteTechnician;
                        else if (
                            !(theEvent.EnableAlaCarteOnline || theEvent.EnableAlaCarteCallCenter ||
                              theEvent.EnableAlaCarteTechnician))
                            EnableAlaCarte = false;
                    }

                    var hostRepository = IoC.Resolve<IHostRepository>();
                    var host = hostRepository.GetHostForEvent(theEvent.Id);
                    if (host != null)
                    {
                        EventNameLabel.Text = HttpUtility.HtmlEncode(host.OrganizationName);
                        EventAddressLabel.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(CommonCode.AddressMultiLine(host.Address.StreetAddressLine1,
                            host.Address.StreetAddressLine2, host.Address.City,
                            host.Address.State, host.Address.ZipCode.Zip), true);
                    }
                    var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
                    var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(EventId);
                    if (hospitalPartnerId > 0)
                    {
                        var organizationRepository = IoC.Resolve<IOrganizationRepository>();
                        var hospitalPartner = organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                        HospitalPartnerLabel.Text = hospitalPartner.Name;
                        SponsoredInfoDiv.Visible = true;
                    }
                }
            }
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var userSession = IoC.Resolve<ISessionContext>().UserSession;
            Core.Users.Domain.Customer customer = null;
            if (CustomerId > 0)
            {
                customer = customerRepository.GetCustomer(CustomerId);
            }
            else if (userSession != null && userSession.CurrentOrganizationRole.CheckRole((long)Roles.Customer))
            {
                customer = customerRepository.GetCustomer(userSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            else if (Request.QueryString["CustomerId"] != null)
            {
                customer = customerRepository.GetCustomer(Convert.ToInt64(Request.QueryString["CustomerId"]));
            }
            if (Request.QueryString["EventCustomerID"] != null)
            {
                var eventCustomerRepository = IoC.Resolve<IUniqueItemRepository<EventCustomer>>();
                var eventCustomer = eventCustomerRepository.GetById(Convert.ToInt64(Request.QueryString["EventCustomerID"]));
                if (eventCustomer != null)
                {
                    if (customer == null)
                        customer = customerRepository.GetCustomer(eventCustomer.CustomerId);
                    SingleTestOverride = eventCustomer.SingleTestOverride;
                }
            }
            CorporateAccount account = null;
            if (EventId > 0 && customer != null)
            {
                _customerId = customer.CustomerId;

                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                account = corporateAccountRepository.GetbyEventId(EventId);

                var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
                var preApprovedTests = preApprovedTestRepository.GetByCustomerId(customer.CustomerId);

                var preApprovedPackageRepository = IoC.Resolve<IPreApprovedPackageRepository>();
                var preApprovedPackageId = preApprovedPackageRepository.CheckPreApprovedPackages(customer.CustomerId);

                //IEnumerable<RequiredTest> requiredTests = null;
                //var requiredTestIdList = new List<long>();
                //if (forYear > 0)
                //{
                //    var requiredTestRepository = IoC.Resolve<IRequiredTestRepository>();
                //    requiredTests = requiredTestRepository.GetByRequiredTestByCustomerIdAndYear(customer.CustomerId, forYear);
                //    requiredTestIdList = requiredTests != null ? requiredTests.Select(x => x.TestId).ToList() : null;
                //    if (!requiredTests.IsNullOrEmpty())
                //        RequiredTestIds = string.Join(",", requiredTests.Select(x => x.TestId));
                //}

                var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                var eventPackages = eventPackageRepository.GetPackagesForEventByRole(EventId, RoleId);

                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var eventCustomer = eventCustomerRepository.Get(EventId, customer.CustomerId);

                var eventTestRepository = IoC.Resolve<IEventTestRepository>();
                var eventTests = eventTestRepository.GetTestsForEventByRole(EventId, RoleId);
                var preApprovedTestIds = new List<long>();

                if (preApprovedPackageId > 0 && eventPackages != null && eventPackages.Any() && account != null && account.AllowPreQualifiedTestOnly)
                {
                    var eventPackage = eventPackages.FirstOrDefault(x => x.PackageId == preApprovedPackageId);
                    PreApprovedPackage = eventPackage != null;
                    PreApprovedPackageId = eventPackage != null ? eventPackage.PackageId : 0;
                }

                if (account != null && account.DefaultSelectionBasePackage && PreApprovedPackageId == 0)
                {
                    if (!eventPackages.IsNullOrEmpty())
                    {
                        var lowestPricePackage = eventPackages.OrderBy(ep => ep.Price).First();
                        PreApprovedPackageId = lowestPricePackage.PackageId;
                    }
                }

                var testIdsToAdd = new List<long>();
                if (account != null && account.AllowPreQualifiedTestOnly && (preApprovedTests != null && preApprovedTests.Any()))
                {
                    AllowPrequalifiedTestOnly = true;

                    var eventTestIds = eventTests.Select(et => et.TestId).ToList();
                    preApprovedTestIds = preApprovedTests.Where(pat => eventTestIds.Contains(pat.TestId)).Select(pat => pat.TestId).ToList();

                    var eventPackage = eventPackages.FirstOrDefault(x => x.PackageId == preApprovedPackageId);
                    var preApprovedPackageTestIds = eventPackage != null ? eventPackage.Package.Tests.Select(x => x.Id) : new List<long>();

                    var testIdsForCustomerOrder = eventTests.Where(x => x.Test.IsDefaultSelectionForOrder).Select(x => x.TestId).ToList();
                    if (!testIdsForCustomerOrder.IsNullOrEmpty())
                    {
                        testIdsToAdd = preApprovedTestIds.Where(x => !preApprovedPackageTestIds.Contains(x)).ToList();
                        testIdsToAdd.AddRange(testIdsForCustomerOrder);
                        // PreApprovedIndependentTestIds = string.Join(",", testIdsToAdd);
                    }

                    else
                    {
                        testIdsToAdd = preApprovedTestIds.Where(x => !preApprovedPackageTestIds.Contains(x)).ToList();
                        //PreApprovedIndependentTestIds = string.Join(",", preApprovedTestIds.Where(x => !preApprovedPackageTestIds.Contains(x)));
                    }

                    /*PreApprovedIndependentTestIds = string.Join(",", preApprovedTestIds.Where(x => !preApprovedPackageTestIds.Contains(x)));*/

                    if (userSession.CurrentOrganizationRole.CheckRole((long)Roles.Technician) || userSession.CurrentOrganizationRole.CheckRole((long)Roles.NursePractitioner)
                        || userSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep) || userSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin)
                        || userSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchiseeAdmin))
                    {
                        AllowPrequalifiedTestOnly = !account.AllowTechnicianUpdatePreQualifiedTests;
                    }

                    if (account.AllowPreQualifiedTestOnly && (eventCustomer == null || !eventCustomer.AppointmentId.HasValue) && (RegistrationFlow == null || !RegistrationFlow.SingleTestOverride)
                        && (RegistrationFlow == null || string.IsNullOrEmpty(RegistrationFlow.DisqualifiedTest)))
                    {
                        if (!preApprovedTestIds.IsNullOrEmpty())
                        {
                            if (PackageId > 0)
                            {
                                TestIds.AddRange(preApprovedTestIds);
                                TestIds = TestIds.Distinct().ToList();
                            }
                            else
                            {
                                TestIds = preApprovedTestIds;
                            }
                        }
                    }
                }

                if (!EnableAlaCarte )
                {
                    AllowPrequalifiedTestOnly = true;
                }

                //if (account != null && (requiredTests != null && requiredTests.Any()))
                //{
                //    testIdsToAdd.AddRange(requiredTests.Select(x => x.TestId).ToList());
                //    //PreApprovedIndependentTestIds = string.Join(",", requiredTests.Select(x => x.TestId));
                //}
                if (!testIdsToAdd.IsNullOrEmpty())
                {
                    testIdsToAdd = testIdsToAdd.Distinct().ToList();
                    PreApprovedIndependentTestIds = string.Join(",", testIdsToAdd);
                }

                PrequalifedTestIds = string.Join(",", preApprovedTestIds);

                if (eventCustomer == null || !eventCustomer.AppointmentId.HasValue)
                {
                    var testForCustomerOrder =
                        eventTests.Where(x => x.Test.IsDefaultSelectionForOrder).Select(x => x.TestId).ToList();

                    if (TestIds.IsNullOrEmpty())
                        TestIds = testForCustomerOrder;
                    else
                    {
                        TestIds.AddRange(testForCustomerOrder);
                        TestIds = TestIds.Distinct().ToList();
                    }
                }
                else
                {
                    if (PreApprovedPackage && preApprovedPackageId > 0)
                        PreApprovedPackage = PackageId == preApprovedPackageId;
                }
                if (!DisqualifiedTestIds.IsNullOrEmpty())
                {
                    if (!string.IsNullOrWhiteSpace(SelectedPackageTestIds))
                    {
                        try
                        {
                            var packageTestIds = SelectedPackageTestIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(long.Parse);

                            if (packageTestIds.Any(x => DisqualifiedTestIds.Contains(x)))
                                PackageId = 0;
                        }
                        catch (Exception ex)
                        {
                            IoC.Resolve<ILogManager>().GetLogger("Logger").Error("Exception occurred while converting package Test");
                            IoC.Resolve<ILogManager>().GetLogger("Logger").Error("Exception Message: " + ex.Message);
                            IoC.Resolve<ILogManager>().GetLogger("Logger").Error("stack trace: " + ex.StackTrace);
                        }
                    }
                    if (!TestIds.IsNullOrEmpty())
                        TestIds = TestIds.Where(x => !DisqualifiedTestIds.Contains(x)).ToList();

                }
                //if (!requiredTests.IsNullOrEmpty() && !requiredTestIdList.IsNullOrEmpty())
                //{
                //    TestIds.AddRange(requiredTestIdList);
                //    TestIds = TestIds.Distinct().ToList();
                //}

            }

            if (customer == null || !customer.DateOfBirth.HasValue) return;

            if (account != null)
            {
                UpsellTest = account.UpsellTest;
            }

            var now = DateTime.Now;
            var birth = customer.DateOfBirth.Value;
            Age = now.Year - birth.Year - ((now.DayOfYear < birth.DayOfYear) ? 1 : 0);
        }
    }
}