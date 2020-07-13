using System;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.ValidationRules
{
    public class ConditionalRule<T> : IValidationRule<T>
        where T : class
    {
        private readonly Func<T, bool> _condition;
        private readonly IValidationRule<T> _ruleToCheck;
        private readonly bool _validIfConditionIsFalse;

        public ConditionalRule(Func<T, bool> condition, IValidationRule<T> ruleToCheck)
            : this(condition, ruleToCheck, true)
        {}

        public ConditionalRule(Func<T, bool> condition, IValidationRule<T> ruleToCheck, bool validIfConditionIsFalse)
        {
            _condition = condition;
            _ruleToCheck = ruleToCheck;
            _validIfConditionIsFalse = validIfConditionIsFalse;
        }

        public string GetErrorMessage(T objectToValidate)
        {
            return _ruleToCheck.GetErrorMessage(objectToValidate);
        }

        public bool IsValid(T objectToValidate)
        {
            if (_condition(objectToValidate))
            {
                return _ruleToCheck.IsValid(objectToValidate);
            }
            return _validIfConditionIsFalse;
        }
    }
}