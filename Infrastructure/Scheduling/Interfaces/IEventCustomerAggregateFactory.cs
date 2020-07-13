using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Scheduling.Interfaces
{
    public interface IEventCustomerAggregateFactory
    {
        List<EventCustomerAggregate> CreateAggregatesFromTypedViewCollection
            (CustomerEventBasicInfoTypedView customerEventBasicInfoTypedView);
        EventCustomerAggregate GetEventCustomerAggregateFromTypedViewRow(CustomerEventBasicInfoRow customerEventInfo);

        EventCustomerAggregate CreateEventCustomerAggregate(EventCustomer eventCustomer);
    }
}