using System;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class CallQueueCustomerEditModel
    {
        public long CustomerId { get; set; }
        public long UserId { get; set; }
        public long ProspectCustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string CallBackPhoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public bool IsHealthPlanQueue { get; set; }

        public string PcpPhoneNumber { get; set; }
        public AddressEditModel Address { get; set; }

        public long CallQueueCustomerId { get; set; }
        public long CallId { get; set; }

        public string Hicn { get; set; }
        public string MemberId { get; set; }
        public string Mbi { get; set; }
        public bool EnableEmail { get; set; }
        //public bool? EligibleStatus { get; set; }

        public PrimaryCarePhysicianEditModel PrimaryCarePhysician { get; set; }

        public long ActivityId { get; set; }
    }
}