using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AuthorizeNet;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Sales.Enum;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    public class EventCustomerRepository : UniqueItemRepository<EventCustomer, EventCustomersEntity>, IEventCustomerRepository
    {
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository = new OrganizationRoleUserRepository();
        private readonly IShippingOptionRepository _shippingOptionRepository = new ShippingOptionRepository();
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IRoleRepository _roleRepository = new RoleRepository();
        private IMapper<EventCustomer, VwEventCustomersAccountEntity> _viewMapper;
        public EventCustomerRepository()
            : this(new EventCustomerMapper(), new ConfigurationSettingRepository(), new EventCustomerViewMapper())
        { }

        public EventCustomerRepository(IMapper<EventCustomer, EventCustomersEntity> mapper, IConfigurationSettingRepository configurationSettingRepository, IMapper<EventCustomer, VwEventCustomersAccountEntity> viewMapper)
            : base(mapper)
        {
            _configurationSettingRepository = configurationSettingRepository;
            _viewMapper = viewMapper;
        }

        protected override EntityField2 EntityIdField
        {
            get { return EventCustomersFields.EventCustomerId; }
        }

        public IEnumerable<EventCustomer> GetbyEventId(long eventId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from ec in linqMetaData.EventCustomers
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                    into ecWithApp
                                from a in ecWithApp.DefaultIfEmpty()
                                where ec.EventId == eventId
                                orderby a.StartTime
                                select ec).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public EventCustomer Get(long eventId, long customerId)
        {
            return GetByPredicate(new PredicateExpression(EventCustomersFields.EventId == eventId).AddWithAnd(EventCustomersFields.CustomerId == customerId)).FirstOrDefault();
        }

        public bool UpdateAppointmentId(long eventCustomerId, long? appointmentId = null)
        {
            var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { AppointmentId = appointmentId };

            if (appointmentId == null)
            {
                eventCustomersEntity.IsAppointmentConfirmed = false;
                eventCustomersEntity.ConfirmedBy = null;
            }

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (appointmentId == null)
                {
                    var callQueueCustomerBucket = new RelationPredicateBucket(CallQueueCustomerFields.EventCustomerId == eventCustomerId);

                    var callQueueCustomerEntity = new CallQueueCustomerEntity
                    {
                        AppointmentDate = null,
                        AppointmentDateTimeWithTimeZone = null,
                        AppointmentCancellationDate = DateTime.Now
                    };

                    myAdapter.UpdateEntitiesDirectly(callQueueCustomerEntity, callQueueCustomerBucket);
                }

                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public EventMetricsViewData GetEventCustomerFlagMetrics(EventMetricsViewData eventMetricsViewData, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                eventMetricsViewData.AttendedCustomersCount += linqMetaData.EventCustomers.Count(ec => ec.EventId == eventId && ec.AppointmentId.HasValue && !ec.NoShow && ec.IsTestConducted && !ec.LeftWithoutScreeningReasonId.HasValue);
                eventMetricsViewData.NoShowCustomersCount += linqMetaData.EventCustomers.Count(ec => ec.EventId == eventId && ec.AppointmentId.HasValue && ec.NoShow);
                eventMetricsViewData.LeftWithoutScreeningCustomersCount += linqMetaData.EventCustomers.Count(ec => ec.EventId == eventId && ec.AppointmentId.HasValue && ec.LeftWithoutScreeningReasonId.HasValue);

                var eventCustomers = from ec in linqMetaData.EventCustomers
                                     join ea in linqMetaData.EventAppointment on ec.AppointmentId.Value equals
                                         ea.AppointmentId
                                     where
                                         ec.AppointmentId.HasValue && !ec.NoShow && (ea.CheckinTime.HasValue || ea.CheckoutTime.HasValue)
                                          && ec.EventId == eventId
                                     group ec by ec.Hipaastatus
                                         into
                                             hippaGroup
                                         select
                                         new { HippaStatus = (RegulatoryState)hippaGroup.Key, Count = hippaGroup.Count() };

                var hipaaSignedCustomers = eventCustomers.SingleOrDefault(ec => ec.HippaStatus == RegulatoryState.Signed);
                eventMetricsViewData.HipaaSignedCount += hipaaSignedCustomers != null ? hipaaSignedCustomers.Count : 0;

                var hipaaUnSignedCustomers = eventCustomers.SingleOrDefault(ec => ec.HippaStatus == RegulatoryState.Not_Signed);
                eventMetricsViewData.HipaaUnSignedCount += hipaaUnSignedCustomers != null ? hipaaUnSignedCustomers.Count : 0;
                return eventMetricsViewData;
            }
        }

        public EventCustomer GetRegisteredEventForUser(long customerId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventCustomers =
                    linqMetaData.EventCustomers.Where(
                        ec => ec.CustomerId == customerId && ec.EventId == eventId && ec.AppointmentId.HasValue).
                        SingleOrDefault();
                if (eventCustomers == null)
                    throw new ObjectNotFoundInPersistenceException<EventCustomer>();
                return Mapper.Map(eventCustomers);
            }
        }

        public EventCustomer GetCancelledEventForUser(long customerId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventCustomers =
                    linqMetaData.EventCustomers.Where(
                        ec => ec.CustomerId == customerId && ec.EventId == eventId && !ec.AppointmentId.HasValue).
                        SingleOrDefault();

                if (eventCustomers == null)
                    throw new ObjectNotFoundInPersistenceException<EventCustomer>();

                return Mapper.Map(eventCustomers);
            }
        }

        //TODO: SRE
        public List<EventCustomer> GetEventCustomersRegisteredByCallCenterRep(long callCenterRepId, DateTime startDate, DateTime endDate)
        {
            var callCenterRepOrganizationRoleUser =
                _organizationRoleUserRepository.GetOrganizationRoleUser(callCenterRepId);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventCustomers = linqMetaData.EventCustomers.Join(linqMetaData.OrganizationRoleUser.Where(o => GetParentRoleIdByRoleId(o.RoleId) == (long)Roles.CallCenterRep),
                                            ec => ec.CreatedByOrgRoleUserId, oru => oru.OrganizationRoleUserId, (ec, oru) => ec).Where(ec => ec.DateCreated >= startDate &&
                                            ec.DateCreated <= endDate && !ec.NoShow && ec.AppointmentId.HasValue && ec.CreatedByOrgRoleUserId == callCenterRepId).ToList();

                if (eventCustomers.IsEmpty())
                    throw new EmptyCollectionException();

                return Mapper.MapMultiple(eventCustomers).ToList();
            }
        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return roleId;

            return role.ParentId != null && role.ParentId > 0 ? role.ParentId.Value : roleId;
        }

        public bool UpdateFirstRegistrationMarketingSource(long customerId, string marketingSource)
        {
            try
            {
                var eventCustomers = GetEventCustomerForFirstTimeRegistration(customerId);

                if (eventCustomers != null)
                {
                    return UpdateMaketingSource(eventCustomers.EventCustomerId, marketingSource);
                }
            }
            catch (Exception exception)
            {
                throw new PersistenceFailureException(exception.Message);
            }
            return true;
        }

        public bool UpdateMaketingSource(long eventCustomerId, string marketingSource)
        {
            var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { MarketingSource = marketingSource };
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool UpdateHippaStatus(long eventCustomerId, short hippaStatus)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { Hipaastatus = hippaStatus };
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool UpdateShowUp(long eventCustomerId, bool isNoShowUp, DateTime? noShowDate)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var isTestConducted = (from ec in linqMetaData.EventCustomers
                                       join ep in linqMetaData.EventAppointment on ec.AppointmentId equals
                                           ep.AppointmentId
                                       where (ep.CheckinTime.HasValue || ep.CheckoutTime.HasValue) && ec.EventCustomerId == eventCustomerId
                                       select ep.AppointmentId).Any();
                EventCustomersEntity eventCustomersEntity = null;
                eventCustomersEntity = isNoShowUp ? new EventCustomersEntity(eventCustomerId) { IsTestConducted = false, NoShow = true } : new EventCustomersEntity(eventCustomerId) { NoShow = false, IsTestConducted = isTestConducted };
                eventCustomersEntity.NoShowDate = noShowDate;

                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        //public string UpdateCheckInCheckOutTime(long eventCustomerId, long appointmentId, DateTime? checkInTime, DateTime? checkOutTime)
        //{
        //    if (!checkInTime.HasValue && !checkOutTime.HasValue) throw new Exception("Can not update appointment with blank Check In/Check Out Time.");

        //    try
        //    {
        //        UpdateCheckInCheckOutTime(eventCustomerId, appointmentId, checkInTime, checkOutTime);
        //        return string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public string UpdateCheckInCheckOutTime(long eventCustomerId, long appointmentId, DateTime? checkInTime, DateTime? checkOutTime)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventAppointmentEntity = new EventAppointmentEntity(appointmentId) { CheckinTime = checkInTime, CheckoutTime = checkOutTime, DateModified = DateTime.Now };
                if (!checkInTime.HasValue && checkOutTime.HasValue)
                {
                    eventAppointmentEntity = new EventAppointmentEntity(appointmentId) { CheckoutTime = checkOutTime, DateModified = DateTime.Now };
                }
                if (checkInTime.HasValue && !checkOutTime.HasValue)
                {
                    eventAppointmentEntity = new EventAppointmentEntity(appointmentId) { CheckinTime = checkInTime, DateModified = DateTime.Now };
                }
                var bucket = new RelationPredicateBucket(EventAppointmentFields.AppointmentId == appointmentId);
                try
                {
                    myAdapter.StartTransaction(IsolationLevel.ReadCommitted, "CheckInCheckOutUpdate");
                    if (myAdapter.UpdateEntitiesDirectly(eventAppointmentEntity, bucket) > 0)
                    {
                        var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { IsTestConducted = true };//, NoShow = false 
                        bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                        myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket);
                        myAdapter.Commit();
                        return string.Empty;
                    }

                    throw new Exception(
                        "There appears to be an issue while updating the Check In/ Check out Time. Please try again");
                }
                catch (Exception exception)
                {
                    myAdapter.Rollback();
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public string ClearCheckInCheckOutTime(long eventCustomerId, long appointmentId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventAppointmentEntity = new EventAppointmentEntity(appointmentId) { CheckinTime = null, CheckoutTime = null, DateModified = DateTime.Now };
                var bucket = new RelationPredicateBucket(EventAppointmentFields.AppointmentId == appointmentId);
                try
                {
                    myAdapter.StartTransaction(IsolationLevel.ReadCommitted, "CheckInCheckOutUpdate");
                    if (myAdapter.UpdateEntitiesDirectly(eventAppointmentEntity, bucket) > 0)
                    {
                        var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { IsTestConducted = false };
                        bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                        myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket);
                        myAdapter.Commit();
                        return string.Empty;
                    }

                    throw new Exception(
                        "There appears to be an issue while updating the Check In/ Check out Time. Please try again");
                }
                catch (Exception exception)
                {
                    myAdapter.Rollback();
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public List<int> GetHipaaRatio(long eventId)
        {
            var hippaStatusCounts = new List<int>();
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventCustomersAppointmentIds =
                    linqMetaData.EventCustomers.Where(
                        eventCustomer =>
                        eventCustomer.EventId == eventId && !eventCustomer.NoShow &&
                        eventCustomer.AppointmentId.HasValue &&
                        eventCustomer.Hipaastatus == Convert.ToInt16(RegulatoryState.Signed)).Select(
                        eventAppointment => eventAppointment.AppointmentId);

                var hippaYesCount =
                    linqMetaData.EventAppointment.Where(
                        eventAppointment =>
                        eventAppointment.CheckinTime.HasValue &&
                        eventCustomersAppointmentIds.Contains(eventAppointment.AppointmentId)).Count();

                eventCustomersAppointmentIds =
                    linqMetaData.EventCustomers.Where(
                        eventCustomer =>
                        eventCustomer.EventId == eventId && !eventCustomer.NoShow &&
                        eventCustomer.AppointmentId.HasValue).Select(eventAppointment => eventAppointment.AppointmentId);

                var hippaAllCount =
                    linqMetaData.EventAppointment.Where(
                        eventAppointment =>
                        eventAppointment.CheckinTime.HasValue &&
                        eventCustomersAppointmentIds.Contains(eventAppointment.AppointmentId)).Count();

                hippaStatusCounts.Add(hippaYesCount);
                hippaStatusCounts.Add(hippaAllCount);
            }
            return hippaStatusCounts;
        }

        private EventCustomersEntity GetEventCustomerForFirstTimeRegistration(long customerId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                EventCustomersEntity eventCustomersEntity = null;

                var eventCustomers = linqMetaData.EventCustomers.Where(e => e.CustomerId == customerId).ToList();
                if (eventCustomers.Count > 0)
                {
                    DateTime compareDateTime = DateTime.Now;


                    foreach (var entity in eventCustomers)
                    {
                        if (DateTime.Compare(entity.DateCreated.Value, compareDateTime) < 0 &&
                            entity.AppointmentId.HasValue)
                        {
                            eventCustomersEntity = entity;
                            compareDateTime = entity.DateCreated.Value;
                        }
                    }
                }
                return eventCustomersEntity;
            }
        }

        // Used for Reports
        public IEnumerable<EventCustomer> GetEventCustomersbyRegisterationDate(int pageNumber, int pageSize, AppointmentsBookedListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<VwEventCustomersAccountEntity> entities;
                if (filter == null)
                {
                    var query = (from ec in linqMetaData.VwEventCustomersAccount orderby ec.DateCreated descending select ec);
                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();

                    return _viewMapper.MapMultiple(entities);
                }
                else
                {
                    var query = (from ec in linqMetaData.VwEventCustomersAccount
                                 select ec);

                    if (filter.EventId > 0)
                    {
                        var queryForEcs = query.Where(q => q.EventId == filter.EventId).Select(q => q);
                        totalRecords = queryForEcs.Count();
                        entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                        return _viewMapper.MapMultiple(entities);
                    }
                    else
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(a => a.DateCreated >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(a => a.DateCreated < filter.ToDate.Value.AddHours(23).AddMinutes(59));

                        if (filter.EventFrom.HasValue)
                            query = query.Where(a => a.EventDate >= filter.EventFrom.Value);

                        if (filter.EventTo.HasValue)
                            query = query.Where(a => a.EventDate < filter.EventTo.Value.AddHours(23).AddMinutes(59));

                        if (filter.EventStatus > 0)
                            query = query.Where(a => a.EventStatus == filter.EventStatus);

                        var eventAccounts = (from ea in linqMetaData.EventAccount select ea);
                      
                        if (filter.AccountId > 0)
                        {
                            var eventIds = eventAccounts.Where(x => x.AccountId == filter.AccountId).Select(x => x.EventId);
                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }
                        else if (filter.IsRetailEvent && !filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                        {
                            var eventIds = eventAccounts.Select(x => x.EventId);

                            query = query.Where(q => !eventIds.Contains(q.EventId));
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                        {
                            var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                            var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }
                        else if (!filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                        {
                            var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                            var eventIds = (from ea in eventAccounts where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }
                        else if (!filter.IsRetailEvent && filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }
                        else if (filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                        {
                            var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                            var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                            query = query.Where(q => !eventIds.Contains(q.EventId));
                        }
                        else if (filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                        {
                            var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                            var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                            query = query.Where(q => !eventIds.Contains(q.EventId));
                        }

                      
                        if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                            query = query.Where(a => a.EventTypeId == (long)RegistrationMode.Public);
                        else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                            query = query.Where(a => a.EventTypeId == (long)RegistrationMode.Private);

                        if (filter.Zipcodes != null && filter.Zipcodes.Count() > 0)
                        {
                            var eventIds = (from hed in linqMetaData.HostEventDetails
                                            join p in linqMetaData.Prospects on hed.HostId equals p.ProspectId
                                            join a in linqMetaData.Address on p.AddressId equals a.AddressId
                                            join z in linqMetaData.Zip on a.ZipId equals z.ZipId
                                            where filter.Zipcodes.Contains(z.ZipCode)
                                            select hed.EventId);
                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }

                        if (filter.StateId > 0)
                        {
                            var eventIds = (from hed in linqMetaData.HostEventDetails
                                            join p in linqMetaData.Prospects on hed.HostId equals p.ProspectId
                                            join a in linqMetaData.Address on p.AddressId equals a.AddressId
                                            where a.StateId == filter.StateId
                                            select hed.EventId);
                            query = query.Where(q => eventIds.Contains(q.EventId));
                        }

                        if (!string.IsNullOrEmpty(filter.Tag))
                        {
                            var customerIds = (from c in linqMetaData.CustomerProfile
                                               where c.Tag == filter.Tag
                                               select c.CustomerId);
                            query = query.Where(q => customerIds.Contains(q.CustomerId));
                        }

                        if (filter.CustomTags != null && filter.CustomTags.Any())
                        {
                            var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                        where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                        select ct.CustomerId);

                            if (filter.ExcludeCustomerWithCustomTag)
                            {
                                query = (from q in query where !customTagCustomerIds.Contains(q.CustomerId) select q);
                            }
                            else
                            {
                                query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                            }
                        }
                      
                        if (filter.CancelledCustomer)
                        {
                            query = query.Where(q => q.AppointmentId <= 0);
                        }

                        if (filter.ShowCustomersWithAppointment)
                        {
                            query = query.Where(q => q.AppointmentId > 0);
                        }
                      
                        if (!(string.IsNullOrEmpty(filter.GroupName)))
                        {
                            var customerIds = (from c in linqMetaData.CustomerProfile
                                               where c.GroupName == filter.GroupName
                                               select c.CustomerId);
                            query = query.Where(q => customerIds.Contains(q.CustomerId));
                        }
                        if(filter.ProductTypeId>0)
                        {
                            query = from ec in query
                                    join ea in linqMetaData.CustomerProfile on ec.CustomerId equals
                                        ea.CustomerId
                                    where ea.ProductTypeId == filter.ProductTypeId
                                    select ec;
                        }

                        var countQuery = from ec in query
                                         join ea in linqMetaData.EventAppointment on ec.AppointmentId equals
                                             ea.AppointmentId into ecQuery
                                         from e in ecQuery.DefaultIfEmpty()
                                         select ec;
                        totalRecords = countQuery.Count();

                        var queryForEcs = from ec in query
                                          join ea in linqMetaData.EventAppointment on ec.AppointmentId equals
                                              ea.AppointmentId into ecQuery
                                          from e in ecQuery.DefaultIfEmpty()
                                          orderby ec.DateCreated descending, e.StartTime, ec.EventCustomerId
                                          select new { ec.DateCreated, e.StartTime, ec.EventCustomerId };

                        //query.OrderBy(a => a.ec.DateCreated).Select(a => a.ec);
                       
                        var temp = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                        var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                        var eventCustomers = GetByIds(eventCustomerIds);
                        return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                    }
                }
            }
        }

        // Used for Reports
        public IEnumerable<EventCustomer> GetEventCustomersforPatientSchedule(int pageNumber, int pageSize, CustomerScheduleModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                if (filter == null)
                {
                    var query = (from ec in linqMetaData.EventCustomers
                                 join e in linqMetaData.Events on ec.EventId equals e.EventId
                                 where ec.AppointmentId != null
                                 orderby e.EventDate
                                 select ec);

                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize);
                    return Mapper.MapMultiple(entities);
                }
                else
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                    if (filter.FromDate == null && filter.ToDate == null)
                        filter.FromDate = DateTime.Today;

                    var vehicle = string.IsNullOrEmpty(filter.Vehicle) ? "" : filter.Vehicle;

                    var queryEvents = from op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData)
                                      join ep in linqMetaData.EventPod on op.FirstValue.EventId equals ep.EventId
                                      join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                      where
                                          (filter.FromDate == null || fromDate <= op.FirstValue.EventDate) &&
                                          (filter.ToDate == null ||
                                           toDate.AddHours(23).AddMinutes(59) > op.FirstValue.EventDate) && ep.IsActive &&
                                          p.Name.Contains(vehicle)
                                          &&
                                          (filter.IsRetailEvent && !filter.IsCorporateEvent
                                               ? (!op.SecondValue)
                                               : (!filter.IsRetailEvent && filter.IsCorporateEvent
                                                      ? op.SecondValue
                                                      : true))
                                          && ((filter.IsPublicEvent && !filter.IsPrivateEvent)
                                                  ? op.FirstValue.EventTypeId == (long)RegistrationMode.Public
                                                  : (!filter.IsPublicEvent && filter.IsPrivateEvent)
                                                        ? op.FirstValue.EventTypeId == (long)RegistrationMode.Private
                                                        : true)
                                      select op.FirstValue;

                    var query = (from e in queryEvents
                                 join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                 where ec.AppointmentId != null
                                 select new { e, ec });

                    var countQuery = from ec in query
                                     join ea in linqMetaData.EventAppointment on ec.ec.AppointmentId equals ea.AppointmentId into ecQuery
                                     from e in ecQuery.DefaultIfEmpty()
                                     select ec.ec.EventCustomerId;

                    totalRecords = countQuery.Count();

                    var queryForEcs = from ec in query
                                      join ea in linqMetaData.EventAppointment on ec.ec.AppointmentId equals ea.AppointmentId into ecQuery
                                      from e in ecQuery.DefaultIfEmpty()
                                      orderby ec.e.EventDate, ec.ec.EventId, e.StartTime, ec.ec.EventCustomerId
                                      select new { ec.e.EventDate, ec.ec.EventId, e.StartTime, ec.ec.EventCustomerId };


                    var temp = queryForEcs.TakePage(pageNumber, pageSize).ToArray();
                    var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                    var eventCustomers = GetByIds(eventCustomerIds);
                    return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                }

            }
        }

        // Used for Reports
        public IEnumerable<EventCustomer> GetNoShowEventCustomers(int pageNumber, int pageSize, NoShowCustomerModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                if (filter == null)
                {
                    var query = (from ec in linqMetaData.EventCustomers
                                 join e in linqMetaData.Events on ec.EventId equals e.EventId
                                 where ec.NoShow && ec.AppointmentId != null
                                 orderby e.EventDate descending
                                 select ec);
                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }
                else
                {

                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                    var query = (from ec in linqMetaData.EventCustomers
                                 join op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData) on
                                     ec.EventId equals op.FirstValue.EventId
                                 where ec.NoShow && ec.AppointmentId != null
                                       && (filter.FromDate != null ? fromDate <= op.FirstValue.EventDate : true)
                                       && (filter.ToDate != null ? toDate >= op.FirstValue.EventDate : true)
                                       && (filter.IsRetailEvent && !filter.IsCorporateEvent
                                               ? (!op.SecondValue)
                                               : (!filter.IsRetailEvent && filter.IsCorporateEvent
                                                      ? op.SecondValue
                                                      : true))
                                       && ((filter.IsPublicEvent && !filter.IsPrivateEvent)
                                               ? op.FirstValue.EventTypeId == (long)RegistrationMode.Public
                                               : (!filter.IsPublicEvent && filter.IsPrivateEvent)
                                                     ? op.FirstValue.EventTypeId == (long)RegistrationMode.Private
                                                     : true)
                                 select new { ec, op });

                    var countQuery = (from q in query select q.ec);
                    totalRecords = countQuery.Count();

                    //var noShowquery = (from q in query
                    //                   orderby q.op.FirstValue.EventDate descending, q.ec.EventCustomerId
                    //                   select new { q.ec, q.op.FirstValue });

                    //var temp = noShowquery.TakePage(pageNumber, pageSize).ToArray();
                    //entities = temp.Select(x => x.ec).ToArray();
                    //return Mapper.MapMultiple(entities);

                    var noShowquery = (from q in query
                                       orderby q.op.FirstValue.EventDate descending, q.ec.EventCustomerId
                                       select new { q.ec.EventCustomerId, q.op.FirstValue.EventDate });

                    var temp = noShowquery.TakePage(pageNumber, pageSize).ToArray();

                    var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                    var eventCustomers = GetByIds(eventCustomerIds);
                    return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                }
            }
        }


        public IEnumerable<EventCustomer> GetEventCustomerswithCdPurchase(int pageNumber, int pageSize, CdImageStatusModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                List<EventCustomersEntity> entities;
                var productOrders = (from od in linqMetaData.OrderDetail
                                     join poi in linqMetaData.ProductOrderItem on od.OrderItemId equals poi.OrderItemId
                                     where od.Status == (int)OrderStatusState.FinalSuccess
                                         && poi.ProductId == (long)Product.UltraSoundImages
                                     select od.OrderId);

                var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);

                var cdOrders = (from od in linqMetaData.OrderDetail
                                join sdod in linqMetaData.ShippingDetailOrderDetail on od.OrderDetailId equals sdod.OrderDetailId
                                join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                where productOrders.Contains(od.OrderId) && sdod.IsActive
                                && od.Status == (int)OrderStatusState.FinalSuccess
                                && (cdShippingOption != null ? sd.ShippingOptionId == cdShippingOption.Id : true)
                                select od.OrderId);

                var queryable = from ec in linqMetaData.EventCustomers
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                where
                                    ecod.IsActive && ec.AppointmentId.HasValue &&
                                    cdOrders.Contains(od.OrderId)
                                select ec;

                if (filter == null)
                {
                    totalRecords = queryable.Count();
                    entities = queryable.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }
                else
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;
                    var vehicle = !string.IsNullOrEmpty(filter.Vehicle) ? filter.Vehicle : "";

                    var queryWithExpression = (from ec in queryable
                                               join e in linqMetaData.Events on ec.EventId equals e.EventId
                                               join epd in linqMetaData.EventPod
                                                   on e.EventId equals epd.EventId
                                               join pd in linqMetaData.PodDetails on epd.PodId equals pd.PodId
                                               where pd.Name.Contains(vehicle)
                                                     && (filter.FromDate != null
                                                         ? fromDate <= e.EventDate
                                                         : true)
                                                           && (filter.ToDate != null
                                                               ? toDate >= e.EventDate
                                                               : true)
                                               select ec);
                    totalRecords = queryWithExpression.Count();
                    entities = queryWithExpression.TakePage(pageNumber, pageSize).ToList();
                }
                return Mapper.MapMultiple(entities);
            }
        }

        public DateTime GetEventCustomerDataForNotification(long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomer = from ec in linqMetaData.EventCustomers
                                    where
                                        ec.CustomerId == orgRoleUserId
                                    orderby ec.DateCreated descending
                                    select ec.DateCreated.Value;

                return eventCustomer.FirstOrDefault();

            }
        }

        public IEnumerable<EventCustomer> GetbyCustomerId(long customerId)
        {
            return GetByPredicate(new PredicateExpression(EventCustomersFields.CustomerId == customerId));
        }

        public bool UpdatePartnerReleaseStatus(long eventCustomerId, short partnerReleaseStatus)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { PartnerRelease = partnerReleaseStatus };
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersWithCdPurchase(int pageNumber, int pageSize, CustomerCdConentTrackingModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                List<EventCustomersEntity> entities;
                var cdOrders = (from od in linqMetaData.OrderDetail
                                join poi in linqMetaData.ProductOrderItem on od.OrderItemId equals poi.OrderItemId
                                where
                                    od.Status == (int)OrderStatusState.FinalSuccess
                                    && poi.ProductId == (long)Product.UltraSoundImages
                                select od.OrderId);

                var queryable = from ec in linqMetaData.EventCustomers
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                    ecod.EventCustomerId
                                join od in linqMetaData.OrderDetail
                                    on ecod.OrderDetailId equals od.OrderDetailId
                                where
                                    ecod.IsActive && ec.AppointmentId.HasValue &&
                                    cdOrders.Contains(od.OrderId)
                                select ec;

                if (filter == null)
                {
                    totalRecords = queryable.Count();
                    entities = queryable.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }
                else
                {

                    var name = !string.IsNullOrEmpty(filter.CustomerName) ? filter.CustomerName : "";

                    var countQuery = (from ec in queryable
                                      join e in linqMetaData.Events on ec.EventId equals e.EventId
                                      join oru in linqMetaData.OrganizationRoleUser on ec.CustomerId equals
                                          oru.OrganizationRoleUserId
                                      join u in linqMetaData.User on oru.UserId equals u.UserId
                                      where (u.FirstName + " " + u.LastName).Contains(name)
                                            && (filter.EventId > 0 ? e.EventId == filter.EventId : true)
                                            && (filter.CustomerId > 0 ? ec.CustomerId == filter.CustomerId : true)
                                      orderby u.FirstName
                                      select ec);
                    totalRecords = countQuery.Count();

                    var queryWithExpression = (from ec in queryable
                                               join e in linqMetaData.Events on ec.EventId equals e.EventId
                                               join oru in linqMetaData.OrganizationRoleUser on ec.CustomerId equals
                                                   oru.OrganizationRoleUserId
                                               join u in linqMetaData.User on oru.UserId equals u.UserId
                                               where (u.FirstName + " " + u.LastName).Contains(name)
                                                     && (filter.EventId > 0 ? e.EventId == filter.EventId : true)
                                                     && (filter.CustomerId > 0 ? ec.CustomerId == filter.CustomerId : true)
                                               orderby u.FirstName
                                               select new { ec.EventCustomerId, u.FirstName });

                    var temp = queryWithExpression.TakePage(pageNumber, pageSize).ToList();
                    var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                    var eventCustomers = GetByIds(eventCustomerIds);
                    return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                }

            }
        }

        public DateTime? GetPreviousAttendedEventDate(long eventId, long customerId, DateTime eventDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                        where ec.CustomerId == customerId && ec.EventId != eventId
                              && ec.AppointmentId.HasValue && (!ec.NoShow) && ec.LeftWithoutScreeningReasonId == null
                              && e.EventDate < eventDate
                        orderby e.EventDate descending
                        select e.EventDate).ToArray().Cast<DateTime?>().FirstOrDefault();

            }
        }

        public IEnumerable<EventCustomer> EventCustomersForHospitalPartner(int pageNumber, int pageSize, HospitalPartnerCustomerListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var currentDate = DateTime.Now.Date;
                const int deliveredResultState = (int)TestResultStateNumber.ResultDelivered;
                const int signedRegulatoryState = (int)RegulatoryState.Signed;

                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }

                var maximumValidityPeriod = 0;
                if (normalValidityPeriod > abnormalValidityPeriod && normalValidityPeriod > criticalValidityPeriod)
                    maximumValidityPeriod = normalValidityPeriod;
                else if (abnormalValidityPeriod > criticalValidityPeriod)
                    maximumValidityPeriod = abnormalValidityPeriod;
                else
                    maximumValidityPeriod = criticalValidityPeriod;

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                var query = (from cars in linqMetaData.VwCustomerAggregateResultSummary
                             join ec in linqMetaData.EventCustomers on new { cars.EventCustomerId, filter.EventId } equals new { ec.EventCustomerId, ec.EventId }
                             //join ea in linqMetaData.EventAppointment on new { cars.AppointmentId, filter.EventId } equals new { ea.AppointmentId, ea.EventId }
                             join ea in linqMetaData.EventAppointment on cars.AppointmentId equals ea.AppointmentId
                             where
                                (filter.HospitalPartnerId > 0 ? cars.HospitalPartnerId == filter.HospitalPartnerId : true)
                                && (filter.HospitalFacilityId > 0 ? cars.HospitalFacilityId == filter.HospitalFacilityId : true)
                                && cars.PartnerRelease == signedRegulatoryState
                                && cars.HiPaastatus == signedRegulatoryState
                                && !cars.NoShow
                                && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                                && (
                                        (((cars.ResultSummary == 0 //&& cars.ResultState == deliveredResultState
                                            && (maximumValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * maximumValidityPeriod)))
                                        ||
                                        (cars.ResultSummary == (long)ResultInterpretation.Normal //&& cars.ResultState == deliveredResultState
                                            && (normalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * normalValidityPeriod)))
                                        ||
                                        (cars.ResultSummary == (long)ResultInterpretation.Abnormal //&& cars.ResultState == deliveredResultState
                                            && (abnormalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * abnormalValidityPeriod)))
                                        ||
                                        (cars.ResultSummary == (long)ResultInterpretation.Urgent //&& cars.ResultState == deliveredResultState
                                            && (criticalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * criticalValidityPeriod)))
                                        ) && cars.ResultState == deliveredResultState) ||
                                        ((cars.ResultSummary == (long)ResultInterpretation.Critical || criticalEventCustomerResultIds.Contains(cars.EventCustomerId))
                                            && (criticalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * criticalValidityPeriod)))
                                    )
                             select cars);

                //if (filter.EventId > 0)
                //{
                //    query = query.Where(q => q.EventId == filter.EventId);
                //}

                totalRecords = query.Count();

                var queryable = SortHospitalPartnerCustomers(query, filter.SortingColumn, filter.SortingOrder);

                var eventCustomerIds = queryable.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomers = GetByIds(eventCustomerIds);

                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public IEnumerable<EventCustomer> SearchCustomersForHospitalPartner(int pageNumber, int pageSize, HospitalPartnerCustomerListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var currentDate = DateTime.Now.Date;
                const int deliveredResultState = (int)TestResultStateNumber.ResultDelivered;
                const int signedRegulatoryState = (int)RegulatoryState.Signed;
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }
                var maximumValidityPeriod = 0;
                if (normalValidityPeriod > abnormalValidityPeriod && normalValidityPeriod > criticalValidityPeriod)
                    maximumValidityPeriod = normalValidityPeriod;
                else if (abnormalValidityPeriod > criticalValidityPeriod)
                    maximumValidityPeriod = abnormalValidityPeriod;
                else
                    maximumValidityPeriod = criticalValidityPeriod;

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);
                var query = from cars in linqMetaData.VwCustomerAggregateResultSummary
                            join ea in linqMetaData.EventAppointment on cars.AppointmentId equals ea.AppointmentId
                            where
                                (filter.HospitalPartnerId > 0 ? cars.HospitalPartnerId == filter.HospitalPartnerId : true)
                                && (filter.HospitalFacilityId > 0 ? cars.HospitalFacilityId == filter.HospitalFacilityId : true)
                                && cars.PartnerRelease == signedRegulatoryState
                                && cars.HiPaastatus == signedRegulatoryState
                                && !cars.NoShow
                                && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                            select cars;

                if (filter.EventId < 1 && filter.CustomerId < 1 && (filter.ResultSummary > 0 || filter.CriticalMarkedByTechnician))
                {

                    query = (from cars in query
                             where
                                 (filter.ResultSummary <= 0 || (cars.ResultSummary == filter.ResultSummary &&
                                 (
                                 (((cars.ResultSummary == (long)ResultInterpretation.Normal
                             && (normalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * normalValidityPeriod)))
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Abnormal
                             && (abnormalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * abnormalValidityPeriod)))
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Urgent
                             && (criticalValidityPeriod < 1 || cars.EventDate.AddDays(criticalValidityPeriod) >= currentDate.AddDays(-1 * criticalValidityPeriod)))
                             ) && cars.ResultState == deliveredResultState)
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Critical
                             && (criticalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * criticalValidityPeriod)))
                                 ))
                                 )
                                 && (filter.CriticalMarkedByTechnician == false ||
                                 ((criticalEventCustomerResultIds.Contains(cars.EventCustomerId))
                             && (criticalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * criticalValidityPeriod)))
                                 )
                             select cars);

                }
                else
                {
                    query = (from cars in query
                             where (
                                 (((cars.ResultSummary == 0 && cars.ResultState == deliveredResultState
                                 && (maximumValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * maximumValidityPeriod)))
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Normal
                                 && (normalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * normalValidityPeriod)))
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Abnormal
                                 && (abnormalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * abnormalValidityPeriod)))
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Urgent
                                 && (criticalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * criticalValidityPeriod)))
                                 ) && cars.ResultState == deliveredResultState)
                                 ||
                                 ((cars.ResultSummary == (long)ResultInterpretation.Critical || criticalEventCustomerResultIds.Contains(cars.EventCustomerId))
                                 && (criticalValidityPeriod < 1 || cars.EventDate >= currentDate.AddDays(-1 * criticalValidityPeriod)))
                                 )
                             select cars);
                }

                if (filter.EventId > 0)
                    query = query.Where(q => q.EventId == filter.EventId);
                else if (filter.CustomerId > 0)
                    query = query.Where(q => q.CustomerId == filter.CustomerId);
                else
                {
                    if (filter.Status > 0)
                    {
                        query = query.Where(q => q.HospitalPartnerStatus == filter.Status);
                    }

                    if (filter.DateType == (int)HospitalPartnerCustomerDateTypeFilter.LastModifiedDate)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.HospitalPartnerLastModifiedDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.HospitalPartnerLastModifiedDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }
                    else if (filter.DateType == (int)HospitalPartnerCustomerDateTypeFilter.EventDate)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.EventDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }

                    else if (filter.DateType == (int)HospitalPartnerCustomerDateTypeFilter.ResultStatusUpdatedDate)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.ResultStatusUpdatedDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.ResultStatusUpdatedDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }

                    else if (filter.DateType == (int)HospitalPartnerCustomerDateTypeFilter.DateOfBirth)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.Dob >= filter.FromDate.Value.Date);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.Dob <= filter.ToDate.Value.Date);
                    }

                    if (!string.IsNullOrEmpty(filter.Pod))
                    {
                        query = from q in query
                                join ep in linqMetaData.EventPod on q.EventId equals ep.EventId
                                join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                where ep.IsActive && p.Name.Contains(filter.Pod)
                                select q;
                    }

                    if (!string.IsNullOrEmpty(filter.CustomerName))
                    {
                        query = from q in query
                                where (q.FirstName + (q.MiddleName.Length > 0 ? " " + q.MiddleName + " " : " ") + q.LastName).Contains(filter.CustomerName)
                                select q;
                    }

                    if (!string.IsNullOrEmpty(filter.PhoneNumber))
                    {
                        var phoneNumber = filter.PhoneNumber.Replace("-", "").Replace("(", "").Replace(")", "");
                        query = query.Where(q => q.PhoneHome.Contains(phoneNumber) || q.PhoneCell.Contains(phoneNumber) || q.PhoneOffice.Contains(phoneNumber));
                    }

                }
                totalRecords = query.Count();

                var queryable = SortHospitalPartnerCustomers(query, filter.SortingColumn, filter.SortingOrder);

                var eventCustomerIds = queryable.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomers = GetByIds(eventCustomerIds);

                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        private IQueryable<long> SortHospitalPartnerCustomers(IQueryable<VwCustomerAggregateResultSummaryEntity> query, int sortingColumn, int sortingOrder)
        {
            var queryForSorting = (from q in query
                                   select new
                                   {
                                       q.EventCustomerId,
                                       q.LastName,
                                       q.ResultSummaryOrder,
                                       q.HospitalPartnerStatusOrder,
                                       q.HospitalPartnerLastModifiedDate,
                                       q.ShippingStatus,
                                       q.EventDate,
                                       SortEventId = q.EventId
                                       ,
                                       InitialCallDate = q.InitialCallDate == null ? (sortingOrder == (int)SortingOrder.Ascending ? DateTime.MaxValue : new DateTime(1901, 1, 1)) : q.InitialCallDate
                                   }).Distinct();


            if (sortingOrder == (int)SortingOrder.Ascending)
            {
                var orderedQueryable = OrderBy(queryForSorting, ((HospitalPartnerCustomerSortingColumn)sortingColumn).GetDescription());
                if (sortingColumn == (int)HospitalPartnerCustomerSortingColumn.EventDate)
                    orderedQueryable = ThenBy(orderedQueryable, "SortEventId");

                return orderedQueryable.Select(qs => qs.EventCustomerId);
            }
            else
            {
                var orderedQueryable = OrderByDescending(queryForSorting, ((HospitalPartnerCustomerSortingColumn)sortingColumn).GetDescription());
                if (sortingColumn == (int)HospitalPartnerCustomerSortingColumn.EventDate)
                    orderedQueryable = ThenBy(orderedQueryable, "SortEventId");

                return orderedQueryable.Select(qs => qs.EventCustomerId);
            }

        }

        public IEnumerable<EventCustomer> GetEventCustomersForAuthorization(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var authorizedEventCustomerIds = (from sa in linqMetaData.ScreeningAuthorization
                                                  select sa.EventCustomerId);

                var entities = (from ec in linqMetaData.EventCustomers
                                where ec.EventId == eventId
                                      && ec.AppointmentId.HasValue && !ec.NoShow
                                      && !authorizedEventCustomerIds.Contains(ec.EventCustomerId)
                                select ec);
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForDeferredRevenue(int pageNumber, int pageSize, DeferredRevenueListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }

                var query = from ec in linqMetaData.EventCustomers
                            join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                            join op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData) on ec.EventId equals op.FirstValue.EventId
                            join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals ecp.EventCustomerId
                            where !ea.CheckinTime.HasValue && !ea.CheckoutTime.HasValue && ecp.OrderTotal > 0 && (filter.PaidCustomers && !filter.UnPaidCustomers ? ecp.NetPayment > 0 : true)
                            && (filter.UnPaidCustomers && !filter.PaidCustomers ? ecp.OrderTotal > ecp.NetPayment : true)
                            select new { ec, op };

                if (filter.EventId > 0)
                {
                    var queryForEcs = (from q in query
                                       where q.ec.EventId == filter.EventId
                                       orderby q.op.FirstValue.EventDate, q.op.FirstValue.EventId
                                       select q.ec);
                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }
                else
                {
                    if (!string.IsNullOrEmpty(filter.Pod))
                    {
                        var podString = string.IsNullOrEmpty(filter.Pod) ? "" : filter.Pod;

                        var eventIds = (from ep in linqMetaData.EventPod
                                        join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                        where ep.IsActive && p.Name.Contains(podString)
                                        select ep.EventId).Distinct();

                        query = (from q in query
                                 where eventIds.Contains(q.op.FirstValue.EventId)
                                 select q);
                    }
                    if (filter.FromEventDate.HasValue || filter.ToEventDate.HasValue)
                    {
                        var fromDate = filter.FromEventDate.HasValue ? filter.FromEventDate.Value.Date : DateTime.Now.Date;
                        var toDate = filter.ToEventDate.HasValue ? filter.ToEventDate.Value.Date : DateTime.Now.Date;

                        query = from q in query
                                where
                                    (filter.FromEventDate != null ? q.op.FirstValue.EventDate >= fromDate : true) &&
                                    (filter.ToEventDate != null ? q.op.FirstValue.EventDate <= toDate : true)
                                select q;
                    }

                    if (filter.FromRegistrationDate.HasValue)
                        query = query.Where(q => q.ec.DateCreated >= filter.FromRegistrationDate.Value);

                    if (filter.ToRegistrationDate.HasValue)
                        query = query.Where(q => q.ec.DateCreated < filter.ToRegistrationDate.Value.AddHours(23).AddMinutes(59));

                    if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                        query = query.Where(a => !a.op.SecondValue);
                    else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                        query = query.Where(a => a.op.SecondValue);

                    if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                        query = query.Where(a => a.op.FirstValue.EventTypeId == (long)RegistrationMode.Public);
                    else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                        query = query.Where(a => a.op.FirstValue.EventTypeId == (long)RegistrationMode.Private);

                    var countQuery = (from q in query select q.ec);
                    totalRecords = countQuery.Count();

                    var queryForEcs = (from q in query
                                       orderby q.op.FirstValue.EventDate descending, q.op.FirstValue.EventId, q.ec.EventCustomerId
                                       select new { q.op.FirstValue.EventDate, q.op.FirstValue.EventId, q.ec.EventCustomerId });


                    var temp = queryForEcs.TakePage(pageNumber, pageSize).ToList();

                    var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                    var eventCustomers = GetByIds(eventCustomerIds);
                    return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                }

            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForAggregateResultSummary(int pageNumber, int pageSize, HospitalPartnerCustomerListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                const int deliveredResultState = (int)TestResultStateNumber.ResultDelivered;

                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }

                var isHipaaEnabled = Convert.ToBoolean(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.IsHipaaEnabled));

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                var query = (from cars in linqMetaData.VwCustomerAggregateResultSummary
                             join ea in linqMetaData.EventAppointment on cars.AppointmentId equals ea.AppointmentId
                             where (isHipaaEnabled == false || cars.HiPaastatus == (int)RegulatoryState.Signed)
                                   && !cars.NoShow
                                   && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                             select cars);



                if (filter.EventId < 1 && filter.CustomerId < 1 && (filter.ResultSummary > 0 || filter.CriticalMarkedByTechnician))
                {
                    query = (from cars in query
                             where
                                 (filter.ResultSummary <= 0 || (cars.ResultSummary == filter.ResultSummary && cars.ResultState == deliveredResultState &&
                                 (
                                 (cars.ResultSummary == (long)ResultInterpretation.Normal)
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Abnormal)
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Urgent)
                                 ||
                                 (cars.ResultSummary == (long)ResultInterpretation.Critical)
                                 ))
                                 )
                                 && (filter.CriticalMarkedByTechnician == false || (criticalEventCustomerResultIds.Contains(cars.EventCustomerId)))
                             select cars);

                }
                else
                {
                    query = (from cars in query
                             where
                                 (
                                     (cars.ResultState == deliveredResultState && (
                                     (cars.ResultSummary == 0)
                                     ||
                                     (cars.ResultSummary == (long)ResultInterpretation.Normal)
                                     ||
                                     (cars.ResultSummary == (long)ResultInterpretation.Abnormal)
                                     ||
                                     (cars.ResultSummary == (long)ResultInterpretation.Urgent)
                                     ))
                                     ||
                                     (cars.ResultSummary == (long)ResultInterpretation.Critical || criticalEventCustomerResultIds.Contains(cars.EventCustomerId))
                                 )
                             select cars);
                }

                if (filter.EventId > 0)
                    query = query.Where(q => q.EventId == filter.EventId);
                else if (filter.CustomerId > 0)
                    query = query.Where(q => q.CustomerId == filter.CustomerId);
                else
                {
                    if (filter.HospitalPartnerId > 0)
                        query = query.Where(q => q.HospitalPartnerId == filter.HospitalPartnerId);

                    if (filter.CorporateAccountId > 0)
                        query = query.Where(q => q.CorporateAccountId == filter.CorporateAccountId);

                    if (filter.Status > 0)
                    {
                        query = query.Where(q => q.HospitalPartnerStatus == filter.Status);
                    }

                    if (filter.DateType == (int)HospitalPartnerCustomerDateTypeFilter.LastModifiedDate)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.HospitalPartnerLastModifiedDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.HospitalPartnerLastModifiedDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }
                    else if (filter.DateType == (int)HospitalPartnerCustomerDateTypeFilter.EventDate)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.EventDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }
                    else if (filter.DateType == (int)HospitalPartnerCustomerDateTypeFilter.DateOfBirth)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.Dob >= filter.FromDate.Value.Date);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.Dob <= filter.ToDate.Value.Date);
                    }

                    if (!string.IsNullOrEmpty(filter.Pod))
                    {
                        query = from q in query
                                join ep in linqMetaData.EventPod on q.EventId equals ep.EventId
                                join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                where ep.IsActive && p.Name.Contains(filter.Pod)
                                select q;
                    }

                    if (!string.IsNullOrEmpty(filter.CustomerName))
                    {
                        query = from q in query
                                where (q.FirstName + (q.MiddleName.Length > 0 ? " " + q.MiddleName + " " : " ") + q.LastName).Contains(filter.CustomerName)
                                select q;
                    }

                    if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                    {
                        query = query.Where(q => q.CorporateAccountId == 0);
                    }
                    else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                    {
                        query = query.Where(q => q.CorporateAccountId > 0);
                    }

                    if (filter.IsHospitalPartnerAttached)
                    {
                        query = query.Where(q => q.HospitalPartnerId > 0);
                    }

                    if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                        query = query.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                    else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                        query = query.Where(q => q.EventTypeId == (long)RegistrationMode.Private);

                    if (!string.IsNullOrEmpty(filter.PhoneNumber))
                    {
                        var phoneNumber = filter.PhoneNumber.Replace("-", "").Replace("(", "").Replace(")", "");
                        query = query.Where(q => q.PhoneHome.Contains(phoneNumber) || q.PhoneCell.Contains(phoneNumber) || q.PhoneOffice.Contains(phoneNumber));
                    }

                }
                totalRecords = query.Count();
                var queryable = SortHospitalPartnerCustomers(query, filter.SortingColumn, filter.SortingOrder);

                var eventCustomerIds = queryable.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomers = GetByIds(eventCustomerIds);

                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public bool DeleteEventCustomer(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(EventCustomerOrderDetailFields.EventCustomerId == eventCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerOrderDetailEntity), bucket);

                adapter.DeleteEntitiesDirectly(typeof(EventAppointmentChangeLogEntity), new RelationPredicateBucket(EventAppointmentChangeLogFields.EventCustomerId == eventCustomerId));

                adapter.DeleteEntitiesDirectly(typeof(CustomerHealthInfoEntity), new RelationPredicateBucket(CustomerHealthInfoFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(CustomerHealthInfoArchiveEntity), new RelationPredicateBucket(CustomerHealthInfoArchiveFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerNotificationEntity), new RelationPredicateBucket(EventCustomerNotificationFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(PcpAppointmentEntity), new RelationPredicateBucket(PcpAppointmentFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(PcpDispositionEntity), new RelationPredicateBucket(PcpDispositionFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPreApprovedTestEntity), new RelationPredicateBucket(EventCustomerPreApprovedTestFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventAppointmentCancellationLogEntity), new RelationPredicateBucket(EventAppointmentCancellationLogFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPreApprovedPackageTestEntity), new RelationPredicateBucket(EventCustomerPreApprovedPackageTestFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPrimaryCarePhysicianEntity), new RelationPredicateBucket(EventCustomerPrimaryCarePhysicianFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(CheckListAnswerEntity), new RelationPredicateBucket(CheckListAnswerFields.EventCustomerId == eventCustomerId));

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerQuestionAnswerEntity), new RelationPredicateBucket(EventCustomerQuestionAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(DisqualifiedTestEntity), new RelationPredicateBucket(DisqualifiedTestFields.EventCustomerId == eventCustomerId));

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerIcdCodesEntity), new RelationPredicateBucket(EventCustomerIcdCodesFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerCurrentMedicationEntity), new RelationPredicateBucket(EventCustomerCurrentMedicationFields.EventCustomerId == eventCustomerId));

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerDiagnosisEntity), new RelationPredicateBucket(EventCustomerDiagnosisFields.EventCustomerId == eventCustomerId));

                adapter.UpdateEntitiesDirectly(new CallQueueCustomerEntity { EventCustomerId = null }, new RelationPredicateBucket(CallQueueCustomerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerRetestEntity), new RelationPredicateBucket(EventCustomerRetestFields.EventCustomerId == eventCustomerId));

                adapter.DeleteEntitiesDirectly(typeof(FluConsentAnswerEntity), new RelationPredicateBucket(FluConsentAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(FluConsentSignatureEntity), new RelationPredicateBucket(FluConsentSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ParticipationConsentSignatureEntity), new RelationPredicateBucket(ParticipationConsentSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(PhysicianRecordRequestSignatureEntity), new RelationPredicateBucket(PhysicianRecordRequestSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ChaperoneAnswerEntity), new RelationPredicateBucket(ChaperoneAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ChaperoneSignatureEntity), new RelationPredicateBucket(ChaperoneSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ExitInterviewAnswerEntity), new RelationPredicateBucket(ExitInterviewAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(SurveyAnswerEntity), new RelationPredicateBucket(SurveyAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerGiftCardEntity), new RelationPredicateBucket(EventCustomerGiftCardFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(CustomerOrderHistoryEntity), new RelationPredicateBucket(CustomerOrderHistoryFields.EventCustomerId == eventCustomerId));

                bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);

                return (adapter.DeleteEntitiesDirectly(typeof(EventCustomersEntity), bucket) > 0) ? true : false;
            }
        }

        public IEnumerable<EventCustomer> GetCancelledEventCustomers(int pageNumber, int pageSize, CancelledCustomerModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                if (filter == null)
                {
                    var query = (from ec in linqMetaData.EventCustomers
                                 join e in linqMetaData.Events on ec.EventId equals e.EventId
                                 where ec.AppointmentId == null
                                 orderby e.EventDate descending
                                 select ec);
                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }
                else
                {

                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                    var query = (from ec in linqMetaData.EventCustomers
                                 join op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData) on
                                     ec.EventId equals op.FirstValue.EventId
                                 where ec.AppointmentId == null
                                       && (filter.FromDate != null ? fromDate <= op.FirstValue.EventDate : true)
                                       && (filter.ToDate != null ? toDate >= op.FirstValue.EventDate : true)
                                       && (filter.IsRetailEvent && !filter.IsCorporateEvent
                                               ? (!op.SecondValue)
                                               : (!filter.IsRetailEvent && filter.IsCorporateEvent
                                                      ? op.SecondValue
                                                      : true))
                                       && ((filter.IsPublicEvent && !filter.IsPrivateEvent)
                                               ? op.FirstValue.EventTypeId == (long)RegistrationMode.Public
                                               : (!filter.IsPublicEvent && filter.IsPrivateEvent)
                                                     ? op.FirstValue.EventTypeId == (long)RegistrationMode.Private
                                                     : true)
                                 select new { ec, op });

                    if (filter.CorporateAccountId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.CorporateAccountId select ea.EventId);

                        query = (from q in query where eventIds.Contains(q.ec.EventId) select q);
                    }

                    if (filter.HospitalPartnerId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventHospitalPartner where ea.HospitalPartnerId == filter.HospitalPartnerId select ea.EventId);

                        query = (from q in query where eventIds.Contains(q.ec.EventId) select q);
                    }

                    var countQuery = (from q in query select q.ec);
                    totalRecords = countQuery.Count();

                    var cancelledquery = (from q in query
                                          orderby q.op.FirstValue.EventDate descending, q.ec.EventCustomerId
                                          select new { q.op.FirstValue.EventDate, q.ec.EventCustomerId });


                    var temp = cancelledquery.TakePage(pageNumber, pageSize).ToArray();
                    var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                    var eventCustomers = GetByIds(eventCustomerIds);
                    return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                }

            }
        }

        public EventCustomer GetEventCustomerByOrderId(long orderId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ecod in linqMetaData.EventCustomerOrderDetail
                              join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                              join ec in linqMetaData.EventCustomers on ecod.EventCustomerId equals ec.EventCustomerId
                              where od.OrderId == orderId && ecod.IsActive
                              select ec).FirstOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map(entity);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForCdLabel(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var productOrders = (from od in linqMetaData.OrderDetail
                                     join poi in linqMetaData.ProductOrderItem on od.OrderItemId equals poi.OrderItemId
                                     where od.Status == (int)OrderStatusState.FinalSuccess
                                         && poi.ProductId == (long)Product.UltraSoundImages
                                     select od.OrderId);

                long cdShippinOptionId = 0;
                var cdShippingOption = _shippingOptionRepository.GetShippingOptionByProductId((long)Product.UltraSoundImages);
                if (cdShippingOption != null)
                    cdShippinOptionId = cdShippingOption.Id;

                var cdOrders = (from od in linqMetaData.OrderDetail
                                join sdod in linqMetaData.ShippingDetailOrderDetail on od.OrderDetailId equals sdod.OrderDetailId
                                join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                where productOrders.Contains(od.OrderId) && sdod.IsActive
                                && od.Status == (int)OrderStatusState.FinalSuccess
                                && (cdShippinOptionId > 0 ? sd.ShippingOptionId == cdShippinOptionId : false)
                                select od.OrderId);

                var entities = (from ec in linqMetaData.EventCustomers
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                where ec.EventId == eventId && ecod.IsActive && ec.AppointmentId.HasValue && !ec.NoShow
                                && cdOrders.Contains(od.OrderId)
                                orderby ea.StartTime
                                select ec).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForShippingRevenueDetail(int pageNumber, int pageSize, ShippingRevenueListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIdsWithShipping = (from ecod in linqMetaData.EventCustomerOrderDetail
                                                    join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                                    join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                                    where ecod.IsActive && sdod.IsActive
                                                    && sd.ActualPrice > 0
                                                    select ecod.EventCustomerId);

                var query = (from ec in linqMetaData.EventCustomers
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             where eventCustomerIdsWithShipping.Contains(ec.EventCustomerId)
                             && ec.AppointmentId.HasValue
                             select new { ec, e.EventDate });
                if (filter.EventId > 0)
                {
                    query = query.Where(q => q.ec.EventId == filter.EventId);
                }
                else
                {
                    if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    {
                        var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value.Date : DateTime.Now.Date;
                        var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.Date : DateTime.Now.Date;

                        query = from q in query
                                where
                                    (filter.FromDate != null ? q.EventDate >= fromDate : true) &&
                                    (filter.ToDate != null ? q.EventDate <= toDate : true)
                                select q;
                    }

                    if (filter.PodId > 0)
                    {
                        var podEventIds = (from ep in linqMetaData.EventPod
                                           where ep.PodId == filter.PodId
                                           select ep.EventId);

                        query = from q in query
                                where podEventIds.Contains(q.ec.EventId)
                                select q;
                    }
                }

                var countQuery = from q in query select q.ec;
                totalRecords = countQuery.Count();

                var eventCustomerQuery = from q in query
                                         orderby q.EventDate, q.ec.EventId, q.ec.EventCustomerId
                                         select new { q.EventDate, q.ec.EventId, q.ec.EventCustomerId };


                var temp = eventCustomerQuery.TakePage(pageNumber, pageSize).ToArray();
                var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                var eventCustomers = GetByIds(eventCustomerIds);
                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();

            }
        }

        public static IOrderedQueryable<T> OrderBy<T>(IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }
        public static IOrderedQueryable<T> ThenBy<T>(IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }
        public static IOrderedQueryable<T> ThenByDescending<T>(IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }
        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = System.Linq.Expressions.Expression.Parameter(type, "x");
            System.Linq.Expressions.Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = System.Linq.Expressions.Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = System.Linq.Expressions.Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }

        public IEnumerable<EventCustomer> GetCustomerOpenOrder(int pageNumber, int pageSize, CustomerOpenOrderListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;

                var query = (from ec in linqMetaData.EventCustomers
                             join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals ecp.EventCustomerId
                             join op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData) on ec.EventId equals op.FirstValue.EventId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                 into ecea
                             from ee in ecea.DefaultIfEmpty()
                             where (ec.AppointmentId.HasValue
                                        ? ((!ee.CheckinTime.HasValue && !ee.CheckoutTime.HasValue && !ec.NoShow) ||
                                           (ec.NoShow && ecp.NetPayment > 0))
                                        : ecp.NetPayment > 0)
                                   && ecp.OrderTotal > 0
                             select new { ec, op });

                if (filter.EventId > 0)
                {
                    var queryForEcs = (from q in query
                                       where q.ec.EventId == filter.EventId
                                       orderby q.op.FirstValue.EventDate, q.op.FirstValue.EventId
                                       select q.ec);
                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }
                else
                {
                    if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    {
                        var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value.Date : DateTime.Now.Date;
                        var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.Date : DateTime.Now.Date;

                        query = from q in query
                                where
                                    (filter.FromDate != null ? q.op.FirstValue.EventDate >= fromDate : true) &&
                                    (filter.ToDate != null ? q.op.FirstValue.EventDate <= toDate : true)
                                select q;
                    }

                    if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                        query = query.Where(a => !a.op.SecondValue);
                    else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                        query = query.Where(a => a.op.SecondValue);

                    if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                        query = query.Where(a => a.op.FirstValue.EventTypeId == (long)RegistrationMode.Public);
                    else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                        query = query.Where(a => a.op.FirstValue.EventTypeId == (long)RegistrationMode.Private);

                    var countQuery = (from q in query select q.ec);
                    totalRecords = countQuery.Count();

                    var queryForEcs = (from q in query
                                       orderby q.op.FirstValue.EventDate descending, q.op.FirstValue.EventId, q.ec.EventCustomerId
                                       select new { q.op.FirstValue.EventDate, q.op.FirstValue.EventId, q.ec.EventCustomerId });


                    var temp = queryForEcs.TakePage(pageNumber, pageSize).ToArray();
                    var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                    var eventCustomers = GetByIds(eventCustomerIds);
                    return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                }

            }
        }


        public IEnumerable<EventCustomer> GetEventsforCorporateAccountInvoice(int pageNumber, int pageSize, CorporateAccountInvoiceListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corpCode = string.IsNullOrEmpty(filter.CorpCode) ? "" : filter.CorpCode.Trim();

                var query = from e in linqMetaData.Events select e;
                if (filter.EventId > 0)
                {
                    query = from q in query
                            where q.EventId == filter.EventId
                            select q;
                }
                else
                {
                    query = from q in query
                            join ea in linqMetaData.EventAccount on q.EventId equals ea.EventId
                            join a in linqMetaData.Account on ea.AccountId equals a.AccountId
                            where (filter.AccountId < 1 || a.AccountId == filter.AccountId)
                                  && (corpCode.Length < 1 || a.CorpCode == corpCode)
                            select q;

                    if (filter.EventFrom != null)
                        query = from q in query where q.EventDate >= filter.EventFrom.Value select q;


                    if (filter.EventTo != null)
                        query = from q in query where q.EventDate <= filter.EventTo.Value select q;
                }
                var countQuery = from q in query
                                 join ec in linqMetaData.EventCustomers on q.EventId equals ec.EventId
                                 join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                 where ec.AppointmentId != null && !ec.NoShow
                                 select ec;

                totalRecords = countQuery.Count();

                var queryEc = from q in query
                              join ec in linqMetaData.EventCustomers on q.EventId equals ec.EventId
                              join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                              where ec.AppointmentId != null && !ec.NoShow
                              orderby q.EventDate, q.EventId, ea.StartTime, ec.EventCustomerId
                              select new { q.EventDate, q.EventId, ea.StartTime, ec.EventCustomerId };

                var temp = queryEc.TakePage(pageNumber, pageSize).ToArray();
                var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                var eventCustomers = GetByIds(eventCustomerIds);
                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public IEnumerable<EventCustomer> GetByEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ec in linqMetaData.EventCustomers
                                where eventIds.Contains(ec.EventId)
                                select ec).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersWithCdPurchaseByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var cdOrders = (from od in linqMetaData.OrderDetail
                                join poi in linqMetaData.ProductOrderItem on od.OrderItemId equals poi.OrderItemId
                                where od.Status == (int)OrderStatusState.FinalSuccess
                                    && poi.ProductId == (long)Product.UltraSoundImages
                                select od.OrderId);

                var entities = (from ec in linqMetaData.EventCustomers
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                where ec.EventId == eventId && ecod.IsActive && ec.AppointmentId.HasValue && !ec.NoShow && cdOrders.Contains(od.OrderId)
                                select ec).Distinct().ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForShippingLabels(long eventId, int shippingStatus)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from ec in linqMetaData.EventCustomers
                                        join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                        join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                        join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                        where ec.EventId == eventId && ec.AppointmentId.HasValue
                                        && (shippingStatus > 0 ? sd.Status == shippingStatus : true)
                                        select ec.EventCustomerId).ToArray();

                if (eventCustomerIds.IsNullOrEmpty())
                    return null;

                return GetByIds(eventCustomerIds);

            }
        }

        public IEnumerable<EventCustomer> GetByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ec in linqMetaData.EventCustomers
                                where customerIds.Contains(ec.CustomerId)
                                select ec).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForTestUpsellNotification(int days)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                var entities = (from ec in linqMetaData.EventCustomers
                                join e in linqMetaData.Events on ec.EventId equals e.EventId
                                where
                                    ec.AppointmentId.HasValue && ec.CustomerId == ec.CreatedByOrgRoleUserId
                                    && e.EventDate > DateTime.Now.Date
                                    && e.EnableAlaCarteOnline
                                    && !corporateEventIds.Contains(ec.EventId)
                                    && ec.DateCreated.HasValue && ec.DateCreated.Value.Date == DateTime.Now.AddDays(-1 * days).Date
                                select ec).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForSecondScreeingReminderNotification(int hours, int interval)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                var currentDate = DateTime.Now;
                var eventIds = (from e in linqMetaData.Events
                                where
                                    e.EventDate.Date == currentDate.Date && e.IsActive && e.EventStatus.HasValue &&
                                    e.EventStatus.Value == (int)EventStatus.Active
                                select e.EventId);

                if (eventIds.Any())
                {
                    var entities = (from ec in linqMetaData.EventCustomers
                                    join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                    where eventIds.Contains(ec.EventId)
                                          && ea.StartTime >= currentDate.AddHours(hours)
                                          && ea.StartTime < currentDate.AddHours(hours + interval)
                                          && !ec.NoShow
                                          && !corporateEventIds.Contains(ec.EventId)
                                    select ec).ToArray();
                    return Mapper.MapMultiple(entities);
                }
                return null;
            }
        }

        public bool UpdateHospitalFacility(long eventCustomerId, long? hospitalfacilityId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { HospitalFacilityId = hospitalfacilityId };
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForKynFirstNotification(int days, int pageNumber, int pageSize, out long totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var queryEc = (from ec in linqMetaData.EventCustomers
                               join e in linqMetaData.Events on ec.EventId equals e.EventId
                               where ec.AppointmentId.HasValue
                               && e.EventDate > DateTime.Now
                               && ec.DateCreated.HasValue && ec.DateCreated.Value.Date == DateTime.Now.AddDays(-1 * days).Date
                               orderby ec.EventCustomerId
                               select ec);

                totalRecords = queryEc.Count();

                var entities = queryEc.TakePage(pageNumber, pageSize).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForKynSecondNotification(int hours, int interval, int pageNumber, int pageSize, out long totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var currentDate = DateTime.Now;

                var queryEc = (from ec in linqMetaData.EventCustomers
                               join e in linqMetaData.Events on ec.EventId equals e.EventId
                               join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                               where ec.AppointmentId.HasValue
                               && e.EventDate > DateTime.Now
                               && ea.StartTime >= currentDate.AddHours(hours)
                               && ea.StartTime < currentDate.AddHours(hours + interval)
                               orderby ec.EventCustomerId
                               select ec);

                totalRecords = queryEc.Count();

                var entities = queryEc.TakePage(pageNumber, pageSize).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetInsurancePayment(int pageNumber, int pageSize, InsurancePaymentListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;

                var insurancePaymentQuery = (from ip in linqMetaData.InsurancePayment
                                             join po in linqMetaData.PaymentOrder on ip.PaymentId equals po.PaymentId
                                             group ip by po.OrderId
                                                 into g
                                                 select new { OrderId = g.Key, InsuranceAmount = g.Sum(ip => ip.AmountToBePaid), PaidAmount = g.Sum(ip => ip.Amount) });

                var query = (from ec in linqMetaData.EventCustomers
                             join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                             join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                             join ipq in insurancePaymentQuery on od.OrderId equals ipq.OrderId
                             where ec.AppointmentId.HasValue && ecod.IsActive
                             select new { ec, ipq });
                if (filter.EventId > 0)
                {
                    var queryForEcs = (from q in query
                                       where q.ec.EventId == filter.EventId
                                       select q.ec);
                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    if (filter.EventFrom.HasValue || filter.EventTo.HasValue)
                    {
                        var fromDate = filter.EventFrom.HasValue ? filter.EventFrom.Value.Date : DateTime.Now.Date;
                        var toDate = filter.EventTo.HasValue ? filter.EventTo.Value.Date : DateTime.Now.Date;

                        query = (from q in query
                                 join e in linqMetaData.Events on q.ec.EventId equals e.EventId
                                 where
                                     (filter.EventFrom != null ? e.EventDate >= fromDate : true) &&
                                     (filter.EventTo != null ? e.EventDate <= toDate : true)
                                 select q);
                    }

                    if (filter.Status > 0)
                    {
                        if (filter.Status == (int)InsurancePaymentStatus.NotSettled)
                        {
                            query = (from q in query
                                     where q.ipq.InsuranceAmount > q.ipq.PaidAmount
                                     select q);
                        }
                        else if (filter.Status == (int)InsurancePaymentStatus.Settled)
                        {
                            query = (from q in query
                                     where q.ipq.InsuranceAmount <= q.ipq.PaidAmount
                                     select q);
                        }
                    }

                    var queryForEcs = (from q in query
                                       select q.ec);

                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                }
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForInsuranceClaim(int daysAfter, long billingAccountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);


                var insurancePaymentQuery = (from ip in linqMetaData.InsurancePayment
                                             join po in linqMetaData.PaymentOrder on ip.PaymentId equals po.PaymentId
                                             group ip by po.OrderId
                                                 into g
                                                 select new { OrderId = g.Key, InsuranceAmount = g.Sum(ip => ip.AmountToBePaid), PaidAmount = g.Sum(ip => ip.Amount) });

                var entities = (from e in linqMetaData.Encounter
                                join ee in linqMetaData.EventCustomerEncounter on e.EncounterId equals ee.EncounterId
                                join ec in linqMetaData.EventCustomers on ee.EventCustomerId equals ec.EventCustomerId
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                join ipq in insurancePaymentQuery on od.OrderId equals ipq.OrderId
                                where ec.AppointmentId.HasValue && ecod.IsActive
                                && e.BillingAccountId == billingAccountId
                                && e.DateCreated <= DateTime.Now.AddDays(-1 * daysAfter)
                                && ipq.InsuranceAmount > ipq.PaidAmount
                                select ec);
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetKynEventCustomers(int pageNumber, int pageSize, KynCustomerModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                IQueryable<EventCustomersEntity> query;

                if (filter == null)
                {
                    var eventQuery = (from ep in linqMetaData.EventPod where ep.IsActive && ep.EnableKynIntegration select ep.EventId);

                    query = (from ec in linqMetaData.EventCustomers
                             join kyn in linqMetaData.VwGetKynTestCustomers on ec.EventCustomerId equals kyn.EventCustomerId
                             where ec.AppointmentId.HasValue && eventQuery.Contains(ec.EventId) && ec.LeftWithoutScreeningReasonId == null
                             orderby ec.DateCreated descending, ec.CustomerId
                             select ec);

                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();

                    return Mapper.MapMultiple(entities);
                }

                query = (from ec in linqMetaData.EventCustomers
                         where ec.AppointmentId.HasValue && ec.LeftWithoutScreeningReasonId == null
                         select ec);

                if (filter.ShowOnlyKyn)
                {
                    var eventQuery = (from ep in linqMetaData.EventPod where ep.IsActive && ep.EnableKynIntegration select ep.EventId);

                    query = (from q in query
                             join kyn in linqMetaData.VwGetKynTestCustomers on q.EventCustomerId equals kyn.EventCustomerId
                             where eventQuery.Contains(q.EventId)
                             select q);
                }
                else
                {
                    var donotCaptureHafEventIds = (from a in linqMetaData.Account
                                                   join ea in linqMetaData.EventAccount on a.AccountId equals ea.AccountId
                                                   where !a.CaptureHaf
                                                   select ea.EventId);

                    var eventQuery = (from ep in linqMetaData.EventPod where ep.IsActive && ep.EnableKynIntegration select ep.EventId);

                    var kynCustomerIds = (from q in query
                                          join kyn in linqMetaData.VwGetKynTestCustomers on q.EventCustomerId equals kyn.EventCustomerId
                                          where eventQuery.Contains(q.EventId)
                                          select q.EventCustomerId);

                    query = (from q in query
                             where !donotCaptureHafEventIds.Contains(q.EventId) || kynCustomerIds.Contains(q.EventCustomerId)
                             select q);
                }

                if (!string.IsNullOrEmpty(filter.Tag))
                {
                    query = query.Where(q => q.CustomerProfile.Tag == filter.Tag);
                }
                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);
                    query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                }
                if (!string.IsNullOrEmpty(filter.SponseredBy))
                {
                    var hospitalPartnerEvents = from ea in linqMetaData.EventHospitalPartner
                                                join o in linqMetaData.Organization on ea.HospitalPartnerId equals o.OrganizationId
                                                where o.Name.Contains(filter.SponseredBy)
                                                select ea.EventId;

                    var corporateEvents = from ea in linqMetaData.EventAccount
                                          join o in linqMetaData.Organization on ea.AccountId equals o.OrganizationId
                                          where o.Name.Contains(filter.SponseredBy)
                                          select ea.EventId;


                    query = query.Where(q => hospitalPartnerEvents.Contains(q.EventId) || corporateEvents.Contains(q.EventId));
                }

                if (filter.EventId > 0)
                {
                    var queryForEcs = query.Where(q => q.EventId == filter.EventId).Select(q => q);
                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    {
                        var queryWithEvents = (from q in query
                                               join e in linqMetaData.Events on q.EventId equals e.EventId
                                               select new { q, e });

                        if (filter.FromDate.HasValue)
                            queryWithEvents = queryWithEvents.Where(a => a.e.EventDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            queryWithEvents = queryWithEvents.Where(a => a.e.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));

                        query = (from q in queryWithEvents select q.q);
                    }

                    if (filter.RegistrationFromDate.HasValue || filter.RegistrationToDate.HasValue)
                    {
                        if (filter.RegistrationFromDate.HasValue)
                            query = query.Where(a => a.DateCreated >= filter.RegistrationFromDate.Value);

                        if (filter.RegistrationToDate.HasValue)
                            query = query.Where(a => a.DateCreated < filter.RegistrationToDate.Value.AddHours(23).AddMinutes(59));
                    }

                    var queryForEcs = (from ec in query
                                       orderby ec.DateCreated descending, ec.CustomerId
                                       select ec);

                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                }



                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomerBasedOnTime(DateTime fromDateTime, DateTime toDateTime, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ec in linqMetaData.EventCustomers
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                // join customer in linqMetaData.CustomerProfile on ec.CustomerId equals customer.CustomerId
                                where ec.EventId == eventId
                                      && ea.StartTime >= fromDateTime
                                      && ea.StartTime < toDateTime
                                      && !ec.NoShow
                                      && !ec.LeftWithoutScreeningReasonId.HasValue
                                      && ec.EnableTexting
                                select ec).ToArray();

                return (!entities.Any()) ? null : Mapper.MapMultiple(entities);
            }
        }


        public IEnumerable<EventCustomer> GetEventsCustomersForDailyPatientRecap(int pageNumber, int pageSize, DailyPatientRecapModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    filter = new DailyPatientRecapModelFilter { EventDateFrom = DateTime.Now, EventDateTo = DateTime.Now };
                }
                var fromDate = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.Date;
                var toDate = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now.Date;

                //var pod = string.IsNullOrEmpty(filter.Pod) ? "" : filter.Pod;

                var query = (from e in linqMetaData.Events
                             join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                             where (e.EventDate >= fromDate && e.EventDate <= toDate)
                                   && e.IsActive
                                   && !ec.NoShow
                                   && !ec.LeftWithoutScreeningReasonId.HasValue
                                   && ec.AppointmentId.HasValue
                                   && e.EventStatus.Value == (int)EventStatus.Active
                             select new { e, ec });

                if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                    query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Public);
                else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                    query = query.Where(q => q.e.EventTypeId == (long)RegistrationMode.Private);

                if (!string.IsNullOrEmpty(filter.Pod))
                {
                    query = (from q in query
                             join ep in linqMetaData.EventPod on q.e.EventId equals ep.EventId
                             join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                             where ep.IsActive && p.Name.Contains(filter.Pod)
                             select q);
                }

                if (filter.CustomerId > 0)
                {
                    query = query.Where(q => q.ec.CustomerId == filter.CustomerId);
                }

                var eventAccounts = (from ea in linqMetaData.EventAccount select ea);

                //if (filter.CorporateAccountId > 0)
                //{
                //    eventAccounts = eventAccounts.Where(x => x.AccountId == filter.CorporateAccountId);
                //}

                if (filter.CorporateAccountId > 0)
                {
                    var eventIds = eventAccounts.Where(x => x.AccountId == filter.CorporateAccountId).Select(x => x.EventId);

                    query = query.Where(q => eventIds.Contains(q.e.EventId));
                }
                else if (filter.IsRetailEvent && !filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                {
                    var eventIds = eventAccounts.Select(x => x.EventId);

                    query = query.Where(q => !eventIds.Contains(q.e.EventId));
                }
                else if (!filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                {
                    var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                    var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => eventIds.Contains(q.e.EventId));
                }
                else if (!filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                {
                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                    var eventIds = (from ea in eventAccounts where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => eventIds.Contains(q.e.EventId));
                }
                else if (!filter.IsRetailEvent && filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                {
                    var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                    query = query.Where(q => eventIds.Contains(q.e.EventId));
                }
                else if (filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                {
                    var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                    var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => !eventIds.Contains(q.e.EventId));
                }
                else if (filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                {
                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => !eventIds.Contains(q.e.EventId));
                }

                if (filter.HospitalPartnerId > 0)
                {
                    var eventids =
                        (from hp in linqMetaData.EventHospitalPartner
                         where hp.HospitalPartnerId == filter.HospitalPartnerId
                         select hp.EventId);

                    query = query.Where(q => eventids.Contains(q.e.EventId));
                }

                if (!string.IsNullOrEmpty(filter.CustomerName))
                {
                    var userids = (from q in linqMetaData.User
                                   where
                                       (q.FirstName + (q.MiddleName.Length > 0 ? " " + q.MiddleName + " " : " ") + q.LastName)
                                           .Contains(filter.CustomerName)
                                   select q.UserId);

                    var customerIds = (from oru in linqMetaData.OrganizationRoleUser
                                       where userids.Contains(oru.UserId) && oru.RoleId == (long)Roles.Customer
                                       select oru.OrganizationRoleUserId);

                    query = query.Where(q => customerIds.Contains(q.ec.CustomerId));
                }

                if (!string.IsNullOrEmpty(filter.IsGiftCertificateDeleievred))
                {
                    if (filter.IsGiftCertificateDeleievred.ToLower() == "yes")
                    {
                        query = query.Where(q => q.ec.IsGiftCertificateDelivered.HasValue && q.ec.IsGiftCertificateDelivered.Value == true);
                    }
                    else if (filter.IsGiftCertificateDeleievred.ToLower() == "no")
                    {
                        query = query.Where(q => q.ec.IsGiftCertificateDelivered.HasValue && q.ec.IsGiftCertificateDelivered.Value == false);
                    }
                }

                var countQuery = from q in query select q.ec;
                totalRecords = countQuery.Count();

                var queryEc = from q in query
                              orderby q.e.EventDate, q.ec.EventId, q.ec.CustomerId, q.ec.EventCustomerId
                              select new { q.e.EventDate, q.ec.EventId, q.ec.CustomerId, q.ec.EventCustomerId };

                var temp = queryEc.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                var eventCustomers = GetByIds(eventCustomerIds);
                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public IEnumerable<EventCustomer> GetEventsCustomersForDailyPatientRecapCustom(int pageNumber, int pageSize, DailyPatientRecapModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    filter = new DailyPatientRecapModelFilter { EventDateFrom = DateTime.Now, EventDateTo = DateTime.Now };
                }
                var fromDate = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.Date;
                var toDate = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now.Date;

                var query = (from e in linqMetaData.Events
                             join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where (e.EventDate >= fromDate && e.EventDate <= toDate)
                                   && e.IsActive
                                   && !ec.NoShow
                                   && !ec.LeftWithoutScreeningReasonId.HasValue
                                   && ec.AppointmentId.HasValue
                                   && e.EventStatus.Value == (int)EventStatus.Active
                                   && ea.CheckinTime.HasValue
                                   && ea.CheckoutTime.HasValue
                             select new { e, ec });

                if (filter.CorporateAccountId > 0)
                {
                    var eventAccounts = (from ea in linqMetaData.EventAccount select ea);

                    var eventIds = eventAccounts.Where(x => x.AccountId == filter.CorporateAccountId).Select(x => x.EventId);

                    query = query.Where(q => eventIds.Contains(q.e.EventId));
                }

                if (!string.IsNullOrWhiteSpace(filter.Tag))
                {
                    var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == filter.Tag select cp.CustomerId);

                    query = (from q in query where customerIds.Contains(q.ec.CustomerId) select q);
                }

                var countQuery = from q in query select q;

                totalRecords = countQuery.Count();

                var queryEc = from q in query
                              orderby q.e.EventDate, q.ec.EventId, q.ec.CustomerId, q.ec.EventCustomerId
                              select new { q.e.EventDate, q.ec.EventId, q.ec.CustomerId, q.ec.EventCustomerId };


                var temp = queryEc.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                var eventCustomers = GetByIds(eventCustomerIds);
                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public bool UpdateAbnStatus(long eventCustomerId, short abnStatus)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { AbnStatus = abnStatus };
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0);
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool UpdatePcpConsentStatus(long eventCustomerId, short pcpConsentStatus)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { PcpConsentStatus = pcpConsentStatus };
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0);
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool UpdateInsuranceReleaseStatus(long eventCustomerId, short insuranceReleaseStatus)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { InsuranceReleaseStatus = insuranceReleaseStatus };
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0);
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetCustomerForConfirmationCallQueue(int noOfDays)
        {
            var executionDate = DateTime.Today;
            var executionTime = DateTime.Now;
            var tenAmDate = executionDate.AddHours(19);
            if (noOfDays == 0)
                noOfDays = 1;
            int daysToAdd = executionTime < tenAmDate ? 1 : 2;
            var startDate = executionDate.AddDays(daysToAdd);
            var endDate = executionDate.AddDays(daysToAdd + noOfDays);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                var customerIds = (from e in linqMetaData.Events
                                   join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                   where e.EventDate.Date >= startDate && e.EventDate < endDate
                                         && ec.AppointmentId.HasValue
                                         && !corporateEventIds.Contains(e.EventId)
                                         && e.IsActive
                                         && e.EventStatus.Value == (int)EventStatus.Active
                                   select new OrderedPair<long, long>(ec.EventId, ec.CustomerId)).ToArray();


                return customerIds.Count() > 0 ? customerIds : null;
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetCustomersForUpsellCallQueue(decimal amount, int days)
        {
            var executionDate = DateTime.Today;
            var executionTime = DateTime.Now;
            var tenAmDate = executionDate.AddHours(19);

            int daysToAdd = executionTime < tenAmDate ? 1 : 2;

            var startDate = executionDate.AddDays(daysToAdd);
            var endDate = executionDate.AddDays(daysToAdd + days);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                var customerIds = (from e in linqMetaData.Events
                                   join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                   join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals ecp.EventCustomerId
                                   where e.EventDate >= startDate && e.EventDate < endDate
                                   && (ecp.OrderTotal <= amount && ecp.OrderTotal > 0)
                                   && ec.AppointmentId.HasValue
                                   && !corporateEventIds.Contains(e.EventId)
                                   && e.IsActive
                                   && e.EventStatus.Value == (int)EventStatus.Active
                                   select new OrderedPair<long, long>(ec.EventId, ec.CustomerId)).ToArray();

                return customerIds.Count() > 0 ? customerIds : null;
            }

        }

        // Used for Reports
        public IEnumerable<OrderedPair<long, long>> GetTestBooked(int pageNumber, int pageSize, TestsBookedListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<OrderedPair<long, long>> entities;

                if (filter == null)
                {
                    var query = (from ect in linqMetaData.VwGetAllTestForCustomers
                                 join ec in linqMetaData.EventCustomers
                                     on ect.EventCustomerId equals ec.EventCustomerId
                                 join e in linqMetaData.Events
                                     on ec.EventId equals e.EventId
                                 where e.EventDate > DateTime.Today.AddDays(-1)
                                 orderby e.EventDate
                                 select new OrderedPair<long, long>(ect.EventCustomerId, ect.TestId));

                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var query = (from ect in linqMetaData.VwGetAllTestForCustomers
                                 join ec in linqMetaData.EventCustomers
                                     on ect.EventCustomerId equals ec.EventCustomerId
                                 join e in linqMetaData.Events
                                     on ec.EventId equals e.EventId
                                 where e.EventDate > DateTime.Today.AddDays(-1)
                                 orderby e.EventDate
                                 select new { ect.EventCustomerId, ect.TestId, e.EventId, e.EventDate });

                    if (filter.TestId > 0)
                        query = query.Where(a => a.TestId == filter.TestId);

                    if (filter.EventId > 0)
                        query = query.Where(a => a.EventId == filter.EventId);

                    if (filter.FromDate.HasValue)
                        query = query.Where(a => a.EventDate >= filter.FromDate.Value);

                    if (filter.ToDate.HasValue)
                        query = query.Where(a => a.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));

                    if (!string.IsNullOrEmpty(filter.Pod))
                    {
                        var podQuery = from q in query
                                       join ep in linqMetaData.EventPod
                                           on q.EventId equals ep.EventId
                                       join p in linqMetaData.PodDetails
                                           on ep.PodId equals p.PodId
                                       where p.Name == filter.Pod
                                       select new { q.EventCustomerId, q.TestId, q.EventId, q.EventDate };
                        query = podQuery;
                    }

                    var queryFinal = query.Select(x => new OrderedPair<long, long>(x.EventCustomerId, x.TestId)).Distinct();

                    totalRecords = queryFinal.Count();
                    entities = queryFinal.TakePage(pageNumber, pageSize).ToList();

                }

                return entities;
            }
        }

        public long GetEventIdAttendedByCustomerForTest(long customerId, long testId, int numberOfDays)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var fromDate = DateTime.Today.AddDays(-1 * numberOfDays);
                var toDate = DateTime.Today;

                var linqMetaData = new LinqMetaData(adapter);
                var eventData = (from ect in linqMetaData.VwGetAllTestForCustomers
                                 join ec in linqMetaData.EventCustomers on ect.EventCustomerId equals ec.EventCustomerId
                                 join e in linqMetaData.Events on ec.EventId equals e.EventId
                                 where e.EventDate >= fromDate && e.EventDate <= toDate
                                       && ec.CustomerId == customerId && ect.TestId == testId
                                 orderby e.EventDate descending
                                 select new { e.EventId, e.EventDate }).FirstOrDefault();

                return eventData == null ? 0 : eventData.EventId;
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersByEventIdsCustomerIds(IEnumerable<long> eventIds, IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ec in linqMetaData.EventCustomers
                                where eventIds.Contains(ec.EventId) && customerIds.Contains(ec.CustomerId)
                                select ec).ToList();


                return (!entities.Any()) ? null : Mapper.MapMultiple(entities);
            }
        }
        public EventCustomer GetCustomersPreviousEventId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ec in linqMetaData.EventCustomers
                                where ec.EventId != eventId && ec.CustomerId == customerId
                                select ec).OrderByDescending(x => x.DateCreated).FirstOrDefault();


                if (entities == null)
                    return null;
                var ecust = Mapper.Map(entities);
                return ecust.AppointmentId.HasValue ? ecust : null;
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersDoesNotAppearOnEvent(long eventId, DateTime currentTime, long minutesAfterAppointmentTime, int intervalInMinitus)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var appointmentTime = currentTime.AddMinutes(-1 * minutesAfterAppointmentTime);

                var entities = (from ec in linqMetaData.EventCustomers
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                where ec.EventId == eventId && ea.StartTime >= appointmentTime && ea.StartTime < appointmentTime.AddMinutes(intervalInMinitus) &&
                                        !ea.CheckinTime.HasValue && ec.AppointmentId.HasValue
                                        && ec.LeftWithoutScreeningReasonId == null

                                select ec).ToArray();

                return (!entities.Any()) ? null : Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<ViewPcpAppointmentDisposition> GetEventCustomersForPcpAppointmentReporting(PcpAppointmentListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                filter = filter ?? new PcpAppointmentListModelFilter();

                var linqMetaData = new LinqMetaData(adapter);

                var query = (from pad in linqMetaData.VwPcpAppointmetnDisposition
                             join ec in linqMetaData.EventCustomers on pad.EventCustomerId equals ec.EventCustomerId
                             select new { pad, ec });

                if (filter.DateType == (long)PcpAppointmentDispositionFilterDateType.EventDate && (filter.FromDate.HasValue || filter.ToDate.HasValue))
                {
                    var eventQuery = (from e in linqMetaData.Events select e);
                    if (filter.FromDate.HasValue)
                    {
                        eventQuery = (from q in eventQuery
                                      where q.EventDate >= filter.FromDate.Value.Date
                                      select q);
                    }

                    if (filter.ToDate.HasValue)
                    {
                        eventQuery = (from q in eventQuery
                                      where q.EventDate <= filter.ToDate.Value.Date
                                      select q);
                    }

                    var eventIds = (from eq in eventQuery select eq.EventId);

                    query = (from q in query where eventIds.Contains(q.ec.EventId) select q);

                }
                else if (filter.DateType == (long)PcpAppointmentDispositionFilterDateType.AppointmentDate && (filter.FromDate.HasValue || filter.ToDate.HasValue))
                {
                    if (filter.FromDate.HasValue)
                    {
                        query = (from q in query where q.pad.PcpAppointment >= filter.FromDate.Value select q);
                    }

                    if (filter.ToDate.HasValue)
                    {
                        var defaultDate = new DateTime(1901, 1, 1);

                        query = (from q in query where q.pad.PcpAppointment >= defaultDate && q.pad.PcpAppointment <= filter.ToDate.Value.AddDays(1) select q);
                    }
                }


                if (!string.IsNullOrEmpty(filter.Tag))
                {
                    var corporateEventIds = (from ea in linqMetaData.EventAccount
                                             join ca in linqMetaData.Account on ea.AccountId equals ca.AccountId
                                             where ca.Tag == filter.Tag
                                             select ea.EventId);

                    query = (from q in query where corporateEventIds.Contains(q.ec.EventId) select q);
                }

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId).Distinct();

                    query = (from q in query where customTagCustomerIds.Contains(q.ec.CustomerId) select q);
                }

                var finalQuery = (from q in query select q).OrderByDescending(q => q.pad.LastModified).ThenByDescending(q => q.pad.PcpAppointmentLastModified)
                        .ThenByDescending(q => q.pad.EventCustomerId);


                totalRecords = finalQuery.Count();

                var viewPcpAppointmentDisposition = finalQuery.TakePage(pageNumber, pageSize).Select(q => new ViewPcpAppointmentDisposition
                {
                    PcpAppointment = q.pad.PcpAppointment,
                    EventCustomerId = q.pad.EventCustomerId,
                    PcpAppointmentLastModified = q.pad.PcpAppointmentLastModified,
                    PcpDispositionId = q.pad.PcpDispositionId,
                    PcpDispositionLastModified = q.pad.PcpDispositionLastModified,
                    LastModified = q.pad.LastModified
                }).ToList();

                return viewPcpAppointmentDisposition;
            }
        }

        public bool UpdateLeftReason(long eventCustomerId, long? leftWithoutScreeningReasonId, long? noteId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { LeftWithoutScreeningReasonId = leftWithoutScreeningReasonId, LeftWithoutScreeningNotesId = noteId };

                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0);
            }
        }

        public IEnumerable<EventCustomer> GetCustomerLeftWithoutScreening(int pageNumber, int pageSize, CustomerLeftWithoutScreeningModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                if (filter == null)
                {
                    var query = (from ec in linqMetaData.EventCustomers
                                 join e in linqMetaData.Events on ec.EventId equals e.EventId
                                 where ec.LeftWithoutScreeningReasonId.HasValue
                                 && ec.AppointmentId.HasValue
                                 orderby e.EventDate descending
                                 select ec);
                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToArray();
                    return Mapper.MapMultiple(entities);
                }
                else
                {

                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                    var query = (from ec in linqMetaData.EventCustomers
                                 join op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData) on
                                     ec.EventId equals op.FirstValue.EventId
                                 where ec.LeftWithoutScreeningReasonId.HasValue
                                        && ec.AppointmentId.HasValue
                                       && (filter.FromDate != null ? fromDate <= op.FirstValue.EventDate : true)
                                       && (filter.ToDate != null ? toDate >= op.FirstValue.EventDate : true)
                                       && (filter.IsRetailEvent && !filter.IsCorporateEvent ? (!op.SecondValue) : (!filter.IsRetailEvent && filter.IsCorporateEvent ? op.SecondValue : true))
                                       && ((filter.IsPublicEvent && !filter.IsPrivateEvent) ? op.FirstValue.EventTypeId == (long)RegistrationMode.Public : (!filter.IsPublicEvent && filter.IsPrivateEvent) ?
                                       op.FirstValue.EventTypeId == (long)RegistrationMode.Private : true)
                                 select new { ec, op });
                    if (filter.AccountId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount
                                        where ea.AccountId == filter.AccountId
                                        select ea.EventId);
                        query = (from q in query
                                 where eventIds.Contains(q.ec.EventId)
                                 select q);
                    }

                    var countQuery = (from q in query select q.ec);
                    totalRecords = countQuery.Count();

                    var patientLeftQuery = (from q in query
                                            orderby q.op.FirstValue.EventDate descending, q.ec.EventCustomerId
                                            select new { q.op.FirstValue.EventDate, q.ec.EventCustomerId });


                    var temp = patientLeftQuery.TakePage(pageNumber, pageSize).ToArray();

                    var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                    var eventCustomers = GetByIds(eventCustomerIds);
                    return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
                }
            }
        }

        public IEnumerable<EventCustomer> GetVoiceMailReminderReport(int pageNumber, int pageSize, VoiceMailReminderModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Today;
                var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : filter.ToDate = null;

                var query = (from ec in linqMetaData.EventCustomers
                             join c in linqMetaData.CustomerProfile on ec.CustomerId equals c.CustomerId
                             join op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData) on
                                ec.EventId equals op.FirstValue.EventId
                             where c.EnableVoiceMail && ec.AppointmentId.HasValue && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue
                             orderby c.DateCreated descending
                             select new { ec, op });


                if (filter.EventId > 0)
                {
                    query = (from q in query where q.op.FirstValue.EventId == filter.EventId select q);
                    var eventFilterQuery = (from q in query orderby q.op.FirstValue.EventDate descending select q.ec);
                    totalRecords = query.Count();
                    entities = eventFilterQuery.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }
                if (filter.CorporateAccountId > 0 || filter.HospitalPartnerId > 0 || filter.FromDate != null || filter.ToDate != null)
                {
                    if (filter.CorporateAccountId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.CorporateAccountId select ea.EventId);

                        query = (from q in query where eventIds.Contains(q.op.FirstValue.EventId) select q);
                    }

                    if (filter.HospitalPartnerId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventHospitalPartner where ea.HospitalPartnerId == filter.HospitalPartnerId select ea.EventId);

                        query = (from q in query where eventIds.Contains(q.op.FirstValue.EventId) select q);
                    }

                    if (filter.FromDate != null)
                    {
                        query = (from q in query where q.op.FirstValue.EventDate.Date >= fromDate.Date select q);
                    }

                    if (filter.ToDate != null)
                    {
                        query = (from q in query where q.op.FirstValue.EventDate.Date <= toDate.Value.Date select q);
                    }
                }
                else
                {
                    query = (from q in query where q.op.FirstValue.EventDate.Date >= fromDate.Date.AddDays(1) select q);
                    filter.FromDate = fromDate.Date.AddDays(1);
                }


                var voiceMailQuery = (from q in query orderby q.op.FirstValue.EventDate descending select q.ec);

                totalRecords = query.Count();
                entities = voiceMailQuery.TakePage(pageNumber, pageSize).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public void UpdateEnableTexting(long customerId, bool enableTexting)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomersIds = (from ec in linqMetaData.EventCustomers
                                         join e in linqMetaData.Events on ec.EventId equals e.EventId
                                         where ec.CustomerId == customerId && e.EventDate > DateTime.Now.AddDays(-1)
                                         select ec.EventCustomerId).ToList();

                foreach (var eventCustomersId in eventCustomersIds)
                {
                    var eventCustomersEntity = new EventCustomersEntity(eventCustomersId) { EnableTexting = enableTexting };
                    var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomersId);
                    myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket);
                }
            }
        }
        public bool UpdateEnableTextingById(long eventCustomerId, bool enableTexting)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { EnableTexting = enableTexting };
                var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0);
            }
        }
        public IEnumerable<EventCustomer> GetTextReminderReport(int pageNumber, int pageSize, TextReminderModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                filter = filter ?? new TextReminderModelFilter();

                var query = (from ec in linqMetaData.EventCustomers
                             join op in EventRepository.GetEventEntityQuerywithIsCorporateField(linqMetaData) on ec.EventId equals op.FirstValue.EventId
                             where !ec.LeftWithoutScreeningReasonId.HasValue && ec.AppointmentId.HasValue && !ec.NoShow
                             select new { ec, op });

                if (filter.ShowSmsNotOptedCustomers)
                {
                    query = (from q in query where q.ec.EnableTexting == false select q);
                }

                if (filter.ShowSmsOptedCustomers)
                {
                    query = (from q in query where q.ec.EnableTexting select q);
                }

                if (filter.EventId > 0)
                {
                    query = (from q in query where q.ec.EventId == filter.EventId select q);
                    var eventFilterQuery = (from q in query orderby q.op.FirstValue.EventDate descending select q.ec);
                    totalRecords = query.Count();
                    entities = eventFilterQuery.TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }

                filter.FromDate = filter.FromDate.HasValue ? filter.FromDate : DateTime.Today.Date.AddDays(1);
                filter.ToDate = filter.ToDate.HasValue ? filter.ToDate : DateTime.Today.Date.AddDays(1);

                var fromDate = filter.FromDate.Value;
                var toDate = filter.ToDate.Value.AddDays(1);

                if (filter.CustomerId > 0)
                {
                    query = (from q in query where q.ec.CustomerId == filter.CustomerId select q);
                }

                if (filter.HealthPlanId > 0)
                {
                    var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);
                    query = (from q in query where eventIds.Contains(q.ec.EventId) select q);
                }

                if (filter.FromDate != null)
                {
                    query = (from q in query where q.op.FirstValue.EventDate.Date >= fromDate.Date select q);
                }

                if (filter.ToDate != null)
                {
                    query = (from q in query where q.op.FirstValue.EventDate.Date < toDate.Date select q);
                }

                var countQuery = (from q in query select q.ec);
                totalRecords = countQuery.Count();

                var textReminderQuery = (from q in query orderby q.op.FirstValue.EventDate descending select new { q.op.FirstValue.EventDate, q.ec.EventCustomerId });


                var temp = textReminderQuery.TakePage(pageNumber, pageSize).ToArray();
                var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                var eventCustomers = GetByIds(eventCustomerIds);
                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public long GetEventCustomerCountForHealthPlanRevenueByCustomer(long accountId, DateTime dateFrom, DateTime dateTo)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventids = (from eaccount in linqMetaData.EventAccount
                                where eaccount.AccountId == accountId
                                select eaccount.EventId);

                return (from ec in linqMetaData.EventCustomers
                        //join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        where e.EventDate >= dateFrom && e.EventDate < dateTo
                        && ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                        && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                        && eventids.Contains(e.EventId)
                        select ec).Count();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetEventCustomerCountForHealthPlanRevenueByPackage(long accountId, DateTime dateFrom, DateTime dateTo, IEnumerable<long> packageIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventids = (from eaccount in linqMetaData.EventAccount
                                where eaccount.AccountId == accountId
                                select eaccount.EventId);

                var temp = (from ecod in linqMetaData.EventCustomerOrderDetail
                            join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                            where ecod.IsActive
                            select new { ecod.EventCustomerId, od.OrderId });

                return (from ec in linqMetaData.EventCustomers
                        // join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join t in temp on ec.EventCustomerId equals t.EventCustomerId
                        join cod in linqMetaData.OrderDetail on t.OrderId equals cod.OrderId
                        join epoi in linqMetaData.EventPackageOrderItem on cod.OrderItemId equals epoi.OrderItemId
                        join epd in linqMetaData.EventPackageDetails on epoi.EventPackageId equals epd.EventPackageId
                        where e.EventDate >= dateFrom && e.EventDate < dateTo
                              && ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                              && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                              && cod.Status == 1
                              && eventids.Contains(e.EventId)
                              && packageIds.Contains(epd.PackageId)

                        group epd by epd.PackageId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetTestAvailedForHealthPlanRevenueByTest(long accountId, DateTime dateFrom, DateTime dateTo, IEnumerable<long> testIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventids = (from eaccount in linqMetaData.EventAccount
                                where eaccount.AccountId == accountId
                                select eaccount.EventId);

                var unableToScreen = (from uts in linqMetaData.CustomerEventUnableScreenReason select uts.CustomerEventScreeningTestId);
                var testNotPerfomred = (from tnp in linqMetaData.TestNotPerformed select tnp.CustomerEventScreeningTestId);

                return (from ec in linqMetaData.EventCustomers
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                        join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                        join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                        where e.EventDate >= dateFrom && e.EventDate < dateTo
                              && ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                              && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                              && eventids.Contains(e.EventId)
                              && testIds.Contains(cest.TestId)
                              && !unableToScreen.Contains(cest.CustomerEventScreeningTestId)
                              && !testNotPerfomred.Contains(cest.CustomerEventScreeningTestId)
                        group cest by cest.TestId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public long GetCustomerCountForHealthPlanRevenueByTest(long accountId, DateTime dateFrom, DateTime dateTo, IEnumerable<long> testIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventids = (from eaccount in linqMetaData.EventAccount
                                where eaccount.AccountId == accountId
                                select eaccount.EventId);

                var unableToScreen = (from uts in linqMetaData.CustomerEventUnableScreenReason select uts.CustomerEventScreeningTestId);
                var testNotPerfomred = (from tnp in linqMetaData.TestNotPerformed select tnp.CustomerEventScreeningTestId);

                return (from ec in linqMetaData.EventCustomers
                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                        join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                        join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId

                        where e.EventDate >= dateFrom && e.EventDate < dateTo
                              && ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                              && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                              && eventids.Contains(e.EventId)
                              && testIds.Contains(cest.TestId)
                              && !unableToScreen.Contains(cest.CustomerEventScreeningTestId)
                              && !testNotPerfomred.Contains(cest.CustomerEventScreeningTestId)

                        select ecr.EventCustomerResultId).Distinct().Count();
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForMemberResultSummary(int pageNumber, int pageSize, CorporateAccountCustomerListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                /*const int deliveredResultState = (int)TestResultStateNumber.ResultDelivered;*/

                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }

                var isHipaaEnabled = Convert.ToBoolean(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.IsHipaaEnabled));

                /*var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);*/

                var query = (from cars in linqMetaData.VwCustomerAggregateResultSummary
                             join ea in linqMetaData.EventAppointment on cars.AppointmentId equals ea.AppointmentId
                             where (isHipaaEnabled == false || cars.HiPaastatus == (int)RegulatoryState.Signed)
                                   && !cars.NoShow
                                   && ea.CheckinTime.HasValue && ea.CheckoutTime.HasValue
                             select cars);

                query = query.Where(q => q.EventId == filter.EventId);

                if (filter.CustomerId > 0)
                    query = query.Where(q => q.CustomerId == filter.CustomerId);
                else
                {
                    if (filter.DateOfBirthFrom.HasValue)
                        query = query.Where(q => q.Dob >= filter.DateOfBirthFrom.Value.Date);

                    if (filter.DateOfBirthTo.HasValue)
                        query = query.Where(q => q.Dob <= filter.DateOfBirthTo.Value.Date);

                    if (!string.IsNullOrEmpty(filter.CustomerName))
                    {
                        query = from q in query
                                where (q.FirstName + (q.MiddleName.Length > 0 ? " " + q.MiddleName + " " : " ") + q.LastName).Contains(filter.CustomerName)
                                select q;
                    }

                    if (!string.IsNullOrEmpty(filter.MemberId) || !string.IsNullOrEmpty(filter.HICN))
                    {
                        var customers = from cp in linqMetaData.CustomerProfile select cp;

                        if (!string.IsNullOrEmpty(filter.MemberId))
                        {
                            customers = (from c in customers where c.InsuranceId == filter.MemberId select c);
                        }

                        if (!string.IsNullOrEmpty(filter.HICN))
                        {
                            customers = (from c in customers where c.Hicn == filter.HICN select c);
                        }

                        var customerIds = customers.Select(x => x.CustomerId);

                        query = (from q in query where customerIds.Contains(q.CustomerId) select q);
                    }

                }
                totalRecords = query.Count();
                var queryable = query.Select(q => q.EventCustomerId).Distinct();

                var eventCustomerIds = queryable.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomers = GetByIds(eventCustomerIds);

                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }


        public IEnumerable<EventCustomer> GetEventCustomerForFurtureEventsByCustomerId(long customerId, bool isTodayIncluded = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ec in linqMetaData.EventCustomers
                                join e in linqMetaData.Events on ec.EventId equals e.EventId
                                where ec.CustomerId == customerId
                                && ec.AppointmentId.HasValue
                                // && e.EventDate >= DateTime.Today.Date
                                select ec);
                if (isTodayIncluded)
                {
                    entities = (from e in entities
                                where e.Events.EventDate >= DateTime.Today.Date
                                select e);
                }
                else
                {
                    entities = (from e in entities
                                where e.Events.EventDate > DateTime.Today.Date
                                select e);
                }
                var result = entities.ToArray();
                return Mapper.MapMultiple(result);
            }
        }
        public IEnumerable<EventCustomer> GetCorporateEventCustomerbyEventId(int pageNumber, int pageSize, CorporateEventCustomerModelFilter filter, out int totalRecords)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from ec in linqMetaData.EventCustomers
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                    into ecWithApp
                                from a in ecWithApp.DefaultIfEmpty()
                                where ec.EventId == filter.EventId
                                orderby a.StartTime
                                select ec).ToArray();

                totalRecords = entities.Count();
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersForInterviewReport(InterviewInboundFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault();

                var query = (from ec in linqMetaData.EventCustomers
                             join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                             where (account == null || cp.Tag == account.Tag)
                                   && (filter.StartDate == null || (ec.DateCreated.HasValue && ec.DateCreated.Value.Date >= filter.StartDate))
                                   && (filter.EndDate == null || (ec.DateCreated.HasValue && ec.DateCreated.Value.Date <= filter.EndDate))
                             select ec);

                totalRecords = query.Count();

                var result = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return Mapper.MapMultiple(result);
            }
        }
        public bool IsCustomerNoShowOrLeftWithoutScreening(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var custId = (from ec in linqMetaData.EventCustomers
                              where ec.CustomerId == customerId && ec.EventId == eventId && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue
                              select ec.CustomerId).FirstOrDefault();

                if (custId > 0)
                    return false;
                else
                    return true;
            }
        }

        public IEnumerable<EventCustomer> GetForCustomerExport(IEnumerable<long> customerIds, CustomerExportListModelFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from ec in linqMetaData.EventCustomers
                             where customerIds.Contains(ec.CustomerId)
                             select ec).ToArray();

                if (filter != null)
                {
                    if (filter.AppointmentFrom.HasValue)
                    {
                        query = (from q in query
                                 join e in linqMetaData.Events on q.EventId equals e.EventId
                                 where e.EventDate >= filter.AppointmentFrom.Value
                                 && q.AppointmentId.HasValue
                                 select q).ToArray();
                    }
                    if (filter.AppointmentTo.HasValue)
                    {
                        query = (from q in query
                                 join e in linqMetaData.Events on q.EventId equals e.EventId
                                 where e.EventDate < filter.AppointmentTo.Value.AddDays(1)
                                 && q.AppointmentId.HasValue
                                 select q).ToArray();
                    }
                }

                return Mapper.MapMultiple(query);
            }
        }

        public bool UpdateGiftCertificate(long eventCustomerId, string giftCode = null, long? giftCardNotGivenReasonId = null)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!string.IsNullOrEmpty(giftCode))
                {
                    var eventCustomersEntity = new EventCustomersEntity(eventCustomerId)
                    {
                        IsGiftCertificateDelivered = true,
                        GiftCode = giftCode,
                        GcNotGivenReasonId = null
                    };

                    var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0);
                }
                else if (giftCardNotGivenReasonId.HasValue && giftCardNotGivenReasonId.Value > 0)
                {
                    var eventCustomersEntity = new EventCustomersEntity(eventCustomerId)
                    {
                        IsGiftCertificateDelivered = false,
                        GiftCode = null,
                        GcNotGivenReasonId = giftCardNotGivenReasonId
                    };

                    var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
                    return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0);
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<EventCustomer> GetForGiftCertificateReport(int pageNumber, int pageSize, GiftCertificateReportFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from ec in linqMetaData.EventCustomers
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             where ec.IsGiftCertificateDelivered.HasValue && ec.IsGiftCertificateDelivered.Value == true
                             orderby e.EventDate
                             select new { ec, e.EventDate });

                if (filter != null)
                {
                    if (filter.CustomerId > 0)
                        query = query.Where(q => q.ec.CustomerId == filter.CustomerId);
                    else
                    {
                        if (filter.EventId > 0)
                        {
                            query = query.Where(x => x.ec.EventId == filter.EventId);
                        }
                        if (!string.IsNullOrEmpty(filter.MemberId))
                        {
                            var customerIds = from cp in linqMetaData.CustomerProfile where cp.InsuranceId == filter.MemberId select cp.CustomerId;
                            query = (from q in query where customerIds.Contains(q.ec.CustomerId) select q);
                        }
                        if (filter.HealthPlanId > 0)
                        {
                            var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);
                            query = query.Where(x => eventIds.Contains(x.ec.EventId));
                        }
                        if (filter.EventFrom.HasValue)
                        {
                            var eventIds = (from e in linqMetaData.Events where e.EventDate >= filter.EventFrom.Value select e.EventId);
                            query = query.Where(x => eventIds.Contains(x.ec.EventId));
                        }
                        if (filter.EventTo.HasValue)
                        {
                            var eventIds = (from e in linqMetaData.Events where e.EventDate < filter.EventTo.Value.AddDays(1) select e.EventId);
                            query = query.Where(x => eventIds.Contains(x.ec.EventId));
                        }

                        if (!string.IsNullOrEmpty(filter.Pod))
                        {
                            var eventIds = (from ep in linqMetaData.EventPod
                                            join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                            where ep.IsActive && p.Name.Contains(filter.Pod)
                                            select ep.EventId).Distinct();
                            query = query.Where(x => eventIds.Contains(x.ec.EventId));
                        }

                        if (!string.IsNullOrWhiteSpace(filter.Tag))
                        {
                            var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == filter.Tag select cp.CustomerId);
                            query = query.Where(x => customerIds.Contains(x.ec.CustomerId));
                        }
                    }

                }

                totalRecords = query.Count();

                var finalResult = (from q in query
                                   orderby q.EventDate descending, q.ec.EventId, q.ec.EventCustomerId
                                   select new { q.EventDate, q.ec.EventId, q.ec.EventCustomerId });

                var temp = finalResult.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                var eventCustomers = GetByIds(eventCustomerIds);
                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public EventCustomer GetByCustomerIdAndEventDate(long customerId, DateTime eventDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ec in linqMetaData.EventCustomers
                              join e in linqMetaData.Events on ec.EventId equals e.EventId
                              where ec.CustomerId == customerId
                              && e.EventDate == eventDate.Date
                              && ec.AppointmentId.HasValue
                              select ec).SingleOrDefault();

                return entity != null ? Mapper.Map(entity) : null;
            }
        }

        public EventCustomer GetByPatientDetailId(long patientDetailId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ec in linqMetaData.EventCustomers
                              where ec.PatientDetailId == patientDetailId
                              select ec).SingleOrDefault();

                return entity != null ? Mapper.Map(entity) : null;
            }
        }
        public IEnumerable<EventCustomer> GetAppointmentBookedChartForLastSevenDays(AppointmentBookedChartStatus appointmentBookedType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ec in linqMetaData.VwEventCustomersAccount where ec.DateCreated.Date >= DateTime.Now.AddDays(-7).Date && ec.DateCreated.Date <= DateTime.Now.Date select ec);

                if (appointmentBookedType == AppointmentBookedChartStatus.All)
                {
                    var entities = query.ToArray();
                    return _viewMapper.MapMultiple(entities);
                }
                else if (appointmentBookedType == AppointmentBookedChartStatus.HealthPlan || appointmentBookedType == AppointmentBookedChartStatus.Corporate)
                {
                    var healthPlan = (from hp in linqMetaData.Account select hp);

                    IQueryable<long> healthPlanIds = null;
                    if (appointmentBookedType == AppointmentBookedChartStatus.HealthPlan)
                    {
                        healthPlanIds = (from h in healthPlan where h.IsHealthPlan select h.AccountId);
                    }
                    else
                    {
                        healthPlanIds = (from h in healthPlan where !h.IsHealthPlan select h.AccountId);
                    }

                    var eventIds = (from ea in linqMetaData.EventAccount
                                    where healthPlanIds.Contains(ea.AccountId)
                                    select ea.EventId);
                    var entities = query.Where(q => eventIds.Contains(q.EventId) && q.AccountId > 0);

                    return _viewMapper.MapMultiple(entities);
                }
                else if (appointmentBookedType == AppointmentBookedChartStatus.Retail)
                {
                    var entities = (from q in query where q.AccountId <= 0 select q).ToArray();
                    return _viewMapper.MapMultiple(entities);
                }
                return null;
            }
        }

        public EventCustomer GetByMedicareVisitId(long visitId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ec in linqMetaData.EventCustomers
                              where ec.AwvVisitId == visitId && ec.NoShow == false && ec.AppointmentId.HasValue
                              select ec).SingleOrDefault();

                return entity != null ? Mapper.Map(entity) : null;
            }
        }

        public IEnumerable<EventCustomer> GetPayPeriodBookedCustomers(int pageNumber, int pageSize, PayPeriodBookedCustomerFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }

                var query = (from ec in linqMetaData.VwEventCustomersAccount
                             select ec);

                if (filter.ShowAttendedCustomersOnly)
                {
                    query = (from q in query
                             //join a in linqMetaData.Account on ec.AccountId equals a.AccountId
                             join ea in linqMetaData.EventAppointment on q.AppointmentId equals ea.AppointmentId
                             where q.DateCreated >= filter.StartDate && q.DateCreated < filter.EndDate.Value.AddDays(1) &&
                              q.AppointmentId > 0 && q.CreatedByOrgRoleUserId == filter.AgentId //&& a.IsHealthPlan 
                              && (ea.CheckinTime != null && !q.NoShow)
                             orderby q.DateCreated descending, ea.StartTime
                             select q);
                }
                else
                {
                    query = (from q in query
                             //join a in linqMetaData.Account on ec.AccountId equals a.AccountId
                             //join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where q.DateCreated >= filter.StartDate && q.DateCreated < filter.EndDate.Value.AddDays(1) &&
                             q.CreatedByOrgRoleUserId == filter.AgentId  //&& a.IsHealthPlan 
                             orderby q.DateCreated descending
                             select q);
                }

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).ToArray();

                return _viewMapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomerForBonusCalculation(DateTime startDate, DateTime endDate, IEnumerable<long> callCenterAgents)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var patientLeftWithoutScreening = (from lws in linqMetaData.EventCustomers where lws.LeftWithoutScreeningReasonId != null select lws.EventCustomerId);

                var entities = (from ec in linqMetaData.VwEventCustomersAccount

                                join e in linqMetaData.Events on ec.EventId equals e.EventId
                                join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                where e.EventDate >= startDate && e.EventDate <= endDate &&
                                ec.AppointmentId > 0 && callCenterAgents.Contains(ec.CreatedByOrgRoleUserId) //&& a.IsHealthPlan
                                 && ea.CheckinTime != null && !ec.NoShow
                                 && !patientLeftWithoutScreening.Contains(ec.EventCustomerId)
                                orderby ec.DateCreated descending, ea.StartTime
                                select ec).ToArray();

                return (!entities.Any()) ? null : _viewMapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetActualCustomerShowed(int pageNumber, int pageSize, PayPeriodBookedCustomerFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }
                var patientLeftWithoutScreening = (from lws in linqMetaData.EventCustomers where lws.LeftWithoutScreeningReasonId != null select lws.EventCustomerId);

                var query = (from ec in linqMetaData.VwEventCustomersAccount
                             //join a in linqMetaData.Account on ec.AccountId equals a.AccountId
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             where e.EventDate >= filter.StartDate && e.EventDate <= filter.EndDate &&
                             ec.AppointmentId > 0 && ec.CreatedByOrgRoleUserId == filter.AgentId //&& a.IsHealthPlan
                              && ea.CheckinTime != null && !ec.NoShow && !patientLeftWithoutScreening.Contains(ec.EventCustomerId)
                             orderby ec.DateCreated descending, ea.StartTime
                             select ec);

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).ToList();

                return _viewMapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomersViewServiceReport> GetEventCustomerResultByFilter(CustomTestPerformedReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter.DateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value : DateTime.Now.AddMonths(-1).Date;
                filter.DateTo = filter.DateTo.HasValue ? filter.DateTo.Value : DateTime.Now;

                var query = (from ecrsr in linqMetaData.VwEventCustomersViewServiceReport
                             where ecrsr.EventDate >= filter.DateFrom && ecrsr.EventDate < filter.DateTo.Value.AddDays(1)
                             && ecrsr.AccountId == filter.HealthPlanId
                             select ecrsr);

                if (!string.IsNullOrWhiteSpace(filter.Tag))
                {
                    var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == filter.Tag select cp.CustomerId);

                    query = (from q in query
                             where customerIds.Contains(q.CustomerId)
                             select q);
                }

                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);

                    if (filter.ExcludeCustomerWithCustomTag)
                    {
                        query = (from q in query where !customTagCustomerIds.Contains(q.CustomerId) select q);
                    }
                    else
                    {
                        query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                    }
                }

                totalRecords = query.Count();

                query = (from q in query
                         orderby q.EventDate, q.EventId, q.CustomerId
                         select q);

                var entities = query.TakePage(pageNumber, pageSize).ToArray();

                return AutoMapper.Mapper.Map<IEnumerable<VwEventCustomersViewServiceReportEntity>, IEnumerable<EventCustomersViewServiceReport>>(entities);
            }
        }

        public IEnumerable<EventCustomer> GetByCustomerIdEventDate(IEnumerable<long> customerIds, DateTime? eventDatefrom = null, DateTime? eventDateTo = null, long? technicianId = null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from ec in linqMetaData.EventCustomers
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             where customerIds.Contains(ec.CustomerId)
                             select new { ec, e });

                if (eventDatefrom.HasValue)
                    query = (from q in query where q.e.EventDate >= eventDatefrom.Value select q);

                if (eventDateTo.HasValue)
                    query = (from q in query where q.e.EventDate <= eventDateTo.Value.AddDays(1) select q);

                if (technicianId.HasValue)
                {
                    var eventIds = linqMetaData.EventStaffAssignment.Where(x => x.ScheduledStaffOrgRoleUserId == technicianId.Value).Select(x => x.EventId);
                    query = (from q in query
                             where eventIds.Contains(q.e.EventId)
                             select q);
                }

                var entities = (from q in query select q.ec);

                return Mapper.MapMultiple(entities.ToArray());
            }
        }

        public IEnumerable<EventCustomer> GetForHealthPlanGiftCertificateReport(int pageNumber, int pageSize, HealthPlanGiftCertificateReportFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ec in linqMetaData.EventCustomers
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             where ec.AppointmentId > 0 && ea.CheckinTime != null && ea.CheckoutTime != null
                             && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null
                             orderby e.EventDate
                             select new { ec, e.EventDate });

                if (filter != null)
                {
                    if (!string.IsNullOrEmpty(filter.Tag))
                    {
                        query = (from q in query
                                 join cp in linqMetaData.CustomerProfile on q.ec.CustomerId equals cp.CustomerId
                                 where cp.Tag == filter.Tag
                                 select q);
                    }

                    if (filter.FromDate.HasValue)
                    {
                        query = (from q in query
                                 where q.EventDate >= filter.FromDate.Value
                                 select q);
                    }

                    if (filter.ToDate.HasValue)
                    {
                        query = (from q in query
                                 where q.EventDate <= filter.ToDate.Value
                                 select q);
                    }
                }

                totalRecords = query.Count();
                var ecQuery = (from q in query
                               orderby q.EventDate descending, q.ec.EventId, q.ec.EventCustomerId
                               select new { q.EventDate, q.ec.EventId, q.ec.EventCustomerId });

                var temp = ecQuery.TakePage(pageNumber, pageSize).ToArray();

                var eventCustomerIds = temp.Select(x => x.EventCustomerId).ToArray();
                var eventCustomers = GetByIds(eventCustomerIds);
                return eventCustomerIds.Select(eventCustomerId => eventCustomers.Single(x => x.Id == eventCustomerId)).ToList();
            }
        }

        public IEnumerable<EventCustomer> GetByEventIdsOrCustomerIds(DateTime? startDate, IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ec in linqMetaData.EventCustomers
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             where customerIds.Contains(ec.CustomerId)
                             && (startDate == null || e.EventDate >= startDate)
                             select ec);


                var entities = query.ToArray();

                return (!entities.Any()) ? null : Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetHhynEventCustomers(int pageNumber, int pageSize, KynCustomerModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventCustomersEntity> entities;
                IQueryable<EventCustomersEntity> query;

                if (filter == null)
                {
                    var eventQuery = (from ep in linqMetaData.EventPod where ep.IsActive && ep.EnableKynIntegration select ep.EventId);

                    query = (from ec in linqMetaData.EventCustomers
                             join kyn in linqMetaData.VwGetHkynTestCustomers on ec.EventCustomerId equals kyn.EventCustomerId
                             where ec.AppointmentId.HasValue && eventQuery.Contains(ec.EventId) && ec.LeftWithoutScreeningReasonId == null
                             orderby ec.DateCreated descending, ec.CustomerId
                             select ec);

                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();

                    return Mapper.MapMultiple(entities);
                }

                query = (from ec in linqMetaData.EventCustomers
                         where ec.AppointmentId.HasValue && ec.LeftWithoutScreeningReasonId == null
                         select ec);

                if (filter.ShowOnlyKyn)
                {
                    var eventQuery = (from ep in linqMetaData.EventPod where ep.IsActive && ep.EnableKynIntegration select ep.EventId);

                    query = (from q in query
                             join kyn in linqMetaData.VwGetHkynTestCustomers on q.EventCustomerId equals kyn.EventCustomerId
                             where eventQuery.Contains(q.EventId)
                             select q);
                }
                else
                {
                    var donotCaptureHafEventIds = (from a in linqMetaData.Account
                                                   join ea in linqMetaData.EventAccount on a.AccountId equals ea.AccountId
                                                   where !a.CaptureHaf
                                                   select ea.EventId);

                    var eventQuery = (from ep in linqMetaData.EventPod where ep.IsActive && ep.EnableKynIntegration select ep.EventId);

                    var kynCustomerIds = (from q in query
                                          join kyn in linqMetaData.VwGetHkynTestCustomers on q.EventCustomerId equals kyn.EventCustomerId
                                          where eventQuery.Contains(q.EventId)
                                          select q.EventCustomerId);

                    query = (from q in query
                             where !donotCaptureHafEventIds.Contains(q.EventId) || kynCustomerIds.Contains(q.EventCustomerId)
                             select q);
                }

                if (!string.IsNullOrEmpty(filter.Tag))
                {
                    query = query.Where(q => q.CustomerProfile.Tag == filter.Tag);
                }
                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);
                    query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                }
                if (!string.IsNullOrEmpty(filter.SponseredBy))
                {
                    var hospitalPartnerEvents = from ea in linqMetaData.EventHospitalPartner
                                                join o in linqMetaData.Organization on ea.HospitalPartnerId equals o.OrganizationId
                                                where o.Name.Contains(filter.SponseredBy)
                                                select ea.EventId;

                    var corporateEvents = from ea in linqMetaData.EventAccount
                                          join o in linqMetaData.Organization on ea.AccountId equals o.OrganizationId
                                          where o.Name.Contains(filter.SponseredBy)
                                          select ea.EventId;


                    query = query.Where(q => hospitalPartnerEvents.Contains(q.EventId) || corporateEvents.Contains(q.EventId));
                }

                if (filter.EventId > 0)
                {
                    var queryForEcs = query.Where(q => q.EventId == filter.EventId).Select(q => q);
                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    {
                        var queryWithEvents = (from q in query
                                               join e in linqMetaData.Events on q.EventId equals e.EventId
                                               select new { q, e });

                        if (filter.FromDate.HasValue)
                            queryWithEvents = queryWithEvents.Where(a => a.e.EventDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            queryWithEvents = queryWithEvents.Where(a => a.e.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));

                        query = (from q in queryWithEvents select q.q);
                    }

                    if (filter.RegistrationFromDate.HasValue || filter.RegistrationToDate.HasValue)
                    {
                        if (filter.RegistrationFromDate.HasValue)
                            query = query.Where(a => a.DateCreated >= filter.RegistrationFromDate.Value);

                        if (filter.RegistrationToDate.HasValue)
                            query = query.Where(a => a.DateCreated < filter.RegistrationToDate.Value.AddHours(23).AddMinutes(59));
                    }

                    var queryForEcs = (from ec in query
                                       orderby ec.DateCreated descending, ec.CustomerId
                                       select ec);

                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToList();
                }



                return Mapper.MapMultiple(entities);
            }
        }

        public void UpdateCustomerProfileIdByCustomerId(long customerId, long customerProfileHistoryId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from ec in linqMetaData.EventCustomers
                                        join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals ecr.EventCustomerResultId
                                            into ecwithecr
                                        from r in ecwithecr.DefaultIfEmpty()
                                        where ec.CustomerId == customerId &&
                                        (ec.CustomerProfileHistoryId == null || (r != null && r.ResultState < (long)TestResultStateNumber.ResultDelivered))
                                        select ec.EventCustomerId).ToArray();
                if (!eventCustomerIds.IsNullOrEmpty())
                {
                    var entity = new EventCustomersEntity()
                    {
                        CustomerProfileHistoryId = customerProfileHistoryId,
                    };

                    var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerIds);

                    adapter.UpdateEntitiesDirectly(entity, bucket);
                }
            }
        }

        public IEnumerable<EventCustomer> GetByEventDate(DateTime? fromDate, DateTime? toDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from ec in linqMetaData.EventCustomers
                             join e in linqMetaData.Events on ec.EventId equals e.EventId
                             where e.EventStatus == (int)EventStatus.Active && e.IsActive
                             select new { ec, e });

                if (fromDate.HasValue)
                    query = (from q in query where q.e.EventDate >= fromDate.Value select q);

                if (toDate.HasValue)
                    query = (from q in query where q.e.EventDate <= toDate.Value select q);

                var entities = (from q in query select q.ec);

                return Mapper.MapMultiple(entities.ToArray());
            }
        }

        public int IsNoShowOrCancelled(long visitId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity =
                    linqMetaData.EventCustomers.FirstOrDefault(ec => (ec.AwvVisitId.HasValue && ec.AwvVisitId.Value == visitId));
                if (entity != null)
                {
                    if (entity.NoShow)
                        return 1;

                    if (!entity.AppointmentId.HasValue)
                        return 2;
                }
                return 0;
            }
        }

        public IEnumerable<EventCustomer> GetLatestEventCustomersByCustomerId(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from ec in linqMetaData.EventCustomers
                                        where ec.AppointmentId.HasValue && customerIds.Contains(ec.CustomerId)
                                        group ec by ec.CustomerId
                                            into ecgrp
                                            select ecgrp.Max(x => x.EventCustomerId));

                var entities = (from ec in linqMetaData.EventCustomers where eventCustomerIds.Contains(ec.EventCustomerId) select ec).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetMyBioCheckEventCustomers(int pageNumber, int pageSize, MyBioCheckCustomerModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventQuery = (from ep in linqMetaData.EventPod where ep.IsActive && ep.EnableKynIntegration select ep.EventId);

                IQueryable<EventCustomersEntity> query = (from ec in linqMetaData.EventCustomers
                                                          join kyn in linqMetaData.VwGetMyBioCheckTestCustomers on ec.EventCustomerId equals kyn.EventCustomerId
                                                          where eventQuery.Contains(ec.EventId) && ec.EventId == filter.EventId
                                                          orderby ec.DateCreated descending, ec.CustomerId
                                                          select ec);

                totalRecords = query.Count();
                IEnumerable<EventCustomersEntity> entities = query.TakePage(pageNumber, pageSize).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<long> GetCustomerIdsForNonTargetableReport(int pageNumber, int pageSize, NonTargetableReportModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventIds = from ea in linqMetaData.EventAccount where ea.AccountId == filter.AccountId select ea.EventId;

                var query = (from e in linqMetaData.Events
                             join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                             join hed in linqMetaData.HostEventDetails on e.EventId equals hed.EventId
                             join p in linqMetaData.Prospects on hed.HostId equals p.ProspectId
                             join c in linqMetaData.CustomerProfile on ec.CustomerId equals c.CustomerId

                             where eventIds.Contains(e.EventId)
                                   && e.EventDate.Date >= filter.StartDate
                                   && e.EventDate.Date < filter.EndDate.AddDays(1)
                                   && p.Address.StateId == filter.StateId
                                   && ec.NoShow == false && ec.LeftWithoutScreeningNotesId == null && ec.AppointmentId.HasValue
                                   && (c.Tag == null || c.Tag.Trim() == "")
                             select ec.CustomerId).Distinct();

                totalRecords = query.Count();
                var customerIds = query.TakePage(pageNumber, pageSize).ToArray();

                return customerIds;
            }
        }

        public IEnumerable<EventCustomer> GetAppointmentEncounterReport(int pageNumber, int pageSize, AppointmentEncounterFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<VwEventCustomersAccountEntity> entities;
                if (filter == null)
                {
                    var query = (from ec in linqMetaData.VwEventCustomersAccount orderby ec.DateCreated descending select ec);
                    totalRecords = query.Count();
                    entities = query.TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var query = (from ec in linqMetaData.VwEventCustomersAccount
                                 select ec);

                    if (filter.FromDate.HasValue)
                        query = query.Where(a => a.DateCreated >= filter.FromDate.Value);

                    if (filter.ToDate.HasValue)
                        query = query.Where(a => a.DateCreated < filter.ToDate.Value.AddDays(1));


                    if (filter.EventFromDate.HasValue)
                        query = query.Where(a => a.EventDate >= filter.EventFromDate.Value);

                    if (filter.EventToDate.HasValue)
                        query = query.Where(a => a.EventDate < filter.EventToDate.Value.AddDays(1));


                    if (filter.AccountId > 0)
                        query = query.Where(a => a.AccountId == filter.AccountId);

                    if (!string.IsNullOrEmpty(filter.Tag))
                    {
                        var customerIds = (from c in linqMetaData.CustomerProfile
                                           where c.Tag == filter.Tag
                                           select c.CustomerId);
                        query = query.Where(q => customerIds.Contains(q.CustomerId));
                    }

                    var queryForEcs = from ec in query
                                      join ea in linqMetaData.EventAppointment on ec.AppointmentId equals
                                          ea.AppointmentId into ecQuery
                                      from e in ecQuery.DefaultIfEmpty()
                                      orderby ec.EventDate, ec.CustomerId
                                      select ec;

                    totalRecords = queryForEcs.Count();
                    entities = queryForEcs.TakePage(pageNumber, pageSize).ToArray();

                }

                return _viewMapper.MapMultiple(entities);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomerForPcpChangeReport(int pageNumber, int pageSize, PotentialPcpChangeReportModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventIds = (from ea in linqMetaData.EventAccount
                                where ea.AccountId == filter.AccountId
                                select ea.EventId);

                var customerIdsWithPcp = (from cpcp in linqMetaData.CustomerPrimaryCarePhysician
                                          select cpcp.CustomerId);

                var query = from ec in linqMetaData.EventCustomers
                            join e in linqMetaData.Events on ec.EventId equals e.EventId
                            join hed in linqMetaData.HostEventDetails on ec.EventId equals hed.EventId
                            join p in linqMetaData.Prospects on hed.HostId equals p.ProspectId
                            join eappt in linqMetaData.EventAppointment on ec.AppointmentId equals eappt.AppointmentId
                            where !ec.NoShow
                            && ec.AppointmentId != null
                                  && ec.LeftWithoutScreeningReasonId == null
                                  && (eappt.CheckinTime != null && eappt.CheckoutTime != null)
                                  && eventIds.Contains(ec.EventId)
                                  && p.Address.StateId == filter.StateId
                                  && e.EventDate >= filter.StartDate
                                  && e.EventDate < filter.EndDate.AddDays(1)
                                  && customerIdsWithPcp.Contains(ec.CustomerId)
                            select ec;

                totalRecords = query.Count();
                var eventCustomers = query.TakePage(pageNumber, pageSize).ToArray();

                return Mapper.MapMultiple(eventCustomers);
            }
        }

        public IEnumerable<EventCustomer> GetEventCustomersbyEventId(long eventId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from ec in linqMetaData.EventCustomers
                                where ec.EventId == eventId
                                select ec).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public void UpdatePreferredContactTypeByCustomerId(long customerId, long? preferredContactType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from ec in linqMetaData.EventCustomers
                                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                                        where e.EventDate >= DateTime.Today && ec.CustomerId == customerId
                                        select ec.EventCustomerId).ToArray();
                if (!eventCustomerIds.IsNullOrEmpty())
                {
                    var entity = new EventCustomersEntity()
                    {
                        PreferredContactType = preferredContactType,
                    };

                    var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerIds);

                    adapter.UpdateEntitiesDirectly(entity, bucket);
                }
            }
        }

        public DateTime? GetFutureMostAppointmentDateForEventCustomerByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var fistDayOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var appointmentIdsForCutomer = (from ec in linqMetaData.EventCustomers
                                                where ec.AppointmentId != null && ec.NoShow == false && ec.CustomerId == customerId
                                                select ec.AppointmentId);

                DateTime? appointmentDate = null;

                appointmentDate = (from ea in linqMetaData.EventAppointment
                                   where appointmentIdsForCutomer.Contains(ea.AppointmentId) && ea.StartTime >= fistDayOfYear
                                   orderby ea.StartTime descending
                                   select ea.StartTime).FirstOrDefault();

                appointmentDate = (appointmentDate == DateTime.MinValue) ? (DateTime?)null : appointmentDate;

                //join is bit inefficient ,as comapred execution plans for both
                //var appointmentDate = (from ec in linqMetaData.EventCustomers
                //                       join appt in linqMetaData.EventAppointment on ec.AppointmentId equals appt.AppointmentId
                //                       where ec.CustomerId == customerId && appt.StartTime.Date >= new DateTime(DateTime.Now.Year, 1, 1)
                //                       orderby appt.StartTime descending
                //                       select appt.StartTime).FirstOrDefault();
                return appointmentDate;
            }
        }

        public void UpddateIsAppointmentConfirmed(long eventid)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from ec in linqMetaData.EventCustomers
                                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                                        where e.EventId == eventid
                                        select ec.EventCustomerId).ToArray();

                if (!eventCustomerIds.IsNullOrEmpty())
                {
                    var entity = new EventCustomersEntity()
                    {
                        IsAppointmentConfirmed = false,
                        ConfirmedBy = null
                    };

                    var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerIds);

                    adapter.UpdateEntitiesDirectly(entity, bucket);
                }
            }
        }

        public bool IsTestPurchasedByEventIdCustomerId(long eventId, long customerId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var isTestPurchased = (from ect in linqMetaData.VwGetAllTestForCustomers
                                       join ec in linqMetaData.EventCustomers on ect.EventCustomerId equals ec.EventCustomerId
                                       where ec.EventId == eventId && ec.CustomerId == customerId && ect.TestId == testId
                                       select ec.EventId).Any();
                return isTestPurchased;
            }
        }

        //public bool UpdateGeneratePreAssessmentCallQueueStatus(long eventCustomerId, bool isAssessmentCompleted)
        //{
        //    using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var eventCustomersEntity = new EventCustomersEntity(eventCustomerId) { GeneratePreAssessmentCallQueue = isAssessmentCompleted };// remove  IsPhysicianRecordRequestSigned after LLBN gen
        //        var bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);
        //        try
        //        {
        //            return (myAdapter.UpdateEntitiesDirectly(eventCustomersEntity, bucket) > 0) ? true : false;
        //        }
        //        catch (Exception exception)
        //        {
        //            throw new PersistenceFailureException(exception.Message);
        //        }
        //    }
        //}

    }
}
