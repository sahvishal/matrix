using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CheckListTemplateListModel
    {
        public IEnumerable<CheckListTemplateViewModel> Templates { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public CheckListTemplateModelFilter Filter { get; set; }
    }
}