using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.Scheduling.Services
{
    [DefaultImplementation]
    public class CustomerBarrierService : ICustomerBarrierService
    {
        private readonly IBarrierRepository _barrierRepository;
        public CustomerBarrierService(IBarrierRepository barrierRepository)
        {
            _barrierRepository = barrierRepository;
        }
        public BarrierEditModel GetCustomerBarrier(long eventCustomerId)
        {
            var customerBarrier = _barrierRepository.GetCustomerBarrierByEventCustomerId(eventCustomerId);
            var model = new BarrierEditModel();
            if (customerBarrier != null)
            {
                model.EventCustomerId = customerBarrier.EventCustomerId;
                model.BarrierId = customerBarrier.BarrierId;
                model.Reason = customerBarrier.Reason;
                model.Resolution = customerBarrier.Resolution;
            }
            return model;
        }

        public void Save(BarrierEditModel model)
        {
            _barrierRepository.Save(GetEventCustomerBarrier(model));
        }
        private EventCustomerBarrier GetEventCustomerBarrier(BarrierEditModel model)
        {
            return new EventCustomerBarrier 
            {
                BarrierId=model.BarrierId, 
                EventCustomerId=model.EventCustomerId,
                Reason=model.Reason, 
                Resolution = model.Resolution 
            };
        }
        
    }
}
