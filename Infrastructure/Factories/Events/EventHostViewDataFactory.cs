using System;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using System.Linq;

namespace Falcon.App.Infrastructure.Factories.Events
{
    [DefaultImplementation]
    public class EventHostViewDataFactory : IEventHostViewDataFactory
    {
        private readonly IHostRepository _hostRepository;
        private readonly IEventTestRepository _testRepository;
        private readonly ISettings _settings;

        public EventHostViewDataFactory()
            : this(new HostRepository(), new EventTestRepository(), new Settings())
        { }

        public EventHostViewDataFactory(IHostRepository hostRepository, IEventTestRepository testRepository, ISettings settings)
        {

            _hostRepository = hostRepository;
            _testRepository = testRepository;
            _settings = settings;
        }

        private EventHostViewData Create(Event eventData, IEnumerable<Pod> pods, ZipCode zipCode,
            EventAppointmentStatsModel eventAppointmentStatsModel, IEnumerable<EventTest> testsInEvent,
            Host eventHost, IEnumerable<OrderedPair<long, string>> corporateAccountNames = null,
            IEnumerable<OrderedPair<long, string>> hospitalPartnerNames = null, IEnumerable<ZipRadiusDistance> zipRadiusDistances = null)
        {
            //var eventHost = _hostRepository.GetHostForEvent(eventData.Id);
            var totalAppointmentSlotsForThisEvent = eventAppointmentStatsModel.TotalSlots - eventAppointmentStatsModel.BlockedSlots;
            var availableAppointmentSlotsForThisEvent = eventAppointmentStatsModel.FreeSlots;
            double distanceFromOriginalZipCode = 0L;
            
            if (zipCode != null && eventHost.Address.ZipCode != null)
            {
                ZipRadiusDistance zipRadiusDistance = null;
                if (!zipRadiusDistances.IsNullOrEmpty())
                {
                    zipRadiusDistance = zipRadiusDistances.SingleOrDefault(x => x.SourceZipId == zipCode.Id && x.DestinationZipId == eventHost.Address.ZipCode.Id);
                }

                distanceFromOriginalZipCode = zipRadiusDistance != null
                    ? Math.Round(zipRadiusDistance.Distance, 2)
                    : CalculateDistanceBetweenTwoZips(zipCode, eventHost.Address.ZipCode);
            }

            var hasBreastCancerTest = testsInEvent.Any(te => TestGroup.BreastCancer.Contains(te.TestId));

            string sponseredBy = string.Empty;
            if (!corporateAccountNames.IsNullOrEmpty())
            {
                var sponserName = corporateAccountNames.FirstOrDefault(x => x.FirstValue == eventData.Id);
                if (sponserName != null)
                {
                    sponseredBy = sponserName.SecondValue;
                }
                else
                {
                    if (!hospitalPartnerNames.IsNullOrEmpty())
                        sponserName = hospitalPartnerNames.FirstOrDefault(x => x.FirstValue == eventData.Id);
                    sponseredBy = sponserName != null ? sponserName.SecondValue : _settings.CompanyName;
                }
            }
            else
            {
                if (!hospitalPartnerNames.IsNullOrEmpty())
                {
                    var sponserName = hospitalPartnerNames.FirstOrDefault(x => x.FirstValue == eventData.Id);
                    if (sponserName != null)
                    {
                        sponseredBy = sponserName.SecondValue;
                    }
                }
                if (string.IsNullOrEmpty(sponseredBy))
                    sponseredBy = _settings.CompanyName;
            }

            var eventHostViewData = new EventHostViewData(eventData, eventHost, pods, totalAppointmentSlotsForThisEvent,
                                         availableAppointmentSlotsForThisEvent, distanceFromOriginalZipCode, hasBreastCancerTest, eventAppointmentStatsModel.IsDynamicScheduling, sponseredBy);
            eventHostViewData.BookedSlots = eventAppointmentStatsModel.FilledSlots;
            eventHostViewData.InvitationCode = eventData.InvitationCode;
            return eventHostViewData;
        }

        public List<EventHostViewData> Create(List<Event> events, IEnumerable<Pod> pods, ZipCode zipCode,
            IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels,
            IEnumerable<OrderedPair<long, string>> corporateAccountNames = null,
            IEnumerable<OrderedPair<long, string>> hospitalPartnerNames = null, IEnumerable<ZipRadiusDistance> zipRadiusDistances = null)
        {
            var eventIds = events.Select(e => e.Id).ToArray();
            var eventsTests = _testRepository.GetEventTestsByEventIds(eventIds);

            var eventHosts = _hostRepository.GetEventHostByHostIds(events.Select(x => x.HostId).ToArray());

            return events.Select(@event =>
                                     {
                                         var selectedPods = @event.PodIds != null ? pods.Where(p => @event.PodIds.Contains(p.Id)).ToArray() : null;
                                         var eventAppointmentStatsModel = eventAppointmentStatsModels.Where(easm => easm.EventId == @event.Id).Single();
                                         var eventTests = eventsTests.Where(et => et.EventId == @event.Id).ToArray();
                                         var eventHost = eventHosts.First(ez => ez.Id == @event.HostId);
                                         return Create(@event, selectedPods, zipCode, eventAppointmentStatsModel, eventTests, eventHost, corporateAccountNames, hospitalPartnerNames, zipRadiusDistances);
                                     }).ToList();
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