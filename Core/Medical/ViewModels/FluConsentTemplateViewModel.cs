using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class FluConsentTemplateViewModel : ViewModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string HealthPlan { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
    }
}