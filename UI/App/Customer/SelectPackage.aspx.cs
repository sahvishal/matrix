using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using System.Web.Services;

namespace Falcon.App.UI.App.Customer
{
    public partial class SelectPackage : Page
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

        protected decimal MinimumPurchaseAmount
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToDecimal(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.MinimumPurchaseAmount));
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
            set
            {
                RegistrationFlow.TestIds = value;
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
            set
            {
                RegistrationFlow.AddOnTestIds = value;
            }
        }

        private long PackageId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PackageId : 0;
            }
            set
            {
                RegistrationFlow.PackageId = value;
            }
        }

        private decimal PackageCost
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.PackageCost : 0;
            }
            set
            {
                RegistrationFlow.PackageCost = value;
            }
        }

        protected long? EventId
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
            set
            {
                RegistrationFlow.SourceCode = value;
            }
        }

        private long SourceCodeId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.SourceCodeId : 0;
            }
            set
            {
                RegistrationFlow.SourceCodeId = value;
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

        private decimal TotalAmount
        {
            set { RegistrationFlow.TotalAmount = value; }
        }

        protected long? CustomerId
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
        
        protected bool EnableAlaCarte { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Place Order";
            var objmaster = (Customer_CustomerMaster)Master;
            objmaster.SetBreadcrumb = "<a href=\"/App/Customer/HomePage.aspx\">Home</a>";
            objmaster.SetPageView("EventRegistration");
            if (!IsPostBack)
            {
                if (EventId.HasValue)
                {
                    // Hack: This is  done if the user hits back button on payment page, to get back to select package page.
                    if (SourceCodeId > 0 && !string.IsNullOrEmpty(SourceCode))
                        txtCouponCode.Text = SourceCode;
                }
                else
                {
                    errordiv.InnerHtml = "Sorrry, Event detail not found. <a href =SearchEvent.aspx>Click </a> here to search event again ";
                    errordiv.Visible = true;
                }
                ItemCartControl.EventId = EventId.Value;
                ItemCartControl.RoleId = (long)Roles.Customer;
                ItemCartControl.PackageId = PackageId;
                ItemCartControl.TestIds = TestIds;
                
            }
            if (EventId.HasValue && EventId.Value > 0)
            {
                var eventRepository = IoC.Resolve<IEventRepository>();
                var theEvent = eventRepository.GetById(EventId.Value);
                if (theEvent != null)
                {
                    var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
                    EnableAlaCarte = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));
                    if (EnableAlaCarte)
                        EnableAlaCarte = theEvent.EnableAlaCarteOnline;
                }
            }

            if (Request.Params["__EVENTTARGET"] == "NextButton" && Request.Params["__EVENTARGUMENT"] == "Click")
                NextButtonClick();
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.RedirectUser("SearchEvent.aspx?guid=" + GuId);
        }

        private void NextButtonClick()
        {
            if (Customer == null) return;

            if (!EventValidation()) return;

            SetPackageData();
            if (!string.IsNullOrEmpty(txtCouponCode.Text))
                SetSourceCodeData();
            else
            {
                SourceCodeId = 0;
                SourceCode = string.Empty;
                SourceCodeAmount = decimal.Zero;
            }

            TotalAmount = PackageCost - SourceCodeAmount;
            Response.RedirectUser("SelectAppointment.aspx?guid=" + GuId);
        }

        [WebMethod (EnableSession = true)]
        public static SourceCodeApplyEditModel GetCoupon(long packageId, string addOnTestIds, decimal orderTotal, string couponCode, long eventId, long customerId)
        {
            var testIds = new List<long>();
            if (!string.IsNullOrEmpty(addOnTestIds))
                addOnTestIds.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, couponCode, eventId, customerId, SignUpMode.CustomerPortal);
            return model;
        }

        protected string GetTestName(string packageId)
        {
            ITestRepository testRepository = new TestRepository();
            return testRepository.GetTestNamesByPackageId(Convert.ToInt64(packageId));
        }

        public void SetName(object sender, EventArgs e)
        {
            //spFullName.InnerHtml = uc1.CustName;

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

        private void SetPackageData()
        {
            var currentPackageId = Convert.ToInt64(PackageIdHiddenControl.Value);
            var testIds = new List<long>();
            TestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));
            TestIds = testIds;

            PackageCost = Decimal.Parse(hfPackageCost.Value);

            var addOnTestIds = new List<long>();
            IndependentTestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => addOnTestIds.Add(Convert.ToInt64(t)));
            addOnTestIds.RemoveAll(t => t == 0);

            var isOrderChanged = currentPackageId != PackageId || (AddOnTestIds != null && (!addOnTestIds.All(AddOnTestIds.Contains) || !AddOnTestIds.All(addOnTestIds.Contains)));
            PackageId = currentPackageId;
            AddOnTestIds = addOnTestIds;

            var eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();
            var screeningTime = eventPackageSelectorService.GetScreeningTime(EventId.Value, PackageId, AddOnTestIds);
            if (!RegistrationFlow.AppointmentSlotIds.IsNullOrEmpty() && isOrderChanged)
            {
                var eventSchedulingSlotService = IoC.Resolve<IEventSchedulingSlotService>();

                var theEvent = IoC.Resolve<IEventRepository>().GetById(EventId.Value);

                var slots = eventSchedulingSlotService.AdjustAppointmentSlot(EventId.Value, screeningTime, RegistrationFlow.AppointmentSlotIds, PackageId, AddOnTestIds, theEvent.LunchStartTime, theEvent.LunchDuration);
                RegistrationFlow.AppointmentSlotIds = slots.IsNullOrEmpty() ? null : slots.Select(s => s.Id).ToArray();
            }
            RegistrationFlow.ScreeningTime = screeningTime;

            var eligibilityService = IoC.Resolve<IEligibilityService>();
            RegistrationFlow.IsTestCoveredByInsurance = eligibilityService.CheckTestCoveredByinsurance(EventId.Value, PackageId, AddOnTestIds);

            if (!RegistrationFlow.IsTestCoveredByInsurance)
                RegistrationFlow.EligibilityId = 0;
        }

        private void SetSourceCodeData()
        {
            var testIds = new List<long>();
            IndependentTestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(PackageId, testIds, PackageCost, txtCouponCode.Text, EventId.HasValue?EventId.Value:0, CustomerId.HasValue?CustomerId.Value:0, SignUpMode.CustomerPortal);
            if (model.SourceCodeId < 1 && model.FeedbackMessage != null)
            {
                SourceCodeId = 0;
                SourceCode = string.Empty;
                SourceCodeAmount = decimal.Zero;

            }
            else
            {
                hfCouponCode.Value = model.SourceCode;
                hfTotalAmount.Value = model.DiscountApplied.ToString("0.00");
                SourceCodeId = model.SourceCodeId;
                SourceCode = model.SourceCode;
                SourceCodeAmount = model.DiscountApplied;
            }
        }

        private void SetAndDisplayErrorMessage(string errorMessage)
        {
            errordiv.InnerHtml = errorMessage;
            errordiv.Visible = true;
        }
    }
}