using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class DeletePastEventCallQueueService : IDeletePastEventCallQueueService
    {
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository; 

        public DeletePastEventCallQueueService(ICallQueueCustomerRepository callQueueCustomerRepository)
        {
            _callQueueCustomerRepository = callQueueCustomerRepository; 
        }

        public void DeletePastEventCallQueue()
        {
            _callQueueCustomerRepository.DeletePastEventCallQueue();

        }
    }
}
