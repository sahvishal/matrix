using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.InboundReport;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Infrastructure.InboundReport.Impl
{
    [DefaultImplementation]
    public class ConditionInboundReportFactory : IConditionInboundReportFactory
    {
        private const string Icd10 = "10";
        private const string Icd9 = "9";

        public ListModelBase<ConditionInboundViewModel, ConditionInboundFilter> Create(IEnumerable<EventCustomerDiagnosis> diagnosisRecords, IEnumerable<EventCustomer> eventCustomers, IEnumerable<ChaseOutbound> chaseOutbounds,
            IEnumerable<CustomerChaseCampaign> customerChaseCampaigns, IEnumerable<ChaseCampaign> chaseCampaigns)
        {
            var collection = new List<ConditionInboundViewModel>();

            foreach (var eventCustomer in eventCustomers)
            {
                var eventCustomerDiagnosisRecords = diagnosisRecords.Where(x => x.EventCustomerId == eventCustomer.Id);
                var chaseOutbound = chaseOutbounds.FirstOrDefault(x => x.CustomerId == eventCustomer.CustomerId);
                if (chaseOutbound == null) continue;

                ChaseCampaign campaign = null;
                var customerChaseCampaign = !customerChaseCampaigns.IsNullOrEmpty() ? customerChaseCampaigns.FirstOrDefault(x => x.CustomerId == eventCustomer.CustomerId) : null;

                if (customerChaseCampaign != null && !chaseCampaigns.IsNullOrEmpty())
                    campaign = chaseCampaigns.FirstOrDefault(x => x.Id == customerChaseCampaign.ChaseCampaignId);

                foreach (var eventCustomerDiagnosis in eventCustomerDiagnosisRecords)
                {
                    collection.Add(new ConditionInboundViewModel
                    {
                        TenantId = chaseOutbound.TenantId,
                        ClientId = chaseOutbound.ClientId,
                        CampaignId = campaign != null ? campaign.CampaignId : "",
                        IndividualIdNumber = chaseOutbound.IndividualId,
                        ContractNumber = chaseOutbound.ContractNumber,
                        ContractPersonNumber = chaseOutbound.ContractPersonNumber,
                        ConsumerId = chaseOutbound.ConsumerId,
                        VendorPersonId = eventCustomer.CustomerId.ToString(),
                        ConditionId = "",
                        ConditionName = !string.IsNullOrEmpty(eventCustomerDiagnosis.Diagnosis) && eventCustomerDiagnosis.Diagnosis.Length > 100 ? eventCustomerDiagnosis.Diagnosis.Substring(0, 100) : eventCustomerDiagnosis.Diagnosis,
                        ConditionDiagnosisCode = eventCustomerDiagnosis.Icd,
                        ConditionIcdIndicator = eventCustomerDiagnosis.IsIcd10 ? Icd10 : Icd9
                    });
                }
            }

            return new ConditionInboundListModel
            {
                Collection = collection
            };
        }
    }
}
