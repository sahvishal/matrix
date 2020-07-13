using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Lib;
using Falcon.App.Core.Extensions;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class EventCustomerInformation : UserControl
    {
        private readonly IEventCustomerRegistrationViewDataRepository _eventCustomerRegistrationViewDataRepository =
                    new EventCustomerRegistrationViewDataRepository();

        private readonly IShippingDetailRepository _shippingDetailRepository = new ShippingDetailRepository();

        public long? EventCustomerId
        {
            get
            {
                if (ViewState["EventCustomerId"] != null && !string.IsNullOrEmpty(ViewState["EventCustomerId"].ToString()))
                {
                    long eventCustomerId;
                    if (Int64.TryParse(ViewState["EventCustomerId"].ToString(), out eventCustomerId))
                    {
                        return eventCustomerId;
                    }
                }
                return null;
            }
            set
            {
                ViewState["EventCustomerId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && EventCustomerId.HasValue)
                LoadEventInformation();
        }

        private void LoadEventInformation()
        {
            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
            var eventCustomer = eventCustomerRepository.GetById(EventCustomerId.Value);

            var eventService = IoC.Resolve<IEventService>();
            var eventBasicInfoViewModel = eventService.GetEventBasicInfoFor(eventCustomer.EventId);

            EventNameLabel.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(eventBasicInfoViewModel.HostName + " On: " +
                                  eventBasicInfoViewModel.EventDate.ToShortDateString() + " At: " +
                                  CommonCode.AddressSingleLine(eventBasicInfoViewModel.HostAddress.StreetAddressLine1,
                                                               eventBasicInfoViewModel.HostAddress.StreetAddressLine2,
                                                               eventBasicInfoViewModel.HostAddress.City,
                                                               eventBasicInfoViewModel.HostAddress.State,
                                                               eventBasicInfoViewModel.HostAddress.ZipCode), true);
            EventIdLabel.Text = eventCustomer.EventId.ToString();
            EventStatusLabel.Text = eventBasicInfoViewModel.Status.ToString();

            if (eventCustomer.AppointmentId.HasValue)
            {
                var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                var appointment = appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

                AppointmentTimeLabel.Text = appointment.StartTime.ToShortTimeString() + " On: " +
                                        eventBasicInfoViewModel.EventDate.ToShortDateString();
            }
            

            try
            {
                IOrderController orderController = new OrderController();
                var orderRepository = IoC.Resolve<IOrderRepository>();
                var order = orderRepository.GetOrder(eventCustomer.CustomerId, eventCustomer.EventId);

                PackageCostLabel.Text = order.OrderDetails.Where(od =>
                                (od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted) ||
                                (od.DetailType == OrderItemType.EventTestItem && od.IsCompleted))
                            .Sum(od => od.Price).ToString("C2");

                var totalAmount = order.DiscountedTotal.ToString("0.00");
                var amountPaid = order.TotalAmountPaid.ToString("0.00");
                var amountDue = (order.DiscountedTotal - order.TotalAmountPaid).ToString("0.00");

                var activeOrderDetail = orderController.GetActiveOrderDetail(order.Id);
                 
                var shippingDetails = _shippingDetailRepository.GetShippingDetailsForOrder(activeOrderDetail.Id);

                var orderId = order.Id;

                var orgRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();

                var idNamePairs = orgRoleUserRepository.GetNameIdPairofUsers(new[] {eventCustomer.CustomerId});
                var customerName = idNamePairs.First().SecondValue;
                var customerId = eventCustomer.CustomerId;

                if (!shippingDetails.IsNullOrEmpty())
                {
                    foreach (var shippingOption in shippingDetails)
                    {
                        if (shippingOption != null)
                            ShippingOptionLabel.Text += shippingOption.ShippingOption.Name + "<br />";
                    }
                    ShippingOptionLabel.Text.Remove(ShippingOptionLabel.Text.LastIndexOf("<br />"));
                }
                // set order details tooltip.
                customerName = customerName.Replace("'", "\\'");
                customerName = customerName.Replace("\"", "\\\"");
                var functionToCall = "javascript:return ShowOrderDetailPopUp(" +
                                         HttpUtility.HtmlEncode(orderId) + "," + HttpUtility.HtmlEncode(totalAmount) + "," + HttpUtility.HtmlEncode(amountPaid) + "," +
                                         HttpUtility.HtmlEncode(amountDue) + ",'" + HttpUtility.HtmlEncode(customerName) + "'," +
                                         HttpUtility.HtmlEncode(customerId) + ");";
                _orderLinkAnchor.Attributes.Add("onClick", functionToCall);
            }
            catch
            {
                ShippingOptionLabel.Text = string.Empty;
            }
        }
    }
}