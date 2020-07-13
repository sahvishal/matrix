using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerDetailViewModel
    {
        public long EventCustomerId { get; set; }

        public long CustomerId { get; set; }

        public Name CustomerName { get; set; }

        public AddressEditModel Address { get; set; }

        public PhoneNumber HomePhone { get; set; }

        public string Email { get; set; }

        public bool IsNoShow { get; set; }

        public bool IsHealthAssessmentFormFilled { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal TotalAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal AmountPaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal AmountDue { get; set; }

        public RegulatoryState HipaaStatus { get; set; }

        public string EmployeeId { get; set; }

        public string InsuranceId { get; set; }

        public Height Height { get; set; }

        public Weight Weight { get; set; }

        public Gender Gender { get; set; }

        public Race Race { get; set; }

        public DateTime? Dob { get; set; }

        public long PackageId { get; set; }

        public IEnumerable<long> TestIds { get; set; }

        public string OrderPurchased { get; set; }

        public bool AllowPrequalifiedTestOnly { get; set; }

        public bool EnableTexting { get; set; }

        public PhoneNumber MobileNumber { get; set; }

        public long ProductId { get; set; }

        public string SourceCode { get; set; }

        public IEnumerable<long> ShippingOptions { get; set; }

        public long? Tag { get; set; }

        public RegulatoryState PartnerReleaseStatus { get; set; }

        public RegulatoryState PcpConsentStatus { get; set; }

        public bool ShowAwvPcpForm { get; set; }
        
        public RegulatoryState InsuranceReleaseStatus { get; set; }

        public bool CaptureInsuranceRelease { get; set; }

        public RegulatoryState AbnStatus { get; set; }
    }
}