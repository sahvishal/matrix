using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation(Interface = typeof(IEventScreeningAuthorizationEditModelFactory))]
    public class EventScreeningAuthorizationEditModelFactory : IEventScreeningAuthorizationEditModelFactory
    {
        public EventScreeningAuthorizationEditModel Create(Event theEvent, IEnumerable<EventTest> eventTests, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<EventPackage> packages, 
            IEnumerable<OrderedPair<long, long>> ecIdPackageIdpairs, IEnumerable<OrderedPair<long, long>> ecIdTestIdPairs, Host host)
        {
            var eventScreeningAuthorizationEditModel = new EventScreeningAuthorizationEditModel
                                                           {
                                                               EventId = theEvent.Id,
                                                               EventName = theEvent.Name,
                                                               EventAddress = Mapper.Map< Address,AddressViewModel>(host.Address),
                                                               EventTests = eventTests != null ? eventTests.Select(et => et.Test) : null
                                                           };
            var customerScreeningAuthorizationEditModels = new List<CustomerScreeningAuthorizationEditModel>();
            foreach (var eventCustomer in eventCustomers)
            {
                var customer = customers.Where(c => c.CustomerId == eventCustomer.CustomerId).SingleOrDefault();

                var packageIdPurchased =
                    ecIdPackageIdpairs.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).SingleOrDefault();

                var customerTests = new List<Test>();
                if (packageIdPurchased > 0)
                {
                    var package = packages.Where(p => p.Id == packageIdPurchased).SingleOrDefault();
                    customerTests.AddRange(package.Package.Tests);
                }

                var testIdsPurchased = ecIdTestIdPairs.Where(p => p.FirstValue == eventCustomer.Id).Select(p => p.SecondValue).ToArray();
                if (testIdsPurchased.Count() > 0)
                {
                    var addOnTests = eventTests.Where(et => testIdsPurchased.Contains(et.Id)).Select(et => et.Test).ToArray();
                    customerTests.AddRange(addOnTests);
                }
                customerScreeningAuthorizationEditModels.Add(new CustomerScreeningAuthorizationEditModel
                                                                 {
                                                                     CustomerId = customer.CustomerId,
                                                                     Name = customer.Name.FullName,
                                                                     Dob = customer.DateOfBirth,
                                                                     Ethnicity = (long)customer.Race < 1 ? "" : customer.Race.ToString(),
                                                                     Gender = customer.Gender.ToString(),
                                                                     Height = customer.Height,
                                                                     Weight = customer.Weight,
                                                                     EventTests = customerTests,
                                                                     EventCustomerId = eventCustomer.Id
                                                                 });
            }
            eventScreeningAuthorizationEditModel.Customers = customerScreeningAuthorizationEditModels;
            return eventScreeningAuthorizationEditModel;
        }
    }
}
