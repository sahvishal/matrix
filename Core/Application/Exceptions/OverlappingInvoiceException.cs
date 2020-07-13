using System;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Application.Exceptions
{
    public class OverlappingInvoiceException : Exception
    {
        public OverlappingInvoiceException(PhysicianInvoiceBase medicalVendorInvoice)
            : base(string.Format("A previously saved invoice overlaps with the dates {0} - {1}.",
            medicalVendorInvoice.PayPeriodStartDate, medicalVendorInvoice.PayPeriodEndDate))
        {}
    }
}