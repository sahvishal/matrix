using System;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueueCustomerDetailService
    {
        StartOutBoundCallViewModel GetCustomerContactViewModel(OutboundCallQueueFilter filter);
        StartOutBoundCallViewModel GetStartOutboundCallViewModel(OutboundCallQueueFilter filter, CallQueue callQueue);
        void DoNoShowCallQueueCustomerChanges(long eventCustomerId, bool isNoShow, DateTime? noShowDateTime);
    }
}
