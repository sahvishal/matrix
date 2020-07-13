
using Falcon.App.Core.Domain.MedicalVendors;
using System.Collections.Generic;
namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerPrimaryCarePhysicianRepository
    {
        EventCustomerPrimaryCarePhysician Save(EventCustomerPrimaryCarePhysician domain);
        IEnumerable<EventCustomerPrimaryCarePhysician> GetEventCustomerPrimaryCarePhysicianByIds(IEnumerable<long> eventCustomerIds);
    }
}
