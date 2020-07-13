using System;
using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Impl
{
    public class PRTAxisValidationRuleFactory : IValidationRuleFactory<PRTAxis>
    {
        public List<IValidationRule<PRTAxis>> CreateValidationRules()
        {
            throw new NotImplementedException();
        }
    }
}