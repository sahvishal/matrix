using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ResultArchiveUploadLogViewModel
    {
        public long Id { get; set; }
        public long ResultArchiveId { get; set; }
        public TestType TestId { get; set; }
        public string TestName { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string MedicalEquipmentTag { get; set; }
        public bool IsSuccessful { get; set; }
        public string Notes { get; set; }
    }
}