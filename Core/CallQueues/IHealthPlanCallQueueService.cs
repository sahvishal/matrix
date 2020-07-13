using System;
using System.Collections.Generic;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCallQueueService
    {
        IEnumerable<HealthPlanDropDownView> GetHealthPlanDropdownList(long angentOrganizationId);
        IEnumerable<CallQueueCategoryViewModel> GetHealthPlanCallQueueDropDownList();
    }
}
