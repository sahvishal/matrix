using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
   public class AccountVerificationEditModel : ViewModelBase
    {
        public string Content { get; set; }
        public bool AllowVerifiedMembersOnly { get; set; }
        public string CheckoutPhoneNumber { get; set; }
        
        public bool FirstNameVerification { get; set; }
        public bool LastNameVerification { get; set; }
        public bool DateOfBirthVerification { get; set; }
        public bool CustomerEmailVerification { get; set; }
        public bool MemberIdVerification { get; set; }
        public bool ZipCodeVerification { get; set; }
        

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("DoB")]
        public DateTime? DateOfBirth { get; set; }
        public string CustomerEmail { get; set; }
        public string MemberId { get; set; }
        public string ZipCode { get; set; }

        public string MemberIdLabel { get; set; }

        public string Tag { get; set; }
        public string UrlSuffix { get; set; }
        public string InvitationCode { get; set; }
        public long CustomerId { get; set; }
        public string Guid { get;set; }

        
    }
}
