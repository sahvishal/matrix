using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    // TODO: Needs refactoring and reconsideration
    public class LipidCompleteResultForNoUnableToScreenRule : IValidationRule<LipidTestResult>
    {
        #region IValidationRule<LipidTestResult> Members

        public string GetErrorMessage(LipidTestResult objectToValidate)
        {
            return "'Unable To Screen' is not marked, and Readings/Findings are lying incomplete";
        }

        public bool IsValid(LipidTestResult objectToValidate)
        {            
            if (objectToValidate.UnableScreenReason == null || objectToValidate.UnableScreenReason.Count < 1)
            {
                if ((new ReadingNotBlankRule<int?>().IsValid(objectToValidate.LDL)) == false
                    || (new ReadingNotBlankRule<int?>().IsValid(objectToValidate.Glucose)) == false
                    || (new ReadingNotBlankRule<decimal?>().IsValid(objectToValidate.TCHDLRatio)) == false
                    || (new ReadingNotBlankRule<string>().IsValid(objectToValidate.TotalCholestrol)) == false
                    || (new ReadingNotBlankRule<string>().IsValid(objectToValidate.HDL)) == false
                    || (new ReadingNotBlankRule<string>().IsValid(objectToValidate.TriGlycerides)) == false)
                    return false;
            }

            return true;
        }

        #endregion
    }
}
