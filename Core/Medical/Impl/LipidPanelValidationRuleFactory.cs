using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class LipidPanelValidationRuleFactory : IValidationRuleFactory<LipidTestResult>
    {        
        #region IValidationRuleFactory<LipidTestResult> Members

        public List<IValidationRule<LipidTestResult>> CreateValidationRules()
        {
            return new List<IValidationRule<LipidTestResult>>
            {
                new LipidCalculatableDataMustBeValidRule<LipidTestResult, int?>(),
                new LipidCompleteResultForNoUnableToScreenRule()
            };
        }

        #endregion
    }
}
