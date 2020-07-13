using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorEarningAggregateRepository
    {
        MedicalVendorEarningAggregate GetMedicalVendorEarningAggregate(long medicalVendorMedicalVendorUserId, long eventCustomerResultId, bool isActive);
    }
}