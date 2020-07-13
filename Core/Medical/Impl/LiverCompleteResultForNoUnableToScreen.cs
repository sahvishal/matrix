using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class LiverCompleteResultForNoUnableToScreenRule : IValidationRule<LiverTestResult>
    {

        #region IValidationRule<LiverTestResult> Members

        public string GetErrorMessage(LiverTestResult objectToValidate)
        {
            return "'Unable To Screen' is not marked, and Readings/Findings are lying incomplete";
        }

        public bool IsValid(LiverTestResult objectToValidate)
        {
            if (objectToValidate.UnableScreenReason == null || objectToValidate.UnableScreenReason.Count < 1)
            {
                if ((new ReadingNotBlankRule<int?>().IsValid(objectToValidate.AST)) == false
                    || (new ReadingNotBlankRule<int?>().IsValid(objectToValidate.ALT)) == false)
                    return false;
            }

            return true;
        }

        #endregion
    }
}
