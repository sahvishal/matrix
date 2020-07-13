using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation]
    public class HospitalPartnerEventListFactory : IHospitalPartnerEventListFactory
    {
        public IEnumerable<HospitalPartnerEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> screenedCustomersCount,
            IEnumerable<OrderedPair<long, int>> criticalCustomersCount, IEnumerable<OrderedPair<long, int>> abnormalCustomersCount,
            IEnumerable<OrderedPair<long, long>> eventIdNotesIdPairs, IEnumerable<Notes> notes, IEnumerable<OrderedPair<long, int>> urgentCustomersCount, IEnumerable<OrderedPair<long, int>> normalCustomersCount, 
            IEnumerable<OrderedPair<long, string>> idNamePairs)
        {
            var hospitalPartnerEventViewModels = new List<HospitalPartnerEventViewModel>();

            events.ToList().ForEach(e =>
                                        {
                                            var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();

                                            var secreenedCustomers = screenedCustomersCount.Where(sc => sc.FirstValue == e.Id).FirstOrDefault();
                                            
                                            var abnormalCustomers = abnormalCustomersCount.Where(ac => ac.FirstValue == e.Id).FirstOrDefault();
                                            var criticalCustomers = criticalCustomersCount.Where(cc => cc.FirstValue == e.Id).FirstOrDefault();
                                            var urgentCustomers = urgentCustomersCount.Where(uc => uc.FirstValue == e.Id).FirstOrDefault();
                                            var normalCustomers = normalCustomersCount.Where(nc => nc.FirstValue == e.Id).FirstOrDefault();
                                            
                                            var abnormal = abnormalCustomers != null ? abnormalCustomers.SecondValue : 0;
                                            var critical = criticalCustomers != null ? criticalCustomers.SecondValue : 0;
                                            var urgent = urgentCustomers != null ? urgentCustomers.SecondValue : 0;
                                            var normal = normalCustomers != null ? normalCustomers.SecondValue : 0;
                                           

                                            IEnumerable<Notes> eventNotes = null;
                                            if (eventIdNotesIdPairs != null && eventIdNotesIdPairs.Count() > 0)
                                            {
                                                var notesIds = eventIdNotesIdPairs.Where(en => en.FirstValue == e.Id).Select(en => en.SecondValue).ToArray();

                                                eventNotes = notes.Where(n => notesIds.Contains(n.Id)).Select(n => n).ToArray();
                                            }
                                            hospitalPartnerEventViewModels.Add(new HospitalPartnerEventViewModel
                                                                                   {
                                                                                       EventId = e.Id,
                                                                                       EventDate = e.EventDate,
                                                                                       HostAddress =
                                                                                           host.OrganizationName + " - " +
                                                                                           host.Address.City + ", " +
                                                                                           host.Address.State + ", " +
                                                                                           host.Address.ZipCode.Zip,
                                                                                       ScreenedCustomers =
                                                                                           secreenedCustomers != null
                                                                                               ? secreenedCustomers.
                                                                                                     SecondValue
                                                                                               : 0,
                                                                                       NormalCustomers = normal,
                                                                                       CriticalCustomers = critical,
                                                                                       AbnormalCustomers = abnormal,
                                                                                       UrgentCustomers = urgent,
                                                                                       Notes = CreateNotesViewModel(eventNotes,idNamePairs)
                                                                                   });
                                        });

            return hospitalPartnerEventViewModels;
        }

        public HospitalPartnerEventViewModel Create(Event theEvent, Host host, DateTime? mailedDate)
        {
            return new HospitalPartnerEventViewModel
                       {
                           EventId = theEvent.Id,
                           EventDate = theEvent.EventDate,
                           HostAddress =
                               host.OrganizationName + " - " +
                               host.Address.City + ", " +
                               host.Address.State + ", " +
                               host.Address.ZipCode.Zip,
                           MailedDate = mailedDate

                       };
        }

        public IEnumerable<HospitalPartnerEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, DateTime>> recentEvents)
        {
            return (from recentEvent in recentEvents
                    let theEvent = events.Where(e => e.Id == recentEvent.FirstValue).Select(e => e).Single()
                    let host = hosts.Where(h => h.Id == theEvent.HostId).Select(h => h).Single()
                    select Create(theEvent, host, recentEvent.SecondValue)).ToList();
        }

        public IEnumerable<NotesViewModel> CreateNotesViewModel(IEnumerable<Notes> notes, IEnumerable<OrderedPair<long, string>> idNamePairs)
        {
            if (notes != null && notes.Count() > 0)
            {
                return (from note in notes
                        let idNamePair = idNamePairs.Where(inp => inp.FirstValue == note.DataRecorderMetaData.DataRecorderCreator.Id).Single()
                        select new NotesViewModel
                                   {
                                       Note = note.Text,
                                       CreatedByUser = idNamePair.SecondValue,
                                       EnteredOn = note.DataRecorderMetaData.DateCreated
                                   }).ToArray();
            }
            return null;

        }
    }
}
