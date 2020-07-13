using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Impl;

namespace Falcon.App.Core.ValidationRules
{
    /// <typeparam name="T">Object containing N.</typeparam>
    /// <typeparam name="N">Object composed in T.</typeparam>
    public class ComposedObjectMustBeValidRule<T, N> : IValidationRule<T> 
        where T : class
    {
        private readonly Func<T, N> _propertyToCheck;
        private readonly IValidator<N> _validatorForProperty;
        private readonly IValidationErrorMessageFormatter<N> _formatter;

        public ComposedObjectMustBeValidRule(Func<T, N> propertyToCheck, IValidator<N> validatorForProperty)
            : this(propertyToCheck, validatorForProperty, new ValidationErrorMessageFormatter<N>())
        {}

        public ComposedObjectMustBeValidRule(Func<T, N> propertyToCheck, IValidator<N> validatorForProperty,
            IValidationErrorMessageFormatter<N> formatter)
        {
            if (propertyToCheck == null)
            {
                throw new ArgumentNullException("propertyToCheck", 
                    "A funciton delegating which composed object is to be validated must be provided.");
            }
            if (validatorForProperty == null)
            {
                throw new ArgumentNullException("validatorForProperty",
                    "A validator that can validate the delegated composed object must be provided.");
            }
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter", "An error message formatter must be provided.");
            }
            _propertyToCheck = propertyToCheck;
            _validatorForProperty = validatorForProperty;
            _formatter = formatter;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return _formatter.FormatErrorMessages(_validatorForProperty, "\t");
        }

        public bool IsValid(T objectToValidate)
        {
            return objectToValidate != null && _validatorForProperty.IsValid(_propertyToCheck(objectToValidate));
        }
    }
}