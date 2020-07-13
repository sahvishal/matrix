using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class EKGValidationRuleFactory : IValidationRuleFactory<EKGTestResult>
    {
        #region IValidationRuleFactory<EKGTestResult> Members

        public List<IValidationRule<EKGTestResult>> CreateValidationRules()
        {//TODO: More Rules will be created and added here
            return new List<IValidationRule<EKGTestResult>>
            {
                new EKGCompleteResultForNoUnableToScreenReasonRule()
            };
        }

        #endregion
    }
}
