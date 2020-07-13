using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Operations.Impl;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Extensions;

namespace Falcon.App.UI.App.Customer
{
    public partial class SelectAppointment : Page
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
        }

        private RegistrationFlowModel RegistrationFlow
        {
            get
            {
                if (!string.IsNullOrEmpty(GuId))
                {
                    return Session[GuId] as RegistrationFlowModel;
                }
                return null;
            }
        }

        private List<long> TestIds
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.TestIds != null)
                {
                    return RegistrationFlow.TestIds.ToList();
                }
                return null;
            }
        }

        private List<long> AddOnTestIds
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.AddOnTestIds != null)
                {
                    return RegistrationFlow.AddOnTestIds.ToList();
                }
                return null;
            }
        }

        private long PackageId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PackageId : 0;
            }
        }

        private long? ProductId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ProductId > 0)
                    return RegistrationFlow.ProductId;
                return null;
            }
            set
            {
                RegistrationFlow.ProductId = value.HasValue ? value.Value : 0;
            }
        }

        private decimal PackageCost
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PackageCost : 0;
            }
        }

        private IEnumerable<long> AppointmentSlotIds
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.AppointmentSlotIds : null;
            }
            set { RegistrationFlow.AppointmentSlotIds = value; }
        }

        private long? EventId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.EventId > 0)
                    return RegistrationFlow.EventId;
                return null;
            }
        }

        private string SourceCode
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCode : string.Empty;
            }
        }

        private long SourceCodeId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCodeId : 0;
            }
        }

        private decimal SourceCodeAmount
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCodeAmount : 0;
            }
            set { RegistrationFlow.SourceCodeAmount = value; }
        }

        protected ShippingDetail ShippingDetail
        {
            get
            {
                if (ShippingOptionId.HasValue && ShippingAddressId.HasValue)
                {

                    var shippingDetail = GetShippingDetailData(ShippingOptionId.Value, ShippingAddressId.Value);
                    if (RegistrationFlow != null)
                        shippingDetail.Id = RegistrationFlow.ShippingDetailId;
                    return shippingDetail;
                }
                return null;
            }
            set
            {
                RegistrationFlow.ShippingDetailId = value.Id;
            }
        }

        protected decimal TotalAmount
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.TotalAmount : 0;
            }
            set { RegistrationFlow.TotalAmount = value; }
        }

        private long? CustomerId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CustomerId > 0)
                    return RegistrationFlow.CustomerId;
                return null;
            }
        }

        private Core.Users.Domain.Customer _customer;

        private Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    if (!CustomerId.HasValue)
                        return null;
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId.Value);
                }
                return _customer;
            }
        }

        private string MarketingSource
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.MarketingSource : string.Empty;
            }
        }

        private long? ShippingOptionId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingOptionId > 0)
                    return RegistrationFlow.ShippingOptionId;
                return null;
            }
            set
            {
                RegistrationFlow.ShippingOptionId = value.HasValue ? value.Value : 0;
            }
        }

        private long? ShippingAddressId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingAddressId > 0)
                    return RegistrationFlow.ShippingAddressId;
                return null;
            }
            set
            {
                RegistrationFlow.ShippingAddressId = value.HasValue ? value.Value : 0;
            }
        }

        protected EventType EventType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Event eventData = null;
            if (EventId.HasValue)
            {
                ProductOption.EventId = EventId.Value;
                OrderSummaryControl.EventId = EventId.Value;
                OrderSummaryControl.RoleId = (long)Roles.Customer;
                OrderSummaryControl.PackageId = PackageId;
                OrderSummaryControl.TestIds = TestIds;
                OrderSummaryControl.IsSourceCodeApplied = SourceCodeId > 0;
                OrderSummaryControl.SourceCodeAmount = SourceCodeAmount;
                var eventRepository = IoC.Resolve<IEventRepository>();
                eventData = eventRepository.GetById(EventId.Value);
                EventType = eventData.EventType;
            }
            Page.Title = "Select Appointment And Fullfillment Option";
            var objmaster = (Customer_CustomerMaster)Master;
            objmaster.SetBreadcrumb = "<a href=\"/App/Customer/HomePage.aspx\">Home</a>";
            objmaster.SetPageView("EventRegistration");

            if (eventData != null && eventData.EventType == EventType.Retail)
                ResultOtion.ShowFreeOption = false;
            else if (eventData != null && eventData.EventType == EventType.Corporate)
            {
                ResultOtion.EventType = EventType.Corporate;
                ResultOtion.AccountId = eventData.AccountId.HasValue ? eventData.AccountId.Value : 0;
            }
            _ucEventAppointment1.PackageId = PackageId;
            _ucEventAppointment1.TestIds = AddOnTestIds.IsNullOrEmpty() ? "" : string.Join(",", AddOnTestIds);
            if (!IsPostBack)
            {
                TotalAmount = PackageCost - SourceCodeAmount;
                if (EventId.HasValue)
                {
                    _ucEventAppointment1.EventId = EventId;
                    _ucEventAppointment1.CurrentViewType = ViewType.CustomerPortal;
                    _ucEventAppointment1.SetAppointmentIds(AppointmentSlotIds);
                    _ucEventAppointment1.ScreeningTime = RegistrationFlow.ScreeningTime;
                }
                else
                {
                    ErrorDiv.InnerHtml = "Sorrry, Event detail not found. <a href =SearchEvent.aspx>Click </a> here to search event again ";
                    ErrorDiv.Visible = true;
                }
            }
            else
            {
                if (Request.Params["__EVENTTARGET"] == "NextButton" && Request.Params["__EVENTARGUMENT"] == "Click")
                    NextButtonClick();
            }
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            AppointmentSlotIds = _ucEventAppointment1.GetAppointmentIds();
            Response.RedirectUser("SelectPackage.aspx?guid=" + GuId);
        }

        private void NextButtonClick()
        {
            AppointmentSlotIds = _ucEventAppointment1.GetAppointmentIds();

            if (Customer == null) return;

            if (!EventValidation()) return;

            if (!AppointmentValidation()) return;

            SetShippingDetailData();
            SetProductDetail();
            var orderTotal = PackageCost + (ProductId.HasValue && ProductId.Value > 0 ? ProductOption.ProductPrice : 0m) +
                             (ShippingDetail != null ? ShippingDetail.ActualPrice : 0m);

            if (!string.IsNullOrEmpty(SourceCode))
                SetSourceCodeData(orderTotal);

            TotalAmount = orderTotal - SourceCodeAmount;
            if (TotalAmount == 0.00m)
            {

                bool eventRegistrationSuccessful = false;
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        eventRegistrationSuccessful = PaymentViaSourceCode();
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + HttpUtility.HtmlEncode(ex.Message));
                    eventRegistrationSuccessful = false;
                }
                if (eventRegistrationSuccessful)
                {
                    UpdateProspectCustomer(CustomerId.Value);

                    if (RegistrationFlow != null)
                    {
                        RegistrationFlow.SourceCodeId = 0;
                        RegistrationFlow.SourceCode = string.Empty;
                        RegistrationFlow.SourceCodeAmount = 0;
                        RegistrationFlow.ProductId = 0;
                        RegistrationFlow.ShippingDetailId = 0;
                        RegistrationFlow.ShippingOptionId = 0;
                        RegistrationFlow.ShippingAddressId = 0;
                        RegistrationFlow.AppointmentSlotIds = null;
                        RegistrationFlow.PackageId = 0;
                        RegistrationFlow.TestIds = null;
                    }
                    Response.RedirectUser("ConfirmationReciept.aspx?guid=" + GuId);
                }
            }
            else
            {
                Response.RedirectUser("Payment.aspx?guid=" + GuId);
            }
        }

        private void SetProductDetail()
        {
            if (ProductOption.IsProductSelected && ProductOption.ProductId > 0)
                ProductId = ProductOption.ProductId;
            else
                ProductId = null;
        }

        public void SetName(object sender, EventArgs e)
        { }

        private void SetAndDisplayErrorMessage(string errorMessage)
        {
            ErrorDiv.InnerHtml = errorMessage;
            ErrorDiv.Visible = true;
        }

        private bool EventValidation()
        {
            if (PackageRegistrationValidators.EventValidation(Customer.CustomerId, EventId.Value))
            {
                IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository =
                new EventCustomerRegistrationViewDataRepository();

                var data =
                    eventCustomerRegistrationViewDataRepository.GetEventCustomerOrders(Customer.CustomerId, EventId.Value);

                //check dulicate event registration
                if (data != null)
                {
                    var packageAndTest = data.PackageName;
                    packageAndTest = string.IsNullOrEmpty(packageAndTest)
                                         ? data.AdditinalTest
                                         : packageAndTest +
                                           (string.IsNullOrEmpty(data.AdditinalTest)
                                                ? string.Empty
                                                : ", " + data.AdditinalTest);

                    var message = HttpUtility.HtmlEncode(Customer.Name.FirstName) + " " + HttpUtility.HtmlEncode(Customer.Name.MiddleName) + " " +
                                  HttpUtility.HtmlEncode(Customer.Name.LastName) + " is already registered for this event (" +
                                  HttpUtility.HtmlEncode(data.EventName) + " ) at " +
                                  HttpUtility.HtmlEncode(data.EventDate.ToString("dddd dd MMMM yyyy")) + " " +
                                  HttpUtility.HtmlEncode(data.AppointmentStartTime.ToString("hh:mm tt")) + " for the " +
                                  HttpUtility.HtmlEncode(packageAndTest) +
                                  ". Duplicate registrations for the same customer are not allowed.";
                    SetAndDisplayErrorMessage(message);
                    return false;
                }
            }
            return true;
        }

        private bool AppointmentValidation()
        {
            //Check for duplicate appointment slot
            var slotService = IoC.Resolve<IEventSchedulingSlotService>();
            if (slotService.IsSlotBooked(AppointmentSlotIds))
            {
                AppointmentSlotIds = null;
                const string message =
                     "This appointment slot has already been selected. Please choose another appointment slot.";

                SetAndDisplayErrorMessage(message);
                return false;
            }
            return true;
        }

        //TODO: SRE
        private void SetShippingDetailData()
        {
            if (Convert.ToInt64(hfResultOrderID.Value) > 0)
            {
                ShippingOptionId = Convert.ToInt64(hfResultOrderID.Value);
                var shippingAddress = ResultOtion.SaveShippingAddress();
                if (shippingAddress != null)
                    ShippingAddressId = shippingAddress.Id;
                else
                    return;
            }
            else
            {
                ShippingAddressId = null;
                ShippingOptionId = null;
            }
        }

        private bool PaymentViaSourceCode()
        {
            var organizationRoleUser = GetOrganizationRoleUser();

            var orderables = new List<IOrderable>();
            var packageTestIds = new List<long>();
            if (PackageId > 0)
            {
                var packageRepository = IoC.Resolve<IEventPackageRepository>();
                var package = packageRepository.GetByEventAndPackageIds(EventId.Value, PackageId);
                if (package != null)
                    packageTestIds = package.Tests.Select(t => t.Test.Id).ToList();

                orderables.Add(package);
            }

            var independentTestIds = !packageTestIds.IsNullOrEmpty() ? TestIds.Where(t => !packageTestIds.Contains(t)).Select(t => t).ToList() : TestIds;

            if (!independentTestIds.IsNullOrEmpty())
            {
                var eventTestRepository = IoC.Resolve<IEventTestRepository>();
                orderables.AddRange(eventTestRepository.GetByEventAndTestIds(EventId.Value, independentTestIds));
            }

            if (ProductId.HasValue && ProductId.Value > 0)
            {
                IUniqueItemRepository<ElectronicProduct> itemRepository = new ElectronicProductRepository();
                orderables.Add(itemRepository.GetById(ProductId.Value));
            }

            if (orderables.IsNullOrEmpty()) return false;

            Core.Finance.Domain.Order order = null;
            EventCustomer eventCustomer;
            try
            {
                order = GetOrder();
                if (order == null)
                    eventCustomer = SaveEventCustomer(organizationRoleUser);
                else
                    eventCustomer = UpdateEventCustomer(organizationRoleUser);
            }
            catch
            {
                eventCustomer = SaveEventCustomer(organizationRoleUser);
            }

            SourceCode sourceCode;
            if (SourceCodeId > 0)
                sourceCode = new SourceCode
                {
                    Id = SourceCodeId,
                    CouponCode = SourceCode,
                    CouponValue = SourceCodeAmount
                };
            else
                sourceCode = null;

            if (ShippingDetail != null)
            {
                IShippingController shippingController = new ShippingController();
                ShippingDetail = shippingController.OrderShipping(ShippingDetail);
            }

            IOrderController orderController = new OrderController();
            bool indentedLineItemsAdded = false;
            // TODO: applying hook to the system all the indented line items will be attached to the first order item.
            foreach (var orderable in orderables)
            {
                if (!indentedLineItemsAdded)
                {
                    orderController.AddItem(orderable, 1, organizationRoleUser.Id, organizationRoleUser.Id,
                                           sourceCode,
                                           eventCustomer, ShippingDetail, OrderStatusState.FinalSuccess);
                    indentedLineItemsAdded = true;
                }
                else
                    orderController.AddItem(orderable, 1, organizationRoleUser.Id, organizationRoleUser.Id,
                                            OrderStatusState.FinalSuccess);
            }

            if (order == null)
                order = orderController.PlaceOrder(OrderType.Retail, organizationRoleUser.Id);
            else
                order = orderController.ActivateOrder(order);

            SaveProductShippingDetail(order);
            return true;
        }

        private void SaveProductShippingDetail(Core.Finance.Domain.Order order)
        {
            if (ProductId.HasValue && ProductId.Value > 0)
            {
                var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
                var shippingOption = shippingOptionRepository.GetShippingOptionByProductId(ProductId.Value);

                if (shippingOption == null || ShippingDetail == null)
                    return;

                IOrderController orderController = new OrderController();
                OrderDetail orderDetail = orderController.GetActiveOrderDetail(order);

                if (shippingOption.Id == ShippingDetail.ShippingOption.Id)
                    return;
                var productShippingDetail = ShippingDetail;

                productShippingDetail.Id = 0;
                productShippingDetail.ShippingAddress.Id = 0;
                productShippingDetail.ShippingOption.Id = shippingOption.Id;
                productShippingDetail.ActualPrice = shippingOption.Price;

                if (orderDetail != null)
                {
                    IShippingController shippingController = new ShippingController();
                    productShippingDetail = shippingController.OrderShipping(productShippingDetail);

                    IRepository<ShippingDetailOrderDetail> shippingDetailOrderDetailRepository =
                        new ShippingDetailOrderDetailRepository();

                    var shippingDetailOrderDetail = new ShippingDetailOrderDetail
                    {
                        Amount = productShippingDetail.ActualPrice,
                        IsActive = true,
                        OrderDetailId = orderDetail.Id,
                        ShippingDetailId = productShippingDetail.Id
                    };

                    shippingDetailOrderDetailRepository.Save(shippingDetailOrderDetail);
                }

            }
        }

        private Core.Finance.Domain.Order GetOrder()
        {
            IOrderRepository orderRepository = new OrderRepository();

            return orderRepository.GetOrder(Customer.CustomerId, EventId.Value);
        }

        private ShippingDetail GetShippingDetailData(long shippingOptionId, long shippingAddressId)
        {
            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var addressRepository = IoC.Resolve<IAddressRepository>();

            var shippingDetail = new ShippingDetail
            {
                ShippingOption = new ShippingOption(),
                DataRecorderMetaData =
                    new DataRecorderMetaData
                    {
                        DataRecorderCreator =
                            organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                        ,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                Status = ShipmentStatus.Processing,
                ShippingAddress = addressRepository.GetAddress(shippingAddressId)
            };
            var shippingOptionRepository = IoC.Resolve<IShippingOptionRepository>();
            var shippingOption = shippingOptionRepository.GetById(shippingOptionId);
            shippingDetail.ShippingOption.Id = shippingOption.Id;
            shippingDetail.ActualPrice = shippingOption.Price;

            return shippingDetail;
        }

        private static OrganizationRoleUser GetOrganizationRoleUser()
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            return organizationRoleUserRepository.GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        private EventCustomer SaveEventCustomer(OrganizationRoleUser organizationRoleUser)
        {
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            var appointment = eventAppointmentService.CreateAppointment(AppointmentSlotIds, organizationRoleUser.Id);

            var eventCustomer = new EventCustomer
                                    {
                                        AppointmentId = appointment.Id,
                                        EventId = EventId.Value,
                                        CustomerId = CustomerId.Value,
                                        DataRecorderMetaData = new DataRecorderMetaData
                                                                   {
                                                                       DataRecorderCreator = organizationRoleUser,
                                                                       DateCreated = DateTime.Now
                                                                   },
                                        OnlinePayment = false,
                                        MarketingSource = MarketingSource,
                                        NoShow = false,
                                        LeftWithoutScreeningReasonId = null,
                                        LeftWithoutScreeningNotesId = null,
                                        TestConducted = false,
                                        HIPAAStatus = RegulatoryState.Unknown,
                                        PcpConsentStatus = RegulatoryState.Unknown,
                                        EnableTexting = Customer.EnableTexting,
                                        PreferredContactType = Customer.PreferredContactType,
                                    };

            IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
            eventCustomer = itemRepository.Save(eventCustomer);

            return eventCustomer;
        }

        private EventCustomer UpdateEventCustomer(OrganizationRoleUser organizationRoleUser)
        {
            IEventCustomerRepository eventCustomerRepository = new EventCustomerRepository();
            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
            try
            {
                var eventCustomer = eventCustomerRepository.GetCancelledEventForUser(Customer.CustomerId, EventId.Value);
                var appointment = eventAppointmentService.CreateAppointment(AppointmentSlotIds, organizationRoleUser.Id);
                eventCustomer.AppointmentId = appointment.Id;
                eventCustomer.NoShow = false;
                eventCustomer.LeftWithoutScreeningReasonId = null;
                eventCustomer.LeftWithoutScreeningNotesId = null;
                eventCustomer.EnableTexting = Customer.EnableTexting;
                IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
                eventCustomer = itemRepository.Save(eventCustomer);

                return eventCustomer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void SetSourceCodeData(decimal orderTotal)
        {
            var testIds = OrderSummaryControl.SelectedAddOnTests.Select(t => t.Id);
            var productAmount = ProductId.HasValue && ProductId.Value > 0 ? ProductOption.ProductPrice : 0m;
            var shippingAmount = ShippingDetail != null ? ShippingDetail.ActualPrice : 0m;
            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(PackageId, testIds, orderTotal, SourceCode, EventId.HasValue ? EventId.Value : 0, CustomerId.HasValue ? CustomerId.Value : 0, SignUpMode.CustomerPortal, shippingAmount, productAmount);

            if (model.SourceCodeId < 1 && model.FeedbackMessage != null)
                SourceCodeAmount = decimal.Zero;
            else
                SourceCodeAmount = model.DiscountApplied;
        }

        private void UpdateProspectCustomer(long customerId)
        {
            var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
            var prospectCustomer = ((IProspectCustomerRepository)prospectCustomerRepository).GetProspectCustomerByCustomerId(customerId);
            if (prospectCustomer != null)
            {
                prospectCustomer.CustomerId = customerId;
                prospectCustomer.IsConverted = true;
                prospectCustomer.ConvertedOnDate = DateTime.Now;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                prospectCustomer.TagUpdateDate = DateTime.Now;

                prospectCustomerRepository.Save(prospectCustomer);
            }
        }
    }
}
