using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class HiptoAcesCrossWalkFactory : IHiptoAcesCrossWalkFactory
    {
        public HiptoAcesCrossWalkViewModel Create(Customer customer, CorporateAccount account)
        {
            var model = new HiptoAcesCrossWalkViewModel
            {
                ClientId = account.ClientId,
                HipId = customer.CustomerId,
                AcesId = string.IsNullOrWhiteSpace(customer.AcesId) ? "NULL" : customer.AcesId,
                ClientMemberId = string.IsNullOrWhiteSpace(customer.InsuranceId) ? "NULL" : customer.InsuranceId,
                SecondaryClientMemberId = "NULL",
            };
            return model;
        }

    }
}
