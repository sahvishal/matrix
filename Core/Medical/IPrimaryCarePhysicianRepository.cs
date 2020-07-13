using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPrimaryCarePhysicianRepository : IRepository<PrimaryCarePhysician>
    {
        PrimaryCarePhysician Get(long customerId);
        IEnumerable<PrimaryCarePhysician> GetByCustomerIds(IEnumerable<long> customerIds);
        IEnumerable<PrimaryCarePhysician> GetByPhysicianMasterId(long physicianMasterId);
        void Delete(long customerId);
        void DecativatePhysician(long customerId, long updatedBy);
        IEnumerable<PrimaryCarePhysician> GetForPcpChangeReport(IEnumerable<long> customerIds);
        IEnumerable<PrimaryCarePhysician> GetAllByCustomerIds(IEnumerable<long> customerIds);
        IEnumerable<PrimaryCarePhysician> GetCustomerPcpWithoutAddress(IEnumerable<long> customerIds);

        IEnumerable<PrimaryCarePhysician> GetPrimaryCarePhysicians(UniversalProviderListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
    }
}