using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class EventAppointmentOnlineListModelFactory : IEventAppointmentOnlineListModelFactory
    {
        public EventAppointmentOnlineListModel Create(IEnumerable<EventSchedulingSlot> appointmentSlots)
        {
            var modal = new EventAppointmentOnlineListModel();

            if (appointmentSlots != null && appointmentSlots.Any())
            {
                var appointmentSlotList = appointmentSlots.ToList();
                var onlineSlots = new List<EventAppointmentOnlineModel>();
                appointmentSlotList.ForEach(x => onlineSlots.Add(new EventAppointmentOnlineModel
                {
                    AppointmentId = x.Id,
                    AppointmentStatus = x.Status,
                    EndTime = x.EndTime,
                    StartTime = x.StartTime
                }));

                var morningEndTime = appointmentSlotList.First().StartTime.Date.AddHours(12);
                modal.MorningSlots = onlineSlots.OrderBy(x => x.StartTime).Where(x => x.StartTime < morningEndTime);
                var afterNoonEndTime = appointmentSlotList.First().StartTime.Date.AddHours(16);
                modal.AfterNoonSlots = onlineSlots.OrderBy(x => x.StartTime).Where(x => x.StartTime >= morningEndTime && x.StartTime < afterNoonEndTime);
                modal.EveningSlots = onlineSlots.OrderBy(x => x.StartTime).Where(x => x.StartTime >= afterNoonEndTime);
            }
            else
            {
                modal.MorningSlots = new List<EventAppointmentOnlineModel>();
                modal.AfterNoonSlots = new List<EventAppointmentOnlineModel>();
                modal.EveningSlots = new List<EventAppointmentOnlineModel>();
            }

            return modal;
        }
    }
}
