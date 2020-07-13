using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Marketing.Impl;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class SourceCodeListModel
    {
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public IEnumerable<SourceCodeViewModel> SourceCodes { get; set; }
        public SourceCodeListModelFilter Filter { get; set; }
    }
}