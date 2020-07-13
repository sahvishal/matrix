using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeValidator<T> : IValidator<T>
    {
        public bool IsValidReturnValue { get; set; }
        public List<string> BrokenRuleErrorMessages { get; set; }

        public FakeValidator()
            : this(true, new List<string>())
        {}

        public FakeValidator(bool isValid)
            : this(isValid, new List<string>())
        {}

        public FakeValidator(bool isValid, List<string> brokenRuleErrorMessages)
        {
            IsValidReturnValue = isValid;
            BrokenRuleErrorMessages = brokenRuleErrorMessages;
        }

        public bool IsValid(T objectToValidate)
        {
            return IsValidReturnValue;
        }

        public List<string> GetBrokenRuleErrorMessages()
        {
            return BrokenRuleErrorMessages;
        }
    }
}