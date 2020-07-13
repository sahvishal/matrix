using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PackageListModel
    {
        public IEnumerable<PackageViewModel> Packages { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public PackageListModelFilter Filter { get; set; }
    }
}