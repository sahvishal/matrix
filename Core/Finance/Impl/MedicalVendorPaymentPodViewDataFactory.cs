using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Finance.Impl
{
    public class MedicalVendorPaymentPodViewDataFactory : IMedicalVendorPaymentPodViewDataFactory
    {
        public List<MedicalVendorPaymentPodViewData> CreatePodViewData(List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems)
        {
            return medicalVendorInvoiceItems.GroupBy(i => new {i.PodId, i.PodName}).Select(
                g => new MedicalVendorPaymentPodViewData
                {
                    Pod = new Pod(g.Key.PodId) {Name = g.Key.PodName},
                    AmountEarned = g.Sum(i => i.MedicalVendorAmountEarned),
                    NumberOfEvaluations = g.Count()
                }).ToList();
        }
    }
}