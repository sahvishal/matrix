using System;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorEarningAggregateFactory : IMedicalVendorEarningAggregateFactory
    {
        public MedicalVendorEarningAggregate CreateMedicalVendorEarningAggregate(MedicalVendorEarningInfoRow medicalVendorEarningInfoRow, 
            long medicalVendorUserEventTestLockId)
        {
            if (medicalVendorEarningInfoRow == null)
            {
                throw new ArgumentNullException("medicalVendorEarningInfoRow");
            }

            return new MedicalVendorEarningAggregate
            {
                MedicalVendorUserEventTestLockId = medicalVendorUserEventTestLockId,
                MedicalVendorMedicalVendorUserId = medicalVendorEarningInfoRow.OrganizationRoleUserId,
                MedicalVendorId = medicalVendorEarningInfoRow.OrganizationId,
                //TODO Sandeep Change
                //MedicalVendorMedicalVendorUserAmountEarned = medicalVendorEarningInfoRow.
            };
        }
    }
}