using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class CdImageStatusModelFactory : ICdImageStatusModelFactory
    {
        public CdImageStatusListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<OrderedPair<long, ShipmentStatus>> orderShipingStatuses,
            IEnumerable<Customer> customers, IEnumerable<Event> events)
        {
            var model = new CdImageStatusListModel();
            var cdImageStatusModels = new List<CdImageStatusModel>();

            eventCustomers.ToList().ForEach(ec =>
                                                {
                                                    var orderShipingStatus = orderShipingStatuses.Where(os => os.FirstValue == ec.Id).FirstOrDefault();

                                                    var status = orderShipingStatus == null ? 0 :
                                                        orderShipingStatuses.Where(os => os.FirstValue == ec.Id).
                                                            FirstOrDefault().SecondValue;

                                                    var selectedEvent =
                                                        events.Where(e => e.Id == ec.EventId).FirstOrDefault();

                                                    var customer =
                                                        customers.Where(c => c.CustomerId == ec.CustomerId).
                                                            FirstOrDefault();

                                                    cdImageStatusModels.Add(new CdImageStatusModel
                                                                                {
                                                                                    Address = new AddressViewModel
                                                                                                  {
                                                                                        StreetAddressLine1 = customer.Address.StreetAddressLine1,
                                                                                        StreetAddressLine2 = customer.Address.StreetAddressLine2,
                                                                                        City = customer.Address.City,
                                                                                        Country = customer.Address.Country,
                                                                                        State = customer.Address.State,
                                                                                        ZipCode = customer.Address.ZipCode.Zip
                                                                                    },
                                                                                    CdImageStatus = status != 0 ? status.ToString() : " Not Available ",
                                                                                    CustomerCode = customer.CustomerId.ToString(),
                                                                                    EventDate = selectedEvent.EventDate,
                                                                                    CustomerId = customer.CustomerId,
                                                                                    EventId = selectedEvent.Id,
                                                                                    Name = customer.NameAsString
                                                                                });

                                                });

            model.Collection = cdImageStatusModels;
            return model;
        }
    }
}
