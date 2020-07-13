using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Infrastructure.Finance.Impl;

namespace API.Areas.Finance.Controllers
{
    public class CustomerOrderController : BaseController
    {
        private readonly OrderSummaryService _orderSummaryService;

        public CustomerOrderController(OrderSummaryService  orderSummaryService)
        {
            _orderSummaryService = orderSummaryService;
        }

        [HttpGet]
        public CustomerOrderViewModel GetOrderSummary(long customerId,long eventId)
        {
            return _orderSummaryService.GetOrderSummary(customerId, eventId); 
        }
    }
}