using System.Web.Http;
using Falcon.App.Core.Finance.ViewModels;

namespace API.Areas.Finance.Controllers
{
    public class OrderController:ApiController
    {
        public OrderController()
        {

        }

        [HttpPost]
        public CustomerOrderViewModel GetOrderSummary(long customerId,long eventId)
        {
            return null;
           
        }
    }
}