using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class SurveyTemplateListModel
    {

        public IEnumerable<SurveyTemplateViewModel> Templates { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public SurveyTemplateModelFilter Filter { get; set; }
    }
}
