using System.Collections.Generic;

namespace Falcon.App.Core.Deprecated
{
    public interface IValidationRuleFactory<T>
        where T : class
    {
        List<IValidationRule<T>> CreateValidationRules();
    }
}