using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PrimaryCarePhysicianViewModel
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

        public AddressViewModel Address { get; set; }

        public bool HasSameAddress { get; set; }

        public AddressViewModel MailingAddress { get; set; }

        public string Phone { get; set; }
    }
}