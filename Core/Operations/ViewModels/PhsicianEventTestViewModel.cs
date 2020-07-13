using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Operations.ViewModels
{
    [NoValidationRequired]
    public class PhsicianEventTestViewModel
    {
        public long TestId { get; set; }
        public bool IsSelected { get; set; }
        public long PhysicianId { get; set; }
    }
}