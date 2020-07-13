using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTags(ProspectCustomerSource source, bool isHealthPlan = false, bool includeWarmTransferTag = false);
        IEnumerable<Tag> GetForPreAssessmentTags(ProspectCustomerSource source, bool isHealthPlan = false, bool includeWarmTransferTag = false);
    }
}
