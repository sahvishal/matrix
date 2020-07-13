using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    [NoValidationRequired]
    public class CampaignDirectMailDatesEditModel
    {
        public long CampaignId { get; set; }

        public IEnumerable<DirectMailDateEditModel> DirectMailDateActivities { get; set; }
    }
}
