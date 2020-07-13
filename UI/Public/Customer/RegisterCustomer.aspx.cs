using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using System.Web.Services;

namespace Falcon.App.UI.Public.Customer
{
    public partial class RegisterCustomer : Page
    {
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
                if (Session["TestIds"] != null && Session["TestIds"] is List<long>)
                {
                    return Session["TestIds"] as List<long>;
                }
                return null;
            }
            set
            {
                Session["TestIds"] = value;
            }
        }

        private int? PackageId
        {
            get
            {
                if (Session["PackageID"] != null && !string.IsNullOrEmpty(Session["PackageID"].ToString()))
                {
                    int packageId;
                    if (Int32.TryParse(Session["PackageID"].ToString(), out packageId))
                        return packageId;
                }
                return null;
            }
        }

        private long? EventId
        {
            get
            {
                if (Session["EventID"] != null && !string.IsNullOrEmpty(Session["EventID"].ToString()))
                {
                    long eventId;
                    if (Int64.TryParse(Session["EventID"].ToString(), out eventId))
                        return eventId;
                }
                return null;
            }
        }

        private string SourceCode
        {
            get
            {
                if (Session["CouponCode"] != null && !string.IsNullOrEmpty(Session["CouponCode"].ToString()))
                {
                    return Session["CouponCode"].ToString();
                }
                return string.Empty;
            }
        }

        private long? SourceCodeId
        {
            get
            {
                if (Session["CouponID"] != null && !string.IsNullOrEmpty(Session["CouponID"].ToString()))
                {
                    long sourceCodeId;
                    if (Int64.TryParse(Session["CouponID"].ToString(), out sourceCodeId))
                        return sourceCodeId;
                }
                return null;
            }
        }

        private long? UserId
        {
            get
            {
                if (IoC.Resolve<ISessionContext>().UserSession!=null)
                {
                    return IoC.Resolve<ISessionContext>().UserSession.UserId;
                }
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
                    if (!UserId.HasValue)
                        return null;
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomerByUserId(UserId.Value);
                }
                return _customer;
            }
        }

        public long CustomerId
        {
            get
            {
                return Customer.CustomerId;
            }
        }
        
        protected bool EnableAlaCarte { get; set; }
        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {

            headingtxt.InnerHtml = "<img src=\"/Content/Images/step3_public.gif\">";
            
            Page.Title = "Select Package";
            

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EventId"]))
                {
                    Session["EventID"] = Request.QueryString["EventId"];
                    hfEventID.Value = Request.QueryString["EventId"];
                    // Hack: This is  done if the user hits back button on payment page, to get back to select package page.
                    if (SourceCodeId.HasValue && SourceCodeId.Value > 0 && !string.IsNullOrEmpty(SourceCode))
                        txtCouponCode.Text = SourceCode;
                }
                else
                {
                    spErrorMsgtop.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode("Sorry, Event detail not found. <a href='../Events/Default.aspx'> Click here  </a> to search again",true);
                    divErrortop.Visible = true;
                    spErrorMsgbottom.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode("Sorry, Event detail not found. <a href='../Events/Default.aspx'> Click here  </a> to search again",true);
                    divErrorbottom.Visible = true;
                }
            }
            ItemCartControl.EventId = EventId.HasValue ? EventId.Value : 0;
            ItemCartControl.RoleId = (long)Roles.Customer;
            ItemCartControl.PackageId = PackageId.HasValue ? PackageId.Value : 0;
            ItemCartControl.TestIds = TestIds;

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

        private void NextButtonClick()
        {
            if (Customer == null) return;
            
            if (!EventValidation()) return;
            
            var testIds = new List<long>();
            IndependentTestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));
            if (!string.IsNullOrEmpty(txtCouponCode.Text))
            {

                var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
                var model = eventSchedulerService.ApplySourceCode(Convert.ToInt64(PackageIdHiddenControl.Value), testIds, Convert.ToDecimal(hfPackageCost.Value), txtCouponCode.Text, (EventId.HasValue?EventId.Value:0), CustomerId, SignUpMode.Online);

                if (!(model.SourceCodeId < 1 && model.FeedbackMessage != null))
                {
                    var couponAmount = model.DiscountApplied;
                    var packageCost = decimal.Parse(hfPackageCost.Value);
                    var totalAmount = packageCost - couponAmount;

                    hfCouponID.Value = model.SourceCodeId.ToString();
                    hfCouponAmt.Value = couponAmount.ToString("#0.00");
                    hfTotalAmount.Value = totalAmount.ToString("#0.00");

                    hfCouponCode.Value = txtCouponCode.Text;

                    // where prospect customers are updated
                    UpdateProspectCustomer(model.SourceCodeId);
                }
            }

            Session["CouponID"] = hfCouponID.Value;
            Session["CouponAmt"] = hfCouponAmt.Value;
            Session["PackageCost"] = hfPackageCost.Value;
            Session["PackageID"] = PackageIdHiddenControl.Value;
            TestIds = testIds;
            Session["TotalAmount"] = hfTotalAmount.Value;
            Session["EventID"] = Request.QueryString["EventId"];
            Session["CouponCode"] = hfCouponCode.Value;

            Response.RedirectUser("SelectAppointment.aspx?User=" + Request.QueryString["User"] + "&EventId=" + Request.QueryString["EventId"]);
        }

        #endregion

        #region Method

        private bool EventValidation()
        {
            if (PackageRegistrationValidators.EventValidation(Customer.CustomerId, Convert.ToInt64(Request.QueryString["ID"])))
            {
                IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository =
                new EventCustomerRegistrationViewDataRepository();

                var data =
                    eventCustomerRegistrationViewDataRepository.GetEventCustomerOrders(Customer.CustomerId, Convert.ToInt64(Request.QueryString["ID"]));

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

                    var message = Customer.Name.FirstName + " " + Customer.Name.MiddleName + " " +
                                  Customer.Name.LastName + " is already registered for this event (" +
                                  data.EventName + " ) at " +
                                  data.EventDate.ToString("dddd dd MMMM yyyy") + " " +
                                  data.AppointmentStartTime.ToString("hh:mm tt") + " for the " +
                                  packageAndTest +
                                  ". Duplicate registrations for the same customer are not allowed. " +
                                  "<span class='gobacklnklogin1_pw'><a id='aChooseAnEvent' href='../Events/Default.aspx?z=" +
                                  Session["z"] + "&m=" + Session["m"] +
                                  "'>Go back and choose another event</a></span>";
                    MaintainPageDataAfterValidationFailure(message);

                }
                return false;
            }
            return true;
        }

        // TODO: same as method in RegisterCustomerSubmit
        protected string GetTestName(string packageId)
        {
            ITestRepository testRepository = new TestRepository();
            return testRepository.GetTestNamesByPackageId(Convert.ToInt64(packageId));
        }

        private void UpdateProspectCustomer(long sourceCodeId)
        {
            IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();

            if(Session["ProspectCustomerId"]==null) return;
            var prospectCustomerId =(long)Session["ProspectCustomerId"];

            if(prospectCustomerId <= 0) return;

            var prospectCustomer = uniqueItemRepository.GetById(prospectCustomerId);

            if(prospectCustomer== null) return;

            var sourceCodeRepository = IoC.Resolve<ISourceCodeRepository>();

            bool isAWorkshopSourceCode;
            try
            {
                isAWorkshopSourceCode = sourceCodeRepository.IsSourceCodeAWorkshopSourceCode(txtCouponCode.Text.Trim());
            }
            catch (Exception)
            {
                isAWorkshopSourceCode = false;
            }

            if (isAWorkshopSourceCode)
            {
                prospectCustomer.SourceCodeId = sourceCodeId;
                prospectCustomer.Source = ProspectCustomerSource.SalesRep;
                prospectCustomer.Tag = ProspectCustomerTag.WellnessSeminar;
                prospectCustomer.TagUpdateDate = DateTime.Now;

            }
            prospectCustomer.IsConverted = false;
            prospectCustomer = uniqueItemRepository.Save(prospectCustomer);
            if (prospectCustomer.Id > 0)
            {
                Session["ProspectCustomerId"] = prospectCustomer.Id;
            }
        }

        private void MaintainPageDataAfterValidationFailure(string message)
        {
            spErrorMsgtop.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(message,true);
            divErrortop.Visible = true;
            spErrorMsgbottom.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(message, true);
            divErrorbottom.Visible = true;

            ClientScript.RegisterStartupScript(typeof(string), "jscode_maintainAfterDuplicateAppointment", "SelectPackage();", true);
        }

        [WebMethod (EnableSession = true)]
        public static SourceCodeApplyEditModel GetCoupon(long packageId, string addOnTestIds, decimal orderTotal, string couponCode, long eventId, long customerId)
        {
            var testIds = new List<long>();
            if (!string.IsNullOrEmpty(addOnTestIds))
                addOnTestIds.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, couponCode, eventId, customerId, SignUpMode.Online);
            return model;
        }

        #endregion

    }
}