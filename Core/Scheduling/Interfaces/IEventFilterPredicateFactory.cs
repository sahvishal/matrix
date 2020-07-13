using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling.Interfaces
{
    public interface IEventFilterPredicateFactory
    {
        Func<Event, bool> CreateEventFilterPredicate(ViewType viewType, string invitationCode, DateTime? fromDate,
                                                     DateTime? toDate);
    }
}