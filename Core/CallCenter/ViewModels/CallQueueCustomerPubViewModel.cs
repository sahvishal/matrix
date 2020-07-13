using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallQueueCustomerPubViewModel
    {
        public CallQueueCustomerPubViewModel()
        {
            Guid = System.Guid.NewGuid().ToString();
        }
        public string Guid { get; set; }
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneCell { get; set; }
        public string PhoneOffice { get; set; }
        public long? DoNotContactTypeId { get; set; }
        public long? DoNotContactReasonId { get; set; }
        public DateTime? DoNotContactUpdateDate { get; set; }
        public long? ActivityId { get; set; }
        //public bool? IsEligible { get; set; }
        public bool IsIncorrectPhoneNumber { get; set; }
        public bool IsLanguageBarrier { get; set; }
        public string ZipCode { get; set; }
        public long ZipId { get; set; }
        public string Tag { get; set; }
        public long? DoNotContactUpdateSource { get; set; }
        public DateTime? LanguageBarrierMarkedDate { get; set; }
        public DateTime? IncorrectPhoneNumberMarkedDate { get; set; }
        public long? LanguageId { get; set; }
    }
}
