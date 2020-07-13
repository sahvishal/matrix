using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using System.Linq;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventBasicInfoViewModel : ViewModelBase
    {
        public long Id { get; set; }
        public DateTime EventDate { get; set; }
        public RegistrationMode RegistrationMode { get; set; }
        public EventType EventType { get; set; }
        public string InvitationCode { get; set; }
        public string AssignedtoFullName { get; set; }
        public long AssignedtoOrgRoleUserId { get; set; }
        public EventStatus Status { get; set; }

        public long HostId { get; set; }
        public string HostName { get; set; }
        public AddressViewModel HostAddress { get; set; }

        //vehicle
        public IEnumerable<OrderedPair<long, string>> Pods { get; set; }

        public int TotalAppointmentSlots { get; set; }
        public int FilledAppintmentSlots { get; set; }
        public int BookedSlots { get; set; }
        public bool CaptureHealthAssessmentForm { get; set; }
        public bool GenerateBatchLabel { get; set; }
        public string PodNames()
        {
            //return string.Join(",", Pods.Select(p => p.SecondValue));
            return Pods != null ? string.Join(", ", Pods.Select(pod => pod.SecondValue)) : string.Empty;
        }

        public bool IsCdContentGenerated { get; set; }
        public bool IsResultPacketGenetated { get; set; }
        public bool IsDynamicScheduling { get; set; }
        public string Sponsor { get; set; }

        public long MorningAvailableSlots { get; set; }
        public long AfternoonAvailableSlots { get; set; }
        public long EveningAvailableSlots { get; set; }

        public long ScreenedCustomers { get; set; }

        public bool IsSmsEnabled { get; set; }
        public bool IsPackageTimeOnly { get; set; }
        public bool GenerateHealthAssesmentForm { get; set; }
    }
}