using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class HealthPlanCriteriaTeamListEditModel : ViewModelBase
    {
      public  IEnumerable<HealthPlanCriteriaTeamEditModel> Collection { get; set; }
    }
}