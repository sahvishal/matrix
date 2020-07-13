using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Medical.Factories;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PhysicianPartnerResultExportService : PersistenceRepository, IPhysicianPartnerResultExportService
    {
        private readonly ILogger _logger;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly string _resultExportSettings;
        private readonly long _accountId;


        private readonly IPhysicianPartnerResultExportFactory _physicianPartnerResultExportFactory;

        public PhysicianPartnerResultExportService(ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager)
        {
            _logger = logManager.GetLogger("ResultExport");
            _customSettingManager = customSettingManager;
            _resultExportSettings = settings.PhysicianPartnerResultReportDownloadSettings;
            var physicianPartnerResultExportDownloadPath = settings.PhysicianPartnerResultReportDownloadPath;
            _accountId = settings.PhysicianPartnerAccountId;

            _physicianPartnerResultExportFactory = new PhysicianPartnerResultExportFactory(_logger, physicianPartnerResultExportDownloadPath, settings);
        }

        public void ResultExport()
        {
            try
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    var linqMetaData = new LinqMetaData(adapter);

                    _logger.Info("Fetching EventCustomerResults");

                    var customSettings = _customSettingManager.Deserialize(_resultExportSettings);
                    var fromDate = (customSettings.LastTransactionDate != null ? customSettings.LastTransactionDate.Value : (DateTime?)null);
                    var toDate = DateTime.Now;

                    var eventCustomerResult = GetEventCustomerResult(linqMetaData, fromDate, toDate, _accountId);

                    if (eventCustomerResult == null || !eventCustomerResult.Any())
                    {
                        _logger.Info("No Records Found");
                        return;
                    }

                    var customerIds = eventCustomerResult.Select(ecr => ecr.CustomerId);

                    _logger.Info("Fetching UserIds");

                    var orgRoleUserIdUserIdPairs = GetOrgRoleUserIdUserIdPairs(linqMetaData, customerIds);

                    _logger.Info("Fetching Users info");

                    var users = GetUsers(linqMetaData, orgRoleUserIdUserIdPairs.Select(oru => oru.SecondValue));

                    _logger.Info("Fetching Address info");

                    var addresses = GetAddress(linqMetaData, users.Select(u => u.HomeAddressId));

                    _logger.Info("Fetching Customer Profile info");

                    var customers = GetCustomers(linqMetaData, customerIds);

                    _logger.Info("Fetching Event info");

                    var events = GetEvents(linqMetaData, eventCustomerResult.Select(ecr => ecr.EventId));

                    _logger.Info("Fetching Pod info");

                    var eventIdPodIdPairs = GetEventIdPodIdPairs(linqMetaData, eventCustomerResult.Select(ecr => ecr.EventId));

                    var pods = GetAllPods(linqMetaData);

                    _logger.Info("Fetching Hospitalpartner info");

                    var eventIdHospitalPartnerIdPairs = GetEventIdHospitalPartnerIdPairs(linqMetaData, eventCustomerResult.Select(ecr => ecr.EventId));

                    var hospitalPartnerIdNamePairs = GetOrganizationIdNamePairs(linqMetaData, eventIdHospitalPartnerIdPairs.Select(eh => eh.SecondValue));

                    _logger.Info("Fetching EventCustomer info");

                    var eventCustomers = GetEventCustomers(linqMetaData, eventCustomerResult.Select(ecr => ecr.EventCustomerResultId));

                    _logger.Info("Fetching Event Appoint info");

                    var eventAppointment = GetAppointmentDetails(linqMetaData, eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value));

                    _logger.Info("Fetching Hospital Partner Customer info");

                    var hospitalPartnerCustomers = GetHospitalPartnerCustomers(linqMetaData, eventCustomerResult.Select(ecr => ecr.EventId));

                    var careCoordinatorIdNamePair = GetIdNamePairofUsers(linqMetaData, hospitalPartnerCustomers.Select(hpc => hpc.CareCoordinatorOrgRoleUserId));

                    _logger.Info("Fetching Primary care physician info");

                    var primaryCarePhysicians = GetPrimaryCarePhysicians(linqMetaData, customerIds);

                    _logger.Info("Fetching Basic Biometric info");

                    var basicBiometric = GetEventCustomerBasicBiometric(linqMetaData, eventCustomerResult.Select(ecr => ecr.EventCustomerResultId));

                    _logger.Info("Fetching HAF info");

                    var customerHealthAnswers = GetCustomerHealthAnswers(linqMetaData, eventCustomerResult.Select(ecr => ecr.EventCustomerResultId));

                    _logger.Info("Creating CSV file");

                    _physicianPartnerResultExportFactory.Create(eventCustomerResult.ToArray(), orgRoleUserIdUserIdPairs.ToArray(), users.ToArray(), addresses, customers, events, customerHealthAnswers,
                    eventIdPodIdPairs.ToArray(), pods, eventIdHospitalPartnerIdPairs.ToArray(), hospitalPartnerIdNamePairs, basicBiometric, eventCustomers.ToArray(), eventAppointment,
                    hospitalPartnerCustomers, careCoordinatorIdNamePair, primaryCarePhysicians);


                    customSettings.LastTransactionDate = toDate;
                    _customSettingManager.SerializeandSave(_resultExportSettings, customSettings);

                    _logger.Info("Completed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
            }
        }

        private IQueryable<EventCustomerResultEntity> GetEventCustomerResult(LinqMetaData linqMetaData, DateTime? startDate, DateTime endDate, long accountId)
        {
            var tag = (from a in linqMetaData.Account where a.AccountId == accountId select a.Tag).Single();

            return (from ecr in linqMetaData.EventCustomerResult
                    join e in linqMetaData.Events on ecr.EventId equals e.EventId
                    join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                    join cp in linqMetaData.CustomerProfile on ecr.CustomerId equals cp.CustomerId
                    where cp.Tag == tag
                    && (ecr.DateModified.HasValue && (startDate == null || ecr.DateModified > startDate) && ecr.DateModified <= endDate)
                    && ecr.ResultState == 7
                    && ea.AccountId == accountId
                    orderby e.EventDate, e.EventId, ecr.CustomerId
                    select ecr);

        }

        private IQueryable<OrderedPair<long, long>> GetOrgRoleUserIdUserIdPairs(LinqMetaData linqMetaData, IQueryable<long> orgRoleUserIds)
        {
            return (from oru in linqMetaData.OrganizationRoleUser
                    join u in linqMetaData.User on oru.UserId equals u.UserId
                    where orgRoleUserIds.Contains(oru.OrganizationRoleUserId)
                    select new OrderedPair<long, long>(oru.OrganizationRoleUserId, u.UserId));

        }

        private IQueryable<UserEntity> GetUsers(LinqMetaData linqMetaData, IQueryable<long> userIds)
        {
            return (from u in linqMetaData.User
                    where userIds.Contains(u.UserId)
                    select u);
        }

        private IEnumerable<Address> GetAddress(LinqMetaData linqMetaData, IQueryable<long> addressIds)
        {
            return (from a in linqMetaData.Address
                    join c in linqMetaData.City on a.CityId equals c.CityId
                    join s in linqMetaData.State on a.StateId equals s.StateId
                    join z in linqMetaData.Zip on a.ZipId equals z.ZipId
                    where addressIds.Contains(a.AddressId)
                    select new Address
                    {
                        Id = a.AddressId,
                        StreetAddressLine1 = a.Address1,
                        City = c.Name,
                        State = s.Name,
                        ZipCode = new ZipCode(z.ZipCode),
                    }).ToArray();
        }

        private IEnumerable<CustomerProfileEntity> GetCustomers(LinqMetaData linqMetaData, IQueryable<long> customerIds)
        {
            return (from cp in linqMetaData.CustomerProfile
                    where customerIds.Contains(cp.CustomerId)
                    select cp).ToArray();
        }

        private IEnumerable<EventsEntity> GetEvents(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from e in linqMetaData.Events
                    where eventIds.Contains(e.EventId)
                    select e).ToArray();
        }

        private IEnumerable<CustomerHealthInfoEntity> GetCustomerHealthAnswers(LinqMetaData linqMetaData, IQueryable<long> eventCustomerIds)
        {
            return (from chi in linqMetaData.CustomerHealthInfo
                    where eventCustomerIds.Contains(chi.EventCustomerId)
                    select chi).ToArray();
        }

        private IEnumerable<OrderedPair<long, long>> GetEventIdPodIdPairs(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from ep in linqMetaData.EventPod
                    where ep.IsActive && eventIds.Contains(ep.EventId)
                    select new OrderedPair<long, long>(ep.EventId, ep.PodId)).ToArray();
        }

        private IEnumerable<PodDetailsEntity> GetAllPods(LinqMetaData linqMetaData)
        {
            return (from pd in linqMetaData.PodDetails
                    select pd).ToArray();
        }

        private IQueryable<OrderedPair<long, long>> GetEventIdHospitalPartnerIdPairs(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from ehp in linqMetaData.EventHospitalPartner
                    where eventIds.Contains(ehp.EventId)
                    select new OrderedPair<long, long>(ehp.EventId, ehp.HospitalPartnerId));
        }

        private IEnumerable<OrderedPair<long, string>> GetOrganizationIdNamePairs(LinqMetaData linqMetaData, IQueryable<long> organizationIds)
        {
            return (from o in linqMetaData.Organization
                    where organizationIds.Contains(o.OrganizationId)
                    select new OrderedPair<long, string>(o.OrganizationId, o.Name)).ToArray();
        }

        private IEnumerable<EventCustomerBasicBioMetricEntity> GetEventCustomerBasicBiometric(LinqMetaData linqMetaData, IQueryable<long> eventCustomerIds)
        {
            return (from bb in linqMetaData.EventCustomerBasicBioMetric
                    where eventCustomerIds.Contains(bb.EventCustomerId)
                    select bb).ToArray();
        }

        private IQueryable<EventCustomersEntity> GetEventCustomers(LinqMetaData linqMetaData, IQueryable<long> eventCustomerIds)
        {
            return (from ec in linqMetaData.EventCustomers
                    where eventCustomerIds.Contains(ec.EventCustomerId)
                    select ec);
        }

        private IEnumerable<EventAppointmentEntity> GetAppointmentDetails(LinqMetaData linqMetaData, IQueryable<long> appointmentIds)
        {
            return (from ea in linqMetaData.EventAppointment
                    where appointmentIds.Contains(ea.AppointmentId)
                    select ea).ToArray();
        }

        private IQueryable<HospitalPartnerCustomerEntity> GetHospitalPartnerCustomers(LinqMetaData linqMetaData, IQueryable<long> eventIds)
        {
            return (from hpc in linqMetaData.HospitalPartnerCustomer
                    where eventIds.Contains(hpc.EventId)
                    select hpc);
        }

        private IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsers(LinqMetaData linqMetaData, IQueryable<long> orgRoleUserIds)
        {
            return (from u in linqMetaData.User
                    join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                    where orgRoleUserIds.Contains(oru.OrganizationRoleUserId)
                    select new OrderedPair<long, string>(oru.OrganizationRoleUserId, u.FirstName + " " + u.LastName)).OrderBy(o => o.SecondValue)
                    .ToArray();
        }

        private IEnumerable<CustomerPrimaryCarePhysicianEntity> GetPrimaryCarePhysicians(LinqMetaData linqMetaData, IQueryable<long> customerIds)
        {
            return (from pcp in linqMetaData.CustomerPrimaryCarePhysician 
                    where customerIds.Contains(pcp.CustomerId) && pcp.IsActive
                    select pcp).ToArray();
        }
    }
}
