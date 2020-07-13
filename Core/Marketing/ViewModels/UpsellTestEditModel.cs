using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    [NoValidationRequired]
    public class UpsellTestEditModel
    {
        public IEnumerable<EventTestOrderItemViewModel> EventTestOrderItemList { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public IEnumerable<long> SelectedEventTestIds { get; set; }

        public string Guid { get; set; }
        public bool IsAdditionalTestAvailable { get; set; }

        public bool SaveBloodPanelTest { get; set; }

    }
}
