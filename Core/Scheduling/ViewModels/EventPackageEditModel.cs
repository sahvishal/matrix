namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventPackageEditModel
    {
        public long PackageId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsSelectedByDefaultforEvent { get; set; }
        public int ScreeningTime { get; set; }
        public long? HealthAssessmentTemplateId { get; set; }
        public long Gender { get; set; }

        public bool IsRecommended { get; set; }

        public bool MostPopular { get; set; }
        public bool BestValue { get; set; }
    }
}
