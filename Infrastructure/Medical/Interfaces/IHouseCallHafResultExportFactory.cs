using Falcon.App.Core;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface IHouseCallHafResultExportFactory
    {
        void Create(IEnumerable<EventCustomersEntity> eventCustomerEntities, IEnumerable<OrderedPair<long, long>> orgRoleUserIdUserIdPairs,
            IEnumerable<UserEntity> userEntities, IEnumerable<Address> addresses, IEnumerable<CustomerProfileEntity> customerProfileEntities, IEnumerable<EventsEntity> eventsEntities,
            IEnumerable<CustomerHealthInfoEntity> customerHealthInfoEntities, IEnumerable<OrderedPair<long, string>> careCoordinatorIdNamePair,
            IEnumerable<CustomerPrimaryCarePhysicianEntity> primaryCarePhysicianEntities, IEnumerable<Address> pcpAddresses, IEnumerable<EventAppointmentEntity> eventAppointmentEntities, string destinationDirectory);
    }
}
