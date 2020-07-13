using Falcon.App.Core.Sales.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Sales.Interfaces
{
    public interface IContactFactory
    {
        Contact CreateContact(ContactsEntity contactsEntity);
    }
}
