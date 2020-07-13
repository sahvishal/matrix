using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Sales.Domain
{
    public class Contact : DomainObjectBase
    {
        public Name Name { get; set; }
        public Email Email { get; set; }
        public PhoneNumber HomePhoneNumber { get; set; }
        public PhoneNumber OfficePhoneNumber { get; set; }
        public PhoneNumber MobilePhoneNumber { get; set; }
        public string OfficePhoneExtn { get; set; }
        public Contact()
        {}

        public Contact(long contactId)
            :base(contactId)
        {}
    }
}
