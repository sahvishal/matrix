using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Users.ViewModels
{
    [NoValidationRequired]
    public class PhysicianLabTestModel
    {
        [UIHint("Hidden")]
        public long LabTestLicenseId { get; set; }

        [DisplayName("IFOBT License No")]
        public string IfobtLicenseNo { get; set; }

        [DisplayName("Microalbumine License No")]
        public string MicroalbumineLicenseNo { get; set; } 

        [UIHint("Hidden")]
        public DateTime DateCreated { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        public long StateId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }

    }
}