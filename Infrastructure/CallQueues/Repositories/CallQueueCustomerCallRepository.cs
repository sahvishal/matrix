using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class CallQueueCustomerCallRepository : PersistenceRepository, ICallQueueCustomerCallRepository
    {

        public IEnumerable<CallQueueCustomerCall> GetByCallQueueCustomerIds(IEnumerable<long> callQueueCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var enetities = (from cqcc in linqMetaData.CallQueueCustomerCall
                                 where callQueueCustomerIds.Contains(cqcc.CallQueueCustomerId)
                                 select cqcc).ToArray();

                return Mapper.Map<IEnumerable<CallQueueCustomerCallEntity>, IEnumerable<CallQueueCustomerCall>>(enetities);
            }
        }

        public void Save(CallQueueCustomerCall domain, bool refatch = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CallQueueCustomerCall, CallQueueCustomerCallEntity>(domain);
                if (!adapter.SaveEntity(entity, refatch))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<CallQueueCustomerCallDetails> GetHealthPlanCallQueueCallReports(CallQueueSchedulingReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                filter = filter ?? new CallQueueSchedulingReportFilter();

                var query = (from ocr in linqMetaData.VwCallQueueCustomerCallDetails select ocr);

                if (filter.HealthPlanId > 0)
                {
                    query = (from ocr in linqMetaData.VwCallQueueCustomerCallDetails where ocr.HealthPlanId == filter.HealthPlanId select ocr);
                }

                if (filter.CallQueueId > 0)
                {
                    query = (from ocr in query where ocr.CallQueueId == filter.CallQueueId select ocr);
                }

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



                totalRecords = query.Count();

                var entities = query.OrderByDescending(x => x.DateCreated).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return Mapper.Map<IEnumerable<VwCallQueueCustomerCallDetailsEntity>, IEnumerable<CallQueueCustomerCallDetails>>(entities);
            }
        }

        public long GetCallQueueCustomerIdByCallId(long callId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var callQueueCustomerId = (from cqcc in linqMetaData.CallQueueCustomerCall
                                           where cqcc.CallId == callId
                                           select cqcc.CallQueueCustomerId).SingleOrDefault();

                return callQueueCustomerId;
            }
        }
    }
}
