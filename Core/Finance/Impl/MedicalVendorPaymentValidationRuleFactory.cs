using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class MedicalVendorPaymentValidationRuleFactory : IValidationRuleFactory<MedicalVendorPayment>
    {
        public List<IValidationRule<MedicalVendorPayment>> CreateValidationRules()
        {
            var validator = new Validator<PaymentInstrument>(new PaymentInstrumentValidationRuleFactory());
            var composedObjectMustBeValidRule = new ComposedObjectMustBeValidRule<PaymentInstrument, 
                PaymentInstrument>(p => p,validator);
            return new List<IValidationRule<MedicalVendorPayment>>
            {
                new CollectionMustBeValidRule<MedicalVendorPayment, PaymentInstrument>(m => m.PaymentInstruments, 
                    composedObjectMustBeValidRule),
                new ObjectMustBeEnumMemberRule<MedicalVendorPayment>(m => m.PaymentStatus),
                new CannotBeNullRule<MedicalVendorPayment, DataRecorderMetaData>(m => m.DataRecorderMetaData, 
                    "DataRecorderMetaData")
            };
        }
    }
}