namespace Falcon.App.Core.CallQueues
{
    public interface IUncontactedCustomersRegeneratePollingAgent
    {
        void PollForRegenerateUncontactedCustomer();
    }
}