using System;
using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class ResultReadingRuleFactory<T> : IValidationRuleFactory<ResultReading<T>>
    {
        public List<IValidationRule<ResultReading<T>>> CreateValidationRules()
        {
            throw new NotImplementedException();
        }
    }
}