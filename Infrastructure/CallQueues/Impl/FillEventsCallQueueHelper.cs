using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class FillEventsCallQueueHelper : IFillEventsCallQueueHelper
    {
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;

        public FillEventsCallQueueHelper(IEventSchedulingSlotRepository eventSchedulingSlotRepository)
        {
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
        }

        public IEnumerable<Event> GetAllTheEventFilledUnderPecentage(IEnumerable<Event> events, decimal percentage)
        {
            var list = new List<Event>();
            foreach (Event theEvent in events)
            {
                var slots = _eventSchedulingSlotRepository.GetbyEventId(theEvent.Id);
                var filledSlotsCount = slots.Count(s => s.Status == AppointmentStatus.Booked);
                var blockedSlotsCount = slots.Count(s => s.Status == AppointmentStatus.Blocked);
                var totalSlotsCount = slots.Count() - blockedSlotsCount;

                if (percentage > 0 && totalSlotsCount > 0)
                {
                    var bookingPercentage = ((filledSlotsCount * 100) / totalSlotsCount);
                    if (bookingPercentage <= percentage) list.Add(theEvent);
                }
            }
            return list;
        }
    }
}
