namespace Falcon.App.Core.Medical.ViewModels
{
    public class ClinicalTestQualificationViewModel
    {
        public long TestId { get; set; }
        public string Name { get; set; }
        public bool IsDisqualified { get; set; }

        public ClinicalTestQualificationViewModel()
        {
            
        }
        public ClinicalTestQualificationViewModel(long id, string name, bool isDisqualified)
        {
            TestId = id;
            Name = name;
            IsDisqualified = isDisqualified;
        }
    }
}