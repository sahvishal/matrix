using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PreQualifiedQuestionTemplateEditModel : ViewModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long TestId { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public PreQualifiedQuestionEditModel[] Questions { get; set; }
        public IEnumerable<long> DependentTestIds { get; set; }
    }
}
