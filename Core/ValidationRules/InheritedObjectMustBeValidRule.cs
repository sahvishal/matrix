using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Impl;

namespace Falcon.App.Core.ValidationRules
{
    public class InheritedObjectMustBeValidRule<T, N> : IValidationRule<T>
        where T : class, N
    {
        private readonly IValidator<N> _validatorForObject;
        private readonly IValidationErrorMessageFormatter<N> _formatter;

        public InheritedObjectMustBeValidRule(IValidator<N> validatorForObject)
            : this(validatorForObject, new ValidationErrorMessageFormatter<N>())
        {}

        public InheritedObjectMustBeValidRule(IValidator<N> validatorForObject,
            IValidationErrorMessageFormatter<N> formatter)
        {
            if (validatorForObject == null)
            {
                throw new ArgumentNullException("validatorForObject", "A validator for the inherited object must be provided.");
            }
            if (formatter == null)
            {
                throw new ArgumentNullException("formatter", "An error message formatter must be provided.");
            }
            _validatorForObject = validatorForObject;
            _formatter = formatter;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return _formatter.FormatErrorMessages(_validatorForObject);
        }

        public bool IsValid(T objectToValidate)
        {
            return objectToValidate != null && _validatorForObject.IsValid(objectToValidate);
        }
    }
}