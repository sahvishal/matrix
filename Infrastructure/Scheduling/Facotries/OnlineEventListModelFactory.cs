using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class OnlineEventListModelFactory : IOnlineEventListModelFactory
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public OnlineEventListModelFactory(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        public IEnumerable<OnlineEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<EventAppointmentStatsModel> eventAppointmentStatsModels, ZipCode filterZipCode,
            IEnumerable<EventSchedulingSlot> slots, long selectedEventId, int cutOffHourforMarkEventOnlineSelection, SortOrderBy sortOrderBy, SortOrderType sortOrderType, int maxNumberofRecordstoFetch, int pageNumber,
            int pageSize, out int totalRecords)
        {
            var viewModelCollection = new List<OnlineEventViewModel>();

            DateTime? nextDay = null;
            if (cutOffHourforMarkEventOnlineSelection > 0)
            {
                var currentDay = DateTime.Now;
                nextDay = currentDay.Date.AddDays(1);

                if (currentDay.AddHours(cutOffHourforMarkEventOnlineSelection) < nextDay)
                {
                    nextDay = currentDay;
                }
            }

            foreach (var theEvent in events)
            {
                var host = hosts.FirstOrDefault(h => h.Id == theEvent.HostId);
                var eventAppointmentStatsModel = eventAppointmentStatsModels.Single(a => a.EventId == theEvent.Id);

                if (theEvent.EventDate.Date == DateTime.Now.Date && slots != null && theEvent.Id != selectedEventId)
                {
                    var slot = slots.Where(a => a.EventId == theEvent.Id).ToArray();
                    var maxStartTime = slot.Select(a => a.StartTime).Max();
                    if (DateTime.Now.Date.AddHours(maxStartTime.Hour).AddMinutes(maxStartTime.Minute) < DateTime.Now.AddHours(1))
                    {
                        continue;
                    }
                }

                double distance = 0;
                if (filterZipCode != null && host.Address.ZipCode != null)
                    distance = _distanceCalculator.DistanceBetweenTwoPoints(filterZipCode.Latitude, filterZipCode.Longitude,
                                                                    host.Address.ZipCode.Latitude, host.Address.ZipCode.Longitude);

                if (distance > 0) distance = Math.Round(distance, 2);

                var model = new OnlineEventViewModel
                {
                    EventDate = theEvent.EventDate,
                    EventId = theEvent.Id,
                    EventLocation = Mapper.Map<Address, AddressViewModel>(host.Address),
                    HostName = host.OrganizationName,
                    DistanceFromZip = distance,
                    TotalSlots = eventAppointmentStatsModel.TotalSlots - eventAppointmentStatsModel.BlockedSlots,
                    MorningAvailableSlots = eventAppointmentStatsModel.MorningAvailableSlots,
                    AfternoonAvailableSlots = eventAppointmentStatsModel.AfternoonAvailableSlots,
                    EveningAvailableSlots = eventAppointmentStatsModel.EveningAvailableSlots,
                    IsMarkedOffforSelection = nextDay != null && theEvent.EventDate.Date <= nextDay.Value.Date,
                    EventType = theEvent.EventType,
                    RegistrationMode = theEvent.RegistrationMode,
                    IsFemaleOnly = theEvent.IsFemaleOnly
                };

                viewModelCollection.Add(model);
            }

            if (viewModelCollection.Count < 1)
            {
                totalRecords = 0;
                return viewModelCollection;
            }

            var selectEventViewModel = viewModelCollection.SingleOrDefault(vw => vw.EventId == selectedEventId);

            viewModelCollection = viewModelCollection.Where(vw => vw.EventId != selectedEventId).ToList();

            if (viewModelCollection.Any())
            {
                if (sortOrderBy == SortOrderBy.Distance)
                {
                    int countForUncalculatableZip = viewModelCollection.Count(vm => vm.DistanceFromZip < 0);
                    double maxDistance = viewModelCollection.Max(vm => vm.DistanceFromZip);

                    if (countForUncalculatableZip > 0 && maxDistance >= 0 && sortOrderType == SortOrderType.Ascending)
                    {
                        maxDistance += 1;
                        viewModelCollection.Where(vm => vm.DistanceFromZip < 0).All(vm =>
                        {
                            vm.DistanceFromZip = maxDistance;
                            return true;
                        });
                    }

                    viewModelCollection = sortOrderType == SortOrderType.Ascending
                                              ? viewModelCollection.OrderBy(m => m.EventDate).OrderBy(m => m.DistanceFromZip).ToList()
                                              : viewModelCollection.OrderByDescending(m => m.EventDate).OrderBy(m => m.DistanceFromZip).ToList();

                    if (countForUncalculatableZip > 0 && maxDistance >= 0 && sortOrderType == SortOrderType.Ascending)
                    {
                        viewModelCollection.Where(vm => vm.DistanceFromZip == maxDistance).All(vm =>
                        {
                            vm.DistanceFromZip = -0.0009;
                            return true;
                        });
                    }
                }
                else // Default Ordering will be Event Date
                {
                    viewModelCollection = sortOrderType == SortOrderType.Ascending
                                              ? viewModelCollection.OrderBy(m => m.DistanceFromZip).OrderBy(m => m.EventDate).ToList()
                                              : viewModelCollection.OrderByDescending(m => m.DistanceFromZip).OrderBy(m => m.EventDate).ToList();
                }
            }


            var finalViewModelcollection = new List<OnlineEventViewModel>();
            if (selectEventViewModel != null)
                finalViewModelcollection.Add(selectEventViewModel);

            finalViewModelcollection.AddRange(viewModelCollection);

            totalRecords = finalViewModelcollection.Count();
            totalRecords = totalRecords > maxNumberofRecordstoFetch ? maxNumberofRecordstoFetch : totalRecords;

            finalViewModelcollection = finalViewModelcollection.Take(totalRecords).ToList();

            finalViewModelcollection = finalViewModelcollection.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            if (pageNumber > 1 && !finalViewModelcollection.Any())
            {
                finalViewModelcollection = finalViewModelcollection.Skip((pageNumber - 2) * pageSize).Take(pageSize).ToList();
            }

            return finalViewModelcollection;
        }

        public IEnumerable<OnlineEventViewModel> ManageSponsoredByLogo(IEnumerable<OnlineEventViewModel> collection, IEnumerable<OrderedPair<long, long>> eventIdOrganizationIdpairs, IEnumerable<Organization> organizations,
            IEnumerable<File> files)
        {
            if (eventIdOrganizationIdpairs == null || eventIdOrganizationIdpairs.Count() < 1 || files == null || files.Count() < 1) return collection;

            foreach (var organization in organizations)
            {
                if (organization.LogoImageId < 1) continue;
                var file = files.Single(f => f.Id == organization.LogoImageId);
                var eventIds = eventIdOrganizationIdpairs.Where(p => p.SecondValue == organization.Id).Select(m => m.FirstValue).ToArray();
                foreach (var eventId in eventIds)
                {
                    var theEvent = collection.SingleOrDefault(m => m.EventId == eventId);
                    if (theEvent == null) continue;
                    theEvent.SponsorImage = file.Path;
                }
            }

            return collection;
        }
    }
}
