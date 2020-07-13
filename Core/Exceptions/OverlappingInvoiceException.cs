using System;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Exceptions
{
    public class OverlappingInvoiceException : Exception
    {
        public OverlappingInvoiceException(MedicalVendorInvoiceBase medicalVendorInvoice)
            : base(string.Format("A previously saved invoice overlaps with the dates {0} - {1}.",
            medicalVendorInvoice.PayPeriodStartDate, medicalVendorInvoice.PayPeriodEndDate))
        {}
    }
}