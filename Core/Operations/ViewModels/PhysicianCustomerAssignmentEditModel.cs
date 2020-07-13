using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class PhysicianCustomerAssignmentEditModel:ViewModelBase
    {
        public long EventCustomerId { get; set; }

        [DisplayName("Physician")]
        public long PhysicianId { get; set; }

        [DisplayName("Over Read Physician")]
        public long? OverReadPhysicianId { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        public IEnumerable<AssignedPhysicianBasicInfoModel> AssignedPhysicians { get; set; }
    }
}
