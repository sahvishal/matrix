using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class MedicalVendorEarningValidationRuleFactory : IValidationRuleFactory<MedicalVendorEarning>
    {
        public List<IValidationRule<MedicalVendorEarning>> CreateValidationRules()
        {
            return new List<IValidationRule<MedicalVendorEarning>>
            {
                new NumberMustBeInRangeRule<MedicalVendorEarning, long>(mve => mve.OrganizationRoleUserId, 
                    "Organization Role User Id", 1, long.MaxValue),
                new NumberMustBeInRangeRule<MedicalVendorEarning, long>(mve => mve.MedicalVendorUserEventTestLockId, 
                    "MedicalVendorUserEventTestLockId", 1, long.MaxValue),
                new NumberMustBeInRangeRule<MedicalVendorEarning, decimal>(mve => mve.MedicalVendorUserAmountEarned,
                    "MedicalVendorUserAmountEarned", .01m, 100m),
                new CannotBeNullRule<MedicalVendorEarning, DataRecorderMetaData>(mve => mve.DataRecorderMetaData, 
                    "DataRecorderMetaData")
            };
        }
    }
}