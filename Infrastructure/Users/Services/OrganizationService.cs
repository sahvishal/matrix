using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Impl;
using Twilio;

namespace Falcon.App.Infrastructure.Users.Services
{
    [DefaultImplementation]
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IAddressService _addressService;
        private readonly IAddressRepository _addressRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICorporateAccountListModelFactory _corporateAccountListModelFactory;
        private readonly IMedicalVendorRepository _medicalVendorRepository;
        private readonly IMedicalVendorListModelFactory _medicalVendorListModelFactory;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICorporateAccountEventListFactory _corporateAccountEventListFactory;
        private readonly IHospitalPartnerCustomerRepository _hospitalPartnerCustomerRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IShippingDetailRepository _shippingDetailRepository;
        private readonly IHospitalPartnerDashboardViewModelFactory _hospitalPartnerViewModelFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly IHospitalFacilityListModelFactory _hospitalFacilityListModelFactory;
        private readonly IPackageRepository _packageRepository;
        private readonly IHospitalPartnerPackageFactory _hospitalPartnerPackagFactory;
        private readonly IHospitalPartnerPackageRepository _hospitalPartnerPackageRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IEventAppointmentStatsService _eventAppointmentStatsService;
        private readonly IPodRepository _podRepository;
        private readonly IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventVolumeFactory _eventVolumeFactory;
        private readonly IUniqueItemRepository<CorporateAccount> _uniqueItemCorporateAccountRepository;
        private readonly ICorporateAccountDashboardFactory _corporateAccountDashboardFactory;

        public OrganizationService(IOrganizationRepository organizationRepository, IAddressService addressService, IAddressRepository addressRepository, ICorporateAccountRepository corporateAccountRepository,
            ICorporateAccountListModelFactory corporateAccountListModelFactory, IMedicalVendorRepository medicalVendorRepository, IMedicalVendorListModelFactory medicalVendorListModelFactory,
            IHospitalPartnerRepository hospitalPartnerRepository, IEventRepository eventRepository, IHostRepository hostRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            ICorporateAccountEventListFactory corporateAccountEventListFactory, IHospitalPartnerCustomerRepository hospitalPartnerCustomerRepository, ICustomerRepository customerRepository,
            IUniqueItemRepository<File> fileRepository, IShippingDetailRepository shippingDetailRepository, IHospitalPartnerDashboardViewModelFactory hospitalPartnerViewModelFactory,
            IHospitalFacilityRepository hospitalFacilityRepository, IHospitalFacilityListModelFactory hospitalFacilityListModelFactory, IPackageRepository packageRepository, IHospitalPartnerPackageFactory hospitalPartnerPackagFactory,
            IHospitalPartnerPackageRepository hospitalPartnerPackageRepository, IConfigurationSettingRepository configurationSettingRepository, IEventAppointmentStatsService eventAppointmentStatsService, IPodRepository podRepository,
            IEventStaffAssignmentRepository eventStaffAssignmentRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IEventVolumeFactory eventVolumeFactory, IUniqueItemRepository<CorporateAccount> uniqueItemCorporateAccountRepository, ICorporateAccountDashboardFactory corporateAccountDashboardFactory)
        {
            _fileRepository = fileRepository;
            _organizationRepository = organizationRepository;
            _addressService = addressService;
            _addressRepository = addressRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _corporateAccountListModelFactory = corporateAccountListModelFactory;
            _medicalVendorRepository = medicalVendorRepository;
            _medicalVendorListModelFactory = medicalVendorListModelFactory;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _eventRepository = eventRepository;
            _hostRepository = hostRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _corporateAccountEventListFactory = corporateAccountEventListFactory;
            _hospitalPartnerCustomerRepository = hospitalPartnerCustomerRepository;
            _shippingDetailRepository = shippingDetailRepository;
            _hospitalPartnerViewModelFactory = hospitalPartnerViewModelFactory;
            _customerRepository = customerRepository;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _hospitalFacilityListModelFactory = hospitalFacilityListModelFactory;
            _packageRepository = packageRepository;
            _hospitalPartnerPackagFactory = hospitalPartnerPackagFactory;
            _hospitalPartnerPackageRepository = hospitalPartnerPackageRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _eventAppointmentStatsService = eventAppointmentStatsService;
            _podRepository = podRepository;
            _eventStaffAssignmentRepository = eventStaffAssignmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventVolumeFactory = eventVolumeFactory;
            _uniqueItemCorporateAccountRepository = uniqueItemCorporateAccountRepository;
            _corporateAccountDashboardFactory = corporateAccountDashboardFactory;
        }

        public OrganizationListModel GetOrganizationListModel(OrganizationType type)
        {
            var organizations = _organizationRepository.GetOrganizationCollection(type);
            return GetOrganizationListModel(organizations);
        }

        public OrganizationListModel GetOrganizationListModel(OrganizationType type, string searchText)
        {
            var organizations = _organizationRepository.GetOrganizationCollection(type, searchText);
            return GetOrganizationListModel(organizations);
        }

        public CorporateAccountListModel GetCorporateAccountListModel(int pageNumber, int pageSize, CorporateAccountListModelFilter filter, out int totalRecords)
        {
            var accounts = _corporateAccountRepository.GetbyFilter(pageNumber, pageSize, filter, out totalRecords);
            if (accounts.IsNullOrEmpty()) return null;

            var accountIds = accounts.Select(a => a.Id).ToArray();
            var accountIdPackagesPair =
                _corporateAccountRepository.GetAccountIdPackagesNamePair(accountIds);

            var organizations = _organizationRepository.GetOrganizations(accountIds);
            var orgListModels = GetOrganizationListModel(organizations);
            return _corporateAccountListModelFactory.Create(accounts, accountIdPackagesPair, orgListModels);
        }

        private static OrganizationListModel GetOrganizationListModel(IEnumerable<Organization> organizations)
        {
            IAddressRepository addressRepository = new AddressRepository();

            var binder = new OrganizationBasicInfoBinder();
            var basicModelCollection = new List<OrganizationBasicInfoModel>();
            foreach (var item in organizations)
            {
                Address address = null;
                if (item.BusinessAddressId > 0)
                    address = addressRepository.GetAddress(item.BusinessAddressId);

                basicModelCollection.Add(binder.ToModel(item, address));
            }

            return binder.ToModel(basicModelCollection);
        }

        public OrganizationEditModel GetOrganizationCreateModel(long id)
        {
            AddressEditModel billingAddress, businessAddress;
            File teamImage, logoImage;
            Organization organization = GetDomainforOrganizationCreateModel(id, out billingAddress, out businessAddress, out teamImage, out logoImage);

            var binder = new OrganizationCreateModelBinder();
            return binder.ToModel(organization, billingAddress, businessAddress, logoImage, teamImage);
        }

        public FranchiseeEditModel GetFranchiseeCreateModel(long id)
        {
            var franchiseeModel = new FranchiseeEditModel();
            AddressEditModel billingAddress, businessAddress;
            File teamImage, logoImage;
            Organization organization = GetDomainforOrganizationCreateModel(id, out billingAddress, out businessAddress, out teamImage, out logoImage);

            var binder = new OrganizationCreateModelBinder();
            franchiseeModel = binder.ToModel(franchiseeModel, organization, billingAddress, businessAddress, logoImage, teamImage) as FranchiseeEditModel;

            var podReposirotry = new PodRepository();
            var pods = podReposirotry.GetPodsAssignedToFranchisee(id);
            if (pods != null && pods.Count > 0)
                franchiseeModel.AllocatedPods = pods.ToArray();

            return franchiseeModel;
        }

        public MedicalVendorEditModel GetMedicalVendorCreateModel(long id)
        {
            var medicalVendor = _medicalVendorRepository.GetMedicalVendor(id);
            var model = Mapper.Map<MedicalVendor, MedicalVendorEditModel>(medicalVendor);
            var organizationEditModel = GetOrganizationCreateModel(id);

            model.OrganizationEditModel = organizationEditModel;

            if (medicalVendor.ResultLetterCoBrandingFileId.HasValue && medicalVendor.ResultLetterCoBrandingFileId.Value > 0)
            {
                model.ResultLetterCoBrandingFile = _fileRepository.GetById(medicalVendor.ResultLetterCoBrandingFileId.Value);
            }
            if (medicalVendor.DoctorLetterFileId.HasValue && medicalVendor.DoctorLetterFileId.Value > 0)
            {
                model.DoctorLetterFile = _fileRepository.GetById(medicalVendor.DoctorLetterFileId.Value);
            }
            if (medicalVendor.IsHospitalPartner)
            {
                model.HospitalPartnerEditModel = MedicalVendorCreateModel(medicalVendor.Id);
            }


            return model;
        }

        private HospitalPartnerEditModel MedicalVendorCreateModel(long medicalVendorId)
        {
            HospitalPartnerEditModel registrationModel = null;

            var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(medicalVendorId);
            registrationModel = Mapper.Map<HospitalPartner, HospitalPartnerEditModel>(hospitalPartner);

            var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AskPreQualificationQuestion);
            var askPreQualificationQuestion = value.ToLower() == bool.TrueString.ToLower();

            registrationModel.ShowAskPreQualificationQuestionSetttings = askPreQualificationQuestion;

            GetHospitalPartnerPackageInformation(medicalVendorId, registrationModel);

            return registrationModel;
        }

        public void GetHospitalPartnerPackageInformation(long medicalVendorId, HospitalPartnerEditModel registrationModel)
        {
            var packages = _packageRepository.GetAll();
            registrationModel.OrganizationPackageList =
                packages.Select(x => new OrganizationPackageViewModel { Gender = ((Gender)x.Gender), Id = x.Id, Name = x.Name })
                    .OrderBy(x => x.Name).ToList();

            var defaultPackages = _hospitalPartnerPackageRepository.GetByHospitalpartnerId(medicalVendorId);

            if (defaultPackages != null)
            {
                var activePackageIds = packages.Select(p => p.Id);

                if (registrationModel.DefaultPackages.IsNullOrEmpty())
                {
                    var deactivatedPackageIds = defaultPackages.Where(ap => !activePackageIds.Contains(ap.PackageId)).Select(ap => ap.PackageId);

                    var accountPackages = defaultPackages.Where(ap => !deactivatedPackageIds.Contains(ap.PackageId));

                    registrationModel.DefaultPackages = _hospitalPartnerPackagFactory.CreateModel(packages, accountPackages);

                    if (!deactivatedPackageIds.IsNullOrEmpty())
                    {
                        var deactivatedPackages = _packageRepository.GetByIds(deactivatedPackageIds).Select(p => p.Name).ToArray();

                        registrationModel.DeactivedPackages =
                            string.Format("Package(s) {0} attached with the hospital partner has been deactived. If you save then it will be removed.",
                                string.Join(",", deactivatedPackages));
                    }
                }
            }
        }

        public long Create(OrganizationEditModel model)
        {
            SaveAssociatesforModel(model);

            var binder = new OrganizationCreateModelBinder();
            var organization = binder.ToDomain(model);
            return _organizationRepository.SaveOrganization(organization);
        }

        public long CreateFranchisee(FranchiseeEditModel model)
        {
            var organizationId = Create(model);

            if (model.AllocatedPods != null)
            {
                var podRepository = new PodRepository();
                podRepository.AssignGivenPodstoaFranchisee(model.AllocatedPods.Select(pod => pod.Id).ToArray(), organizationId);
            }
            return organizationId;
        }

        public long CreateMedicalVendor(MedicalVendorEditModel model)
        {
            long toDeleteFileId = 0;
            if (model.ResultLetterCoBrandingFile != null)
            {
                model.ResultLetterCoBrandingFile = _fileRepository.Save(model.ResultLetterCoBrandingFile);
            }

            if (model.OrganizationEditModel.Id > 0)
            {
                var inDb = _medicalVendorRepository.GetMedicalVendor(model.OrganizationEditModel.Id);
                if (inDb.ResultLetterCoBrandingFileId.HasValue && inDb.ResultLetterCoBrandingFileId.Value > 0 && (model.ResultLetterCoBrandingFile == null || inDb.ResultLetterCoBrandingFileId != model.ResultLetterCoBrandingFile.Id))
                {
                    toDeleteFileId = inDb.ResultLetterCoBrandingFileId.Value;
                }
            }

            long toDeleteDoctorLetterFileId = 0;
            if (model.DoctorLetterFile != null)
            {
                model.DoctorLetterFile = _fileRepository.Save(model.DoctorLetterFile);
            }

            if (model.OrganizationEditModel.Id > 0)
            {
                var inDb = _medicalVendorRepository.GetMedicalVendor(model.OrganizationEditModel.Id);
                if (inDb.DoctorLetterFileId.HasValue && inDb.DoctorLetterFileId.Value > 0 && (model.DoctorLetterFile == null || inDb.DoctorLetterFileId != model.DoctorLetterFile.Id))
                {
                    toDeleteDoctorLetterFileId = inDb.DoctorLetterFileId.Value;
                }
            }

            var medicalVendor = Mapper.Map<MedicalVendorEditModel, MedicalVendor>(model);
            var organizationId = Create(model.OrganizationEditModel);
            medicalVendor.Id = organizationId;
            _medicalVendorRepository.Save(medicalVendor);

            if (toDeleteFileId > 0)
                ((IFileRepository)_fileRepository).Delete(toDeleteFileId);

            if (toDeleteDoctorLetterFileId > 0)
                ((IFileRepository)_fileRepository).Delete(toDeleteDoctorLetterFileId);

            if (medicalVendor.IsHospitalPartner)
            {
                var hospitalPartner = Mapper.Map<HospitalPartnerEditModel, HospitalPartner>(model.HospitalPartnerEditModel);
                hospitalPartner.Id = medicalVendor.Id;
                var domain = _hospitalPartnerPackagFactory.CreateDomain(model.HospitalPartnerEditModel.DefaultPackages, hospitalPartner.Id);
                _hospitalPartnerRepository.Save(hospitalPartner);
                _hospitalPartnerPackageRepository.Save(domain, hospitalPartner.Id);
            }
            else
                _hospitalPartnerRepository.Delete(medicalVendor.Id);

            return organizationId;
        }

        public MedicalVendorListModel GetMedicalVendorlistModel(int pageNumber, int pageSize, MedicalVendorListModelFilter filter, out int totalRecords)
        {
            var medicalVendors = _medicalVendorRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);
            if (medicalVendors.IsNullOrEmpty()) return null;
            var organizationIds = medicalVendors.Select(mv => mv.Id).ToArray();
            var organizations = _organizationRepository.GetOrganizations(organizationIds);
            var orgListModels = GetOrganizationListModel(organizations);
            var contracts = _medicalVendorRepository.GetAllContracts();

            return _medicalVendorListModelFactory.Create(medicalVendors, orgListModels, contracts);
        }

        private Organization GetDomainforOrganizationCreateModel(long id, out AddressEditModel billingAddress, out AddressEditModel businessAddress, out File teamImage, out File logoImage)
        {
            Organization organization = _organizationRepository.GetOrganizationbyId(id);
            GetAssociatesforCreateModel(organization, out billingAddress, out businessAddress, out teamImage, out logoImage);
            return organization;
        }

        private void GetAssociatesforCreateModel(Organization organization, out AddressEditModel billingAddress, out AddressEditModel businessAddress, out File teamImage, out File logoImage)
        {

            billingAddress = businessAddress = null;
            teamImage = logoImage = null;

            if (organization.BillingAddressId > 0)
            {
                billingAddress =
                    Mapper.Map<Address, AddressEditModel>(_addressRepository.GetAddress(organization.BillingAddressId));
            }
            if (organization.BusinessAddressId > 0)
            {
                businessAddress =
                    Mapper.Map<Address, AddressEditModel>(_addressRepository.GetAddress(organization.BusinessAddressId));
            }

            if (organization.LogoImageId > 0) logoImage = _fileRepository.GetById(organization.LogoImageId);
            if (organization.TeamImageId > 0) teamImage = _fileRepository.GetById(organization.TeamImageId);
        }

        private void SaveAssociatesforModel(OrganizationEditModel model)
        {
            Address address = null;

            if (model.BillingAddress != null && !model.BillingAddress.IsEmpty())
            {
                address = Mapper.Map<AddressEditModel, Address>(model.BillingAddress);
                address = _addressService.SaveAfterSanitizing(address);
                model.BillingAddress = Mapper.Map<Address, AddressEditModel>(address);
            }

            if (model.BusinessAddress != null && !model.BusinessAddress.IsEmpty())
            {
                address = Mapper.Map<AddressEditModel, Address>(model.BusinessAddress);
                address = _addressService.SaveAfterSanitizing(address);
                model.BusinessAddress = Mapper.Map<Address, AddressEditModel>(address);
            }

            if (model.LogoImage != null)
            {
                model.LogoImage = _fileRepository.Save(model.LogoImage);
            }
            if (model.TeamImage != null) model.TeamImage = _fileRepository.Save(model.TeamImage);

        }

        public HospitalPartnerDashboardViewModel GetHospitalPartnerDashboardModel(long hospitalPartnerId)
        {
            var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

            var eventIds = _hospitalPartnerRepository.GetEventIdsForHospitalPartner(hospitalPartnerId);
            if (eventIds.IsNullOrEmpty()) return new HospitalPartnerDashboardViewModel();

            var reccentContactedEventId = _hospitalPartnerCustomerRepository.GetMostRecentContactedEvent(hospitalPartnerId);
            var recentMailedEvents = _shippingDetailRepository.GetRecentMailedHospitalPartnerEvents(hospitalPartnerId).ToList();

            var recentCriticalCustomers =
                _eventCustomerResultRepository.GetRecentCriticalAndUrgentCustomersForHospitalPartner(hospitalPartnerId, 1, 8, hospitalPartner.CriticalResultValidityPeriod);

            var getEventIds = recentMailedEvents.Count() > 0 ? recentMailedEvents.Select(me => me.FirstValue).ToList() : new List<long>();

            if (reccentContactedEventId > 0)
                getEventIds.Add(reccentContactedEventId);

            IEnumerable<Customer> customers = null;
            IEnumerable<Event> events = null;
            IEnumerable<Host> hosts = null;
            IEnumerable<CustomerResultStatusViewModel> customerResultStatusViewModels = null;
            if (recentCriticalCustomers != null && recentCriticalCustomers.Count() > 0)
            {
                getEventIds.AddRange(recentCriticalCustomers.Select(rcc => rcc.EventId).ToArray());
                customers = _customerRepository.GetCustomers(recentCriticalCustomers.Select(rcc => rcc.CustomerId).ToArray());
                customerResultStatusViewModels = _eventCustomerResultRepository.GetTestResultStatus(recentCriticalCustomers.Select(rcc => rcc.Id).ToArray());
            }

            if (getEventIds.Count > 0)
            {
                events = _eventRepository.GetEventswithPodbyIds(getEventIds.ToArray());
                hosts = _hostRepository.GetEventHosts(events.Select(e => e.Id).ToArray());
            }
            var totalCustomers = _eventRepository.GetCustomersWithAppointmentByHospitalPartnerId(hospitalPartnerId);
            var customersAttended = _eventRepository.GetAttendedCustomersByHospitalPartnerId(hospitalPartnerId);

            var normalCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForHospitalPartner(hospitalPartnerId, ResultInterpretation.Normal, true, hospitalPartner.NormalResultValidityPeriod);
            var abnormalCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForHospitalPartner(hospitalPartnerId, ResultInterpretation.Abnormal, true, hospitalPartner.AbnormalResultValidityPeriod);
            var criticalCustomers = _eventCustomerResultRepository.GetCriticalEventIdCustomersCountForHospitalPartner(hospitalPartnerId, ResultInterpretation.Critical, true, hospitalPartner.CriticalResultValidityPeriod);
            var urgentCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForHospitalPartner(hospitalPartnerId, ResultInterpretation.Urgent, true, hospitalPartner.CriticalResultValidityPeriod);

            var mailedDate = _shippingDetailRepository.MailedDateForEvent(reccentContactedEventId);

            return _hospitalPartnerViewModelFactory.Create(eventIds.Count(), totalCustomers, customersAttended,
                                                           criticalCustomers, normalCustomers, abnormalCustomers,
                                                           events, hosts,
                                                           reccentContactedEventId, recentMailedEvents, mailedDate,
                                                           recentCriticalCustomers, customers, customerResultStatusViewModels, urgentCustomers);
        }

        public CorporateAccountDashboardViewModel GetCorporateAccountDashboardModel(long accountId, int pageSize)
        {
            var accountEvents = _eventRepository.GetUpcomingHealthPlanEvents(1, pageSize, accountId);
            var upcomingEvents = GetClientEventVolumeModel(accountEvents).Collection;
            var memberStatus = GetMemberStatusForAccountCoordinatorDashboard(accountId);

            IEnumerable<Customer> customers = null;
            IEnumerable<Event> events = null;
            IEnumerable<CustomerResultStatusViewModel> customerResultStatusViewModels = null;

            var recentCriticalCustomers = _eventCustomerResultRepository.GetRecentCriticalAndUrgentCustomersForCorporateAccountCoordinator(accountId, 1, 8);
            var recentMailedEvents = _shippingDetailRepository.GetRecentMailedHospitalPartnerEvents(accountId).ToList();
            var getEventIds = recentMailedEvents.Any() ? recentMailedEvents.Select(me => me.FirstValue).ToList() : new List<long>();
            if (recentCriticalCustomers != null && recentCriticalCustomers.Any())
            {
                getEventIds.AddRange(recentCriticalCustomers.Select(rcc => rcc.EventId).ToArray());
                customers = _customerRepository.GetCustomers(recentCriticalCustomers.Select(rcc => rcc.CustomerId).ToArray());
                customerResultStatusViewModels = _eventCustomerResultRepository.GetTestResultStatus(recentCriticalCustomers.Select(rcc => rcc.Id).ToArray());
            }
            if (getEventIds.Count > 0)
            {
                events = _eventRepository.GetEventswithPodbyIds(getEventIds.ToArray());
            }

            return _corporateAccountDashboardFactory.Create(upcomingEvents, memberStatus, recentCriticalCustomers, events, customers, customerResultStatusViewModels);
        }

        private CorporateAccountMemberStatusViewModel GetMemberStatusForAccountCoordinatorDashboard(long accountId)
        {
            return _customerRepository.GetMemberStatusForAccountCoordinatorDashboard(accountId);
        }

        private ClientEventVolumeListModel GetClientEventVolumeModel(IEnumerable<Event> events)
        {
            if (events.IsNullOrEmpty()) return null;
            var eventIds = events.Select(e => e.Id).ToList();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(events);

            var pods = _podRepository.GetPodsForEvents(eventIds);

            var eventIdHospitalPartnerIdPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);

            var organizationIds = new List<long>();
            organizationIds.AddRange(eventIdHospitalPartnerIdPairs.Select(ehp => ehp.SecondValue).Distinct().ToArray());

            var organizations = _organizationRepository.GetOrganizations(organizationIds.ToArray());

            var eventIdHospitalPartnerNamePairs = (from ehp in eventIdHospitalPartnerIdPairs
                                                   join org in organizations on ehp.SecondValue equals org.Id
                                                   select new OrderedPair<long, string>(ehp.FirstValue, org.Name)).ToArray();

            var eventIdCorporateNamePairs = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(eventIds);

            var customersAttended = _eventRepository.GetAttendedCustomers(eventIds);

            var eventStaffCollection = _eventStaffAssignmentRepository.GetForEvents(eventIds);

            IEnumerable<OrderedPair<long, string>> staffIdNamePairs = null;

            if (eventStaffCollection != null && eventStaffCollection.Any())
            {
                var orgRoleUserIds = eventStaffCollection.Select(esc => (esc.ActualStaffOrgRoleUserId != null ? esc.ActualStaffOrgRoleUserId.Value : esc.ScheduledStaffOrgRoleUserId)).ToArray();
                staffIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);
            }

            return _eventVolumeFactory.Create(events, hosts, pods, eventAppointmentStatsModels, eventIdHospitalPartnerNamePairs, customersAttended, eventIdCorporateNamePairs, eventStaffCollection, staffIdNamePairs);
        }

        public long CreateHospitalFacility(HospitalFacilityEditModel model)
        {
            long toDeleteFileId = 0;
            if (model.ResultLetterFile != null)
            {
                model.ResultLetterFile = _fileRepository.Save(model.ResultLetterFile);
            }

            if (model.OrganizationEditModel.Id > 0)
            {
                var inDb = _hospitalFacilityRepository.GetHospitalFacility(model.OrganizationEditModel.Id);
                if (inDb.ResultLetterFileId.HasValue && inDb.ResultLetterFileId.Value > 0 && (model.ResultLetterFile == null || inDb.ResultLetterFileId != model.ResultLetterFile.Id))
                {
                    toDeleteFileId = inDb.ResultLetterFileId.Value;
                }
            }

            var hospitalFacility = Mapper.Map<HospitalFacilityEditModel, HospitalFacility>(model);
            var organizationId = Create(model.OrganizationEditModel);
            hospitalFacility.Id = organizationId;
            _hospitalFacilityRepository.Save(hospitalFacility);

            if (toDeleteFileId > 0)
                ((IFileRepository)_fileRepository).Delete(toDeleteFileId);

            return organizationId;
        }

        public HospitalFacilityEditModel GetHospitalFacilityCreateModel(long id)
        {
            var hospitalFacility = _hospitalFacilityRepository.GetHospitalFacility(id);
            var hospitalFacilityEditModel = Mapper.Map<HospitalFacility, HospitalFacilityEditModel>(hospitalFacility);
            var organizationEditModel = GetOrganizationCreateModel(id);

            hospitalFacilityEditModel.OrganizationEditModel = organizationEditModel;

            if (hospitalFacility.ResultLetterFileId.HasValue && hospitalFacility.ResultLetterFileId.Value > 0)
            {
                hospitalFacilityEditModel.ResultLetterFile = _fileRepository.GetById(hospitalFacility.ResultLetterFileId.Value);
            }

            return hospitalFacilityEditModel;
        }

        public HospitalFacilityListModel GetHospitalFacilityListModel(int pageNumber, int pageSize, HospitalFacilityListModelFilter filter, out int totalRecords)
        {
            var hospitalFacilities = _hospitalFacilityRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);
            if (hospitalFacilities.IsNullOrEmpty()) return null;

            var organizationIds = hospitalFacilities.Select(hf => hf.Id).ToArray();

            var hospitalPartnerIdHospitalFacilityIdPairs = _hospitalFacilityRepository.GetHospitalPartnerIdHositalFacilityIdPair(organizationIds);

            if (hospitalPartnerIdHospitalFacilityIdPairs != null && hospitalPartnerIdHospitalFacilityIdPairs.Any())
                organizationIds = organizationIds.Concat(hospitalPartnerIdHospitalFacilityIdPairs.Select(hphf => hphf.FirstValue)).ToArray();

            var organizations = _organizationRepository.GetOrganizations(organizationIds);
            var orgListModels = GetOrganizationListModel(organizations);
            var contracts = _medicalVendorRepository.GetAllContracts();

            return _hospitalFacilityListModelFactory.Create(hospitalFacilities, orgListModels, contracts, hospitalPartnerIdHospitalFacilityIdPairs);
        }

        public HospitalPartnerDashboardViewModel GetHospitalFacilityDashboardModel(long hospitalFacilityId)
        {
            var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(hospitalFacilityId);
            HospitalPartner hospitalPartner = null;
            if (hospitalPartnerId > 0)
                hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);

            var eventIds = _hospitalFacilityRepository.GetEventIdsForHospitalFacility(hospitalFacilityId);
            if (eventIds.IsNullOrEmpty()) return new HospitalPartnerDashboardViewModel();

            var reccentContactedEventId = _hospitalPartnerCustomerRepository.GetMostRecentContactedEventForHospitalFacility(hospitalFacilityId);
            var recentMailedEvents = _shippingDetailRepository.GetRecentMailedHospitalFacilityEvents(hospitalFacilityId).ToList();

            var recentCriticalCustomers = _eventCustomerResultRepository.GetRecentCriticalAndUrgentCustomersForHospitalFacility(hospitalFacilityId, 1, 8, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0);

            var getEventIds = recentMailedEvents.Count() > 0 ? recentMailedEvents.Select(me => me.FirstValue).ToList() : new List<long>();

            if (reccentContactedEventId > 0)
                getEventIds.Add(reccentContactedEventId);

            IEnumerable<Customer> customers = null;
            IEnumerable<Event> events = null;
            IEnumerable<Host> hosts = null;
            IEnumerable<CustomerResultStatusViewModel> customerResultStatusViewModels = null;
            if (recentCriticalCustomers != null && recentCriticalCustomers.Count() > 0)
            {
                getEventIds.AddRange(recentCriticalCustomers.Select(rcc => rcc.EventId).ToArray());
                customers = _customerRepository.GetCustomers(recentCriticalCustomers.Select(rcc => rcc.CustomerId).ToArray());
                customerResultStatusViewModels = _eventCustomerResultRepository.GetTestResultStatus(recentCriticalCustomers.Select(rcc => rcc.Id).ToArray());
            }

            if (getEventIds.Count > 0)
            {
                events = _eventRepository.GetEventswithPodbyIds(getEventIds.ToArray());
                hosts = _hostRepository.GetEventHosts(events.Select(e => e.Id).ToArray());
            }
            var totalCustomers = _eventRepository.GetCustomersWithAppointmentByHospitalFacilityId(hospitalFacilityId);
            var customersAttended = _eventRepository.GetAttendedCustomersByHospitalFacilityId(hospitalFacilityId);

            var normalCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForHospitalFacility(hospitalFacilityId, ResultInterpretation.Normal, true, hospitalPartner != null ? hospitalPartner.NormalResultValidityPeriod : 0);
            var abnormalCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForHospitalFacility(hospitalFacilityId, ResultInterpretation.Abnormal, true, hospitalPartner != null ? hospitalPartner.AbnormalResultValidityPeriod : 0);
            var criticalCustomers = _eventCustomerResultRepository.GetCriticalEventIdCustomersCountForHospitalFacility(hospitalFacilityId, ResultInterpretation.Critical, true, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0);
            var urgentCustomers = _eventCustomerResultRepository.GetResultSummaryEventIdCustomersCountForHospitalFacility(hospitalFacilityId, ResultInterpretation.Urgent, true, hospitalPartner != null ? hospitalPartner.CriticalResultValidityPeriod : 0);

            var mailedDate = _shippingDetailRepository.MailedDateForEvent(reccentContactedEventId, hospitalFacilityId);

            return _hospitalPartnerViewModelFactory.Create(eventIds.Count(), totalCustomers, customersAttended,
                                                           criticalCustomers, normalCustomers, abnormalCustomers,
                                                           events, hosts,
                                                           reccentContactedEventId, recentMailedEvents, mailedDate,
                                                           recentCriticalCustomers, customers, customerResultStatusViewModels, urgentCustomers);
        }
    
        public bool IsActiveOrganizationbyId(long organizationId)
        {
            return _organizationRepository.IsActiveOrganizationbyId(organizationId);
        }
        
    }
}
