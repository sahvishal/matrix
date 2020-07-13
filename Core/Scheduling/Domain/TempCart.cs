using System;
using System.Collections.Generic;
using System.Linq;

using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class TempCart : DomainObjectBase
    {
        public TempCart()
        {
            LoginAttempt = 0;
            IsExistingCustomer = false;
            IsCompleted = false;
        }

        public string Guid { get; set; }
        public string ZipCode { get; set; }

        public long? EventId { get; set; }
        public long? CustomerId { get; set; }
        public long? ProspectCustomerId { get; set; }

        public long? AppointmentId { get; set; }
        public long? EventPackageId { get; set; }

        public long? SourceCodeId { get; set; }
        public string TestId { get; set; }
        public string ProductId { get; set; }
        public long? ShippingId { get; set; }

        public string PaymentMode { get; set; }
        public decimal? PaymentAmount { get; set; }

        public bool? IsPaymentSuccessful { get; set; }
        public bool? IsHafFilled { get; set; }

        public string EntryPage { get; set; }
        public string ExitPage { get; set; }

        public string IPAddress { get; set; }
        public string ScreenResolution { get; set; }
        public string Browser { get; set; }

        public bool IsCompleted { get; set; }
        public bool IsExistingCustomer { get; set; }

        public int LoginAttempt { get; set; }

        public long? ShippingAddressId { get; set; }
        public string InvitationCode { get; set; }
        public string CorpCode { get; set; }
        public decimal? Radius { get; set; }
        public string MarketingSource { get; set; }

        public bool? IsUsedAppointmentSlotExpiryExtension { get; set; }

        public string InChainAppointmentSlots { get; set; }

        public IEnumerable<long> InChainAppointmentSlotIds
        {
            get
            {
                if (string.IsNullOrEmpty(InChainAppointmentSlots))
                    return null;//new long[0]
                var slotIdString = InChainAppointmentSlots.Split(new[] { ',' });

                if (!slotIdString.Any()) return new long[0];

                long slotId;
                return slotIdString.Where(s => long.TryParse(s.Trim(), out slotId)).Select(s => Convert.ToInt64(s.Trim())).ToArray();
            }
        }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public DateTime? PreliminarySelectedTime { get; set; }

        public string Gender { get; set; }

        public DateTime? Dob { get; set; }

        public int Version { get; set; }

        public long? EligibilityId { get; set; }
        public long? ChargeCardId { get; set; }

        //public long? HighBloodPressure { get; set; }
        //public long? Smoker { get; set; }
        //public long? HeartDisease { get; set; }
        //public long? Diabetic { get; set; }
        //public long? ChestPain { get; set; }
        //public long? DiagnosedHeartProblem { get; set; }
        //public long? HighCholestrol { get; set; }

        //public long? OverWeight { get; set; }

        //public bool AgreedWithPrequalificationQuestion { get; set; }

        //public long? AgeOverPreQualificationQuestion { get; set; }

        //public bool SkipPreQualificationQuestion { get; set; }

    }
}
