
namespace Falcon.App.Core.Medical.ViewModels
{
    public class SurveyTemplateViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string HealthPlan { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        //public string Type { get; set; }
    }
}
