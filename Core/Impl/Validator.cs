using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.Impl
{
    
    public class Validator<T> : IValidator<T>
        where T : class
    {
        private readonly List<IValidationRule<T>> _validationRules;
        private readonly List<string> _brokenRuleErrorMessages = new List<string>();

        public Validator(IValidationRuleFactory<T> factory)
        {
            _validationRules = factory.CreateValidationRules();
        }

        public bool IsValid(T objectToValidate)
        {
            _brokenRuleErrorMessages.Clear();
            if (objectToValidate != null)
            {
                foreach (IValidationRule<T> rule in _validationRules)
                {
                    if (!rule.IsValid(objectToValidate))
                    {
                        _brokenRuleErrorMessages.Add(rule.GetErrorMessage(objectToValidate));
                    }
                }
            }
            else
            {
                _brokenRuleErrorMessages.Add("The given object to validate was null.");
            }
            return _brokenRuleErrorMessages.Count() == 0;
        }

        public List<string> GetBrokenRuleErrorMessages()
        {
            return _brokenRuleErrorMessages;
        }
    }
}