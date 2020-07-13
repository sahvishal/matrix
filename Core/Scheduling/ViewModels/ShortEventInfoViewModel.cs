using System;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class ShortEventInfoViewModel
    {
        public long Id { get; set; }
        public DateTime EventDate { get; set; }
        public string HostName { get; set; }
        public AddressViewModel HostAddress { get; set; }

        //vehicle
        public string Pods { get; set; }

        public int TotalAppointmentSlots { get; set; }
        public int FilledAppintmentSlots { get; set; }
        public int BookedSlots { get; set; }
        public bool CaptureHealthAssessmentForm { get; set; }

        public string Sponsor { get; set; }

        public bool GenerateHealthAssesmentForm { get; set; }

        public int HipaaSignedCount { get; set; }
        public int HipaaUnSignedCount { get; set; }

        public bool ShowGiftCard { get; set; }
        public decimal GiftCardAmount { get; set; }
        public bool ShowMatrixConsent { get; set; }
        public bool ShowFluVaccineConsent { get; set; }
        public bool ShowSurvey { get; set; }
        public bool ShowChaperoneConsent { get; set; }
        public bool ShowPcpConsent { get; set; }
    }
}