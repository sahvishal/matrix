using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Application.Repositories;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses.ExpressionClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Repositories;
using DateTime = System.DateTime;
using Falcon.App.Core.Medical.ValueType;
using System;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventRepository : UniqueItemRepository<Event, EventsEntity>, IEventRepository
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        private IConfigurationSettingRepository _configurationSettingRepository;
        // private IRequiredTestRepository _requiredTestRepository;
        private const int CutOfDateForKynXmlinDays = 90;
        private readonly ISettings _settings;
        public EventRepository()
            : this(new ZipCodeRepository(), new ConfigurationSettingRepository(), new EventMapper(), new Settings()) //, new RequiredTestRepository()
        { }

        public EventRepository(IZipCodeRepository zipCodeRepository, IConfigurationSettingRepository configurationSettingRepository, IMapper<Event, EventsEntity> mapper, ISettings settings) //, IRequiredTestRepository requiredTestRepository
            : base(mapper)
        {
            _zipCodeRepository = zipCodeRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _settings = settings;
            //_requiredTestRepository = requiredTestRepository;
        }

        protected override EntityField2 EntityIdField
        {
            get { return EventsFields.EventId; }
        }

        public Event GetEventForShippingDetail(long shippingDetailId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var orderDetailIds =
                    linqMetaData.ShippingDetailOrderDetail.Where(
                        sdod => sdod.ShippingDetailId == shippingDetailId && sdod.IsActive).Select(
                        sdod => sdod.OrderDetailId).Distinct();

                var eventCustomerId =
                    linqMetaData.EventCustomerOrderDetail.Where(
                        ecod => orderDetailIds.Contains(ecod.OrderDetailId) && ecod.IsActive).Select(
                        ecod => ecod.EventCustomerId).Distinct();

                if (eventCustomerId.IsEmpty())
                    throw new ObjectNotFoundInPersistenceException<Event>();

                if (eventCustomerId.Count() > 1)
                    throw new DuplicateObjectException<Event>();

                var eventId =
                    linqMetaData.EventCustomers.Single(ec => ec.EventCustomerId == eventCustomerId.Single()).EventId;

                var eventData =
                    Queryable.Single<EventsEntity>(linqMetaData.Events.WithPath(path => path.Prefetch(p => p.HostEventDetails)), @e => @e.EventId == eventId);

                return Mapper.Map(eventData);
            }
        }

        public decimal GetEventRevenue(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var orderDetails = from ec in linqMetaData.EventCustomers
                                   join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                       ecod.EventCustomerId
                                   join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                   where
                                       ec.EventId == eventId && ecod.IsActive && !ec.NoShow &&
                                       ec.AppointmentId.HasValue
                                   select new { od.OrderDetailId, Price = (od.Price * od.Quantity) };

                var shippingDetails = from od in orderDetails
                                      join sdod in linqMetaData.ShippingDetailOrderDetail on od.OrderDetailId equals
                                          sdod.OrderDetailId
                                      join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals
                                          sd.ShippingDetailId
                                      where sdod.IsActive
                                      group sd by sdod.OrderDetailId
                                          into shippingGroup
                                          select
                                          new { ShippingPrice = shippingGroup.Sum(s => s.ActualPrice) };

                var sourceCodeDetails = from od in orderDetails
                                        join scod in linqMetaData.SourceCodeOrderDetail on od.OrderDetailId equals
                                            scod.OrderDetailId
                                        where scod.IsActive
                                        select scod.Amount;

                return ((orderDetails.Sum(o => o.Price) + shippingDetails.Sum(s => s.ShippingPrice)) -
                        sourceCodeDetails.Sum());
            }
        }

        //public List<Event> GetFuturePublicEventsWithInRange(string zipCode, int zipRange, long corporateId, int pageNumber, int pageSize)
        //{
        //    var zipCodesInRange = _zipCodeRepository.GetZipCodesInRadius(zipCode, zipRange);
        //    if (zipCodesInRange == null) zipCodesInRange = new List<ZipCode>();
        //    var zipIdsInRange = zipCodesInRange.Select(zcir => zcir.Id).ToList();

        //    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var linqMetaData = new LinqMetaData(adapter);

        //        IQueryable<AddressEntity> queryableAddress = null;
        //        if (!zipIdsInRange.IsEmpty())
        //            queryableAddress = from a in linqMetaData.Address
        //                               join z in linqMetaData.Zip on a.ZipId equals z.ZipId
        //                               where zipIdsInRange.Contains(z.ZipId)
        //                               select a;

        //        IEnumerable<EventsEntity> events = null;
        //        if (queryableAddress != null)
        //        {
        //            events = (from e in linqMetaData.Events
        //                      join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
        //                      join p in linqMetaData.Prospects on eh.HostId equals p.ProspectId
        //                      join a in queryableAddress on p.AddressId equals a.AddressId
        //                      where e.EventDate > DateTime.Today.AddDays(-1) && e.EventStatus == (int)EventStatus.Active && e.IsActive && e.EventTypeId == (long)RegistrationMode.Public
        //                      && (p.IsHost.HasValue && p.IsHost.Value)
        //                      && (corporateId > 0 ? (from ca in linqMetaData.EventAccount where ca.AccountId == corporateId select ca.EventId).Contains(e.EventId) : true)
        //                      select e).WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod)).ToArray();//.TakePage(pageNumber, pageSize)
        //        }
        //        else
        //        {
        //            events = (from e in linqMetaData.Events
        //                      join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
        //                      where e.EventDate > DateTime.Today.AddDays(-1) && e.EventStatus == (int)EventStatus.Active && e.IsActive && e.EventTypeId == (long)RegistrationMode.Public
        //                      && (corporateId > 0 ? (from ca in linqMetaData.EventAccount where ca.AccountId == corporateId select ca.EventId).Contains(e.EventId) : true)
        //                      select e).WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod)).ToArray();//.TakePage(pageNumber, pageSize)
        //        }

        //        return Mapper.MapMultiple(events).ToList();
        //    }
        //}

        private static int IndexOf(string searchText, string searchFrom)
        {
            return searchFrom.IndexOf(searchText);
        }

        public List<Event> GetEventsByFilters(string zipCode, int? zipRange, string stateName, string cityName, DateTime? fromDate, DateTime? toDate, string invitationCode, int pageNumber, int pageSize, bool enableForCallcenter = false,
            long excludeEventId = 0, string tag = "", bool hasMammo = false, long zipCodeId = 0, bool allEvents = false, long? ProductType = null) //, long customerId = 0
        {
            //var zipCodesInRange = !string.IsNullOrEmpty(zipCode) && zipRange.HasValue
            //                          ? _zipCodeRepository.GetZipCodesInRadius(zipCode, zipRange.Value)
            //                          : null;
            //var zipIdsInRange = zipCodesInRange != null ? zipCodesInRange.Select(zcir => zcir.Id).ToList() : null;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var filtered = false;
                var queryableAddress = (from p in linqMetaData.Prospects
                                        join a in linqMetaData.Address on p.AddressId equals a.AddressId
                                        select new { p.ProspectId, a.ZipId, a.StateId, a.CityId });

                //if (!(zipIdsInRange == null || zipIdsInRange.IsEmpty()))
                //{
                //    var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                //    if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                //    linqMetaData.CustomFunctionMappings.Add(mapping);
                //    mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                //    linqMetaData.CustomFunctionMappings.Add(mapping);

                //    string zipIdstring = "," + string.Join(",", zipIdsInRange) + ",";
                //    queryableAddress = from a in queryableAddress
                //                       where IndexOf(Convert.ToString(a.ZipId), zipIdstring) > 0
                //                       select a;

                //    filtered = true;
                //}
                if (zipCodeId > 0 && zipRange.HasValue)
                {
                    var zipBasedonRadius = (from zrd in linqMetaData.ZipRadiusDistance
                                            where zrd.SourceZipId == zipCodeId && zrd.Radius <= zipRange.Value
                                            select zrd.DestinationZipId);

                    queryableAddress = from a in queryableAddress
                                       where zipBasedonRadius.Contains(a.ZipId)
                                       select a;
                    filtered = true;
                }
                else if (!string.IsNullOrEmpty(zipCode))
                {
                    var zipCodes = _zipCodeRepository.GetZipCode(zipCode);
                    if (zipCodes != null && zipCodes.Any())
                    {
                        var zipIds = zipCodes.Select(z => z.Id).ToArray();
                        queryableAddress = from a in queryableAddress
                                           where zipIds.Contains(a.ZipId)
                                           select a;
                        filtered = true;
                    }
                }

                if (!string.IsNullOrEmpty(stateName))
                {
                    queryableAddress = from a in queryableAddress
                                       join s in linqMetaData.State on a.StateId equals s.StateId
                                       where s.Name == stateName
                                       select a;
                    filtered = true;
                }


                if (!string.IsNullOrEmpty(cityName))
                {
                    queryableAddress = from a in queryableAddress
                                       join c in linqMetaData.City on a.CityId equals c.CityId
                                       where c.Name == cityName
                                       select a;
                    filtered = true;
                }

                var queryablEvents = from e in linqMetaData.Events
                                     select e;
                if (ProductType.HasValue && ProductType.Value > 0)
                {
                    queryablEvents = from e in linqMetaData.Events
                                     join ept in linqMetaData.EventProductType on e.EventId equals ept.EventId
                                     where ept.ProductTypeId == ProductType && ept.IsActive
                                     select e;
                    if (excludeEventId > 0)
                        queryablEvents = from e in linqMetaData.Events
                                         join ept in linqMetaData.EventProductType on e.EventId equals ept.EventId
                                         where ept.ProductTypeId == ProductType && ept.IsActive && e.EventId != excludeEventId
                                         select e;

                }
                else
                {

                    if (excludeEventId > 0)
                        queryablEvents = from e in linqMetaData.Events
                                         where e.EventId != excludeEventId
                                         select e;
                }

                if (enableForCallcenter)
                    queryablEvents = from e in queryablEvents where e.EnableForCallCenter select e;

                if (fromDate != null)
                    queryablEvents = from e in queryablEvents where e.EventDate >= fromDate.Value select e;

                if (toDate != null)
                    queryablEvents = from e in queryablEvents where e.EventDate < toDate.Value.AddDays(1).AddMinutes(-1) select e;

                if (!string.IsNullOrWhiteSpace(invitationCode))
                    queryablEvents = from e in queryablEvents where e.InvitationCode == invitationCode.Trim() select e;

                var eventAccountQuery = (from ea in linqMetaData.EventAccount select ea);


                if (!string.IsNullOrEmpty(tag))
                {
                    var account = !string.IsNullOrEmpty(tag) ? (from a in linqMetaData.Account where a.Tag == tag select a).SingleOrDefault() : null;
                    queryablEvents = (from e in queryablEvents
                                      join ea in eventAccountQuery on e.EventId equals ea.EventId
                                      where (account == null || ea.AccountId == account.AccountId)
                                      select e);
                }

                if (hasMammo && !allEvents)
                {
                    queryablEvents = (from e in queryablEvents
                                      join et in linqMetaData.EventTest on e.EventId equals et.EventId
                                      where TestGroup.BreastCancer.Contains(et.TestId)
                                      select e);
                }
                else if (!hasMammo && !allEvents)
                {

                    var eventWithMammo = (from et in linqMetaData.EventTest where TestGroup.BreastCancer.Contains(et.TestId) select et.EventId);

                    queryablEvents = (from e in queryablEvents
                                      where e.AllowNonMammoPatients == true || !eventWithMammo.Contains(e.EventId)
                                      select e);
                }


                //if (customerId > 0 && (_requiredTestRepository.IsRequiredTestAvailble(customerId)))
                //{
                //    var eventIds = (from e in linqMetaData.Events
                //                    join rt in linqMetaData.RequiredTest on e.EventDate.Year equals rt.ForYear
                //                    join et in linqMetaData.EventTest on new { eventId = e.EventId, testId = rt.TestId } equals new { eventId = et.EventId, testId = et.TestId } into etg
                //                    from eti in etg.DefaultIfEmpty()
                //                    where rt.IsActive && eti.TestId == null
                //                    && e.EventDate > DateTime.Today && e.EventStatus == 1 && rt.CustomerId == customerId
                //                    select e.EventId).Distinct().ToArray();

                //    if (eventIds != null && eventIds.Count() > 0)
                //    {
                //        queryablEvents = (from e in queryablEvents
                //                          where !eventIds.Contains(e.EventId)
                //                          select e);
                //    }
                //}

                IEnumerable<EventsEntity> events = null;
                if (filtered)
                {
                    var prospectIds = (from q in queryableAddress select q.ProspectId);

                    events = (from e in queryablEvents
                              join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                              where prospectIds.Contains(eh.HostId) && e.EventDate > DateTime.Today.AddDays(-1) && e.EventStatus == (int)EventStatus.Active && e.IsActive
                              select e).WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod)).ToArray();//.TakePage(pageNumber, pageSize)
                }
                else
                {
                    events = (from e in queryablEvents
                              join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                              where e.EventDate > DateTime.Today.AddDays(-1) && e.EventStatus == (int)EventStatus.Active && e.IsActive
                              select e).WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod)).ToArray();//.TakePage(pageNumber, pageSize)
                }

                return Mapper.MapMultiple(events).ToList();

            }
        }

        public IEnumerable<Event> GetEventsbyFilters(EventBasicInfoViewModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    var entities = (from e in linqMetaData.Events where e.IsActive orderby e.EventDate select e).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount).Prefetch(e => e.EventPod)).TakePage(pageNumber, pageSize).OrderBy(e => e.EventDate).ToArray();
                    totalRecords = (from e in linqMetaData.Events where e.IsActive select e).Count();
                    return Mapper.MapMultiple(entities);
                }
                else
                {
                    var accountQuery = (from ea in linqMetaData.EventAccount select ea);
                    var eventIds = (from ea in accountQuery select ea.EventId);

                    if (filter.AgentOrganizationId > 0)
                    {
                        var assignedAccountIds = (from acco in linqMetaData.AccountCallCenterOrganization
                                                  where acco.OrganizationId == filter.AgentOrganizationId && acco.IsDeleted == false
                                                  select acco.AccountId);

                        var accountIds = (from a in linqMetaData.Account where (a.RestrictHealthPlanData == false || assignedAccountIds.Contains(a.AccountId)) select a.AccountId);

                        accountQuery = (from ea in linqMetaData.EventAccount where (accountIds.Contains(ea.AccountId)) select ea);

                        eventIds = (from ea in accountQuery select ea.EventId);
                    }

                    if (filter.AccountId > 0)
                    {
                        eventIds = (from ea in accountQuery where ea.AccountId == filter.AccountId select ea.EventId);
                    }

                    if (filter.EventId > 0)
                    {
                        if (filter.AccountId > 0 || filter.AgentOrganizationId > 0)
                        {
                            totalRecords = linqMetaData.Events.Where(e => e.EventId == filter.EventId && e.IsActive && eventIds.Contains(e.EventId)).Count();
                            return Mapper.MapMultiple(linqMetaData.Events.Where(e => e.EventId == filter.EventId && e.IsActive && eventIds.Contains(e.EventId)).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount).Prefetch(e => e.EventPod)).ToArray());
                        }

                        totalRecords = linqMetaData.Events.Where(e => e.EventId == filter.EventId && e.IsActive).Count();
                        return Mapper.MapMultiple(linqMetaData.Events.Where(e => e.EventId == filter.EventId && e.IsActive).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount).Prefetch(e => e.EventPod)).ToArray());
                    }

                    var queryable = GetQuerytoEventbyLocation(linqMetaData, filter.Name, filter.City, filter.State, filter.ZipCode, filter.Radius);

                    queryable = queryable.Where(e => e.IsActive);

                    if (filter.AccountId > 0 || filter.AgentOrganizationId > 0)
                    {
                        queryable = queryable.Where(e => eventIds.Contains(e.EventId));
                    }


                    if (!string.IsNullOrEmpty(filter.Pod))
                    {
                        queryable = (from e in queryable
                                     join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                     join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                     where ep.IsActive && p.Name.Contains(filter.Pod)
                                     select e);
                    }

                    if (filter.DateFrom != null)
                    {
                        queryable = (from e in queryable where e.EventDate >= filter.DateFrom.Value select e);
                    }

                    if (filter.DateTo != null)
                    {
                        queryable = (from e in queryable where e.EventDate < filter.DateTo.Value.AddDays(1).AddMinutes(-1) select e);
                    }

                    totalRecords = queryable.Count();
                    var entities = queryable.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount).Prefetch(e => e.EventPod)).OrderBy(e => e.EventDate).TakePage(pageNumber, pageSize).ToArray();
                    return Mapper.MapMultiple(entities);
                }
            }
        }

        public IEnumerable<Event> GetEventsbyFilters(OnlineSchedulingEventListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    var entities = (from e in linqMetaData.Events where e.EventDate >= DateTime.Now && e.IsActive && e.EventStatus != null && e.EventStatus == (int)EventStatus.Active orderby e.EventDate select e).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount)).OrderBy(e => e.EventDate).ToArray();
                    totalRecords = (from e in linqMetaData.Events where e.IsActive select e).Count();
                    return Mapper.MapMultiple(entities);
                }
                else
                {
                    var queryable = GetQuerytoEventbyLocation(linqMetaData, string.Empty, string.Empty, string.Empty, filter.ZipCode, filter.Radius);

                    //var eventIdsToBeExcluded = (from a in linqMetaData.Account
                    //                            join ea in linqMetaData.EventAccount on a.AccountId equals ea.AccountId
                    //                            where !a.AllowOnlineRegistration
                    //                            select ea.EventId);
                    //queryable = queryable.Where(e => !eventIdsToBeExcluded.Contains(e.EventId));

                    if (!string.IsNullOrEmpty(filter.InvitationCode))
                    {
                        queryable = from e in queryable//linqMetaData.Events
                                    where e.InvitationCode.Trim() == filter.InvitationCode.Trim()
                                    select e;
                    }
                    else
                    {
                        var eventIdsToBeExcluded = (from a in linqMetaData.Account
                                                    join ea in linqMetaData.EventAccount on a.AccountId equals ea.AccountId
                                                    where !a.AllowOnlineRegistration
                                                    select ea.EventId);
                        queryable = queryable.Where(e => !eventIdsToBeExcluded.Contains(e.EventId));

                        queryable = (from e in queryable where e.EventTypeId == (int)RegistrationMode.Public select e);
                    }

                    if (filter.DateFrom != null)
                    {
                        queryable = (from e in queryable where e.EventDate >= filter.DateFrom.Value select e);
                    }

                    if (filter.DateTo != null)
                    {
                        queryable = (from e in queryable where e.EventDate < filter.DateTo.Value.AddDays(1) select e);
                    }

                    if (filter.DateFrom == null && filter.DateTo == null)
                    {
                        queryable = queryable.Where(e => e.EventDate >= DateTime.Now.Date);
                    }

                    queryable = queryable.Where(e => (e.EventId == filter.EventId || true) && e.IsActive && e.EventStatus != null && e.EventStatus == (int)EventStatus.Active);

                    if (!string.IsNullOrEmpty(filter.CorpCode))
                    {
                        var eventIds = (from e in linqMetaData.Events
                                        join
                                            ca in linqMetaData.EventAccount on e.EventId equals ca.EventId
                                        join ac in linqMetaData.Account on ca.AccountId equals ac.AccountId
                                        where ac.CorpCode == filter.CorpCode && e.EventDate >= DateTime.Now.Date
                                        select ca.EventId).ToArray();

                        queryable = queryable.Where(e => eventIds.Contains(e.EventId));
                    }

                    totalRecords = queryable.Count();
                    var entities = queryable.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount)).OrderBy(e => e.EventDate).ToArray();

                    if (filter.EventId > 0 && entities.Where(e => e.EventId == filter.EventId).Count() < 1)
                    {
                        var entity = linqMetaData.Events.Where(e => e.EventId == filter.EventId).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount)).ToArray();
                        entities = entities.Concat(entity).ToArray();
                    }

                    return Mapper.MapMultiple(entities);
                }
            }
        }

        private IQueryable<EventsEntity> GetQuerytoEventbyLocation(LinqMetaData linqMetaData, string hostName, string city, string state, string zipCode, int? radius)
        {
            hostName = hostName ?? "";
            city = city ?? "";
            state = state ?? "";
            zipCode = zipCode ?? "";

            if (string.IsNullOrEmpty(hostName) && string.IsNullOrEmpty(city) && string.IsNullOrEmpty(state) && string.IsNullOrEmpty(zipCode))
                return from e in linqMetaData.Events select e;

            var hostEventqueryable = from e in linqMetaData.Events
                                     join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                                     join h in linqMetaData.Prospects on eh.HostId equals h.ProspectId
                                     where h.IsHost.HasValue && h.IsHost.Value &&
                                         (hostName.Trim().Length < 1 || h.OrganizationName.Contains(hostName.Trim()))
                                     select new { e.EventId, AddressId = h.AddressId.Value };

            if (!string.IsNullOrEmpty(city) || !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(zipCode))
            {
                var addressQueryable = from q in hostEventqueryable
                                       join a in linqMetaData.Address on q.AddressId equals a.AddressId
                                       select new { q.EventId, a };

                if (!string.IsNullOrEmpty(city) || !string.IsNullOrEmpty(state))
                {
                    addressQueryable = from q in hostEventqueryable
                                       join a in linqMetaData.Address on q.AddressId equals a.AddressId
                                       join c in linqMetaData.City on a.CityId equals c.CityId
                                       join s in linqMetaData.State on a.StateId equals s.StateId
                                       where (city.Trim().Length < 1 || c.Name.Contains(city.Trim()))
                                       && (state.Trim().Length < 1 || s.Name.Contains(state.Trim()))
                                       select new { q.EventId, a };
                }

                if (!string.IsNullOrEmpty(zipCode))
                {
                    int defaultRadius;
                    string rangeInMiles =
                        _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.Eventdistance);
                    int.TryParse(rangeInMiles, out defaultRadius);

                    List<ZipCode> zipCodes = null;
                    //if (radius.HasValue)
                    //{
                    //    if (radius.Value > 0)
                    //        zipCodes = _zipCodeRepository.GetZipCodesInRadius(zipCode, radius.Value);
                    //    else
                    //    {
                    //        try
                    //        {
                    //            zipCodes = _zipCodeRepository.GetZipCode(zipCode).ToList();
                    //        }
                    //        catch
                    //        { }

                    //    }
                    //}
                    //else
                    //    zipCodes = _zipCodeRepository.GetZipCodesInRadius(zipCode, defaultRadius);
                    try
                    {
                        zipCodes = _zipCodeRepository.GetZipCode(zipCode).ToList();
                    }
                    catch { }

                    if (!zipCodes.IsNullOrEmpty())
                    {
                        var zipCodesInRange = zipCodes.Select(zcir => zcir.Id).ToList();
                        if ((radius.HasValue && radius.Value > 0) || (radius.HasValue == false && defaultRadius > 0))
                        {
                            radius = radius ?? defaultRadius;
                            var zipRadiusDistacne = (from zrd in linqMetaData.ZipRadiusDistance
                                                     where zipCodesInRange.Contains(zrd.SourceZipId) && zrd.Radius <= radius
                                                     select zrd.DestinationZipId);

                            addressQueryable = from aq in addressQueryable where zipRadiusDistacne.Contains(aq.a.ZipId) select aq;
                        }
                        else
                        {
                            addressQueryable = from aq in addressQueryable where zipCodesInRange.Contains(aq.a.ZipId) select aq;
                        }
                    }
                    else
                    {
                        const int idToCancelAllRecords = 0;
                        addressQueryable = from aq in addressQueryable where (aq.EventId == idToCancelAllRecords) select aq;
                    }


                    //if (zipCodes != null && zipCodes.Count > 0)
                    //{
                    //    var zipCodesInRange = zipCodes.Select(zcir => zcir.Id).ToList();

                    //    var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                    //    if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                    //    linqMetaData.CustomFunctionMappings.Add(mapping);
                    //    mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                    //    linqMetaData.CustomFunctionMappings.Add(mapping);

                    //    string zipIdstring = "," + string.Join(",", zipCodesInRange) + ",";

                    //    //addressQueryable = from aq in addressQueryable where zipCodes.Select(z => z.Id).Contains(aq.a.ZipId) select aq;

                    //    addressQueryable = from aq in addressQueryable where IndexOf(Convert.ToString(aq.a.ZipId), zipIdstring) > 0 select aq;
                    //}
                    //else
                    //{
                    //    const int idToCancelAllRecords = 0;
                    //    addressQueryable = from aq in addressQueryable where (fetchRecordsifZipnotinRange ? true : aq.EventId == idToCancelAllRecords) select aq;
                    //}
                }

                hostEventqueryable = addressQueryable.Select(aq => new { aq.EventId, aq.a.AddressId });
            }

            return from e in linqMetaData.Events join h in hostEventqueryable on e.EventId equals h.EventId select e;
        }

        public string GetTechnicianNotes(long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return linqMetaData.HostEventDetails.WithPath(prefetchpath => prefetchpath.Prefetch(e => e.Events)).Where(
                        e => eventId == e.EventId).Select(en => en.ConfirmedVisuallyComments).SingleOrDefault();
            }
        }

        public string GetCallCenterNotes(long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return
                    linqMetaData.HostEventDetails.WithPath(prefetchpath => prefetchpath.Prefetch(e => e.Events)).Where(
                        e => eventId == e.EventId).Select(en => en.InstructionForCallCenter).SingleOrDefault();
            }
        }

        public List<OrderedPair<long, int>> GetTotalAppointmentSlots(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return
                    linqMetaData.EventAppointment.Where(ea => eventIds.Contains(ea.EventId))
                        .GroupBy(ea => ea.EventId).Select(
                        g => new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetBookedAppointmentSlots(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue
                                                        select ec.EventId).Count())).ToList();

                //linqMetaData.EventCustomers.Where(ec => eventIds.Contains(ec.EventId) && ec.AppointmentId.HasValue)
                //    .GroupBy(ec => ec.EventId).Select(
                //        g => new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetAvailableAppointmentSlots(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return
                    linqMetaData.EventAppointment.Where(
                        ea => ea.ScheduledByOrgRoleUserId == null && eventIds.Contains(ea.EventId))
                        .
                        GroupBy(ea => ea.EventId).Select(
                        g => new OrderedPair<long, int>(g.Key, g.Count())).ToList();
            }
        }

        public bool ValidateInvitationCode(long eventId, string invitationCode)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.Events.Any(e => e.EventId == eventId && e.InvitationCode == invitationCode);
            }
        }

        public IEnumerable<Event> GetEventswithPodbyIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventsEntity> eventEntities =
                    linqMetaData.Events.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount).Prefetch(e => e.HostEventDetails)).Where(
                        e => ids.Contains(e.EventId)).ToList();

                if (!eventEntities.IsNullOrEmpty())
                    return Mapper.MapMultiple(eventEntities).ToList();
                return null;
            }
        }

        public new Event GetById(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                EventsEntity eventEntitys =
                    linqMetaData.Events.WithPath(
                        prefetchPath => prefetchPath.Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount).Prefetch(e => e.HostEventDetails)).Where(
                            e => e.EventId == eventId).SingleOrDefault();

                return Mapper.Map(eventEntitys);

            }
        }

        public List<Event> GetRetailEvents(int pageNumber, int pageSize, EventVolumeListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                List<EventsEntity> eventEntities;
                if (filter.IsEmpty())
                {
                    var query =
                        (from ea in GetEventEntityQuerywithIsCorporateField(linqMetaData)
                         where !ea.SecondValue && ea.FirstValue.IsActive
                         select ea.FirstValue).OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var queryEventIds = GetFilteredEventIds(filter);

                    var query =
                        (from ea in GetEventEntityQuerywithIsCorporateField(linqMetaData)
                         where !ea.SecondValue && queryEventIds.Contains(ea.FirstValue.EventId) && ea.FirstValue.IsActive
                         select ea.FirstValue).OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).TakePage(pageNumber, pageSize).ToList();
                }
                if (!eventEntities.IsNullOrEmpty())
                    return Mapper.MapMultiple(eventEntities).ToList();

                return null;
            }
        }

        public List<Event> GetCorporteEvents(int pageNumber, int pageSize, EventVolumeListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                List<EventsEntity> eventEntities;

                var accountIdsQuery = (from a in linqMetaData.Account where a.IsHealthPlan == false select a.AccountId);

                if (filter.IsEmpty())
                {
                    var query = (from e in linqMetaData.Events
                                 join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                                 where e.EventStatus.HasValue
                                    && (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                                    && accountIdsQuery.Contains(ea.AccountId)
                                 select e).OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    //var query = (from ea in GetEventEntityQuerywithIsCorporateField(linqMetaData)
                    //     where ea.SecondValue && ea.FirstValue.IsActive
                    //     select ea.FirstValue).OrderByDescending(e => e.EventDate).OrderBy(e => e.EventId);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount)).TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var queryEventIds = GetFilteredEventIds(filter);

                    //var query =
                    //    (from ea in GetEventEntityQuerywithIsCorporateField(linqMetaData)
                    //     where ea.SecondValue && queryEventIds.Contains(ea.FirstValue.EventId) && ea.FirstValue.IsActive
                    //     select ea.FirstValue).OrderBy(e => e.EventDate).OrderBy(e => e.EventId);

                    var query = (from e in linqMetaData.Events
                                 join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                                 where e.EventStatus.HasValue
                                    && (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                                    && accountIdsQuery.Contains(ea.AccountId) && queryEventIds.Contains(e.EventId)
                                 select e).OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount)).TakePage(pageNumber, pageSize).ToList();
                }

                if (!eventEntities.IsNullOrEmpty()) return Mapper.MapMultiple(eventEntities).ToList();
                return null;
            }
        }

        private IQueryable<long> GetFilteredEventIds(EventVolumeListModelFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;
                string zip, vehicle = "";
                zip = string.IsNullOrEmpty(filter.ZipCode) ? "" : filter.ZipCode;
                vehicle = string.IsNullOrEmpty(filter.Vehicle) ? "" : filter.Vehicle;


                var eventFilterQuery = (from e in linqMetaData.Events
                                        join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                                        join prospect in linqMetaData.Prospects on eh.HostId equals prospect.ProspectId
                                        join a in linqMetaData.Address on prospect.AddressId equals a.AddressId
                                        join z in linqMetaData.Zip on a.ZipId equals z.ZipId
                                        join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                        join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                        where e.EventStatus.HasValue
                                              && (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                                              && ep.IsActive
                                              && ((filter.IsPublicEvent && !filter.IsPrivateEvent)
                                                      ? e.EventTypeId == (long)RegistrationMode.Public
                                                      : (!filter.IsPublicEvent && filter.IsPrivateEvent)
                                                            ? e.EventTypeId == (long)RegistrationMode.Private
                                                            : true)
                                              && (filter.FromDate != null ? fromDate <= e.EventDate : true)
                                              && (filter.ToDate != null ? toDate >= e.EventDate : true)
                                              && (z.ZipCode.Contains(zip)) && (p.Name.Contains(vehicle))
                                        select new { e, z });

                if (!string.IsNullOrEmpty(filter.Territory))
                    eventFilterQuery = (from ez in eventFilterQuery
                                        join tz in linqMetaData.TerritoryZip on ez.z.ZipId equals tz.ZipId
                                        join t in linqMetaData.Territory on tz.TerritoryId equals t.TerritoryId
                                        where (t.Name.Contains(filter.Territory))
                                        select ez);

                return eventFilterQuery.Select(ez => ez.e.EventId);
            }
        }

        //public static Func<EventsEntity, TerritoryEntity, ZipEntity, PodDetailsEntity, bool> GetExpressionforEventFiltering(EventBaseModelFilter filter)
        //{
        //    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
        //    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

        //    return
        //        ((e, t, z, p) =>
        //         (filter.FromDate != null ? fromDate < e.EventDate : true) &&
        //                    (filter.ToDate != null ? toDate > e.EventDate : true) &&
        //                    (filter.Territory.Trim().Length > 0 ? t.Name.Contains(filter.Territory) : true)
        //                    && (filter.ZipCode.Trim().Length > 0 ? z.ZipCode.Contains(filter.ZipCode) : true)
        //                    && (filter.Vehicle.Trim().Length > 0 ? p.Name.Contains(filter.Vehicle) : true));
        //}

        public static IQueryable<OrderedPair<EventsEntity, bool>> GetEventEntityQuerywithIsCorporateField(LinqMetaData linqMetaData)
        {
            return from e in linqMetaData.Events
                   join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId into queryableEvent
                   from qe in queryableEvent.DefaultIfEmpty()
                   where e.EventStatus.HasValue && (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                   select new OrderedPair<EventsEntity, bool>(e, (qe.AccountId > 0 ? true : false));
        }

        public IEnumerable<Event> GetEventsforDetailOpenOrder(int pageNumber, int pageSize, DetailOpenOrderModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventEntities = new List<EventsEntity>();
                if (filter == null)
                {
                    var query = (from e in linqMetaData.Events
                                 where e.EventDate >= DateTime.Now.Date && e.EventStatus == (int)EventStatus.Active && e.IsActive
                                 select e);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                    var query = (from e in GetEventEntityQuerywithIsCorporateField(linqMetaData)
                                 where (filter.FromDate != null ? e.FirstValue.EventDate >= fromDate : true)
                                       && (filter.ToDate != null ? e.FirstValue.EventDate <= toDate : true)
                                       && (filter.IsRetailEvent && !filter.IsCorporateEvent
                                               ? (!e.SecondValue)
                                               : (!filter.IsRetailEvent && filter.IsCorporateEvent
                                                      ? e.SecondValue
                                                      : true))
                                       && ((filter.IsPublicEvent && !filter.IsPrivateEvent)
                                               ? e.FirstValue.EventTypeId == (long)RegistrationMode.Public
                                               : (!filter.IsPublicEvent && filter.IsPrivateEvent)
                                                     ? e.FirstValue.EventTypeId == (long)RegistrationMode.Private
                                                     : true)
                                       && e.FirstValue.IsActive
                                 orderby e.FirstValue.EventDate descending, e.FirstValue.EventId ascending
                                 select e.FirstValue);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).TakePage(pageNumber, pageSize).ToList();
                }
                return Mapper.MapMultiple(eventEntities);
            }
        }

        public IEnumerable<Event> GetForMonth(int month, int year)
        {
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var events = (linqMetaData.Events.WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod))
                                .Where(e => (e.EventDate >= startDate && e.EventDate <= endDate) && e.IsActive)).ToList();

                return Mapper.MapMultiple(events);
            }
        }

        public IEnumerable<Event> GetForStaffCalendar(EventStaffAssignmentListModelFilter filter, bool isForExport = false)
        {
            var startDate = new DateTime(filter.Year, filter.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventIds = (from ea in linqMetaData.EventAccount
                                where ea.AccountId == filter.AccountId
                                select ea.EventId);

                var events = (from e in linqMetaData.Events
                              where (e.EventDate >= startDate && e.EventDate <= endDate) &&
                              (e.EventStatus == (int)EventStatus.Active || e.EventStatus == (int)EventStatus.Suspended) && e.IsActive
                              select e);

                if (filter.AccountId > 0)
                {
                    events = (from e in linqMetaData.Events
                              where (filter.AccountId == 0 || eventIds.Contains(e.EventId)) &&
                                    (e.EventDate >= startDate && e.EventDate <= endDate) &&
                                    (e.EventStatus == (int)EventStatus.Active || e.EventStatus == (int)EventStatus.Suspended) &&
                                    e.IsActive
                              select e);
                }

                if (filter.PodId > 0)
                    events = (from e in events
                              join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                              where ep.IsActive && ep.PodId == filter.PodId && (e.EventStatus == (int)EventStatus.Active || e.EventStatus == (int)EventStatus.Suspended)
                              select e);

                if (filter.StaffId > 0)
                {
                    var query = from ep in linqMetaData.EventPod
                                join p in linqMetaData.PodDefaultTeam on ep.PodId equals p.PodId
                                    into queryableDefStaff
                                from qds in queryableDefStaff.DefaultIfEmpty()
                                join esa in linqMetaData.EventStaffAssignment on ep.EventId equals esa.EventId
                                    into queryableStaff
                                from qs in queryableStaff.DefaultIfEmpty()
                                where ep.IsActive
                                select
                                    new
                                        {
                                            ep.EventId,
                                            OrgRoleUserId = ((qs.ActualStaffOrgRoleUserId == null && qs.ScheduledStaffOrgRoleUserId == null)
                                         ? qds.OrgnizationRoleUserId
                                         : (qs.ActualStaffOrgRoleUserId ?? qs.ScheduledStaffOrgRoleUserId))
                                        };

                    events = from e in events
                             where query.Where(q => q.OrgRoleUserId == filter.StaffId).Select(q => q.EventId).Contains(e.EventId)
                             select e;
                }

                if (isForExport)
                {
                    filter.TotalRecords = events.Count();
                    events = events.Skip(filter.PageSize * (filter.PageNumber - 1)).Take(filter.PageSize);
                }

                return Mapper.MapMultiple(events.WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod)).ToArray());
            }
        }

        public List<Event> GetEventByInvitataionCd(string pInvitationCd)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var events =
                    Enumerable.ToList<EventsEntity>(linqMetaData.Events.WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails)).Where(
                            e => e.EventDate > DateTime.Today.AddDays(-1) && e.IsActive && e.InvitationCode == pInvitationCd && e.EventTypeId == (long)RegistrationMode.Private));


                return Mapper.MapMultiple(events).ToList();
            }
        }

        public Event GetEventbyHostName(string hostName, DateTime? dateTime)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity =
                    (from e in linqMetaData.Events
                     join he in linqMetaData.HostEventDetails on e.EventId equals he.EventId
                     join p in linqMetaData.Prospects on he.HostId equals p.ProspectId
                     where p.OrganizationName == hostName && e.EventStatus.HasValue && e.EventStatus.Value == (int)EventStatus.Active
                     orderby e.EventDate descending
                     select e
                    );

                if (dateTime.HasValue)
                    entity = entity.Where(e => e.EventDate.Date == dateTime.Value.Date);

                if (entity.Count() > 0)
                {
                    return Mapper.Map(entity.First());
                }
                return null;
            }
        }

        public IEnumerable<long> GetEventIdsforaTechnicianasStaff(long technicianId, IEnumerable<long> filterFromEventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var queryDefTeam = from ep in linqMetaData.EventPod
                                   join p in linqMetaData.PodDefaultTeam on ep.PodId equals p.PodId
                                   where ep.IsActive && p.IsActive && filterFromEventIds.Contains(ep.EventId)
                                   select new { ep.EventId, OrgRoleUserId = p.OrgnizationRoleUserId };

                var queryAssignedTeam = from ep in linqMetaData.EventPod
                                        join p in linqMetaData.EventStaffAssignment on ep.EventId equals p.EventId
                                        where filterFromEventIds.Contains(ep.EventId) && ep.IsActive && p.IsActive
                                        select new { ep.EventId, OrgRoleUserId = p.ActualStaffOrgRoleUserId.HasValue ? p.ActualStaffOrgRoleUserId.Value : p.ScheduledByOrgRoleUserId };

                var query = (from def in queryDefTeam
                             join asd in queryAssignedTeam on def.EventId equals asd.EventId into queryableStaff
                             from qs in queryableStaff.DefaultIfEmpty()
                             select
                                 new
                                     {
                                         def.EventId,
                                         OrgRoleUserId = (qs.OrgRoleUserId < 1 ? def.OrgRoleUserId : qs.OrgRoleUserId)
                                     });

                return query.Where(q => q.OrgRoleUserId == technicianId).Select(q => q.EventId).ToArray();
            }
        }

        public IEnumerable<Event> GetEventsForDailyRecap(int pageNumber, int pageSize, DailyRecapModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    filter = new DailyRecapModelFilter { EventDateFrom = DateTime.Now, EventDateTo = DateTime.Now };
                }
                var fromDate = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now.Date;
                var toDate = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now.Date;

                var pod = string.IsNullOrEmpty(filter.Pod) ? "" : filter.Pod;

                var query = (from e in linqMetaData.Events
                             join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                             join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                             where (e.EventDate >= fromDate && e.EventDate <= toDate)
                                   && (p.Name.Contains(pod) && ep.IsActive)
                                   && e.IsActive
                                   && e.EventStatus.Value == (int)EventStatus.Active
                             select e);

                if (filter.IsRetailEvent && !filter.IsCorporateEvent && !filter.IsHealthPlan)
                {
                    var eventIds = (from ea in linqMetaData.EventAccount
                                    select ea.EventId);
                    query = query.Where(q => !eventIds.Contains(q.EventId));
                }
                else if (!filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlan)
                {
                    var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                    var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => eventIds.Contains(q.EventId));
                }
                else if (!filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlan)
                {
                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => eventIds.Contains(q.EventId));
                }
                else if (!filter.IsRetailEvent && filter.IsCorporateEvent && filter.IsHealthPlan)
                {
                    var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                    query = query.Where(q => eventIds.Contains(q.EventId));
                }
                else if (filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlan)
                {
                    var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                    var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => !eventIds.Contains(q.EventId));
                }
                else if (filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlan)
                {
                    var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                    query = query.Where(q => !eventIds.Contains(q.EventId));
                }

                if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                    query = query.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                    query = query.Where(q => q.EventTypeId == (long)RegistrationMode.Private);

                query = from q in query
                        orderby q.EventDate, q.EventId
                        select q;

                totalRecords = query.Count();
                var eventEntities = query.TakePage(pageNumber, pageSize).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).ToList();
                return Mapper.MapMultiple(eventEntities);
            }
        }

        public List<OrderedPair<long, int>> GetTotalRegistration(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetAttendedCustomers(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue && !ec.LeftWithoutScreeningReasonId.HasValue
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetAttendedCustomersByHospitalPartnerId(long hospitalPartnerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        join ehp in linqMetaData.EventHospitalPartner on e.EventId equals ehp.EventId
                        where ehp.HospitalPartnerId == hospitalPartnerId
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue && !ec.NoShow && ec.LeftWithoutScreeningReasonId == null && ea.CheckinTime.HasValue
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetNoShowCustomers(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue && ec.NoShow
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetCancelledCustomers(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && !ec.AppointmentId.HasValue
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetCustomersWithAppointment(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetCustomersWithAppointmentByHospitalPartnerId(long hospitalPartnerId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        join ehp in linqMetaData.EventHospitalPartner on e.EventId equals ehp.EventId
                        where ehp.HospitalPartnerId == hospitalPartnerId
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public bool IsHospitalPartnerAttached(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return !((from ehp in linqMetaData.EventHospitalPartner
                          where ehp.EventId == eventId
                          select ehp.HospitalPartnerId).IsEmpty());
            }
        }

        public IEnumerable<Event> GetEventsForEventResultStatus(int pageNumber, int pageSize, EventResultStatusViewModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    var queryable = (from ec in linqMetaData.EventCustomers
                                     join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals
                                         ecr.EventCustomerResultId into ececr
                                     from ee in ececr.DefaultIfEmpty()
                                     join e in linqMetaData.Events on ec.EventId equals e.EventId
                                     where ec.AppointmentId.HasValue
                                           && (!ec.NoShow) && ec.LeftWithoutScreeningReasonId == null
                                     orderby e.EventDate descending
                                     select e).Distinct();

                    totalRecords = queryable.Count();
                    var eventEntities = queryable.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.EventPod).Prefetch(e => e.HostEventDetails)).TakePage(pageNumber, pageSize).ToArray();//

                    return Mapper.MapMultiple(eventEntities);
                }
                else
                {
                    var dateFrom = filter.EventDateFrom.HasValue ? filter.EventDateFrom.Value : DateTime.Now;
                    var dateTo = filter.EventDateTo.HasValue ? filter.EventDateTo.Value : DateTime.Now;

                    var queryable = (from e in linqMetaData.Events
                                     join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                     join ecr in linqMetaData.EventCustomerResult on ec.EventCustomerId equals
                                         ecr.EventCustomerResultId
                                         into ecr_leftjoin
                                     from ee in ecr_leftjoin.DefaultIfEmpty()
                                     where e.EventDate < DateTime.Now.AddDays(1).Date &&
                                            ec.AppointmentId.HasValue && (!ec.NoShow) && ec.LeftWithoutScreeningReasonId == null
                                     && (filter.EventId > 0 ? ec.EventId == filter.EventId : true)
                                     && (filter.EventDateFrom != null ? e.EventDate >= dateFrom : true)
                                     && (filter.EventDateTo != null ? e.EventDate <= dateTo : true)
                                     && (filter.Status == (int)EventResultStatusFilter.MissingResults ? (ee.ResultState == null || ee.ResultState == (int)TestResultStateNumber.NoResults) : true)
                                     && (filter.Status == (int)EventResultStatusFilter.UnStableState ? (ee.ResultState == 0) : true)
                                     && (filter.Status == (int)EventResultStatusFilter.PreAuditPending ? (ee.ResultState > (int)TestResultStateNumber.NoResults && ee.ResultState < (int)TestResultStateNumber.PreAudit) : true)
                                     && (filter.Status == (int)EventResultStatusFilter.ReviewPending ? (ee.ResultState == (int)TestResultStateNumber.PreAudit || (ee.ResultState == (int)TestResultStateNumber.Evaluated && ee.IsPartial)) : true)
                                     && (filter.Status == (int)EventResultStatusFilter.PostAuditPending ? (ee.ResultState == (int)TestResultStateNumber.Evaluated && (!ee.IsPartial)) : true)
                                     && (filter.Status == (int)EventResultStatusFilter.ResultDelivered ? (ee.ResultState == (int)TestResultStateNumber.ResultDelivered) : true)
                                     //orderby e.EventDate descending
                                     select e);

                    if (filter.Status == (int)EventResultStatusFilter.UploadPending || filter.Status == (int)EventResultStatusFilter.ParsePending)
                    {
                        var a = from e in linqMetaData.ResultArchiveUpload
                                where (from rau in linqMetaData.ResultArchiveUpload
                                       group rau by rau.EventId
                                           into g
                                           select g.Max(rau => rau.ResultArchiveUploadId)).Contains(e.ResultArchiveUploadId)
                                      &&
                                      (filter.Status == (int)EventResultStatusFilter.UploadPending
                                           ? (e.Status < (int)ResultArchiveUploadStatus.Uploaded)
                                           : true)
                                      &&
                                      (filter.Status == (int)EventResultStatusFilter.ParsePending
                                           ? (e.Status > (int)ResultArchiveUploadStatus.Uploaded &&
                                              e.Status < (int)ResultArchiveUploadStatus.Parsed)
                                           : true)
                                select e.EventId;

                        if (filter.Status == (int)EventResultStatusFilter.UploadPending)
                            queryable = from e in queryable where a.Contains(e.EventId) || !(from rau in linqMetaData.ResultArchiveUpload select rau.EventId).Contains(e.EventId) select e;
                        else
                            queryable = from e in queryable where a.Contains(e.EventId) select e;
                    }

                    if (filter.PodId > 0)
                    {

                        var eventIdPodQueryable = (from ep in linqMetaData.EventPod where ep.IsActive && ep.PodId == filter.PodId select ep.EventId);
                        queryable = queryable.Where(q => eventIdPodQueryable.Contains(q.EventId));
                    }

                    //var eventiIdQueryable = queryable.Distinct().OrderByDescending(x => x.EventDate).Select(x => x.EventId);
                    var eventiIdQueryable = (from q in queryable select q).Distinct().OrderByDescending(x => x.EventDate).Select(x => x.EventId);

                    totalRecords = eventiIdQueryable.Count();
                    var eventids = eventiIdQueryable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();//

                    return eventids.Count() > 0 ? eventids.Select(x => GetById(x)).ToList() : null;
                }
                //return Mapper.MapMultiple(eventEntities);
            }
        }

        public IEnumerable<Event> GetEventsForHospitalPartnerDashboard(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var fromDate = DateTime.Now.AddDays(-1 * (int)DateTime.Now.DayOfWeek);
                var toDate = DateTime.Now.AddDays(6 - (int)DateTime.Now.DayOfWeek);

                var query = (from ehp in linqMetaData.EventHospitalPartner
                             join ecr in linqMetaData.EventCustomerResult on ehp.EventId equals ecr.EventId
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             where ehp.HospitalPartnerId == hospitalPartnerId
                                   && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) ||
                                   (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                   && e.EventDate >= fromDate
                                   && e.EventDate < toDate
                             orderby e.EventDate
                             select e).Distinct();

                var eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).ToList();

                return Mapper.MapMultiple(eventEntities);
            }
        }

        public IEnumerable<long> GetEventIdsForCorporateAccount(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ehp in linqMetaData.EventAccount
                        join e in linqMetaData.Events on ehp.EventId equals e.EventId
                        where ehp.AccountId == accountId
                              && e.EventStatus.HasValue
                              && e.EventStatus.Value == (int)EventStatus.Active
                        select e.EventId).ToArray();
            }
        }

        public IEnumerable<Event> GetEventsForCorporateAccountDashboard(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var fromDate = DateTime.Now.AddDays(-30);
                var toDate = DateTime.Now.AddDays(30);

                var query = (from eac in linqMetaData.EventAccount
                             join ecr in linqMetaData.EventCustomerResult on eac.EventId equals ecr.EventId
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             where eac.AccountId == accountId
                                   && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered) ||
                                   (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                   && e.EventDate >= fromDate
                                   && e.EventDate < toDate
                             orderby e.EventDate
                             select e).Distinct();

                var eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).ToArray();

                return Mapper.MapMultiple(eventEntities);
            }
        }

        public IEnumerable<Event> GetEventsForHospitalPartner(int pageNumber, int pageSize, HospitalPartnerEventListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
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

                var query = (from ehp in linqMetaData.EventHospitalPartner
                             join e in linqMetaData.Events on ehp.EventId equals e.EventId
                             where ehp.HospitalPartnerId == filter.HospitalPartnerId
                                   && e.EventStatus.HasValue
                                   && e.EventStatus.Value == (int)EventStatus.Active
                             select e);


                var resultQuery = (from ecr in linqMetaData.EventCustomerResult
                                   select ecr);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit || ecr.ResultState <= (int)NewTestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                IQueryable<long> eventFilterQuery = (from ecr in linqMetaData.EventCustomerResult
                                                     join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                                     join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                                     join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                                     where ec.PartnerRelease == (int)RegulatoryState.Signed
                                                         && ec.Hipaastatus == (int)RegulatoryState.Signed
                                                         && ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue
                                                         &&
                                                         (
                                                             (!ecr.ResultSummary.HasValue && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (maximumValidityPeriod > 0 ? e.EventDate.AddDays(maximumValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             (ecr.ResultSummary == (long)ResultInterpretation.Normal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (normalValidityPeriod > 0 ? e.EventDate.AddDays(normalValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             (ecr.ResultSummary == (long)ResultInterpretation.Abnormal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (abnormalValidityPeriod > 0 ? e.EventDate.AddDays(abnormalValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             (ecr.ResultSummary == (long)ResultInterpretation.Urgent && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             ((ecr.ResultSummary == (long)ResultInterpretation.Critical || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId))
                                                                 && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                         )
                                                     select ecr.EventId);

                if (filter.EventId < 1 && (filter.ResultInterpretation > 0 || filter.CriticalMarkedByTechnician))
                {
                    eventFilterQuery = (from ecr in linqMetaData.EventCustomerResult
                                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                        where ec.PartnerRelease == (int)RegulatoryState.Signed
                                            && ec.Hipaastatus == (int)RegulatoryState.Signed
                                            && ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue
                                            && (filter.ResultInterpretation > 0 ? ecr.ResultSummary == filter.ResultInterpretation &&
                                                (
                                                    (ecr.ResultSummary == (long)ResultInterpretation.Normal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                        && (normalValidityPeriod > 0 ? e.EventDate.AddDays(normalValidityPeriod) >= DateTime.Now.Date : true))
                                                    ||
                                                    (ecr.ResultSummary == (long)ResultInterpretation.Abnormal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                        && (abnormalValidityPeriod > 0 ? e.EventDate.AddDays(abnormalValidityPeriod) >= DateTime.Now.Date : true))
                                                    ||
                                                    (ecr.ResultSummary == (long)ResultInterpretation.Urgent && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                        && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                    ||
                                                    ((ecr.ResultSummary == (long)ResultInterpretation.Critical)
                                                        && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                ) : true
                                            )
                                            && (filter.CriticalMarkedByTechnician ?
                                                    ((criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId))
                                                        && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                : true
                                            )
                                        select ecr.EventId);

                }

                query = query.Where(q => eventFilterQuery.Contains(q.EventId));

                if (filter.EventId > 0)
                {
                    query = query.Where(q => q.EventId == filter.EventId);
                }
                else
                {
                    if (filter.FromDate.HasValue)
                        query = query.Where(a => a.EventDate >= filter.FromDate.Value);

                    if (filter.ToDate.HasValue)
                        query =
                            query.Where(
                                a => a.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));

                    if (filter.Status == (int)HospitalPartnerEventStatusFilter.Unprocessed)
                    {
                        query =
                            query.Where(
                                q =>
                                resultQuery.Where(rq => (q.EventDate < _settings.ResultFlowChangeDate && rq.ResultState == (int)TestResultStateNumber.PostAudit)
                                    || (q.EventDate >= _settings.ResultFlowChangeDate && rq.ResultState == (int)NewTestResultStateNumber.PostAuditNew)).Select(
                                    rq => rq.EventId).Contains(q.EventId));
                    }
                    else if (filter.Status == (int)HospitalPartnerEventStatusFilter.Processed)
                    {
                        query =
                            query.Where(
                                q =>
                                resultQuery.Where(rq => (q.EventDate < _settings.ResultFlowChangeDate && rq.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                || (q.EventDate >= _settings.ResultFlowChangeDate && rq.ResultState == (int)NewTestResultStateNumber.ResultDelivered)).Select(
                                    rq => rq.EventId).Contains(q.EventId));
                    }

                }
                if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    query = query.OrderBy(q => q.EventDate).OrderBy(q => q.EventId);
                else
                    query = query.OrderByDescending(q => q.EventDate).OrderBy(q => q.EventId);

                totalRecords = query.Count();
                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).TakePage(pageNumber, pageSize).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Event> GetEventsForCorporateAccount(int pageNumber, int pageSize, CorporateAccountEventListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = 0;
                    return null;
                }

                var query = (from ehp in linqMetaData.EventAccount
                             join e in linqMetaData.Events on ehp.EventId equals e.EventId
                             where ehp.AccountId == filter.AccountId
                                   && e.EventStatus.HasValue
                                   && e.EventStatus.Value == (int)EventStatus.Active
                             select e);


                var resultQuery = (from ecr in linqMetaData.EventCustomerResult select ecr);

                var eventFilterQuery = (from ecr in linqMetaData.EventCustomerResult
                                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals
                                            ec.EventCustomerId
                                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals
                                            ea.AppointmentId
                                        where ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue
                                        select ecr);

                query = query.Where(q => eventFilterQuery.Select(efq => efq.EventId).Contains(q.EventId));

                if (filter.EventId > 0)
                {
                    query = query.Where(q => q.EventId == filter.EventId);
                }
                else
                {
                    if (filter.FromDate.HasValue)
                        query = query.Where(a => a.EventDate >= filter.FromDate.Value);

                    if (filter.ToDate.HasValue)
                        query =
                            query.Where(a => a.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));


                    if (filter.ResultInterpretation > 0)
                    {
                        query =
                            query.Where(
                                q => resultQuery.Where(rq => rq.ResultSummary == filter.ResultInterpretation).Select(rq => rq.EventId).Contains(q.EventId));
                    }
                }
                query = query.OrderBy(q => q.EventDate);
                totalRecords = query.Count();
                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).TakePage(pageNumber, pageSize).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public Event GetEventForAuthorization(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var physicianAssignedEventIds = from pea in linqMetaData.PhysicianEventAssignment
                                                where pea.PhysicianId == physicianId && pea.IsActive
                                                select pea.EventId;

                var physicianAssignedEventCustomerIDs = from pca in linqMetaData.PhysicianCustomerAssignment
                                                        where pca.PhysicianId == physicianId && pca.IsActive
                                                        select pca.EventCustomerId;

                var authorizedEventCustomerIds = (from sa in linqMetaData.ScreeningAuthorization
                                                  select sa.EventCustomerId);

                var eventIds = (from ec in linqMetaData.EventCustomers
                                where ec.AppointmentId.HasValue && !ec.NoShow
                                      && !authorizedEventCustomerIds.Contains(ec.EventCustomerId)
                                      && !(from pca in linqMetaData.PhysicianCustomerAssignment where pca.PhysicianId != physicianId && pca.IsActive select pca.EventCustomerId).Contains(ec.EventCustomerId)
                                      && (physicianAssignedEventIds.Contains(ec.EventId) || physicianAssignedEventCustomerIDs.Contains(ec.EventCustomerId))
                                select ec.EventId);

                var eventEntity = (from e in linqMetaData.Events
                                   where
                                       //e.EventDate >= DateTime.Now.Date && 
                                   eventIds.Contains(e.EventId)
                                   orderby e.EventDate == DateTime.Now.Date ? 1 : (e.EventDate < DateTime.Now.Date ? 2 : 3)
                                   orderby e.EventDate
                                   select e
                                  ).Distinct().FirstOrDefault();

                if (eventEntity == null) return null;

                return Mapper.Map(eventEntity);
            }
        }

        public void SetCommandforGenrateHealthAssesmentForm(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new EventsEntity { GenerateHealthAssesmentForm = true, GenerateHealthAssesmentFormStatus = (long)GenerateHealthAssesmentFormStatus.Pending }, new RelationPredicateBucket(EventsFields.EventId == eventId));
            }
        }

        public Notes GetEmrNotes(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var notesId =
                    linqMetaData.Events.Where(e => e.EventId == eventId).Select(e => e.EmrNotesId).SingleOrDefault();
                if (!notesId.HasValue) return null;

                var notesRepository = new NotesRepository();
                return notesRepository.Get(notesId.Value);
            }
        }

        public Notes SaveEmrNotes(long eventId, Notes notes)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                bool updateEventWithId = false;
                if (notes.Id < 1) updateEventWithId = true;

                var notesRepository = new NotesRepository();
                notes = notesRepository.Save(notes);

                if (notes.Id > 0 && updateEventWithId)
                {
                    adapter.UpdateEntitiesDirectly(new EventsEntity { EmrNotesId = notes.Id }, new RelationPredicateBucket(EventsFields.EventId == eventId));
                }

                return notes;
            }
        }

        public void SaveEventSignoffData(long orgRoleUserId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                adapter.UpdateEntitiesDirectly(new EventsEntity
                                                    {
                                                        IsSignoff = true,
                                                        SignoffDatetime = DateTime.Now,
                                                        SignOffOrgRoleUserId = orgRoleUserId
                                                    }, new RelationPredicateBucket(EventsFields.EventId == eventId));

            }
        }

        public bool AttachHospitalMaterial(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ehp in linqMetaData.EventHospitalPartner
                        where ehp.EventId == eventId
                        select ehp.AttachHospitalMaterial).SingleOrDefault();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetUnServicedAppointments(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals ecp.EventCustomerId
                        where eventIds.Contains(ec.EventId)
                              && (
                              (!ea.CheckinTime.HasValue && !ea.CheckoutTime.HasValue && !ec.NoShow)
                              || (ec.NoShow && ecp.NetPayment > 0))
                        group ec by ec.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetNoShowAppointmentsForOpenOrder(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                        join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals ecp.EventCustomerId
                        where eventIds.Contains(ec.EventId)
                              && (ec.NoShow && ecp.NetPayment > 0)
                        group ec by ec.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetCancelledAppointmentsForOpenOrder(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join ecp in linqMetaData.EventCustomerPayment on ec.EventCustomerId equals ecp.EventCustomerId
                        where eventIds.Contains(ec.EventId)
                              && !ec.AppointmentId.HasValue
                              && ecp.NetPayment > 0
                        group ec by ec.EventId
                            into g
                            select new OrderedPair<long, int>(g.Key, g.Count())).ToArray();
            }
        }

        public Event CheckDuplicateEventCreationOnSameHost(long hostId, DateTime eventDate, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from e in linqMetaData.Events
                              join hed in linqMetaData.HostEventDetails on e.EventId equals hed.EventId
                              where e.IsActive && e.EventStatus == (int)EventStatus.Active
                                    && hed.HostId == hostId
                                    && e.EventDate.Date == eventDate.Date
                                    && e.EventId != eventId
                              select e
                             ).FirstOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map(entity);

            }
        }

        public bool CheckCustomerRegisteredForFutureEvent(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join e in linqMetaData.Events on ec.EventId equals e.EventId
                        where ec.CustomerId == customerId && ec.AppointmentId.HasValue
                              && e.EventDate >= DateTime.Now.Date
                        select ec.EventCustomerId).Any();

            }
        }

        public IEnumerable<Event> GetEventsForShippingRevenueSummary(int pageNumber, int pageSize, ShippingRevenueListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventIds = (from ec in linqMetaData.EventCustomers
                                join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals ecod.EventCustomerId
                                join sdod in linqMetaData.ShippingDetailOrderDetail on ecod.OrderDetailId equals sdod.OrderDetailId
                                join sd in linqMetaData.ShippingDetail on sdod.ShippingDetailId equals sd.ShippingDetailId
                                where ec.AppointmentId.HasValue && ecod.IsActive && sdod.IsActive
                                && sd.ActualPrice > 0
                                select ec.EventId);

                var query = (from e in linqMetaData.Events
                             where eventIds.Contains(e.EventId)
                                   && e.IsActive && e.EventStatus == (int)EventStatus.Active
                             select e);

                if (!filter.FromDate.HasValue && !filter.ToDate.HasValue && filter.PodId <= 0 && filter.EventId <= 0)
                {
                    filter.FromDate = DateTime.Now;
                    filter.ToDate = DateTime.Now;
                }

                if (filter.EventId > 0)
                {
                    query = query.Where(q => q.EventId == filter.EventId);
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
                                           where ep.PodId == filter.PodId && ep.IsActive
                                           select ep.EventId);

                        query = from q in query
                                where podEventIds.Contains(q.EventId)
                                select q;
                    }
                }

                query = from q in query
                        orderby q.EventDate, q.EventId
                        select q;

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        public static IQueryable<OrderedPair<EventsEntity, bool>> GetALLEventEntityQuerywithIsCorporateField(LinqMetaData linqMetaData)
        {
            return from e in linqMetaData.Events
                   join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId into queryableEvent
                   from qe in queryableEvent.DefaultIfEmpty()
                   select new OrderedPair<EventsEntity, bool>(e, (qe.AccountId > 0 ? true : false));
        }

        public bool CaptureSsn(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ehp in linqMetaData.EventHospitalPartner
                        where ehp.EventId == eventId
                        select ehp.CaptureSsn).SingleOrDefault();
            }
        }

        public List<OrderedPair<long, int>> GetCustomersWithAppointmentByHospitalFacilityId(long hospitalFacilityId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                        where ehf.HospitalFacilityId == hospitalFacilityId
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue && ec.HospitalFacilityId == hospitalFacilityId
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public List<OrderedPair<long, int>> GetAttendedCustomersByHospitalFacilityId(long hospitalFacilityId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                        where ehf.HospitalFacilityId == hospitalFacilityId
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue
                                                        && ec.HospitalFacilityId == hospitalFacilityId
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public IEnumerable<Event> GetEventsForHospitalFacility(int pageNumber, int pageSize, HospitalPartnerEventListModelFilter filter, out int totalRecords, int normalValidityPeriod = 0, int abnormalValidityPeriod = 0, int criticalValidityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
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

                var query = (from ehf in linqMetaData.EventHospitalFacility
                             join e in linqMetaData.Events on ehf.EventId equals e.EventId
                             where ehf.HospitalFacilityId == filter.HospitalFacilityId
                                   && e.EventStatus.HasValue
                                   && e.EventStatus.Value == (int)EventStatus.Active
                             select e);


                var resultQuery = (from ecr in linqMetaData.EventCustomerResult
                                   select ecr);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit || ecr.ResultState <= (int)NewTestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                IQueryable<long> eventFilterQuery = (from ecr in linqMetaData.EventCustomerResult
                                                     join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                                     join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                                     join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                                     where ec.PartnerRelease == (int)RegulatoryState.Signed && ec.HospitalFacilityId == filter.HospitalFacilityId
                                                         && ec.Hipaastatus == (int)RegulatoryState.Signed
                                                         && ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue
                                                         &&
                                                         (
                                                             (!ecr.ResultSummary.HasValue && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (maximumValidityPeriod > 0 ? e.EventDate.AddDays(maximumValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             (ecr.ResultSummary == (long)ResultInterpretation.Normal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (normalValidityPeriod > 0 ? e.EventDate.AddDays(normalValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             (ecr.ResultSummary == (long)ResultInterpretation.Abnormal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (abnormalValidityPeriod > 0 ? e.EventDate.AddDays(abnormalValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             (ecr.ResultSummary == (long)ResultInterpretation.Urgent && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                                 && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                             ||
                                                             ((ecr.ResultSummary == (long)ResultInterpretation.Critical || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId))
                                                                 && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                         )
                                                     select ecr.EventId);

                if (filter.EventId < 1 && (filter.ResultInterpretation > 0 || filter.CriticalMarkedByTechnician))
                {
                    eventFilterQuery = (from ecr in linqMetaData.EventCustomerResult
                                        join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                        where ec.PartnerRelease == (int)RegulatoryState.Signed && ec.HospitalFacilityId == filter.HospitalFacilityId
                                            && ec.Hipaastatus == (int)RegulatoryState.Signed
                                            && ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue
                                            && (filter.ResultInterpretation > 0 ? ecr.ResultSummary == filter.ResultInterpretation &&
                                                (
                                                    (ecr.ResultSummary == (long)ResultInterpretation.Normal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                        && (normalValidityPeriod > 0 ? e.EventDate.AddDays(normalValidityPeriod) >= DateTime.Now.Date : true))
                                                    ||
                                                    (ecr.ResultSummary == (long)ResultInterpretation.Abnormal && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                        && (abnormalValidityPeriod > 0 ? e.EventDate.AddDays(abnormalValidityPeriod) >= DateTime.Now.Date : true))
                                                    ||
                                                    (ecr.ResultSummary == (long)ResultInterpretation.Urgent && ((e.EventDate < _settings.ResultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                                             || (e.EventDate >= _settings.ResultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                                                        && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                    ||
                                                    ((ecr.ResultSummary == (long)ResultInterpretation.Critical)
                                                        && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                ) : true
                                            )
                                            && (filter.CriticalMarkedByTechnician ?
                                                    ((criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId))
                                                        && (criticalValidityPeriod > 0 ? e.EventDate.AddDays(criticalValidityPeriod) >= DateTime.Now.Date : true))
                                                : true
                                            )
                                        select ecr.EventId);

                }

                query = query.Where(q => eventFilterQuery.Contains(q.EventId));

                if (filter.EventId > 0)
                {
                    query = query.Where(q => q.EventId == filter.EventId);
                }
                else
                {
                    if (filter.FromDate.HasValue)
                        query = query.Where(a => a.EventDate >= filter.FromDate.Value);

                    if (filter.ToDate.HasValue)
                        query =
                            query.Where(
                                a => a.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));

                    if (filter.Status == (int)HospitalPartnerEventStatusFilter.Unprocessed)
                    {
                        query =
                            query.Where(
                                q =>
                                resultQuery.Where(rq => (q.EventDate < _settings.ResultFlowChangeDate && rq.ResultState == (int)TestResultStateNumber.PostAudit)
                                || (q.EventDate >= _settings.ResultFlowChangeDate && rq.ResultState == (int)NewTestResultStateNumber.PostAuditNew)).Select(
                                    rq => rq.EventId).Contains(q.EventId));
                    }
                    else if (filter.Status == (int)HospitalPartnerEventStatusFilter.Processed)
                    {
                        query =
                            query.Where(
                                q =>
                                resultQuery.Where(rq => (q.EventDate < _settings.ResultFlowChangeDate && rq.ResultState == (int)TestResultStateNumber.ResultDelivered)
                                    || (q.EventDate >= _settings.ResultFlowChangeDate && rq.ResultState == (int)NewTestResultStateNumber.ResultDelivered)).Select(
                                    rq => rq.EventId).Contains(q.EventId));
                    }

                }
                if (filter.FromDate.HasValue || filter.ToDate.HasValue)
                    query = query.OrderBy(q => q.EventDate).OrderBy(q => q.EventId);
                else
                    query = query.OrderByDescending(q => q.EventDate).OrderBy(q => q.EventId);

                totalRecords = query.Count();
                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).TakePage(pageNumber, pageSize).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public List<OrderedPair<long, int>> GetAttendedCustomersByEventIdsAndHospitalFacilityId(IEnumerable<long> eventIds, long hospitalFacilityId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        join ehf in linqMetaData.EventHospitalFacility on e.EventId equals ehf.EventId
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue && !ec.NoShow && ea.CheckinTime.HasValue
                                                        && ec.HospitalFacilityId == hospitalFacilityId
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public IEnumerable<Event> GetEventsForGenerateKynXml()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var events = (linqMetaData.Events.Where(e => e.IsActive && e.GenerateKynXml.HasValue && e.GenerateKynXml.Value == (long)GenerateKynXmlStatus.Generate)).ToList();

                return Mapper.MapMultiple(events);
            }
        }

        public void UpateGenerateXMLStatusField(long eventId, GenerateKynXmlStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new EventsEntity
                {
                    GenerateKynXml = (long)status,
                }, new RelationPredicateBucket(EventsFields.EventId == eventId));

            }
        }

        public IEnumerable<Event> GetEventsToSendSms(DateTime fromDate, DateTime toDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventsEntity> eventEntities =
                    linqMetaData.Events.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount).Prefetch(e => e.HostEventDetails)).Where(
                        e => e.EventDate >= fromDate.Date && e.EventDate <= toDate.Date && (e.EventStatus == (long)EventStatus.Active || (e.EventStatus == (long)EventStatus.Suspended && e.IsLocked)) && e.IsActive).ToList();

                if (!eventEntities.IsNullOrEmpty())
                    return Mapper.MapMultiple(eventEntities).ToList();
                return null;
            }
        }

        public IEnumerable<Event> GetEventForKynXml()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var cutofDate = DateTime.Now.AddDays(-CutOfDateForKynXmlinDays).Date;

                var events = (from e in linqMetaData.Events
                              join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                              where e.IsActive && e.EventStatus == (int)EventStatus.Active
                                && !e.GenerateKynXml.HasValue
                                && e.EventDate > cutofDate && e.EventDate < DateTime.Now.Date
                                && ep.IsActive && ep.EnableKynIntegration
                              select e).ToArray();

                return Mapper.MapMultiple(events);
            }
        }

        public IEnumerable<Event> GetEventsForStaff(EventSearchModelFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var events = (from e in linqMetaData.Events
                              where e.EventStatus == (int)EventStatus.Active && e.IsActive && e.EventDate >= filter.FromDate
                              select e);

                if (filter.EventId.HasValue && filter.EventId.Value > 0)
                {
                    events = (from e in events
                              where e.EventId == filter.EventId
                              select e);
                }

                if (filter.ToDate.HasValue)
                {
                    events = (from e in events
                              where e.EventDate <= filter.ToDate.Value
                              select e);
                }

                if (!string.IsNullOrEmpty(filter.City) || !string.IsNullOrEmpty(filter.State) || !string.IsNullOrEmpty(filter.Zip))
                {
                    var queryableAddress = (from p in linqMetaData.Prospects
                                            join a in linqMetaData.Address on p.AddressId equals a.AddressId
                                            select new { p.ProspectId, a.ZipId, a.StateId, a.CityId });

                    if (!string.IsNullOrEmpty(filter.Zip))
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.Zip);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            queryableAddress = from a in queryableAddress
                                               where zipIds.Contains(a.ZipId)
                                               select a;
                        }
                    }

                    if (!string.IsNullOrEmpty(filter.State))
                    {
                        queryableAddress = from a in queryableAddress
                                           join s in linqMetaData.State on a.StateId equals s.StateId
                                           where s.Name == filter.State
                                           select a;
                    }


                    if (!string.IsNullOrEmpty(filter.City))
                    {
                        queryableAddress = from a in queryableAddress
                                           join c in linqMetaData.City on a.CityId equals c.CityId
                                           where c.Name == filter.City
                                           select a;
                    }

                    var prospectIds = (from q in queryableAddress select q.ProspectId);

                    events = (from e in events
                              join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                              where prospectIds.Contains(eh.HostId)
                              select e);
                }

                if (!string.IsNullOrEmpty(filter.Pod))
                {
                    events = (from e in events
                              join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                              join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                              where ep.IsActive && p.Name.Contains(filter.Pod)
                              select e);
                }

                var query = from ep in linqMetaData.EventPod
                            join p in linqMetaData.PodDefaultTeam on ep.PodId equals p.PodId
                                into queryableDefStaff
                            from qds in queryableDefStaff.DefaultIfEmpty()
                            join esa in linqMetaData.EventStaffAssignment on ep.EventId equals esa.EventId
                                into queryableStaff
                            from qs in queryableStaff.DefaultIfEmpty()
                            where ep.IsActive
                            select
                                new
                                {
                                    ep.EventId,
                                    OrgRoleUserId = ((qs.ActualStaffOrgRoleUserId == null && qs.ScheduledStaffOrgRoleUserId == null)
                                            ? qds.OrgnizationRoleUserId
                                            : (qs.ActualStaffOrgRoleUserId ?? qs.ScheduledStaffOrgRoleUserId))
                                };

                events = from e in events
                         where query.Where(q => q.OrgRoleUserId == filter.StaffId).Select(q => q.EventId).Contains(e.EventId)
                         select e;


                return Mapper.MapMultiple(events.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount).Prefetch(e => e.EventPod)).OrderBy(e => e.EventDate).ToArray());
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEventStaffPairs(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from ep in linqMetaData.EventPod
                             join e in linqMetaData.Events on ep.EventId equals e.EventId
                             join p in linqMetaData.PodDefaultTeam on ep.PodId equals p.PodId
                                 into queryableDefStaff
                             from qds in queryableDefStaff.DefaultIfEmpty()
                             join esa in linqMetaData.EventStaffAssignment on ep.EventId equals esa.EventId
                                 into queryableStaff
                             from qs in queryableStaff.DefaultIfEmpty()
                             where ep.IsActive && (!eventIds.Any() || eventIds.Contains(e.EventId))
                             select
                                 new OrderedPair<long, long>
                                 {
                                     FirstValue = ep.EventId,
                                     SecondValue = ((qs.ActualStaffOrgRoleUserId == null && qs.ScheduledStaffOrgRoleUserId == null) ? qds.OrgnizationRoleUserId : (qs.ActualStaffOrgRoleUserId ?? qs.ScheduledStaffOrgRoleUserId))
                                 }).ToArray();

                return query;
            }
        }

        public Event GetEventByInvitationCode(string invitationCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var events = linqMetaData.Events.Where(e => e.IsActive && e.InvitationCode == invitationCode && e.EventTypeId == (long)RegistrationMode.Private && e.EventDate.Date >= DateTime.Today).ToList();

                return events.Any() ? Mapper.Map(events.First()) : null;
            }
        }

        public void UpdatePackageTrackingNumbers(long eventId, string bloodPackageTrackingNumber, string recordsPackageTrackingNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new EventsEntity
                {
                    BloodPackageTracking = bloodPackageTrackingNumber,
                    RecordsPackageTracking = recordsPackageTrackingNumber
                }, new RelationPredicateBucket(EventsFields.EventId == eventId));
            }
        }

        public IEnumerable<Event> GetEventsForCallQueue(FillEventsCallQueueFilter filter, long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId < 0)
                {
                    return null;
                }

                //var query = (from cqc in linqMetaData.CallQueueCustomer
                //             where cqc.CallQueueId == filter.CallQueueId && cqc.EventId.HasValue
                //             select cqc.EventId.Value);

                var query = (from cqc in linqMetaData.CallQueueCustomer
                             join sgcca in linqMetaData.SystemGeneratedCallQueueAssignment on cqc.CallQueueCustomerId equals sgcca.CallQueueCustomerId
                             where cqc.CallQueueId == filter.CallQueueId
                             && sgcca.CriteriaId == criteriaId
                             && cqc.EventId.HasValue
                             select cqc.EventId.Value);

                var queryable = (from e in linqMetaData.Events
                                 where e.IsActive && query.Contains(e.EventId) && e.EventDate.Date > DateTime.Now.Date && e.EnableForCallCenter
                                 select e);


                if (filter.EventId.HasValue)
                    queryable = (from e in queryable where e.EventId == filter.EventId.Value select e);

                if (!string.IsNullOrEmpty(filter.Pod))
                {
                    queryable = (from e in queryable
                                 join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                 join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                 where ep.IsActive && p.Name.Contains(filter.Pod)
                                 select e);
                }

                var entities = (from e in queryable select e)
                                .WithPath(prefetchPath =>
                                    prefetchPath.Prefetch(e => e.HostEventDetails)
                                        .Prefetch(e => e.EventAccount)
                                        .Prefetch(e => e.EventPod))
                                .OrderBy(e => e.EventDate)
                                .ToArray();

                return Mapper.MapMultiple(entities);
            }

        }

        public Event GetPreviousAttendedEvent(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from ec in linqMetaData.EventCustomers
                              join e in linqMetaData.Events on ec.EventId equals e.EventId
                              where ec.CustomerId == customerId && ec.AppointmentId.HasValue && (!ec.NoShow)
                              && ec.LeftWithoutScreeningReasonId == null
                              && e.EventDate.Date < DateTime.Now.Date
                              orderby e.EventDate descending
                              select e).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).FirstOrDefault();
                if (entity == null)
                    return null;

                return Mapper.Map(entity);
            }
        }

        public IEnumerable<Event> GetEventsForFillEventsCallQueue(DateTime dtDateTime)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                var entities = (from e in linqMetaData.Events
                                where e.IsActive
                                    && e.EventDate > DateTime.Today
                                    && e.EventDate <= dtDateTime
                                    && !corporateEventIds.Contains(e.EventId)
                                    && e.EventStatus.HasValue
                                    && e.EventStatus.Value == (int)EventStatus.Active
                                    && e.EventTypeId == (long)RegistrationMode.Public
                                select e).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Event> GetCancelledEvents(int pageNumber, int pageSize, EventCancellationModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<EventsEntity> entities;
                var query = (from e in linqMetaData.Events
                             where e.EventStatus == (int)EventStatus.Canceled && e.IsActive
                             select e).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails));

                if (filter == null)
                {
                    totalRecords = query.Count();
                    entities = query.OrderByDescending(e => e.EventDate).TakePage(pageNumber, pageSize).ToList();
                    return Mapper.MapMultiple(entities);
                }

                if (filter.EventId > 0)
                    query = (from e in query where e.EventId == filter.EventId select e);

                if (filter.FromDate.HasValue)
                    query = (from e in query where e.EventDate >= filter.FromDate.Value select e);

                if (filter.ToDate.HasValue)
                    query = (from e in query where e.EventDate <= filter.ToDate.Value select e);

                totalRecords = query.Count();
                entities = query.OrderByDescending(e => e.EventDate).TakePage(pageNumber, pageSize).ToList();
                return Mapper.MapMultiple(entities);
            }
        }

        public bool ValidateEventForAccount(long eventId, long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var count = (from ea in linqMetaData.EventAccount
                             where ea.AccountId == accountId && ea.EventId == eventId
                             select ea.EventId).Count();
                return count > 0;
            }
        }

        public IEnumerable<long> GetEventsToArchive(DateTime toTime, DateTime? fromTime)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventIds = (from e in linqMetaData.Events
                                where ((fromTime == null || e.EventDate > fromTime) && e.EventDate <= toTime)
                                select e.EventId).ToList();

                return eventIds;
            }
        }

        public IEnumerable<long> GetLockedEventIds()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventIds = (from e in linqMetaData.Events
                                where e.IsActive && e.IsLocked
                                select e.EventId).ToArray();
                return eventIds;
            }
        }

        public void UnlockLockedCorporateEvents()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                //mark event Active & unlocked for Suspended and locked
                var eventIds = (from e in linqMetaData.Events
                                where e.IsActive && e.IsLocked &&
                                      e.EventDate.Date == DateTime.Today.AddDays(1)
                                      && e.EventStatus.HasValue && e.EventStatus.Value == ((int?)EventStatus.Suspended)
                                select e.EventId).ToArray();

                if (eventIds.Any())
                    adapter.UpdateEntitiesDirectly(new EventsEntity { IsLocked = false, EventStatus = (int?)EventStatus.Active }, new RelationPredicateBucket(EventsFields.EventId == eventIds));

                //mark event unlock for locked
                eventIds = (from e in linqMetaData.Events
                            where e.IsActive && e.IsLocked && e.EventDate.Date == DateTime.Now.Date
                            select e.EventId).ToArray();

                if (eventIds.Any())
                    adapter.UpdateEntitiesDirectly(new EventsEntity { IsLocked = false }, new RelationPredicateBucket(EventsFields.EventId == eventIds));

            }
        }

        public IEnumerable<long> LockCorporateEvents(long accountId, DateTime eventDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var eventIds = (from e in linqMetaData.Events
                                join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                                where ea.AccountId == accountId && e.IsActive && e.EventStatus == (long)EventStatus.Active
                                      && e.EventDate == eventDate
                                select e.EventId).ToArray();
                if (eventIds.Any())
                {
                    adapter.UpdateEntitiesDirectly(new EventsEntity { IsLocked = true, EventStatus = (int?)EventStatus.Suspended }, new RelationPredicateBucket(EventsFields.EventId == eventIds));
                }

                return eventIds;
            }
        }

        public IEnumerable<Event> GetEventsForHealthPlanFillEventsCallQueue(DateTime dtDateTime, long healthPlanId, bool eventForNonMammoPatient)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == healthPlanId select ea.EventId);

                var query = (from e in linqMetaData.Events
                             where e.IsActive
                                   && e.EventDate > DateTime.Today
                                   && e.EventDate <= dtDateTime
                                   && corporateEventIds.Contains(e.EventId)
                                   && e.EventStatus.HasValue
                                   && e.EventStatus.Value == (int)EventStatus.Active
                             select e);

                if (eventForNonMammoPatient)
                {
                    var mammoEvent = (from et in linqMetaData.EventTest
                                      where et.TestId == (long)TestType.Mammogram
                                      select et.EventId);

                    query = query.Where(x => x.AllowNonMammoPatients || !mammoEvent.Contains(x.EventId));
                }

                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Event> GetHealthPlanEventsForCallQueue(FillEventsCallQueueFilter filter, long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId < 0)
                {
                    return null;
                }

                var eventIds = (from e in linqMetaData.EventAccount where e.AccountId == filter.HealthPlanId select e.EventId);
                var queryable = (from e in linqMetaData.Events
                                 join ept in linqMetaData.EventProductType on e.EventId equals ept.EventId
                                 join hpfecqe in linqMetaData.HealthPlanFillEventCallQueue on e.EventId equals hpfecqe.EventId
                                 where e.IsActive && e.EventDate.Date > DateTime.Now.Date && e.EnableForCallCenter
                                 && e.EventStatus == (long)EventStatus.Active
                                 && eventIds.Contains(e.EventId)
                                 && hpfecqe.CriteriaId == criteriaId
                                 && ept.IsActive
                                 select e);

                if (filter.EventId.HasValue)
                    queryable = (from e in queryable where e.EventId == filter.EventId.Value select e);

                if (!string.IsNullOrEmpty(filter.Pod))
                {
                    queryable = (from e in queryable
                                 join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                 join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                 where ep.IsActive && p.Name.Contains(filter.Pod)
                                 select e);
                }

                var entities = (from e in queryable select e)
                                .WithPath(prefetchPath =>
                                    prefetchPath.Prefetch(e => e.HostEventDetails)
                                        .Prefetch(e => e.EventAccount)
                                        .Prefetch(e => e.EventPod))
                                .OrderBy(e => e.EventDate)
                                .ToArray();

                return Mapper.MapMultiple(entities);
            }

        }

        public List<Event> GetEventsByFiltersForCallQueue(EventSearchFilterCallQueueCustomer filter)
        {
            //var zipCodesInRange = !string.IsNullOrEmpty(filter.ZipCode) && filter.Radius.HasValue
            //                          ? _zipCodeRepository.GetZipCodesInRadius(filter.ZipCode, filter.Radius.Value)
            //                          : null;
            //var zipIdsInRange = zipCodesInRange != null ? zipCodesInRange.Select(zcir => zcir.Id).ToList() : null;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var filtered = false;
                //IQueryable<AddressEntity> queryableAddress = from a in linqMetaData.Address select a;

                var queryableAddress = (from p in linqMetaData.Prospects
                                        join a in linqMetaData.Address on p.AddressId equals a.AddressId
                                        select new { p.ProspectId, a.ZipId, a.StateId, a.CityId });

                //if (!(zipIdsInRange == null || zipIdsInRange.IsEmpty()))
                //{
                //    var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                //    if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                //    linqMetaData.CustomFunctionMappings.Add(mapping);
                //    mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                //    linqMetaData.CustomFunctionMappings.Add(mapping);

                //    string zipIdstring = "," + string.Join(",", zipIdsInRange) + ",";
                //    queryableAddress = from a in queryableAddress
                //                       where IndexOf(Convert.ToString(a.ZipId), zipIdstring) > 0
                //                       select a;

                //    filtered = true;
                //}
                if (filter.ZipCodeId > 0 && filter.Radius > 0)
                {
                    var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                             where zrd.SourceZipId == filter.ZipCodeId && zrd.Radius <= filter.Radius
                                             select zrd.DestinationZipId);

                    queryableAddress = from a in queryableAddress
                                       where zipRadiusDistance.Contains(a.ZipId)
                                       select a;
                    filtered = true;
                }
                else if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                    if (zipCodes != null && zipCodes.Any())
                    {
                        var zipIds = zipCodes.Select(z => z.Id).ToArray();
                        queryableAddress = from a in queryableAddress
                                           where zipIds.Contains(a.ZipId)
                                           select a;
                        filtered = true;
                    }
                }

                if (!string.IsNullOrEmpty(filter.State))
                {
                    queryableAddress = from a in queryableAddress
                                       join s in linqMetaData.State on a.StateId equals s.StateId
                                       where s.Name == filter.State
                                       select a;
                    filtered = true;
                }


                if (!string.IsNullOrEmpty(filter.City))
                {
                    queryableAddress = from a in queryableAddress
                                       join c in linqMetaData.City on a.CityId equals c.CityId
                                       where c.Name == filter.City
                                       select a;
                    filtered = true;
                }
                long productTypeId = 0;
                var queryablEvents = from e in linqMetaData.Events
                                                      where e.EnableForCallCenter
                                                      select e; ;
                if (filter.CustomerId > 0)
                {
                    var productType = (from cp in linqMetaData.CustomerProfile
                                       where cp.CustomerId == filter.CustomerId
                                       select cp).FirstOrDefault();
                    productTypeId = productType != null && productType.ProductTypeId.HasValue ? productType.ProductTypeId.Value : 0;
                }
                if (productTypeId > 0)
                {
                     queryablEvents = from e in linqMetaData.Events
                                         join ept in linqMetaData.EventProductType on e.EventId equals ept.EventId
                                         where ept.ProductTypeId == productTypeId && ept.IsActive && e.EnableForCallCenter
                                         select e;
                }
               


                if (filter.ExcludeCorporateEvents)
                {
                    var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);
                    queryablEvents = from e in queryablEvents where !corporateEventIds.Contains(e.EventId) select e;
                }

                var eventAccountQuery = (from ea in linqMetaData.EventAccount select ea);

                if (filter.AgentOrganizationId > 0)
                {
                    var assignedAccountIds = (from acco in linqMetaData.AccountCallCenterOrganization
                                              where acco.OrganizationId == filter.AgentOrganizationId && acco.IsDeleted == false
                                              select acco.AccountId);

                    var accountIds = (from a in linqMetaData.Account where (a.RestrictHealthPlanData == false || assignedAccountIds.Contains(a.AccountId)) select a.AccountId);

                    eventAccountQuery = (from ea in linqMetaData.EventAccount where (accountIds.Contains(ea.AccountId)) select ea);
                }

                if (filter.HealthPlanId > 0)
                {
                    var corporateEventIds = (from ea in eventAccountQuery where ea.AccountId == filter.HealthPlanId select ea.EventId);
                    queryablEvents = from e in queryablEvents where corporateEventIds.Contains(e.EventId) select e;
                }
                else if (filter.AgentOrganizationId > 0)
                {
                    var corporateEventIds = (from ea in eventAccountQuery select ea.EventId);
                    queryablEvents = from e in queryablEvents where corporateEventIds.Contains(e.EventId) select e;
                }

                if (filter.SearchMammoEvents && !filter.SearchAllEvents)
                {
                    queryablEvents = (from e in queryablEvents
                                      join et in linqMetaData.EventTest on e.EventId equals et.EventId
                                      where TestGroup.BreastCancer.Contains(et.TestId)
                                      select e);

                }
                else if (!filter.SearchMammoEvents && !filter.SearchAllEvents)
                {
                    var eventWithMammo = (from et in linqMetaData.EventTest where TestGroup.BreastCancer.Contains(et.TestId) select et.EventId);

                    queryablEvents = (from e in queryablEvents
                                      where e.AllowNonMammoPatients == true || !eventWithMammo.Contains(e.EventId)
                                      select e);

                }


                IEnumerable<EventsEntity> events = null;

                if (filtered)
                {
                    var prospectIds = (from q in queryableAddress select q.ProspectId);

                    events = (from e in queryablEvents
                              join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                              where prospectIds.Contains(eh.HostId) && (filter.ShowFutureEvents ? e.EventDate > DateTime.Today : e.EventDate > DateTime.Today.AddDays(-1)) && e.EventStatus == (int)EventStatus.Active && e.IsActive
                              select e).WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod)).ToArray();//.TakePage(pageNumber, pageSize)
                }
                else
                {
                    events = (from e in queryablEvents
                              join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                              where (filter.ShowFutureEvents ? e.EventDate > DateTime.Today : e.EventDate > DateTime.Today.AddDays(-1)) && e.EventStatus == (int)EventStatus.Active && e.IsActive
                              select e).WithPath(prefetchPath => prefetchPath.Prefetch(p => p.HostEventDetails).Prefetch(p => p.EventPod)).ToArray();//.TakePage(pageNumber, pageSize)
                }

                return Mapper.MapMultiple(events).ToList();

            }
        }

        public List<Event> GetHealthPlanEvents(int pageNumber, int pageSize, ClientEventVolumeListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var accountIdsQuery = (from a in linqMetaData.Account where a.IsHealthPlan select a.AccountId);

                List<EventsEntity> eventEntities;
                if (filter.IsEmpty())
                {
                    var query =
                        (from e in linqMetaData.Events
                         join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                         where e.EventStatus.HasValue
                            && (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                            && accountIdsQuery.Contains(ea.AccountId)
                         select e).OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount)).TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                    string vehicle = "";
                    vehicle = string.IsNullOrEmpty(filter.Vehicle) ? "" : filter.Vehicle;

                    if (filter.Sponsers.HasValue && filter.Sponsers.Value > 0)
                    {
                        accountIdsQuery = (from a in linqMetaData.Account where a.AccountId == filter.Sponsers.Value && a.IsHealthPlan select a.AccountId);
                    }

                    var query = (from e in linqMetaData.Events
                                 join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                 join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                 join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                                 where e.EventStatus.HasValue
                                       && (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                                       && ep.IsActive
                                       && (filter.FromDate != null ? fromDate <= e.EventDate : true)
                                       && (filter.ToDate != null ? toDate >= e.EventDate : true)
                                       && accountIdsQuery.Contains(ea.AccountId)
                                         && (p.Name.Contains(vehicle))
                                 select e).Distinct().OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    totalRecords = query.Count();
                    eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount)).TakePage(pageNumber, pageSize).ToList();
                }

                if (!eventEntities.IsNullOrEmpty()) return Mapper.MapMultiple(eventEntities).ToList();
                return null;
            }
        }

        public IEnumerable<Event> GetEventsforDailyVolumeReport(int pageNumber, int pageSize, DailyVolumeListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                List<EventsEntity> eventEntities;

                filter = filter ?? new DailyVolumeListModelFilter();

                filter.FromDate = filter.FromDate ?? DateTime.Today.AddDays(-1);
                filter.ToDate = filter.ToDate ?? DateTime.Today.AddDays(-1);

                var fromDate = filter.FromDate.Value;
                var toDate = filter.ToDate.Value;

                var pod = string.IsNullOrEmpty(filter.Pod) ? "" : filter.Pod;

                var query = (from e in linqMetaData.Events
                             join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                             join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                             where e.EventStatus.HasValue
                                   && (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                                   && ep.IsActive
                                   && (filter.FromDate != null ? fromDate <= e.EventDate : true)
                                   && (filter.ToDate != null ? toDate >= e.EventDate : true)
                                   && (p.Name.Contains(pod))
                             select e);

                if (filter.HealthPlanId > 0)
                {
                    var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);
                    query = (from q in query where eventIds.Contains(q.EventId) select q);
                }
                else if (filter.IsRetailEvent && !filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                {
                    var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

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

                    var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

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

                query = (from q in query
                         orderby q.EventDate descending
                         orderby q.EventId
                         select q);

                totalRecords = query.Count();
                eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).TakePage(pageNumber, pageSize).ToList();


                if (!eventEntities.IsNullOrEmpty())
                    return Mapper.MapMultiple(eventEntities).ToList();

                return null;
            }
        }

        public List<OrderedPair<long, int>> GetCustomersCancelledOnDayOfEvent(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        join eacl in linqMetaData.EventAppointmentCancellationLog
                                                           on ec.EventCustomerId equals eacl.EventCustomerId
                                                        where ec.EventId == e.EventId && ec.AppointmentId == null && eacl.DateCreated >= e.EventDate.Date
                                                        select ec.EventCustomerId).Distinct().Count())).ToList();
            }
        }

        public bool IsCustomerRegisterForCurrentEvent(long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var previousEvent = (from ec in linqMetaData.EventCustomers
                                     join e in linqMetaData.Events on ec.EventId equals e.EventId
                                     where ec.CustomerId == customerId && ec.AppointmentId.HasValue && (!ec.NoShow)
                                     && !ec.LeftWithoutScreeningReasonId.HasValue
                                     && e.EventDate.Date < DateTime.Now.Date
                                     orderby e.EventDate descending
                                     select e).FirstOrDefault();

                if (previousEvent == null) return false;

                var newEvent = (from e in linqMetaData.Events
                                where e.EventId == eventId
                                select e).First();

                if (previousEvent.EventDate.Year == newEvent.EventDate.Year) return true;

                return false;
            }
        }

        public List<OrderedPair<long, int>> GetLeftWithoutScreeningCustomers(IEnumerable<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && ec.AppointmentId.HasValue && ec.LeftWithoutScreeningReasonId.HasValue
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public IEnumerable<Event> GetEventListByHealthPlanId(int pageNumber, int pageSize, HealthPlanRevenueEventModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var fromDate = filter.DateFrom ?? DateTime.Today;
                var toDate = filter.DateTo ?? DateTime.Today;
                var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);

                var query = (from e in linqMetaData.Events
                             where e.IsActive && e.EventStatus.HasValue && e.EventStatus.Value == (int)EventStatus.Active && e.EventDate >= fromDate && e.EventDate < toDate && eventIds.Contains(e.EventId)
                             select e);

                totalRecords = query.Count();

                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).OrderByDescending(e => e.EventDate).TakePage(pageNumber, pageSize).ToList();

                return Mapper.MapMultiple(entities);
            }
        }

        public List<Event> GetUpcomingHealthPlanEvents(int pageNumber, int pageSize, long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var fromDate = DateTime.Now.Date;

                var query = (from e in linqMetaData.Events
                             join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                             join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                             where e.EventStatus.HasValue
                                   && (e.EventStatus.Value == (int)EventStatus.Active)
                                   && ep.IsActive
                                   && fromDate <= e.EventDate
                                   && ea.AccountId == accountId
                             select e).OrderBy(e => e.EventDate).OrderBy(e => e.EventId);

                var eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod).Prefetch(e => e.EventAccount)).TakePage(pageNumber, pageSize).ToList();

                return !eventEntities.IsNullOrEmpty() ? Mapper.MapMultiple(eventEntities).ToList() : null;
            }
        }

        public IEnumerable<Event> GetEvents(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from e in linqMetaData.Events where eventIds.Contains(e.EventId) select e);

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<long> GetForAddNotes(AddNotesModelFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from e in linqMetaData.Events
                             select e);

                if (filter != null)
                {
                    if (filter.HealthPlanId > 0)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == filter.HealthPlanId select ea.EventId);
                        query = (from q in query where eventIds.Contains(q.EventId) select q);
                    }
                    if (filter.EventDateFrom.HasValue)
                    {
                        query = (from q in query where q.EventDate >= filter.EventDateFrom.Value select q);
                    }
                    if (filter.EventDateTo.HasValue)
                    {
                        query = (from q in query where q.EventDate <= filter.EventDateTo.Value select q);
                    }
                    if (filter.PodId > 0)
                    {
                        query = (from q in query
                                 join ep in linqMetaData.EventPod on q.EventId equals ep.EventId
                                 join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                 where p.PodId == filter.PodId
                                 select q);
                    }
                }

                return query.OrderBy(x => x.EventDate).Select(x => x.EventId).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, int>> GetGcIssuedCountByEventIds(List<long> eventIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from e in linqMetaData.Events
                        where eventIds.Contains(e.EventId)
                        select new OrderedPair<long, int>(e.EventId,
                                                       (from ec in linqMetaData.EventCustomers
                                                        where ec.EventId == e.EventId && (ec.IsGiftCertificateDelivered.HasValue && ec.IsGiftCertificateDelivered.Value == true)
                                                        select ec.EventId).Count())).ToList();
            }
        }

        public IEnumerable<Event> GetActiveEvents(EventsDateRangeType duration)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from e in linqMetaData.Events where e.IsActive && e.EventStatus == (long)EventStatus.Active select e).
                                WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount).Prefetch(e => e.EventPod));
                if (duration == EventsDateRangeType.Today)
                {
                    entities = entities.Where(x => x.EventDate == DateTime.Now.Date);
                }
                else if (duration == EventsDateRangeType.ThisWeek)
                {
                    entities = entities.Where(x => x.EventDate >= DateTime.Now.Date && x.EventDate <= DateTime.Now.Date.AddDays(6));
                }
                else if (duration == EventsDateRangeType.ThisMonth)
                {
                    entities = entities.Where(x => x.EventDate >= DateTime.Now.Date && x.EventDate <= DateTime.Now.Date.AddDays(29));
                }
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<long> GetEventIdsByAccountIdAndDate(long accountId, DateTime fromDate, DateTime? toDate = null, bool getActiveEventsOnly = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from e in linqMetaData.Events
                             join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                             where ea.AccountId == accountId
                             && (e.EventDate >= fromDate)
                             select e);

                if (getActiveEventsOnly)
                {
                    query = (from q in query
                             where q.EventStatus == (int)EventStatus.Active
                             select q);
                }

                if (toDate != null)
                {
                    query = (from q in query
                             where q.EventDate <= toDate
                             select q);
                }

                return query.Select(x => x.EventId).ToArray();
            }
        }

        public IEnumerable<Event> GetEventForHkynXml()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var cutofDate = DateTime.Now.AddDays(-CutOfDateForKynXmlinDays).Date;

                var events = (from e in linqMetaData.Events
                              join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                              where e.IsActive && e.EventStatus == (int)EventStatus.Active
                                && !e.GenerateHkynXml.HasValue
                                && e.EventDate > cutofDate && e.EventDate >= _settings.HkynGenerationDate && e.EventDate < DateTime.Now.Date.AddDays(1)
                                && ep.IsActive && ep.EnableKynIntegration
                              select e).ToArray();

                return Mapper.MapMultiple(events);
            }
        }

        public IEnumerable<Event> GetEventsForGenerateHkynXml()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var events = (linqMetaData.Events.Where(e => e.IsActive && e.GenerateHkynXml.HasValue && e.GenerateHkynXml.Value == (long)GenerateKynXmlStatus.Generate)).ToList();

                return Mapper.MapMultiple(events);
            }
        }

        public void UpateGeneratehkynXmlStatusField(long eventId, GenerateKynXmlStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new EventsEntity
                {
                    GenerateHkynXml = (long)status,
                }, new RelationPredicateBucket(EventsFields.EventId == eventId));

            }
        }

        public List<long> GetEventsByTag(DateTime onDate, string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var queryablEvents = from e in linqMetaData.Events where e.EventDate == onDate select e;
                if (!string.IsNullOrEmpty(tag))
                {
                    var account = !string.IsNullOrEmpty(tag) ? (from a in linqMetaData.Account where a.Tag == tag select a).SingleOrDefault() : null;
                    queryablEvents = (from e in queryablEvents
                                      join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                                      where (account == null || ea.AccountId == account.AccountId)
                                      select e);
                }
                return (from e in queryablEvents select e.EventId).ToList();
            }
        }

        public IEnumerable<Event> GetEventsForGenerateMyBioCheckAssessment()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var events = (linqMetaData.Events.Where(e => e.IsActive && e.GenerateMyBioCheckAssessment.HasValue && e.GenerateMyBioCheckAssessment.Value == (long)GenerateKynXmlStatus.Generate)).ToList();

                return Mapper.MapMultiple(events);
            }
        }

        public IEnumerable<Event> GetEventForMyBioCheckAssessment()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var cutofDate = DateTime.Now.AddDays(-CutOfDateForKynXmlinDays).Date;

                var events = (from e in linqMetaData.Events
                              join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                              where e.IsActive && e.EventStatus == (int)EventStatus.Active
                                && !e.GenerateMyBioCheckAssessment.HasValue
                                && e.EventDate > cutofDate && e.EventDate >= _settings.NewHkynEventDate && e.EventDate < DateTime.Now.Date.AddDays(1)
                                && ep.IsActive && ep.EnableKynIntegration
                              select e).ToArray();

                return Mapper.MapMultiple(events);
            }
        }

        public void UpateGenerateMyBioCheckStatusField(long eventId, GenerateKynXmlStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new EventsEntity
                {
                    GenerateMyBioCheckAssessment = (long)status,
                }, new RelationPredicateBucket(EventsFields.EventId == eventId));

            }
        }

        public List<Event> GetActiveHealthPlanEventsForGmsEventList(EventListGmsModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var accountIdsQuery = (from a in linqMetaData.Account where a.IsHealthPlan && (!filter.HealthPlanIds.Any() || filter.HealthPlanIds.Contains(a.AccountId)) select a.AccountId);

                var query = (from e in linqMetaData.Events
                             join ea in linqMetaData.EventAccount
                                 on e.EventId equals ea.EventId
                             where
                                 e.IsActive
                                 && e.EventStatus != null
                                 && e.EventStatus == (long)EventStatus.Active
                                 && e.EventDate >= filter.FromDate
                                 && accountIdsQuery.Contains(ea.AccountId)
                             select e).Distinct();

                totalRecords = query.Count();

                var entities = query.TakePage(pageNumber, pageSize).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount)).ToList();
                if (!entities.IsNullOrEmpty()) return Mapper.MapMultiple(entities).ToList();
                return null;
            }
        }

        public IEnumerable<Event> GetFutureEventsForHealthPlan(long healthPlanId, DateTime fromDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var healthPlanEventIds = (from ea in linqMetaData.EventAccount where ea.AccountId == healthPlanId select ea.EventId);

                var entities = (from e in linqMetaData.Events
                                where e.EventDate >= fromDate
                                      && e.EventStatus.HasValue
                                      && e.EventStatus.Value == (int)EventStatus.Active
                                      && healthPlanEventIds.Contains(e.EventId)
                                select e).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount));

                return !entities.IsNullOrEmpty() ? Mapper.MapMultiple(entities) : null;
            }
        }

        public IEnumerable<long> GetEventStateByAccountId(EventScheduleListModelFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                var stateId = (from e in linqMetaData.Events
                               join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                               join host in linqMetaData.HostEventDetails on e.EventId equals host.EventId
                               join p in linqMetaData.Prospects on host.HostId equals p.ProspectId
                               join a in linqMetaData.Address on p.AddressId equals a.AddressId

                               where
                                e.EventStatus.HasValue
                                       &&
                                       (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)
                                       && (fromDate <= e.EventDate)
                                       && (toDate >= e.EventDate)
                                       && (ea.AccountId == filter.AccountId)
                               select a.StateId).Distinct().ToArray();
                return stateId;
            }
        }

        public IEnumerable<Event> GetEventScheduleListModel(int pageNumber, int pageSize, EventScheduleListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (!filter.IsEmpty())
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value : DateTime.Now;

                    var query = (from e in linqMetaData.Events
                                 join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                                 join host in linqMetaData.HostEventDetails on e.EventId equals host.EventId
                                 join p in linqMetaData.Prospects on host.HostId equals p.ProspectId
                                 join a in linqMetaData.Address on p.AddressId equals a.AddressId
                                 where e.EventStatus.HasValue
                                       &&
                                       (e.EventStatus.Value == (int)EventStatus.Active || e.EventStatus.Value == (int)EventStatus.Suspended)

                                       && (fromDate <= e.EventDate)
                                       && (toDate >= e.EventDate)
                                       && (ea.AccountId == filter.AccountId)
                                       && a.StateId == filter.StateId
                                 select e).Distinct().OrderBy(e => e.EventDate).OrderBy(e => e.EventId);

                    totalRecords = query.Count();
                    var eventEntities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventPod)).TakePage(pageNumber, pageSize).ToList();
                    if (!eventEntities.IsNullOrEmpty()) return Mapper.MapMultiple(eventEntities).ToList();
                }

                totalRecords = 0;
                return null;
            }
        }

        public Event GetEventWithEventTypeAndHostEventById(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                EventsEntity eventEntitys = linqMetaData.Events.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.EventAccount).Prefetch(e => e.HostEventDetails)).Where(e => e.EventId == eventId).SingleOrDefault();

                return Mapper.Map(eventEntitys);

            }
        }

        public Event GetEventOnlyById(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                EventsEntity eventEntity = linqMetaData.Events.SingleOrDefault(e => e.EventId == eventId);

                return Mapper.Map(eventEntity);

            }
        }

        public IEnumerable<Event> GetEventsByIdsWithHostDetails(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from e in linqMetaData.Events where eventIds.Contains(e.EventId) select e).WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Event> GetEventsByIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from e in linqMetaData.Events where e.IsActive && (e.EventStatus != (long)EventStatus.Canceled) && eventIds.Contains(e.EventId) select e).
                                WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails).Prefetch(e => e.EventAccount).Prefetch(e => e.EventPod)).ToArray();
                return Mapper.MapMultiple(entities);
            }
        }

        public void SetGenrateHealthAssesmentFormStatus(long eventId, bool isFormGenerated, long generateHealthAssesmentFormStatus)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new EventsEntity { GenerateHealthAssesmentForm = isFormGenerated, GenerateHealthAssesmentFormStatus = generateHealthAssesmentFormStatus }, new RelationPredicateBucket(EventsFields.EventId == eventId));
            }
        }

        public IEnumerable<Event> GetEventsforGenerateHealthAssesmentForm()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.Events.Where(e => e.GenerateHealthAssesmentForm).Select(e => e).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Event> GetEventByEventDateAndPod(DateTime eventDate, string pod)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from e in linqMetaData.Events
                                join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                where e.EventDate == eventDate && p.Name == pod && e.IsActive && ep.IsActive
                                select e).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Event> GetEventsByAccountIdAndDate(long accountId, DateTime fromDate, DateTime? toDate = null, bool getActiveEventsOnly = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from e in linqMetaData.Events
                             join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                             where ea.AccountId == accountId
                             && (e.EventDate >= fromDate)
                             select e);

                if (getActiveEventsOnly)
                {
                    query = (from q in query
                             where q.EventStatus == (int)EventStatus.Active
                             select q);
                }

                if (toDate != null)
                {
                    query = (from q in query
                             where q.EventDate <= toDate
                             select q);
                }

                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public bool IsEventHasNewResultFlow(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventData = (from e in linqMetaData.Events
                                 where e.EventId == eventId && e.EventDate >= _settings.ResultFlowChangeDate
                                 select e).SingleOrDefault();
                return eventData != null;
            }
        }

        public bool IsHealthPlanEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventData = (from e in linqMetaData.Events
                                 join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                                 join a in linqMetaData.Account on ea.AccountId equals a.AccountId
                                 where a.IsHealthPlan == true && e.EventId == eventId
                                 select e).SingleOrDefault();
                return eventData != null;
            }
        }
        public IEnumerable<Event> GetEventsFutureDate(DateTime fromDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from e in linqMetaData.Events
                             join ea in linqMetaData.EventAccount on e.EventId equals ea.EventId
                             //join ept in linqMetaData.EventProductType on e.EventId equals ept.EventId
                             where (e.EventDate >= fromDate) && e.EventStatus == (int)EventStatus.Active
                             select e);



                var entities = query.WithPath(prefetchPath => prefetchPath.Prefetch(e => e.HostEventDetails)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }
    }
}