using System.Collections.Generic;

namespace Falcon.App.Core.Deprecated
{
    public interface IValidationErrorMessageFormatter<T>
    {
        string FormatErrorMessages(IValidator<T> validator);
        string FormatErrorMessages(List<string> brokenRuleErrorMessages);
        string FormatErrorMessages(IValidator<T> validator, string prependString);
        string FormatErrorMessages(List<string> brokenRuleErrorMessages, string prependString);
    }
}