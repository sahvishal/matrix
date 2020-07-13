using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class PreQualifiedQuestionTemplateModelFilter
    {
        public string Name { get; set; }
        public long TestId { get; set; }
    }
}
