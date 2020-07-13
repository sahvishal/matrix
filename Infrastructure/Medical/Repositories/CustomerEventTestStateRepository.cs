using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class CustomerEventTestStateRepository : PersistenceRepository, ICustomerEventTestStateRepository
    {
        private readonly DateTime _resultFlowChangeDate;

        public CustomerEventTestStateRepository(ISettings settings)
        {
            _resultFlowChangeDate = settings.ResultFlowChangeDate;
        }

        public IEnumerable<CustomerEventTestState> GetCustomerEventTestState(long[] customerEventScreeningTestId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cets in linqMetaData.CustomerEventTestState
                                where customerEventScreeningTestId.Contains(cets.CustomerEventScreeningTestId)
                                select cets).ToArray();

                return Mapper.Map<IEnumerable<CustomerEventTestStateEntity>, IEnumerable<CustomerEventTestState>>(entities);
            }
        }

        public IEnumerable<CustomerEventTestState> GetForLabInboundReport(LabsInboundFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = filter.AccountId > 0 ? (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault() : null;

                var query = (from ecr in linqMetaData.EventCustomerResult
                             join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                             join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                             join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                             join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                             join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                             join e in linqMetaData.Events on ecr.EventId equals e.EventId
                             where (ec.NoShow == false && ec.LeftWithoutScreeningReasonId == null)
                             && (ea.CheckinTime != null && ea.CheckoutTime != null)
                             && (!linqMetaData.TestNotPerformed.Select(x => x.CustomerEventScreeningTestId).Contains(cest.CustomerEventScreeningTestId))
                             && (filter.StartDate == null || ecr.DateModified >= filter.StartDate || ecr.RegenerationDate >= filter.StartDate)
                             && (filter.EndDate == null || ecr.DateModified <= filter.EndDate || ecr.RegenerationDate <= filter.EndDate)
                             && (account == null || cp.Tag == account.Tag)
                             && ((e.EventDate < _resultFlowChangeDate && ecr.ResultState == (int)TestResultStateNumber.ResultDelivered)
                             || (e.EventDate >= _resultFlowChangeDate && ecr.ResultState == (int)NewTestResultStateNumber.ResultDelivered))
                             select new { cets, ec.CustomerId });

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    var customTagCustomersIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && filter.CustomTags.Contains(ct.Tag) select ct.CustomerId);
                    query = (from q in query where customTagCustomersIds.Contains(q.CustomerId) select q);
                }

                var entities = (from q in query select q.cets);

                totalRecords = entities.Count();

                var result = entities.OrderByDescending(x => x.CreatedOn).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

                return Mapper.Map<IEnumerable<CustomerEventTestStateEntity>, IEnumerable<CustomerEventTestState>>(result);
            }
        }

        public bool IsPatientCritical(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cets in linqMetaData.CustomerEventTestState
                                join cest in linqMetaData.CustomerEventScreeningTests on cets.CustomerEventScreeningTestId equals cest.CustomerEventScreeningTestId
                                where cest.EventCustomerResultId == eventCustomerId
                                && cets.IsCritical
                                select cets);

                return entities.Any();
            }
        }
        public bool IsPatientCriticalForHIPTest(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cets in linqMetaData.CustomerEventTestState
                                join cest in linqMetaData.CustomerEventScreeningTests on cets.CustomerEventScreeningTestId equals cest.CustomerEventScreeningTestId
                                join ecr in linqMetaData.EventCustomers on cest.EventCustomerResultId equals ecr.EventCustomerId
                                join et in linqMetaData.EventTest on ecr.EventId equals et.EventId
                                where ecr.EventId == eventId && ecr.CustomerId == customerId && et.TestId == cest.TestId && et.ResultEntryTypeId == (long)ResultEntryType.Hip
                                && cets.IsCritical
                                select cets);


                return entities.Any();
            }
        }
    }
}