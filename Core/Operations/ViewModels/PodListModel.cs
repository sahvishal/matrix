using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class PodBasicModel
    {
        public long Id { get; set; }
        public string PodName { get; set; }
        public string AssignedToFranchisee { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> AssignedTerritories { get; set; }
        public IEnumerable<OrderedPair<string, string>> PodStaff { get; set; }
    }
    
    public class PodListModel : ViewModelBase
    {
        public IEnumerable<PodBasicModel> Pods { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}