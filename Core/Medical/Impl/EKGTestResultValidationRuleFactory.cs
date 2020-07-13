using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Medical.Impl
{
    public class EKGTestResultValidationRuleFactory : IValidationRuleFactory<EKGTestResult>
    {
        public List<IValidationRule<EKGTestResult>> CreateValidationRules()
        {
            return new List<IValidationRule<EKGTestResult>>
            {
                new ConditionalRule<EKGTestResult> (
                    ekgTestResult => ekgTestResult.VentRate != null,
                    new NumberMustBeInRangeRule<EKGTestResult,int>(ekgTestResult => ekgTestResult.VentRate.Reading.Value, 
                        "Heartrate", 1, 250)
                ),
                new ConditionalRule<EKGTestResult> (
                    ekgTestResult => ekgTestResult.RRInterval != null,
                    new NumberMustBeInRangeRule<EKGTestResult,int>(ekgTestResult => ekgTestResult.RRInterval.Reading.Value, 
                        "RR Interval", 1, 250)
                ),
                new ComposedObjectMustBeValidRule<EKGTestResult, PRTAxis>(ekgTestResult => ekgTestResult.PRTAxis, 
                    new Validator<PRTAxis>(new PRTAxisValidationRuleFactory()))
            };
        }
    }
}