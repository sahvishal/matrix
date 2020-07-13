using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorPaymentRepository
    {
        MedicalVendorPayment GetMedicalVendorPayment(int medicalVendorPaymentId);
        void MakePayment(MedicalVendorPayment medicalVendorPayment, List<long> medicalVendorInvoiceIdsToApplyPaymentTo);
    }
}