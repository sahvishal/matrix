using System.Collections.Generic;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.ValidationRules;

namespace Falcon.App.Core.Finance.Impl
{
    public class MedicalVendorInvoiceValidationRuleFactory : IValidationRuleFactory<PhysicianInvoice>
    {
        private readonly IValidator<PhysicianInvoiceBase> _medicalVendorInvoiceBaseValidator;
        private readonly IValidator<MedicalVendorInvoiceItem> _medicalVendorInvoiceItemValidator;

        public MedicalVendorInvoiceValidationRuleFactory()
            : this(new Validator<PhysicianInvoiceBase>(new MedicalVendorInvoiceBaseValidationRuleFactory()),
            new Validator<MedicalVendorInvoiceItem>(new MedicalVendorInvoiceItemValidationRuleFactory()))
        {}

        public MedicalVendorInvoiceValidationRuleFactory(IValidator<PhysicianInvoiceBase> medicalVendorInvoiceBaseValidator,
            IValidator<MedicalVendorInvoiceItem> medicalVendorInvoiceItemValidator)
        {
            _medicalVendorInvoiceBaseValidator = medicalVendorInvoiceBaseValidator;
            _medicalVendorInvoiceItemValidator = medicalVendorInvoiceItemValidator;
        }

        public List<IValidationRule<PhysicianInvoice>> CreateValidationRules()
        {
            var medicalVendorInvoiceItemValidationRule = new ComposedObjectMustBeValidRule<MedicalVendorInvoiceItem, 
                MedicalVendorInvoiceItem>(m => m, _medicalVendorInvoiceItemValidator);
            return new List<IValidationRule<PhysicianInvoice>>
            {
                new CollectionCannotBeEmptyRule<PhysicianInvoice, MedicalVendorInvoiceItem>
                    (m => m.MedicalVendorInvoiceItems, "Medical Vendor Invoice Items"),
                new CollectionMustBeValidRule<PhysicianInvoice, MedicalVendorInvoiceItem>
                    (m => m.MedicalVendorInvoiceItems, medicalVendorInvoiceItemValidationRule),
                new InheritedObjectMustBeValidRule<PhysicianInvoice, PhysicianInvoiceBase>
                    (_medicalVendorInvoiceBaseValidator)
            };
        }
    }
}