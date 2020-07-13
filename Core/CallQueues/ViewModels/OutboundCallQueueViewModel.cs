using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class OutboundCallQueueViewModel
    {
        public long CallQueueCustomerId { get; set; }

        public long? ProspectCustomerId { get; set; }

        public long? CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [DisplayName("Number")]
        public PhoneNumber CallBackPhoneNumber { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Inserted In Queue")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Call Reason")]
        public string CallReason { get; set; }

        public DateTime? ProspectCreatedOn { get; set; }

        public IEnumerable<CallHistoryViewModel> CallHistory { get; set; }

        public IEnumerable<NotesViewModel> Notes { get; set; }

        public string Email { get; set; }

        public PhoneNumber OfficePhoneNumber { get; set; }
        public PhoneNumber MobilePhoneNumber { get; set; }
        public string Tag { get; set; }
        public long? EventId { get; set; }

        public DateTime? EventDate { get; set; }
        public AddressViewModel EventLocation { get; set; }
        public string HostName { get; set; }
        public string Pod { get; set; }
        public string ZipCode { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public string RegistrationMode { get; set; }
        public bool IsDoNotCallCustomer { get; set; }
        public DateTime? RequestedCallBackDateTime { get; set; }

        public string CustomCorporateTags { get; set; }
    }
}
