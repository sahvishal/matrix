using Falcon.App.Core.Medical.ViewModels;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IMedicalVendorEarningAggregateFactory
    {
        MedicalVendorEarningAggregate CreateMedicalVendorEarningAggregate(MedicalVendorEarningInfoRow medicalVendorEarningInfoRow, 
            long medicalVendorUserEventTestLockId);
    }
}