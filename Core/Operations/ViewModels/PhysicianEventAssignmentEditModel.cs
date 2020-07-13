using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class PhysicianEventAssignmentEditModel : ViewModelBase
    {
        public long EventId { get; set; }

        [DisplayName("Physician")]
        public long PhysicianId { get; set; }

        [DisplayName("Over Read Physician")]
        public long? OverReadPhysicianId { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        public IEnumerable<AssignedPhysicianBasicInfoModel> AssignedPhysicians { get; set; }

        public bool IsEvaluationRestricted { get; set; }

        public IEnumerable<PhsicianEventTestViewModel> EventPhysicianTests { get; set; }

        public IEnumerable<Test> EventTests { get; set; }

    }
}
