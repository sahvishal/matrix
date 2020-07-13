using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareTestRecommendationListModel
    {
        public List<string> Alias { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }
    }
}
