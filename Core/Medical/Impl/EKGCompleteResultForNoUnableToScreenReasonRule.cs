using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class EKGCompleteResultForNoUnableToScreenReasonRule : IValidationRule<EKGTestResult>
    {
        #region IValidationRule<EKGTestResult> Members

        public string GetErrorMessage(EKGTestResult objectToValidate)
        {
            return "'Unable To Screen' is not marked, and Readings/Findings are lying incomplete";
        }

        public bool IsValid(EKGTestResult objectToValidate)
        {
            if (objectToValidate.UnableScreenReason == null || objectToValidate.UnableScreenReason.Count < 1)
            {
                if ((new ReadingNotBlankRule<int?>().IsValid(objectToValidate.VentRate)) == false
                    || (new ReadingNotBlankRule<decimal?>().IsValid(objectToValidate.PRInterval)) == false
                    || (new ReadingNotBlankRule<decimal?>().IsValid(objectToValidate.QRSDuration)) == false
                    || (new ReadingNotBlankRule<decimal?>().IsValid(objectToValidate.QTcInterval)) == false
                    || (new ReadingNotBlankRule<decimal?>().IsValid(objectToValidate.QTInterval)) == false
                    || objectToValidate.ResultImage == null || objectToValidate.ResultImage.File == null)
                    return false;
            }

            return true;
        }

        #endregion
    }
}
