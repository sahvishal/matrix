using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Medical.Impl
{
    public class AAATestResultValidationRuleFactory : IValidationRuleFactory<AAATestResult>
    {
        public List<IValidationRule<AAATestResult>> CreateValidationRules()
        {
            return new List<IValidationRule<AAATestResult>>
            {
                new CannotBeNullRule<AAATestResult,ResultReading<decimal?>>(aaaTestResult => aaaTestResult.AortaSize, 
                    "Aorta Diameter"),
                new CannotBeNullRule<AAATestResult,List<ResultMedia>>(aaaTestResult => aaaTestResult.ResultImages, "Result Images"),                
                new NumberMustBeInRangeRule<AAATestResult,int>(aaaTestResult => aaaTestResult.ResultImages.Count,"Number of Images",3, 15)
                
            };
        }
    }
}