using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class ClinicalTemplateEditModel
    {
        public long TemplateId { get; set; }
        public bool OpenNextTab { get; set; }
    }
}