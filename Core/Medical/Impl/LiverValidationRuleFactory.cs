using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class LiverValidationRuleFactory : IValidationRuleFactory<LiverTestResult>
    {
        #region IValidationRuleFactory<LiverTestResult> Members

        public List<IValidationRule<LiverTestResult>> CreateValidationRules()
        {//TODO: More Rules will be created and added here
            return new List<IValidationRule<LiverTestResult>>
            {
                new LiverCompleteResultForNoUnableToScreenRule()
            };
        }

        #endregion
    }
}
