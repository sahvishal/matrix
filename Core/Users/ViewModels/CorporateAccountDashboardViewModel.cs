using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CorporateAccountDashboardViewModel
    {
        public IEnumerable<ClientEventVolumeModel> UpcomingEvents { get; set; }

        public CorporateAccountMemberStatusViewModel MemberStatus { get; set; }

        public IEnumerable<CorporateAccountDashboardCriticalResults> CriticalUrgentResult { get; set; }
    }
}