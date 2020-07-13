using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.ViewModels;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class CareCodingOutboundFactory : ICareCodingOutboundFactory
    {
        public CareCodingOutbound Create(CareCodingOutboundViewModel model)
        {
            return new CareCodingOutbound
            {
                TenantId = model.TenantId,
                CampaignId = model.CampaignId,
                IndividualId = model.IndividualIdNumber,
                ClientId = model.ClientId,
                ContractNumber = model.ContractNumber,
                ContractPersonNumber = model.ContractPersonNumber,
                ConsumerId = model.ConsumerId,
                CampaignCode = model.CampaignCode,
                CampaignMemberId = model.CampaignMemberId,
                CareCodeLabType = model.CareCodeLabType,
                CareCodeLabDescription = model.CareCodeLabDesc,
                StatusOfCoding = model.StatusOfCoding,
                MedicalCode = model.MedicalCode,
                MedicalCodeType = model.MedicalCodeType,
                DateCreated = DateTime.Now
            };
        }
    }
}
