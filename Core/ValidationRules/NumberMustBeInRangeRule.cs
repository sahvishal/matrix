using System;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class NumberMustBeInRangeRule<T,N> : IValidationRule<T>
        where T : class
        where N : IComparable
    {
        private readonly Func<T, N> _numberToCheck;
        private readonly string _propertyName;
        private readonly N _minimumNumber;
        private readonly N _maximumNumber;

        public NumberMustBeInRangeRule(Func<T, N> numberToCheck, string propertyName, 
            N minimumNumber, N maximumNumber)
        {
            if (numberToCheck == null)
            {
                throw new ArgumentNullException("numberToCheck", "Function delegating which number to check must be provided.");
            }
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "Property name must be provided.");
            }
            if (minimumNumber.CompareTo(maximumNumber) > 0)
            {
                throw new ArgumentException("Minimum number must be greater than maximum number.");
            }
            _numberToCheck = numberToCheck;
            _propertyName = propertyName;
            _minimumNumber = minimumNumber;
            _maximumNumber = maximumNumber;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return objectToValidate != null ? string.Format("{0} {1} must be between {2} and {3} (inclusive).",
                _propertyName, _numberToCheck(objectToValidate), _minimumNumber, _maximumNumber) 
                : "Given object to get message for was null.";
        }

        public bool IsValid(T objectToValidate)
        {
            return objectToValidate != null && _numberToCheck(objectToValidate).CompareTo(_minimumNumber) >= 0
                && _numberToCheck(objectToValidate).CompareTo(_maximumNumber) <= 0;
        }
    }
}