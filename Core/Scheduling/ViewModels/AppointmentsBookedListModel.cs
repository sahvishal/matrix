using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class AppointmentsBookedListModel : ListModelBase<AppointmentsBookedModel, AppointmentsBookedListModelFilter>
    {
        public override IEnumerable<AppointmentsBookedModel> Collection { get; set; }
        public decimal TotalCost
        {
            get
            {
                if (!Collection.IsNullOrEmpty())
                {
                    return Collection.Sum(a => a.TotalAmount);
                }
                return 0;
            }
        }

        public override AppointmentsBookedListModelFilter Filter { get; set; }
    }
}