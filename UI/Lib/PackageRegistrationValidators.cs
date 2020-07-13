using System;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.UI.Lib
{
    public class PackageRegistrationValidators
    {
        public static bool EventValidation(long customerId,long eventId)
        {
            IEventCustomerRepository eventCustomerRepository = new EventCustomerRepository();
            try
            {
                eventCustomerRepository.GetRegisteredEventForUser(customerId, eventId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
