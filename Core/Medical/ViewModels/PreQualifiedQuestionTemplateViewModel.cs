
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PreQualifiedQuestionTemplateViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TestName { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public string DependentTests { get; set; }
    }
}
