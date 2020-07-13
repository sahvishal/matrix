using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IHospitalPartnerPackageRepository
    {
        void Save(HospitalPartnerPackage domainObject);
        void DeleteByHospitalPartnerId(long hospitalpartnerId);
        void Save(IEnumerable<HospitalPartnerPackage> hospitalPartnerPackags, long hospitalpartnerId);
        IEnumerable<HospitalPartnerPackage> GetByHospitalpartnerId(long hospitalpartnerId);
    }
}
