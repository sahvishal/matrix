using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class PreAssessmentCustomerCallQueueCallAttemptRepository : PersistenceRepository, IPreAssessmentCustomerCallQueueCallAttemptRepository
    {
        public PreAssessmentCustomerCallQueueCallAttempt GetCustomerCallQueueCallPreAssessmentAttemptIfCustomerLockedforAgent(long customerId, long createdBy, long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var lockedCallQueueCustomer = (from cqcl in linqMetaData.PreAssessmentCallQueueCustomerLock
                                               where cqcl.CustomerId.HasValue && cqcl.CustomerId.Value == customerId && cqcl.CreatedBy == createdBy
                                               select cqcl).FirstOrDefault();

                if (lockedCallQueueCustomer != null)
                {
                    var entity = (from ccqca in linqMetaData.PreAssessmentCustomerCallQueueCallAttempt
                                  join c in linqMetaData.Calls on ccqca.CallId equals c.CallId
                                  where c.EventId == eventId && ccqca.CustomerId == customerId && ccqca.CreatedBy == createdBy
                                  && ccqca.DateCreated >= lockedCallQueueCustomer.CreatedOn.Date
                                  orderby ccqca.DateCreated descending
                                  select ccqca).FirstOrDefault();

                    return entity == null ? null : Mapper.Map<PreAssessmentCustomerCallQueueCallAttemptEntity, PreAssessmentCustomerCallQueueCallAttempt>(entity);
                }

                return null;
            }
        }
        public PreAssessmentCustomerCallQueueCallAttempt Save(PreAssessmentCustomerCallQueueCallAttempt domain, bool refatch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PreAssessmentCustomerCallQueueCallAttempt, PreAssessmentCustomerCallQueueCallAttemptEntity>(domain);
                if (!adapter.SaveEntity(entity, refatch))
                {
                    throw new PersistenceFailureException();
                }
                return !refatch
                    ? domain
                    : Mapper.Map<PreAssessmentCustomerCallQueueCallAttemptEntity, PreAssessmentCustomerCallQueueCallAttempt>(entity);
            }
        }
        public PreAssessmentCustomerCallQueueCallAttempt GetByCallId(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ccc in linqMetaData.PreAssessmentCustomerCallQueueCallAttempt
                              where ccc.CallId == callId
                              select ccc).SingleOrDefault();

                return entity == null ? null : Mapper.Map<PreAssessmentCustomerCallQueueCallAttemptEntity, PreAssessmentCustomerCallQueueCallAttempt>(entity);
            }
        }

        //public CallQueueCustomer GetByCallIdAndcustomerId(long callId, long customerId)
        //{
        //    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var linqMetaData = new LinqMetaData(adapter);


        //        CallQueueCustomer callQueueCustomer = new CallQueueCustomer();
        //        var calls = (from cp in linqMetaData.Calls where cp.CallId == callId && cp.CalledCustomerId == (long)customerId select cp).FirstOrDefault();

        //        var customerProfile = (from cp in linqMetaData.CustomerProfile where cp.CustomerId == calls.CalledCustomerId select cp).FirstOrDefault();
        //        var organizationRoleUser = (from org in linqMetaData.OrganizationRoleUser where org.OrganizationRoleUserId == calls.CalledCustomerId select org).FirstOrDefault();
        //        var user = (from org in linqMetaData.User where org.UserId == organizationRoleUser.UserId select org).FirstOrDefault();
        //        var address = (from ad in linqMetaData.Address where ad.AddressId == customerProfile.BillingAddressId select ad);
        //        var eventCustomer = (from ec in linqMetaData.EventCustomers where ec.EventId == calls.EventId && ec.CustomerId == calls.CalledCustomerId select ec).FirstOrDefault();
        //        var eventAccount = (from ea in linqMetaData.EventAccount where ea.EventId == calls.EventId select ea).FirstOrDefault();
        //        var eventAppointment = (from ea in linqMetaData.EventAppointment where ea.AppointmentId == eventCustomer.AppointmentId select ea).FirstOrDefault();
        //        var prospectCustomer = (from pc in linqMetaData.ProspectCustomer where pc.CustomerId == calls.CalledCustomerId select pc).FirstOrDefault();

        //        callQueueCustomer.CustomerId = calls.CalledCustomerId;
        //        callQueueCustomer.FirstName = user.FirstName;
        //        callQueueCustomer.LastName = user.LastName;
        //        callQueueCustomer.MiddleName = user.MiddleName;
        //        callQueueCustomer.EventId = calls.EventId;
        //        callQueueCustomer.EventCustomerId = eventCustomer.EventCustomerId;
        //        callQueueCustomer.HealthPlanId = eventAccount.AccountId;
        //        callQueueCustomer.AppointmentDate = eventAppointment.StartTime;
        //        callQueueCustomer.CallQueueId = (long)calls.CallQueueId;
        //        callQueueCustomer.ProspectCustomerId = prospectCustomer.ProspectCustomerId;

        //        return callQueueCustomer;
        //    }
        //}

        public IEnumerable<PreAssessmentCallCustomer> GetForPreAssessmentReport(PreAssessmentReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueue = (from cq in linqMetaData.CallQueue where cq.Category == HealthPlanCallQueueCategory.PreAssessmentCallQueue select cq).Single();

                var temp1 = (from cqcc in linqMetaData.PreAssessmentCustomerCallQueueCallAttempt
                             join c in linqMetaData.Calls on cqcc.CallId equals c.CallId
                             where (c.CallQueueId == callQueue.CallQueueId || c.Disposition == ProspectCustomerTag.PatientConfirmed.ToString())
                             && c.Status != (long)CallStatus.Initiated
                             group cqcc.CallId by cqcc.CustomerId
                                 into grp
                                 select new { CustomerId = grp.Key, CallId = grp.Max() });



                var query = (from cqc in linqMetaData.PreAssessmentCustomerCallQueueCallAttempt
                             join t in temp1 on cqc.CallId equals t.CallId
                             join c in linqMetaData.Calls on t.CallId equals c.CallId
                             join ec in linqMetaData.EventCustomers on new { CustomerId = t.CustomerId, EventId = c.EventId.Value } equals new { CustomerId = ec.CustomerId, EventId = ec.EventId }
                             where c.CallQueueId == callQueue.CallQueueId
                             && cqc.CustomerId != null && cqc.CustomerId > 0
                             && c.CalledCustomerId != null && c.EventId != null
                                 && c.Status != (long)CallStatus.Initiated
                             select new { c.CalledCustomerId, c.EventId, c.HealthPlanId, c.TimeCreated, c.Disposition, t.CallId, ec.EventCustomerId });

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

                totalRecords = query.Count();

                var model = query.OrderByDescending(x => x.TimeCreated).Select(x => new PreAssessmentCallCustomer
                {
                    HealthPlanId = x.HealthPlanId,
                    CustomerId = x.CalledCustomerId,
                    EventId = x.EventId,
                    CallId = x.CallId,
                    EventCustomerID = x.EventCustomerId
                }).TakePage(pageNumber, pageSize).ToArray();

                return model;
            }
        }




    }
}
