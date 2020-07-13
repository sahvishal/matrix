using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    class CustomerCallQueueCallAttemptRepository : PersistenceRepository, ICustomerCallQueueCallAttemptRepository
    {
        public CustomerCallQueueCallAttempt Save(CustomerCallQueueCallAttempt domain, bool refatch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CustomerCallQueueCallAttempt, CustomerCallQueueCallAttemptEntity>(domain);
                if (!adapter.SaveEntity(entity, refatch))
                {
                    throw new PersistenceFailureException();
                }
                return !refatch
                    ? domain
                    : Mapper.Map<CustomerCallQueueCallAttemptEntity, CustomerCallQueueCallAttempt>(entity);
            }
        }

        public CustomerCallQueueCallAttempt GetByCallQueueCustomerId(long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ccc in linqMetaData.CustomerCallQueueCallAttempt
                                where ccc.CallQueueCustomerId == callQueueCustomerId
                                orderby ccc.DateCreated descending
                                select ccc).FirstOrDefault();

                return Mapper.Map<CustomerCallQueueCallAttemptEntity, CustomerCallQueueCallAttempt>(entities);
            }
        }

        public IEnumerable<CustomerCallQueueCallAttempt> GetAllByCallQueueCustomerId(long callQueueCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ccc in linqMetaData.CustomerCallQueueCallAttempt
                                where ccc.CallQueueCustomerId == callQueueCustomerId
                                orderby ccc.CallAttemptId descending
                                select ccc).ToArray();

                return Mapper.Map<IEnumerable<CustomerCallQueueCallAttemptEntity>, IEnumerable<CustomerCallQueueCallAttempt>>(entities);
            }
        }

        public CustomerCallQueueCallAttempt GetById(long callAttemptId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ccc in linqMetaData.CustomerCallQueueCallAttempt
                                where ccc.CallAttemptId == callAttemptId
                                select ccc).FirstOrDefault();

                return Mapper.Map<CustomerCallQueueCallAttemptEntity, CustomerCallQueueCallAttempt>(entities);
            }
        }

        public CustomerCallQueueCallAttempt GetByCallId(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ccc in linqMetaData.CustomerCallQueueCallAttempt
                              where ccc.CallId == callId
                              select ccc).SingleOrDefault();

                return entity == null ? null : Mapper.Map<CustomerCallQueueCallAttemptEntity, CustomerCallQueueCallAttempt>(entity);
            }
        }

        public IEnumerable<CallSkippedReportEditModel> GetForCallSkippedReport(int pageNumber, int pageSize, CallSkippedReportFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = from gdfscr in linqMetaData.VwGetDataForSkippedCallReport select gdfscr;

                //moved this to View with No Lock
                //var query = (from ccqc in linqMetaData.CustomerCallQueueCallAttempt
                //             join cqc in linqMetaData.CallQueueCustomer on ccqc.CallQueueCustomerId equals cqc.CallQueueCustomerId
                //             where ccqc.IsCallSkipped == true
                //             select new { ccqc, cqc });

                if (filter != null)
                {
                    if (filter.DateTo == null && filter.DateFrom == null && filter.CallQueueId <= 0 && filter.HealthPlanId <= 0 && filter.CustomerId <= 0)  //user hit CLEAR button
                    {
                        filter.DateTo = DateTime.Today;
                        filter.DateFrom = DateTime.Today;
                    }

                    if (filter.CallQueueId > 0)
                    {
                        query = query.Where(x => x.CallQueueId == filter.CallQueueId);
                    }

                    if (filter.HealthPlanId > 0)
                    {
                        query = query.Where(x => x.HealthPlanId == filter.HealthPlanId);
                    }
                    if (filter.CustomerId > 0)
                    {
                        query = query.Where(x => x.CustomerId == filter.CustomerId);
                    }

                    //name filter
                    if (filter.AgentId == 0 && string.Compare(filter.AgentName, "No records found", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        query = query.Where(x => x.AgentId == 0);
                    }
                    else if (filter.AgentId > 0)
                    {
                        query = query.Where(x => x.AgentId == filter.AgentId);
                    }

                    //date filters
                    if (filter.DateFrom.HasValue && filter.DateTo.HasValue)
                    {
                        query = query.Where(x => x.SkipCallDate.Date >= filter.DateFrom.Value.Date && x.SkipCallDate.Date <= filter.DateTo.Value.Date);
                    }
                    else if (!filter.DateFrom.HasValue && filter.DateTo.HasValue)
                    {
                        query = query.Where(x => x.SkipCallDate.Date <= filter.DateTo.Value.Date);
                    }
                    else if (filter.DateFrom.HasValue && !filter.DateTo.HasValue)
                    {
                        query = query.Where(x => x.SkipCallDate.Date >= filter.DateFrom.Value.Date);
                    }
                }

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).OrderByDescending(x => x.SkipCallDate).ToList();
                return Mapper.Map<IEnumerable<VwGetDataForSkippedCallReportEntity>, IEnumerable<CallSkippedReportEditModel>>(entities);
            }
        }

        public CustomerCallQueueCallAttempt GetCustomerCallQueueCallAttemptIfCustomerLockedforAgent(long customerId, long createdBy)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var lockedCallQueueCustomer = (from cqcl in linqMetaData.CallQueueCustomerLock
                                               where cqcl.CustomerId.HasValue && cqcl.CustomerId.Value == customerId && cqcl.CreatedBy == createdBy
                                               select cqcl).FirstOrDefault();

                if (lockedCallQueueCustomer != null)
                {
                    var entity = (from ccqca in linqMetaData.CustomerCallQueueCallAttempt
                                  where ccqca.CallQueueCustomerId == lockedCallQueueCustomer.CallQueueCustomerId && ccqca.CreatedBy == createdBy
                                  && ccqca.DateCreated >= lockedCallQueueCustomer.CreatedOn.Date
                                  orderby ccqca.DateCreated descending
                                  select ccqca).FirstOrDefault();

                    return entity == null ? null : Mapper.Map<CustomerCallQueueCallAttemptEntity, CustomerCallQueueCallAttempt>(entity);
                }

                return null;
            }
        }
    }
}