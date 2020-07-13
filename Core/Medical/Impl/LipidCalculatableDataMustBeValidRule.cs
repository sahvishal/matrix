using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    public class LipidCalculatableDataMustBeValidRule<T, N> : IValidationRule<T> where T : LipidTestResult
    {
        private const int validRangeDecider = 5;

        #region IValidationRule<LipidTestResult> Members

        public string GetErrorMessage(T objectToValidate)
        {
            return "The values entered do not match or co-relate to those defined by the formula!";
        }

        public bool IsValid(T objectToValidate)
        {
            
            int outValue = 0;
            if ((new ReadingNotBlankRule<string>().IsValid(objectToValidate.TotalCholestrol)) == false
                    || (new ReadingNotBlankRule<string>().IsValid(objectToValidate.HDL)) == false
                    || (new ReadingNotBlankRule<string>().IsValid(objectToValidate.TriGlycerides)) == false
                    || (new ReadingNotBlankRule<int?>().IsValid(objectToValidate.LDL)) == false
                    || int.TryParse(objectToValidate.TotalCholestrol.Reading, out outValue) == false
                    || int.TryParse(objectToValidate.HDL.Reading, out outValue) == false
                    || int.TryParse(objectToValidate.TriGlycerides.Reading, out outValue) == false)
                return true; // Should send a proper message of Incomplete Readings

            bool isValid = true;
            
            isValid = IsCompareReadingValid<int?>(testResult => testResult.LDL.Reading, ReadingLabels.LDL, objectToValidate);
            if (!isValid) return false;

            isValid = IsCompareReadingValid<string>(testResult => testResult.HDL.Reading, ReadingLabels.HDL, objectToValidate);
            if (!isValid) return false;

            isValid = IsCompareReadingValid<string>(testResult => testResult.TriGlycerides.Reading, ReadingLabels.TriGlycerides, objectToValidate);
            if (!isValid) return false;

            isValid = IsCompareReadingValid<string>(testResult => testResult.TotalCholestrol.Reading, ReadingLabels.TotalCholestrol, objectToValidate);
            if (!isValid) return false;

            return true;
        }

        private bool IsCompareReadingValid<X>(Func<LipidTestResult, X> _propertyToCompare, ReadingLabels _propertyType, LipidTestResult _testResultObject)
        {
            int? _valueToCompare = Convert.ToInt32(_propertyToCompare(_testResultObject)) as int?;

            if (_valueToCompare == null)
                return true;

            int valueCalculated = 0;
            
            switch (_propertyType)
            {
                case ReadingLabels.LDL:
                    valueCalculated = Convert.ToInt32(_testResultObject.TotalCholestrol.Reading)
                                    - Convert.ToInt32(_testResultObject.HDL.Reading)
                                    - Convert.ToInt32(decimal.Round((Convert.ToDecimal(_testResultObject.TriGlycerides.Reading) / 5), 0));
                    break;

                case ReadingLabels.HDL:
                    valueCalculated = Convert.ToInt32(_testResultObject.TotalCholestrol.Reading)
                                    - _testResultObject.LDL.Reading.Value
                                    - Convert.ToInt32(decimal.Round((Convert.ToDecimal(_testResultObject.TriGlycerides.Reading) / 5), 0));
                    break;

                case ReadingLabels.TotalCholestrol:
                    valueCalculated = Convert.ToInt32(_testResultObject.HDL.Reading)
                                    + _testResultObject.LDL.Reading.Value
                                    + Convert.ToInt32(decimal.Round((Convert.ToDecimal(_testResultObject.TriGlycerides.Reading) / 5), 0));
                    break;

                case ReadingLabels.TriGlycerides:
                    valueCalculated = (Convert.ToInt32(_testResultObject.TotalCholestrol.Reading)
                                    - Convert.ToInt32(_testResultObject.HDL.Reading)
                                    - _testResultObject.LDL.Reading.Value) * 5;
                    break;
            }

            int minValue = _valueToCompare.Value - validRangeDecider;
            int maxValue = _valueToCompare.Value + validRangeDecider;

            if (valueCalculated >= minValue && valueCalculated <= maxValue)
                return true;

            return false;
        }

        #endregion
    }
}
