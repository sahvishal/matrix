using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PreQualifiedQuestionTemplateListModel
    {
        public IEnumerable<PreQualifiedQuestionTemplateViewModel> Templates { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public PreQualifiedQuestionTemplateModelFilter Filter { get; set; }

    }
}
