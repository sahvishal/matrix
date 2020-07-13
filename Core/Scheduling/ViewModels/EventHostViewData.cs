using System;
using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventHostViewData
    {
        // Event Data
        public long EventId { get; set; }
        public string Name { get { return OrganizationName; } }

        public double? DistanceFromZip { get; set; }

        public int DistanceGroup
        {
            get
            {
                if (DistanceFromZip <= 5)
                    return 1;
                if (DistanceFromZip > 5 && DistanceFromZip <= 10)
                    return 2;
                if (DistanceFromZip > 10 && DistanceFromZip <= 15)
                    return 3;
                if (DistanceFromZip > 15 && DistanceFromZip <= 20)
                    return 4;
                if (DistanceFromZip > 20 && DistanceFromZip <= 25)
                    return 5;
                return 0;
            }
        }
        public DateTime EventDate { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public string EventTimeZone { get; set; }
        public string EventType { get; set; }
        public string EventStatus { get; set; }
        public string EventNotes { get; set; }
        public string CallCenterNotes { get; set; }
        public string TechnicianNotes { get; set; }

        public int? TotalAppointmentSlots { get; set; }
        public int? AvailableAppointmentSlots { get; set; }

        public int BookedSlots { get; set; }

        public IEnumerable<OrderedPair<long, string>> Pods { get; set; }
        public string PodNames()
        {
            return string.Join(",", Pods.Select(p => p.SecondValue));
        }

        // Host Data
        public long HostId { get; set; }
        public string OrganizationName { get; set; }

        // Host Address
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool? UseLatitudeAndLongitudeForMapping { get; set; }
        public long? GoogleAddressVerifiedBy { get; set; }
        public bool? HasBreastCancerTest { get; set; }
        public bool? IsDynamicScheduling { get; set; }
        public bool IsFemaleOnly { get; set; }
        public string InvitationCode { get; set; }

        public string SponseredBy { get; set; }

        public bool AllowNonMammoPatients { get; set; }

        public EventHostViewData(Event eventData, Host host, IEnumerable<Pod> pods, int? totalAppointmentSlots, int? availableAppointmentSlots, double? distanceFromZip, bool? hasBreastCancerTest, bool? isDynamicScheduling, string sponseredBy)
        {
            EventId = eventData.Id;
            OrganizationName = eventData.Name;
            EventDate = eventData.EventDate;
            EventStartTime = eventData.EventStartTime;
            EventEndTime = eventData.EventEndTime;
            EventType = eventData.RegistrationMode.ToString();
            EventStatus = eventData.Status.ToString();
            EventNotes = eventData.EventNotes;
            CallCenterNotes = eventData.CallCenterNotes;
            TechnicianNotes = eventData.TechnicianNotes;

            EventTimeZone = eventData.TimeZone;
            HostId = host.Id;
            OrganizationName = host.OrganizationName;
            StreetAddressLine1 = host.Address.StreetAddressLine1;
            StreetAddressLine2 = host.Address.StreetAddressLine2;
            City = host.Address.City;
            State = host.Address.State;
            Zip = host.Address.ZipCode.Zip;
            Latitude = !string.IsNullOrEmpty(host.Address.Latitude) ? host.Address.Latitude : string.Empty;
            Longitude = !string.IsNullOrEmpty(host.Address.Longitude) ? host.Address.Longitude : string.Empty;
            UseLatitudeAndLongitudeForMapping = host.Address.LatLogUseForAddressMaping;
            GoogleAddressVerifiedBy = host.Address.VerificationOrgRoleUserId;
            TotalAppointmentSlots = totalAppointmentSlots;
            AvailableAppointmentSlots = availableAppointmentSlots;
            DistanceFromZip = distanceFromZip;
            HasBreastCancerTest = hasBreastCancerTest;
            Pods = pods != null ? pods.Select(p => new OrderedPair<long, string>(p.Id, p.Name)) : null;
            IsDynamicScheduling = isDynamicScheduling;
            IsFemaleOnly = eventData.IsFemaleOnly;
            SponseredBy = sponseredBy;
            AllowNonMammoPatients = eventData.AllowNonMammoPatients;
        }

        public EventHostViewData(Event eventData, Host host, IEnumerable<Pod> pods)
            : this(eventData, host, pods, null, null, null, null, null, string.Empty)
        { }
    }
}


