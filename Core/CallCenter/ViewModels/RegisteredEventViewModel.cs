using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class RegisteredEventViewModel
    {
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }

        public string HostName { get; set; }
        public string HostAddress { get; set; }

        public DateTime? AppointmentTime { get; set; }

        public string EventNotes { get; set; }

        public long EventCustomerId { get; set; }

        public bool IsCanceled { get; set; }

        public bool IsRescheduled { get; set; }

        public string TimeZone { get; set; }

        public string HraQuestionerAppUrl { get; set; }

        public string OrganizationNameForHraQuestioner { get; set; }

        public string CorporateAccountTag { get; set; }

        public long MedicareVisitId { get; set; }

        public string Pods { get; set; }

        public string Token { get; set; }

        public bool ShowHraQuestionnaire { get; set; }

        public bool IsEawvPurchased { get; set; }

        public bool ShowChatQuestionnaire { get; set; }
        public string ChatQuestionerAppUrl { get; set; }

        public bool AllowNonMammoPatients { get; set; }
        public bool CaptureHaf { get; set; }

    }
}
