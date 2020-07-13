using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Operations
{
    public interface IPcpShippingService
    {
        bool AddPcpProductShipping(long customerId, long eventId);
        MediaLocation PrintEventCustomerPcpAppointmentForm(long eventId, long customerId, string fileName);
        void AddShippingForPcp(long customerId, long eventId, PrimaryCarePhysician pcp);
    }
}