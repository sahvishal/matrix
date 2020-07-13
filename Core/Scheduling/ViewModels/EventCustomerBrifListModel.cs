using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventCustomerBrifListModel
    {
        public long EventId { get; set; }

        public IEnumerable<EventCustomerAppointmentViewModel> EventAppointmentSlotDistributions { get; set; }

        public IEnumerable<ShippingOption> ShippingOptions { get; set; }

        public IEnumerable<ElectronicProduct> Products { get; set; }

        public bool IsHospitalPartnerEvent { get; set; }

        public bool CapturePcpConsent { get; set; }

        public DateTime EventDate { get; set; }

        public EventType EventType { get; set; }

        public long? AccountId { get; set; }

       public bool CaptureAbnStatus { get; set; }
         

    }
}