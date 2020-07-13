using System;
using System.Linq;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class StringLengthMustBeInRangeRule<T> : IValidationRule<T> 
        where T : class
    {
        private readonly Func<T, string> _stringPropertyToValidate;
        private readonly string _propertyName;
        private readonly int _minimumLength;
        private readonly int _maximumLength;

        public StringLengthMustBeInRangeRule(Func<T, string> stringPropertyToValidate, string propertyName,
            int minimumLength)
            : this(stringPropertyToValidate, propertyName, minimumLength, int.MaxValue)
        {}

        public StringLengthMustBeInRangeRule(Func<T, string> stringPropertyToValidate, string propertyName,
            int minimumLength, int maximumLength)
        {
            if (minimumLength < 0)
            {
                throw new ArgumentOutOfRangeException("minimumLength", "Minimum length cannot be less than 0.");
            }
            if (maximumLength < 0)
            {
                throw new ArgumentOutOfRangeException("maximumLength", "Maximum length cannot be less than 0.");
            }
            if (minimumLength > maximumLength)
            {
                throw new ArgumentException(string.Format("Minimum length {0} cannot exceed maximum length {1}.", 
                    minimumLength, maximumLength));
            }
            _stringPropertyToValidate = stringPropertyToValidate;
            _propertyName = propertyName;
            _minimumLength = minimumLength;
            _maximumLength = maximumLength;
        }


        public string GetErrorMessage(T objectToValidate)
        {
            if (objectToValidate == null || _stringPropertyToValidate(objectToValidate) == null)
            {
                return string.Format("The given object to validate (or its string property) was null.");
            }
            string typeName = typeof(T).ToString().Split(".".ToArray()).Last();
            string errorMessagePrefix = string.Format("The {0} property {1} ", typeName, _propertyName);
            string errorMessageBody;
            if (_minimumLength > 0 && _maximumLength < int.MaxValue)
            {
                errorMessageBody = string.Format("must be between {0} and {1} characters.", _minimumLength, _maximumLength);
            }
            else if (_maximumLength < int.MaxValue)
            {
                errorMessageBody = string.Format("can't have more than {0} characters.", _maximumLength);
            }
            else
            {
                errorMessageBody = string.Format("must be at least {0} characters long.", _minimumLength);
            }
            return errorMessagePrefix + errorMessageBody + string.Format(" The length was {0}.",
                _stringPropertyToValidate(objectToValidate).Length);
        }

        public bool IsValid(T objectToValidate)
        {
            if (objectToValidate == null || _stringPropertyToValidate(objectToValidate) == null)
            {
                return false;
            }
            int lengthOfStringProperty = _stringPropertyToValidate(objectToValidate).Length;
            return lengthOfStringProperty >= _minimumLength && lengthOfStringProperty <= _maximumLength;
        }
    }
}