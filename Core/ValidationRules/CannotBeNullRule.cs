using System;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class CannotBeNullRule<T, N> : IValidationRule<T>
        where T : class
        where N : class
    {
        private readonly Func<T, N> _propertyToCheck;
        private readonly string _propertyName;

        public CannotBeNullRule(Func<T, N> propertyToCheck, string propertyName)
        {
            _propertyToCheck = propertyToCheck;
            _propertyName = propertyName;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return string.Format("{0} must be provided.", _propertyName);
        }

        public bool IsValid(T objectToValidate)
        {
            return objectToValidate != null && _propertyToCheck(objectToValidate) != null;
        }
    }
}