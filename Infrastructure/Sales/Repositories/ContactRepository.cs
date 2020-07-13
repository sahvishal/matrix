using System.Linq;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Sales.Factories;
using Falcon.App.Infrastructure.Sales.Interfaces;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    public class ContactRepository : PersistenceRepository, IContactRepository
    {
        private readonly IContactFactory _contactFactory;
        public ContactRepository()
            :this(new SqlPersistenceLayer(), new ContactFactory())
        {}

        public ContactRepository(IPersistenceLayer persistenceLayer, IContactFactory contactFactory)
            :base(persistenceLayer)
        {
            _contactFactory = contactFactory;
        }

        public Contact GetContactForHost(long hostId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from pc in linqMetaData.ProspectContact
                              join c in linqMetaData.Contacts on pc.ContactId equals c.ContactId
                              join pcrm in linqMetaData.ProspectContactRoleMapping on pc.ProspectContactId equals
                                  pcrm.ProspectContactId into querableContact
                              from qc in querableContact.DefaultIfEmpty()
                              orderby qc.ProspectContactRoleId
                              where
                                  pc.ProspectId == hostId && c.IsActive && pc.IsActive &&
                                  (qc.IsActive == null || qc.IsActive)
                              select c).FirstOrDefault();
                if (entity == null)
                    return null;
                return _contactFactory.CreateContact(entity);

            }
        }
    }
}
