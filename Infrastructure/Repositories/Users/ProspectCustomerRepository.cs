using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.Web.Infrastructure.Marketing.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    [DefaultImplementation]
    public class ProspectCustomerRepository : UniqueItemRepository<ProspectCustomer, ProspectCustomerEntity>, IProspectCustomerRepository
    {
        private readonly IZipCodeRepository _zipcodeRepository;
        private readonly ITempCartRepository _tempCartRepository;
        private readonly IStateRepository _stateRepository;
        public ProspectCustomerRepository()
            : this(new ProspectCustomerMapper(), new ZipCodeRepository(), new TempCartRepository(), new StateRepository())
        { }

        public ProspectCustomerRepository(IMapper<ProspectCustomer, ProspectCustomerEntity> mapper, IZipCodeRepository zipCodeRepository, ITempCartRepository tempCartRepository, IStateRepository stateRepository)
            : base(mapper)
        {
            _zipcodeRepository = zipCodeRepository;
            _tempCartRepository = tempCartRepository;
            _stateRepository = stateRepository;
        }

        protected override EntityField2 EntityIdField
        {
            get { return ProspectCustomerFields.ProspectCustomerId; }
        }


        public ProspectCustomer GetProspectCustomer(long prospectCustomerId)
        {
            ProspectCustomerEntity entity;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                entity = linqMetaData.ProspectCustomer.Where(pc => pc.ProspectCustomerId == prospectCustomerId).First();
            }

            if (entity == null)
            {
                return null;
            }

            return Mapper.Map(entity);
        }

        public List<ProspectCustomer> GetProspectCustomers(long[] prospectCustomerIds)
        {
            var entities = new EntityCollection<ProspectCustomerEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(ProspectCustomerFields.ProspectCustomerId == prospectCustomerIds);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entities, bucket);
            }

            return Mapper.MapMultiple(entities).ToList();
        }

        public bool IsConvertedandRegistered(long prospectCustomerId, long eventId)
        {
            var prospectCustomerEntity = GetProspectCustomer(prospectCustomerId);

            if (prospectCustomerEntity.CustomerId == null || prospectCustomerEntity.CustomerId.Value < 1)
                return false;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var listEventCustomer =
                    linqMetaData.EventCustomers.Where(
                        eventCustomer =>
                        eventCustomer.CustomerId == prospectCustomerEntity.CustomerId
                        && eventCustomer.EventId == eventId
                        && eventCustomer.AppointmentId.HasValue).ToList();

                return listEventCustomer.Count > 0;
            }
        }

        public bool UpdateProspectCustomerConversionState(ProspectCustomerConversionStatus conversionStatus, long prospectCustomerId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var prospectCustomerEntity = new ProspectCustomerEntity(prospectCustomerId) { Status = (long)conversionStatus };

                var bucket = new RelationPredicateBucket(ProspectCustomerFields.ProspectCustomerId == prospectCustomerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(prospectCustomerEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        // TODO: To move from here, to be kept into a service when Domain for Call, Notification will be prepared
        // TODO: SRE
        public List<ProspectCustomerViewData> GetProspectCustomersForSalesRep(DateTime? startDate, DateTime? endDate,
                string prospectName, long eventId, string sourceCode, string welnessSeminarName,
                ProspectCustomerConversionStatus? prospectCustomerConversionStatus,
                long salesRepId, int pageNumber, int pageSize, out long totalRecord)
        {
            //TODO: Need to do it with proper repository and factory and service,extension.
            var hscProspectCustomerViewDataList = new List<ProspectCustomerViewData>();

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                //TODO: SRE
                var eventsEntity = linqMetaData.Events.Where(
                    eventEntity => eventEntity.AssignedToOrgRoleUserId == salesRepId && eventEntity.IsActive).
                Join(linqMetaData.Seminars.Where(seminar => seminar.IsActive),
                     eventEntity => eventEntity.EventId,
                     seminar => seminar.EventId,
                     (eventEntity, seminar) =>
                     new
                     {
                         eventEntity.EventId,
                         seminar.SeminarId,
                         eventEntity.EventName,
                         seminar.Name
                     }).ToList();

                if (eventId > 0)
                {
                    eventsEntity = eventsEntity.Where(events => events.EventId == eventId).ToList();
                }

                if (!string.IsNullOrEmpty(welnessSeminarName))
                {
                    eventsEntity = eventsEntity.Where(events => events.Name.ToLower().Contains(welnessSeminarName.ToLower())).ToList();
                }

                var eventSeminarIds =
                    eventsEntity.Select(events => new OrderedPair<long, long>(events.EventId, events.SeminarId)).ToList();

                var listSeminarId =
                    eventSeminarIds.Select(eventSeminarId => eventSeminarId.SecondValue).ToList();


                var seminarSourceCodeId = linqMetaData.SeminarCampaignDetails.Join(linqMetaData.Afcampaign,
                                                                                   seminarCampaign =>
                                                                                   seminarCampaign.CampaignId,
                                                                                   afCampaign => afCampaign.CampaignId,
                                                                                   (seminarCampaign, afCampaign) =>
                                                                                   new OrderedPair<long, long>(
                                                                                       seminarCampaign.SeminarId,
                                                                                       afCampaign.PromoCodeId)
                    ).Where(seminarCouponPair => listSeminarId.Contains(seminarCouponPair.FirstValue)).ToList();

                var listSourceCode =
                    seminarSourceCodeId.Select(seminarSourceCode => seminarSourceCode.SecondValue).ToList();

                var listSourceCodeAndIdPair = linqMetaData.Coupons.Where(coupon => listSourceCode.Contains(coupon.CouponId)).
                    Select(coupon => new OrderedPair<long, string>(coupon.CouponId, coupon.CouponCode)).ToList();

                // Ordered Pair SeminarId, SourceCode
                var eventSourceCodes = seminarSourceCodeId.Join(listSourceCodeAndIdPair,
                                                                seminarCoupon => seminarCoupon.SecondValue,
                                                                sourceCodeAndIdPair => sourceCodeAndIdPair.FirstValue,
                                                                (seminarCoupon, sourceCodeAndIdPair) =>
                                                                new OrderedPair<long, string>(
                                                                    seminarCoupon.FirstValue,
                                                                    sourceCodeAndIdPair.SecondValue)).ToList();

                var listEventId = eventSeminarIds.Select(eventSeminarId => eventSeminarId.FirstValue).ToList();

                // Event Entity with seminar details prefetched
                var eventSeminars =
                    linqMetaData.Events.WithPath(
                        prefetchPath => prefetchPath.Prefetch(eventSeminar => eventSeminar.Seminars)).
                        Where(eventSeminar => listEventId.Contains(eventSeminar.EventId)).ToList();

                // Prospect Entity
                var prospectEntity =
                    linqMetaData.ProspectCustomer.Where(
                        prospectCustomer =>
                        prospectCustomer.SourceCodeId.HasValue &&
                        listSourceCode.Contains(prospectCustomer.SourceCodeId.Value)
                        ).
                        ToList();
                prospectEntity = prospectEntity.Where(
                        prospectCustomer =>
                        (prospectCustomer.Source == (long)ProspectCustomerSource.SalesRep) &&
                        (!prospectCustomerConversionStatus.HasValue ||
                         (long)prospectCustomerConversionStatus == prospectCustomer.Status)).ToList();

                if (startDate.HasValue && endDate.HasValue)
                {
                    prospectEntity =
                        prospectEntity.Where(prospectCustomer => prospectCustomer.DateCreated >= startDate &&
                        prospectCustomer.DateCreated <= endDate).ToList();
                }
                if (!string.IsNullOrEmpty(prospectName))
                    prospectEntity = prospectEntity.Where(prospectCustomer =>
                                                          (prospectCustomer.FirstName.ToLower() + " " +
                                                          prospectCustomer.LastName.ToLower()).Contains(prospectName.ToLower())).
                        ToList();

                // ProspectCustomer and Source Code pair
                var prospectCustomerIdAndSourceCodePair = prospectEntity.Join(listSourceCodeAndIdPair, pc => pc.SourceCodeId, sCodeAndId => sCodeAndId.FirstValue,
                    (pc, sCodeAndId) => new OrderedPair<long, string>(pc.ProspectCustomerId, sCodeAndId.SecondValue)).ToList();

                var listProspectCustomerIds = prospectEntity.Select(prospectCustomer => prospectCustomer.ProspectCustomerId).ToList().Distinct();

                var prospectCustomerNotificationQueryable = linqMetaData.ProspectCustomerNotification.
                    Where(prospectCustomerNotification => listProspectCustomerIds.Contains(prospectCustomerNotification.ProspectCustomerId)).ToList();

                var prospectCustomerNotificationIds = linqMetaData.ProspectCustomerNotification.
                    Where(
                    prospectCustomerNotification =>
                    listProspectCustomerIds.Contains(prospectCustomerNotification.ProspectCustomerId))
                    .Select(prosCustNotification => new OrderedPair<long, long>(prosCustNotification.ProspectCustomerId, prosCustNotification.NotificationId)).
                    ToList();

                //TODO:CallQueue new Flow
                //Prospect Customer Call Pair
                //var callNotification =
                //    linqMetaData.CallNotification.Where(
                //        callNo =>
                //        prospectCustomerNotificationIds.Select(pcn => pcn.SecondValue).Contains(callNo.NotificationId)).
                //        ToList();

                //var prospectCustomerCallPair = callNotification.Join(prospectCustomerNotificationIds, calln => calln.NotificationId, pcn => pcn.SecondValue,
                //    (calln, pcnCode) => new OrderedPair<long, long>(calln.CallId, pcnCode.FirstValue)).ToList();

                var prospectCustomerCallPair = new List<OrderedPair<long, long>>();

                var prospectCustomerCallPairForInboundCalls = linqMetaData.ProspectCustomerCall.
                                Where(pcCall => listProspectCustomerIds.Contains(pcCall.ProspectCustomerId)).
                                Select(pcCall => new OrderedPair<long, long>(pcCall.CallId, pcCall.ProspectCustomerId)).ToList();

                prospectCustomerCallPair.AddRange(prospectCustomerCallPairForInboundCalls);

                var listCallIds = prospectCustomerCallPair != null && prospectCustomerCallPair.Count > 0 ? prospectCustomerCallPair.Select(pcCall => pcCall.FirstValue).ToList() : null;

                //Call Entity
                var callEntity = listCallIds != null && listCallIds.Count > 0 ? linqMetaData.Calls.WithPath(prefetchPath => prefetchPath.Prefetch(call => call.CallCenterNotes))
                .Where(call => listCallIds.Contains(call.CallId)).ToList() : null;

                if (prospectEntity == null)
                {
                    hscProspectCustomerViewDataList = null;
                    totalRecord = 0;
                }
                else
                {
                    IProspectCustomerViewDataFactory _hscProspectCustomerViewDataFactory = new ProspectCustomerViewDataFactory();
                    hscProspectCustomerViewDataList = _hscProspectCustomerViewDataFactory.CreateViewDataforHSC(
                        prospectCustomerIdAndSourceCodePair,
                       eventSourceCodes, prospectCustomerCallPair, prospectEntity, eventSeminars, callEntity);

                    if (!string.IsNullOrEmpty(sourceCode))
                        hscProspectCustomerViewDataList = hscProspectCustomerViewDataList.Where(hscProspectCustomer => hscProspectCustomer.SourceCode.ToLower() == sourceCode.ToLower()).ToList();

                    if (hscProspectCustomerViewDataList != null && hscProspectCustomerViewDataList.Count > 0)
                    {
                        totalRecord = hscProspectCustomerViewDataList.Count;
                        hscProspectCustomerViewDataList = hscProspectCustomerViewDataList.OrderByDescending(eh => eh.DateCreated).ToList();
                        hscProspectCustomerViewDataList = hscProspectCustomerViewDataList.Skip((pageNumber) * pageSize).Take(pageSize).ToList();
                    }
                    else
                    {
                        hscProspectCustomerViewDataList = null;
                        totalRecord = 0;
                    }
                }
            }
            return hscProspectCustomerViewDataList;
        }

        // TODO: In Process, To improve yet.
        public List<ProspectCustomerViewData> GetProspectCustomersWithFiltersforCallCenterRep(string firstname, string lastName, string callBackNumber)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                List<ProspectCustomerEntity> listProspectCustomerEntity = null;

                if (!string.IsNullOrEmpty(callBackNumber) && (!string.IsNullOrEmpty(firstname) || !string.IsNullOrEmpty(lastName)))
                    listProspectCustomerEntity = linqMetaData.ProspectCustomer.Where(pc => (pc.CustomerId == null || pc.CustomerId.Value < 1) &&
                        ((pc.CallbackNo.Contains(callBackNumber) || pc.Phone2.Contains(callBackNumber))
                        || ((pc.FirstName.StartsWith(firstname, StringComparison.InvariantCultureIgnoreCase))
                        && (pc.LastName.StartsWith(lastName, StringComparison.InvariantCultureIgnoreCase))))).ToList();
                else if (!string.IsNullOrEmpty(callBackNumber))
                    listProspectCustomerEntity = linqMetaData.ProspectCustomer.Where(pc => ((pc.CallbackNo.Contains(callBackNumber))
                        || (pc.Phone2.Contains(callBackNumber))) && (pc.CustomerId == null || pc.CustomerId.Value < 1)).ToList();
                else if (!string.IsNullOrEmpty(firstname) || !string.IsNullOrEmpty(lastName))
                    listProspectCustomerEntity = linqMetaData.ProspectCustomer.Where(pc => (pc.CustomerId == null || pc.CustomerId.Value < 1)
                        && (pc.FirstName.StartsWith(firstname, StringComparison.InvariantCultureIgnoreCase))
                        && (pc.LastName.StartsWith(lastName, StringComparison.InvariantCultureIgnoreCase))).ToList();

                if (listProspectCustomerEntity != null && listProspectCustomerEntity.Count > 0)
                {
                    var listSourceCode = listProspectCustomerEntity.Where(pc => pc.SourceCodeId != null).Select(pc => pc.SourceCodeId).ToList();

                    var listSeminarIDCouponIdPair = linqMetaData.SeminarCampaignDetails.Join(linqMetaData.Afcampaign.Where(campaign => listSourceCode.Contains(campaign.PromoCodeId)),
                                            seminarCampaign => seminarCampaign.CampaignId, afCampaign => afCampaign.CampaignId,
                                                            (seminarCampaign, afCampaign) => new { seminarCampaign.SeminarId, afCampaign.PromoCodeId }
                        );

                    var listSeminar = linqMetaData.Seminars.
                        Where(seminar => listSeminarIDCouponIdPair.
                                Select(seminarCoupon => seminarCoupon.SeminarId).ToList().Contains(seminar.SeminarId)).ToList();

                    var listSeminarCouponPair = listSeminar.Join(listSeminarIDCouponIdPair, seminar => seminar.SeminarId,
                            seminarIdCouponId => seminarIdCouponId.SeminarId,
                            (seminar, seminarIdCouponId) => new OrderedPair<SeminarsEntity, long>(seminar, seminarIdCouponId.PromoCodeId)).ToList();

                    var listCouponCodeIdPair = linqMetaData.Coupons.Where(coupon => listSourceCode.Contains(coupon.CouponId)).
                        Select(coupon => new OrderedPair<long, string>(coupon.CouponId, coupon.CouponCode)).ToList();

                    // Call Factory and Prepare the View Data
                    IProspectCustomerViewDataFactory _prospectCustomerViewDataFactory = new ProspectCustomerViewDataFactory();
                    var listProspectCustomerViewData = _prospectCustomerViewDataFactory.CreateViewDataForCallCenterRep(listProspectCustomerEntity, listSeminarCouponPair, listCouponCodeIdPair);
                    return listProspectCustomerViewData;
                }

            }

            return null;
        }

        public ProspectCustomer GetProspectCustomermatchingConditions(string firstName, string lastName, string email, string phoneNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.ProspectCustomer.Where(
                    pc =>
                    pc.FirstName == firstName && pc.LastName == lastName &&
                    (pc.Email == email || pc.CallbackNo == phoneNumber || pc.Phone2 == phoneNumber)).ToArray();

                var entity = entities.OrderBy(pc => pc.DateCreated).LastOrDefault();
                if (entity == null) return null;
                return Mapper.Map(entity);
            }
        }

        public bool IsProspectAWorkshopProspect(long prospectCustomerId)
        {
            var prospectCustomer = GetProspectCustomer(prospectCustomerId);

            if (prospectCustomer.SourceCodeId == null) return false;

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var selectedRecord = linqMetaData.Afcampaign.Join(linqMetaData.SeminarCampaignDetails,
                    afCampaign => afCampaign.CampaignId,
                    seminarCampaign => seminarCampaign.CampaignId,
                    (afCampaign, seminarCampaign) => new { afCampaign.PromoCodeId, seminarCampaign.SeminarId })
                    .Where(seminarSourceCode => seminarSourceCode.PromoCodeId == prospectCustomer.SourceCodeId)
                    .SingleOrDefault();

                if (selectedRecord == null)
                    return false;
            }

            return true;
        }

        public IList<ProspectCustomer> GetProspectCustomersAfter(DateTime lastChecked)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IQueryable<ProspectCustomerEntity> prospectCustomers = linqMetaData.ProspectCustomer
                    .Where(pc => pc.DateCreated < lastChecked && pc.IsConverted == false);

                return Mapper.MapMultiple(prospectCustomers).ToList();
            }
        }

        private static int IndexOf(string searchText, string searchFrom)
        {
            return searchFrom.IndexOf(searchText);
        }

        private static string IsNull(object searchText)
        {
            return string.IsNullOrEmpty(searchText.ToString()) ? "" : searchText.ToString().Trim();
        }


        public IEnumerable<ProspectCustomer> GetAbandonedProspectCustomer(int pageNumber, int pageSize, ProspectCustomerListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {

                    totalRecords = linqMetaData.ProspectCustomer.Where(
                        pc =>
                            //(!pc.CustomerId.HasValue || pc.CustomerId.Value < 1) &&
                        (!pc.IsConverted.HasValue || !pc.IsConverted.Value)).Select(pc => pc).Count();

                    return
                        Mapper.MapMultiple(linqMetaData.ProspectCustomer.Where(
                                pc =>
                                    //(!pc.CustomerId.HasValue || pc.CustomerId.Value < 1) &&
                                (!pc.IsConverted.HasValue || !pc.IsConverted.Value)).Select(pc => pc).TakePage(
                                    pageNumber, pageSize).ToArray());
                }

                IQueryable<ProspectCustomerEntity> query = from pc in linqMetaData.ProspectCustomer select pc;

                //TODO: Don't write any condition before this, please 
                if (!string.IsNullOrEmpty(filter.Zipcode))
                {
                    if (filter.Miles > 0)
                    {
                        var zipInRange = _zipcodeRepository.GetZipCodesInRadius(filter.Zipcode, filter.Miles);

                        var zipCodesInRange = zipInRange != null ? zipInRange.Select(zcir => zcir.Zip).ToList() : null;

                        if (!(zipCodesInRange == null || zipCodesInRange.IsEmpty()))
                        {
                            var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                            if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                            linqMetaData.CustomFunctionMappings.Add(mapping);
                            mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                            linqMetaData.CustomFunctionMappings.Add(mapping);

                            string zipIdstring = "," + string.Join(",", zipCodesInRange) + ",";
                            query = from a in linqMetaData.ProspectCustomer
                                    where IndexOf(Convert.ToString(a.ZipCode), zipIdstring) > 0
                                    select a;

                        }
                    }
                    else
                        query = query.Where(pc => pc.ZipCode == filter.Zipcode);
                }

                query = query.Where(pc =>
                    //(!pc.CustomerId.HasValue || pc.CustomerId.Value < 1) &&
                                (!pc.IsConverted.HasValue || !pc.IsConverted.Value)
                                && (pc.CallbackNo.Trim().Length > 0 || pc.Email.Trim().Length > 0))
                            .Select(pc => pc);

                if (!string.IsNullOrEmpty(filter.CorporateTag))
                {
                    query = (from q in query
                             join ct in linqMetaData.CustomerProfile on q.CustomerId equals ct.CustomerId
                             where ct.Tag == filter.CorporateTag
                             select q);
                }

                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var isNoneSelected = filter.CustomTags.Any(x => x == "None");

                    var customTags = (filter.CustomTags.Where(x => x != "None"));

                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && customTags.Contains(ct.Tag)
                                                select ct.CustomerId);

                    if (isNoneSelected)
                    {
                        customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && customTags.Contains(ct.Tag)
                                                select ct.CustomerId);

                        var customTagNotApplied = (from ct in linqMetaData.CustomerTag where ct.IsActive select ct.CustomerId);
                        query = (from q in query
                                 join ct in linqMetaData.CustomerProfile on q.CustomerId equals ct.CustomerId
                                 where ((ct.Tag != null && ct.Tag != "" && !customTagNotApplied.Contains(ct.CustomerId)) || customTagCustomerIds.Contains(ct.CustomerId))
                                 select q);

                    }
                    else
                    {
                        query = (from q in query where q.CustomerId.HasValue && customTagCustomerIds.Contains(q.CustomerId.Value) select q);
                    }

                }


                if (filter.DateType == (int)ProspectCustomerDateTypeFilter.CreatedDate)
                {
                    if (filter.FromDate.HasValue)
                        query = query.Where(pc => pc.DateCreated >= filter.FromDate.Value);

                    if (filter.ToDate.HasValue)
                        query = query.Where(pc => pc.DateCreated < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                }
                else if (filter.DateType == (int)ProspectCustomerDateTypeFilter.LastContactedDate)
                {
                    if (filter.FromDate.HasValue)
                        query = query.Where(pc => pc.ContactedDate >= filter.FromDate.Value);

                    if (filter.ToDate.HasValue)
                        query = query.Where(pc => pc.ContactedDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                }

                if (filter.Source > 0)
                {
                    query = query.Where(pc => pc.Source == filter.Source);
                }

                if (!string.IsNullOrEmpty(filter.Tag))
                    query =
                        query.Where(pc => pc.Tag.Contains(filter.Tag));

                if (!string.IsNullOrEmpty(filter.PhoneNumber))
                {
                    var phoneNumber = filter.PhoneNumber.Replace("-", "").Replace("(", "").Replace(")", "");
                    query = query.Where(q => q.CallbackNo.Contains(phoneNumber));
                }

                if (filter.StateId > 0)
                {
                    var state = _stateRepository.GetState(filter.StateId);
                    query = query.Where(q => q.State.Equals(state.Name, StringComparison.InvariantCultureIgnoreCase));
                }

                if (!string.IsNullOrEmpty(filter.City))
                {
                    query = query.Where(q => q.City.Equals(filter.City, StringComparison.InvariantCultureIgnoreCase));
                }

                if (filter.AgentOrganizationId > 0)
                {
                    var assignedAccountIds = (from acco in linqMetaData.AccountCallCenterOrganization
                                              where acco.OrganizationId == filter.AgentOrganizationId && acco.IsDeleted == false
                                              select acco.AccountId);

                    var tags = (from a in linqMetaData.Account
                                where (a.RestrictHealthPlanData == false || assignedAccountIds.Contains(a.AccountId))
                                select a.Tag);

                    var customerIds = (from cp in linqMetaData.CustomerProfile
                                       where cp.Tag == null || cp.Tag == "" || tags.Contains(cp.Tag)
                                       select cp.CustomerId);

                    query = query.Where(x => x.CustomerId == null || customerIds.Contains(x.CustomerId.Value));

                }

                totalRecords = query.Count();

                query = filter.DateType == (int)ProspectCustomerDateTypeFilter.LastContactedDate ? query.OrderByDescending(pc => pc.ContactedDate) : query.OrderByDescending(pc => pc.DateCreated);

                return Mapper.MapMultiple(query.TakePage(pageNumber, pageSize).ToArray());

            }
        }

        public bool Delete(long prospectCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(ProspectCustomerCallFields.ProspectCustomerId == prospectCustomerId);
                adapter.DeleteEntitiesDirectly("ProspectCustomerCallEntity", bucket);

                _tempCartRepository.DeleteByProspectCustomerId(prospectCustomerId);

                bucket = new RelationPredicateBucket(ProspectCustomerNotificationFields.ProspectCustomerId == prospectCustomerId);
                adapter.DeleteEntitiesDirectly("ProspectCustomerNotificationEntity", bucket);

                bucket = new RelationPredicateBucket(CallQueueCustomerFields.ProspectCustomerId == prospectCustomerId);
                adapter.DeleteEntitiesDirectly("CallQueueCustomerEntity", bucket);

                bucket = new RelationPredicateBucket(ProspectCustomerFields.ProspectCustomerId == prospectCustomerId);

                if (adapter.DeleteEntitiesDirectly("ProspectCustomerEntity", bucket) > 0)
                    return true;
                return false;
            }
        }

        public bool Delete(long[] prospectCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(ProspectCustomerCallFields.ProspectCustomerId == prospectCustomerIds);
                adapter.DeleteEntitiesDirectly("ProspectCustomerCallEntity", bucket);

                _tempCartRepository.DeleteByProspectCustomerIds(prospectCustomerIds);

                bucket = new RelationPredicateBucket(ProspectCustomerNotificationFields.ProspectCustomerId == prospectCustomerIds);
                adapter.DeleteEntitiesDirectly("ProspectCustomerNotificationEntity", bucket);

                bucket = new RelationPredicateBucket(CallQueueCustomerFields.ProspectCustomerId == prospectCustomerIds);
                adapter.DeleteEntitiesDirectly("CallQueueCustomerEntity", bucket);

                bucket = new RelationPredicateBucket(ProspectCustomerFields.ProspectCustomerId == prospectCustomerIds);

                if (adapter.DeleteEntitiesDirectly("ProspectCustomerEntity", bucket) > 0)
                    return true;
                return false;
            }
        }

        public ProspectCustomer GetProspectCustomerByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from pc in linqMetaData.ProspectCustomer
                              where pc.CustomerId == customerId
                              select pc).FirstOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map(entity);
            }
        }

        public bool UpdateContactedStatus(long prospectCustomerId, long contactedBy)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new ProspectCustomerEntity(prospectCustomerId)
                                 {
                                     IsContacted = true,
                                     ContactedDate = DateTime.Now,
                                     ContactedBy = contactedBy
                                 };
                var bucket = new RelationPredicateBucket(ProspectCustomerFields.ProspectCustomerId == prospectCustomerId);

                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0 ? true : false;
            }
        }

        public bool UpdateDoNotCallStatus(long prospectCustomerId, ProspectCustomerConversionStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new ProspectCustomerEntity(prospectCustomerId)
                {
                    Status = (long)status
                };
                var bucket = new RelationPredicateBucket(ProspectCustomerFields.ProspectCustomerId == prospectCustomerId);

                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0 ? true : false;
            }
        }

        public IEnumerable<ProspectCustomer> GetProspectCustomersForReminder(int days)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ppcustomerIds = (from cp in linqMetaData.CustomerProfile
                                     where cp.Tag != null && cp.Tag.Trim().Length > 0
                                     select cp.CustomerId);

                var entities = (from pc in linqMetaData.ProspectCustomer
                                where pc.DateCreated.Date == DateTime.Now.AddDays(-1 * days).Date
                                      && pc.Email.Trim().Length > 0
                                      && (!pc.IsConverted.HasValue || !pc.IsConverted.Value)
                                      && (!pc.CustomerId.HasValue || !ppcustomerIds.Contains(pc.CustomerId.Value))
                                      && pc.Status == (long)ProspectCustomerConversionStatus.NotConverted
                                      && pc.Tag != ProspectCustomerTag.NoShow.ToString()
                                      && pc.Tag != ProspectCustomerTag.Cancellation.ToString()
                                      && pc.Tag != ProspectCustomerTag.Corporate.ToString()
                                select pc);
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<OrderedPair<long, long?>> GetProspectsBasedOnGeography(string zipCode, int radius, string searchTag)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ppcustomerIds = (from cp in linqMetaData.CustomerProfile
                                     where cp.Tag != null && cp.Tag.Trim().Length > 0
                                     select cp.CustomerId);

                var zipInRange = _zipcodeRepository.GetZipCodesInRadius(zipCode, radius);

                var zipCodesInRange = zipInRange != null ? zipInRange.Select(zcir => zcir.Zip).ToList() : null;

                if (!(zipCodesInRange == null || zipCodesInRange.IsEmpty()))
                {
                    var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                    if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                    linqMetaData.CustomFunctionMappings.Add(mapping);
                    mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                    linqMetaData.CustomFunctionMappings.Add(mapping);

                    string zipIdstring = "," + string.Join(",", zipCodesInRange) + ",";

                    bool isAllProspect = searchTag == "AllProspects";
                    return (from pc in linqMetaData.ProspectCustomer
                            where
                            (!pc.IsConverted.HasValue || !pc.IsConverted.Value)
                            && (!pc.CustomerId.HasValue || !ppcustomerIds.Contains(pc.CustomerId.Value))
                            && (pc.Status == (long)ProspectCustomerConversionStatus.NotConverted || pc.Status == 0)
                            && IndexOf(Convert.ToString(pc.ZipCode), zipIdstring) > 0
                            && (isAllProspect ? true : pc.Tag == searchTag)
                            orderby pc.DateCreated
                            select new OrderedPair<long, long?>(pc.ProspectCustomerId, pc.CustomerId)).ToArray();
                }
                return null;
            }
        }

        public IEnumerable<OrderedPair<long, long?>> GetEasiestToConvertProspect(DateTime? lastGeneratedDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ppcustomerIds = (from cp in linqMetaData.CustomerProfile
                                     where cp.Tag != null && cp.Tag.Trim().Length > 0
                                     select cp.CustomerId);

                var onlineSignUp = ProspectCustomerTag.OnlineSignup.ToString();
                var allEventsFull = ProspectCustomerTag.AllEventsFull.ToString();
                var callCenterSignup = ProspectCustomerTag.CallCenterSignup.ToString();
                var indecisiveUndecided = ProspectCustomerTag.IndecisiveUndecided.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();
                var morningAppointmentPreferred = ProspectCustomerTag.MorningAppointmentPreferred.ToString();
                var afternoonAppointmentPreferred = ProspectCustomerTag.AfternoonAppointmentPreferred.ToString();
                var noEventsInTheArea = ProspectCustomerTag.NoEventsInTheArea.ToString();
                var cancellation = ProspectCustomerTag.Cancellation.ToString();
                var poorLocation = ProspectCustomerTag.PoorLocation.ToString();
                var notServicedZip = ProspectCustomerTag.NotServicedZip.ToString();
                var pricingConcerns = ProspectCustomerTag.PricingConcerns.ToString();
                var surveyResponse = ProspectCustomerTag.SurveyResponse.ToString();
                var doctorConcerns = ProspectCustomerTag.DoctorConcerns.ToString();
                var insuranceConcerns = ProspectCustomerTag.InsuranceConcerns.ToString();


                var query = (from pc in linqMetaData.ProspectCustomer
                             where
                                 (!pc.IsConverted.HasValue || !pc.IsConverted.Value)
                                 && (!pc.CustomerId.HasValue || !ppcustomerIds.Contains(pc.CustomerId.Value))
                                 && (pc.Status == (long)ProspectCustomerConversionStatus.NotConverted || pc.Status == 0)
                                 && (pc.CallbackNo != null && pc.CallbackNo.Trim().Length > 0)
                                 &&
                                 (pc.Tag == onlineSignUp || pc.Tag == callCenterSignup || pc.Tag == morningAppointmentPreferred || pc.Tag == noShow || pc.Tag == cancellation
                                 || pc.Tag == allEventsFull || pc.Tag == noEventsInTheArea || pc.Tag == indecisiveUndecided || pc.Tag == afternoonAppointmentPreferred
                                 || pc.Tag == poorLocation || pc.Tag == notServicedZip || pc.Tag == pricingConcerns || pc.Tag == surveyResponse || pc.Tag == doctorConcerns
                                 || pc.Tag == insuranceConcerns)
                             select pc);
                if (lastGeneratedDate.HasValue)
                    query = (from q in query where q.DateCreated >= lastGeneratedDate.Value.AddHours(-1) select q);

                return (from q in query orderby q.DateCreated select new OrderedPair<long, long?>(q.ProspectCustomerId, q.CustomerId)).ToArray();
            }
        }

        public IEnumerable<FillEventProspectCustomerViewModel> GetProspectCustomerForFillEventCallQueue(List<OrderedPair<long, string>> eventIdZips, List<OrderedPair<string, string>> zipZipStringPairList)
        {
            var completePCustomerList = new List<FillEventProspectCustomerViewModel>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                linqMetaData.CustomFunctionMappings.Add(mapping);
                mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                linqMetaData.CustomFunctionMappings.Add(mapping);

                foreach (var item in eventIdZips)
                {
                    var zipIdstring = zipZipStringPairList.Where(x => x.FirstValue == item.SecondValue).Select(x => x.SecondValue).FirstOrDefault() ?? item.SecondValue;

                    var ppcustomerIds = (from cp in linqMetaData.CustomerProfile
                                         where cp.Tag != null && cp.Tag.Trim().Length > 0
                                         select cp.CustomerId);

                    var prospectCustomerIds = (from pc in linqMetaData.ProspectCustomer
                                               where
                                                   (!pc.IsConverted.HasValue || !pc.IsConverted.Value)
                                                   && (!pc.CustomerId.HasValue || !ppcustomerIds.Contains(pc.CustomerId.Value))
                                                   && (pc.Status == (long)ProspectCustomerConversionStatus.NotConverted || pc.Status == 0)
                                                   && pc.ZipCode != null
                                                   && IndexOf(Convert.ToString(pc.ZipCode), zipIdstring) > 0
                                               orderby pc.DateCreated
                                               select new FillEventProspectCustomerViewModel() { ProspectCustomerId = pc.ProspectCustomerId, EventId = item.FirstValue, CustomerId = pc.CustomerId }).Take(100).ToArray();
                    if (prospectCustomerIds.Any())
                        completePCustomerList.AddRange(prospectCustomerIds);
                }
            }
            return completePCustomerList.Distinct();
        }

        public IEnumerable<ProspectCustomer> GetCallBackQueue(DateTime? lastGeneratedDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ppcustomerIds = (from cp in linqMetaData.CustomerProfile
                                     where cp.Tag != null && cp.Tag.Trim().Length > 0
                                     select cp.CustomerId);

                var query = (from pc in linqMetaData.ProspectCustomer
                             where (!pc.IsConverted.HasValue || !pc.IsConverted.Value)
                                && (!pc.CustomerId.HasValue || !ppcustomerIds.Contains(pc.CustomerId.Value))
                                && pc.IsQueuedForCallBack
                             select pc);

                if (lastGeneratedDate.HasValue)
                    query = (from q in query where q.CallBackRequestedOn >= lastGeneratedDate.Value.AddHours(-1) select q);

                return Mapper.MapMultiple(query);
            }
        }

        public List<ProspectCustomer> GetProspectCustomersByCustomerIds(long[] customerIds)
        {
            var entities = new EntityCollection<ProspectCustomerEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(ProspectCustomerFields.CustomerId == customerIds);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(entities, bucket);
            }

            return Mapper.MapMultiple(entities).ToList();
        }

        public IEnumerable<long> GetCustomerIdsByTag(ProspectCustomerTag tag, CallStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var existing = CallType.Existing_Customer.GetDescription();
                var linqMetaData = new LinqMetaData(adapter);
                var ppcustomerIds = from cl in linqMetaData.Calls
                                    where cl.CallStatus == existing && cl.TimeCreated.Value.Date == DateTime.Today && cl.Status == (long)status
                                    && cl.CalledCustomerId.HasValue
                                    select cl.CalledCustomerId.Value;

                var query = (from pc in linqMetaData.ProspectCustomer
                             where (pc.CustomerId.HasValue && ppcustomerIds.Contains(pc.CustomerId.Value))
                                && pc.Tag == tag.ToString()
                             select pc.CustomerId.Value);

                return query.ToList();
            }
        }

        public IEnumerable<ProspectCustomer> GetForInterviewReport(InterviewInboundFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault();

                var query = (from pc in linqMetaData.ProspectCustomer
                             join cp in linqMetaData.CustomerProfile on pc.CustomerId equals cp.CustomerId
                             where (account == null || cp.Tag == account.Tag)
                                   && (filter.StartDate == null || (pc.DateCreated >= filter.StartDate))
                                   && (filter.EndDate == null || (pc.DateCreated <= filter.EndDate))
                             select pc);

                return Mapper.MapMultiple(query).ToArray();
            }
        }
    }
}