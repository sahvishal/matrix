using System.Collections.Generic;

namespace Falcon.App.Core.Deprecated
{
    public interface IValidator<T>
    {
        bool IsValid(T objectToValidate);
        List<string> GetBrokenRuleErrorMessages();
    }
}