using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class FraminghamCalculationIsVaildRule : IValidationRule<FraminghamRiskTestResult>
    {
        #region IValidationRule<FraminghamRiskTestResult> Members

        public string GetErrorMessage(FraminghamRiskTestResult objectToValidate)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(FraminghamRiskTestResult objectToValidate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
