using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class ClientEventVolumeListModel : ListModelBase<ClientEventVolumeModel, ClientEventVolumeListModelFilter>
    {
        public override IEnumerable<ClientEventVolumeModel> Collection { get; set; }
        public override ClientEventVolumeListModelFilter Filter { get; set; }
    }
}
