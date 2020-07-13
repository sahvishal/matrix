using System;
using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventCustomerAggregateRepository
    {
        EventCustomerAggregate GetEventCustomerById(long eventCustomerId);
        List<EventCustomerAggregate> GetEventCustomersByIds(long[] eventCustomerIds);
        EventCustomerAggregate GetRegisteredEvent(long customerId, long eventId);
        List<EventCustomerAggregate> GetAllEventCustomerInfoBySalesRep(int salesRepId);
        List<EventCustomerAggregate> GetEventCustomerInfoBySalesRep(long salesRepId, DateTime eventStartDate);
        List<EventCustomerAggregate> GetEventCustomerInfoBySalesRep(long salesRepId, DateRange eventDateRange);
    }
}