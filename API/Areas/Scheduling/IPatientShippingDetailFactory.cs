using API.Areas.Scheduling.Models;
using Falcon.App.Core.Operations.Domain;

namespace API.Areas.Scheduling
{
    public interface IPatientShippingDetailFactory
    {
        ShippingDetail GetShippingDetailData(CustomerOrderDetail customerOrderDetail);
    }
}
