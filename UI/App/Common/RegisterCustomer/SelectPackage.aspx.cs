using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.App.Core.Users.Enum;


namespace Falcon.App.UI.App.Common.RegisterCustomer
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

        private CustomerType CustomerType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Customer"]))
                {
                    switch (Request.QueryString["Customer"])
                    {
                        case "Existing":
                            return CustomerType.Existing;
                        default:
                            return CustomerType.New;
                    }
                }
                return CustomerType.New;
            }
        }

        protected long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
            set
            { RegistrationFlow.EventId = value; }
        }

        protected long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        private Core.Users.Domain.Customer _customer;

        private Core.Users.Domain.Customer CurrentCustomer
        {
            get
            {
                if (_customer == null && CustomerId > 0)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId);
                }
                return _customer;
            }
        }

        private EventCustomer _eventCustomer = null;
        private EventCustomer EventCustomer
        {
            get
            {
                if (_eventCustomer == null)
                {
                    var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                    _eventCustomer = eventCustomerRepository.Get(EventId, CustomerId);

                }
                return _eventCustomer;
            }
        }

        private IEventCustomerPackageTestDetailService _packageTestDetailService;
        private IEventCustomerPackageTestDetailService PackageTestDetailService
        {
            get
            {
                return _packageTestDetailService ?? (_packageTestDetailService = IoC.Resolve<IEventCustomerPackageTestDetailService>());
            }
        }

        private IEventRepository _eventRepository;
        private IEventRepository EventRepository
        {
            get
            {
                return _eventRepository ?? (_eventRepository = IoC.Resolve<IEventRepository>());
            }
        }

        private Event _eventData;
        private Event EventData
        {
            get
            {
                if (_eventData == null && EventId > 0)
                {
                    _eventData = EventRepository.GetById(EventId);
                }
                return _eventData;
            }
        }

        private CorporateAccount _accountByEventId;
        private CorporateAccount AccountByEventId
        {
            get
            {
                if (_accountByEventId == null && EventId > 0)
                {
                    _accountByEventId = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId);
                }

                return _accountByEventId;
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
 
        private bool SingleTestOverride
        {
            get { return RegistrationFlow != null && RegistrationFlow.SingleTestOverride; }
            set { RegistrationFlow.SingleTestOverride = value; }
        }

        public string QuestionIdAnswerTestId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.QuestionIdAnswerTestId : string.Empty;
            }
            set
            {
                RegistrationFlow.QuestionIdAnswerTestId = value;
            }
        }

        public string DisqualifiedTest
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.DisqualifiedTest : string.Empty;
            }
            set
            {
                RegistrationFlow.DisqualifiedTest = value;
            }
        }

        private IEnumerable<long> DisqualifiedTestIds
        {
            get
            {
                var disqualifiedTestString = RegistrationFlow != null ? RegistrationFlow.DisqualifiedTest : string.Empty;
                if (string.IsNullOrEmpty(disqualifiedTestString))
                    return new List<long>();
                var disqualifiedTests = disqualifiedTestString.Split('|');

                var disqualifiedTestIds = new List<long>();
                foreach (var disqualifiedTest in disqualifiedTests)
                {
                    var dtArray = disqualifiedTest.Split(',');
                    var disqualifiedTestId = Convert.ToInt64(dtArray[0]);
                    disqualifiedTestIds.Add(disqualifiedTestId);
                }

                if (RegistrationFlow != null && !RegistrationFlow.DependentDisqualifiedTests.IsNullOrEmpty())
                    disqualifiedTestIds.AddRange(RegistrationFlow.DependentDisqualifiedTests);

                return disqualifiedTestIds;
            }
        }


        protected EventType EventType { get; set; }
        protected bool EnableAlaCarte { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle();
            if (!IsPostBack)
            {
                if (RegistrationFlow != null && RegistrationFlow.IsRetest)
                {
                    RetestNo.Checked = false;
                    RetestYes.Checked = true;
                }
                else
                {
                    RetestNo.Checked = true;
                    RetestYes.Checked = false;
                }
 
                if (RegistrationFlow != null && RegistrationFlow.SingleTestOverride)
                {
                    SingleTestOverrideYes.Checked = true;
                    SingleTestOverrideNo.Checked = false;
                }
                else
                {
                    SingleTestOverrideYes.Checked = false;
                    SingleTestOverrideNo.Checked = true;
                }

                if (Request.QueryString["EventID"] != null)
                    EventId = long.Parse(Request.QueryString["EventID"]);
                if (EventId != 0)
                {
                    // Hack: This is  done if the user hits back button on payment page, to get back to select package page.
                    if (SourceCodeId > 0 && !string.IsNullOrEmpty(SourceCode))
                        txtCouponCode.Text = SourceCode;
                }
                else
                {
                    const string message = "Sorry, Event detail not found. <a href=\"RegCustomerSearchEvent.aspx\">Click here</a> to search event again ";
                    DisplayErrorMessage(message);
                }
                //ItemCartControl.EventId = EventId;
                //ItemCartControl.RoleId = (long)Roles.Technician;
                //ItemCartControl.PackageId = PackageId;
                //ItemCartControl.TestIds = TestIds;
            }

            if (EventId > 0)
            {

                if (EventData != null)
                {
                    EventType = EventData.EventType;

                    var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
                    EnableAlaCarte = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));
                    if (EnableAlaCarte)
                        EnableAlaCarte = EventData.EnableAlaCarteTechnician;
                }

                var eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
                hfQuestionAnsTestId.Value = eventCustomerQuestionAnswerService.GetQuestionAnswerTestIdString(CustomerId, EventId);

                IEventPackageRepository packageRepository = new EventPackageRepository();
                var preApprovedPackageRepository = IoC.Resolve<IPreApprovedPackageRepository>();

                if (AccountByEventId != null && AccountByEventId.AllowPreQualifiedTestOnly)
                {
                    long preApprovedPackageId = preApprovedPackageRepository.CheckPreApprovedPackages(CustomerId);
                    if (PackageId == 0 && preApprovedPackageId > 0 && (RegistrationFlow == null || !RegistrationFlow.SingleTestOverride) && (RegistrationFlow == null || string.IsNullOrEmpty(RegistrationFlow.DisqualifiedTest)))
                    {
                        var eventPackages = packageRepository.GetPackagesForEventByRole(EventId, (long)Roles.CallCenterRep);

                        if (!eventPackages.IsNullOrEmpty())
                        {
                            var preApprovedPackage = eventPackages.FirstOrDefault(x => x.PackageId == preApprovedPackageId);
                            if (preApprovedPackage != null)
                            {
                                PackageId = preApprovedPackage.PackageId;
                                TestIds = preApprovedPackage.Tests.Select(t => t.TestId).ToList();
                            }

                        }
                    }
                }

                if (RegistrationFlow != null && !string.IsNullOrWhiteSpace(RegistrationFlow.DisqualifiedTest) && string.IsNullOrWhiteSpace(hfDisqualifedTest.Value))
                {
                    hfDisqualifedTest.Value = RegistrationFlow.DisqualifiedTest;
                }

                if (RegistrationFlow != null && !string.IsNullOrWhiteSpace(RegistrationFlow.QuestionIdAnswerTestId) && string.IsNullOrWhiteSpace(hfQuestionAnsTestId.Value))
                {
                    hfQuestionAnsTestId.Value = RegistrationFlow.QuestionIdAnswerTestId;
                }

                /*if (!DisqualifiedTestIds.IsNullOrEmpty())
                {
                    TestIds = TestIds.Where(x => !DisqualifiedTestIds.Contains(x)).ToList();
                }*/


                ItemCartControl.EventId = EventId;
                ItemCartControl.RoleId = (long)Roles.Technician;
                ItemCartControl.PackageId = PackageId;
                ItemCartControl.TestIds = TestIds;
            }

            ClientScript.RegisterStartupScript(typeof(string), "JsCode_WaitForPageLoad", " $('.package-list').toggle(); ", true);
            if (Request.Params["__EVENTTARGET"] == "NextButton" && Request.Params["__EVENTARGUMENT"] == "Click")
                NextButtonClick();

        }

        private void NextButtonClick()
        {
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

            if (!string.IsNullOrWhiteSpace(hfQuestionAnsTestId.Value))
                QuestionIdAnswerTestId = hfQuestionAnsTestId.Value;
            else QuestionIdAnswerTestId = string.Empty;

            if (!string.IsNullOrWhiteSpace(hfDisqualifedTest.Value))
                DisqualifiedTest = hfDisqualifedTest.Value;
            else
            {
                DisqualifiedTest = string.Empty;
            }

            var isEawvPurchased = (TestIds.Any(x => x == (long)TestType.eAWV) || AddOnTestIds.Any(x => x == (long)TestType.eAWV));

            if (CustomerId > 0 && !RegistrationFlow.AwvVisitId.HasValue)
            {   // this was added so that Even if the user forgets to open the HRA Questionnaire Button - We push the User to Medicare.

                var account = AccountByEventId;

                QuestionnaireType questionnaireType = QuestionnaireType.None;
                if (account != null && EventData != null)
                {
                    var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                    questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, EventData.EventDate);
                }


                if (account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.HraQuestionnaire) && isEawvPurchased)
                {
                    try
                    {
                        var setting = IoC.Resolve<ISettings>();
                        
                        if (setting.SyncWithHra)
                        {
                            var medicareService = IoC.Resolve<IMedicareService>();
                            var model = medicareService.GetCustomerDetails(CustomerId);
                            model.Tag = account.Tag;
                            var medicareApiService = IoC.Resolve<IMedicareApiService>();


                            model.EventDetails = new MedicareEventEditModel { EventId = EventId, VisitDate = EventData.EventDate };
                            var result = medicareApiService.PostAnonymous<MedicareCustomerSetupViewModel>(setting.MedicareApiUrl + MedicareApiUrl.CreateUpdateCustomer, model);
                            if (result != null)
                            {
                                RegistrationFlow.AwvVisitId = result.PatientVisitId;
                            } 
                        }
                        
                    }
                    catch (Exception exception)
                    {
                        var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                        logger.Error("Error occured in Medicare Customer Sync (In Existing Customer : Select appointment) for Customer : " + CustomerId +
                            " Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
                    }
                }
            }

            if (Request.QueryString["Eventid"] != null)
            {
                EventId = long.Parse(Request.QueryString["Eventid"]);
                Response.RedirectUser("/App/Common/RegisterCustomer/SelectAppointment.aspx?EventID=" + EventId + "&guid=" + GuId);
            }
            else if (CustomerType == CustomerType.Existing)
            {
                Response.RedirectUser("SelectAppointment.aspx?Customer=Existing" + "&guid=" + GuId);
            }
            else
            {
                Response.RedirectUser("SelectAppointment.aspx?guid=" + GuId);
            }
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                long eventId = long.Parse(Request.QueryString["EventID"]);
                if (Request.QueryString["Customer"] != null)
                {
                    Response.RedirectUser("RegisterCustomer.aspx?EventID=" + eventId + "&Action=Back&Customer=" + Request.QueryString["Customer"] + "&guid=" + GuId);
                }
            }
            if (CustomerType == CustomerType.Existing)
            {
                Response.RedirectUser("RegCustomerSearchEvent.aspx?Customer=Existing" + "&guid=" + GuId);
            }
            else
            {
                Response.RedirectUser("RegCustomerSearchEvent.aspx?guid=" + GuId);
            }
        }

        [WebMethod(EnableSession = true)]
        public static SourceCodeApplyEditModel GetCoupon(long packageId, string addOnTestIds, decimal orderTotal, string couponCode, long eventId, long customerId)
        {
            var testIds = new List<long>();
            if (!string.IsNullOrEmpty(addOnTestIds))
                addOnTestIds.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, couponCode, eventId, customerId, SignUpMode.Walkin);
            return model;
        }

        protected string GetTestName(string packageId)
        {
            ITestRepository testRepository = new TestRepository();
            return testRepository.GetTestNamesByPackageId(Convert.ToInt64(packageId));
        }

        private void SetTitle()
        {
            var franchiseeTechnicianMasterPage = (Franchisee_Technician_TechnicianMaster)Master;
            franchiseeTechnicianMasterPage.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/HomePage.aspx\">Dashboard></a>";

            if (CustomerType == CustomerType.Existing)
            {
                franchiseeTechnicianMasterPage.settitle("Existing Customer");
                dvTitle.InnerText = "Technician Existing Customer";
            }
            else
            {
                int symbolNumber = Request.QueryString["From"] != null && Request.QueryString["From"] == "ECL" ? 2 : 3;
                imgSymbol.Src = string.Format("/App/Images/CCRep/page{0}symbol.gif", symbolNumber);
                franchiseeTechnicianMasterPage.settitle("Register New Customer");
                dvTitle.InnerText = "Technician Register Customer";
            }
        }

        private bool EventValidation()
        {

            if (EventCustomer != null && EventCustomer.AppointmentId.HasValue)
            {
                var packageTestDetail = PackageTestDetailService.GetEventPackageDetails(EventCustomer.Id);

                var appointment = IoC.Resolve<IAppointmentRepository>().GetById(EventCustomer.AppointmentId.Value);

                if (packageTestDetail != null)
                {
                    var packageAndTest = packageTestDetail.Package != null ? packageTestDetail.Package.Name : string.Empty;
                    var additinalTest = packageTestDetail.Tests.IsNullOrEmpty() ? string.Empty : string.Join(",", packageTestDetail.Tests.Select(x => x.Name).ToArray());

                    packageAndTest = string.IsNullOrEmpty(packageAndTest) ? additinalTest : packageAndTest + (string.IsNullOrEmpty(additinalTest) ? string.Empty : ", " + additinalTest);

                    var message = CurrentCustomer.NameAsString + " is already registered for this event (" + EventData.Name + " ) at " + EventData.EventDate.ToString("dddd dd MMMM yyyy") + " " + appointment.StartTime.ToString("hh:mm tt") + " for the " + packageAndTest +
                        ". Duplicate registrations for the same customer are not allowed.";

                    DisplayErrorMessage(message);
                }

                return false;
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
            var screeningTime = eventPackageSelectorService.GetScreeningTime(EventId, PackageId, AddOnTestIds);
            if (!RegistrationFlow.AppointmentSlotIds.IsNullOrEmpty() && isOrderChanged)
            {
                var eventSchedulingSlotService = IoC.Resolve<IEventSchedulingSlotService>();

                var slots = eventSchedulingSlotService.AdjustAppointmentSlot(EventId, screeningTime, RegistrationFlow.AppointmentSlotIds, PackageId, AddOnTestIds, EventData.LunchStartTime, EventData.LunchDuration);
                RegistrationFlow.AppointmentSlotIds = slots.IsNullOrEmpty() ? null : slots.Select(s => s.Id).ToArray();
            }
            RegistrationFlow.ScreeningTime = screeningTime;

            var eligibilityService = IoC.Resolve<IEligibilityService>();
            RegistrationFlow.IsTestCoveredByInsurance = eligibilityService.CheckTestCoveredByinsurance(EventId, PackageId, AddOnTestIds);

            if (!RegistrationFlow.IsTestCoveredByInsurance)
                RegistrationFlow.EligibilityId = 0;

            RegistrationFlow.IsRetest = RetestYes.Checked;
            RegistrationFlow.SingleTestOverride = SingleTestOverrideYes.Checked;
        }

        private void SetSourceCodeData()
        {
            var testIds = new List<long>();
            IndependentTestIdsHiddenControl.Value.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(PackageId, testIds, PackageCost, txtCouponCode.Text, EventId, CustomerId, SignUpMode.Walkin);
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

        private void DisplayErrorMessage(string errorMessage)
        {
            errordiv.InnerHtml = errorMessage;
            errordiv.Visible = true;
            ClientScript.RegisterStartupScript(typeof(string), "js_MaintainAfterFailedPostback", "MaintainAfterFailedPostBack();", true);
        }

    }
}