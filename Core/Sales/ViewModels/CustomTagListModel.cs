using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CustomTagListModel
    {
        public IEnumerable<CustomTagViewModel> Collection { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }

        public CustomTagListModelFilter Filter { get; set; }
    }
}
