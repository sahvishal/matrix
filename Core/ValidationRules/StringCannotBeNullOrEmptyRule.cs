using System;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class StringCannotBeNullOrEmptyRule<T> : IValidationRule<T>
        where T : class
    {
        private readonly Func<T, string> _stringToCheck;
        private readonly string _propertyName;

        public StringCannotBeNullOrEmptyRule(Func<T, string> stringToCheck, string propertyName)
        {
            if (stringToCheck == null)
            {
                throw new ArgumentNullException("stringToCheck", "Function delegating which string to check must be provided.");
            }
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "The name of the string property must be provided.");
            }
            _stringToCheck = stringToCheck;
            _propertyName = propertyName;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return objectToValidate != null ? string.Format("The string property '{0}' cannot be null or empty.", _propertyName) 
                       : "The given object to get message for was null.";
        }

        public bool IsValid(T objectToValidate)
        {
            return objectToValidate != null && !string.IsNullOrEmpty(_stringToCheck(objectToValidate));
        }
    }
}