using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Infrastructure.Deprecated.Factories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.Entity.CallCenter;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Customer = Falcon.App.Core.Users.Domain.Customer;

namespace Falcon.App.Infrastructure.Deprecated.Repository
{
    [DefaultImplementation(Interface = typeof(ICallCenterCallRepository))]
    public class CallCenterCallRepository : PersistenceRepository, ICallCenterCallRepository
    {
        public ECall GetCallCenterEntity(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var call = (from c in linqMetaData.Calls where c.CallId == callId select c).FirstOrDefault();

                if (call == null) throw new Exception("No call found for the given call Id");

                var couponCode = string.Empty;
                if (call.PromoCodeId != null)
                    couponCode =
                        (from c in linqMetaData.Coupons where c.CouponId == call.PromoCodeId.Value select c.CouponCode).
                            FirstOrDefault();

                var orderedPair = new OrderedPair<CallsEntity, string>(call, couponCode);

                var factory = new ECallFactory();
                return factory.Create(orderedPair);
            }
        }

        public string GetCallStarttime(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var call = linqMetaData.Calls.Where(
                    c => c.CallId == callId).FirstOrDefault();

                if (call != null && call.TimeCreated != null) return call.TimeCreated.ToString();

                return string.Empty;
            }
        }

        public bool UpdateCallCenterCallStatus(string status, long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callEntity = new CallsEntity() { CallStatus = status };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }
            return true;
        }

        public bool UpdateCalledCustomerId(long customerId, long callId, long? healthPlanId, long ? ProductTypeId =null)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callEntity = new CallsEntity() { CalledCustomerId = customerId, HealthPlanId = healthPlanId, ProductTypeId = ProductTypeId };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }
            return true;
        }

        public bool UpdatePromoCode(string sourceCode, long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var couponId =
                    linqMetaData.Coupons.Where(cop => cop.CouponCode == sourceCode).Select(cop => cop.CouponId).
                        FirstOrDefault();

                if (couponId < 1) throw new InvalidDataException("Source Code is invalid");

                var callEntity = new CallsEntity() { PromoCodeId = couponId };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }
            return true;
        }

        public bool UpdateCallEnd(DateTime endTime, long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callEntity = new CallsEntity() { TimeEnd = endTime };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }
            return true;
        }

        public bool UpdateEventforaCall(long eventId, long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callEntity = new CallsEntity() { EventId = eventId };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }
            return true;
        }

        public IEnumerable<Call> GetCallDetails(IEnumerable<Customer> customers)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                string str1 = CallType.Register_New_Customer.GetDescription();
                string str2 = CallType.Existing_Customer.GetDescription();
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<CallsEntity> entities;
                //This condition should be there but somehow event Id is null :( Have to check this. cl.EventId != null && 
                var query = from cl in linqMetaData.Calls
                            where customers.Select(c => c.CustomerId).Contains(cl.CalledCustomerId.Value) &&
                            (cl.CallStatus == str2 ||
                                 cl.CallStatus == str1)
                            select cl;

                entities = query.ToArray();

                return Mapper.Map<IEnumerable<CallsEntity>, IEnumerable<Call>>(entities);
            }
        }


        public IEnumerable<Call> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cl in linqMetaData.Calls
                                where ids.Contains(cl.CallId)
                                select cl).ToArray();

                return Mapper.Map<IEnumerable<CallsEntity>, IEnumerable<Call>>(entities);
            }
        }

        public Call Save(Call call)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<Call, CallsEntity>(call);
                adapter.SaveEntity(entity, true);

                return Mapper.Map<CallsEntity, Call>(entity);
            }
        }
        public Call GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cl in linqMetaData.Calls
                                where cl.CallId == id
                                select cl).SingleOrDefault();

                return Mapper.Map<CallsEntity, Call>(entities);
            }
        }

        public IEnumerable<CallQueueCustomerCallViewModel> GetCallsForCallQueueCustomer(long callId, long customerId, long prospectCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetatData = new LinqMetaData(adapter);

                var customerCalls = (from c in linqMetatData.Calls
                                     where c.CalledCustomerId > 0 && c.CalledCustomerId == customerId
                                     && c.CallId != callId && c.Status != (long)CallStatus.CallSkipped
                                     select c).ToArray();

                var callList = new List<CallQueueCustomerCallViewModel>();

                if (customerCalls.Any())
                {
                    callList.AddRange(customerCalls.Select(cc => new CallQueueCustomerCallViewModel
                                         {
                                             CallId = cc.CallId,
                                             CallDateTime = cc.DateCreated,
                                             CreatedByOrgRoleUserId = cc.CreatedByOrgRoleUserId,
                                             CustomerId = customerId,
                                             Status = cc.Status,
                                             Disposition = cc.Disposition,
                                             NotInterestedReasonId = cc.NotInterestedReasonId
                                         }).ToList());
                }

                var prospectCustomerCalls = (from pc in linqMetatData.ProspectCustomerCall
                                             join c in linqMetatData.Calls on pc.CallId equals c.CallId
                                             where pc.ProspectCustomerId == prospectCustomerId
                                             && c.CallId != callId
                                             select c).ToArray();
                if (prospectCustomerCalls.Any())
                {
                    prospectCustomerCalls = prospectCustomerCalls.Where(pcc => !callList.Select(cl => cl.CallId).Contains(pcc.CallId)).Select(pcc => pcc).ToArray();
                    if (prospectCustomerCalls.Any())
                    {
                        callList.AddRange(prospectCustomerCalls.Select(pcc => new CallQueueCustomerCallViewModel
                                         {
                                             CallId = pcc.CallId,
                                             CallDateTime = pcc.DateCreated,
                                             CreatedByOrgRoleUserId = pcc.CreatedByOrgRoleUserId,
                                             ProspectCustomerId = prospectCustomerId,
                                             Status = pcc.Status,
                                             Disposition = pcc.Disposition
                                         }).ToList());
                    }
                }

                return callList;
            }
        }

        public IEnumerable<CallQueueCustomerCallViewModel> GetCallForCallQueueCustomerList(IEnumerable<long> customerIds, IEnumerable<long> prospectCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetatData = new LinqMetaData(adapter);

                var customerCalls = (from c in linqMetatData.Calls
                                     where c.CalledCustomerId.HasValue && customerIds.Contains(c.CalledCustomerId.Value)
                                     select c).ToArray();

                var callList = new List<CallQueueCustomerCallViewModel>();

                if (customerCalls.Any())
                {
                    callList.AddRange(customerCalls.Select(cc => new CallQueueCustomerCallViewModel
                    {
                        CallId = cc.CallId,
                        CallDateTime = cc.DateCreated,
                        CreatedByOrgRoleUserId = cc.CreatedByOrgRoleUserId,
                        CustomerId = cc.CalledCustomerId.Value,
                        Status = cc.Status
                    }).ToList());
                }

                if (prospectCustomerIds != null && prospectCustomerIds.Any())
                {
                    var prospectCustomerCalls = (from pc in linqMetatData.ProspectCustomerCall
                                                 join c in linqMetatData.Calls on pc.CallId equals c.CallId
                                                 where prospectCustomerIds.Contains(pc.ProspectCustomerId)
                                                 select new CallQueueCustomerCallViewModel
                                                 {
                                                     CallId = c.CallId,
                                                     CallDateTime = c.DateCreated,
                                                     CreatedByOrgRoleUserId = c.CreatedByOrgRoleUserId,
                                                     ProspectCustomerId = pc.ProspectCustomerId,
                                                     Status = c.Status
                                                 }).ToArray();

                    if (prospectCustomerCalls.Any())
                    {
                        prospectCustomerCalls = prospectCustomerCalls.Where(pcc => !callList.Select(cl => cl.CallId).Contains(pcc.CallId)).Select(pcc => pcc).ToArray();
                        if (prospectCustomerCalls.Any())
                        {
                            callList.AddRange(prospectCustomerCalls);
                        }
                    }
                }

                return callList;
            }
        }

        public static IQueryable<long> CustomerHaveMoreRoundOfCallsInDays(LinqMetaData linqMetaData, int lastCallDaysBefore, int roundOfCallCompleted)
        {
            var lastCallDate = DateTime.Now.AddDays(-lastCallDaysBefore);

            var callsAggregate = (from c in linqMetaData.VwGetCallsForCallQueue
                                  where c.OutBound && c.Status == (long)CallStatus.Attended && c.DateCreated >= lastCallDate
                                  group c by c.CalledCustomerId into grp_calls
                                  select new { CustomerId = grp_calls.Key, CallCount = grp_calls.Count() });

            if (roundOfCallCompleted == 0)
                return (from ca in callsAggregate where ca.CallCount > roundOfCallCompleted select ca.CustomerId);

            return (from ca in callsAggregate where ca.CallCount == roundOfCallCompleted select ca.CustomerId);
        }

        public IEnumerable<CallQueueCustomerCallViewModel> GetCallForHealtPlanCallQueueCustomer(IEnumerable<long> customerIds, string customTags)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var dateCallDate = new DateTime(DateTime.Today.Year, 1, 1);

                var customerCalls = (from c in linqMetaData.VwGetCallsForCallQueue
                                     where c.CalledCustomerId > 0 && customerIds.Contains(c.CalledCustomerId)
                                     && c.Status != (long)CallStatus.CallSkipped && c.TimeCreated > dateCallDate
                                     select c).ToArray();

                if (customerCalls.Any())
                {
                    return customerCalls.Select(cc => new CallQueueCustomerCallViewModel
                    {
                        CallId = cc.CallId,
                        CallDateTime = cc.DateCreated,
                        CreatedByOrgRoleUserId = cc.CreatedByOrgRoleUserId,
                        CustomerId = cc.CalledCustomerId,
                        Status = cc.Status
                    }).ToList();
                }

                return null;
            }
        }

        public IEnumerable<Call> GetOutreachCallQueueCustomer(OutreachCallReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter = filter ?? new OutreachCallReportModelFilter();

                var query = (from ocr in linqMetaData.VwOutreachCallReport select ocr);

                if (filter.CustomerId.HasValue)
                {
                    if (filter.CustomerId.Value > 0)
                        query = (from cqc in query where cqc.CalledCustomerId == filter.CustomerId select cqc);
                    else
                    {
                        totalRecords = 0;
                        return null;
                    }
                }
                else if (filter.EventId.HasValue)
                {
                    query = (from cqc in query where cqc.EventId == filter.EventId.Value select cqc);
                }
                else
                {
                    if (string.IsNullOrEmpty(filter.Tag) && (filter.CustomTags == null) && !filter.DateFrom.HasValue && !filter.DateTo.HasValue && !filter.CustomerId.HasValue && filter.HealthPlanId <= 0 && filter.CallQueueId <= 0)
                    {
                        filter.DateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value : DateTime.Now.AddDays(-1).Date;
                        filter.DateTo = filter.DateTo.HasValue ? filter.DateTo.Value : DateTime.Now.AddDays(-1).Date;
                    }

                    if (filter.HealthPlanId > 0)
                    {
                        query = (from ocr in linqMetaData.VwOutreachCallReport where ocr.AccountId == filter.HealthPlanId select ocr);
                    }
                    else if (filter.Tag != null && !string.IsNullOrEmpty(filter.Tag.Trim()))
                    {
                        query = (from ocr in linqMetaData.VwOutreachCallReport where ocr.Tag == filter.Tag.Trim() select ocr);
                    }

                    if (filter.CallQueueId > 0)
                        query = (from cqc in query where cqc.CallQueueId == filter.CallQueueId select cqc);

                    if (filter.DateFrom.HasValue && filter.DateTo.HasValue)
                    {
                        query = (from cqc in query where cqc.DateCreated >= filter.DateFrom && cqc.DateCreated <= filter.DateTo.Value.AddDays(1) select cqc);

                    }
                    else if (filter.DateFrom.HasValue && !filter.DateTo.HasValue)
                    {
                        query = (from cqc in query where cqc.DateCreated >= filter.DateFrom select cqc);
                    }
                    else if (!filter.DateFrom.HasValue && filter.DateTo.HasValue)
                    {
                        query = (from cqc in query where cqc.DateCreated <= filter.DateTo.Value.AddDays(1) select cqc);
                    }

                    if (filter.CustomTags != null)
                    {
                        var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId);
                        query = (from cqc in query where customTagCustomersIds.Contains(cqc.CalledCustomerId) select cqc);
                    }
                    if (filter.ProductTypeId>0)
                    {
                        query = from ec in query
                                where ec.ProductTypeId == filter.ProductTypeId
                               select ec;
                    }
                }

                if (filter.CallAttemptFilter == CallAttemptFilterStatus.ContactsOnly)
                {
                    query = query.Where(x => x.IsContacted);
                }
                else if (filter.CallAttemptFilter == CallAttemptFilterStatus.AttemptsOnly)
                {
                    query = query.Where(x => !x.IsContacted);
                }
                totalRecords = query.Count();

                //var entities = finalQuery.OrderByDescending(x => x.DateCreated).TakePage(pageNumber, pageSize).Select(x => x).ToArray();

                var entities = query.OrderByDescending(x => x.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return Mapper.Map<IEnumerable<VwOutreachCallReportEntity>, IEnumerable<Call>>(entities);
            }
        }

        public IEnumerable<Call> GetCallDetails(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IEnumerable<CallsEntity> entities;

                var query = from cl in linqMetaData.Calls
                            where customerIds.Contains(cl.CalledCustomerId.Value) && cl.IsUploaded == false
                            select cl;

                entities = query.ToArray();

                return Mapper.Map<IEnumerable<CallsEntity>, IEnumerable<Call>>(entities);
            }
        }

        public IEnumerable<Call> GetCallDetailsForOutreachCalls(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IEnumerable<CallsEntity> entities;

                var query = from c in linqMetaData.Calls
                            join cqcc in linqMetaData.CallQueueCustomerCall on c.CallId equals cqcc.CallId
                            join cqc in linqMetaData.CallQueueCustomer on cqcc.CallQueueCustomerId equals cqc.CallQueueCustomerId
                            where customerIds.Contains(c.CalledCustomerId.Value) && cqc.HealthPlanId != null && (c.OutBound != null && c.OutBound.Value == true)
                            && (c.Status != (long)CallStatus.Initiated)

                            select c;

                entities = query.ToArray();

                return Mapper.Map<IEnumerable<CallsEntity>, IEnumerable<Call>>(entities);
            }
        }

        public IEnumerable<long> GetForResponseVendorReport(ResponseVendorReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = filter.AccountId > 0 ? (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault() : null;

                var query = (from c in linqMetaData.Calls
                             join cp in linqMetaData.CustomerProfile on c.CalledCustomerId equals cp.CustomerId
                             where c.CalledCustomerId.HasValue && c.CalledCustomerId.Value > 0 && (account != null && cp.Tag == account.Tag)
                             && (filter.StartDate == null || c.TimeCreated >= filter.StartDate)
                             && (filter.EndDate == null || c.TimeCreated <= filter.EndDate)
                             && (c.Status != (long)CallStatus.Initiated)
                             orderby cp.CustomerId
                             select cp.CustomerId).Distinct();

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId);
                    query = (from q in query where customTagCustomersIds.Contains(q) select q);
                }

                totalRecords = query.Count();

                var customerIds = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return customerIds;
            }
        }

        public IEnumerable<long> GetForInterviewReport(InterviewInboundFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = filter.AccountId > 0 ? (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault() : null;

                var query = (from c in linqMetaData.Calls
                             join cp in linqMetaData.CustomerProfile on c.CalledCustomerId equals cp.CustomerId
                             where c.CalledCustomerId.HasValue && c.CalledCustomerId.Value > 0 && (account != null && cp.Tag == account.Tag)
                             && (filter.StartDate == null || c.TimeCreated >= filter.StartDate)
                             && (filter.EndDate == null || c.TimeCreated <= filter.EndDate)
                             && (c.Status != (long)CallStatus.Initiated)
                             orderby cp.CustomerId
                             select cp);

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId);
                    query = (from q in query where customTagCustomersIds.Contains(q.CustomerId) select q);
                }

                var entities = query.OrderBy(x => x.CustomerId).Select(x => x.CustomerId).Distinct();

                totalRecords = entities.Count();

                var customerIds = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return customerIds;
            }
        }

        public long GetOutreachCallQueueCallsForLastSevenDays(DateTime fromDate, DateTime toDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ocr in linqMetaData.VwOutreachCallReport where ocr.DateCreated >= fromDate && ocr.DateCreated < toDate select ocr).Count();

            }
        }

        public IEnumerable<Call> GetCallsForResponseVendorReport(ResponseVendorReportFilter filter, IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from c in linqMetaData.Calls
                             where (c.CalledCustomerId.HasValue && c.CalledCustomerId.Value > 0 && customerIds.Contains(c.CalledCustomerId.Value))
                             && (filter.StartDate == null || c.TimeCreated >= filter.StartDate)
                             && (filter.EndDate == null || c.TimeCreated <= filter.EndDate)
                             && (c.Status != (long)CallStatus.Initiated)
                             select c);

                return Mapper.Map<IEnumerable<CallsEntity>, IEnumerable<Call>>(query);
            }
        }

        public IEnumerable<Call> GetCallsForInterviewReport(InterviewInboundFilter filter, IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from c in linqMetaData.Calls
                             where (c.CalledCustomerId.HasValue && c.CalledCustomerId.Value > 0 && customerIds.Contains(c.CalledCustomerId.Value))
                             && (filter.StartDate == null || c.TimeCreated >= filter.StartDate)
                             && (filter.EndDate == null || c.TimeCreated <= filter.EndDate)
                             && (c.Status != (long)CallStatus.Initiated)
                             select c);

                return Mapper.Map<IEnumerable<CallsEntity>, IEnumerable<Call>>(query);
            }
        }

        public IEnumerable<long> GetCustomerIdsMarkedIncorrectPhoneNumber(IEnumerable<long> customerIds, DateTime lastTranctionDate)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var markedThisWeekcustomes = (from c in linqMetaData.Calls
                                              where c.CalledCustomerId.HasValue && c.CalledCustomerId.Value > 0 &&
                                              customerIds.Contains(c.CalledCustomerId.Value) && (c.TimeCreated > lastTranctionDate)
                                              && (c.Status == (long)CallStatus.IncorrectPhoneNumber || c.Disposition == ProspectCustomerTag.IncorrectPhoneNumber.ToString())
                                              select c.CalledCustomerId.Value).ToArray();

                return markedThisWeekcustomes;
            }
        }

        public IEnumerable<Call> GetCallsByCustomerIds(IEnumerable<long> customerIds, DateTime? fromDate = null, DateTime? toDate = null, bool? isOutbound = null, CallAttemptFilterStatus callAttemptFilter = CallAttemptFilterStatus.All)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IEnumerable<CallsEntity> entities;

                var excluedeCallStatus = new long[] { (long)CallStatus.Initiated, (long)CallStatus.CallSkipped };

                var confirmQueueId = (from cc in linqMetaData.CallQueue
                                      where cc.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                                      select cc.CallQueueId).SingleOrDefault();

                var query = (from c in linqMetaData.Calls
                             where customerIds.Contains(c.CalledCustomerId.Value) && c.HealthPlanId != null
                             && (!excluedeCallStatus.Contains(c.Status))
                             && (c.CallQueueId == null || c.CallQueueId != confirmQueueId)
                             select c);

                if (fromDate.HasValue)
                    query = (from q in query where q.DateCreated >= fromDate select q);
                if (toDate.HasValue)
                    query = (from q in query where q.DateCreated <= toDate.Value.AddDays(1) select q);

                if (isOutbound.HasValue)
                {
                    if (isOutbound.Value)
                        query = query.Where(x => x.OutBound.HasValue && x.OutBound.Value);
                    else
                        query = query.Where(x => x.OutBound.HasValue && !x.OutBound.Value);
                }

                if (callAttemptFilter == CallAttemptFilterStatus.ContactsOnly)
                {
                    query = query.Where(x => x.IsContacted == null || x.IsContacted == true);
                }
                else if (callAttemptFilter == CallAttemptFilterStatus.AttemptsOnly)
                {
                    query = query.Where(x => x.IsContacted.HasValue && !x.IsContacted.Value);
                }

                entities = query.Select(x => x).ToArray();

                return Mapper.Map<IEnumerable<CallsEntity>, IEnumerable<Call>>(entities);
            }
        }

        public IEnumerable<Call> GetCallCenterCallQueueCustomer(CallCenterCallReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter = filter ?? new CallCenterCallReportModelFilter();

                var query = (from cccr in linqMetaData.VwCallCenterCallReport where cccr.CalledCustomerId > 0 select cccr);

                if (filter.CustomerId.HasValue)
                {
                    if (filter.CustomerId.Value > 0)
                        query = (from cqc in query where cqc.CalledCustomerId == filter.CustomerId select cqc);
                    else
                    {
                        totalRecords = 0;
                        return null;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(filter.Tag) && (filter.CustomTags == null) && !filter.DateFrom.HasValue && !filter.DateTo.HasValue && !filter.CustomerId.HasValue && filter.HealthPlanId <= 0 && filter.CallQueueId <= 0)
                    {
                        filter.DateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value : DateTime.Now.AddDays(-1).Date;
                        filter.DateTo = filter.DateTo.HasValue ? filter.DateTo.Value : DateTime.Now.AddDays(-1).Date;
                    }

                    if (filter.HealthPlanId > 0)
                    {
                        query = (from cccr in linqMetaData.VwCallCenterCallReport where cccr.AccountId == filter.HealthPlanId select cccr);
                    }
                    else if (filter.Tag != null && !string.IsNullOrEmpty(filter.Tag.Trim()))
                    {
                        query = (from cccr in linqMetaData.VwCallCenterCallReport where cccr.Tag == filter.Tag.Trim() select cccr);
                    }

                    if (filter.CallQueueId > 0)
                        query = (from cqc in query where cqc.CallQueueId == filter.CallQueueId select cqc);

                    if (filter.DateFrom.HasValue && filter.DateTo.HasValue)
                    {
                        query = (from cqc in query where cqc.DateCreated >= filter.DateFrom && cqc.DateCreated <= filter.DateTo.Value.AddDays(1) select cqc);

                    }
                    else if (filter.DateFrom.HasValue && !filter.DateTo.HasValue)
                    {
                        query = (from cqc in query where cqc.DateCreated >= filter.DateFrom select cqc);
                    }
                    else if (!filter.DateFrom.HasValue && filter.DateTo.HasValue)
                    {
                        query = (from cqc in query where cqc.DateCreated <= filter.DateTo.Value.AddDays(1) select cqc);
                    }

                    if (filter.CustomTags != null)
                    {
                        var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId);
                        query = (from cqc in query where customTagCustomersIds.Contains(cqc.CalledCustomerId) select cqc);
                    }

                    if (filter.CallType == (int)CallCenterCallType.Inbound)
                    {
                        query = (from q in query where q.OutBound != null && q.OutBound == false select q);
                    }
                    else if (filter.CallType == (int)CallCenterCallType.Outbound)
                    {
                        query = (from q in query where q.OutBound != null && q.OutBound == true select q);
                    }
                }

                totalRecords = query.Count();

                //var entities = finalQuery.OrderByDescending(x => x.DateCreated).TakePage(pageNumber, pageSize).Select(x => x).ToArray();

                var entities = query.OrderByDescending(x => x.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return Mapper.Map<IEnumerable<VwCallCenterCallReportEntity>, IEnumerable<Call>>(entities);
            }
        }

        public IEnumerable<Call> GetCallByCustomerId(IEnumerable<long> customerIds, DateTime startDate, bool excludeConfirmationCall)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IEnumerable<VwGetCallsEntity> entities = null;

                if (excludeConfirmationCall)
                {
                    var confirmQueueId = (from cc in linqMetaData.CallQueue
                                          where cc.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                                          select cc.CallQueueId).SingleOrDefault();

                    entities = (from c in linqMetaData.VwGetCalls
                                where c.CalledCustomerId > 0 && customerIds.Contains(c.CalledCustomerId)
                               && c.DateCreated >= startDate
                               && c.CallQueueId != confirmQueueId
                                select c).ToArray();
                }
                else
                {
                    entities = (from c in linqMetaData.VwGetCalls
                                where c.CalledCustomerId > 0 && customerIds.Contains(c.CalledCustomerId)
                               && c.DateCreated >= startDate
                                select c).ToArray();
                }



                return Mapper.Map<IEnumerable<VwGetCallsEntity>, IEnumerable<Call>>(entities);
            }
        }

        public IEnumerable<Call> GetCallByCustomerIdAndCallQueue(IEnumerable<long> customerIds, string category)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IEnumerable<VwGetCallsEntity> entities = null;

                var callQueueId = (from cc in linqMetaData.CallQueue
                                   where cc.Category == HealthPlanCallQueueCategory.AppointmentConfirmation
                                   select cc.CallQueueId).SingleOrDefault();

                entities = (from c in linqMetaData.VwGetCalls
                            where c.CalledCustomerId > 0 && customerIds.Contains(c.CalledCustomerId)
                           && (c.CallQueueId == callQueueId || c.Disposition == ProspectCustomerTag.PatientConfirmed.ToString())
                           && c.Status != (long)CallStatus.Initiated
                            select c).ToArray();

                return Mapper.Map<IEnumerable<VwGetCallsEntity>, IEnumerable<Call>>(entities);
            }
        }

        public bool UpdateCallersPhoneNumber(long callId, string patientPhoneNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callEntity = new CallsEntity() { CallersPhoneNumber = patientPhoneNumber, CallBackNumber = patientPhoneNumber };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }
            return true;
        }

        public void SaveCallDispositionAndIsContacted(long callId, string disposition, long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callEntity = new CallsEntity() { Disposition = disposition, IsContacted = callQueueCustomerId > 0 ? true : (bool?)null };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }

        }

        public Call GetSecondLastCall(long customerId, long excludeLastCallId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cl in linqMetaData.Calls
                              where cl.CallId != excludeLastCallId && cl.CalledCustomerId == customerId
                              && cl.Status != (long)CallStatus.Initiated
                              orderby cl.DateCreated descending
                              select cl).FirstOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<CallsEntity, Call>(entity);
            }
        }
        public bool UpdateCallCenterCallEvent(long eventId, long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var callEntity = new CallsEntity() { EventId = eventId };
                var bucket = new RelationPredicateBucket(CallsFields.CallId == callId);

                if (adapter.UpdateEntitiesDirectly(callEntity, bucket) == 0)
                    throw new PersistenceFailureException("CallId doesn't exist");
            }
            return true;
        }
       
        public IEnumerable<Call> GetCallByCustomerIdAndCallQueuePreAssessment(IEnumerable<long> customerIds, string category)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IEnumerable<VwGetCallsEntity> entities = null;

                var callQueueId = (from cc in linqMetaData.CallQueue
                                   where cc.Category == HealthPlanCallQueueCategory.PreAssessmentCallQueue
                                   select cc.CallQueueId).SingleOrDefault();

                entities = (from c in linqMetaData.VwGetCalls
                            where c.CalledCustomerId > 0 && customerIds.Contains(c.CalledCustomerId)
                           && (c.CallQueueId == callQueueId || c.Disposition == ProspectCustomerTag.PatientConfirmed.ToString())
                           && c.Status != (long)CallStatus.Initiated
                            select c).ToArray();

                return Mapper.Map<IEnumerable<VwGetCallsEntity>, IEnumerable<Call>>(entities);
            }
        }
    }
}
