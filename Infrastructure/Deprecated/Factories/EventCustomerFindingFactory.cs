using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Deprecated.Factories
{
    public interface IEventCustomerFindingFactory
    {
        EventCustomersFindingEditModel Create(Event selectedEvent, IEnumerable<CustomerItemizedReceiptModel> reciepts, IEnumerable<EventTest> eventTests,
                                                              IEnumerable<CustomerEventTestFindingEntity> entities, IEnumerable<CustomerEventTestPhysicianNoteEntity> physicianNoteEntities, IEnumerable<Customer> customers,IEnumerable<Pod> pod);
    }

    [DefaultImplementation]
    public class EventCustomerFindingFactory : IEventCustomerFindingFactory
    {
        public EventCustomersFindingEditModel Create(Event selectedEvent, IEnumerable<CustomerItemizedReceiptModel> reciepts, IEnumerable<EventTest> eventTests,
                                                        IEnumerable<CustomerEventTestFindingEntity> entities, IEnumerable<CustomerEventTestPhysicianNoteEntity> physicianNoteEntities, IEnumerable<Customer> customers, IEnumerable<Pod> pod)
        {
            var model = new EventCustomersFindingEditModel
                            {
                                EventDate = selectedEvent.EventDate,
                                EventId = selectedEvent.Id,
                                EventTests = eventTests != null ? eventTests.Select(et => et.Test).ToArray() : null,
                                Host = reciepts != null && reciepts.Count() > 0 ? reciepts.First().Host : string.Empty,
                                Pod = string.Join(",",pod.Select(pn => pn.Name))
                            };

            var customerFindingEditModels = reciepts.Select(reciept =>
                                                                {
                                                                    var customer = customers.Where(c => c.CustomerId == reciept.CustomerId).FirstOrDefault();

                                                                    var physicianNote =
                                                                        physicianNoteEntities.Where(pe => pe.EventId == reciept.EventId && pe.CustomerId == reciept.CustomerId).FirstOrDefault();

                                                                    string phone = customer.HomePhoneNumber != null
                                                                                       ? customer.HomePhoneNumber.
                                                                                             ToString()
                                                                                       : (customer.OfficePhoneNumber !=
                                                                                          null
                                                                                              ? customer.
                                                                                                    OfficePhoneNumber.
                                                                                                    ToString()
                                                                                              : (customer.
                                                                                                     MobilePhoneNumber !=
                                                                                                 null
                                                                                                     ? customer.
                                                                                                           MobilePhoneNumber
                                                                                                           .ToString()
                                                                                                     : string.Empty));

                                                                    return new CustomerTestFindingEditModel
                                                                               {
                                                                                   CustomerId = reciept.CustomerId,
                                                                                   CustomerName = reciept.CustomerName,
                                                                                   Phone = phone,
                                                                                   Notes = physicianNote != null ? physicianNote.PhysicianNotes : string.Empty,
                                                                                   Tests = reciept.Items.Where(i =>i.ItemType ==OrderItemType.EventPackageItem ||i.ItemType ==OrderItemType.EventTestItem)
                                                                                            .Select(i =>new TestFindingEditModel()
                                                                                            {
                                                                                                Finding =GetifCustomerFindingforTestisAbnormal(selectedEvent.Id, reciept.CustomerId, i.ItemId, entities),
                                                                                                TestType = (TestType)i.ItemId
                                                                                            }).ToArray()
                                                                                };
                                                                }).ToList();
                                                                

            model.Customers = customerFindingEditModels.OrderBy(cf => cf.CustomerName);
            return model;
        }

        private static Finding GetifCustomerFindingforTestisAbnormal(long eventId, long customerId, long testId, IEnumerable<CustomerEventTestFindingEntity> entities)
        {
            var entity = entities.Where(e => e.EventId == eventId && e.CustomerId == customerId && e.TestId == testId).
                SingleOrDefault();

            if (entity == null) return Finding.Unknown;

            return (Finding)entity.Finding;
        }

    }
}