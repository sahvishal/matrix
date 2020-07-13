using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class ProspectCustomerViewData
    {
        public long ProspectCustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public PhoneNumber PhoneHome { get; set; }
        public PhoneNumber PhoneCell { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
        // TODO: Will be map to enum
        public ProspectCustomerConversionStatus? ProspectStatus { get; set; }

        public string SourceCode { get; set; }
        public string WellnessSeminar { get; set; }
        public DateTime SeminarDate { get; set; }
        public DateTime EventDate { get; set; }
        public long EventId { get; set; }

        public List<CallDetails> ProspectCallDetails { get; set; }

    }
    public class CallDetails
    {
        public long CallId { get; set; }
        public string CallNotes { get; set; }
        public CallStatus? CallStatus { get; set; }
        public DateTime? CallDate { get; set; }
        public DateTime? CallStartTime { get; set; }
        public DateTime? CallEndTime { get; set; }
    }
}
