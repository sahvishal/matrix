using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.ViewModels
{
    public abstract class ListModelBase<T, N> : ViewModelBase
        where T : ViewModelBase
        where N : ModelFilterBase
    {
        public abstract IEnumerable<T> Collection { get; set; }
        public abstract N Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }

    }
}
