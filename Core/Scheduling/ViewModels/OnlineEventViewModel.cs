using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class OnlineEventViewModel
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        public AddressViewModel EventLocation { get; set; }
        public string HostName { get; set; }
        public Double DistanceFromZip { get; set; }

        public long TotalSlots { get; set; }

        public long MorningAvailableSlots { get; set; }
        public long AfternoonAvailableSlots { get; set; }
        public long EveningAvailableSlots { get; set; }

        public long AvailableSlots
        {
            get
            {
                return MorningAvailableSlots + AfternoonAvailableSlots + EveningAvailableSlots;
            }
        }

        public string CorporateAccountName { get; set; }
        public string CorporateAccountLogoPath { get; set; }
        public bool HasBreastCancer { get; set; }

        public string SponsorImage { get; set; }

        public bool IsMarkedOffforSelection { get; set; }

        public EventType EventType { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public bool IsFemaleOnly { get; set; }


        public OnlineEventViewModel()
        {
            IsMarkedOffforSelection = false;
        }
    }
}
