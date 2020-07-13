using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerCustomerEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long HospitalPartnerCustomerId { get; set; }

        [UIHint("Hidden")]
        public long EventId { get; set; }

        [UIHint("Hidden")]
        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        [DisplayName("Status")]
        public int Status { get; set; }

        [DisplayName("Outcome")]
        public int Outcome { get; set; }

        [DisplayName("Physician Name")]
        public string PrimaryCarePhysicianName { get; set; }

        [DisplayName("Notes")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [UIHint("Hidden")]
        public long CareCoordinatorOrgRoleUserId { get; set; }

        [UIHint("Hidden")]
        public long CreatedByOrgRoleUserId { get; set; }

        [UIHint("Hidden")]
        public DateTime DateCreated { get; set; }

    }
}
