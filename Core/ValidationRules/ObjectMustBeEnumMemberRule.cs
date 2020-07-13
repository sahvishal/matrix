using System;
using System.Linq;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class ObjectMustBeEnumMemberRule<T> : IValidationRule<T> 
        where T : class
    {
        private readonly Func<T, System.Enum> _enumToCheck;

        public ObjectMustBeEnumMemberRule(Func<T, System.Enum> enumToCheck)
        {
            if (enumToCheck == null)
            {
                throw new ArgumentNullException("enumToCheck", "A function delegating which enum to validate is required.");
            }
            _enumToCheck = enumToCheck;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            if (objectToValidate == null)
            {
                return "The given object to validate to get message for was null.";
            }
            string enumTypeName = _enumToCheck(objectToValidate).GetType().ToString().Split(".".ToArray()).Last();
            return string.Format("Enum {0} is set to {1}, which is invalid.", enumTypeName, 
                _enumToCheck(objectToValidate));
        }

        public bool IsValid(T objectToValidate)
        {
            if (objectToValidate != null)
            {
                System.Enum enumToCheck = _enumToCheck(objectToValidate);
                Type enumType = enumToCheck.GetType();
                string enumName = System.Enum.GetName(enumType, enumToCheck);

                return System.Enum.GetNames(enumType).Any(name => name == enumName);
            }
            return false;
        }
    }
}