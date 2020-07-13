using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;

namespace HealthYes.Web.UnitTests.Fakes
{
    public class FakeMedicalVendorInvoiceBase : PhysicianInvoiceBase
    {
        public FakeMedicalVendorInvoiceBase()
            : base(0)
        {}

        public FakeMedicalVendorInvoiceBase(long medicalVendorInvoiceId) : base(medicalVendorInvoiceId)
        {}

        public override decimal InvoiceAmount{get { throw new NotImplementedException(); }}
        public override int NumberOfEvaluations{get { throw new NotImplementedException(); }}
    }
}