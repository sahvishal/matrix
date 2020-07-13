using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class EventAppointmentBasicInfoModelFactory : IEventAppointmentBasicInfoModelFactory
    {
        public EventAppointmentListModel Create(IEnumerable<EventSchedulingSlot> appointmentSlots, Event eventData, IEnumerable<EventPodRoom> eventPodRooms)
        {
            var eventAppointmentListModel = new EventAppointmentListModel();
            var eventAppointmentBasicInfoModels = Create(appointmentSlots);

            eventAppointmentListModel.EventAppointmentViewModel = eventAppointmentBasicInfoModels.OrderBy(ep => ep.StartTime);
            eventAppointmentListModel.EventPodRooms = eventPodRooms;
            if (eventData != null)
            {
                eventAppointmentListModel.EventId = eventData.Id;
                eventAppointmentListModel.EventName = eventData.Name;
                eventAppointmentListModel.EventDate = eventData.EventDate;
            }
            return eventAppointmentListModel;
        }

        public EventAppointmentListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<EventSchedulingSlot> appointmentSlots, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages,
            IEnumerable<OrderedPair<long, string>> tests, Event eventData, IEnumerable<Appointment> bookedAppointments, IEnumerable<EventPodRoom> eventPodRooms)
        {

            var eventAppointmentListModel = new EventAppointmentListModel();
            var eventAppointmentBasicInfoModels = new List<EventAppointmentBasicInfoModel>();

            var freeSlots = appointmentSlots.Where(ap => ap.Status != AppointmentStatus.Booked).Select(ap => ap).ToArray();

            if (!freeSlots.IsNullOrEmpty())
            {
                var unBookedModels = Create(freeSlots);
                eventAppointmentBasicInfoModels.AddRange(unBookedModels);
            }

            if (!bookedAppointments.IsNullOrEmpty())
            {
                var bookedSlots = appointmentSlots.Where(ap => ap.Status == AppointmentStatus.Booked).Select(ap => ap).ToArray();
                var bookedModels = Create(eventCustomers, customers, packages, tests, bookedAppointments, bookedSlots);
                eventAppointmentBasicInfoModels.AddRange(bookedModels);
            }

            if (eventData != null)
            {
                eventAppointmentListModel.EventId = eventData.Id;
                eventAppointmentListModel.EventName = eventData.Name;
                eventAppointmentListModel.EventDate = eventData.EventDate;
            }
            eventAppointmentListModel.EventPodRooms = eventPodRooms;
            eventAppointmentListModel.EventAppointmentViewModel = eventAppointmentBasicInfoModels.OrderBy(ea => ea.StartTime);

            return eventAppointmentListModel;
        }

        public IEnumerable<EventAppointmentBasicInfoModel> Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests,
            IEnumerable<Appointment> bookedAppointments, IEnumerable<EventSchedulingSlot> appointmentSlots)
        {

            var eventAppointmentBasicInfoModels = new List<EventAppointmentBasicInfoModel>();

            var slotIdAppointmentIdPairs = (from bookedAppointment in bookedAppointments from slotId in bookedAppointment.SlotIds select new OrderedPair<long, long>(slotId, bookedAppointment.Id)).ToList();

            appointmentSlots.ToList()
                .ForEach(slot =>
                             {
                                 var appointmentId = slotIdAppointmentIdPairs.Where(sa => sa.FirstValue == slot.Id).Select(sa => sa.SecondValue).SingleOrDefault();

                                 var eventCustomer = eventCustomers.SingleOrDefault(ec => ec.AppointmentId == appointmentId);

                                 var customerName = string.Empty;
                                 var orderPurchased = string.Empty;

                                 long customerid = 0;

                                 if (eventCustomer != null)
                                 {
                                     customerName = customers.Where(c => c.CustomerId == eventCustomer.CustomerId).SingleOrDefault().NameAsString;

                                     customerid = eventCustomer.CustomerId;

                                     var package = packages.Where(p => p.FirstValue == eventCustomer.Id).FirstOrDefault();

                                     var selectedTests = tests.Where(t => t.FirstValue == eventCustomer.Id);

                                     if (package != null)
                                         orderPurchased = package.SecondValue;

                                     if (selectedTests.Count() > 0)
                                     {
                                         orderPurchased = string.IsNullOrEmpty(orderPurchased)
                                                              ? string.Join(" + ", selectedTests.Select(s => s.SecondValue))
                                                              : orderPurchased + " + " + string.Join(" + ", selectedTests.Select(s => s.SecondValue));
                                     }
                                 }

                                 var eventAppointmentEditModel = new EventAppointmentBasicInfoModel
                                                                     {
                                                                         AppointmentId = appointmentId,
                                                                         AppointmentStatus = AppointmentStatus.Booked,
                                                                         CustomerId = customerid,
                                                                         OrderPurchased = orderPurchased,
                                                                         Name = customerName,
                                                                         StartTime = slot.StartTime,
                                                                         EndTime = slot.EndTime,
                                                                         EventPodRoomId = slot.EventPodRoomId
                                                                     };
                                 eventAppointmentBasicInfoModels.Add(eventAppointmentEditModel);
                             });
            return eventAppointmentBasicInfoModels;
        }

        public IEnumerable<EventAppointmentBasicInfoModel> Create(IEnumerable<EventSchedulingSlot> appointmentSlots)
        {
            var eventAppointmentBasicInfoModels = new List<EventAppointmentBasicInfoModel>();

            appointmentSlots.ToList().ForEach(ap =>
                                                  {
                                                      var eventAppointmentEditModel = new EventAppointmentBasicInfoModel
                                                                                          {
                                                                                              AppointmentId = ap.Id,
                                                                                              AppointmentStatus = ap.Status,
                                                                                              StartTime = ap.StartTime,
                                                                                              EndTime = ap.EndTime,
                                                                                              Reason = ap.Reason,
                                                                                              EventPodRoomId = ap.EventPodRoomId
                                                                                          };
                                                      eventAppointmentBasicInfoModels.Add(eventAppointmentEditModel);
                                                  });
            return eventAppointmentBasicInfoModels;
        }
    }
}
