using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class GmsCallQueueCustomerModelFactory : IGmsCallQueueCustomerModelFactory
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        private const int NearestEventZipCount = 3;
        private const int EventZipRadius = 25;

        public GmsCallQueueCustomerModelFactory(IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        public IEnumerable<GmsCallQueueCustomerViewModel> Create(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers, IEnumerable<EventListGmsModel> events, IEnumerable<Host> eventHosts,
            CorporateAccount healthPlan, Organization account, IEnumerable<OrderedPair<long, PhoneNumber>> customerIdCheckoutNumberPairList, bool setAdditionalField = false)
        {
            var collection = new List<GmsCallQueueCustomerViewModel>();

            foreach (var cqc in callQueueCustomers)
            {
                if (!cqc.CustomerId.HasValue) continue;

                var customer = customers.Single(x => x.CustomerId == cqc.CustomerId.Value);
                var checkoutNumber = customerIdCheckoutNumberPairList != null ? customerIdCheckoutNumberPairList.FirstOrDefault(x => x.FirstValue == cqc.CustomerId.Value) : null;
                var model = new GmsCallQueueCustomerViewModel
                {
                    CustomerId = cqc.CustomerId.Value,
                    FirstName = cqc.FirstName,
                    MiddleName = !string.IsNullOrEmpty(cqc.MiddleName) ? cqc.MiddleName : "",
                    LastName = cqc.LastName,
                    Email = customer.Email.ToString(),
                    PhoneHome = cqc.PhoneHome != null ? cqc.PhoneHome.ToString() : string.Empty,
                    PhoneOffice = cqc.PhoneOffice != null ? cqc.PhoneOffice.ToString() : string.Empty,
                    PhoneCell = cqc.PhoneCell != null ? cqc.PhoneCell.ToString() : string.Empty,
                    Address1 = customer.Address.StreetAddressLine1,
                    Address2 = string.IsNullOrEmpty(customer.Address.StreetAddressLine2) ? "" : customer.Address.StreetAddressLine2,
                    City = customer.Address.City,
                    State = customer.Address.State,
                    Zip = customer.Address.ZipCode.Zip,
                    MemberId = customer.InsuranceId,
                    HealthPlan = account.Name,
                    CallerId = checkoutNumber != null ? checkoutNumber.SecondValue.ToString() : "",
                    AdditionalField = setAdditionalField ? customer.AdditionalField3 : ""
                };

                if (string.IsNullOrEmpty(model.CallerId))
                {
                    model.CallerId = _phoneNumberFactory.CreatePhoneNumber(healthPlan.CheckoutPhoneNumber.ToString(), PhoneNumberType.Unknown).ToString();
                }

                var hostIdsWithAvailableSlots = events.Where(x => x.AvailableSlots > 0).Select(x => x.HostId);

                eventHosts = eventHosts.Where(x => hostIdsWithAvailableSlots.Contains(x.Id));

                //var zipDistanceOrderedPairs = GetEventZips(eventHosts, customer.Address.ZipCode);

                //var nearestEventZips = zipDistanceOrderedPairs.OrderBy(x => x.SecondValue).Select(x => x.FirstValue).Distinct().Take(NearestEventZipCount);

                //model.NearestEventZips = string.Join(", ", nearestEventZips);

                var eventDistanceOrderedPairs = GetEventDistance(events, eventHosts, customer.Address.ZipCode);
                var nearestEvents = eventDistanceOrderedPairs.Where(x => x.SecondValue <= EventZipRadius).OrderBy(x => x.SecondValue).Select(x => x.FirstValue).Distinct().Take(NearestEventZipCount);

                model.NearestEvents = string.Join("|", nearestEvents);

                collection.Add(model);
            }

            return collection;
        }

        private IEnumerable<OrderedPair<string, double>> GetEventZips(IEnumerable<Host> eventHosts, ZipCode customerZip)
        {
            var zipDistanceOrderedPairs = new List<OrderedPair<string, double>>();

            foreach (var eventHost in eventHosts)
            {
                if (customerZip == null || eventHost.Address.ZipCode == null) continue;

                var distanceFromCustomerZipCode = CalculateDistanceBetweenTwoZips(customerZip, eventHost.Address.ZipCode);

                zipDistanceOrderedPairs.Add(new OrderedPair<string, double>(eventHost.Address.ZipCode.Zip, distanceFromCustomerZipCode));
            }

            return zipDistanceOrderedPairs;
        }

        private IEnumerable<OrderedPair<long, double>> GetEventDistance(IEnumerable<EventListGmsModel> events, IEnumerable<Host> eventHosts, ZipCode customerZip)
        {
            var eventIdDistanceOrderedPairs = new List<OrderedPair<long, double>>();

            foreach (var eventHost in eventHosts)
            {
                if (customerZip == null || eventHost.Address.ZipCode == null) continue;

                var distanceFromCustomerZipCode = CalculateDistanceBetweenTwoZips(customerZip, eventHost.Address.ZipCode);

                eventIdDistanceOrderedPairs.AddRange(events.Where(e => e.HostId == eventHost.Id).Select(e => new OrderedPair<long, double>(e.EventId, distanceFromCustomerZipCode)));
            }

            return eventIdDistanceOrderedPairs;
        }

        private static double CalculateDistanceBetweenTwoZips(ZipCode originalZipCode, ZipCode destinationZipCode)
        {
            IDistanceCalculator distanceCalculator = new DistanceCalculator();
            return
                Math.Round(
                    distanceCalculator.DistanceBetweenTwoPoints(originalZipCode.Latitude, originalZipCode.Longitude,
                                                                destinationZipCode.Latitude,
                                                                destinationZipCode.Longitude), 2);
        }
    }
}
