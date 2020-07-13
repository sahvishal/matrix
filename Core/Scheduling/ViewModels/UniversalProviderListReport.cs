using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class UniversalProviderListReport : ListModelBase<UniversalProviderViewModel, UniversalProviderListModelFilter>
    {
        public override IEnumerable<UniversalProviderViewModel> Collection
        {
            get;
            set;
        }

        public override UniversalProviderListModelFilter Filter
        {
            get;
            set;
        }
    }
}