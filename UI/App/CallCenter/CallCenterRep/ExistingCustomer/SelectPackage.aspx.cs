using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Sales.Enum;
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
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer
{
    public partial class SelectPackage : Page
    {
        public string GuId
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
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerType"]))
                {
                    switch (Request.QueryString["CustomerType"])
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

        public ProspectCustomer CurrentProspectCustomer
        {
            get
            {
                var prospectCustomerId = RegistrationFlow != null ? RegistrationFlow.ProspectCustomerId : 0;

                if (prospectCustomerId > 0)
                {
                    var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                    return prospectCustomerRepository.GetById(Convert.ToInt64(prospectCustomerId));
                }
                return null;
            }
        }

        protected long CallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }

        protected long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
        }

        protected long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
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

        protected long? AwvVisitId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.AwvVisitId : 0;
            }
            set
            {
                RegistrationFlow.AwvVisitId = value;
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

        protected EventType EventType { get; set; }

        protected bool EnableAlaCarte { get; set; }

        public bool IsClinicalQuestionaireFilled { get; set; }

        public long ClinicalQuestionTemplateId { get; set; }
        public string HraQuestionerAppUrl { get; set; }
        public string HraQuestionerAppUrlWithoutVisit { get; set; }

        public string ChatQuestionerAppUrl { get; set; }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            RegistrationFlow.CanSaveConsentInfo = false;
            SetTitle();
            bool defaultBasePackage = false;

            FillClinicialQuestionnaireDiv.Visible = false;
            ClinicalQuestionTemplateId = 0;
            IsClinicalQuestionaireFilled = false;


            if (EventId > 0)
            {
                if (EventData != null)
                {
                    EventType = EventData.EventType;

                    var configurationSettingRepository = IoC.Resolve<IConfigurationSettingRepository>();
                    EnableAlaCarte = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));
                    if (EnableAlaCarte)
                        EnableAlaCarte = EventData.EnableAlaCarteCallCenter;
                }

                if (AccountByEventId != null)
                {
                    if (AccountByEventId.AskClinicalQuestions && AccountByEventId.ClinicalQuestionTemplateId.HasValue)
                    {
                        FillClinicialQuestionnaireDiv.Visible = true;
                        ClinicalQuestionTemplateId = AccountByEventId.ClinicalQuestionTemplateId.Value;
                        GetRecommendationText();
                    }
                    defaultBasePackage = AccountByEventId.DefaultSelectionBasePackage;

                    // for penguin integartion
                    var settings = IoC.Resolve<ISettings>();

                    QuestionnaireType questionnaireType = QuestionnaireType.None;
                    if (AccountByEventId != null && AccountByEventId.IsHealthPlan && EventData != null)
                    {
                        var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                        questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(AccountByEventId.Id, EventData.EventDate);
                    }

                    if (questionnaireType == QuestionnaireType.HraQuestionnaire)
                    {
                        var userSession = IoC.Resolve<ISessionContext>().UserSession;
                        var token =
                            (Session.SessionID + "_" + userSession.UserId + "_" +
                             userSession.CurrentOrganizationRole.RoleId + "_" +
                             userSession.CurrentOrganizationRole.OrganizationId).Encrypt();


                        HraQuestionerAppUrlWithoutVisit = settings.HraQuestionerAppUrl + "?userToken=" +
                                              HttpUtility.UrlEncode(token) + "&customerId=" + CustomerId + "&orgName=" +
                                              settings.OrganizationNameForHraQuestioner + "&tag=" + AccountByEventId.Tag;
                        HraQuestionerAppUrl = HraQuestionerAppUrlWithoutVisit + "&visitId=" + (RegistrationFlow.AwvVisitId.HasValue ? RegistrationFlow.AwvVisitId.Value : 0);

                        ChatQuestionerAppUrl = string.Empty;
                    }
                    else if (questionnaireType == QuestionnaireType.ChatQuestionnaire)
                    {
                        ChatQuestionerAppUrl = settings.HraQuestionerAppUrl;
                        HraQuestionerAppUrl = string.Empty;
                    }

                }
            }


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

                if (EventId != 0)
                {
                    // Hack: This is  done if the user hits back button on payment page, to get back to select package page.
                    if (SourceCodeId > 0 && !string.IsNullOrEmpty(SourceCode))
                        txtCouponCode.Text = SourceCode;
                    else if (RegistrationFlow != null)
                        txtCouponCode.Text = RegistrationFlow.CallSourceCode;

                    hfEventID.Value = EventId.ToString();

                    var eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
                    hfQuestionAnsTestId.Value = eventCustomerQuestionAnswerService.GetQuestionAnswerTestIdString(CustomerId, EventId);
                }
                else
                {
                    const string message = "Sorry, Event detail not found. <a href=\"RegCustomerSearchEvent.aspx\">Click here</a> to search event again ";
                    DisplayErrorMessage(message);
                }

                if (CurrentProspectCustomer != null && CurrentProspectCustomer.Id > 0 && CurrentProspectCustomer.SourceCodeId != null && CurrentProspectCustomer.SourceCodeId.Value > 0)
                {
                    ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                    var sourceCode = sourceCodeRepository.GetSourceCodeById(CurrentProspectCustomer.SourceCodeId.Value);
                    if (sourceCode != null)
                        txtCouponCode.Text = sourceCode.CouponCode;
                }
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


                if (defaultBasePackage && PackageId == 0 && (RegistrationFlow == null || !RegistrationFlow.SingleTestOverride) && (RegistrationFlow == null || string.IsNullOrEmpty(RegistrationFlow.DisqualifiedTest)))
                {
                    var eventPackages = packageRepository.GetPackagesForEventByRole(EventId, (long)Roles.CallCenterRep)
                            .OrderBy(p => p.Price);
                    if (!eventPackages.IsNullOrEmpty())
                    {
                        var lowestPricePackage = eventPackages.First();
                        PackageId = lowestPricePackage.PackageId;
                        TestIds = lowestPricePackage.Tests.Select(t => t.TestId).ToList();
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
                ItemCartControl.RoleId = (long)Roles.CallCenterRep;
                ItemCartControl.PackageId = PackageId;
                ItemCartControl.TestIds = TestIds;

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else
                {
                    var repository = new CallCenterCallRepository();
                    hfCallStartTime.Value = repository.GetCallStarttime(CallId);
                }

                if (Request.UrlReferrer != null)
                    ViewState["UrlReferer"] = Request.UrlReferrer.PathAndQuery;
            }
            if (Request.Params["__EVENTTARGET"] == "NextButton" && Request.Params["__EVENTARGUMENT"] == "Click")
                NextButtonClick();



        }

        private void GetRecommendationText()
        {
            recommended_test_text.Style.Add(HtmlTextWriterStyle.Display, "none");
            disqulifiedTests.Style.Add(HtmlTextWriterStyle.Display, "none");

            var clinicalQuestionAnswersRepository = IoC.Resolve<ICustomerClinicalQuestionAnswerRepository>();
            var answersSaved = clinicalQuestionAnswersRepository.GetCustomerClinicalQuestionAnswers(GuId, CustomerId);
            if (answersSaved.IsNullOrEmpty()) return;

            var customerClinicalQuestionAnswerSerice = IoC.Resolve<ICustomerClinicalQuestionAnswerService>();
            var recommendedTest = customerClinicalQuestionAnswerSerice.RecommendTestToCustomer(GuId, CustomerId, EventId);
            var recommendedTestNames = "None";
            IsClinicalQuestionaireFilled = true;

            if (recommendedTest != null && recommendedTest.Any(x => !x.IsDisqualified))
            {
                recommendedTestNames = string.Join(",", recommendedTest.Where(x => !x.IsDisqualified).Select(x => x.Name).ToArray());
            }

            if (recommendedTest != null && recommendedTest.Any(x => x.IsDisqualified))
            {
                var disqualifiedTestNames = string.Join(",", recommendedTest.Where(x => x.IsDisqualified).Select(x => x.Name).ToArray());
                disqulifiedTests.InnerHtml = "<b>Disqualified Tests: </b>" + HttpUtility.HtmlEncode(disqualifiedTestNames);
                disqulifiedTests.Style.Add(HtmlTextWriterStyle.Display, "block");
            }

            recommended_test_text.InnerHtml = "<b>Recommended Tests: </b>" + HttpUtility.HtmlEncode(recommendedTestNames);
            recommended_test_text.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

        [WebMethod(EnableSession = true)]
        public static SourceCodeApplyEditModel GetCoupon(long packageId, string addOnTestIds, decimal orderTotal, string couponCode, long eventId, long customerId)
        {
            var testIds = new List<long>();
            if (!string.IsNullOrEmpty(addOnTestIds))
                addOnTestIds.Split(',').ToList().ForEach(t => testIds.Add(Convert.ToInt64(t)));

            var eventSchedulerService = IoC.Resolve<IEventSchedulerService>();
            var model = eventSchedulerService.ApplySourceCode(packageId, testIds, orderTotal, couponCode, eventId, customerId, SignUpMode.CallCenter);
            return model;
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

            SaveProspectCustomer();

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
            SetPageRedirect();
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            //if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            //    Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=" + CustomerType + "&Action=Back&Call=No");
            //else
            //    Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=" + CustomerType + "&Action=Back");

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                {
                    Response.RedirectUser("ExistingCustomer.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&Call=No" + "&guid=" + GuId);
                }
                else if (Request.QueryString["CustomerID"] != null)
                {
                    Response.RedirectUser("ExistingCustomer.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Call=No" + "&guid=" + GuId);
                }
                else
                {
                    Response.RedirectUser("ExistingCustomer.aspx" + "?Call=No" + "&guid=" + GuId);
                }
            }
            else
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                {
                    if (Request.QueryString["Action"] != null && Request.QueryString["CustomerType"] != null && (Request.QueryString["Action"] == "RegNewCustForSameEvent" || Request.QueryString["Action"] == "SameEvent"))
                        Response.RedirectUser("ExistingCustomer.aspx?CustomerType=" + Request.QueryString["CustomerType"] + "&Action=Back&Page=SelectPackage&CustomerID=" + Request.QueryString["CustomerID"] +
                        "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);

                    Response.RedirectUser("ExistingCustomer.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&CustomerType=" + Request.QueryString["CustomerType"] + "&Action=Back&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
                }
                else if (Request.QueryString["CustomerID"] != null)
                {
                    if (Request.QueryString["Action"] != null && Request.QueryString["CustomerType"] != null && (Request.QueryString["Action"] == "RegNewCustForSameEvent" || Request.QueryString["Action"] == "SameEvent"))
                        Response.RedirectUser("ExistingCustomer.aspx?CustomerType=" + Request.QueryString["CustomerType"] + "&Action=Back&Page=SelectPackage&CustomerID=" + Request.QueryString["CustomerID"] + "&guid=" + GuId);

                    Response.RedirectUser("ExistingCustomer.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&CustomerType=" + Request.QueryString["CustomerType"] + "&Action=Back" + "&guid=" + GuId);
                }
                else
                {
                    if (Request.QueryString["Action"] != null && Request.QueryString["CustomerType"] != null && (Request.QueryString["Action"] == "RegNewCustForSameEvent" || Request.QueryString["Action"] == "SameEvent"))
                        Response.RedirectUser("ExistingCustomer.aspx?CustomerType=" + Request.QueryString["CustomerType"] + "&Action=Back&Page=SelectPackage" + "&guid=" + GuId);

                    Response.RedirectUser("ExistingCustomer.aspx?CustomerType=" + Request.QueryString["CustomerType"] + "&Action=Back" + "&guid=" + GuId);
                }
            }
        }

        private void DisplayErrorMessage(string errorMessage)
        {
            errordiv.InnerHtml = errorMessage;
            errordiv.Visible = true;
            ClientScript.RegisterStartupScript(typeof(string), "js_MaintainAfterFailedPostback", "MaintainAfterFailedPostBack();", true);
        }

        protected string GetTestName(string packageId)
        {
            ITestRepository testRepository = new TestRepository();
            return testRepository.GetTestNamesByPackageId(Convert.ToInt64(packageId));
        }

        protected void SelectScheduleListItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Not using java script as PackageId cant find at java script
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var radioButton = (RadioButton)e.Item.FindControl("rbtSelectSlot");
                if (radioButton != null)
                {
                    radioButton.Attributes["onClick"] = "return SlotSelect(" + radioButton.ClientID + ")";
                }
            }
        }

        protected void EndCallImageClick(object sender, ImageClickEventArgs e)
        {
            var objCommoncode = new CommonCode();
            objCommoncode.EndCCRepCall(Page);
        }

        private void SetTitle()
        {
            var callCenterMasterPage = (CallCenter_CallCenterMaster1)Master;
            callCenterMasterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
            callCenterMasterPage.hideucsearch();
            if (CustomerType == CustomerType.Existing)
            {
                callCenterMasterPage.SetTitle("Existing Customer");
                StepTitleContainer.InnerText = "Existing Customer";
            }
            else
            {
                callCenterMasterPage.SetTitle("Register New Customer");
                StepTitleContainer.InnerText = "Register New Customer";
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

        private Core.Users.Domain.Customer _customer;
        private Core.Users.Domain.Customer CurrentCustomer
        {
            get
            {
                if (_customer == null && CustomerId > 0)
                {
                    _customer = IoC.Resolve<ICustomerRepository>().GetCustomer(CustomerId);
                }
                return _customer;
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

        private Event _eventData;
        private Event EventData
        {
            get
            {
                if (_eventData == null && EventId > 0)
                {
                    _eventData = IoC.Resolve<IEventRepository>().GetById(EventId);
                }
                return _eventData;
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

                    packageAndTest = string.IsNullOrEmpty(packageAndTest)
                                         ? additinalTest
                                         : packageAndTest +
                                           (string.IsNullOrEmpty(additinalTest)
                                                ? string.Empty
                                                : ", " + additinalTest);

                    var message = CurrentCustomer.NameAsString + " is already registered for this event (" + EventData.Name + " ) at " +
                                            EventData.EventDate.ToString("dddd dd MMMM yyyy") + " " +
                                            appointment.StartTime.ToString("hh:mm tt") + " for the " + packageAndTest +
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
            var model = eventSchedulerService.ApplySourceCode(PackageId, testIds, PackageCost, txtCouponCode.Text, EventId, CustomerId, SignUpMode.CallCenter);
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

        private void SetPageRedirect()
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                {
                    Response.RedirectUser("SelectAppointment.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId
                                      + "&Name=" + Request.QueryString["Name"] + "&Call=No" + "&guid=" + GuId);
                }
                else if (Request.QueryString["CustomerID"] != null)
                {
                    Response.RedirectUser("SelectAppointment.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&Call=No" + "&guid=" + GuId);
                }
                else
                {
                    Response.RedirectUser("SelectAppointment.aspx?CustomerType=" + CustomerType + "&Call=No" + "&guid=" + GuId);
                }
            }
            else
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["Name"] != null)
                {
                    Response.RedirectUser("SelectAppointment.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
                }
                else if (Request.QueryString["CustomerID"] != null)
                {
                    Response.RedirectUser("SelectAppointment.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&guid=" + GuId);
                }
                else
                {
                    Response.RedirectUser("SelectAppointment.aspx?CustomerType=" + CustomerType + "&guid=" + GuId);
                }
            }
        }

        private void SaveProspectCustomer()
        {
            if (CurrentProspectCustomer == null || CurrentProspectCustomer.Id < 1) return;

            IProspectCustomerRepository prospectCustomerRepository = new ProspectCustomerRepository();
            bool isAWorkshopProspect = prospectCustomerRepository.IsProspectAWorkshopProspect(CurrentProspectCustomer.Id);

            if (isAWorkshopProspect)
            {
                CurrentProspectCustomer.Source = ProspectCustomerSource.SalesRep;
                CurrentProspectCustomer.Tag = ProspectCustomerTag.WellnessSeminar;
                CurrentProspectCustomer.TagUpdateDate = DateTime.Now;

                IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();
                uniqueItemRepository.Save(CurrentProspectCustomer);
                return;
            }

            if (!string.IsNullOrEmpty(txtCouponCode.Text))
            {
                ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                bool isAWorkshopSourceCode;
                try
                {
                    isAWorkshopSourceCode =
                        sourceCodeRepository.IsSourceCodeAWorkshopSourceCode(txtCouponCode.Text.Trim());

                }
                catch (Exception)
                {
                    isAWorkshopSourceCode = false;
                }

                if (isAWorkshopSourceCode)
                {
                    CurrentProspectCustomer.SourceCodeId = SourceCodeId;
                    CurrentProspectCustomer.Source = ProspectCustomerSource.SalesRep;
                    CurrentProspectCustomer.Tag = ProspectCustomerTag.WellnessSeminar;
                    CurrentProspectCustomer.TagUpdateDate = DateTime.Now;

                    IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();
                    uniqueItemRepository.Save(CurrentProspectCustomer);
                }
            }
        }



    }
}