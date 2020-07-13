using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Infrastructure.Medical.Factories;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HouseCallHafResultExportService : PersistenceRepository, IHouseCallHafResultExportService
    {
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly ICustomSettingManager _customSettingManager;
        private readonly string _resultExportSettings;
        private readonly IHouseCallHafResultExportFactory _houseCallHafResultExportFactory;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEnumerable<long> _accountIds;

        public HouseCallHafResultExportService(ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager,
            ICorporateAccountRepository corporateAccountRepository)
        {
            _logger = logManager.GetLogger("ResultExport");
            _customSettingManager = customSettingManager;
            _houseCallHafResultExportFactory = new HouseCallHafResultExportFactory(_logger);
            _resultExportSettings = settings.HousecallHafResultReportDownloadSettings;
            _corporateAccountRepository = corporateAccountRepository;
            _accountIds = settings.HousecallPlanOutreachReportAccountIds;
            _settings = settings;
        }

        public void ResultExport()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                foreach (var account in corporateAccounts)
                {
                    try
                    {
                        var resultExportSettings = string.Format(_resultExportSettings, account.Tag);
                        var houseCallHafResultExportDownloadPath = string.Format(_settings.HousecallHafResultReportDownloadPath, account.FolderName);

                        var customSettings = _customSettingManager.Deserialize(resultExportSettings);

                        var fromDate = customSettings.LastTransactionDate == null ? _settings.HousecallOutreachReportCutOfDate : new DateTime(customSettings.LastTransactionDate.Value.Year, 1, 1);
                        var toDate = DateTime.Now;

                        _logger.Info(string.Format("Generating Result Report for Account ID : {0} and Tag : {1}", account.Id, account.Tag));

                        GenerateResultReport(account.Id, fromDate, toDate, houseCallHafResultExportDownloadPath);

                        customSettings.LastTransactionDate = toDate;
                        _customSettingManager.SerializeandSave(resultExportSettings, customSettings);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Account Id {0} and account Tag {1}  Message: {2} \n Stack Trace: {3} ", account.Id, account.Tag, ex.Message, ex.StackTrace));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: {0} \n Stack Trace: {1} ", ex.Message, ex.StackTrace));
            }
        }

        private void GenerateResultReport(long accountId, DateTime fromDate, DateTime toDate, string destinationDirectory)
        {
            try
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    var linqMetaData = new LinqMetaData(adapter);

                    _logger.Info("Fetching EventCustomers");

                    var eventCustomers = GetEventCustomers(linqMetaData, fromDate, toDate, accountId);

                    if (eventCustomers == null || !eventCustomers.Any())
                    {
                        _logger.Info("No Records Found");
                        return;
                    }

                    var customerIds = eventCustomers.Select(ecr => ecr.CustomerId);

                    _logger.Info("Fetching UserIds");

                    var orgRoleUserIdUserIdPairs = GetOrgRoleUserIdUserIdPairs(linqMetaData, customerIds);

                    _logger.Info("Fetching Users info");

                    var users = GetUsers(linqMetaData, orgRoleUserIdUserIdPairs.Select(oru => oru.SecondValue));

                    _logger.Info("Fetching Address info");

                    var addresses = GetAddress(linqMetaData, users.Select(u => u.HomeAddressId));

                    _logger.Info("Fetching Customer Profile info");

                    var customers = GetCustomers(linqMetaData, customerIds);

                    _logger.Info("Fetching Event info");

                    var events = GetEvents(linqMetaData, eventCustomers.Select(ecr => ecr.EventId));

                    _logger.Info("Fetching Hospital Partner Customer info");

                    var hospitalPartnerCustomers = GetHospitalPartnerCustomers(linqMetaData, eventCustomers.Select(ecr => ecr.EventId));

                    var careCoordinatorIdNamePair = GetIdNamePairofUsers(linqMetaData, hospitalPartnerCustomers.Select(hpc => hpc.CareCoordinatorOrgRoleUserId));

                    _logger.Info("Fetching Primary care physician info");

                    var primaryCarePhysicians = GetPrimaryCarePhysicians(linqMetaData, customerIds);

                    _logger.Info("Fetching Primary care physician address info");

                    var pcpAddressIds = (from pcp in primaryCarePhysicians
                                         where pcp.Pcpaddress.HasValue
                                         select pcp.Pcpaddress.Value);

                    var pcpAddressInfo = GetAddress(linqMetaData, pcpAddressIds);

                    _logger.Info("Fetching Event Appointment info");

                    var eventAppointments = GetAppointmentDetails(linqMetaData, eventCustomers.Where(ec => ec.AppointmentId.HasValue).Select(ec => ec.AppointmentId.Value));

                    _logger.Info("Fetching HAF info");

                    var customerHealthAnswers = GetCustomerHealthAnswers(linqMetaData, eventCustomers.Select(ecr => ecr.EventCustomerId));

                    _logger.Info("Creating CSV file");

                    _houseCallHafResultExportFactory.Create(eventCustomers.ToArray(), orgRoleUserIdUserIdPairs.ToArray(), users.ToArray(), addresses, customers, events, customerHealthAnswers,
                     careCoordinatorIdNamePair, primaryCarePhysicians.ToArray(), pcpAddressInfo, eventAppointments, destinationDirectory);

                    _logger.Info("Completed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
            }
        }

        private IQueryable<EventCustomersEntity> GetEventCustomers(LinqMetaData linqMetaData, DateTime startDate, DateTime endDate, long accountId)
        {
            return (from chi in linqMetaData.CustomerHealthInfo
                    join ec in linqMetaData.EventCustomers on chi.EventCustomerId equals ec.EventCustomerId
                    join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                    where ec.AppointmentId.HasValue && ea.AccountId == accountId
                    && chi.DateCreated >= startDate && chi.DateCreated < endDate
                    select ec);
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

        private IQueryable<CustomerPrimaryCarePhysicianEntity> GetPrimaryCarePhysicians(LinqMetaData linqMetaData, IQueryable<long> customerIds)
        {
            return (from pcp in linqMetaData.CustomerPrimaryCarePhysician
                    where customerIds.Contains(pcp.CustomerId) && pcp.IsActive
                    select pcp);
        }

        private IEnumerable<EventAppointmentEntity> GetAppointmentDetails(LinqMetaData linqMetaData, IQueryable<long> appointmentIds)
        {
            return (from ea in linqMetaData.EventAppointment
                    where appointmentIds.Contains(ea.AppointmentId)
                    select ea).ToArray();
        }
    }
}
