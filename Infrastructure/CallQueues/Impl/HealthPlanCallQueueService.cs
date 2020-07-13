using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanCallQueueService : IHealthPlanCallQueueService
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallQueueRepository _callQueueRepository;

        public HealthPlanCallQueueService(ICorporateAccountRepository corporateAccountRepository, ICallQueueRepository callQueueRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _callQueueRepository = callQueueRepository;
        }

        public IEnumerable<HealthPlanDropDownView> GetHealthPlanDropdownList(long angentOrganizationId)
        {
            var healthPlans = _corporateAccountRepository.GetHealthPlanAssingedToAgent(angentOrganizationId);
            var healthPlanDropDownView = new List<HealthPlanDropDownView>();
            healthPlanDropDownView.Add(new HealthPlanDropDownView
            {
                HealthPlanName = "--- Select ---",
                Id = -1
            });
            if (!healthPlans.IsNullOrEmpty())
            {
                healthPlanDropDownView.AddRange(healthPlans.OrderBy(hp => hp.Name).Select(hp =>
                                    new HealthPlanDropDownView
                                    {
                                        CorporateTag = hp.Tag,
                                        HealthPlanName = hp.Name.ToString(),
                                        Id = hp.Id
                                    }));
            }

            return healthPlanDropDownView;
        }

        public IEnumerable<CallQueueCategoryViewModel> GetHealthPlanCallQueueDropDownList()
        {
            var callqueues = _callQueueRepository.GetAll(false, true);
            var callQueueCategory = new List<CallQueueCategoryViewModel>();
            callQueueCategory.Add(new CallQueueCategoryViewModel
            {
                Name = "--- Select ---",
                CallQueueId = -1
            });
            if (callqueues != null)
            {
                callQueueCategory.AddRange(callqueues.Select(x => new CallQueueCategoryViewModel { CallQueueId = x.Id, Name = x.Name, Category = x.Category, Description = x.Description }).OrderBy(s => s.CallQueueId));
            }

            return callQueueCategory;
        }
    }
}
