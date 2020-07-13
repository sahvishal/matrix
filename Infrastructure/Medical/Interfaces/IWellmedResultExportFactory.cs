using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Geo.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface IWellmedResultExportFactory
    {
        void Create(IEnumerable<EventCustomerResultEntity> eventCustomerResultEntities, IEnumerable<OrderedPair<long, long>> orgRoleUserIdUserIdPairs, IEnumerable<UserEntity> userEntities,
            IEnumerable<Address> addresses, IEnumerable<CustomerProfileEntity> customerProfileEntities, IEnumerable<EventsEntity> eventsEntities, IEnumerable<CustomerHealthInfoEntity> customerHealthInfoEntities,
            IEnumerable<OrderedPair<long, long>> eventIdPodIdPairs, IEnumerable<PodDetailsEntity> podDetailsEntities, IEnumerable<OrderedPair<long, long>> eventIdHospitalPartnerIdPairs, IEnumerable<OrderedPair<long, string>> hospitalPartnerIdNamePairs,
            IEnumerable<EventCustomerBasicBioMetricEntity> basicBioMetricEntities, IEnumerable<EventCustomersEntity> eventCustomersEntities, IEnumerable<EventAppointmentEntity> eventAppointmentEntities,
            IEnumerable<HospitalPartnerCustomerEntity> hospitalPartnerCustomerEntities, IEnumerable<OrderedPair<long, string>> careCoordinatorIdNamePair, IEnumerable<CustomerPrimaryCarePhysicianEntity> primaryCarePhysicianEntities,
            string destinationDirectory, IEnumerable<long> hafQuestionIds);
    }
}