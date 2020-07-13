using System;
using System.Web.Http;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;

namespace API.Areas.Scheduling.Controllers
{
    public class OrderController : ApiController
    {
        private readonly ICustomerOrderBuilderService _orderBuilderService;
        private readonly IUpdateCustomerPackageService _updateCustomerPackageService;
        private readonly ILogger _logger;
        public OrderController(ICustomerOrderBuilderService orderBuilderService, IUpdateCustomerPackageService updateCustomerPackageService, ILogManager logManager)
        {
            _orderBuilderService = orderBuilderService;
            _updateCustomerPackageService = updateCustomerPackageService;
            _logger = logManager.GetLogger<OrderController>();
        }

        [HttpGet]
        public CustomerOrderDetail Get([FromUri]long customerId, [FromUri]long eventId)
        {
            CustomerOrderDetail model;
            try
            {
                model = _orderBuilderService.GetCustomerOrderDetails(customerId, eventId);
                model.IsSuccess = true;
            }
            catch (Exception exception)
            {
                model = new CustomerOrderDetail();
                _logger.Error(string.Format("While getting order for customerid ={0} and EverntId= {1} Exception Message {2} \n stack trace {3}", customerId, eventId, exception.Message, exception.StackTrace));
            }

            return model;
        }

        [HttpGet]
        public EventPackageTestModel GetEventPackageTestModel([FromUri] long eventId)
        {
            var model = new EventPackageTestModel { IsSuccess = false };
            try
            {
                model = _orderBuilderService.GetEventPackageTestModel(eventId);
                model.IsSuccess = true;
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("while getting list of avilable pacakges and test for Event {0} get Exection \n\t [Message : {1}] \n\t\t StackTrace {2} ", eventId, exception.Message, exception.StackTrace));

            }
            return model;
        }


        [HttpPost]
        public ResponseBaseModel Post([FromBody]CustomerOrderDetail orderDetail)
        {
            var model = new ResponseBaseModel { IsSuccess = false };

            try
            {
                _updateCustomerPackageService.ChangePackage(orderDetail);
                model.Message = "Successfully updated";
                model.IsSuccess = true;

            }
            catch (InvalidAddressException exception)
            {
                _logger.Error("Invalid Address or Email Address", exception);
                model.Message = exception.Message;
            }
            catch (DuplicateObjectException<ZipCode> exception)
            {
                _logger.Error("Zip code Error", exception);
                model.Message = "Zip code has some problem";
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("While saving order for customerid ={0} and EverntId= {1} Exception Message {2} \n stack trace {3}", orderDetail.CustomerId, orderDetail.EventId, exception.Message, exception.StackTrace));
                model.Message = exception.Message;
            }

            return model;
        }
    }
}
