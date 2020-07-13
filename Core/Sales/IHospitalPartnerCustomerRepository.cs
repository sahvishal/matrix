using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Core.Sales
{
    public interface IHospitalPartnerCustomerRepository
    {
        HospitalPartnerCustomer Save(HospitalPartnerCustomer hospitalPartnerCustomer);
        IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomers(IEnumerable<long> eventIds);
        IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomers(long eventId, long customerId);
        long GetMostRecentContactedEvent(long hospitalPartnerId);
        IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomersByHospitalPartnerId(long hospitalPartnerId, ResultInterpretation resultInterpretation, int validityPeriod = 0);
        IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomersByHospitalPartnerIdForCritical(long hospitalPartnerId, ResultInterpretation resultInterpretation, int validityPeriod = 0);
        long GetMostRecentContactedEventForHospitalFacility(long hospitalFacilityId);
        IEnumerable<HospitalPartnerCustomer> GetHospitalFacilityCustomersByHospitalFacilityId(long hospitalFacilityId, ResultInterpretation resultInterpretation, int validityPeriod = 0);
        IEnumerable<HospitalPartnerCustomer> GetHospitalFacilityCustomersByHospitalFacilityIdForCritical(long hospitalFacilityId, ResultInterpretation resultInterpretation, int validityPeriod = 0);
    }
}
