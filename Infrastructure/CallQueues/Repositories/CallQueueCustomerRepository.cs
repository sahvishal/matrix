using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class CallQueueCustomerRepository : PersistenceRepository, ICallQueueCustomerRepository
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IOrganizationRepository _organizationRepository;

        private const string CommaString = ",";

        //public CallQueueCustomerRepository()
        //    : this(new ZipCodeRepository())
        //{

        //}

        public CallQueueCustomerRepository(IZipCodeRepository zipCodeRepository, IOrganizationRepository organizationRepository)
        {
            _zipCodeRepository = zipCodeRepository;
            _organizationRepository = organizationRepository;
        }

        public CallQueueCustomer Save(CallQueueCustomer callQueueCustomer, bool refatch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallQueueCustomer, CallQueueCustomerEntity>(callQueueCustomer);

                if (!adapter.SaveEntity(entity, refatch))
                {
                    throw new PersistenceFailureException();
                }

                return refatch ? Mapper.Map<CallQueueCustomerEntity, CallQueueCustomer>(entity) : callQueueCustomer;
            }
        }

        public CallQueueCustomer GetById(long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from cqc in linqMetaData.CallQueueCustomer
                              where cqc.CallQueueCustomerId == callQueueCustomerId
                              select cqc).SingleOrDefault();

                if (entity == null)
                    return null;

                return Mapper.Map<CallQueueCustomerEntity, CallQueueCustomer>(entity);
            }
        }

        public bool IsCallQueueExist(long callQueueId, long prospectId, long customerId, long? eventId, int noofdaysToIncludeRemoved)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cq in linqMetaData.CallQueueCustomer
                             where cq.CallQueueId == callQueueId
                                   && (cq.Status == (long)CallQueueStatus.InProcess || cq.Status == (long)CallQueueStatus.Initial
                                   || (cq.Status == (long)CallQueueStatus.Removed && cq.DateModified.Value.Date.AddDays(noofdaysToIncludeRemoved) < DateTime.Today))
                                   && (cq.ProspectCustomerId == prospectId || cq.CustomerId == customerId)
                             select cq);
                if (eventId.HasValue)
                    query = query.Where(q => q.EventId.Value == eventId.Value);

                var count = query.Count();
                return count > 0;
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerByCallQueueId(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cq in linqMetaData.CallQueueCustomer where cq.CallQueueId == callQueueId select cq).ToArray();
                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(entities);
            }
        }

        public IEnumerable<long> GetCallQueueCustomerIdsByCallQueueIdAndStatus(long callQueueId, CallQueueStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cqc in linqMetaData.CallQueueCustomer
                        where cqc.CallQueueId == callQueueId
                        && cqc.Status == (long)status
                        select cqc.CallQueueCustomerId).ToArray();
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomers(long callQueueId, long assignedToOrgRoleUserId, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (callQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }
                var date = DateTime.Now.AddDays(1).Date;
                var maxAttempt = (from cq in linqMetaData.CallQueue where cq.CallQueueId == callQueueId select cq.Attempts).Single();

                //var tempquery = (from cqc in linqMetaData.CallQueueCustomer
                //                 where cqc.CallQueueId == callQueueId
                //                 && cqc.AssignedToOrgRoleUserId == assignedToOrgRoleUserId
                //                 && cqc.Status == (long)CallQueueStatus.Initial
                //                 && cqc.Attempts < maxAttempt
                //                 //&& cqc.CallDate < date
                //                 //orderby cqc.CallDate descending
                //                 select new { cqc, SortingDate = cqc.CallDate < date ? cqc.CallDate : date.AddYears(-1).Date });

                //var query = (from q in tempquery orderby q.SortingDate descending select q.cqc);

                //var query = (from cqc in linqMetaData.CallQueueCustomer
                //              where cqc.CallQueueId == callQueueId
                //              && cqc.AssignedToOrgRoleUserId == assignedToOrgRoleUserId
                //              && cqc.Status == (long)CallQueueStatus.Initial
                //              && cqc.Attempts < maxAttempt
                //             orderby (cqc.CallDate >= date) ? cqc.CallDate : date,
                //                (cqc.CallDate < date) ? date : cqc.CallDate descending 
                //              select cqc);

                //totalRecords = query.Count();

                //var entities = query.TakePage(pageNumber, pageSize).ToArray();

                var countQuery = (from cqc in linqMetaData.CallQueueCustomer
                                  where cqc.CallQueueId == callQueueId
                                  && cqc.AssignedToOrgRoleUserId == assignedToOrgRoleUserId
                                  && cqc.Status == (long)CallQueueStatus.Initial
                                  && cqc.Attempts < maxAttempt
                                  select cqc);

                totalRecords = countQuery.Count();
                if (totalRecords <= 0)
                    return null;

                var beforeCallDateQuery = (from cqc in linqMetaData.CallQueueCustomer
                                           where cqc.CallQueueId == callQueueId
                                           && cqc.AssignedToOrgRoleUserId == assignedToOrgRoleUserId
                                           && cqc.Status == (long)CallQueueStatus.Initial
                                           && cqc.Attempts < maxAttempt
                                           && cqc.CallDate < date
                                           orderby cqc.CallDate descending
                                           select cqc);

                var entities = beforeCallDateQuery.TakePage(pageNumber, pageSize).ToArray();

                var recordsFound = entities.Count();

                if (recordsFound < pageSize)
                {
                    var newPageSize = pageSize - entities.Count();

                    var afterCallDateQuery = (from cqc in linqMetaData.CallQueueCustomer
                                              where cqc.CallQueueId == callQueueId
                                              && cqc.AssignedToOrgRoleUserId == assignedToOrgRoleUserId
                                              && cqc.Status == (long)CallQueueStatus.Initial
                                              && cqc.Attempts < maxAttempt
                                              select new { cqc, SortIndex = cqc.CallDate < date ? 0 : 1, SortingDate = cqc.DateModified.HasValue ? cqc.DateModified.Value : cqc.DateCreated });

                    var query = (from q in afterCallDateQuery orderby q.SortIndex, q.SortingDate select q.cqc);

                    var skipRecords = (pageSize * (pageNumber - 1)) + recordsFound;

                    var anotherEntities = query.TakePage(pageNumber, pageSize).ToArray();

                    if (anotherEntities.Any())
                    {
                        anotherEntities = anotherEntities.Skip(recordsFound).Take(newPageSize).ToArray();

                        entities = entities.Concat(anotherEntities).ToArray();
                    }
                }

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(entities);
            }
        }

        public void UpdateOtherCustomerStatus(long customerId, long prospectCustomerId, CallQueueStatus status, long updatedBy)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CallQueueCustomerEntity()
                {
                    DateModified = DateTime.Now,
                    ModifiedByOrgRoleUserId = updatedBy,
                    Status = (long)status
                };

                var bucket = new RelationPredicateBucket(CallQueueCustomerFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithOr(CallQueueCustomerFields.ProspectCustomerId == prospectCustomerId);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public void UpdateOtherCustomerAttempt(long callQueueCustomerId, long customerId, long prospectCustomerId, long updatedBy, DateTime callDate,
            bool isRemovedFromQueue, long callQueueId, long? callOutcomeId = null, DateTime? contactedDate = null, bool isForParsing = false, string disposition = "")
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeataData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMeataData.CallQueueCustomer
                                where cqc.CallQueueCustomerId != callQueueCustomerId
                                && (cqc.Status == (long)CallQueueStatus.Initial || cqc.Status == (long)CallQueueStatus.InProcess)
                                && (cqc.CustomerId == customerId || cqc.ProspectCustomerId == prospectCustomerId)
                                select cqc).ToArray();

                var callQueue = linqMeataData.CallQueue.FirstOrDefault(x => x.CallQueueId == callQueueId);

                if (entities.Any())
                {
                    foreach (var entity in entities)
                    {
                        entity.DateModified = DateTime.Now;
                        entity.ModifiedByOrgRoleUserId = updatedBy;
                        entity.CallDate = callDate;

                        entity.IsNew = false;
                        if (isRemovedFromQueue)
                            entity.Status = (long)CallQueueStatus.Removed;

                        if (callQueue != null && callQueueCustomerId > 0)
                        {
                            if (callOutcomeId == null || (callOutcomeId != (long)CallStatus.CallSkipped))
                            {
                                if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                                {
                                    entity.CallCount = (entity.CallCount ?? 0) + 1;
                                }
                                else
                                {
                                    if (callOutcomeId == (long)CallStatus.Attended || callOutcomeId == (long)CallStatus.VoiceMessage || callOutcomeId == (long)CallStatus.LeftMessageWithOther)
                                    {
                                        entity.CallCount = (entity.CallCount ?? 0) + 1;
                                    }
                                }
                            }
                            entity.ContactedDate = contactedDate.HasValue ? contactedDate.Value : DateTime.Now;
                        }
                        entity.CallStatus = callOutcomeId;

                        if (isForParsing)
                        {
                            entity.Disposition = disposition;
                        }

                        //if (callOutcomeId == null || callOutcomeId != (long)CallStatus.CallSkipped)
                        //{ entity.CallCount = (entity.CallCount ?? 0) + 1; }
                        //entity.CallStatus = callOutcomeId;

                        //if (callQueueCustomerId > 0)
                        //{
                        //    entity.ContactedDate = contactedDate.HasValue ? contactedDate.Value : DateTime.Now;
                        //}

                        adapter.SaveEntity(entity);
                    }
                }
            }
        }

        public void UpdateAssignment(IEnumerable<long> callQueueCustomerIds, long assignedToOrgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CallQueueCustomerEntity()
                {
                    AssignedToOrgRoleUserId = assignedToOrgRoleUserId
                };

                var bucket = new RelationPredicateBucket(CallQueueCustomerFields.CallQueueCustomerId == callQueueCustomerIds.ToArray());
                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetQueueIdTotalCustomersInQueuePairs(IEnumerable<long> callQueueIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cqc in linqMetaData.CallQueueCustomer
                        join cq in linqMetaData.CallQueue on cqc.CallQueueId equals cq.CallQueueId
                        where callQueueIds.Contains(cqc.CallQueueId)
                        && cqc.Attempts < cq.Attempts
                        && (cqc.Status == (long)CallQueueStatus.Initial || cqc.Status == (long)CallQueueStatus.InProcess)
                        group cqc by cqc.CallQueueId into g
                        select new OrderedPair<long, long>(g.Key, g.Count())).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetQueueIdTotalCustomersPairs(IEnumerable<long> callQueueIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cqc in linqMetaData.CallQueueCustomer
                        where callQueueIds.Contains(cqc.CallQueueId)
                        group cqc by cqc.CallQueueId into g
                        select new OrderedPair<long, long>(g.Key, g.Count())).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetQueueIdTotalCustomersContactedPairs(IEnumerable<long> callQueueIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cqc in linqMetaData.CallQueueCustomer
                        where callQueueIds.Contains(cqc.CallQueueId)
                        && (cqc.Status == (long)CallQueueStatus.Completed || cqc.Status == (long)CallQueueStatus.Removed || cqc.Attempts > 0)
                        group cqc by cqc.CallQueueId into g
                        select new OrderedPair<long, long>(g.Key, g.Count())).ToArray();
            }
        }

        public IEnumerable<CallQueueCustomerStats> GetTotalCallQueueCustomerStats(IEnumerable<long> callQueueIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cqc in linqMetaData.CallQueueCustomer
                        where callQueueIds.Contains(cqc.CallQueueId)
                        && cqc.AssignedToOrgRoleUserId.HasValue
                        group cqc by new { cqc.CallQueueId, cqc.AssignedToOrgRoleUserId } into g
                        select new CallQueueCustomerStats() { CallQueueId = g.Key.CallQueueId, AssignedToOrgRoleUserId = g.Key.AssignedToOrgRoleUserId.Value, Count = g.Count() }).ToArray();
            }
        }

        public IEnumerable<CallQueueCustomerStats> GetContactedCallCustomersStats(IEnumerable<long> callQueueIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from cqc in linqMetaData.CallQueueCustomer
                        where callQueueIds.Contains(cqc.CallQueueId)
                        && (cqc.Status == (long)CallQueueStatus.Completed || cqc.Status == (long)CallQueueStatus.Removed || cqc.Attempts > 0)
                        && cqc.AssignedToOrgRoleUserId.HasValue
                        group cqc by new { cqc.CallQueueId, cqc.AssignedToOrgRoleUserId } into g
                        select new CallQueueCustomerStats() { CallQueueId = g.Key.CallQueueId, AssignedToOrgRoleUserId = g.Key.AssignedToOrgRoleUserId.Value, Count = g.Count() }).ToArray();
            }
        }

        public IEnumerable<CallQueueCustomer> PullBackCallQueueCustomer(int interval)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMetaData.CallQueueCustomer where cqc.DateModified <= DateTime.Now.AddHours(-1 * interval) && cqc.Status == (long)CallQueueStatus.InProcess select cqc).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(entities);

                //var entity = new CallQueueCustomerEntity()
                //{
                //    Status = (long)CallQueueStatus.Initial
                //};

                //var bucket = new RelationPredicateBucket(CallQueueCustomerFields.Status == (long)CallQueueStatus.InProcess);
                //bucket.PredicateExpression.AddWithAnd(CallQueueCustomerFields.DateModified <= DateTime.Now.AddHours(-1 * interval));

                //adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public void DeleteForInActiveCallQueueCriteria(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var inactiveCallQueueCriteriaIds = (from cqc in linqMetaData.CallQueueCriteria
                                                    where cqc.CallQueueId == callQueueId && !cqc.IsActive
                                                    select cqc.CallQueueCriteriaId).ToArray();

                var contactedCallQueueCustomerIds = (from cqc in linqMetaData.CallQueueCustomer
                                                     join cqcc in linqMetaData.CallQueueCustomerCall on cqc.CallQueueCustomerId equals cqcc.CallQueueCustomerId
                                                     where cqc.CallQueueId == callQueueId
                                                     && cqc.CallQueueCriteriaId.HasValue
                                                     && inactiveCallQueueCriteriaIds.Contains(cqc.CallQueueCriteriaId.Value)
                                                     select cqc.CallQueueCustomerId).ToArray();

                var relationPredicateBucket = new RelationPredicateBucket(CallQueueCustomerFields.CallQueueCriteriaId == inactiveCallQueueCriteriaIds);
                relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueCustomerFields.CallQueueId == callQueueId);
                relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueCustomerFields.Status == (long)CallQueueStatus.Initial);
                relationPredicateBucket.PredicateExpression.AddWithAnd(CallQueueCustomerFields.CallQueueCustomerId != contactedCallQueueCustomerIds);

                adapter.DeleteEntitiesDirectly(typeof(CallQueueCustomerEntity), relationPredicateBucket);
            }
        }

        //private string GetZipIdString(string zipCode, int radius)
        //{
        //    string zipIdstring = string.Empty;
        //    if (!string.IsNullOrEmpty(zipCode))
        //    {
        //        List<ZipCode> zipCodes = null;

        //        if (radius > 0)
        //            zipCodes = _zipCodeRepository.GetZipCodesInRadius(zipCode, radius);
        //        else
        //        {
        //            try
        //            {
        //                zipCodes = _zipCodeRepository.GetZipCode(zipCode).ToList();
        //            }
        //            catch
        //            { }
        //        }

        //        if (zipCodes != null && zipCodes.Count > 0)
        //        {
        //            var zipIdsInRange = zipCodes.Select(zcir => zcir.Id).ToList();

        //            zipIdstring = "," + string.Join(",", zipIdsInRange) + ",";
        //        }
        //        else
        //        {
        //            zipIdstring = ",0,";
        //        }
        //    }

        //    return zipIdstring;

        //}

        //private static int IndexOf(string searchText, string searchFrom)
        //{
        //    return searchFrom.IndexOf(searchText);
        //}

        public IEnumerable<CallQueueCustomer> GetbyIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMetaData.CallQueueCustomer where ids.Contains(cqc.CallQueueCustomerId) select cqc).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(entities);
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerForZipCode(OutboundCallQueueFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();
                var maxAttempt = callQueue.Attempts;

                var query = (from cqc in linqMetaData.CallQueueCustomer
                             where cqc.CallQueueId == filter.CallQueueId
                             && cqc.Status == (long)CallQueueStatus.Initial
                             && cqc.Attempts < maxAttempt
                             select cqc);

                if (filter.EventId.HasValue)
                    query = query.Where(q => q.EventId == filter.EventId.Value);

                var customerQuery = (from cqc in linqMetaData.CallQueueCustomer
                                     join cp in linqMetaData.CustomerProfile on cqc.CustomerId equals cp.CustomerId
                                     where cqc.CallQueueId == filter.CallQueueId
                                     select cp);

                var prospectCustomerQuery = (from cqc in linqMetaData.CallQueueCustomer
                                             join pc in linqMetaData.ProspectCustomer on cqc.ProspectCustomerId equals pc.ProspectCustomerId
                                             where cqc.CallQueueId == filter.CallQueueId
                                             && !cqc.CustomerId.HasValue && cqc.ProspectCustomerId.HasValue
                                             select pc);

                var name = string.IsNullOrEmpty(filter.Name) ? string.Empty : filter.Name;
                var phoneNumber = string.IsNullOrEmpty(filter.PhoneNumber) ? string.Empty : filter.PhoneNumber;
                var email = string.IsNullOrEmpty(filter.Email) ? string.Empty : filter.Email;
                var tag = string.IsNullOrEmpty(filter.Tag) ? string.Empty : filter.Tag;

                if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(phoneNumber) || !string.IsNullOrEmpty(email))
                {
                    customerQuery = (from cq in customerQuery
                                     join oru in linqMetaData.OrganizationRoleUser on cq.CustomerId equals oru.OrganizationRoleUserId
                                     join user in linqMetaData.User on oru.UserId equals user.UserId
                                     where (name == "" || (user.FirstName + (user.MiddleName.Trim().Length > 0 ? (" " + user.MiddleName + " ") : " ") + user.LastName).Contains(name))
                                           && (phoneNumber == "" || (user.PhoneCell == filter.PhoneNumber || user.PhoneHome == filter.PhoneNumber || user.PhoneOffice == filter.PhoneNumber))
                                           && (email == "" || user.Email1 == filter.Email)
                                     select cq);
                }

                if (!string.IsNullOrEmpty(tag))
                {
                    customerQuery = (from cq in customerQuery
                                     join prospect in linqMetaData.ProspectCustomer on cq.CustomerId equals prospect.CustomerId
                                     where prospect.CustomerId.HasValue && prospect.Tag == tag
                                     select cq);
                }

                if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(phoneNumber) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(tag))
                {
                    prospectCustomerQuery = (from prospect in prospectCustomerQuery
                                             where (name == "" || (prospect.FirstName + " " + prospect.LastName).Contains(filter.Name))
                                             && (phoneNumber == "" || prospect.CallbackNo == phoneNumber)
                                             && (email == "" || prospect.Email == email) && (tag == "" || prospect.Tag == tag)
                                             select prospect);
                }

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        customerQuery = from a in customerQuery
                                        where zipRadiusDistance.Contains(a.OrganizationRoleUser.User.Address.ZipId)
                                        select a;

                        prospectCustomerQuery = (from pcq in prospectCustomerQuery
                                                 join zip in linqMetaData.Zip on pcq.ZipCode equals zip.ZipCode
                                                 where zipRadiusDistance.Contains(zip.ZipId)
                                                 select pcq);
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.OrganizationRoleUser.User.Address.ZipId)
                                    select q;

                            prospectCustomerQuery = (from pcq in prospectCustomerQuery
                                                     join zip in linqMetaData.Zip on pcq.ZipCode equals zip.ZipCode
                                                     where zipIds.Contains(zip.ZipId)
                                                     select pcq);
                        }
                    }
                }

                var customerIdQuery = (from cq in customerQuery select cq.CustomerId);
                var prospectCustomerIdQuery = (from pcq in prospectCustomerQuery select pcq.ProspectCustomerId);

                var finalQuery = (from cqc in query
                                  where (cqc.CustomerId.HasValue && customerIdQuery.Contains(cqc.CustomerId.Value))
                                  || (cqc.ProspectCustomerId.HasValue && prospectCustomerIdQuery.Contains(cqc.ProspectCustomerId.Value))
                                  select new
                                  {
                                      cqc.CallQueueCustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified.HasValue ? cqc.DateModified.Value : cqc.DateCreated
                                  });

                totalRecords = finalQuery.Count();

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);

                var callQuequeCusomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQuequeCusomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQuequeCusomerIds);

                    return callQuequeCusomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }

                return null;
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerForFillEvents(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();
                var maxAttempt = callQueue.Attempts;

                var callQueueCustomerIdsInCriteria = (from ca in linqMetaData.SystemGeneratedCallQueueAssignment
                                                      where ca.CriteriaId == criteriaId
                                                      select ca.CallQueueCustomerId);

                var query = (from cqc in linqMetaData.CallQueueCustomer
                             where cqc.CallQueueId == filter.CallQueueId
                             && cqc.EventId == filter.EventId
                             && cqc.Status == (long)CallQueueStatus.Initial
                             && cqc.Attempts < maxAttempt
                             && callQueueCustomerIdsInCriteria.Contains(cqc.CallQueueCustomerId)
                             select cqc);

                var customerQuery = (from cqc in linqMetaData.CallQueueCustomer
                                     join cp in linqMetaData.CustomerProfile on cqc.CustomerId equals cp.CustomerId
                                     where cqc.CallQueueId == filter.CallQueueId
                                     select cp);

                var prospectCustomerQuery = (from cqc in linqMetaData.CallQueueCustomer
                                             join pc in linqMetaData.ProspectCustomer on cqc.ProspectCustomerId equals pc.ProspectCustomerId
                                             where cqc.CallQueueId == filter.CallQueueId
                                             && !cqc.CustomerId.HasValue && cqc.ProspectCustomerId.HasValue
                                             select pc);

                var name = string.IsNullOrEmpty(filter.Name) ? string.Empty : filter.Name;
                var phoneNumber = string.IsNullOrEmpty(filter.PhoneNumber) ? string.Empty : filter.PhoneNumber;
                var email = string.IsNullOrEmpty(filter.Email) ? string.Empty : filter.Email;
                var tag = string.IsNullOrEmpty(filter.Tag) ? string.Empty : filter.Tag;

                if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(phoneNumber) || !string.IsNullOrEmpty(email))
                {
                    customerQuery = (from cq in customerQuery
                                     join oru in linqMetaData.OrganizationRoleUser on cq.CustomerId equals oru.OrganizationRoleUserId
                                     join user in linqMetaData.User on oru.UserId equals user.UserId
                                     where (name == "" || (user.FirstName + (user.MiddleName.Trim().Length > 0 ? (" " + user.MiddleName + " ") : " ") + user.LastName).Contains(name))
                                           && (phoneNumber == "" || (user.PhoneCell == filter.PhoneNumber || user.PhoneHome == filter.PhoneNumber || user.PhoneOffice == filter.PhoneNumber))
                                           && (email == "" || user.Email1 == filter.Email)
                                     select cq);

                    prospectCustomerQuery = (from prospect in prospectCustomerQuery
                                             where (name == "" || (prospect.FirstName + " " + prospect.LastName).Contains(filter.Name))
                                             && (phoneNumber == "" || prospect.CallbackNo == phoneNumber)
                                             && (email == "" || prospect.Email == email)
                                             select prospect);
                }

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        customerQuery = from a in customerQuery
                                        where zipRadiusDistance.Contains(a.OrganizationRoleUser.User.Address.ZipId)
                                        select a;

                        prospectCustomerQuery = (from pcq in prospectCustomerQuery
                                                 join zip in linqMetaData.Zip on pcq.ZipCode equals zip.ZipCode
                                                 where zipRadiusDistance.Contains(zip.ZipId)
                                                 select pcq);
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.OrganizationRoleUser.User.Address.ZipId)
                                    select q;

                            prospectCustomerQuery = (from pcq in prospectCustomerQuery
                                                     join zip in linqMetaData.Zip on pcq.ZipCode equals zip.ZipCode
                                                     where zipIds.Contains(zip.ZipId)
                                                     select pcq);
                        }
                    }
                }


                var customerIdQuery = (from cq in customerQuery select cq.CustomerId);
                var prospectCustomerIdQuery = (from pcq in prospectCustomerQuery select pcq.ProspectCustomerId);

                var finalQuery = (from cqc in query
                                  where (cqc.CustomerId.HasValue && customerIdQuery.Contains(cqc.CustomerId.Value))
                                  || (cqc.ProspectCustomerId.HasValue && prospectCustomerIdQuery.Contains(cqc.ProspectCustomerId.Value))
                                  select new
                                  {
                                      cqc.CallQueueCustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified.HasValue ? cqc.DateModified.Value : cqc.DateCreated
                                  });

                totalRecords = finalQuery.Count();

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);

                var callQuequeCusomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQuequeCusomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQuequeCusomerIds);

                    return callQuequeCusomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }

                return null;
            }
        }

        public void DeletePastEventCallQueue()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var callQueueIds = (from p in linqMetaData.CallQueue where p.IsManual == false select p.CallQueueId).ToArray();

                var callQueueCustomer = (from cqc in linqMetaData.CallQueueCustomer
                                         join e in linqMetaData.Events on cqc.EventId equals e.EventId
                                         where callQueueIds.Contains(cqc.CallQueueId)
                                               && cqc.EventId.HasValue
                                               && e.EventDate < DateTime.Today
                                         select cqc);

                //var excludeCallQueueCustomerIds = (from cqc in callQueueCustomer
                //                                   join cqcc in linqMetaData.CallQueueCustomerCall on cqc.CallQueueCustomerId equals cqcc.CallQueueCustomerId
                //                                   select cqc.CallQueueCustomerId);

                var excludeCallQueueCustomerIds = (from cqcc in linqMetaData.CallQueueCustomerCall
                                                   select cqcc.CallQueueCustomerId);

                var finalCallQueueCustomerIds = (from cqc in callQueueCustomer
                                                 where !excludeCallQueueCustomerIds.Contains(cqc.CallQueueCustomerId)
                                                 select cqc.CallQueueCustomerId).ToArray();

                foreach (var callQueueCustomerId in finalCallQueueCustomerIds)
                {
                    var relationPredicateBucket = new RelationPredicateBucket(CallQueueCustomerFields.CallQueueCustomerId == callQueueCustomerId);

                    adapter.DeleteEntitiesDirectly(typeof(CallQueueCustomerEntity), relationPredicateBucket);
                }
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerForUpsellAndConfirmation(OutboundCallQueueFilter filter, int pageNumber, int pageSize, CallQueue callQueue, long criteriaId, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var query = (from cqc in linqMetaData.CallQueueCustomer
                             join ca in linqMetaData.SystemGeneratedCallQueueAssignment on cqc.CallQueueCustomerId equals ca.CallQueueCustomerId
                             join e in linqMetaData.Events on cqc.EventId equals e.EventId
                             where cqc.CallQueueId == filter.CallQueueId
                             && e.EventDate > DateTime.Now.Date
                             && cqc.Status == (long)CallQueueStatus.Initial
                             && cqc.Attempts < callQueue.Attempts
                             && ca.CriteriaId == criteriaId
                             select cqc);

                if (filter.EventId.HasValue)
                    query = query.Where(q => q.EventId == filter.EventId.Value);

                var customerQuery = (from cqc in linqMetaData.CallQueueCustomer
                                     join cp in linqMetaData.CustomerProfile on cqc.CustomerId equals cp.CustomerId
                                     where cqc.CallQueueId == filter.CallQueueId
                                     select cp);

                var name = string.IsNullOrEmpty(filter.Name) ? string.Empty : filter.Name;
                var phoneNumber = string.IsNullOrEmpty(filter.PhoneNumber) ? string.Empty : filter.PhoneNumber;
                var email = string.IsNullOrEmpty(filter.Email) ? string.Empty : filter.Email;

                if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(phoneNumber) || !string.IsNullOrEmpty(email))
                {
                    customerQuery = (from cq in customerQuery
                                     join oru in linqMetaData.OrganizationRoleUser on cq.CustomerId equals oru.OrganizationRoleUserId
                                     join user in linqMetaData.User on oru.UserId equals user.UserId
                                     where (name == "" || (user.FirstName + (user.MiddleName.Trim().Length > 0 ? (" " + user.MiddleName + " ") : " ") + user.LastName).Contains(name))
                                           && (phoneNumber == "" || (user.PhoneCell == filter.PhoneNumber || user.PhoneHome == filter.PhoneNumber || user.PhoneOffice == filter.PhoneNumber))
                                           && (email == "" || user.Email1 == filter.Email)
                                     select cq);
                }

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        customerQuery = from a in customerQuery
                                        where zipRadiusDistance.Contains(a.OrganizationRoleUser.User.Address.ZipId)
                                        select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            customerQuery = from q in customerQuery
                                            where zipIds.Contains(q.OrganizationRoleUser.User.Address.ZipId)
                                            select q;
                        }
                    }
                }


                var customerIdQuery = (from cq in customerQuery select cq.CustomerId);

                var finalQuery = (from cqc in query
                                  join ec in linqMetaData.EventCustomers on new { EventId = (long)cqc.EventId, CustomerId = (long)cqc.CustomerId } equals new { ec.EventId, ec.CustomerId }
                                  join e in linqMetaData.Events on ec.EventId equals e.EventId
                                  join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                  where (cqc.CustomerId.HasValue && customerIdQuery.Contains(cqc.CustomerId.Value))
                                  select new
                                  {
                                      cqc.CallQueueCustomerId,
                                      e.EventDate,
                                      cqc.EventId,
                                      ea.StartTime,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified.HasValue ? cqc.DateModified.Value : cqc.DateCreated
                                  });

                totalRecords = finalQuery.Count();

                IQueryable<long> outputQueryable = null;

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "EventDate");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "EventId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "StartTime");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");
                outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);


                var callQuequeCusomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQuequeCusomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQuequeCusomerIds);

                    return callQuequeCusomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }

                return null;
            }
        }

        public void UpdateCallQueueCustomerStatusByCallQueueId(long callQueueCustomerId, CallQueueStatus status)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CallQueueCustomerEntity()
                {
                    Status = (long)status
                };

                var bucket = new RelationPredicateBucket(CallQueueCustomerFields.CallQueueCustomerId == callQueueCustomerId);

                adapter.UpdateEntitiesDirectly(entity, bucket);
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerByEventId(long eventId, long callQueueId, int noofdaysToIncludeRemoved)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cq in linqMetaData.CallQueueCustomer
                             where cq.CallQueueId == callQueueId && cq.EventId.Value == eventId
                                 && (cq.Status == (long)CallQueueStatus.InProcess || cq.Status == (long)CallQueueStatus.Initial ||
                                 (cq.Status == (long)CallQueueStatus.Removed && cq.DateModified.Value.Date.AddDays(noofdaysToIncludeRemoved) < DateTime.Today))

                             select cq).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(query);
            }
        }

        public CallQueueCustomer GetByCallQueueIdCustomerIdEventId(long callQueueId, long prospectId, long customerId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from cq in linqMetaData.CallQueueCustomer
                              where cq.CallQueueId == callQueueId
                                    && cq.Status == (long)CallQueueStatus.Initial
                                    && (cq.ProspectCustomerId == prospectId || cq.CustomerId == customerId)
                                    && cq.EventId == eventId
                              select cq).FirstOrDefault();

                if (entity == null)
                    return null;

                return Mapper.Map<CallQueueCustomerEntity, CallQueueCustomer>(entity);
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerByHealthPlanId(long healthPlanId, long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cq in linqMetaData.CallQueueCustomer
                             where cq.CallQueueId == callQueueId && cq.HealthPlanId == healthPlanId && cq.EventId == null
                             select cq);

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(query);
            }
        }

        public IEnumerable<CallQueueCustomer> GetOutboundCallRoundCallQueue(OutboundCallQueueFilter filter, int pageNumber, int pageSize, CallQueue callQueue, long criteriaId, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var criteria = (from c in linqMetaData.HealthPlanCallQueueCriteria where c.Id == criteriaId select c).First();

                var customerWithRoundFilters = CallCenterCallRepository.CustomerHaveMoreRoundOfCallsInDays(linqMetaData, criteria.NoOfDays, criteria.RoundOfCalls);

                IQueryable<VwCallQueueCustomerCriteraAssignmentEntity> query = null;
                var customerBeenCalled = AlreadyCalledCustomes(filter, linqMetaData, false);
                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                if (criteria.RoundOfCalls == 0)
                {
                    query = (from cqcca in linqMetaData.VwCallQueueCustomerCriteraAssignment
                             where cqcca.CallQueueId == filter.CallQueueId
                             && (filter.IsMaxAttemptPerHealthPlan ? cqcca.CallCount < maxAttempt : cqcca.Attempts < maxAttempt)
                             && cqcca.CriteriaId == criteriaId
                             && !customerWithRoundFilters.Contains(cqcca.CustomerId) && cqcca.HealthPlanId == filter.HealthPlanId
                             && !customerBeenCalled.Contains(cqcca.CustomerId)
                             select cqcca);
                }
                else
                {
                    query = (from cqcca in linqMetaData.VwCallQueueCustomerCriteraAssignment
                             where cqcca.CallQueueId == filter.CallQueueId && cqcca.Attempts < callQueue.Attempts
                             && cqcca.CriteriaId == criteriaId
                                  && customerWithRoundFilters.Contains(cqcca.CustomerId)
                                 && (cqcca.HealthPlanId == filter.HealthPlanId)
                                  && !customerBeenCalled.Contains(cqcca.CustomerId)
                             select cqcca);
                }

                //var zipIdsString = string.Empty;

                //if (!string.IsNullOrEmpty(filter.ZipCode))
                //    zipIdsString = GetZipIdString(filter.ZipCode, filter.Radius);

                //var customerQuery = (from cp in linqMetaData.VwGetCustomersForCallQueue where cp.IsLanguageBarrier == false select cp);

                //var customTags = string.Empty;

                //if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                //{
                //    customTags = CommaString + filter.CustomCorporateTag + CommaString;
                //    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                //    if (filter.UseCustomTagExclusively)
                //    {
                //        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);
                //        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue
                //                        where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId)
                //                        select ct.CustomerId);
                //    }

                //    customerQuery = customerQuery.Where(cp => tagCustomers.Contains(cp.CustomerId));
                //}

                //if (!string.IsNullOrEmpty(zipIdsString))
                //{
                //    customerQuery = (from cq in customerQuery
                //                     where zipIdsString.IndexOf(CommaString + Convert.ToString(cq.ZipId) + CommaString) >= 0
                //                     select cq);
                //}

                //var customerIdQuery = (from cq in customerQuery select cq.CustomerId);

                var finalQuery = (from cqc in query
                                  // where customerIdQuery.Contains(cqc.CustomerId)
                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified
                                  });

                totalRecords = finalQuery.Count();

                IQueryable<long> outputQueryable = null;

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");
                outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);

                var callQuesCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQuesCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQuesCustomerIds);

                    return callQuesCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }

                return null;
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerForHealthPlanFillEvents(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords,
            bool isNormalExecution = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0 || filter.EventId == null)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var eventId = filter.EventId ?? 0;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var customTags = string.Empty;
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.CriteriaId == criteriaId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                    !(
                                        (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                           || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow)
                                        )
                                        ||
                                        (
                                            cqc.ContactedDate >= refusalDate
                                            && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                            && (
                                                   cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                   cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                               )
                                        )
                                        || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                        || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                    )
                                   )

                             select cqc);


                if (!string.IsNullOrEmpty(filter.ZipCode) && filter.Radius > 0)
                {
                    long zipCodeId = 0;
                    var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                    if (zipCode != null)
                        zipCodeId = zipCode.Id;

                    var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                             where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                             select zrd.DestinationZipId);

                    query = from a in query
                            where zipRadiusDistance.Contains(a.ZipId)
                            select a;
                }
                else if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                    if (zipCodes != null && zipCodes.Any())
                    {
                        var zipIds = zipCodes.Select(z => z.Id).ToArray();
                        query = from q in query
                                where zipIds.Contains(q.ZipId)
                                select q;
                    }
                }

                if (eventId > 0)
                {
                    var zipQuery = (from ez in linqMetaData.EventZip where ez.EventId == eventId select ez.ZipId);
                    query = (from q in query where zipQuery.Contains(q.ZipId) select q);
                }

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = (from q in query where tagCustomers.Contains(q.CustomerId) select q);
                }
                List<long> productList = new List<long>();
                if (eventId > 0)
                {
                    productList = (from ept in linqMetaData.EventProductType
                                   where ept.EventId == eventId && ept.IsActive
                                   select ept.ProductTypeId).ToList();
                    if (!productList.IsNullOrEmpty())
                    {
                        query = (from q in query
                                 where productList.Contains(q.ProductTypeId)
                                 select q);
                    }
                    else
                    {
                        query = (from q in query
                                 where q.ProductTypeId == 0
                                 select q);
                    }
                }

                var finalQuery = (from cqc in query
                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified
                                  });

                if (isNormalExecution)
                    totalRecords = finalQuery.Count();
                else
                    totalRecords = 0;

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);
                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }
                return null;
            }
        }

        public IEnumerable<CallQueueCustomer> GetNoShowCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var customerBeenCalled = AlreadyCalledCustomes(filter, linqMetaData, false);

                var query = (from cqc in linqMetaData.VwCallQueueCustomerCriteraAssignment
                             where cqc.CallQueueId == filter.CallQueueId && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                             && cqc.CriteriaId == criteriaId && cqc.HealthPlanId == filter.HealthPlanId
                             && !customerBeenCalled.Contains(cqc.CustomerId)
                             select cqc);

                //var zipIdsString = string.Empty;

                //if (!string.IsNullOrEmpty(filter.ZipCode))
                //    zipIdsString = GetZipIdString(filter.ZipCode, filter.Radius);

                //var customerQuery = (from cp in linqMetaData.VwGetCustomersForCallQueue where cp.IsLanguageBarrier == false select cp);

                //var customTags = string.Empty;

                //if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                //{
                //    customTags = CommaString + filter.CustomCorporateTag + CommaString;
                //    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                //    if (filter.UseCustomTagExclusively)
                //    {
                //        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                //        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                //    }
                //    customerQuery = customerQuery.Where(cp => tagCustomers.Contains(cp.CustomerId));
                //}

                //if (!string.IsNullOrEmpty(zipIdsString))
                //{
                //    customerQuery = (from cq in customerQuery
                //                     where zipIdsString.IndexOf(CommaString + Convert.ToString(cq.ZipId) + CommaString) >= 0
                //                     select cq);
                //}

                //var customerIdQuery = (from cq in customerQuery select cq.CustomerId);

                var finalQuery = (from cqc in query
                                  // where (customerIdQuery.Contains(cqc.CustomerId))
                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified
                                  });

                totalRecords = finalQuery.Count();

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);

                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }

                return null;
            }
        }

        public IEnumerable<CallQueueCustomer> GetZipRadiusCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var callQueueCustomerIdsInCriteria = (from ca in linqMetaData.HealthPlanCallQueueCriteriaAssignment
                                                      where ca.CriteriaId == criteriaId
                                                      select ca.CallQueueCustomerId);

                var query = (from cqc in linqMetaData.CallQueueCustomer
                             where cqc.CallQueueId == filter.CallQueueId
                                 && cqc.Status == (long)CallQueueStatus.Initial
                                 && cqc.Attempts < maxAttempt
                                 && callQueueCustomerIdsInCriteria.Contains(cqc.CallQueueCustomerId) && (cqc.HealthPlanId.HasValue && cqc.HealthPlanId.Value == filter.HealthPlanId)
                             select cqc);

                var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId);

                var customerQuery = (from cp in linqMetaData.CustomerProfile
                                     where (eligibleCustomerIds.Contains(cp.CustomerId)
                                     && (cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail)
                                     && cp.IsIncorrectPhoneNumber == false && cp.IsLanguageBarrier == false
                                     && (cp.ActivityId != null && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)))
                                     select cp);

                var customTags = string.Empty;
                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;
                    var tagCustomers = (from ct in linqMetaData.CustomerTag where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = CorporateCustomerCustomTagRepository.GetCustomersHavingSingleCustomTags(linqMetaData);

                        tagCustomers = (from ct in linqMetaData.CustomerTag where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }

                    customerQuery = customerQuery.Where(cp => tagCustomers.Contains(cp.CustomerId));
                }

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        customerQuery = from cq in customerQuery
                                        where zipRadiusDistance.Contains(cq.OrganizationRoleUser.User.Address.ZipId)
                                        select cq;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            customerQuery = from cq in customerQuery
                                            where zipIds.Contains(cq.OrganizationRoleUser.User.Address.ZipId)
                                            select cq;
                        }
                    }
                }


                // var customerIdQuery = (from cq in customerQuery select cq.CustomerId);


                var customerIdQuery = (from cq in customerQuery
                                       join oru in linqMetaData.OrganizationRoleUser on cq.CustomerId equals oru.OrganizationRoleUserId
                                       join user in linqMetaData.User on oru.UserId equals user.UserId
                                       where ((user.PhoneCell != string.Empty && user.PhoneCell != null) || (user.PhoneHome != string.Empty && user.PhoneHome != null) || (user.PhoneOffice != string.Empty && user.PhoneOffice != null))
                                       select cq.CustomerId);

                var customerIdsHavingFutureAppointment = (from ec in linqMetaData.EventCustomers
                                                          join e in linqMetaData.Events on ec.EventId equals e.EventId
                                                          where ec.AppointmentId.HasValue && e.EventDate >= DateTime.Now.Date
                                                          select ec.CustomerId);

                var todayCalledCustomerIds = GetTodayCalledCustomerId(linqMetaData);


                var finalQuery = (from cqc in query
                                  let cCount = (from c in linqMetaData.Calls where c.CalledCustomerId != null && c.CalledCustomerId.Value == cqc.CustomerId select c).Count()
                                  where (cqc.CustomerId.HasValue && customerIdQuery.Contains(cqc.CustomerId.Value) && !customerIdsHavingFutureAppointment.Contains(cqc.CustomerId.Value)
                                  && !(cqc.CallDate > DateTime.Today.AddDays(1) && todayCalledCustomerIds.Contains(cqc.CustomerId.Value)))
                                  select new
                                  {
                                      Calls = cCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified.HasValue ? cqc.DateModified.Value : cqc.DateCreated
                                  });

                if (!string.IsNullOrEmpty(customTags))
                {
                    var customerIdMinDatePairQuery = (from ct in linqMetaData.CustomerTag
                                                      where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0
                                                      group ct by ct.CustomerId
                                                          into g
                                                          select new { CustomerId = g.Key, MinimumDate = g.Min(ct => ct.DateCreated) });


                    var finalQueryWithCustomTags = (from cqc in query
                                                    join cmp in customerIdMinDatePairQuery on cqc.CustomerId equals cmp.CustomerId
                                                    where (cqc.CustomerId.HasValue && customerIdQuery.Contains(cqc.CustomerId.Value) && !customerIdsHavingFutureAppointment.Contains(cqc.CustomerId.Value)
                                                    && !(cqc.CallDate > DateTime.Today.AddDays(1) && todayCalledCustomerIds.Contains(cqc.CustomerId.Value)))
                                                    select new
                                                    {
                                                        cqc.CallQueueCustomerId,
                                                        cmp.MinimumDate,
                                                        cqc.CustomerId,
                                                        SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                                        SortingDate = cqc.DateModified.HasValue ? cqc.DateModified.Value : cqc.DateCreated
                                                    });

                    finalQuery = (from fqct in finalQueryWithCustomTags

                                  let callCount = (from c in linqMetaData.Calls
                                                   where c.CalledCustomerId != null && c.CalledCustomerId.Value == fqct.CustomerId && c.DateCreated >= fqct.MinimumDate
                                                   select c).Count()
                                  select new
                                  {
                                      Calls = callCount,
                                      fqct.CallQueueCustomerId,
                                      fqct.CustomerId,
                                      fqct.SortIndex,
                                      fqct.SortingDate
                                  });
                }

                totalRecords = finalQuery.Count();

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);

                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }

                return null;
            }
        }

        public IEnumerable<CallQueueCustomer> GetUncontactedCallQueueCustomers(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, int neverBeenCalledInDays, int noPastAppointmentInDays, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var healthPlan = (from hp in linqMetaData.Account where hp.AccountId == filter.HealthPlanId && hp.IsHealthPlan select hp).First();

                var alreadyCalledCustomes = AlreadyCalledCustomeForUnContacted(healthPlan.Tag, neverBeenCalledInDays, linqMetaData);

                var query = (from cqc in linqMetaData.VwCallQueueCustomerCriteraAssignment
                             where cqc.CallQueueId == filter.CallQueueId
                                 && cqc.CriteriaId == criteriaId
                                 && (cqc.HealthPlanId == filter.HealthPlanId) && !alreadyCalledCustomes.Contains(cqc.CustomerId)
                             select cqc);

                //var zipIdsString = string.Empty;

                //if (!string.IsNullOrEmpty(filter.ZipCode))
                //    zipIdsString = GetZipIdString(filter.ZipCode, filter.Radius);

                //var customerQuery = (from cp in linqMetaData.VwGetCustomersForCallQueue where cp.IsLanguageBarrier == false select cp);

                //var customTags = string.Empty;
                //if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                //{

                //    customTags = CommaString + filter.CustomCorporateTag + CommaString;
                //    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where filter.CorporateTag.Contains(ct.Tag) select ct.CustomerId);

                //    if (filter.UseCustomTagExclusively)
                //    {
                //        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                //        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                //    }

                //    customerQuery = customerQuery.Where(cp => tagCustomers.Contains(cp.CustomerId));
                //}

                //if (!string.IsNullOrEmpty(zipIdsString))
                //{
                //    customerQuery = (from cq in customerQuery
                //                     where zipIdsString.IndexOf(CommaString + Convert.ToString(cq.ZipId) + CommaString) >= 0
                //                     select cq);
                //}

                //var customerIdQuery = (from cq in customerQuery select cq.CustomerId);

                var finalQuery = (from cqc in query
                                  //where (customerIdQuery.Contains(cqc.CustomerId))
                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified
                                  });

                totalRecords = finalQuery.Count();

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);

                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }

                return null;
            }
        }

        public bool DeleteCallQueueCustomersHasNotBeenCalled(long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var bucket = new RelationPredicateBucket(HealthPlanCallQueueCriteriaAssignmentFields.CallQueueId == callQueueId);

                if (adapter.DeleteEntitiesDirectly("HealthPlanCallQueueCriteriaAssignmentEntity", bucket) > 0)
                {
                    var excludeCallQueueCustomerIds = (from cqcc in linqMetaData.CallQueueCustomerCall
                                                       select cqcc.CallQueueCustomerId);

                    var finalCallQueueCustomerIds = (from cqc in linqMetaData.CallQueueCustomer
                                                     where cqc.CallQueueId == callQueueId && !excludeCallQueueCustomerIds.Contains(cqc.CallQueueCustomerId)
                                                     select cqc.CallQueueCustomerId).ToArray();

                    foreach (var callQueueCustomerId in finalCallQueueCustomerIds)
                    {
                        var relationPredicateBucket = new RelationPredicateBucket(CallQueueCustomerFields.CallQueueCustomerId == callQueueCustomerId);

                        adapter.DeleteEntitiesDirectly(typeof(CallQueueCustomerEntity), relationPredicateBucket);
                    }
                }

                return true;
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomersBuCustomerIds(IEnumerable<long> customerIds, long callqueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMetaData.CallQueueCustomer
                                where cqc.CustomerId.HasValue && customerIds.Contains(cqc.CustomerId.Value) &&
                                    cqc.CallQueueId == callqueueId
                                select cqc).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(entities);
            }
        }

        public IEnumerable<CallQueueCustomer> GetCallQueueCustomerByCampaignIdAndHealthPlanId(long campaignId, long healthPlanId, long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cq in linqMetaData.CallQueueCustomer
                             where cq.CallQueueId == callQueueId && cq.HealthPlanId == healthPlanId && cq.CampaignId == campaignId
                             select cq);

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(query);
            }
        }

        public IEnumerable<CallQueueCustomer> GetMailRoundCallqueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords, bool isNormalExecution = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.CriteriaId == criteriaId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (
                                            cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                            !(
                                                (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                            || (
                                                    cqc.ContactedDate >= refusalDate
                                                    && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                    && (
                                                           cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                           cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                       )
                                                )
                                            || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                            || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                            )
                                    )
                             select cqc);

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        query = from a in query
                                where zipRadiusDistance.Contains(a.ZipId)
                                select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.ZipId)
                                    select q;
                        }
                    }
                }

                if (filter.DirectMailDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                if (filter.DirectMailStartDate.HasValue && filter.DirectMailEndDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue
                                             where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailStartDate.Value && dm.MailDate < filter.DirectMailEndDate.Value.AddDays(1)
                                             select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }
                else if (filter.DirectMailStartDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailStartDate.Value select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }
                else if (filter.DirectMailEndDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate < filter.DirectMailEndDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                var customTags = string.Empty;

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = query.Where(cp => tagCustomers.Contains(cp.CustomerId));
                }

                var finalQuery = (from cqc in query

                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified
                                  });

                if (isNormalExecution)
                    totalRecords = finalQuery.Count();
                else
                    totalRecords = 0;

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);
                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return
                        callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }
                return null;
            }
        }

        private IQueryable<long> GetTodayCalledCustomerId(LinqMetaData linqMetaData)
        {
            var customerIds = (from c in linqMetaData.VwGetCallsForCallQueue
                               where c.TimeCreated.Date == DateTime.Today && c.Status != (long)CallStatus.Initiated
                               select c.CalledCustomerId);

            return customerIds;
        }

        public IEnumerable<CallQueueCustomer> GetLanguageBarrierCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords,
            bool isNormalExecution = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.CriteriaId == criteriaId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == true && cqc.LanguageBarrierMarkedDate >= startOfYear)
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString())
                                    || (cqc.Disposition == ProspectCustomerTag.LanguageBarrier.ToString() && cqc.ContactedDate < DateTime.Today)
                                    || !(
                                        (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                        || (
                                                cqc.ContactedDate >= refusalDate
                                                && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                && (
                                                        cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                        cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                    )
                                            )
                                            || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                            || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                            )
                                        )

                             select cqc);

                /*var zipIdsString = string.Empty;

                if (!string.IsNullOrEmpty(filter.ZipCode))
                    zipIdsString = GetZipIdString(filter.ZipCode, filter.Radius);

                if (!string.IsNullOrWhiteSpace(zipIdsString))
                {
                    query = (from q in query
                             where zipIdsString.IndexOf(CommaString + Convert.ToString(q.ZipId) + CommaString) >= 0
                             select q);
                }*/

                if (!string.IsNullOrEmpty(filter.ZipCode) && filter.Radius > 0)
                {
                    long zipCodeId = 0;
                    var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                    if (zipCode != null)
                        zipCodeId = zipCode.Id;

                    var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                             where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                             select zrd.DestinationZipId);

                    query = from a in query
                            where zipRadiusDistance.Contains(a.ZipId)
                            select a;
                }
                else if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                    if (zipCodes != null && zipCodes.Any())
                    {
                        var zipIds = zipCodes.Select(z => z.Id).ToArray();
                        query = from q in query
                                where zipIds.Contains(q.ZipId)
                                select q;
                    }
                }

                var customTags = string.Empty;

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = query.Where(cp => tagCustomers.Contains(cp.CustomerId));
                }

                var eventId = filter.EventId ?? 0;
                List<long> productList = new List<long>();
                if (eventId > 0)
                {
                    productList = (from ept in linqMetaData.EventProductType
                                   where ept.EventId == eventId && ept.IsActive
                                   select ept.ProductTypeId).ToList();

                    if (!productList.IsNullOrEmpty())
                    {
                        query = (from q in query
                                 where productList.Contains(q.ProductTypeId)
                                 select q);
                    }
                    else
                    {
                        query = (from q in query
                                 where q.ProductTypeId == 0
                                 select q);
                    }
                }

                var finalQuery = (from cqc in query
                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified
                                  });

                if (isNormalExecution)
                    totalRecords = finalQuery.Count();
                else
                    totalRecords = 0;

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);
                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }
                return null;
            }
        }

        private IQueryable<long> AlreadyCalledCustomeForUnContacted(string healthPlanTag, int neverBeenCalledInDays, LinqMetaData linqMetaData)
        {
            var alreadyCalledCustomes = (from c in linqMetaData.VwGetCallsForCallQueue
                                         where c.Tag == healthPlanTag &&
                                         ((c.DateCreated > DateTime.Now.Date.AddDays(-neverBeenCalledInDays) && c.Status != (long)CallStatus.CallSkipped)
                                             || (c.DateCreated > DateTime.Today && c.DateCreated < DateTime.Today.AddDays(1) && c.Status == (long)CallStatus.CallSkipped))
                                         select c.CalledCustomerId);
            return alreadyCalledCustomes;
        }

        private IQueryable<long> AlreadyCalledCustomes(OutboundCallQueueFilter filter, LinqMetaData linqMetaData, bool isLanguageBarrier)
        {
            var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
            var callBackLater = ProspectCustomerTag.CallBackLater.ToString();
            var notInterested = ProspectCustomerTag.NotInterested.ToString();
            var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
            var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
            var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
            var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

            //var customerToCallBackToday = (from pc in linqMetaData.ProspectCustomer
            //                               where
            //                                   pc.Tag == ProspectCustomerTag.CallBackLater.ToString() && pc.CallBackRequestedDate.HasValue &&
            //                                   pc.CallBackRequestedDate.Value < DateTime.Now
            //                               select pc.CustomerId);

            //if (isLanguageBarrier)
            //{
            //    customerToCallBackToday = (from pc in linqMetaData.ProspectCustomer
            //                               where
            //                                  (pc.Tag == callBackLater && pc.CallBackRequestedDate.HasValue && pc.CallBackRequestedDate.Value < DateTime.Now)
            //                                  || (pc.Tag == languageBarrier && pc.ContactedDate.HasValue && pc.ContactedDate.Value < DateTime.Today)

            //                               select pc.CustomerId);
            //}

            var healthPlan = (from hp in linqMetaData.Account where hp.AccountId == filter.HealthPlanId && hp.IsHealthPlan select hp).First();

            var alreadyCalledCustomes = (from c in linqMetaData.VwGetCallsForSuppression
                                         where c.AccountId == healthPlan.AccountId &&
                                         ((c.DateCreated >= DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1)) && c.Status == (long)CallStatus.VoiceMessage)
                                            || (c.DateCreated >= DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1)) && (c.Status != (long)CallStatus.CallSkipped && c.Status != (long)CallStatus.VoiceMessage) && (c.Disposition == notInterested || c.Disposition == declinedMobileAndHomeVisit || c.Disposition == recentlySawDoc || c.Disposition == transportationIssue || c.Disposition == declinedMammoNotinterestedInMammogram))
                                            || (c.DateCreated >= DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1)) && c.Status != (long)CallStatus.CallSkipped && (c.Status != (long)CallStatus.VoiceMessage))
                                        )
                                         select c.CalledCustomerId);

            return alreadyCalledCustomes;
        }

        public bool IsCallQueueCustomerCalledToday(long customerId, long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callCount = (from c in linqMetaData.Calls
                                 where (c.CalledCustomerId != null && c.CalledCustomerId.Value == customerId && c.TimeCreated.HasValue && c.TimeCreated.Value.Date == DateTime.Today && c.Status != (long)CallStatus.Initiated)
                                 select c).Count();

                if (callCount > 0)
                {
                    var callbackToday = (from cqc in linqMetaData.CallQueueCustomer
                                         join c in linqMetaData.Calls on cqc.CustomerId equals c.CalledCustomerId
                                         where cqc.CustomerId == customerId && cqc.CallDate > DateTime.Today && cqc.CallDate < DateTime.Today.AddDays(1)
                                          && c.TimeCreated.HasValue && c.TimeCreated.Value.Date == DateTime.Today && c.Status != (long)CallStatus.Initiated
                                          && c.Disposition == ProspectCustomerTag.CallBackLater.ToString()
                                         select cqc
                                         ).FirstOrDefault();

                    if (callbackToday != null)
                        return false;

                    return true;

                }

                return false;
            }
        }

        //public CallQueueCustomersStatsViewModel GetRejectedCallQueueCustomers(OutboundCallQueueFilter filter, CallQueue callQueue)
        //{
        //    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
        //        var notInterested = ProspectCustomerTag.NotInterested.ToString();
        //        var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
        //        var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();

        //        var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
        //        var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
        //        var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

        //        var linqMetaData = new LinqMetaData(adapter);

        //        var maxAttemptForQueue = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

        //        var query = (from cqcca in linqMetaData.VwCallQueueCustomerCriteraAssignmentForStats
        //                     where cqcca.CallQueueId == filter.CallQueueId && cqcca.CriteriaId == filter.CriteriaId
        //                     && cqcca.HealthPlanId == filter.HealthPlanId
        //                     select cqcca);

        //        var zipIdsString = string.Empty;
        //        var customTags = string.Empty;

        //        var eventId = filter.EventId ?? 0;

        //        if (eventId > 0)
        //        {
        //            var zipQuery = (from ez in linqMetaData.EventZip where ez.EventId == eventId select ez.ZipId);
        //            query = (from q in query where zipQuery.Contains(q.ZipId) select q);
        //        }

        //        if (!string.IsNullOrEmpty(filter.ZipCode) || !string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
        //        {
        //            if (!string.IsNullOrEmpty(filter.ZipCode))
        //            {
        //                zipIdsString = GetZipIdString(filter.ZipCode, filter.Radius);

        //                if (!string.IsNullOrEmpty(zipIdsString))
        //                {
        //                    query = (from q in query
        //                             where zipIdsString.IndexOf(CommaString + Convert.ToString(q.ZipId) + CommaString) >= 0
        //                             select q);
        //                }
        //            }

        //            if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
        //            {
        //                customTags = CommaString + filter.CustomCorporateTag + CommaString;

        //                var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

        //                if (filter.UseCustomTagExclusively)
        //                {
        //                    var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

        //                    tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
        //                }

        //                query = (from q in query where tagCustomers.Contains(q.CustomerId) select q);
        //            }
        //        }

        //        if (filter.DirectMailDate.HasValue)
        //        {
        //            var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

        //            query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
        //        }

        //        var expectedCustomers = query.Count();
        //        var showLanguageBarrierCount = callQueue.Category == HealthPlanCallQueueCategory.LanguageBarrier;

        //        var maxAttempt = 0;

        //        if (filter.IsMaxAttemptPerHealthPlan)
        //        {
        //            maxAttempt = (from q in query
        //                          where q.CallCount >= maxAttemptForQueue
        //                          select q.CustomerId).Distinct().Count();

        //            query = (from q in query where q.CallCount < maxAttemptForQueue select q);
        //        }
        //        else
        //        {
        //            maxAttempt = (from q in query
        //                          where q.Attempts >= maxAttemptForQueue
        //                          select q.CustomerId).Distinct().Count();

        //            query = (from q in query where q.Attempts < maxAttemptForQueue select q);
        //        }

        //        var notEligible = (from cqc in query
        //                           where (cqc.IsEligble == false)
        //                           select cqc.CustomerId).Distinct().Count();

        //        var doNotContact = (from cqc in query
        //                            where cqc.IsEligble
        //                                  && ((cqc.DoNotContactUpdateDate > startOfYear
        //                                        && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall))
        //                                   || (cqc.DoNotContactUpdateSource == (long)DoNotContactSource.Manual && cqc.DoNotContactTypeId != (long)DoNotContactType.DoNotMail))
        //                            select cqc.CustomerId).Distinct().Count();

        //        var uploadActivity = (from cp in query
        //                              where cp.IsEligble && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                              && (cp.ActivityId == (long)UploadActivityType.OnlyMail || cp.ActivityId == (long)UploadActivityType.DoNotCallDoNotMail)
        //                              select cp.CustomerId).Distinct().Count();

        //        var languageBarrier = 0;
        //        var incorrectPhone = 0;
        //        var noPhone = 0;
        //        var appointmentBooked = 0;
        //        var callBackForFutureDate = 0;
        //        var refusedCount = 0;
        //        var customerNoEventsInAreaCount = 0;
        //        var suppressedCustomers = 0;

        //        var eventZip = (from aez in linqMetaData.AccountEventZip where aez.AccountId == filter.HealthPlanId select aez.ZipId);
        //        var refusalTags = GetRefusalTag();


        //        if (!showLanguageBarrierCount)
        //        {
        //            languageBarrier = (from cp in query
        //                               where cp.IsEligble
        //                               && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                               && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                               && (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear)
        //                               select cp.CustomerId).Distinct().Count();

        //            incorrectPhone = (from cp in query
        //                              where cp.IsEligble
        //                              && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)

        //                              && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                              && (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= startOfYear)
        //                              && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
        //                              select cp.CustomerId).Distinct().Count();

        //            noPhone = (from cp in query
        //                       where cp.IsEligble
        //                       && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                       && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                       && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
        //                       && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                       && ((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))

        //                       select cp.CustomerId).Distinct().Count();

        //            appointmentBooked = (from cp in query
        //                                 where cp.IsEligble == true
        //                                    && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                    && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                    && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
        //                                    && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                    && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
        //                                    && (cp.AppointmentDate >= startOfYear)
        //                                 select cp.CustomerId).Distinct().Count();

        //            refusedCount = (from cp in query

        //                            where cp.IsEligble
        //                                            && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
        //                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
        //                                            && (cp.AppointmentDate <= startOfYear)
        //                                            && (cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
        //                            select cp.CustomerId).Distinct().Count();

        //            callBackForFutureDate = (from cp in query
        //                                     where cp.IsEligble == true
        //                                        && (cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail || (cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual))
        //                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
        //                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
        //                                        && (cp.AppointmentDate <= startOfYear)
        //                                        && cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now
        //                                     select cp.CustomerId).Distinct().Count();

        //            customerNoEventsInAreaCount = (from cp in query
        //                                           where cp.IsEligble == true
        //                                                    && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                                    && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                                    && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
        //                                                    && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                                    && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
        //                                                    && (cp.AppointmentDate <= startOfYear)
        //                                                    && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
        //                                                    && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
        //                                                    && !(eventZip.Contains(cp.ZipId))
        //                                           select cp.CustomerId).Distinct().Count();

        //            suppressedCustomers = (from cp in query
        //                                   where cp.IsEligble == true
        //                                         && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                         && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                                 && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
        //                                                 && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                                 && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
        //                                                 && (cp.AppointmentDate <= startOfYear)
        //                                                 && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
        //                                                 && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
        //                                                 && (eventZip.Contains(cp.ZipId))
        //                                            &&
        //                                            (
        //                                                cp.AppointmentCancellationDate >= othersFilterDate
        //                                                || (cp.NoShowDate >= othersFilterDate)
        //                                                || (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus == (long)CallStatus.VoiceMessage)
        //                                                || (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == notInterested || cp.Disposition == recentlySawDoc || cp.Disposition == transportationIssue))
        //                                                || (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.Initiated && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString() && cp.Disposition != (ProspectCustomerTag.LanguageBarrier.ToString())))
        //                                                || (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.CallSkipped || cp.CallStatus == (long)CallStatus.Initiated))
        //                                                )
        //                                   select cp.CustomerId).Distinct().Count();

        //        }
        //        else
        //        {
        //            incorrectPhone = (from cp in query
        //                              where cp.IsEligble
        //                              && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)

        //                              && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                              && (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= startOfYear)
        //                              select cp.CustomerId).Distinct().Count();

        //            noPhone = (from cp in query
        //                       where cp.IsEligble
        //                       && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                       && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                       && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                       && ((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
        //                       select cp.CustomerId).Distinct().Count();

        //            appointmentBooked = (from cp in query
        //                                 where cp.IsEligble == true
        //                                    && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                    && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                    && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                    && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
        //                                    && (cp.AppointmentDate >= startOfYear)
        //                                 select cp.CustomerId).Distinct().Count();

        //            refusedCount = (from cp in query
        //                            where cp.IsEligble
        //                                            && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
        //                                            && (cp.AppointmentDate <= startOfYear)
        //                                            && (cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
        //                            select cp.CustomerId).Distinct().Count();

        //            callBackForFutureDate = (from cp in query
        //                                     where cp.IsEligble == true
        //                                        && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)

        //                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
        //                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                        && (cp.AppointmentDate <= startOfYear)
        //                                        && cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now
        //                                     select cp.CustomerId).Distinct().Count();

        //            customerNoEventsInAreaCount = (from cp in query
        //                                           where cp.IsEligble == true
        //                                                    && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                                    && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                                    && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
        //                                                    && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                                    && (cp.AppointmentDate <= startOfYear)
        //                                                    && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
        //                                                    && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
        //                                                    && !(eventZip.Contains(cp.ZipId))
        //                                           select cp.CustomerId).Distinct().Count();

        //            suppressedCustomers = (from cp in query
        //                                   where cp.IsEligble == true
        //                                         && ((cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
        //                                         && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
        //                                                 && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
        //                                                 && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
        //                                                 && (cp.AppointmentDate <= startOfYear)
        //                                                 && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
        //                                                 && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
        //                                                 && (eventZip.Contains(cp.ZipId))
        //                                         && (
        //                                                cp.AppointmentCancellationDate >= othersFilterDate
        //                                                || (cp.NoShowDate >= othersFilterDate)
        //                                                || (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus == (long)CallStatus.VoiceMessage)
        //                                                || (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == notInterested || cp.Disposition == recentlySawDoc || cp.Disposition == transportationIssue))
        //                                                || (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.Initiated && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString() && cp.Disposition != (ProspectCustomerTag.LanguageBarrier.ToString())))
        //                                                || (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.CallSkipped || cp.CallStatus == (long)CallStatus.Initiated))
        //                                             )
        //                                   select cp.CustomerId).Distinct().Count();
        //        }

        //        return new CallQueueCustomersStatsViewModel
        //        {
        //            TotalCustomerInCallQueue = expectedCustomers,
        //            NotEligible = notEligible,
        //            AppointmentBooked = appointmentBooked,
        //            DoNotContact = doNotContact,
        //            Activity = uploadActivity,
        //            Refused = refusedCount,
        //            NoPhone = noPhone,
        //            IncorrectPhoneNumber = incorrectPhone,
        //            CalledInGivenNoOfDays = suppressedCustomers,
        //            MaxAttempt = maxAttempt,
        //            LanguageBarrier = languageBarrier,
        //            CallbackLater = callBackForFutureDate,
        //            CustomerNoEventsInArea = customerNoEventsInAreaCount
        //        };
        //    }
        //}

        private IEnumerable<string> GetRefusalTag()
        {
            var homeVisitRequested = ProspectCustomerTag.HomeVisitRequested.ToString();
            var doNotContact = ProspectCustomerTag.DoNotCall.ToString();
            var deceased = ProspectCustomerTag.Deceased.ToString();
            var mobilityIssue = ProspectCustomerTag.MobilityIssue.ToString();
            var inLongTermCareNursingHome = ProspectCustomerTag.InLongTermCareNursingHome.ToString();
            var mobilityIssue_LeftMessageWithOther = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString();
            var noLongeronInsuracnePlan = ProspectCustomerTag.NoLongeronInsurancePlan.ToString();
            var debilitatingDisease = ProspectCustomerTag.DebilitatingDisease.ToString();

            string[] refusalTag = { homeVisitRequested, doNotContact, deceased, mobilityIssue, inLongTermCareNursingHome, mobilityIssue_LeftMessageWithOther, noLongeronInsuracnePlan, debilitatingDisease };
            //return query;
            return refusalTag;
        }

        public CallQueueEstimatedCustomerReportModel GetCallQueueEstimatedNumbers(OutboundCallQueueFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var isLanguageBarrier = callQueue.Category == HealthPlanCallQueueCategory.LanguageBarrier;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                string[] refusedforYear =
                {
                    "HomeVisitRequested", "DoNotCall", "MobilityIssue", "InLongTermCareNursingHome",
                    "DebilitatingDisease", "MobilityIssues_LeftMessageWithOther", "NoLongeronInsurancePlan"
                };

                var zipIds = (from aez in linqMetaData.AccountEventZip where aez.AccountId == filter.HealthPlanId select aez.ZipId);
                var substituteZipIds = (from aez in linqMetaData.AccountEventZipSubstitute where aez.AccountId == filter.HealthPlanId select aez.ZipId);

                var query = (from cqc in linqMetaData.VwCallQueueCustomerCriteraAssignmentForStats
                             where cqc.CriteriaId == filter.CriteriaId
                                   && (zipIds.Contains(cqc.ZipId) || substituteZipIds.Contains(cqc.ZipId))
                                   && (cqc.IsEligble)
                                   && (cqc.TargetedYear == startOfYear.Year && cqc.IsTargeted == true)
                                   && (cqc.ActivityId != (long)UploadActivityType.MailOnly)

                                   && isLanguageBarrier ? (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate >= startOfYear)
                                   : (!cqc.IsLanguageBarrier || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.IsIncorrectPhoneNumber == false || (cqc.IsIncorrectPhoneNumber && cqc.IncorrectPhoneNumberMarkedDate < startOfYear))
                                   && (cqc.PhoneCell != "" || cqc.PhoneOffice != "" || cqc.PhoneOffice != "")
                                   && (cqc.DoNotContactTypeId <= 0 || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)// || (cqc.ContactedDate <= startOfYear && cqc.DoNotContactTypeId != (long)DoNotContactType.DoNotMail)
                                   &&
                                    !(
                                        cqc.Disposition == ProspectCustomerTag.Deceased.ToString()
                                        || (cqc.ContactedDate > startOfYear && refusedforYear.Contains(cqc.Disposition))
                                    )
                                    && !(cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cqc.ContactedDate > DateTime.Now)
                                    && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= othersFilterDate)
                                    && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= othersFilterDate)
                                    && (cqc.AppointmentDate < startOfYear)
                                    && (
                                            cqc.ContactedDate == new DateTime(1900, 1, 1) ||
                                            !(
                                                (cqc.ContactedDate >= leftVoiceMailDate && cqc.CallStatus == (long)CallStatus.VoiceMessage)
                                            || (
                                                    cqc.ContactedDate >= refusalDate
                                                    && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                    && (
                                                           cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                           cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                       )
                                                )
                                            )
                                      )
                                && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                             select cqc);

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        query = from a in query
                                where zipRadiusDistance.Contains(a.ZipId)
                                select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipCodeIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipCodeIds.Contains(q.ZipId)
                                    select q;
                        }
                    }
                }


                if (filter.DirectMailDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    filter.CustomCorporateTag = string.Join(",", filter.CustomTags);
                }

                var customTags = string.Empty;

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    query = query.Where(cp => tagCustomers.Contains(cp.CustomerId));
                }

                var actualCustomers = (from c in query select c.CustomerId).Count();

                var callQueueEstimatedCustomer = new CallQueueEstimatedCustomer { TodaysCustomers = actualCustomers };

                //callQueueEstimatedCustomer.TomorrowCustomers = GetUpcomingCallQueueCustomer(actualCustomers, filter, linqMetaData, skippedCustomer, 1, isLanguageBarrier);
                //callQueueEstimatedCustomer.DayAfterTomorrowCustomers = GetUpcomingCallQueueCustomer(actualCustomers, filter, linqMetaData, skippedCustomer, 2, isLanguageBarrier);
                //callQueueEstimatedCustomer.OvermorrowCustomers = GetUpcomingCallQueueCustomer(actualCustomers, filter, linqMetaData, skippedCustomer, 3, isLanguageBarrier);

                var callQueueEstimatedCustomerReportModel = new CallQueueEstimatedCustomerReportModel();
                var organization = _organizationRepository.GetOrganizationbyId(filter.HealthPlanId);
                callQueueEstimatedCustomerReportModel.CallQueueEstimatedCustomer = callQueueEstimatedCustomer;
                callQueueEstimatedCustomerReportModel.Filter = filter;
                callQueueEstimatedCustomerReportModel.HealthPlanName = organization.Name;
                callQueueEstimatedCustomerReportModel.CallQueueCategory = callQueue.Category;
                callQueueEstimatedCustomerReportModel.CallQueueName = callQueue.Name;

                return callQueueEstimatedCustomerReportModel;
            }
        }

        private long GetUpcomingCallQueueCustomer(long actualCustomers, OutboundCallQueueFilter filter, LinqMetaData linqMetaData, long skippedCustomer, int NoOfdaysFor, bool isLanguageBarrier)
        {
            var notInterested = ProspectCustomerTag.NotInterested.ToString();
            var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
            var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
            var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
            var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();


            var cancelledCustomers = (from eacl in linqMetaData.EventAppointmentCancellationLog
                                      join ec in linqMetaData.EventCustomers on eacl.EventCustomerId equals ec.EventCustomerId
                                      where eacl.DateCreated < DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - NoOfdaysFor) + 1)
                                      select ec.CustomerId);


            var callBackDate = DateTime.Today.AddDays(NoOfdaysFor);
            var customerToCallBack = (from pc in linqMetaData.ProspectCustomer
                                      join cp in linqMetaData.CustomerProfile on pc.CustomerId.Value equals cp.CustomerId
                                      where cp.IsLanguageBarrier == isLanguageBarrier
                                      && pc.CustomerId.HasValue
                                      && pc.Tag == ProspectCustomerTag.CallBackLater.ToString() && pc.CallBackRequestedDate.HasValue
                                      && pc.CallBackRequestedDate.Value >= callBackDate && pc.CallBackRequestedDate.Value < callBackDate.AddDays(1)
                                      select pc.CustomerId);

            var suppressedCustomes = (from c in linqMetaData.VwGetCallsForSuppression
                                      where c.AccountId == filter.HealthPlanId &&
                                      ((c.DateCreated < DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - NoOfdaysFor) + 1) && c.Status == (long)CallStatus.VoiceMessage)
                                         || (c.DateCreated < DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - NoOfdaysFor) + 1) && (c.Status != (long)CallStatus.CallSkipped && c.Status != (long)CallStatus.VoiceMessage) && (c.Disposition == notInterested || c.Disposition == declinedMobileAndHomeVisit || c.Disposition == recentlySawDoc || c.Disposition == transportationIssue || c.Disposition == declinedMammoNotinterestedInMammogram))
                                         || (c.DateCreated < DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - NoOfdaysFor) + 1) && c.Status != (long)CallStatus.CallSkipped && (c.Status != (long)CallStatus.VoiceMessage))
                                     )
                                     && (c.Status != (long)CallStatus.IncorrectPhoneNumber || c.Status != (long)CallStatus.TalkedtoOtherPerson)
                                     && c.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                      select c.CalledCustomerId);

            var upcomingCustomers = (from cqc in linqMetaData.VwGetCallQueueCustomers
                                     where cqc.CallQueueId == filter.CallQueueId
                                     && cqc.CriteriaId == filter.CriteriaId
                                     && cqc.CriteriaId == filter.CriteriaId
                                     && (cqc.HealthPlanId == filter.HealthPlanId)
                                     && cqc.IsLanguageBarrier == isLanguageBarrier
                                     select cqc);

            var customTags = string.Empty;

            if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
            {
                customTags = CommaString + filter.CustomCorporateTag + CommaString;

                var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);
                upcomingCustomers = upcomingCustomers.Where(cp => tagCustomers.Contains(cp.CustomerId));
            }

            if (!string.IsNullOrEmpty(filter.ZipCode))
            {
                if (filter.Radius > 0)
                {
                    long zipCodeId = 0;
                    var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                    if (zipCode != null)
                        zipCodeId = zipCode.Id;

                    var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                             where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                             select zrd.DestinationZipId);

                    upcomingCustomers = from a in upcomingCustomers
                                        where zipRadiusDistance.Contains(a.ZipId)
                                        select a;
                }
                else
                {
                    var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                    if (zipCodes != null && zipCodes.Any())
                    {
                        var zipIds = zipCodes.Select(z => z.Id).ToArray();
                        upcomingCustomers = from q in upcomingCustomers
                                            where zipIds.Contains(q.ZipId)
                                            select q;
                    }
                }
            }

            if (filter.DirectMailDate.HasValue)
            {
                var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                upcomingCustomers = (from q in upcomingCustomers where mailedCustomerIds.Contains(q.CustomerId) select q);
            }

            var upcomingCustomersCount = (from cqc in upcomingCustomers
                                          where cancelledCustomers.Contains(cqc.CustomerId)
                                              || customerToCallBack.Contains(cqc.CustomerId)
                                              || suppressedCustomes.Contains(cqc.CustomerId)
                                          select cqc.CustomerId).Count();

            return actualCustomers + skippedCustomer + upcomingCustomersCount;
        }

        public void UpdateCallqueueCustomerByCustomerId(CallQueueCustomerCallDetailsEditModel model, long customerId, bool setOtherCustomerStatus = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var confirmQueueId = (from cc in linqMetaData.CallQueue
                                      where cc.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                                      select cc.CallQueueId).SingleOrDefault();

                var entities = (from cqc in linqMetaData.CallQueueCustomer
                                where cqc.CustomerId.HasValue && cqc.CustomerId.Value == customerId
                                select cqc).ToArray();

                if (entities.Any())
                {
                    foreach (var entity in entities)
                    {
                        if (setOtherCustomerStatus == false && model.CallQueueCustomerId != entity.CallQueueCustomerId)
                            continue;

                        if (model.CallQueueCustomerId == entity.CallQueueCustomerId)
                        {
                            entity.Status = model.CallQueueStatus;
                            if (!model.IsCallSkipped)
                            {
                                entity.Attempts = model.Attempt > 0 ? model.Attempt : entity.Attempts;
                                entity.CallCount = model.Attempt > 0 ? (entity.CallCount ?? 0) + 1 : entity.CallCount;
                            }

                            entity.Disposition = model.Disposition;
                        }



                        entity.ContactedDate = DateTime.Now;
                        entity.CallDate = model.CallDate.HasValue ? model.CallDate.Value : DateTime.Now.AddDays(30);
                        entity.ModifiedByOrgRoleUserId = model.ModifiedByOrgRoleUserId;

                        if (!(model.CallQueueId > 0 && model.CallQueueId == confirmQueueId && string.IsNullOrEmpty(model.Disposition)))
                            entity.Disposition = model.Disposition;

                        entity.CallStatus = model.CallStatusId;
                        entity.CallBackRequestedDate = model.CallbackDate;
                        entity.IsNew = false;
                        entity.DateModified = DateTime.Now;

                        adapter.SaveEntity(entity);
                    }
                }
            }
        }

        public void UpdateCustomerField(CallQueueCustomerPubViewModel customer)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeataData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMeataData.CallQueueCustomer
                                where cqc.CustomerId.HasValue && cqc.CustomerId.Value == customer.CustomerId
                                select cqc).ToArray();

                if (entities.Any())
                {
                    foreach (var entity in entities)
                    {
                        entity.FirstName = customer.FirstName;
                        entity.MiddleName = customer.MiddleName;
                        entity.LastName = customer.LastName;
                        entity.PhoneCell = customer.PhoneCell;
                        entity.PhoneHome = customer.PhoneHome;
                        entity.PhoneOffice = customer.PhoneOffice;
                        entity.DoNotContactTypeId = customer.DoNotContactTypeId;
                        entity.DoNotContactReasonId = customer.DoNotContactReasonId;
                        entity.DoNotContactUpdateDate = customer.DoNotContactUpdateDate;
                        entity.ActivityId = customer.ActivityId;
                        //entity.IsEligble = customer.IsEligible;
                        entity.IsIncorrectPhoneNumber = customer.IsIncorrectPhoneNumber;
                        entity.IsLanguageBarrier = customer.IsLanguageBarrier;
                        entity.ZipCode = customer.ZipCode;
                        entity.ZipId = customer.ZipId;
                        entity.Tag = customer.Tag;
                        entity.IsNew = false;
                        entity.DoNotContactUpdateSource = customer.DoNotContactUpdateSource;
                        entity.LanguageBarrierMarkedDate = customer.IsLanguageBarrier ? customer.LanguageBarrierMarkedDate : (DateTime?)null;
                        entity.IncorrectPhoneNumberMarkedDate = customer.IsIncorrectPhoneNumber ? customer.IncorrectPhoneNumberMarkedDate : (DateTime?)null;
                        entity.LanguageId = customer.LanguageId;
                        adapter.SaveEntity(entity, false);
                    }
                }
            }
        }

        public void UpdateFutureAppointment(FutureAppointmentFlagViewModel model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeataData = new LinqMetaData(adapter);

                var callQueueId =
                   (from cq in linqMeataData.CallQueue
                    where cq.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                    select cq.CallQueueId).First();

                var entities = (from cqc in linqMeataData.CallQueueCustomer
                                where cqc.CustomerId.HasValue && cqc.CustomerId.Value == model.CustomerId && cqc.CallQueueId != callQueueId
                                select cqc).ToArray();

                if (entities.Any())
                {
                    foreach (var entity in entities)
                    {
                        entity.AppointmentDate = model.FutureAppointmentDate;
                        entity.AppointmentCancellationDate = null;
                        entity.NoShowDate = null;
                        entity.IsNew = false;
                        adapter.SaveEntity(entity, false);
                    }
                }
            }
        }

        public void UpdateCancelAppointment(CancelAppointmentFlagViewModel model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeataData = new LinqMetaData(adapter);

                var callQueueId =
                   (from cq in linqMeataData.CallQueue
                    where cq.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                    select cq.CallQueueId).First();

                var entities = (from cqc in linqMeataData.CallQueueCustomer
                                where cqc.CustomerId.HasValue && cqc.CustomerId.Value == model.CustomerId && cqc.CallQueueId != callQueueId
                                select cqc).ToArray();


                if (entities.Any())
                {
                    foreach (var entity in entities)
                    {
                        if (model.HasFutureAppointment == false)
                        {
                            entity.AppointmentCancellationDate = model.CancelAppoinemtDate;
                            entity.NoShowDate = null;
                            entity.AppointmentDate = null;
                        }
                        else
                        {
                            entity.AppointmentCancellationDate = null;
                            entity.NoShowDate = null;
                            entity.AppointmentDate = model.NextFutureAppointmentDate;
                        }

                        entity.IsNew = false;
                        adapter.SaveEntity(entity, false);
                    }
                }
            }
        }

        public IEnumerable<CallQueueCustomerCriteraAssignmentForStats> GetCallQueueCustomersForRejectedList(IEnumerable<long> customerIds, long campaignId, long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from cqcca in linqMetaData.VwCallQueueCustomerCriteraAssignmentForStats
                             where cqcca.CampaignId == campaignId
                             && cqcca.HealthPlanId == healthPlanId
                             && customerIds.Contains(cqcca.CustomerId)
                             select cqcca).ToArray();

                return Mapper.Map<IEnumerable<VwCallQueueCustomerCriteraAssignmentForStatsEntity>, IEnumerable<CallQueueCustomerCriteraAssignmentForStats>>(query);
            }
        }

        public IEnumerable<long> GetAccountZip(long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventZip = (from aez in linqMetaData.AccountEventZip where aez.AccountId == healthPlanId select aez.ZipId).ToArray();
                var substituteZip = (from aezs in linqMetaData.AccountEventZipSubstitute where aezs.AccountId == healthPlanId select aezs.ZipId).ToArray();

                eventZip = eventZip.Concat(substituteZip).ToArray();

                return eventZip;
            }
        }

        public void ReleaseCallQueueCustomerFromLock(long customerId, long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMeataData = new LinqMetaData(adapter);

                var entities = (from cqc in linqMeataData.CallQueueCustomer
                                where cqc.CustomerId.HasValue && cqc.CustomerId.Value == customerId
                                select cqc).ToArray();

                if (entities.Any())
                {
                    foreach (var entity in entities)
                    {
                        if (entity.CallQueueCustomerId == callQueueCustomerId)
                            entity.Attempts = entity.Attempts + 1;

                        entity.CallCount = (entity.CallCount ?? 0) + 1;

                        entity.IsNew = false;
                        entity.Status = (long)CallQueueStatus.Initial;

                        adapter.SaveEntity(entity, false);
                    }
                }
            }
        }

        public IEnumerable<CallQueueCustomer> GetByHealthPlanIdAndCallQueueId(long healthPlanId, long callQueueId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cq in linqMetaData.CallQueueCustomer
                             where cq.CallQueueId == callQueueId && cq.HealthPlanId == healthPlanId
                             select cq);

                return Mapper.Map<IEnumerable<CallQueueCustomerEntity>, IEnumerable<CallQueueCustomer>>(query);
            }
        }

        public IEnumerable<CallQueueCustomer> GetConfirmationCallQueueCustomer(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue, out int totalRecords, bool isNormalExecution = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var appointmentDate = DateTime.Today.AddDays(filter.DaysForAppointmentConfirmation).GetEndOfDay();

                var criteriaLanguageId = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria where hpcqc.Id == criteriaId && hpcqc.LanguageId != null select hpcqc.LanguageId.Value).SingleOrDefault();

                var query = (from cqc in linqMetaData.VwGetCustomersForConfirmationCallQueue
                             where cqc.CriteriaId == criteriaId
                             && (criteriaLanguageId <= 0 || cqc.LanguageId <= 0 || cqc.LanguageId == criteriaLanguageId)
                                 //&& (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && cqc.AppointmentDateTimeWithTimeZone >= DateTime.Now.AddMinutes(filter.ConfirmationBeforeAppointmentMinutes)
                                   && cqc.AppointmentDateTimeWithTimeZone <= appointmentDate
                             select cqc);

                var finalQuery = (from cqc in query
                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      cqc.AppointmentDate,
                                      cqc.AppointmentDateTimeWithTimeZone
                                  });

                if (isNormalExecution)
                    totalRecords = finalQuery.Count();
                else
                    totalRecords = 0;

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "AppointmentDateTimeWithTimeZone");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);

                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return
                        callQueueCustomerIds.Select(
                            callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId))
                            .ToList();
                }
                return null;
            }
        }

        public CallQueueCustomer GetCallQueueCustomerByCustomerId(long customerId, string callQueueCategoryName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue where cq.Category == callQueueCategoryName select cq).SingleOrDefault();

                var callQueueCustomer = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomerVici
                                         where cqc.CallQueueId == callQueue.CallQueueId
                                               && cqc.CustomerId == customerId
                                         select cqc).FirstOrDefault();

                if (callQueueCustomer != null)
                {
                    return GetById(callQueueCustomer.CallQueueCustomerId);
                }

                return null;
            }
        }

        public CallQueueCustomer GetCallQueueCustomerByCustomerIdAndHealthPlanId(long customerId, long healthPlanId, string category)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue where cq.Category == category select cq).Single();

                var entity = (from cqc in linqMetaData.CallQueueCustomer
                              where cqc.HealthPlanId == healthPlanId
                              && cqc.CallQueueId == callQueue.CallQueueId
                                    && cqc.CustomerId == customerId
                              select cqc).First();

                return entity == null ? null : Mapper.Map<CallQueueCustomerEntity, CallQueueCustomer>(entity);
            }
        }

        public long GetCallQueueCustomerCountForHealthPlanFillEvents(OutboundCallQueueFilter filter, bool isForDashboard = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0 || filter.CriteriaId <= 0)
                {
                    return 0;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var customTags = string.Empty;
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.CriteriaId == filter.CriteriaId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                    !(
                                        (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                        ||
                                        (
                                            cqc.ContactedDate >= refusalDate
                                            && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                            && (
                                                   cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                   cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                               )
                                        )
                                        || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                        || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                      )
                                    )
                                    && cqc.ProductTypeId > 0

                             select cqc);


                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = (from q in query where tagCustomers.Contains(q.CustomerId) select q);
                }

                long totalRecords = 0;
                if (isForDashboard)
                {
                    totalRecords = (from q in query
                                    orderby q.CallCount, q.CustomerId
                                    select q.CallQueueCustomerId).TakePage(1, 10).ToArray().Count();
                }
                else
                    totalRecords = query.Count();

                return totalRecords;
            }
        }

        public long GetMailRoundCallqueueCustomerCount(OutboundCallQueueFilter filter, bool isForDashboard = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0 || filter.CriteriaId <= 0)
                {
                    return 0;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.CriteriaId == filter.CriteriaId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   && (
                                            cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                            !(
                                                (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                            || (
                                                    cqc.ContactedDate >= refusalDate
                                                    && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                    && (
                                                           cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                           cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                       )
                                                )
                                        || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                        || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                    )
                                   )
                                   && cqc.ProductTypeId > 0

                             select cqc);

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        query = from a in query
                                where zipRadiusDistance.Contains(a.ZipId)
                                select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.ZipId)
                                    select q;
                        }
                    }
                }

                if (filter.DirectMailDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                if (filter.DirectMailStartDate.HasValue && filter.DirectMailEndDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue
                                             where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailStartDate.Value && dm.MailDate < filter.DirectMailEndDate.Value.AddDays(1)
                                             select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }
                else if (filter.DirectMailStartDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailStartDate.Value select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }
                else if (filter.DirectMailEndDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate < filter.DirectMailEndDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                var customTags = string.Empty;

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = query.Where(cp => tagCustomers.Contains(cp.CustomerId));
                }

                long totalRecords = 0;
                if (isForDashboard)
                {
                    totalRecords = (from q in query
                                    orderby q.CallCount, q.CustomerId
                                    select q.CallQueueCustomerId).TakePage(1, 10).ToArray().Count();
                }
                else
                    totalRecords = query.Count();

                return totalRecords;
            }
        }

        public long GetLanguageBarrierCallQueueCustomerCount(OutboundCallQueueFilter filter, bool isForDashboard = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0 || filter.CriteriaId <= 0)
                {
                    return 0;
                }

                var callQueue =
                    (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.CriteriaId == filter.CriteriaId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == true && cqc.LanguageBarrierMarkedDate >= startOfYear)
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString())
                                    || (cqc.Disposition == ProspectCustomerTag.LanguageBarrier.ToString() && cqc.ContactedDate < DateTime.Today)
                                    || !(
                                        (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                        || (
                                                cqc.ContactedDate >= refusalDate
                                                && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                && (
                                                       cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                       cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                   )
                                            )
                                            || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                            || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                            )
                                        )
                                        && cqc.ProductTypeId > 0

                             select cqc);

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        query = from a in query
                                where zipRadiusDistance.Contains(a.ZipId)
                                select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.ZipId)
                                    select q;
                        }
                    }
                }

                var customTags = string.Empty;

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = query.Where(cp => tagCustomers.Contains(cp.CustomerId));
                }

                long totalRecords = 0;
                if (isForDashboard)
                {
                    totalRecords = (from q in query
                                    orderby q.CallCount, q.CustomerId
                                    select q.CallQueueCustomerId).TakePage(1, 10).ToArray().Count();
                }
                else
                    totalRecords = query.Count();

                return totalRecords;
            }
        }

        public long GetConfirmationCallQueueCustomerCount(OutboundCallQueueFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0 || filter.CriteriaId <= 0)
                {
                    return 0;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var appointmentDate = DateTime.Today.AddDays(filter.DaysForAppointmentConfirmation).GetEndOfDay();

                var criteriaLanguageId = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria where hpcqc.Id == filter.CriteriaId && hpcqc.LanguageId != null select hpcqc.LanguageId.Value).SingleOrDefault();

                var query = (from cqc in linqMetaData.VwGetCustomersForConfirmationCallQueue
                             where cqc.CriteriaId == filter.CriteriaId
                             && (criteriaLanguageId <= 0 || cqc.LanguageId <= 0 || cqc.LanguageId == criteriaLanguageId)
                                   && cqc.AppointmentDateTimeWithTimeZone >= DateTime.Now.AddMinutes(filter.ConfirmationBeforeAppointmentMinutes)
                                   && cqc.AppointmentDateTimeWithTimeZone <= appointmentDate
                             select cqc);

                var totalRecords = query.Count();

                return totalRecords;
            }
        }

        public void UpdateConfirmationQueueCustomers(long customerId, long eventCustomerId, long callId = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue
                                 where cq.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                                 select cq).SingleOrDefault();

                if (callQueue != null)
                {
                    var confirmationCallQueueCustomers = (from cqc in linqMetaData.CallQueueCustomer
                                                          where cqc.CustomerId.HasValue && cqc.CustomerId == customerId
                                                          && cqc.EventCustomerId == eventCustomerId
                                                          && cqc.CallQueueId == callQueue.CallQueueId
                                                          select cqc).ToArray();

                    if (confirmationCallQueueCustomers.Any())
                    {
                        foreach (var confirmationCallQueueCustomer in confirmationCallQueueCustomers)
                        {
                            confirmationCallQueueCustomer.Status = (long)CallQueueStatus.Removed;
                            confirmationCallQueueCustomer.Disposition = ProspectCustomerTag.PatientConfirmed.ToString();
                            confirmationCallQueueCustomer.ContactedDate = DateTime.Now;

                            adapter.SaveEntity(confirmationCallQueueCustomer, false);

                            if (callId > 0)
                            {
                                adapter.SaveEntity(new CallQueueCustomerCallEntity(confirmationCallQueueCustomer.CallQueueCustomerId, callId));
                            }
                        }

                        if (callId > 0)
                        {
                            var entity = new CallsEntity
                            {
                                Status = (long)CallStatus.Attended,
                                //CallQueueId = callQueue.CallQueueId,
                                Disposition = ProspectCustomerTag.PatientConfirmed.ToString()
                            };

                            var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                            adapter.UpdateEntitiesDirectly(entity, bucket);
                        }
                    }
                }
            }
        }

        public IEnumerable<CallQueueCustomer> GetForConfirmationReport(ConfirmationReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue where cq.Category == HealthPlanCallQueueCategory.AppointmentConfirmation select cq).Single();

                var temp1 = (from cqcc in linqMetaData.CallQueueCustomerCall
                             join c in linqMetaData.Calls on cqcc.CallId equals c.CallId
                             where (c.CallQueueId == callQueue.CallQueueId || c.Disposition == ProspectCustomerTag.PatientConfirmed.ToString())
                             && c.Status != (long)CallStatus.Initiated
                             group c.CallId by cqcc.CallQueueCustomerId
                                 into grp
                                 select new { CallQueueCustomerId = grp.Key, CallId = grp.Max() });

                var query = (from cqc in linqMetaData.CallQueueCustomer
                             join t in temp1 on cqc.CallQueueCustomerId equals t.CallQueueCustomerId
                             join c in linqMetaData.Calls on t.CallId equals c.CallId
                             where cqc.CallQueueId == callQueue.CallQueueId
                             && cqc.CustomerId != null && cqc.CustomerId > 0
                             select new { cqc.CallQueueCustomerId, cqc.EventId, cqc.HealthPlanId, c.TimeCreated, c.Disposition });

                if (filter.EventDateFrom.HasValue)
                {
                    var eventIds = (from e in linqMetaData.Events where e.EventDate >= filter.EventDateFrom select e.EventId);
                    query = (from q in query
                             where q.EventId != null && q.EventId > 0
                             && eventIds.Contains(q.EventId.Value)
                             select q);
                }

                if (filter.EventDateTo.HasValue)
                {
                    var eventIds = (from e in linqMetaData.Events where e.EventDate <= filter.EventDateTo select e.EventId);
                    query = (from q in query
                             where q.EventId != null && q.EventId > 0
                             && eventIds.Contains(q.EventId.Value)
                             select q);
                }

                if (filter.HealthPlanId > 0)
                {
                    query = (from q in query
                             where q.HealthPlanId == filter.HealthPlanId
                             select q);
                }

                if (!string.IsNullOrEmpty(filter.Disposition))
                {
                    query = (from q in query
                             where q.Disposition == filter.Disposition
                             select q);
                }

                //var outputQueryable = query.OrderByDescending(x => x.TimeCreated).Select(qs => qs.cqc.CallQueueCustomerId).Distinct();

                var outputQueryable = (from q in query
                                       orderby q.TimeCreated descending
                                       select q.CallQueueCustomerId);

                totalRecords = outputQueryable.Count();

                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }
                return null;
            }
        }

        public bool UpdateCallQueueCustomerEligibility(long customerId, bool? eligibility)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callQueueCustomerEntity = new CallQueueCustomerEntity { IsEligble = eligibility };
                var bucket = new RelationPredicateBucket(CallQueueCustomerFields.CustomerId == customerId);

                return adapter.UpdateEntitiesDirectly(callQueueCustomerEntity, bucket) > 0;
            }
        }

        public IEnumerable<long> GetMailRoundCustomerIdsForMatrixReport(OutboundCallQueueFilter filter, CallQueue callQueue, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.HealthPlanId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.HealthPlanId == filter.HealthPlanId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < filter.MaxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   && (
                                            cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                            !(
                                                (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                            || (
                                                    cqc.ContactedDate >= refusalDate
                                                    && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                    && (
                                                           cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                           cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                       )
                                                )
                                            || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                            || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                            )
                                        )
                             select cqc);

                var activeCampaignIds = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                                         join campaign in linqMetaData.Campaign on hpcqc.CampaignId equals campaign.Id
                                         where hpcqc.HealthPlanId == filter.HealthPlanId && campaign.EndDate >= DateTime.Today && hpcqc.IsQueueGenerated && !hpcqc.IsDeleted
                                         select campaign.Id);
                query = query.Where(x => activeCampaignIds.Contains(x.CampaignId));

                var customerIdsQueryable = (from cqc in query select cqc.CustomerId).Distinct();

                totalRecords = customerIdsQueryable.Count();
                var customerIds = customerIdsQueryable.TakePage(pageNumber, pageSize).ToArray();
                return customerIds;
            }
        }

        public IEnumerable<long> GetFillEventCustomerIDsForMatrixReport(OutboundCallQueueFilter filter, CallQueue callQueue, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.HealthPlanId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                //var eventId = filter.EventId ?? 0;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.HealthPlanId == filter.HealthPlanId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                    !(
                                        (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                        ||
                                        (
                                            cqc.ContactedDate >= refusalDate
                                            && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                            && (
                                                   cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                   cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                               )
                                        )
                                        || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                        || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))

                                    )
                                   )
                             select cqc);

                var activeCriteriaIds = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                                         where hpcqc.HealthPlanId == filter.HealthPlanId && hpcqc.IsQueueGenerated && !hpcqc.IsDeleted
                                         && hpcqc.CallQueueId == filter.CallQueueId
                                         select hpcqc.Id);
                query = query.Where(x => activeCriteriaIds.Contains(x.CriteriaId));

                var customerIdsQueryable = (from cqc in query select cqc.CustomerId).Distinct();

                totalRecords = customerIdsQueryable.Count();
                var customerIds = customerIdsQueryable.TakePage(pageNumber, pageSize).ToArray();
                return customerIds;
            }
        }

        public IEnumerable<long> GetLanguageBarrierCustomerIDsForMatrixReport(OutboundCallQueueFilter filter, CallQueue callQueue, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.HealthPlanId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             where cqc.HealthPlanId == filter.HealthPlanId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == true && cqc.LanguageBarrierMarkedDate >= startOfYear)
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString())
                                    || (cqc.Disposition == ProspectCustomerTag.LanguageBarrier.ToString() && cqc.ContactedDate < DateTime.Today)
                                    || !(
                                        (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                        || (
                                            cqc.ContactedDate >= refusalDate
                                            && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                            && (
                                                   cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                   cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                               )
                                        )
                                         || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                        || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                        )
                                    )
                             select cqc);

                var activeCriteriaIds = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria
                                         where hpcqc.HealthPlanId == filter.HealthPlanId && hpcqc.IsQueueGenerated && !hpcqc.IsDeleted
                                         && hpcqc.CallQueueId == filter.CallQueueId
                                         select hpcqc.Id);
                query = query.Where(x => activeCriteriaIds.Contains(x.CriteriaId));

                var customerIdsQueryable = (from cqc in query select cqc.CustomerId).Distinct();

                totalRecords = customerIdsQueryable.Count();
                var customerIds = customerIdsQueryable.TakePage(pageNumber, pageSize).ToArray();
                return customerIds;
            }
        }

        public IEnumerable<long> GetHealthPlanEventsForCriteria(OutboundCallQueueFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0 || filter.CriteriaId <= 0)
                {
                    return null;
                }

                var callQueue = (from cq in linqMetaData.CallQueue where cq.CallQueueId == filter.CallQueueId select cq).Single();

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var customTags = string.Empty;
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwGetCustomersForCallQueueWithCustomer
                             //join ez in linqMetaData.EventZip on cqc.ZipId equals ez.ZipId
                             // join ept in linqMetaData.EventProductType on ez.EventId equals ept.EventId

                             where cqc.CriteriaId == filter.CriteriaId

                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= leftVoiceMailDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= leftVoiceMailDate)
                                   &&
                                   (cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                    !(
                                        (cqc.ContactedDate >= leftVoiceMailDate && (cqc.CallStatus == (long)CallStatus.VoiceMessage || cqc.CallStatus == (long)CallStatus.NoAnswer || cqc.Disposition == dateTimeConflict
                                            || cqc.Disposition == cancelAppointment || cqc.Disposition == leftMessagewithOther || cqc.Disposition == languageBarrier || cqc.Disposition == noShow))
                                        ||
                                        (
                                            cqc.ContactedDate >= refusalDate
                                            && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                            && (
                                                   cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                   cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                               )
                                        )
                                        || (cqc.ContactedDate >= othersFilterDate && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                        || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                        )
                                    )

                             select cqc);

                //if (filter.EventId > 0)
                //{
                //    var eventQuery = (from ez in linqMetaData.EventZip where ez.EventId == filter.EventId select ez.ZipId);
                //    query = (from q in query where eventQuery.Contains(q.ZipId) select q);
                //}

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = (from q in query where tagCustomers.Contains(q.CustomerId) select q);
                }

                //var productList = (from q in query select q.ProductTypeId).Distinct().ToArray();

                var customerZips = query.Select(q => q.ZipId);

                var criteriaEventQuery = (from hpfecq in linqMetaData.HealthPlanFillEventCallQueue
                                          where hpfecq.CriteriaId == filter.CriteriaId
                                          select hpfecq.EventId);

                var eventIds = (from ez in linqMetaData.EventZip
                                where criteriaEventQuery.Contains(ez.EventId)
                                && customerZips.Contains(ez.ZipId)
                                select ez.EventId).ToArray();

                //var productEventList = _eventProductTypeRepository.GetByEventIds(eventIds);

                //if (!productList.IsNullOrEmpty())
                //{

                //return (from ez in linqMetaData.EventZip
                //                join ept in linqMetaData.EventProductType on ez.EventId equals ept.EventId
                //        where criteriaEventQuery.Contains(ez.EventId) && ept.IsActive && customerZips.Contains(ez.ZipId)
                //                select ez.EventId).ToArray();

                //return (from e in productEventList
                //        //join ept in linqMetaData.EventProductType on e.EventID equals ept.EventId
                //        where e.IsActive && productList.Contains(e.ProductTypeId)
                //        select e.EventID
                //            ).ToArray();
                //  }
                /*var testEventIds = (from ez in linqMetaData.EventZip
                                    join ceq in criteriaEventQuery on ez.EventId equals ceq
                                    where customerZips.Contains(ez.ZipId)
                                    select ez.EventId).ToArray();*/



                return eventIds;
            }
        }

        public CallQueueCustomer GetCallQueueCustomerByCustomerIdForAppointmentConfirmation(long customerId, long callQueueId, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueCustomer = (from cqc in linqMetaData.VwGetConfirmationCallQueueCustomersWithoutSuppression
                                         where cqc.CallQueueId == callQueueId
                                               && cqc.CustomerId == customerId && cqc.EventId == eventId
                                         select cqc).FirstOrDefault();

                if (callQueueCustomer != null)
                {
                    return GetById(callQueueCustomer.CallQueueCustomerId);
                }

                return null;
            }
        }

        public IEnumerable<CallQueueCustomer> GetMailRoundCustomersForGms(OutboundCallQueueFilter filter, int pageNumber, int pageSize, long criteriaId, CallQueue callQueue,
            out int totalRecords, bool isNormalExecution = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.CallQueueId <= 0)
                {
                    totalRecords = 0;
                    return null;
                }

                var maxAttempt = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var moveRelocated = ProspectCustomerTag.MovedRelocated.ToString();
                var speakWithPhysician = ProspectCustomerTag.SpeakWithPhysician.ToString();
                var noEventInArea = ProspectCustomerTag.NoEventsinArea.ToString();
                var declinedMammo = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var noConvenientInArea = ProspectCustomerTag.NoConvenientInArea.ToString();
                var noEventsInList = ProspectCustomerTag.NoEventsInList.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var query = (from cqc in linqMetaData.VwCallQueueCustomerCriteraAssignmentForGms
                             where cqc.CriteriaId == criteriaId
                                   && (filter.IsMaxAttemptPerHealthPlan ? cqc.CallCount < maxAttempt : cqc.Attempts < maxAttempt)
                                   && (cqc.IsLanguageBarrier == false || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate < startOfYear))
                                   && (cqc.AppointmentCancellationDate == new DateTime(1900, 1, 1) || cqc.AppointmentCancellationDate <= othersFilterDate)
                                   && (cqc.NoShowDate == new DateTime(1900, 1, 1) || cqc.NoShowDate <= othersFilterDate)
                                   && (
                                            cqc.ContactedDate == new DateTime(1900, 1, 1) || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString()) ||
                                            !(
                                                (cqc.ContactedDate >= leftVoiceMailDate && cqc.CallStatus == (long)CallStatus.VoiceMessage)
                                            || (
                                                    cqc.ContactedDate >= refusalDate
                                                    && (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                    && (
                                                           cqc.Disposition == notInterested || cqc.Disposition == declinedMobileAndHomeVisit || cqc.Disposition == recentlySawDoc ||
                                                           cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                       )
                                                )
                                        || (cqc.ContactedDate >= othersFilterDate && (cqc.CallStatus == (long)CallStatus.InvalidNumber || cqc.Disposition == moveRelocated || cqc.Disposition == speakWithPhysician || cqc.Disposition == noEventInArea || cqc.Disposition == noConvenientInArea || cqc.Disposition == noEventsInList || cqc.Disposition == declinedMammo) && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated)
                                        || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                    )
                                   )

                             select cqc);

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        query = from a in query
                                where zipRadiusDistance.Contains(a.ZipId)
                                select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.ZipId)
                                    select q;
                        }
                    }
                }

                if (filter.DirectMailDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                if (filter.DirectMailStartDate.HasValue && filter.DirectMailEndDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue
                                             where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailStartDate.Value && dm.MailDate < filter.DirectMailEndDate.Value.AddDays(1)
                                             select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }
                else if (filter.DirectMailStartDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailStartDate.Value select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }
                else if (filter.DirectMailEndDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate < filter.DirectMailEndDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                var customTags = string.Empty;

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }
                    query = query.Where(cp => tagCustomers.Contains(cp.CustomerId));
                }

                var finalQuery = (from cqc in query

                                  select new
                                  {
                                      Calls = cqc.CallCount,
                                      cqc.CallQueueCustomerId,
                                      cqc.CustomerId,
                                      SortIndex = cqc.CallDate >= DateTime.Now.AddDays(-1) && cqc.CallDate <= DateTime.Now ? 0 : (cqc.CallDate < DateTime.Now.AddDays(-1) ? 1 : 2),
                                      SortingDate = cqc.DateModified
                                  });

                if (isNormalExecution)
                    totalRecords = finalQuery.Count();
                else
                    totalRecords = 0;

                var orderedQueryable = OrderingSortingHelper.OrderBy(finalQuery, "Calls");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "CustomerId");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortIndex");
                orderedQueryable = OrderingSortingHelper.ThenBy(orderedQueryable, "SortingDate");

                var outputQueryable = orderedQueryable.Select(qs => qs.CallQueueCustomerId);
                var callQueueCustomerIds = outputQueryable.TakePage(pageNumber, pageSize).ToArray();

                if (callQueueCustomerIds.Any())
                {
                    var callQueueCustomers = GetbyIds(callQueueCustomerIds);

                    return
                        callQueueCustomerIds.Select(callQueueCustomerId => callQueueCustomers.Single(x => x.Id == callQueueCustomerId)).ToList();
                }
                return null;
            }
        }

        public bool UpdateCallQueueCustomerForNoShow(long customerId, DateTime? appointmentDate, DateTime? noshowDateTime, long callQueueToExcludeFromUpdate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var callQueueCustomerEntity = new CallQueueCustomerEntity { AppointmentDate = appointmentDate, NoShowDate = noshowDateTime };
                var bucket = new RelationPredicateBucket(CallQueueCustomerFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(CallQueueCustomerFields.CallQueueId != callQueueToExcludeFromUpdate);

                return adapter.UpdateEntitiesDirectly(callQueueCustomerEntity, bucket) > 0;
            }
        }

        public CallQueueCustomer GetCallQueueCustomerByCustomerIdForGms(long customerId, string callQueueCategoryName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue where cq.Category == callQueueCategoryName select cq).SingleOrDefault();

                var callQueueCustomer = (from cqc in linqMetaData.VwCallQueueCustomerCriteraAssignmentForGms
                                         where cqc.CallQueueId == callQueue.CallQueueId
                                               && cqc.CustomerId == customerId
                                         select cqc).FirstOrDefault();

                if (callQueueCustomer != null)
                {
                    return GetById(callQueueCustomer.CallQueueCustomerId);
                }

                return null;
            }
        }

        public void UpdateConfirmationQueueCustomersOnReschedule(EventCustomer eventCustomer, DateTime appointmentDateTime, DateTime appointmentwithTimeZone)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue
                                 where cq.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                                 select cq).SingleOrDefault();

                if (callQueue != null)
                {
                    var confirmationCallQueueCustomers = (from cqc in linqMetaData.CallQueueCustomer
                                                          where cqc.EventCustomerId == eventCustomer.Id
                                                          && cqc.CallQueueId == callQueue.CallQueueId
                                                          select cqc).ToArray();

                    if (confirmationCallQueueCustomers.Any())
                    {
                        foreach (var confirmationCallQueueCustomer in confirmationCallQueueCustomers)
                        {
                            confirmationCallQueueCustomer.Status = (long)CallQueueStatus.Initial;
                            confirmationCallQueueCustomer.EventId = eventCustomer.EventId;
                            confirmationCallQueueCustomer.AppointmentDate = appointmentDateTime;
                            confirmationCallQueueCustomer.AppointmentDateTimeWithTimeZone = appointmentwithTimeZone;

                            if (confirmationCallQueueCustomer.Disposition == ProspectCustomerTag.PatientConfirmed.ToString())
                            {
                                confirmationCallQueueCustomer.Disposition = null;
                            }

                            adapter.SaveEntity(confirmationCallQueueCustomer, false);
                        }
                    }
                }
            }
        }

        public bool UpdateCallQueueCustomerTargeted(long customerId, int targetedYear, bool? isTargeted)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callQueueCustomerEntity = new CallQueueCustomerEntity { TargetedYear = targetedYear, IsTargeted = isTargeted };
                var bucket = new RelationPredicateBucket(CallQueueCustomerFields.CustomerId == customerId);

                return adapter.UpdateEntitiesDirectly(callQueueCustomerEntity, bucket) > 0;
            }
        }

        public bool UpdateCallQueueCustomerProductType(long customerId, long? productTypeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callQueueCustomerEntity = new CallQueueCustomerEntity { ProductTypeId = productTypeId };
                var bucket = new RelationPredicateBucket(CallQueueCustomerFields.CustomerId == customerId);

                return adapter.UpdateEntitiesDirectly(callQueueCustomerEntity, bucket) > 0;
            }
        }

    }
}