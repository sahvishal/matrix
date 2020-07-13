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
    public class OnlineSchedulingEventListModelFactory : IOnlineSchedulingEventListModelFactory
    {
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly int _limitedAvailabilityThreshold;
        public OnlineSchedulingEventListModelFactory(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
            _limitedAvailabilityThreshold = 3;
        }

        public OnlineSchedulingEventListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> totalSlotsOrderedPair, IEnumerable<OrderedPair<long, int>> availableSlotsOrderedPair, ZipCode filterZipCode,
            IEnumerable<EventSchedulingSlot> slots, long selectedEventId, int cutOffHourforMarkEventOnlineSelection, SortOrderBy sortOrderBy, SortOrderType sortOrderType, int maxNumberofRecordstoFetch, int pageNumber, int pageSize, out int totalRecords)
        {
            var listModel = new OnlineSchedulingEventListModel();
            var viewModelCollection = new List<OnlineSchedulingEventViewModel>();

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
                var host = hosts.Where(h => h.Id == theEvent.HostId).FirstOrDefault();
                var totalSlot = totalSlotsOrderedPair.Where(op => op.FirstValue == theEvent.Id).SingleOrDefault();
                var availableSlot = availableSlotsOrderedPair.Where(op => op.FirstValue == theEvent.Id).SingleOrDefault();

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

                var model = new OnlineSchedulingEventViewModel
                                {
                                    EventDate = theEvent.EventDate,
                                    EventId = theEvent.Id,
                                    HostName = host.OrganizationName,
                                    EventLocation = Mapper.Map<Address, AddressViewModel>(host.Address),
                                    TotalSlots = totalSlot != null ? totalSlot.SecondValue : 0,
                                    AvailableSlots = availableSlot != null ? availableSlot.SecondValue : 0,
                                    DistanceFromZip = distance,
                                    IsMarkedOffforSelection = nextDay != null && theEvent.EventDate.Date <= nextDay.Value.Date ? true : false,
                                    EventType = theEvent.EventType,
                                    IsFemaleOnly = theEvent.IsFemaleOnly,
                                    RegistrationMode = theEvent.RegistrationMode
                                };

                viewModelCollection.Add(model);
            }

            if (viewModelCollection.Count < 1)
            {
                totalRecords = 0;
                listModel.Events = viewModelCollection;
                return listModel;
            }

            if (sortOrderBy == SortOrderBy.Distance)
            {
                int countForUncalculatableZip = viewModelCollection.Where(vm => vm.DistanceFromZip < 0).Count();
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

            viewModelCollection = viewModelCollection.Where(vw => vw.EventId != selectedEventId).ToList();

            totalRecords = viewModelCollection.Count();
            totalRecords = totalRecords > maxNumberofRecordstoFetch ? maxNumberofRecordstoFetch : totalRecords;

            viewModelCollection = viewModelCollection.Take(totalRecords).ToList();

            listModel.Events = viewModelCollection.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

            if (pageNumber > 1 && listModel.Events.Count() < 1)
            {
                listModel.Events = viewModelCollection.Skip((pageNumber - 2) * pageSize).Take(pageSize).ToArray();
            }

            return listModel;
        }

        public OnlineSchedulingEventListModel ManipulateSlotAvilabilityDisplay(OnlineSchedulingEventListModel model, IEnumerable<Appointment> slots)
        {
            foreach (var theEvent in model.Events)
            {
                var eventSlots = slots.Where(sl => sl.EventId == theEvent.EventId).ToArray();
                var freeSlots = eventSlots.Where(sl => (sl.ScheduledById == null || sl.ScheduledById.Value < 1) /*&& sl.AppointmentStatus == AppointmentStatus.Free*/).ToArray();

                if (theEvent.EventDate.Date == DateTime.Now.Date)
                {
                    freeSlots = freeSlots.Where(es => es.StartTime >= DateTime.Now.AddHours(1)).ToArray();
                }

                if (freeSlots.Count() < 1)
                {
                    theEvent.AppointmentAvailabilityDisplayString = "None Available";
                }
                else if (freeSlots.Count() <= _limitedAvailabilityThreshold)
                {
                    theEvent.AppointmentAvailabilityDisplayString = "Limited Availability";
                }
                else
                {
                    bool morningSlot, afternoonSlot;
                    morningSlot = afternoonSlot = false;

                    if (freeSlots.Where(sl => sl.StartTime.TimeOfDay < new TimeSpan(12, 0, 0)).Count() > 0)
                    {
                        morningSlot = true;
                    }
                    if (freeSlots.Where(sl => sl.StartTime.TimeOfDay >= new TimeSpan(12, 0, 0)).Count() > 0)
                    {
                        afternoonSlot = true;
                    }

                    if (morningSlot && afternoonSlot)
                    {
                        theEvent.AppointmentAvailabilityDisplayString = "Morning and Afternoon";
                    }
                    else if (morningSlot)
                    {
                        theEvent.AppointmentAvailabilityDisplayString = "Morning";
                    }
                    else if (afternoonSlot)
                    {
                        theEvent.AppointmentAvailabilityDisplayString = "Afternoon";
                    }
                }
            }

            return model;
        }

        public OnlineSchedulingEventListModel ManageSponsoredByLogo(OnlineSchedulingEventListModel model, IEnumerable<OrderedPair<long, long>> eventIdOrganizationIdpairs, IEnumerable<Organization> organizations, IEnumerable<File> files)
        {
            if (eventIdOrganizationIdpairs == null || eventIdOrganizationIdpairs.Count() < 1 || files == null || files.Count() < 1) return model;

            foreach (var organization in organizations)
            {
                if (organization.LogoImageId < 1) continue;
                var file = files.Where(f => f.Id == organization.LogoImageId).Single();
                var eventIds = eventIdOrganizationIdpairs.Where(p => p.SecondValue == organization.Id).Select(m => m.FirstValue).ToArray();
                foreach (var eventId in eventIds)
                {
                    var theEvent = model.Events.Where(m => m.EventId == eventId).SingleOrDefault();
                    if (theEvent == null) continue;
                    theEvent.SponsorImage = file.Path;
                }
            }

            return model;
        }

        public OnlineSchedulingEventViewModel Create(Event theEvent, Host host, IEnumerable<Appointment> appointments, File file)
        {
            var model = new OnlineSchedulingEventViewModel
            {
                EventDate = theEvent.EventDate,
                EventId = theEvent.Id,
                HostName = host.OrganizationName,
                EventLocation = Mapper.Map<Address, AddressViewModel>(host.Address),
                SponsorImage = file != null ? file.Path : string.Empty,
                EventType = theEvent.EventType,
                IsFemaleOnly = theEvent.IsFemaleOnly,
                RegistrationMode = theEvent.RegistrationMode
            };

            return model;
        }

    }
}