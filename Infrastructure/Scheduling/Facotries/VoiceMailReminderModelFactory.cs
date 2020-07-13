using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Enum;
namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class VoiceMailReminderModelFactory : IVoiceMailReminderModelFactory
    {
        public VoiceMailReminderListModel Create(IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Customer> customers,
            IEnumerable<OrderedPair<long, string>> packages, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> tests)
        {
            var model = new VoiceMailReminderListModel();
            var voiceMailReminderModels = new List<VoiceMailReminderModel>();

            eventCustomers.ToList().ForEach(ec =>
            {
                var eventModel = eventListModel.Collection.Where(e => e.EventCode == ec.EventId).FirstOrDefault();

                var customer = customers.Where(c => c.CustomerId == ec.CustomerId).FirstOrDefault();

                var order = orders.Where(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId).FirstOrDefault();

                var package = packages.Where(p => p.FirstValue == order.Id).FirstOrDefault();

                var test = tests.Where(p => p.FirstValue == order.Id).ToList();

                var productPurchased = string.Empty;

                if (package != null && !test.IsNullOrEmpty())
                    productPurchased =
                        package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (!test.IsNullOrEmpty())
                    productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (package != null)
                    productPurchased =
                        package.SecondValue;


                var sponsorName = eventModel.EventType.ToLower() == EventType.Corporate.ToString().ToLower() ? eventModel.CorporateAccount : eventModel.HospitalPartner;


                var voiceMailReminderModel = new VoiceMailReminderModel()
                {
                    CustomerId = ec.CustomerId,
                    EventId = eventModel.EventCode,
                    PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                    SponsoredBy = sponsorName,
                    EventDate = eventModel.EventDate,
                    Address = eventModel.Address,
                    Package = productPurchased,
                    AppointmentTime = ec.AppointmentId.HasValue ? (DateTime?)appointments.Where(a => a.Id == ec.AppointmentId.Value).FirstOrDefault().StartTime : null,
                };

                voiceMailReminderModels.Add(voiceMailReminderModel);
            });
            model.Collection = voiceMailReminderModels;
            return model;
        }
    }
}
