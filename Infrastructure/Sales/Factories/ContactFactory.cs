using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Sales.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    public class ContactFactory : IContactFactory
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public ContactFactory()
            : this(new EmailFactory(), new PhoneNumberFactory())
        { }

        public ContactFactory(IEmailFactory emailFactory, IPhoneNumberFactory phoneNumberFactory)
        {
            _emailFactory = emailFactory;
            _phoneNumberFactory = phoneNumberFactory;
        }

        public Contact CreateContact(ContactsEntity contactsEntity)
        {
            return new Contact(contactsEntity.ContactId)
                       {
                           Name = new Name(contactsEntity.FirstName, contactsEntity.MiddleName, contactsEntity.LastName),
                           Email = _emailFactory.CreateEmail(contactsEntity.Email),
                           HomePhoneNumber =
                               _phoneNumberFactory.CreatePhoneNumber(contactsEntity.PhoneHome, PhoneNumberType.Home),
                           MobilePhoneNumber =
                               _phoneNumberFactory.CreatePhoneNumber(contactsEntity.PhoneCell, PhoneNumberType.Mobile),
                           OfficePhoneNumber =
                               _phoneNumberFactory.CreatePhoneNumber(contactsEntity.PhoneOffice, PhoneNumberType.Office),
                           OfficePhoneExtn = contactsEntity.PhoneOfficeExtension
                       };
        }
    }
}
