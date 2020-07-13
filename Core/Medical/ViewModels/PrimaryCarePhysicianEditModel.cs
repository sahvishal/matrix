using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;
using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PrimaryCarePhysicianEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long CustomerId { get; set; }

        [UIHint("Name")]
        public Name FullName { get; set; }

        [DisplayName("Email")]
        [UIHint("ExtendedTextBox")]
        public string Email { get; set; }

        [DisplayName("Home Phone Number")]
        public PhoneNumber PhoneNumber { get; set; }

        public AddressEditModel Address { get; set; }

        public AddressEditModel MailingAddress { get; set; }

        public bool HasSameAddress { get; set; }

        public bool? IsPcpAddressVerified { get; set; }
        public long? PcpAddressVerifiedBy { get; set; }
        public DateTime? PcpAddressVerifiedOn { get; set; }

        public string PcpAddresVarifiedByUserName { get; set; }
        public string PcpAddresVarifiedByRole { get; set; }
        public string Phone { get; set; }
    }
}
