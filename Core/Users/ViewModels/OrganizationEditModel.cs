using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.ViewModels
{
    public class OrganizationEditModel: ViewModelBase
    {
        [UIHint("Hidden")]
        public long Id { get; set; }

        [DisplayName("Organization Type")]
        public OrganizationType OrganizationType { get; set; }

        [DisplayName("Name")]
        [UIHint("ExtendedTextBox")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [UIHint("BusinessAddress")]
        [DisplayName("Business Address")]
        public AddressEditModel BusinessAddress { get; set; }

        [UIHint("BillingAddress")]
        [DisplayName("Billing Address")]
        public AddressEditModel BillingAddress { get; set; }

        [DisplayName("Phone Number")]
        [UIHint("PhoneNumber")]
        public PhoneNumber PhoneNumber { get; set; }

        [DisplayName("Fax Number")]
        [UIHint("PhoneNumber")]
        public PhoneNumber FaxNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public File LogoImage { get; set; }
        public File TeamImage { get; set; }

        public OrganizationEditModel()
        {
            BusinessAddress = new AddressEditModel();
            BillingAddress = new AddressEditModel();
        }
    }
}
