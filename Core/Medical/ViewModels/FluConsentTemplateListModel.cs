using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class FluConsentTemplateListModel
    {
        public IEnumerable<FluConsentTemplateViewModel> Collection { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
        public FluConsentTemplateModelFilter Filter { get; set; }
    }
}