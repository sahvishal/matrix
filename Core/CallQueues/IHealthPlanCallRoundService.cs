using System;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCallRoundService
    {
        void SaveCallRoundCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger);
        void SaveNoShowCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger);
        void SaveHealthPlanFillEventCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger);

        void SaveHealthPlanUncontactedCustomerCallQueue(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger);
        void SaveHealthPlanZipRadiusCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger);

        void SaveMailRoundCallQueueCustomers(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger, Campaign campaign);

        void SaveHealthPlanLanguageBarrierCustomerCallQueue(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger);

        void SaveHealthPlanConfirmationCustomerCallQueue(CorporateAccount corporateAccount, HealthPlanCallQueueCriteria queueCriteria, CallQueue callQueue, ILogger logger);
    }
}