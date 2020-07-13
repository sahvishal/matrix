using System;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class GuidMustBeValidRule<T> : IValidationRule<T>
        where T : class
    {
        private readonly Func<T, Guid> _guidToCheck;
        private readonly string _propertyName;

        public GuidMustBeValidRule(Func<T, Guid> guidToCheck, string propertyName)
        {
            if (guidToCheck == null)
            {
                throw new ArgumentNullException("guidToCheck", "Function delegating which guid to check must be provided.");
            }
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "The name of the string property must be provided.");
            }
            _guidToCheck = guidToCheck;
            _propertyName = propertyName;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return objectToValidate != null ? string.Format("The guid property {0} cannot be empty.", _propertyName) 
                : "The given object to get message for was null.";
        }

        public bool IsValid(T objectToValidate)
        {
            return objectToValidate != null && _guidToCheck(objectToValidate) != Guid.Empty;
        }
    }
}