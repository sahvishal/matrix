using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianMasterListModel
    {
        public IEnumerable<PhysicianMasterViewModel> Physicians { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public bool SelectedPhysicianId { get; set; }
    }
}
