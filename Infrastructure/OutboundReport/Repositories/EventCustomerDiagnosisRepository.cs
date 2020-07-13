using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class EventCustomerDiagnosisRepository : PersistenceRepository, IEventCustomerDiagnosisRepository
    {
        public IEnumerable<EventCustomerDiagnosis> GetByEventCustomerId(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecd in linqMetaData.EventCustomerDiagnosis
                                where ecd.EventCustomerId == eventCustomerId
                                select ecd).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerDiagnosisEntity>, IEnumerable<EventCustomerDiagnosis>>(entities);
            }
        }

        public IEnumerable<EventCustomerDiagnosis> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ecd in linqMetaData.EventCustomerDiagnosis
                                where eventCustomerIds.Contains(ecd.EventCustomerId)
                                select ecd).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerDiagnosisEntity>, IEnumerable<EventCustomerDiagnosis>>(entities);
            }
        }

        public EventCustomerDiagnosis Save(EventCustomerDiagnosis domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<EventCustomerDiagnosis, EventCustomerDiagnosisEntity>(domain);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<EventCustomerDiagnosisEntity, EventCustomerDiagnosis>(entity);
            }
        }

        public IEnumerable<EventCustomerDiagnosis> GetForConditionInboundReport(ConditionInboundFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = filter.AccountId > 0 ? (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault() : null;

                var query = (from ecd in linqMetaData.EventCustomerDiagnosis
                             join ec in linqMetaData.EventCustomers on ecd.EventCustomerId equals ec.EventCustomerId
                             join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                             where (filter.StartDate == null || (ecd.DateCreated != null && ecd.DateCreated >= filter.StartDate))
                                    && (filter.EndDate == null || (ecd.DateCreated != null && ecd.DateCreated <= filter.EndDate))
                                    && (account == null || cp.Tag == account.Tag)
                             select new { ecd, ec.CustomerId });

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId);
                    query = (from q in query where customTagCustomersIds.Contains(q.CustomerId) select q);
                }

                var entities = (from q in query select q.ecd);

                totalRecords = entities.Count();
                var results = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return Mapper.Map<IEnumerable<EventCustomerDiagnosisEntity>, IEnumerable<EventCustomerDiagnosis>>(results);
            }
        }
    }
}
