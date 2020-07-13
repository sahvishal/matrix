using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Repositories.Users;
using HtmlAgilityPack;
using Falcon.App.Core.Application.Attributes;
using DateTime = System.DateTime;
using File = System.IO.File;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodPressureStandardFinding
    {
        public StandardFinding<int?> ForSystolic { get; set; }
        public StandardFinding<int?> ForDiastolic { get; set; }

        public BloodPressureStandardFinding(long mockId, string label, string longDescription, OrderedPair<int?, int?> systolicRange, OrderedPair<int?, int?> diastolicRange)
        {
            ForSystolic = new StandardFinding<int?>(mockId) { Label = label, LongDescription = longDescription, MinValue = systolicRange.FirstValue, MaxValue = systolicRange.SecondValue };
            ForDiastolic = new StandardFinding<int?>(mockId) { Label = label, LongDescription = longDescription, MinValue = diastolicRange.FirstValue, MaxValue = diastolicRange.SecondValue };
        }
    }

    public class BloodPressureStandardFindingRange
    {
        public static BloodPressureStandardFinding Normal
        {
            get
            {
                return new BloodPressureStandardFinding(1, "Normal", "<i> The result of your blood pressure screening is normal, falling at or below 119/80. </i>", new OrderedPair<int?, int?>(null, 119), new OrderedPair<int?, int?>(null, 80));
            }
        }

        public static BloodPressureStandardFinding PreHypertension
        {
            get
            {
                return new BloodPressureStandardFinding(2, "Pre-Hypertension", "<i> The result of your blood pressure screening falls between 120/81 and 139/89. This is considered the prehypertension stage; many people in this range go on to develop clinical hypertension.  It is recommended that you consult with your personal physician as to when retesting may be indicated. </i>", new OrderedPair<int?, int?>(120, 139), new OrderedPair<int?, int?>(81, 89));
            }
        }

        public static BloodPressureStandardFinding MildHypertension
        {
            get
            {
                return new BloodPressureStandardFinding(3, "Mild Hypertension", "<i> The result of your blood pressure screening falls between 140/90 and 159/104.  This result suggests mild hypertension and a mildly elevated blood pressure.  It is recommended that you discuss these findings with your personal physician, as lifestyle modifications and medications may be necessary.  Also, your personal physician will be able to advise you as to when retesting may be indicated.</i>", new OrderedPair<int?, int?>(140, 159), new OrderedPair<int?, int?>(90, 104));
            }
        }

        public static BloodPressureStandardFinding ModerateHypertension
        {
            get
            {
                return new BloodPressureStandardFinding(4, "Moderate Hypertension", "<i> The result of your blood pressure screening falls between 160/105 and 179/119.  This result suggests moderate hypertension and a moderately elevated blood pressure.  It is recommended that you discuss these findings with your personal physician, as lifestyle modifications and medications may be necessary.  Also, your personal physician will be able to advise you as to when retesting may be indicated.</i>", new OrderedPair<int?, int?>(160, 179), new OrderedPair<int?, int?>(105, 119));
            }
        }

        public static BloodPressureStandardFinding SevereHypertension
        {
            get
            {
                return new BloodPressureStandardFinding(5, "Severe Hypertension", "<i> The results of your blood pressure screening is greater than or equal to 180/120.  This result is graded as severe hypertension.  It is recommended that you take these results to your personal physician as soon as conveniently possible.  Prolonged severe hypertension has serious medical consequences.</i>", new OrderedPair<int?, int?>(180, null), new OrderedPair<int?, int?>(120, null));
            }
        }

        public static IEnumerable<StandardFinding<int?>> AllSystolic { get { return new[] { Normal.ForSystolic, PreHypertension.ForSystolic, MildHypertension.ForSystolic, ModerateHypertension.ForSystolic, SevereHypertension.ForSystolic }; } }
        public static IEnumerable<StandardFinding<int?>> AllDiastolic { get { return new[] { Normal.ForDiastolic, PreHypertension.ForDiastolic, MildHypertension.ForDiastolic, ModerateHypertension.ForDiastolic, SevereHypertension.ForDiastolic }; } }

        public static StandardFinding<int?> SelectedFinding(int findingId)
        {
            if (findingId < 1) return null;

            return AllSystolic.Where(a => a.Id == findingId).SingleOrDefault();
        }
    }

    [DefaultImplementation(Interface = typeof(IGenerateFinalPdf))]
    public class GenerateFinalPdf : IGenerateFinalPdf
    {
        private readonly string _htmlFilePathPremiumVersion;

        private readonly string _htmlFilePathIndexPage;
        private readonly string _htmlFilePathCoverLetter;
        private readonly string _htmlFilePathPcpCoverLetterWithDianosisCode;
        private readonly string _htmlFilePathBloodLetter;
        private readonly string _htmlFilePathCorporateCoverLetter;
        private readonly string _htmlFilePathPcpCoverLetter;
      

        //HtmlDocument _doc;
        private bool _loadImages;

        private IStandardFindingRepository _standardFindingRepository;
        private IMediaRepository _mediaRepository;
        private ITestRepository _testRepository;
        private List<OrderedPair<long, string>> _technicianIdNamePairs;
        private IIncidentalFindingRepository _incidentalFindingRepository;
        //private  HealthAssesmentFormRepository _assesmentFormRepository;
        private bool _showBasicBiometric;
        private Service.TestResultService _testResultService;

        private ISettings _settings;
        private readonly ICustomerScreeningViewDataRepository _customerScreeningViewDataRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUniqueItemRepository<Core.Application.Domain.File> _fileRepository;

        private const string StringForMale = "male - ";
        private const string StringForFemale = "female - ";
        private const string StringforContentDirectory = "content";
        private const string StringforMediaDirectory = "media";


        private bool _isMale = true;

        public List<IncidentalFindingGroup> IncidentalFindingGroup { get; set; }

        private const string ImtNormal = "NORMAL";
        private const string ImtAbnormal = "ABNORMAL";

        private const string AaaNoAneurysm = "NO ANEURYSM";
        private const string AaaAneurysm = "ANEURYSM";

        private const string EkgNormal = "Normal";
        private const string EkgAbnormal = "Abnormal";

        private const string PulmonaryNormal = "NORMAL";
        private const string PulmonaryAbnormal = "ABNORMAL";

        private const string OsteoNormal = "NORMAL";
        private const string OsteoMild = "MILD / MODERATE RISK";
        private const string OsteoHighRisk = "HIGH RISK";
        private const string OsteoInConclusive = "INCONCLUSIVE";

        private long _eventId;
        private long _customerId;

        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventCustomerResultBloodLabRepository _eventCustomerResultBloodLabRepository;
        private IResultPdfHelper _resultPdfHelper;
        private IEchoResultPdfHelper _echoResultPdfHelper;
        private IStrokeResultPdfHelper _strokeResultPdfHelper;
        private ILipidResultPdfHelper _lipidResultPdfHelper;
        private IHPyloriResultPdfHelper _hPyloriResultPdfHelper;
        private IBloodPanelResultHelper _bloodPanelResultHelper;
        private IAbiResultPdfHelper _abiResultPdfHelper;
        private IEventCustomerResultRepository _eventCustomerResultRepository;
        private ITestNotPerformedHelper _testNotPerformedHelper;
        private Falcon.App.Core.ValueTypes.MediaLocation _ipResultPdfMediaLocation;
        private readonly IAwvAAAResultPdfHelper _awvAAAResultPdfHelper;
        private readonly ILeadResultPdfHelper _leadResultPdfHelper;
        private readonly IAwvEkgResultPdfHelper _awvEkgResultPdfHelper;
        private readonly ICopyMediaResultPdfHelper _copyMediaResultPdfHelper;
        private readonly IGenerateTestPdfHelper _generateTestPdfHelper;
        private readonly IEventCustomerResultBloodLabParserRepository _eventCustomerResultBloodLabParserRepository;        

        public GenerateFinalPdf(ICustomerScreeningViewDataRepository customerScreeningViewDataRepository, ISettings settings, IStandardFindingRepository standardFindingRepository, ITestRepository testRepository,
            IMediaRepository mediaRepository, IIncidentalFindingRepository incidentalFindingRepository, ICustomerRepository customerRepository, IOrganizationRepository organizationRepository, IAddressRepository addressRepository,
            IUniqueItemRepository<Core.Application.Domain.File> fileRepository, IConfigurationSettingRepository configurationSettingRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
            ICorporateAccountRepository corporateAccountRepository, IResultPdfHelper resultPdfHelper, IEchoResultPdfHelper echoResultPdfHelper, IStrokeResultPdfHelper strokeResultPdfHelper, ILipidResultPdfHelper lipidResultPdfHelper,
            IHPyloriResultPdfHelper hPyloriResultPdfHelper, IBloodPanelResultHelper bloodPanelResultHelper, IEventCustomerResultBloodLabRepository eventCustomerResultBloodLabRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            IAbiResultPdfHelper abiResultPdfHelper, ITestNotPerformedHelper testNotPerformedHelper, IAwvAAAResultPdfHelper awvAAAResultPdfHelper, ILeadResultPdfHelper leadResultPdfHelper,
            IAwvEkgResultPdfHelper awvEkgResultPdfHelper, ICopyMediaResultPdfHelper copyMediaResultPdfHelper, IGenerateTestPdfHelper generateTestPdfHelper, IEventCustomerResultBloodLabParserRepository eventCustomerResultBloodLabParserRepository)
        {
            _customerScreeningViewDataRepository = customerScreeningViewDataRepository;
            _settings = settings;
            _standardFindingRepository = standardFindingRepository;
            _testRepository = testRepository;
            _mediaRepository = mediaRepository;
            _incidentalFindingRepository = incidentalFindingRepository;
            _htmlFilePathPremiumVersion = _settings.TemplatePremiumVersionLocation;

            _htmlFilePathIndexPage = _settings.TemplateIndexPageLocation;

            _htmlFilePathCoverLetter = _settings.TemplateCoverLetterLocation;
            _htmlFilePathBloodLetter = _settings.TemplateBloodLetterLoaction;
            _htmlFilePathCorporateCoverLetter = _settings.TemplateCorporateCoverLetterLocation;
            //_assesmentFormRepository = new HealthAssesmentFormRepository();
            _testResultService = new Service.TestResultService();
            _customerRepository = customerRepository;
            _organizationRepository = organizationRepository;
            _addressRepository = addressRepository;
            _fileRepository = fileRepository;
            _showBasicBiometric = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.ShowBasicBiometric));

            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _htmlFilePathPcpCoverLetterWithDianosisCode = _settings.TemplatePcpCoverLetterWithDianosisCodeLocation;
            _htmlFilePathPcpCoverLetter = _settings.TemplatePcpCoverLetterLocation;
            _corporateAccountRepository = corporateAccountRepository;
            _eventCustomerResultBloodLabRepository = eventCustomerResultBloodLabRepository;
            _resultPdfHelper = resultPdfHelper;
            _echoResultPdfHelper = echoResultPdfHelper;
            _strokeResultPdfHelper = strokeResultPdfHelper;
            _lipidResultPdfHelper = lipidResultPdfHelper;
            _hPyloriResultPdfHelper = hPyloriResultPdfHelper;
            _bloodPanelResultHelper = bloodPanelResultHelper;
            _abiResultPdfHelper = abiResultPdfHelper;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _testNotPerformedHelper = testNotPerformedHelper;
            _awvAAAResultPdfHelper = awvAAAResultPdfHelper;
            _leadResultPdfHelper = leadResultPdfHelper;
            _awvEkgResultPdfHelper = awvEkgResultPdfHelper;
            _copyMediaResultPdfHelper = copyMediaResultPdfHelper;
            _generateTestPdfHelper = generateTestPdfHelper;
            _eventCustomerResultBloodLabParserRepository = eventCustomerResultBloodLabParserRepository;           
        }


        public bool CreatePremiumPdf(string saveFilePath, Customer customer, Event eventData, bool isTestDependent, IEnumerable<long> testIds, bool showHeaderImageInReport, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview, bool getPhysicianEvaluatedTest = false)
        {
            var hasSectionToDisplay = false;
            try
            {
                var doc = new HtmlDocument();
                doc.Load(_htmlFilePathPremiumVersion);

                if (getPhysicianEvaluatedTest)
                    _ipResultPdfMediaLocation = _mediaRepository.GetIpResultPdfLocation(eventData.Id, customer.CustomerId, false);

                hasSectionToDisplay = CreatePremiumPdfwithDataProvided(doc, saveFilePath, customer, eventData, isTestDependent, testIds, eventCustomerPhysicianEvaluations, customerSkipReview, showHeaderImageInReport, getPhysicianEvaluatedTest: getPhysicianEvaluatedTest);
            }
            catch (Exception)
            {
                throw;
            }
            return hasSectionToDisplay;
        }

        public bool CreatePcpResultPdf(string saveFilePath, Customer customer, Event eventData, bool isTestDependent, IEnumerable<long> testIds, bool copyMedia, bool copySupportMedia, bool showHeaderImageInReport,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            var hasSectionToDisplay = false;
            try
            {
                var doc = new HtmlDocument();
                doc.Load(_htmlFilePathPremiumVersion);
                hasSectionToDisplay = CreatePremiumPdfwithDataProvided(doc, saveFilePath, customer, eventData, isTestDependent, testIds, eventCustomerPhysicianEvaluations, customerSkipReview, showHeaderImageInReport, copyMedia, copySupportMedia);
            }
            catch (Exception)
            {
                throw;
            }

            return hasSectionToDisplay;
        }

        private bool CreatePremiumPdfwithDataProvided(HtmlDocument doc, string saveFilePath, Customer customer, Event eventData, bool isTestDependent, IEnumerable<long> testIds, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview, bool showHeaderImageInReport, bool copyMedia = true, bool copySupportMedia = true, bool reportWithImages = false, bool getPhysicianEvaluatedTest = false)
        {
            var repository = _customerScreeningViewDataRepository;
            CustomerScreeningViewData viewData = repository.GetCustomerScreeningViewData(customer.CustomerId, eventData.Id);

            if (viewData == null) throw new Exception("Data not found in database.");

            var hasSectionToDisplay = false;

            try
            {
                _eventId = eventData.Id;
                _customerId = customer.CustomerId;

                _loadImages = false;

                _isMale = true;
                if (viewData.Customer.Gender == Gender.Female)
                    _isMale = false;

                var account = _corporateAccountRepository.GetbyEventId(eventData.Id);
                var isPhysicianPartnerCustomer = !getPhysicianEvaluatedTest && account != null && account.GeneratePcpLetterWithDiagnosisCode;
                var removeLongDescription = account != null && account.RemoveLongDescription;

                var showUnreadableTest = account != null && account.AttachUnreadableTest;

                SetCoverLetterData(viewData, doc);
                var eventCustomerResultBloodLab = _eventCustomerResultBloodLabRepository.GetByEventIdAndCustomerId(eventData.Id, customer.CustomerId);
                var isFromNewBloodLab = false;
                if (eventCustomerResultBloodLab != null)
                    isFromNewBloodLab = eventCustomerResultBloodLab.IsFromNewLab;

               // var eventCustomerResultBloodLabParser = _eventCustomerResultBloodLabParserRepository.GetByEventIdAndCustomerId(eventData.Id, customer.CustomerId);
                //var isHanson = false;
                //if (eventCustomerResultBloodLabParser != null)
                //    isHanson = eventCustomerResultBloodLabParser.IsActive;
                var isHanson = true;

                LoadTestResults(viewData.ScreeningResult, viewData.TestsPurchased, isTestDependent, testIds, isPhysicianPartnerCustomer, removeLongDescription, eventData, customer, viewData.Physicians, viewData.EventPhysicianTests,
                    isFromNewBloodLab, showUnreadableTest, eventCustomerPhysicianEvaluations, customerSkipReview, doc, account, getPhysicianEvaluatedTest, isHanson);

                // _testNotPerformedHelper.CreateTestNotPerformedPage(doc, viewData.ScreeningResult);

                ShowIfobtUrineMicroalbumiReportPage(doc);

                if ((account == null || account.GenerateBmiReport) && !getPhysicianEvaluatedTest)
                {
                    LoadBmiValue(doc, viewData.Customer);
                }

                if ((account != null && !account.ShowBasicBiometricPage) || getPhysicianEvaluatedTest)
                {
                    var basicBiometricSection = doc.DocumentNode.SelectSingleNode("//div[@id='basic-biometric-report']");
                    if (basicBiometricSection != null)
                        basicBiometricSection.SetAttributeValue("style", "display:none");
                }
                else
                {
                    SetBasicBiometric(viewData.BasicBiometric, viewData.EventDate, removeLongDescription, doc);

                    ShowBasicBiometricReportPage(doc);
                }

                //Check has any section to diaplay
                var selectNodes = doc.DocumentNode.SelectNodes("//div[contains(@id,'rpp-section')][@style='display:block;']");
                var testNotPerformedSection = doc.DocumentNode.SelectSingleNode("//div[@id='TestNotPerformed'][@style='display:block;']");
                if (selectNodes != null && selectNodes.Any()) //
                {
                    hasSectionToDisplay = true;
                }
                //else if (testNotPerformedSection != null)
                //{
                //    var testNotPerformedPages = doc.DocumentNode.SelectNodes("//div[@id='TestNotPerformed']/div[@class='mainContainer-wopb tnp-pagebreak-before']");
                //    if (testNotPerformedPages != null && testNotPerformedPages.Any())
                //    {
                //        var firstSection = testNotPerformedPages[0];
                //        if (firstSection != null)
                //        {
                //            firstSection.SetAttributeValue("class", "mainContainer-wopb");
                //        }
                //    }

                //    hasSectionToDisplay = true;
                //}

                var logoNode = doc.DocumentNode.SelectNodes("//img[@id='logo-company']");
                if (logoNode != null)
                {
                    foreach (var node in logoNode)
                        node.SetAttributeValue("src", StringforContentDirectory + "/" + _settings.LargeLogoFileName);
                }

                logoNode = doc.DocumentNode.SelectNodes("//img[@id='small-logo']");
                if (logoNode != null)
                {
                    foreach (var node in logoNode)
                        node.SetAttributeValue("src", StringforContentDirectory + "/" + _settings.SmallLogoFileName);
                }

                logoNode = doc.DocumentNode.SelectNodes("//img[@id='medium-logo']");
                if (logoNode != null)
                {
                    foreach (var node in logoNode)
                        node.SetAttributeValue("src", StringforContentDirectory + "/" + _settings.MediumLogoFileName);
                }

                HtmlNode customerName = doc.DocumentNode.SelectSingleNode("//span[@id='customerNameSpan']");
                if (customerName != null) customerName.InnerHtml = viewData.Customer.NameAsString;

                customerName = doc.DocumentNode.SelectSingleNode("//span[@id='address-customer-name']");
                if (customerName != null) customerName.InnerHtml = viewData.Customer.NameAsString;

                HtmlNode eventDate = doc.DocumentNode.SelectSingleNode("//span[@id='eventDateSpan']");
                if (eventDate != null) eventDate.InnerHtml = viewData.EventDate.ToShortDateString();

                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='businessAddress']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.Address1 + ", " + _settings.City + ", " + _settings.State;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='businessAddress-frontpage']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.Address1 + ", " + _settings.City + ", " + _settings.State;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='businessAddresswithZip-frontpage']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.Address1 + ", " + _settings.City + ", " + _settings.State + "-" + _settings.ZipCode;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='siteUrl']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.SiteUrl;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='siteUrl-frontpage']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.SiteUrl;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='tollFreeNumber']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.PhoneTollFree;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='tollFreeNumber-frontpage']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.PhoneTollFree;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='fullBusinessName']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.FullBusinessName;

                //SetEvaluatingPhysicianInfo(viewData.Physicians);

                if (_settings.IncludeCustomerSectioninPremiumResultReport)
                {
                    SetEventCustomerInfo(viewData, doc);
                }


                if (copyMedia)
                {
                    _copyMediaResultPdfHelper.CopyOverSupportDirectorytotheDestination(saveFilePath, _htmlFilePathPremiumVersion, viewData.Physicians, copySupportMediaOtherThanPhysician: copySupportMedia);

                    if (_settings.CopyOverMediainPremiumResultReport)
                    {
                        var resultMedia = new List<ResultMedia>();

                        var aaaTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AAA) as AAATestResult;
                        if (aaaTestResult != null && aaaTestResult.ResultImages != null && aaaTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(aaaTestResult.ResultImages);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(aaaTestResult.ResultImages, "aaaimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.AAA).Name, doc);
                        }

                        var hcpAaaTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.HCPAAA) as HcpAaaTestResult;
                        if (hcpAaaTestResult != null && hcpAaaTestResult.ResultImages != null && hcpAaaTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(hcpAaaTestResult.ResultImages);
                        }

                        var awvAaaTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvAAA) as AwvAaaTestResult;
                        if (awvAaaTestResult != null && awvAaaTestResult.ResultImages != null && awvAaaTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(awvAaaTestResult.ResultImages);
                        }
                        var ppAaaTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.PPAAA) as PpAaaTestResult;
                        if (ppAaaTestResult != null && ppAaaTestResult.ResultImages != null && ppAaaTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(ppAaaTestResult.ResultImages);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(ppAaaTestResult.ResultImages, "Ppaaaimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.PPAAA).Name, doc);
                        }

                        var strokeTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Stroke) as StrokeTestResult;
                        if (strokeTestResult != null && strokeTestResult.ResultImages != null && strokeTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(strokeTestResult.ResultImages);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(strokeTestResult.ResultImages, "strokeimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.Stroke).Name, doc);
                        }

                        var leadTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Lead) as LeadTestResult;
                        if (leadTestResult != null && leadTestResult.ResultImages != null && leadTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(leadTestResult.ResultImages);
                        }

                        var echoTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Echocardiogram) as EchocardiogramTestResult;
                        if (echoTestResult != null && echoTestResult.Media != null && echoTestResult.Media.Count > 0)
                        {
                            resultMedia.AddRange(echoTestResult.Media);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(echoTestResult.Media, "echoimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.Echocardiogram).Name, doc);
                        }

                        var ppEchoTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.PPEcho) as PpEchocardiogramTestResult;
                        if (ppEchoTestResult != null && ppEchoTestResult.Media != null && ppEchoTestResult.Media.Count > 0)
                        {
                            resultMedia.AddRange(ppEchoTestResult.Media);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(ppEchoTestResult.Media, "Ppechoimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.PPEcho).Name, doc);
                        }

                        var awvEchoTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvEcho) as AwvEchocardiogramTestResult;
                        if (awvEchoTestResult != null && awvEchoTestResult.Media != null && awvEchoTestResult.Media.Count > 0)
                        {
                            resultMedia.AddRange(awvEchoTestResult.Media);
                        }

                        var hcpEchoTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.HCPEcho) as HcpEchocardiogramTestResult;
                        if (hcpEchoTestResult != null && hcpEchoTestResult.Media != null && hcpEchoTestResult.Media.Count > 0)
                        {
                            resultMedia.AddRange(hcpEchoTestResult.Media);
                        }
                        var imtTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.IMT) as ImtTestResult;
                        if (imtTestResult != null && imtTestResult.ResultMedia != null && imtTestResult.ResultMedia.Any())
                        {
                            resultMedia.AddRange(imtTestResult.ResultMedia);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(imtTestResult.ResultMedia, "imtimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.IMT).Name, doc);
                        }
                        var thyroidTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Thyroid) as ThyroidTestResult;
                        if (thyroidTestResult != null && thyroidTestResult.ResultMedia != null && thyroidTestResult.ResultMedia.Any())
                        {
                            resultMedia.AddRange(thyroidTestResult.ResultMedia);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(thyroidTestResult.ResultMedia, "thyroidimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.Thyroid).Name, doc);
                        }

                        var pulmonaryTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.PulmonaryFunction) as PulmonaryFunctionTestResult;
                        if (pulmonaryTestResult != null && pulmonaryTestResult.ResultImage != null)
                        {
                            resultMedia.Add(pulmonaryTestResult.ResultImage);
                            _copyMediaResultPdfHelper.SetMediaForTestResult(new List<ResultMedia> { pulmonaryTestResult.ResultImage }, "pulmonaryimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.PulmonaryFunction).Name, doc);
                        }

                        _copyMediaResultPdfHelper.CopyOverMedia(eventData.Id, customer.CustomerId, saveFilePath, resultMedia);
                        _copyMediaResultPdfHelper.CopyOverEkgGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.EKG) as EKGTestResult);
                        _copyMediaResultPdfHelper.CopyOverAwvEkgGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvEkg) as AwvEkgTestResult);
                        _copyMediaResultPdfHelper.CopyOverAwvEkgIppeGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvEkgIPPE) as AwvEkgIppeTestResult);
                        _copyMediaResultPdfHelper.CopyOverSpiroGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Spiro) as SpiroTestResult);
                        _copyMediaResultPdfHelper.CopyOverAwvSpiroGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvSpiro) as AwvSpiroTestResult);
                        _copyMediaResultPdfHelper.CopyOverFloChecAbiPdf(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.FloChecABI) as FloChecABITestResult);
                        _copyMediaResultPdfHelper.CopyOverQuantaFloABIPdf(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.QuantaFloABI) as QuantaFloABITestResult);
                    }
                    else
                    {
                        _copyMediaResultPdfHelper.CopyOverEkgGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.EKG) as EKGTestResult);
                        _copyMediaResultPdfHelper.CopyOverAwvEkgGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvEkg) as AwvEkgTestResult);
                        _copyMediaResultPdfHelper.CopyOverAwvEkgIppeGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvEkgIPPE) as AwvEkgIppeTestResult);
                        _copyMediaResultPdfHelper.CopyOverSpiroGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Spiro) as SpiroTestResult);
                        _copyMediaResultPdfHelper.CopyOverAwvSpiroGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvSpiro) as AwvSpiroTestResult);
                        _copyMediaResultPdfHelper.CopyOverFloChecAbiPdf(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.FloChecABI) as FloChecABITestResult);
                        _copyMediaResultPdfHelper.CopyOverQuantaFloABIPdf(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.QuantaFloABI) as QuantaFloABITestResult);
                    }
                }

                if (reportWithImages)
                {
                    var aaaTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AAA) as AAATestResult;
                    if (aaaTestResult != null && aaaTestResult.ResultImages != null && aaaTestResult.ResultImages.Count > 0)
                    {
                        _copyMediaResultPdfHelper.SetMediaForTestResult(aaaTestResult.ResultImages, "aaaimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.AAA).Name, doc);
                    }

                    var strokeTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Stroke) as StrokeTestResult;
                    if (strokeTestResult != null && strokeTestResult.ResultImages != null && strokeTestResult.ResultImages.Count > 0)
                    {
                        _copyMediaResultPdfHelper.SetMediaForTestResult(strokeTestResult.ResultImages, "strokeimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.Stroke).Name, doc);
                    }

                    var imtTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.IMT) as ImtTestResult;
                    if (imtTestResult != null && imtTestResult.ResultMedia != null && imtTestResult.ResultMedia.Any())
                    {
                        _copyMediaResultPdfHelper.SetMediaForTestResult(imtTestResult.ResultMedia, "imtimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.IMT).Name, doc);
                    }
                    var thyroidTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Thyroid) as ThyroidTestResult;
                    if (thyroidTestResult != null && thyroidTestResult.ResultMedia != null && thyroidTestResult.ResultMedia.Any())
                    {
                        _copyMediaResultPdfHelper.SetMediaForTestResult(thyroidTestResult.ResultMedia, "thyroidimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.Thyroid).Name, doc);
                    }

                    var pulmonaryTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.PulmonaryFunction) as PulmonaryFunctionTestResult;
                    if (pulmonaryTestResult != null && pulmonaryTestResult.ResultImage != null)
                    {

                        _copyMediaResultPdfHelper.SetSingleMediaForTestResult(pulmonaryTestResult.ResultImage, "pulmonaryimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.PulmonaryFunction).Name, doc);
                    }

                    var echoTestResult = viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Echocardiogram) as EchocardiogramTestResult;
                    if (echoTestResult != null && echoTestResult.Media != null && echoTestResult.Media.Count > 0)
                    {
                        _copyMediaResultPdfHelper.SetMediaForTestResult(echoTestResult.Media, "echoimagesectiondiv", viewData.TestsPurchased.SingleOrDefault(t => t.Id == (int)TestType.Echocardiogram).Name, doc);
                    }

                    _copyMediaResultPdfHelper.CopyOverEkgGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.EKG) as EKGTestResult);
                    _copyMediaResultPdfHelper.CopyOverAwvEkgGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.AwvEkg) as AwvEkgTestResult);
                    _copyMediaResultPdfHelper.CopyOverSpiroGraph(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.Spiro) as SpiroTestResult);
                    _copyMediaResultPdfHelper.CopyOverFloChecAbiPdf(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.FloChecABI) as FloChecABITestResult);
                    _copyMediaResultPdfHelper.CopyOverQuantaFloABIPdf(eventData.Id, customer.CustomerId, saveFilePath, viewData.ScreeningResult.SingleOrDefault(sr => sr.TestType == TestType.QuantaFloABI) as QuantaFloABITestResult);
                }

                if (_settings.IncludeHealthAssesmentForm)
                {
                    //SetCustomerDataforHealthAssesmentForm(viewData.Customer);
                    //SetHealthAssesmentFormSection(customerId);
                }

                _copyMediaResultPdfHelper.UpdateHTMLWithImages(doc);
                if (isPhysicianPartnerCustomer)
                    UpdatePhysicianPartnerCustomerInformation(viewData, doc);

                if ((account != null && !account.ShowBasicBiometricPage) || getPhysicianEvaluatedTest)
                    RemovePageBreakForLastSection(doc);

                ShowHideHeaderImage(doc, showHeaderImageInReport);

                doc.Save(saveFilePath);
            }
            catch (Exception)
            {
                throw;
            }

            return hasSectionToDisplay;
        }

        public void CopySupportMediaFiles(string saveFilePath, bool copySupportMediaOtherThanPhysician)
        {
            _copyMediaResultPdfHelper.CopyOverSupportDirectorytotheDestination(saveFilePath, _htmlFilePathPremiumVersion, null, copySupportMediaOtherThanPhysician: copySupportMediaOtherThanPhysician);
        }

        private void UpdatePhysicianPartnerCustomerInformation(CustomerScreeningViewData viewData, HtmlDocument doc)
        {
            if (viewData == null) return;
            var customer = viewData.Customer;
            var selectedNodes = doc.DocumentNode.SelectNodes("//div[@class='ppCustomername']");
            if (!selectedNodes.IsNullOrEmpty())
            {
                foreach (var selectedNode in selectedNodes)
                {
                    selectedNode.InnerHtml = customer.Name.LastName + "," + customer.Name.FirstName;
                }
            }

            selectedNodes = doc.DocumentNode.SelectNodes("//div[@class='ppMemberId']");
            if (!selectedNodes.IsNullOrEmpty())
            {
                foreach (var selectedNode in selectedNodes)
                {
                    selectedNode.InnerHtml = customer.InsuranceId;
                }
            }
            selectedNodes = doc.DocumentNode.SelectNodes("//div[@class='ppCustomerDob']");
            if (!selectedNodes.IsNullOrEmpty())
            {
                foreach (var selectedNode in selectedNodes)
                {
                    selectedNode.InnerHtml = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value.Date.ToShortDateString() : "";
                }
            }
            selectedNodes = doc.DocumentNode.SelectNodes("//div[@class='ppCustomerDos']");
            if (!selectedNodes.IsNullOrEmpty())
            {
                foreach (var selectedNode in selectedNodes)
                {
                    selectedNode.InnerHtml = viewData.EventDate.Date.ToShortDateString();
                }
            }
        }

        public void CreatePacketIndexPage(string saveFilePath, Customer customer, Event eventdata)
        {
            var repository = _customerScreeningViewDataRepository;
            CustomerScreeningViewData viewData = repository.GetCustomerScreeningViewData(customer.CustomerId, eventdata.Id);

            if (viewData == null) throw new Exception("Data not found in database.");

            try
            {
                _eventId = eventdata.Id;
                _customerId = customer.CustomerId;

                _loadImages = true;
                var doc = new HtmlDocument();
                doc.Load(_htmlFilePathIndexPage);

                _isMale = true;
                if (viewData.Customer.Gender == Gender.Female)
                    _isMale = false;

                var eventCustomerResultBloodLab = _eventCustomerResultBloodLabRepository.GetByEventIdAndCustomerId(eventdata.Id, customer.CustomerId);
                var isFromNewBloodLab = false;
                if (eventCustomerResultBloodLab != null)
                    isFromNewBloodLab = eventCustomerResultBloodLab.IsFromNewLab;

                //var eventCustomerResultBloodLabParser = _eventCustomerResultBloodLabParserRepository.GetByEventIdAndCustomerId(eventdata.Id, customer.CustomerId);
                //var isHanson = false;
                //if (eventCustomerResultBloodLabParser != null)
                //    isHanson = eventCustomerResultBloodLabParser.IsActive;
                var isHanson = true;

                var account = _corporateAccountRepository.GetbyEventId(eventdata.Id);
                var showUnreadableTest = account != null && account.AttachUnreadableTest;

                LoadTestResults(viewData.ScreeningResult, viewData.TestsPurchased, false, null, false, false, eventdata, customer, viewData.Physicians, viewData.EventPhysicianTests, isFromNewBloodLab, showUnreadableTest, null, null, doc, account, isHanson);
                SetBasicBiometric(viewData.BasicBiometric, viewData.EventDate, false, doc);

                HtmlNode signatureImage = doc.DocumentNode.SelectSingleNode("//img[@id='docSignature']");
                if (signatureImage != null) signatureImage.SetAttributeValue("src", _mediaRepository.GetPhysicianSignatureMediaFileLocation().Url + viewData.Physicians.First().PhysicianSignatureFilePath);

                var logoNode = doc.DocumentNode.SelectSingleNode("//img[@id='logo-company']");
                if (logoNode != null) logoNode.SetAttributeValue("src", StringforContentDirectory + "/" + _settings.MediumLogoFileName);

                SetEventCustomerInfo(viewData, doc);

                HtmlNode orgAddress = doc.DocumentNode.SelectSingleNode("//div[@id='businessAddress']");
                if (orgAddress != null) orgAddress.InnerHtml = _settings.Address1 + ", " + _settings.City + ", " + _settings.State;

                HtmlNode selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='siteUrl']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.SiteUrl;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='tollFreeNumber']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.PhoneTollFree;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='fullBusinessName']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.FullBusinessName;

                //SetEvaluatingPhysicianInfo(viewData.Physicians);
                _copyMediaResultPdfHelper.CopyOverSupportDirectorytotheDestination(saveFilePath, _htmlFilePathIndexPage, viewData.Physicians, true);
                doc.Save(saveFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        private DateTime GetEFaxNextDueTime(DateTime schedulingTime)
        {
            var nextDueTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedulingTime.Hour,
                schedulingTime.Minute, schedulingTime.Second);

            return (nextDueTime >= DateTime.Now) ? nextDueTime : nextDueTime.AddDays(1);
        }

        public void CreateCoverLetterForPcpResultReportWithDiagnosisCode(long customerId, string saveFilePathCoverLetter, Event theEvent, long[] testIds)
        {
            if (!File.Exists(_htmlFilePathPcpCoverLetterWithDianosisCode)) return;
            var doc = new HtmlDocument();
            doc.Load(_htmlFilePathPcpCoverLetterWithDianosisCode);

            var customer = _customerRepository.GetCustomer(customerId);

            var pcp = _primaryCarePhysicianRepository.Get(customerId);

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ppName']");
            if (selectedNode != null) selectedNode.InnerHtml = pcp.Name.FullName;

            selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='pcp-addressLine']");

            if (selectedNode != null)
            {
                if (pcp.MailingAddress != null && !pcp.MailingAddress.IsEmpty())
                {
                    var addressHtml = pcp.MailingAddress.StreetAddressLine1 + ",<br />";
                    if (!string.IsNullOrEmpty(pcp.MailingAddress.StreetAddressLine2))
                    {
                        addressHtml = addressHtml + pcp.MailingAddress.StreetAddressLine2 + ",<br />";
                    }
                    addressHtml = addressHtml + pcp.MailingAddress.City + " " + pcp.MailingAddress.State + " " + pcp.MailingAddress.ZipCode.Zip + "<br />";
                    selectedNode.InnerHtml = addressHtml;
                }
                else if (pcp.Address != null && !pcp.Address.IsEmpty())
                {
                    var addressHtml = pcp.Address.StreetAddressLine1 + ",<br />";
                    if (!string.IsNullOrEmpty(pcp.Address.StreetAddressLine2))
                    {
                        addressHtml = addressHtml + pcp.Address.StreetAddressLine2 + ",<br />";
                    }
                    addressHtml = addressHtml + pcp.Address.City + " " + pcp.Address.State + " " + pcp.Address.ZipCode.Zip + "<br />";
                    selectedNode.InnerHtml = addressHtml;
                }

            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ppFax']");
            if (selectedNode != null && pcp.Fax != null) selectedNode.InnerHtml = pcp.Fax.DomesticPhoneNumber;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ppPhone']");
            if (selectedNode != null && pcp.Primary != null) selectedNode.InnerHtml = pcp.Primary.DomesticPhoneNumber;

            var selectedNodes = doc.DocumentNode.SelectNodes("//span[@class='patientName']");

            foreach (var node in selectedNodes.Where(node => node != null))
            {
                node.InnerHtml = customer.NameAsString;
            }

            var efaxTime = GetEFaxNextDueTime(_settings.FaxResultNotificationQueueTime);
            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ppDateSent']");
            if (selectedNode != null) selectedNode.InnerHtml = efaxTime.ToShortDateString();

            if (customer.DateOfBirth != null && customer.DateOfBirth.HasValue)
            {
                selectedNodes = doc.DocumentNode.SelectNodes("//span[@class='dob']");
                if (selectedNodes != null && selectedNodes.Any())
                {
                    foreach (var node in selectedNodes.Where(node => node != null))
                    {
                        node.InnerHtml = customer.DateOfBirth.Value.ToString("MM/dd/yyyy");
                    }
                }
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='eventDate']");

            if (selectedNode != null && theEvent != null)
                selectedNode.InnerHtml = theEvent.EventDate.ToShortDateString();

            SetTotalPageCountForPpReport(testIds, 2, 0, 0, doc);

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='footer-customer-name']");
            if (selectedNode != null) selectedNode.InnerHtml = customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='footer-customer-id']");
            if (selectedNode != null) selectedNode.InnerHtml = " [" + customerId + "]";

            doc.Save(saveFilePathCoverLetter);
        }

        public void CreateCoverLetterForCustomerResultReport(long customerId, string saveFilePathCoverLetter)
        {
            if (!File.Exists(_htmlFilePathCoverLetter)) return;
            var doc = new HtmlDocument();
            doc.Load(_htmlFilePathCoverLetter);

            var customer = _customerRepository.GetCustomer(customerId);

            var pcp = _primaryCarePhysicianRepository.Get(customerId);

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name']");
            if (selectedNode != null) selectedNode.InnerHtml = customer.NameAsString;

            if (customer.Address != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-line1']");
                if (selectedNode != null) selectedNode.InnerHtml = customer.Address.StreetAddressLine1;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-line2']");
                if (selectedNode != null) selectedNode.InnerHtml = !String.IsNullOrEmpty(customer.Address.StreetAddressLine2) ? ", " + customer.Address.StreetAddressLine2 : "";

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-city']");
                if (selectedNode != null) selectedNode.InnerHtml = customer.Address.City;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-state']");
                if (selectedNode != null) selectedNode.InnerHtml = customer.Address.State;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-zip']");
                if (selectedNode != null) selectedNode.InnerHtml = customer.Address.ZipCode.Zip;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='pcp-info']");
            if (selectedNode != null)
            {
                if (pcp != null && pcp.Address != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-name']");
                    if (selectedNode != null) selectedNode.InnerHtml = pcp.Name.FullName;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-address-line1']");
                    if (selectedNode != null) selectedNode.InnerHtml = pcp.Address.StreetAddressLine1;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-address-line2']");
                    if (selectedNode != null) selectedNode.InnerHtml = !String.IsNullOrEmpty(pcp.Address.StreetAddressLine2) ? ", " + pcp.Address.StreetAddressLine2 : "";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-address-city']");
                    if (selectedNode != null) selectedNode.InnerHtml = pcp.Address.City;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-address-state']");
                    if (selectedNode != null) selectedNode.InnerHtml = pcp.Address.State;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-address-zip']");
                    if (selectedNode != null) selectedNode.InnerHtml = pcp.Address.ZipCode.Zip;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='patient-name']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = customer.NameAsString;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='customer-info-cover']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none;");
                }
                else
                {
                    selectedNode.SetAttributeValue("style", "display:none;");
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='patient-info']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none;");
                }
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='footer-customer-name']");
            if (selectedNode != null) selectedNode.InnerHtml = customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='footer-customer-id']");
            if (selectedNode != null) selectedNode.InnerHtml = " [" + customer.CustomerId + "]";

            doc.Save(saveFilePathCoverLetter);
        }

        private bool HasPCPInfo(PrimaryCarePhysician pcp, bool isForPcp)
        {
            if (isForPcp)
                return pcp != null && pcp.Name != null && (pcp.MailingAddress != null || pcp.Address != null);

            return pcp != null && pcp.Name != null;
        }

        public void CreateCoverLetterForPcpResultReport(long customerId, string saveFilePathCoverLetter, long corporateAccountId, bool generatePcpletter, bool isPcpLetterUploaded, bool isForPcp)
        {
            var pcp = _primaryCarePhysicianRepository.Get(customerId);

            if (!File.Exists(_htmlFilePathPcpCoverLetter)) return;

            var doc = new HtmlDocument();
            doc.Load(_htmlFilePathPcpCoverLetter);

            HtmlNode selectedNode;

            if (HasPCPInfo(pcp, isForPcp))
            {
                var mailingAddress = pcp.MailingAddress ?? pcp.Address;

                var pcpFullName = pcp.Name.FullName;
                if (!pcpFullName.ToLower().StartsWith("dr ") && !pcpFullName.ToLower().StartsWith("dr."))
                {
                    pcpFullName = "Dr. " + pcpFullName;
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='physicianName']");
                if (selectedNode != null) selectedNode.InnerHtml = pcp.Name.FullName;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='pcp-coverletter-address']");

                if (mailingAddress != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-name']");
                    if (selectedNode != null) selectedNode.InnerHtml = pcpFullName;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-line1']");
                    if (selectedNode != null) selectedNode.InnerHtml = mailingAddress.StreetAddressLine1;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-line2']");
                    if (selectedNode != null)
                    {
                        if (!string.IsNullOrEmpty(mailingAddress.StreetAddressLine2))
                            selectedNode.InnerHtml = "<br />" + mailingAddress.StreetAddressLine2;
                        else
                            selectedNode.SetAttributeValue("style", "display:none");
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-city']");
                    if (selectedNode != null) selectedNode.InnerHtml = mailingAddress.City;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-state']");
                    if (selectedNode != null) selectedNode.InnerHtml = mailingAddress.State;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-zip']");
                    if (selectedNode != null) selectedNode.InnerHtml = mailingAddress.ZipCode.Zip;
                }
                else
                {
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");
                }

            }
            else if (isForPcp)
            {
                //Setting Customer address as Physician Address.

                var customer = _customerRepository.GetCustomer(customerId);

                if (customer.Address != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-name']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.NameAsString;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-line1']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.StreetAddressLine1;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-line2']");
                    if (selectedNode != null)
                    {
                        if (!string.IsNullOrEmpty(customer.Address.StreetAddressLine2))
                            selectedNode.InnerHtml = "<br />" + customer.Address.StreetAddressLine2;
                        else
                            selectedNode.SetAttributeValue("style", "display:none");
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-city']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.City;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-state']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.State;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pcp-coverletter-address-zip']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.ZipCode.Zip;
                }

            }

            SetReturnAddressOnPcpCoverLetter(doc);
            var pcpLetter = doc.DocumentNode.SelectSingleNode("//div[@id='pcp-letter']");

            if (generatePcpletter && !isPcpLetterUploaded)
            {
                if (pcpLetter != null)
                {
                    pcpLetter.SetAttributeValue("style", "display:block;");
                }
                var customer = _customerRepository.GetCustomer(customerId);
                var organization = _organizationRepository.GetOrganizationbyId(corporateAccountId);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='patientName']");
                if (selectedNode != null) selectedNode.InnerHtml = customer.Name.FullName;

                if (organization != null)
                {
                    //Coroporate Logo
                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='corporatelogo']");
                    if (organization.LogoImageId > 0)
                    {
                        var fileName = _fileRepository.GetById(organization.LogoImageId).Path;
                        var filePath = _mediaRepository.GetOrganizationLogoImageFolderLocation().Url + fileName;

                        if (selectedNode != null)
                        {
                            selectedNode.SetAttributeValue("src", filePath);
                        }
                    }
                    else
                    {
                        selectedNode.SetAttributeValue("style", "display:none");
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='organizatinName']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = organization.Name;
                }

                //site Logo
                selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='siteLogo']");

                if (selectedNode != null)
                    selectedNode.SetAttributeValue("src", _settings.MediumLogoLocation);

            }
            else
            {
                if (pcpLetter != null)
                {
                    pcpLetter.SetAttributeValue("style", "display:none;");
                }
            }

            doc.Save(saveFilePathCoverLetter);
        }

        private void SetReturnAddressOnPcpCoverLetter(HtmlDocument doc)
        {

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='return-address-name']");
            if (selectedNode != null) selectedNode.InnerHtml = _settings.CompanyName;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='return-address-line1']");
            if (selectedNode != null) selectedNode.InnerHtml = _settings.Address1;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='return-address-line2']");
            selectedNode.InnerHtml = "<br />" + _settings.Address2;


            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='return-address-city']");
            if (selectedNode != null) selectedNode.InnerHtml = _settings.City;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='return-address-state']");
            if (selectedNode != null) selectedNode.InnerHtml = _settings.State;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='return-address-zip']");
            if (selectedNode != null) selectedNode.InnerHtml = _settings.ZipCode;

        }

        private void SetTotalPageCountForPpReport(long[] purchasedTestIds, int ppcoverletter, int basicBiometric, int doctorletter, HtmlDocument doc)
        {
            var pageCount = 0;

            if (purchasedTestIds != null)
                pageCount = purchasedTestIds.Contains((long)TestType.Spiro)
                    ? purchasedTestIds.Count() + 1
                    : purchasedTestIds.Count();

            pageCount = pageCount + basicBiometric + doctorletter + ppcoverletter;

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ppPages']");
            if (selectedNode != null) selectedNode.InnerHtml = pageCount.ToString();

        }

        public void CreateCorporateCoverLetterForPremiumPdf(long customerId, long corporateAccountId, string saveFilePathCoverLetter)
        {
            if (!File.Exists(_htmlFilePathCorporateCoverLetter)) return;

            try
            {
                var organization = _organizationRepository.GetOrganizationbyId(corporateAccountId);
                var address = _addressRepository.GetAddress(organization.BusinessAddressId);
                var doc = new HtmlDocument();
                doc.Load(_htmlFilePathCorporateCoverLetter);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='corporate-name']");
                if (selectedNode != null) selectedNode.InnerHtml = organization.Name;
                if (address != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='corporate-address1']");
                    if (selectedNode != null) selectedNode.InnerHtml = address.StreetAddressLine1 + ", <br />";

                    if (!string.IsNullOrEmpty(address.StreetAddressLine2))
                    {
                        selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='corporate-address2']");
                        if (selectedNode != null) selectedNode.InnerHtml = address.StreetAddressLine2 + ", <br />";
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='corporate-city-state-zip']");
                    if (selectedNode != null) selectedNode.InnerHtml = address.City + ", " + address.StateCode + " " + address.ZipCode.Zip + " <br />";
                }
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='corporate-phonenumber']");
                if (selectedNode != null) selectedNode.InnerHtml = organization.PhoneNumber.ToString();

                if (organization.LogoImageId > 0)
                {
                    var fileName = _fileRepository.GetById(organization.LogoImageId).Path;
                    var filePath = _mediaRepository.GetOrganizationLogoImageFolderLocation().Url + fileName;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='corporate-logo']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", filePath);
                }
                var customer = _customerRepository.GetCustomer(customerId);
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name']");
                if (selectedNode != null) selectedNode.InnerHtml = customer.NameAsString;

                if (customer.Address != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-line1']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.StreetAddressLine1;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-line2']");
                    if (selectedNode != null) selectedNode.InnerHtml = !String.IsNullOrEmpty(customer.Address.StreetAddressLine2) ? ", " + customer.Address.StreetAddressLine2 : "";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-city']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.City;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-state']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.State;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-zip']");
                    if (selectedNode != null) selectedNode.InnerHtml = customer.Address.ZipCode.Zip;
                }

                doc.Save(saveFilePathCoverLetter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetBasicBiometric(BasicBiometric basicBiometric, DateTime eventDate, bool removeLongDescription, HtmlDocument doc)
        {
            if (!_showBasicBiometric || basicBiometric == null || eventDate >= _settings.BasicBiometricCutOfDate) return;

            var basicBiometricNode = doc.DocumentNode.SelectSingleNode("//div[@id='basicBiometric-rpp-section']");

            if (basicBiometricNode != null)
            {
                basicBiometricNode.SetAttributeValue("style", "display:block;");
            }

            basicBiometricNode = doc.DocumentNode.SelectSingleNode("//div[@id='followup-section-hypertension']");

            if (basicBiometricNode != null)
            {
                //basicBiometricNode.SetAttributeValue("style", "display:block");
                basicBiometricNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }

            SetBasicBiometricVariableReportSection(basicBiometric, doc);

            var selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='systolicbp']");
            if (selectedNode != null && basicBiometric.SystolicPressure != null)
                selectedNode.SetAttributeValue("value", basicBiometric.SystolicPressure.Value.ToString());

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='diastolicbp']");
            if (selectedNode != null && basicBiometric.DiastolicPressure != null)
                selectedNode.SetAttributeValue("value", basicBiometric.DiastolicPressure.Value.ToString());

            if (basicBiometric.SystolicPressure != null || basicBiometric.DiastolicPressure != null)
            {
                if (basicBiometric.IsRightArmBpMeasurement)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='rightArmBp']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("checked", "checked");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='leftArmBp']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("checked", "checked");
                }
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='isElevatedBp']");
            if (selectedNode != null && basicBiometric.IsBloodPressureElevated)
                selectedNode.SetAttributeValue("checked", "checked");

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='pulseratebb']");
            if (selectedNode != null && basicBiometric.PulseRate != null)
                selectedNode.SetAttributeValue("value", basicBiometric.PulseRate.Value.ToString());

            AsiOverlayResults(doc, null, basicBiometric);
        }

        private void SetBasicBiometricVariableReportSection(BasicBiometric basicBiometric, HtmlDocument doc)
        {
            if (basicBiometric == null || (basicBiometric.SystolicPressure == null && basicBiometric.DiastolicPressure == null))
                return;

            var findingSystolic = StandardFindingService.GetCalculatedStandardFinding(BloodPressureStandardFindingRange.AllSystolic.ToList(), basicBiometric.SystolicPressure);
            var findingDiastolic = StandardFindingService.GetCalculatedStandardFinding(BloodPressureStandardFindingRange.AllDiastolic.ToList(), basicBiometric.DiastolicPressure);

            var finding = BloodPressureStandardFindingRange.SelectedFinding(findingDiastolic > findingSystolic ? findingDiastolic : findingSystolic);

            _resultPdfHelper.SetSummaryFindings(doc, finding, BloodPressureStandardFindingRange.AllSystolic, "finding-bloodpressure", "longdescription-bloodpressure");

        }

        private void SetEventCustomerInfo(CustomerScreeningViewData viewData, HtmlDocument doc)
        {
            HtmlNode selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='customer-name']");
            if (selectedNode != null) selectedNode.SetAttributeValue("value", viewData.Customer.NameAsString);

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='customerid']");
            if (selectedNode != null) selectedNode.SetAttributeValue("value", viewData.Customer.CustomerId.ToString());

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='eventid']");
            if (selectedNode != null) selectedNode.SetAttributeValue("value", viewData.EventId.ToString());

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='screening-location']");
            if (selectedNode != null) selectedNode.SetAttributeValue("value", viewData.HostName + ", " + viewData.ScreeningLocation);

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='screening-date']");
            if (selectedNode != null) selectedNode.SetAttributeValue("value", viewData.EventDate.ToShortDateString());

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='screenedfor-package']");
            if (selectedNode != null) selectedNode.SetAttributeValue("value", viewData.ScreeningPackage);

            if (viewData.PaymentData != null)
            {
                foreach (var payment in viewData.PaymentData)
                {
                    if (payment.PaymentType == PaymentType.Cash)
                    {
                        selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='payment-method-cash']");
                        if (selectedNode != null) selectedNode.SetAttributeValue("checked", "true");
                    }
                    else if (payment.PaymentType == PaymentType.Check)
                    {
                        selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='payment-method-check']");
                        if (selectedNode != null) selectedNode.SetAttributeValue("checked", "true");
                    }
                    else if (payment.PaymentType == PaymentType.CreditCard)
                    {
                        selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='payment-method-card']");
                        if (selectedNode != null) selectedNode.SetAttributeValue("checked", "true");
                    }
                }

                if (viewData.ChargeCards != null && viewData.ChargeCards.Count() > 0)
                {
                    string text = "";
                    var cardNumbers = viewData.ChargeCards.Select(cc => cc.Number).Distinct().ToArray();
                    foreach (var cardNumber in cardNumbers)
                    {
                        var cardType = viewData.ChargeCards.Where(cc => cc.Number == cardNumber).FirstOrDefault();
                        if (!string.IsNullOrEmpty(text))
                            text += ", " + cardType.TypeId + "(" + cardNumber.Substring(cardNumber.Length - 4, 4) + ")";
                        else
                            text += cardType.TypeId + "(" + cardNumber.Substring(cardNumber.Length - 4, 4) + ")";
                    }
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='card-number']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("value", text);
                }

                if (viewData.Checks != null && viewData.Checks.Count() > 0)
                {
                    string text = "";
                    var checkNumbers = viewData.Checks.Select(cc => cc.CheckNumber).Distinct().ToArray();
                    foreach (var checkNumber in checkNumbers)
                    {
                        if (!string.IsNullOrEmpty(text))
                            text += ", " + checkNumber.Trim();
                        else
                            text += checkNumber.Trim();
                    }
                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='check-number']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("value", text);
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='payment-amount']");
                if (selectedNode != null) selectedNode.SetAttributeValue("value", "$ " + viewData.PaymentData.Sum(p => p.Amount).ToString("0.00"));
            }
        }

        private void SetCoverLetterData(CustomerScreeningViewData viewData, HtmlDocument doc)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='current-date']");
            if (selectedNode != null) selectedNode.InnerHtml = DateTime.Now.ToShortDateString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name-cl']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name-cl1']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name-findingsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.NameAsString;

            if (viewData.Customer.Address != null)
            {
                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-streetlines']");
                if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.Address.StreetAddressLine1 + (string.IsNullOrEmpty(viewData.Customer.Address.StreetAddressLine2) ? "" : ", <br />" + viewData.Customer.Address.StreetAddressLine2);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-city']");
                if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.Address.City;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-state']");
                if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.Address.StateCode;

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='address-zip']");
                if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.Address.ZipCode.Zip;
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-date-cl']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.EventDate.ToShortDateString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-loc-cl']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.HostName.Trim();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='eventid-frontpage']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.EventId.ToString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customerid-frontpage']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.CustomerId.ToString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name-at-a-glance']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-date-at-a-glance']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.EventDate.ToShortDateString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-loc-at-a-glance']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.HostName;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name-findingsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-date-findingsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.EventDate.ToShortDateString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-loc-findingsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.HostName;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name-clinicalsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-date-clinicalsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.EventDate.ToShortDateString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-loc-clinicalsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.HostName;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='customer-name-ekgsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.Customer.NameAsString;

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-date-ekgsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.EventDate.ToShortDateString();

            selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='screening-loc-ekgsection']");
            if (selectedNode != null) selectedNode.InnerHtml = viewData.HostName;

        }

        private void ShowTestSectionDisabled(string sectionToHideId, string sectionToShowId, HtmlDocument doc)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='" + sectionToShowId + "']");
            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");

            selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='" + sectionToHideId + "']");
            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
        }

        private bool _testOnBasicBiometricPagePurchased = false;
        private void LoadTestResults(IEnumerable<TestResult> testResults, IEnumerable<Test> testPurchased, bool isTestDependent, IEnumerable<long> testIds, bool isPhysicianPartnerCustomer, bool removeLongDescription,
            Event eventData, Customer customer, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, bool isFromNewBloodLab, bool showUnreadableTest,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc, CorporateAccount account, bool getPhysicianEvaluatedTest = false, bool isHanson = true)
        {
            SetTechnicianIdNamePairs(testResults);
            var allTests = _testRepository.GetAll();

            allTests = allTests.Where(at => at.IsRecordable && at.ShowinCustomerPdf).ToList();

            if (account.IsHealthPlan)
            {
                allTests = allTests.Where(at => at.ResultEntryTypeId == null || at.ResultEntryTypeId.Value == (long)ResultEntryType.Hip).ToList();
                testPurchased = testPurchased.Where(x => x.ResultEntryTypeId == null || x.ResultEntryTypeId.Value == (long)ResultEntryType.Hip);
            }

            if (getPhysicianEvaluatedTest)
            {
                allTests = allTests.Where(at => at.IsReviewable).ToList();
                testPurchased = testPurchased.Where(x => x.IsReviewable && TestGroup.TestIdForIpPdf.Contains(x.Id) );
            }

            var showRepeatStudyCheckbox = _resultPdfHelper.ShowHideRepeatStudyCheckbox(eventData.EventDate, _eventId, _customerId);

            _testOnBasicBiometricPagePurchased = testPurchased.Any(x => TestGroup.BasicBiometricReportTestIds.Contains(x.Id));

            var hasEventPhysicianTest = eventPhysicianTests != null && eventPhysicianTests.Any();
            foreach (var test in allTests)
            {
                var testResult = testResults.FirstOrDefault(tr => tr.TestType == (TestType)test.Id);

                IEnumerable<EventPhysicianTest> testPhysicians = null;

                if (hasEventPhysicianTest)
                {
                    testPhysicians = eventPhysicianTests.Where(ept => ept.TestId == test.Id).Select(ept => ept).ToArray();
                }

                switch ((TestType)test.Id)
                {
                    case TestType.AAA:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("aaaTestResultDisabledDiv", "aaaTestResultDiv", doc);
                            LoadAaaTestresults(testResult as AAATestResult, removeLongDescription, showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='aaa-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            LoadAaaTestresults(null, removeLongDescription, showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("aaaTestResultDiv", "aaaTestResultDisabledDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='aaa-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.PPAAA:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("PpaaaTestResultDisabledDiv", "PpaaaTestResultDiv", doc);
                            LoadPpAaaTestresults(testResult as PpAaaTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='Ppaaa-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            LoadPpAaaTestresults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("PpaaaTestResultDiv", "PpaaaTestResultDisabledDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='Ppaaa-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.HCPAAA:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("HcpaaaTestResultDisabledDiv", "HcpaaaTestResultDiv", doc);
                            LoadHcpAaaTestresults(testResult as HcpAaaTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);

                        }
                        else
                        {
                            LoadHcpAaaTestresults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("HcpaaaTestResultDiv", "HcpaaaTestResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.AwvAAA:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvAaaTestResultDisabledDiv", "AwvAaaTestResultDiv", doc);
                            _awvAAAResultPdfHelper.LoadAwvAaaTestresults(doc, _eventId, _customerId, testResult as AwvAaaTestResult, removeLongDescription, _technicianIdNamePairs, _loadImages, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);

                            if (getPhysicianEvaluatedTest)
                            {
                                _generateTestPdfHelper.GenerateTestPdf(TestType.AwvAAA, testResult, eventData, customer, showUnreadableTest, removeLongDescription, _loadImages, _technicianIdNamePairs,
                                    showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, _ipResultPdfMediaLocation, StringforMediaDirectory, isPhysicianPartnerCustomer);
                            }
                        }
                        else
                        {
                            _awvAAAResultPdfHelper.LoadAwvAaaTestresults(doc, _eventId, _customerId, null, removeLongDescription, _technicianIdNamePairs, _loadImages, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("AwvAaaTestResultDiv", "AwvAaaTestResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.ASI:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("asiResultDisabledDiv", "asiResultDiv", doc);
                            LoadAsiTestResults(testResult as ASITestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            AsiOverlayResults(doc, testResult as ASITestResult, null);
                        }
                        else
                        {
                            LoadAsiTestResults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("asiResultDiv", "asiResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.EKG:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("ekgResultDisabledDiv", "ekgResultDiv", doc);
                            LoadEkgTestResults(testResult as EKGTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='ekg-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            LoadEkgTestResults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("ekgResultDiv", "ekgResultDisabledDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='ekg-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.AwvEkg:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvEkgResultDisabledDiv", "AwvEkgResultDiv", doc);
                            _awvEkgResultPdfHelper.LoadAwvEkgTestResults(doc, testResult as AwvEkgTestResult, removeLongDescription, _technicianIdNamePairs, _loadImages, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, StringforMediaDirectory);

                            if (getPhysicianEvaluatedTest)
                            {
                                _generateTestPdfHelper.GenerateTestPdf(TestType.AwvEkg, testResult, eventData, customer, showUnreadableTest, removeLongDescription, _loadImages, _technicianIdNamePairs,
                                    showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, _ipResultPdfMediaLocation, StringforMediaDirectory, isPhysicianPartnerCustomer);
                            }
                        }
                        else
                        {
                            _awvEkgResultPdfHelper.LoadAwvEkgTestResults(doc, null, removeLongDescription, _technicianIdNamePairs, _loadImages, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, StringforMediaDirectory);
                            ShowTestSectionDisabled("AwvEkgResultDiv", "AwvEkgResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.AwvEkgIPPE:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvEkgIppeResultDisabledDiv", "AwvEkgIppeResultDiv", doc);
                            LoadAwvEkgIppeTestResults(testResult as AwvEkgIppeTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadAwvEkgIppeTestResults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("AwvEkgIppeResultDiv", "AwvEkgIppeResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.Echocardiogram:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("echoResultDisabledDiv", "echoResultDiv", doc);
                            _echoResultPdfHelper.LoadEchoTestResults(doc, testResult as EchocardiogramTestResult, removeLongDescription, _loadImages, _technicianIdNamePairs, showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _echoResultPdfHelper.LoadEchoTestResults(doc, null, removeLongDescription, _loadImages, _technicianIdNamePairs, showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("echoResultDiv", "echoResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.PPEcho:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("PpechoResultDisabledDiv", "PpechoResultDiv", doc);
                            _echoResultPdfHelper.LoadPpEchoTestResults(doc, testResult as PpEchocardiogramTestResult, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _echoResultPdfHelper.LoadPpEchoTestResults(doc, null, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("PpechoResultDiv", "PpechoResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.HCPEcho:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("HcpEchoResultDisabledDiv", "HcpEchoResultDiv", doc);
                            _echoResultPdfHelper.LoadHcpEchoTestResults(doc, testResult as HcpEchocardiogramTestResult, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _echoResultPdfHelper.LoadHcpEchoTestResults(doc, null, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("HcpEchoResultDiv", "HcpEchoResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.AwvEcho:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvEchoResultDisabledDiv", "AwvEchoResultDiv", doc);
                            _echoResultPdfHelper.LoadAwvEchoTestResults(doc, testResult as AwvEchocardiogramTestResult, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, _customerId, _eventId);

                            if (getPhysicianEvaluatedTest)
                            {
                                _generateTestPdfHelper.GenerateTestPdf(TestType.AwvEcho, testResult, eventData, customer, showUnreadableTest, removeLongDescription, _loadImages, _technicianIdNamePairs,
                                    showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, _ipResultPdfMediaLocation, StringforMediaDirectory, isPhysicianPartnerCustomer);
                            }
                        }
                        else
                        {
                            _echoResultPdfHelper.LoadAwvEchoTestResults(doc, null, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, _customerId, _eventId);
                            ShowTestSectionDisabled("AwvEchoResultDisabledDiv", "AwvEchoResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.Lipid:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("lipidResultDisabledDiv", "lipidResultDiv", doc);
                            _lipidResultPdfHelper.LoadLipidResult(doc, testResult as LipidTestResult, _isMale, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _lipidResultPdfHelper.LoadLipidResult(doc, null, _isMale, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("lipidResultDiv", "lipidResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.AwvLipid:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvLipidResultDisabledDiv", "AwvLipidResultDiv", doc);
                            _lipidResultPdfHelper.LoadAwvLipidResult(doc, testResult as AwvLipidTestResult, _isMale, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _lipidResultPdfHelper.LoadAwvLipidResult(doc, null, _isMale, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("AwvLipidResultDiv", "AwvLipidResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.Cholesterol:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("CholesterolResultDisabledDiv", "CholesterolResultDiv", doc);
                            _lipidResultPdfHelper.LoadCholesterolResult(doc, testResult as CholesterolTestResult, _isMale, _technicianIdNamePairs);
                        }
                        else
                        {
                            _lipidResultPdfHelper.LoadCholesterolResult(doc, null, _isMale, _technicianIdNamePairs);
                            ShowTestSectionDisabled("CholesterolResultDiv", "CholesterolResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.AwvGlucose:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvGlucoseResultDisabledDiv", "AwvGlucoseResultDiv", doc);
                            _lipidResultPdfHelper.LoadAwvGlucoseResult(doc, testResult as AwvGlucoseTestResult, _technicianIdNamePairs);
                        }
                        else
                        {
                            _lipidResultPdfHelper.LoadAwvGlucoseResult(doc, null, _technicianIdNamePairs);
                            ShowTestSectionDisabled("AwvGlucoseResultDiv", "AwvGlucoseResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.Diabetes:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("DiabetesResultDisabledDiv", "DiabetesResultDiv", doc);
                            _lipidResultPdfHelper.LoadDiabetesResult(doc, testResult as DiabetesTestResult, _technicianIdNamePairs);
                        }
                        else
                        {
                            _lipidResultPdfHelper.LoadDiabetesResult(doc, null, _technicianIdNamePairs);
                            ShowTestSectionDisabled("DiabetesResultDiv", "DiabetesResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.PAD:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("padResultDisabledDiv", "padResultDiv", doc);
                            _abiResultPdfHelper.LoadPadTestResults(doc, testResult as PADTestResult, removeLongDescription, physicians, testPhysicians, _technicianIdNamePairs, eventCustomerPhysicianEvaluation, customerSkipReview);
                            _abiResultPdfHelper.PadOverlayResults(doc, testResult as PADTestResult);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='pad-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            _abiResultPdfHelper.LoadPadTestResults(doc, null, removeLongDescription, physicians, testPhysicians, _technicianIdNamePairs, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("padResultDiv", "padResultDisabledDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='pad-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.AwvABI:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvAbiResultDisabledDiv", "AwvAbiResultDiv", doc);
                            _abiResultPdfHelper.LoadAwvAbiTestResults(doc, testResult as AwvAbiTestResult, removeLongDescription, physicians, testPhysicians, _technicianIdNamePairs, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _abiResultPdfHelper.LoadAwvAbiTestResults(doc, null, removeLongDescription, physicians, testPhysicians, _technicianIdNamePairs, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("AwvAbiResultDiv", "AwvAbiResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.FloChecABI:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("FloChecAbiResultDisabledDiv", "FloChecAbiResultDiv", doc);
                            _abiResultPdfHelper.LoadFloChecAbiTestResults(doc, testResult as FloChecABITestResult, removeLongDescription, physicians, testPhysicians, _technicianIdNamePairs, _loadImages, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _abiResultPdfHelper.LoadFloChecAbiTestResults(doc, null, removeLongDescription, physicians, testPhysicians, _technicianIdNamePairs, _loadImages, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("FloChecAbiResultDiv", "FloChecAbiResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.Stroke:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("strokeResultDisabledDiv", "strokeResultDiv", doc);
                            _strokeResultPdfHelper.LoadStrokeTestresults(doc, testResult as StrokeTestResult, removeLongDescription, _loadImages, _technicianIdNamePairs, _eventId, _customerId, showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='stroke-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            _strokeResultPdfHelper.LoadStrokeTestresults(doc, null, removeLongDescription, _loadImages, _technicianIdNamePairs, _eventId, _customerId, showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("strokeResultDiv", "strokeResultDisabledDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='stroke-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;

                    case TestType.HCPCarotid:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("HcpCarotidResultDisabledDiv", "HcpCarotidResultDiv", doc);
                            _strokeResultPdfHelper.LoadHcpCarotidTestresults(doc, testResult as HcpCarotidTestResult, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _strokeResultPdfHelper.LoadHcpCarotidTestresults(doc, null, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("HcpCarotidResultDiv", "HcpCarotidResultDisabledDiv", doc);
                        }
                        break;

                    case TestType.AwvCarotid:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvCarotidResultDisabledDiv", "AwvCarotidResultDiv", doc);
                            _strokeResultPdfHelper.LoadAwvCarotidTestresults(testResult as AwvCarotidTestResult, removeLongDescription, doc, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _strokeResultPdfHelper.LoadAwvCarotidTestresults(null, removeLongDescription, doc, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("AwvCarotidResultDiv", "AwvCarotidResultDisabledDiv", doc);
                        }
                        break;

                    case TestType.Lead:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("leadResultDisabledDiv", "leadResultDiv", doc);
                            _leadResultPdfHelper.LoadLeadTestresults(doc, testResult as LeadTestResult, removeLongDescription, _technicianIdNamePairs, _loadImages, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, eventData.EventDate, isPhysicianPartnerCustomer);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='lead-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");

                            if (getPhysicianEvaluatedTest)
                            {
                                _generateTestPdfHelper.GenerateTestPdf(TestType.Lead, testResult, eventData, customer, showUnreadableTest, removeLongDescription, _loadImages, _technicianIdNamePairs,
                                    showRepeatStudyCheckbox, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, _ipResultPdfMediaLocation, StringforMediaDirectory, isPhysicianPartnerCustomer);
                            }
                        }
                        else
                        {
                            _leadResultPdfHelper.LoadLeadTestresults(doc, null, removeLongDescription, _technicianIdNamePairs, _loadImages, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, eventData.EventDate, isPhysicianPartnerCustomer);
                            ShowTestSectionDisabled("leadResultDiv", "leadResultDisabledDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='lead-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.A1C:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("a1cResultDisabledDiv", "a1cResultDiv", doc);
                            LoadA1CResult(testResult as HemaglobinA1CTestResult, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadA1CResult(null, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("a1cResultDiv", "a1cResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.AwvHBA1C:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvHemaglobinResultDisabledDiv", "AwvHemaglobinResultDiv", doc);
                            LoadAwvHemaglobinResult(testResult as AwvHemaglobinTestResult, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadAwvHemaglobinResult(null, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("AwvHemaglobinResultDiv", "AwvHemaglobinResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.Hemoglobin:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("HemoglobinResultDisabledDiv", "HemoglobinResultDiv", doc);
                            LoadHemoglobinResult(testResult as HemoglobinTestResult, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadHemoglobinResult(null, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("HemoglobinResultDiv", "HemoglobinResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.Thyroid:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))) && _settings.CaptureBloodTest && eventData.EventDate >= _settings.BloodTestChangeDate)
                        {
                            ShowTestSectionDisabled("thyroidResultDisableDiv", "thyroidResultdiv", doc);
                            _bloodPanelResultHelper.LoadThyroidResult(testResult as ThyroidTestResult, doc, _technicianIdNamePairs, isFromNewBloodLab);
                        }
                        else
                        {
                            _bloodPanelResultHelper.LoadThyroidResult(null, doc, _technicianIdNamePairs, isFromNewBloodLab);
                            ShowTestSectionDisabled("thyroidResultdiv", "thyroidResultDisableDiv", doc);
                        }
                        break;
                    case TestType.Psa:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))) && _settings.CaptureBloodTest && eventData.EventDate >= _settings.BloodTestChangeDate)
                        {
                            ShowTestSectionDisabled("psaResultDisableDiv", "psaResultDiv", doc);
                            _bloodPanelResultHelper.LoadPsaResult(testResult as PsaTestResult, doc, _technicianIdNamePairs, isFromNewBloodLab, isHanson);
                        }
                        else
                        {
                            _bloodPanelResultHelper.LoadPsaResult(null, doc, _technicianIdNamePairs, isFromNewBloodLab, isHanson);
                            ShowTestSectionDisabled("psaResultDiv", "psaResultDisableDiv", doc);
                        }
                        break;
                    case TestType.Crp:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))) && _settings.CaptureBloodTest && eventData.EventDate >= _settings.BloodTestChangeDate)
                        {
                            ShowTestSectionDisabled("crpResultDisableDiv", "crpResultDiv", doc);
                            _bloodPanelResultHelper.LoadCrpResult(testResult as CrpTestResult, doc, _technicianIdNamePairs, isFromNewBloodLab);
                        }
                        else
                        {
                            _bloodPanelResultHelper.LoadCrpResult(null, doc, _technicianIdNamePairs, isFromNewBloodLab);
                            ShowTestSectionDisabled("crpResultDiv", "crpResultDisableDiv", doc);
                        }
                        break;
                    case TestType.Testosterone:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))) && _settings.CaptureBloodTest && eventData.EventDate >= _settings.BloodTestChangeDate)
                        {
                            ShowTestSectionDisabled("testosteroneResultDisableDiv", "testosteroneResultDiv", doc);
                            _bloodPanelResultHelper.LoadTestosteroneResult(testResult as TestosteroneTestResult, doc, _technicianIdNamePairs, isFromNewBloodLab);
                        }
                        else
                        {
                            _bloodPanelResultHelper.LoadTestosteroneResult(null, doc, _technicianIdNamePairs, isFromNewBloodLab);
                            ShowTestSectionDisabled("testosteroneResultDiv", "testosteroneResultDisableDiv", doc);
                        }
                        break;

                    case TestType.Colorectal:
                        LoadColorectalResult(doc, testResult);
                        break;
                    case TestType.Kyn:
                        LoadKynResult(doc, testResult);
                        break;

                    case TestType.IMT:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("imtResultDisableDiv", "imtResultDiv", doc);
                            LoadImtResult(testResult as ImtTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='imt-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            LoadImtResult(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("imtResultDiv", "imtResultDisableDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='imt-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.Osteoporosis:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("osteoResultDisableDiv", "osteoResultDiv", doc);
                            LoadOsteoTestResults(testResult as OsteoporosisTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='osteo-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            LoadOsteoTestResults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("osteoResultDiv", "osteoResultDisableDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='osteo-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.AwvBoneMass:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvBoneMassResultDisableDiv", "AwvBoneMassResultDiv", doc);
                            LoadAwvBoneMassTestResults(testResult as AwvBoneMassTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadAwvBoneMassTestResults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("AwvBoneMassResultDiv", "AwvBoneMassResultDisableDiv", doc);
                        }

                        break;
                    case TestType.PulmonaryFunction:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("pulmonaryResultDisableDiv", "pulmonaryResultdiv", doc);
                            LoadPulmonaryResult(testResult as PulmonaryFunctionTestResult, doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='pulmonary-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                        }
                        else
                        {
                            LoadPulmonaryResult(null, doc);
                            ShowTestSectionDisabled("pulmonaryResultdiv", "pulmonaryResultDisableDiv", doc);

                            var selectedNode = doc.DocumentNode.SelectSingleNode("//tr[@id='pulmonary-at-a-glance']");
                            if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:none;");
                        }
                        break;
                    case TestType.Spiro:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("spiroTestResultDisabledDiv", "spiroTestResultDiv", doc);
                            LoadSpiroTestresults(testResult as SpiroTestResult, isPhysicianPartnerCustomer, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadSpiroTestresults(null, isPhysicianPartnerCustomer, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("spiroTestResultDiv", "spiroTestResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.AwvSpiro:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("AwvSpiroTestResultDisabledDiv", "AwvSpiroTestResultDiv", doc);
                            LoadAwvSpiroTestresults(testResult as AwvSpiroTestResult, removeLongDescription, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadAwvSpiroTestresults(null, removeLongDescription, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("AwvSpiroTestResultDiv", "AwvSpiroTestResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.HPylori:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("HPyloriTestResultDisabledDiv", "HPyloriTestResultDiv", doc);
                            _hPyloriResultPdfHelper.LoadHPyloriTestresults(doc, testResult as HPyloriTestResult, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _hPyloriResultPdfHelper.LoadHPyloriTestresults(doc, null, removeLongDescription, _loadImages, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("HPyloriTestResultDiv", "HPyloriTestResultDisabledDiv", doc);
                        }
                        break;
                    case TestType.VitaminD:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("VitaminDResultDisableDiv", "VitaminDResultDiv", doc);
                            _bloodPanelResultHelper.LoadVitaminDResult(testResult as VitaminDTestResult, doc, _technicianIdNamePairs, isFromNewBloodLab);
                        }
                        else
                        {
                            _bloodPanelResultHelper.LoadVitaminDResult(null, doc, _technicianIdNamePairs, isFromNewBloodLab);
                            ShowTestSectionDisabled("VitaminDResultDiv", "VitaminDResultDisableDiv", doc);
                        }
                        break;
                    case TestType.MenBloodPanel:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("MenBloodPanelResultDisableDiv", "MenBloodPanelResultDiv", doc);
                            _bloodPanelResultHelper.LoadMenBloodPanelResult(testResult as MenBloodPanelTestResult, doc, _technicianIdNamePairs, isFromNewBloodLab);
                        }
                        else
                        {
                            _bloodPanelResultHelper.LoadMenBloodPanelResult(null, doc, _technicianIdNamePairs, isFromNewBloodLab);
                            ShowTestSectionDisabled("MenBloodPanelResultDiv", "MenBloodPanelResultDisableDiv", doc);
                        }
                        break;
                    case TestType.WomenBloodPanel:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("WomenBloodPanelResultDisableDiv", "WomenBloodPanelResultDiv", doc);
                            _bloodPanelResultHelper.LoadWomenBloodPanelResult(testResult as WomenBloodPanelTestResult, doc, _technicianIdNamePairs, isFromNewBloodLab);
                        }
                        else
                        {
                            _bloodPanelResultHelper.LoadWomenBloodPanelResult(null, doc, _technicianIdNamePairs, isFromNewBloodLab);
                            ShowTestSectionDisabled("WomenBloodPanelResultDiv", "WomenBloodPanelResultDisableDiv", doc);
                        }
                        break;
                    case TestType.Hypertension:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("HypertensionResultDisableDiv", "HypertensionResultDiv", doc);
                            LoadHypertensionTestResult(testResult as HypertensionTestResult, eventData.EventDate, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadHypertensionTestResult(null, eventData.EventDate, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("HypertensionResultDiv", "HypertensionResultDisableDiv", doc);
                        }
                        break;
                    case TestType.Vision:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("VisionResultDisableDiv", "VisionResultDiv", doc);
                            LoadVisionTestResults(testResult as VisionTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadVisionTestResults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("VisionResultDiv", "VisionResultDisableDiv", doc);
                        }
                        break;

                    case TestType.RinneWeberHearing:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("RinneWeberHearingResultDisableDiv", "RinneWeberHearingResultDiv", doc);
                            LoadRinneWeberHearingTestResults(testResult as RinneWeberHearingTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadRinneWeberHearingTestResults(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("RinneWeberHearingResultDiv", "RinneWeberHearingResultDisableDiv", doc);
                        }
                        break;

                    case TestType.DiabeticNeuropathy:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("DiabeticNeuropathyResultDisableDiv", "DiabeticNeuropathyResultDiv", doc);
                            LoadDiabeticNeuropathyTestResults(testResult as DiabeticNeuropathyTestResult, removeLongDescription, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadDiabeticNeuropathyTestResults(null, removeLongDescription, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("DiabeticNeuropathyResultDiv", "DiabeticNeuropathyResultDisableDiv", doc);
                        }
                        break;
                    case TestType.PHQ9:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("PHQ9ResultDisableDiv", "PHQ9ResultDiv", doc);
                            LoadPhq9TestResult(testResult as Phq9TestResult, doc);
                        }
                        else
                        {
                            LoadPhq9TestResult(null, doc);
                            ShowTestSectionDisabled("PHQ9ResultDiv", "PHQ9ResultDisableDiv", doc);
                        }
                        break;
                    case TestType.QualityMeasures:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("QualityMeasuresResultDiv", "QualityMeasuresResultDisableDiv", doc);
                            LoadQualityMeasuresTestResult(testResult as QualityMeasuresTestResult, doc);
                        }
                        else
                        {
                            LoadQualityMeasuresTestResult(null, doc);
                            ShowTestSectionDisabled("QualityMeasuresResultDiv", "QualityMeasuresResultDisableDiv", doc);
                        }
                        break;
                    case TestType.IFOBT:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("ifobtResultDiv", "ifobtResultDisableDiv", doc);
                            LoadIFobtTestResult(testResult as IFOBTTestResult, removeLongDescription, doc);
                        }
                        else
                        {
                            LoadIFobtTestResult(null, removeLongDescription, doc);
                            ShowTestSectionDisabled("ifobtResultDiv", "ifobtResultDisableDiv", doc);
                        }
                        break;
                    case TestType.UrineMicroalbumin:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("urineMicroalbuminResultDiv", "urineMicroalbuminResultDisableDiv", doc);
                            LoadUrineMicroalbuminTestResult(testResult as UrineMicroalbuminTestResult, _isMale, removeLongDescription, doc);
                        }
                        else
                        {
                            LoadUrineMicroalbuminTestResult(null, _isMale, removeLongDescription, doc);
                            ShowTestSectionDisabled("urineMicroalbuminResultDisableDiv", "urineMicroalbuminResultDiv", doc);
                        }
                        break;
                    case TestType.Monofilament:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("monofilamentResultDiv", "monofilamentResultDisableDiv", doc);
                            LoadMonofilamentTestResult(testResult as MonofilamentTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadMonofilamentTestResult(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("monofilamentResultDisableDiv", "monofilamentResultDiv", doc);
                        }
                        break;
                    case TestType.Mammogram:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("mammogramResultDiv", "mammogramResultDisableDiv", doc);
                            LoadMammogramTestResult(testResult as MammogramTestResult, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadMammogramTestResult(null, removeLongDescription, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("mammogramResultDisableDiv", "mammogramResultDiv", doc);
                        }
                        break;
                    case TestType.Chlamydia:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("chlamydiaResultDiv", "chlamydiaResultDisableDiv", doc);
                            LoadChlamydiaTestResult(testResult as ChlamydiaTestResult, removeLongDescription, doc);
                        }
                        else
                        {
                            LoadChlamydiaTestResult(null, removeLongDescription, doc);
                            ShowTestSectionDisabled("chlamydiaResultDiv", "chlamydiaResultDisableDiv", doc);
                        }
                        break;

                    case TestType.QuantaFloABI:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("quantaFloABIResultDiv", "quantaFloABIResultDisableDiv", doc);
                            LoadQuantaFloTestResult(testResult as QuantaFloABITestResult, removeLongDescription, physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadQuantaFloTestResult(null, removeLongDescription, physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("quantaFloABIResultDiv", "quantaFloABIResultDisableDiv", doc);
                        }
                        break;
                    case TestType.DPN:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("DpnResultDisableDiv", "DpnResultDiv", doc);
                            LoadDpnTestResults(testResult as DpnTestResult, removeLongDescription, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                        }
                        else
                        {
                            LoadDpnTestResults(null, removeLongDescription, physicians, testPhysicians, showUnreadableTest, eventCustomerPhysicianEvaluation, customerSkipReview, doc);
                            ShowTestSectionDisabled("DpnResultDiv", "DpnResultDisableDiv", doc);
                        }
                        break;
                    case TestType.MyBioCheckAssessment:
                        if (testPurchased.Any(t => t.Id == test.Id && (!isTestDependent || (isTestDependent && testIds.Contains(test.Id)))))
                        {
                            ShowTestSectionDisabled("MyBioCheckResultDisableDiv", "MyBioCheckResultDiv", doc);
                            _lipidResultPdfHelper.LoadMyBioCheckResult(doc, testResult as MyBioAssessmentTestResult, _isMale, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                        }
                        else
                        {
                            _lipidResultPdfHelper.LoadMyBioCheckResult(doc, null, _isMale, _technicianIdNamePairs, physicians, testPhysicians, eventCustomerPhysicianEvaluation, customerSkipReview);
                            ShowTestSectionDisabled("MyBioCheckResultDisableDiv", "MyBioCheckResultDiv", doc);
                        }
                        break;

                }
            }
        }

        private void LoadAaaTestresults(AAATestResult testResult, bool removeLongDescription, bool showRepeatStudyCheckbox, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.AAA);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='aaa-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-aaa-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "aaa-primaryEvalPhysicianSign", "aaa-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.AAA);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.AortaSize:
                            _resultPdfHelper.SetInputBox(doc, "AortaSizeInputText", testResult.AortaSize);
                            _resultPdfHelper.SetInputBox(doc, "aortasize-aaa-summary", testResult.AortaSize);
                            break;

                        case ReadingLabels.IsSaccular:
                            _resultPdfHelper.SetCheckBox(doc, "SaccularCheckbox", testResult.Saccular);
                            break;

                        case ReadingLabels.IsFusiform:
                            _resultPdfHelper.SetCheckBox(doc, "FusiformCheckbox", testResult.Fusiform);
                            break;

                        case ReadingLabels.AortaRangeSaggitalView:
                            break;

                        case ReadingLabels.AortaRangeTransverseView:
                            break;

                        case ReadingLabels.TransverseViewDataPointOne:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "TVDatapointOneTextbox", testResult.TransverseView.FirstValue);
                            break;

                        case ReadingLabels.TransverseViewDataPointTwo:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "TVDatapointTwoTextbox", testResult.TransverseView.SecondValue);
                            break;

                        case ReadingLabels.AorticDissection:
                            _resultPdfHelper.SetCheckBox(doc, "AorticDissectionCheckbox", testResult.AorticDissection);
                            break;

                        case ReadingLabels.Plaque:
                            _resultPdfHelper.SetCheckBox(doc, "PlaqueCheckbox", testResult.Plaque);
                            break;

                        case ReadingLabels.Thrombus:
                            _resultPdfHelper.SetCheckBox(doc, "ThrombusCheckbox", testResult.Thrombus);
                            break;

                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableAaaInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyAaaInputCheck", testResult.RepeatStudy);
                            break;
                    }
                }

                _resultPdfHelper.SetCheckBox(doc, "aaaConsiderOtherModalities", testResult.ConsiderOtherModalities);
                _resultPdfHelper.SetCheckBox(doc, "aaaAdditionalImagesNeeded", testResult.AdditionalImagesNeeded);

                var maxAortaSize = GetMaxofthreeAortaValues(testResult);
                //TODO: This is a hack for U Screen Text on AAA Summary
                LoadAaaFindings(doc, testResult, testResult.Finding, testResult.AortaRangeSaggitalView, testResult.AortaRangeTransverseView, maxAortaSize, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Where(us => us.Reason == UnableToScreenReason.UnableToTechnicallyVisualize).Count() < 1 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AAA, "aaaUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techaaa", "technotesaaa", _technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAaa", "criticalAaa", "physicianRemarksAaa");
                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-aaa", _loadImages);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "aaaIncidenatlFindings");

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Count() > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-aaa']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                if (testResult.Finding != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='aaa-at-a-glance-finding']");
                    if (selectedNode != null) selectedNode.InnerHtml = testResult.Finding.Label;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='aaa-at-a-glance-result']");
                    if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                        selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='aaa-at-a-glance-findingImage']");
                    if (selectedNode != null)
                    {
                        if (testResult.Finding.Label.ToLower() == AaaNoAneurysm.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_N.png");
                        else if (testResult.Finding.Label.ToLower() == AaaAneurysm.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_A.png");
                        else
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");
                    }
                }

                if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='aaa-at-a-glance-finding']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "Unable to Screen";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='aaa-at-a-glance-result']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "N/A";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='aaa-at-a-glance-findingImage']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='aaa-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "aaaIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AAA, "aaaUnableToScreen", null);
                LoadAaaFindings(doc, null, null, null, null, null, false);
            }

            _resultPdfHelper.ShowHideRepeatStudy(doc, "aaaPhysicianrepeatstudy", showRepeatStudyCheckbox);
            _resultPdfHelper.ShowHideOtherModalitiesAdditionalImages(doc, "aaaOtherModalitiesAdditionalImagesDiv", !showRepeatStudyCheckbox);
        }

        private void LoadAaaFindings(HtmlDocument doc, AAATestResult testResult, StandardFinding<decimal?> finding = null, IEnumerable<StandardFinding<int>> aortaRangeSaggitalView = null, IEnumerable<StandardFinding<int>> aortaRangeTransverseView = null, decimal? maxAortaSize = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AAA, (int)ReadingLabels.AortaSize);

            StandardFinding<decimal?> findingForLongDescription = null;
            if (maxAortaSize.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(maxAortaSize, (int)TestType.AAA, (int)ReadingLabels.AortaSize);
                if (findingId > 0)
                    findingForLongDescription = standardFindingList.Where(sf => sf.Id == findingId).SingleOrDefault();
            }

            bool showAdditionalImagesNeeded = false;
            bool showConsiderOtherModalities = false;
            if (testResult != null)
            {
                if (testResult.AdditionalImagesNeeded != null)
                {
                    showAdditionalImagesNeeded = testResult.AdditionalImagesNeeded.Reading;
                }
                if (testResult.ConsiderOtherModalities != null)
                {
                    showConsiderOtherModalities = testResult.ConsiderOtherModalities.Reading;
                }
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAaaDiv", "long-description-aaa", findingForLongDescription, isTestPurchased, unableScreenReason, showAdditionalImagesNeeded, showConsiderOtherModalities);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "aaaFinding");

            if (finding != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='aaa-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-aaa']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            var sViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AAA, (int)ReadingLabels.AortaRangeSaggitalView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeSaggitalView, sViewStandardFindingList, "aaaSagitalView");

            var tViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AAA, (int)ReadingLabels.AortaRangeTransverseView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeTransverseView, tViewStandardFindingList, "aaaTransverseView");
        }

        private decimal? GetMaxofthreeAortaValues(AAATestResult testResult)
        {
            if (testResult == null) return null;

            var aortaValues = new decimal[3];
            int index = 0;

            if (testResult.AortaSize != null && testResult.AortaSize.Reading != null)
                aortaValues[index++] = testResult.AortaSize.Reading.Value;

            if (testResult.TransverseView != null)
            {
                if (testResult.TransverseView.FirstValue != null && testResult.TransverseView.FirstValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.FirstValue.Reading.Value;

                if (testResult.TransverseView.SecondValue != null && testResult.TransverseView.SecondValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.SecondValue.Reading.Value;
            }

            var aortaValue = aortaValues.Max();
            if (aortaValue > 0) return aortaValue;

            return null;
        }

        private void LoadAsiTestResults(ASITestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.ASI);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='asi-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "asi-primaryEvalPhysicianSign", "asi-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                if (testResult.ASI != null && testResult.ASI.Finding != null)
                {
                    LoadAsiFindings(doc, testResult.ASI.Finding, testResult.ASI.Reading, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                }
                else
                {
                    LoadAsiFindings(doc, null, null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                }

                _resultPdfHelper.SetInputBox(doc, "AsiInputtext", testResult.ASI);
                _resultPdfHelper.SetInputBox(doc, "PatternInputtext", testResult.Pattern);

                if (testResult.PressureReadings != null)
                {
                    _resultPdfHelper.SetInputBox(doc, "PulseInputtext", testResult.PressureReadings.Pulse);
                    _resultPdfHelper.SetInputBox(doc, "PulsePressureInputtext", testResult.PressureReadings.PulsePressure);
                }

                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyAsiInputCheck", testResult.RepeatStudy);

                _resultPdfHelper.SetTechnician(doc, testResult, "techasi", "technotesasi", _technicianIdNamePairs);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "asiIncidentalFinding");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.ASI, "asiUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAsi", "criticalAsi", "physicianRemarksAsi");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='asi-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadAsiFindings(doc, null, null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.ASI, "asiUnableToScreen", null);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "asiIncidentalFinding");
            }
        }

        private void LoadAsiFindings(HtmlDocument doc, StandardFinding<int?> finding, int? asiReading = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.ASI, (int)ReadingLabels.ASI);
            StandardFinding<int?> findingForLongDescription = null;
            if (asiReading.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(asiReading, (int)TestType.ASI, (int)ReadingLabels.ASI);
                if (findingId > 0)
                    findingForLongDescription = standardFindingList.Where(sf => sf.Id == findingId).SingleOrDefault();
            }

            var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='asi-rpp-resultspan']");
            if (finding != null && selectedNode != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();
                selectedNode.InnerHtml = stdFinding.Label;
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAsiDiv", "longdescription-asi", findingForLongDescription, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "asiFinding");
        }

        private void LoadEkgTestResults(EKGTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var bbbFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.EKG, (Int32)ReadingLabels.BundleBranchBlock);
            var ipFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.EKG, (Int32)ReadingLabels.InfarctionPattern);

            if (testResult != null)
            {

                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='ekg-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-ekg-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "ekg-primaryEvalPhysicianSign", "ekg-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                LoadEkgFindings(doc, testResult.Finding, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));

                _resultPdfHelper.SetInputBox(doc, "prIntervalTextbox", testResult.PRInterval);
                _resultPdfHelper.SetInputBox(doc, "ventRateTextbox", testResult.VentRate);
                _resultPdfHelper.SetInputBox(doc, "qrsDurationTextbox", testResult.QRSDuration);
                _resultPdfHelper.SetInputBox(doc, "qtIntervalTextbox", testResult.QTInterval);
                _resultPdfHelper.SetInputBox(doc, "qtcInterval", testResult.QTcInterval);

                _resultPdfHelper.SetCheckBox(doc, "ReversedLeadInputCheck", testResult.ReversedLeads);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyInputCheck", testResult.RepeatStudy);
                _resultPdfHelper.SetCheckBox(doc, "ArtifactInputCheck", testResult.Artifact);
                _resultPdfHelper.SetCheckBox(doc, "ComparetoPrevEkgInputCheck", testResult.ComparetoEkg);

                _resultPdfHelper.SetCheckBox(doc, "sinusRythmInputCheck", testResult.SinusRythm);
                _resultPdfHelper.SetCheckBox(doc, "sinusArrythmiaInputCheck", testResult.SinusArrythmia);
                _resultPdfHelper.SetCheckBox(doc, "sinusBradycardiaInputCheck", testResult.SinusBradycardia);
                _resultPdfHelper.SetCheckBox(doc, "markedInputCheck", testResult.Marked);
                _resultPdfHelper.SetCheckBox(doc, "mildInputCheck", testResult.Mild);
                _resultPdfHelper.SetCheckBox(doc, "sinusTachycardiaInputCheck", testResult.SinusTachycardia);
                _resultPdfHelper.SetCheckBox(doc, "atrialFibrillationInputCheck", testResult.AtrialFibrillation);
                _resultPdfHelper.SetCheckBox(doc, "AtrialFlutterInputCheck", testResult.AtrialFlutter);
                _resultPdfHelper.SetCheckBox(doc, "SupraventriculaCheckbox", testResult.SupraventricularArrythmia);
                _resultPdfHelper.SetCheckBox(doc, "svtInputCheck", testResult.SVT);
                _resultPdfHelper.SetCheckBox(doc, "pacInputCheck", testResult.PACs);
                _resultPdfHelper.SetCheckBox(doc, "pvcInputCheck", testResult.PVCs);
                _resultPdfHelper.SetCheckBox(doc, "PacerRythmCheckbox", testResult.PacerRythm);
                _resultPdfHelper.SetCheckBox(doc, "BundleBranchBlockCheckbox", testResult.BundleBranchBlock);

                _resultPdfHelper.SetFindingsHorizontal(doc, testResult.BundleBranchBlockFinding, bbbFindings, "bundleBranchBlockFinding", 3);

                _resultPdfHelper.SetCheckBox(doc, "qrsWideningInputCheck", testResult.QRSWidening);
                _resultPdfHelper.SetCheckBox(doc, "leftAxisInputCheck", testResult.LeftAxis);
                _resultPdfHelper.SetCheckBox(doc, "RightAxisInputCheck", testResult.RightAxis);
                _resultPdfHelper.SetCheckBox(doc, "AbnormalAxisInputCheck", testResult.AbnormalAxis);
                _resultPdfHelper.SetCheckBox(doc, "LeftInputCheck", testResult.Left);
                _resultPdfHelper.SetCheckBox(doc, "RightInputCheck", testResult.Right);
                _resultPdfHelper.SetCheckBox(doc, "LeftAnteriorfasicularBlockCheckbox", testResult.LeftAnteriorFasicularBlock);
                _resultPdfHelper.SetCheckBox(doc, "HeartBlockInputCheck", testResult.HeartBlock);
                _resultPdfHelper.SetCheckBox(doc, "TypeIInputCheck", testResult.TypeI);
                _resultPdfHelper.SetCheckBox(doc, "FirstDegreeBlockInputCheck", testResult.FirstDegreeBlock);
                _resultPdfHelper.SetCheckBox(doc, "SecondDegreeBlockInputCheck", testResult.SecondDegreeBlock);
                _resultPdfHelper.SetCheckBox(doc, "TypeIIInputCheck", testResult.TypeII);
                _resultPdfHelper.SetCheckBox(doc, "ThirdDegreeBlockInputCheck", testResult.ThirdDegreeCompleteHeartBlock);
                _resultPdfHelper.SetCheckBox(doc, "EkgVentricularCheckbox", testResult.VentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "LeftVentricularCheckbox", testResult.LeftVentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "RightVentricularCheckbox", testResult.RightVentricularHypertrophy);

                _resultPdfHelper.SetCheckBox(doc, "ProlongedQTCheckbox", testResult.ProlongedQTInterval);
                _resultPdfHelper.SetCheckBox(doc, "ISchemicSttCheckbox", testResult.IschemicSTTChanges);
                _resultPdfHelper.SetCheckBox(doc, "NonSpecificSttCheckbox", testResult.NonSpecificSTTChanges);
                _resultPdfHelper.SetCheckBox(doc, "PoorRWaveProgressionCheckbox", testResult.PoorRWaveProgression);
                _resultPdfHelper.SetCheckBox(doc, "InfarctionPatternCheckbox", testResult.InfarctionPattern);
                _resultPdfHelper.SetCheckBox(doc, "ATypicalWaveCheckbox", testResult.AtypicalQWaveLead);
                _resultPdfHelper.SetCheckBox(doc, "EkgAtrialEnlargementCheckbox", testResult.AtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "EkgLeftAtrialCheckbox", testResult.LeftAtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "EkgRightAtrialCheckbox", testResult.RightAtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "RepolarizationCheckbox", testResult.RepolarizationVariant);

                _resultPdfHelper.SetCheckBox(doc, "EkgLowVoltageCheckbox", testResult.LowVoltage);
                _resultPdfHelper.SetCheckBox(doc, "EkgLimbLeadsCheckbox", testResult.LimbLeads);
                _resultPdfHelper.SetCheckBox(doc, "EkgPrecordialLeadsCheckbox", testResult.PrecordialLeads);

                _resultPdfHelper.SetFindingsHorizontal(doc, testResult.InfarctionPatternFinding, ipFindings, "infarctionPatternFinding", 2);

                if (testResult.Finding != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ekg-at-a-glance-finding']");
                    if (selectedNode != null) selectedNode.InnerHtml = testResult.Finding.Label;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ekg-at-a-glance-result']");
                    if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                        selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='ekg-at-a-glance-findingImage']");
                    if (selectedNode != null)
                    {
                        if (testResult.Finding.Label.ToLower() == EkgNormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_N.png");
                        else if (testResult.Finding.Label.ToLower() == EkgAbnormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_A.png");
                        else
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");
                    }

                }
                if (testResult.ResultImage != null)
                {
                    _resultPdfHelper.LoadTestMedia(doc, new[] { testResult.ResultImage }, "testmedia-ekg", _loadImages);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='EKGReport']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block");
                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='ekgGraph']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("src", StringforMediaDirectory + "/" + testResult.ResultImage.File.Path);
                }

                _resultPdfHelper.SetTechnician(doc, testResult, "techEkg", "technotesekg", _technicianIdNamePairs);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.EKG, "ekgUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpEkg", "criticalEkg", "ekgPhysicianNotesTextbox");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='div-bradycardia-tachycardia']");
                if (selectedNode != null)
                {
                    if ((testResult.SinusBradycardia != null && testResult.SinusBradycardia.Reading) || (testResult.SinusTachycardia != null && testResult.SinusTachycardia.Reading))
                        selectedNode.SetAttributeValue("style", "display:block;");
                    else
                        selectedNode.SetAttributeValue("style", "display:none;");

                }
                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='div-bradycardia']");
                if (selectedNode != null)
                {
                    if (testResult.SinusBradycardia != null && testResult.SinusBradycardia.Reading)
                        selectedNode.SetAttributeValue("style", "display:block;");
                    else
                        selectedNode.SetAttributeValue("style", "display:none;");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='div-tachycardia']");
                if (selectedNode != null)
                {
                    if (testResult.SinusTachycardia != null && testResult.SinusTachycardia.Reading)
                        selectedNode.SetAttributeValue("style", "display:block;");
                    else
                        selectedNode.SetAttributeValue("style", "display:none;");
                }

                if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ekg-at-a-glance-finding']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "Unable to Screen";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ekg-at-a-glance-result']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "N/A";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='ekg-at-a-glance-findingImage']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='unabletoscreen-ekg-checkbox']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("checked", "checked");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='ekg-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

            }
            else
            {
                LoadEkgFindings(doc, null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.EKG, "ekgUnableToScreen", null);
                _resultPdfHelper.SetFindingsHorizontal(doc, new StandardFinding<int>(), bbbFindings, "bundleBranchBlockFinding", 3);
                _resultPdfHelper.SetFindingsHorizontal(doc, new StandardFinding<int>(), ipFindings, "infarctionPatternFinding", 2);
            }

        }

        private void LoadEkgFindings(HtmlDocument doc, StandardFinding<int?> finding, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int?>(Convert.ToInt32(TestType.EKG));


            if (finding != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='ekg-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-ekg']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsEkgDiv", "longdescription-ekg", null, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsHorizontal(doc, finding, standardFindingList, "ekgFinding");
        }

        private void LoadOsteoTestResults(OsteoporosisTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='osteo-rpp-section']");
                if (selectedNode != null && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "osteo-primaryEvalPhysicianSign", "osteo-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                if (testResult.EstimatedTScore != null && testResult.EstimatedTScore.Finding != null)
                {
                    LoadOsteoFindings(doc, testResult.EstimatedTScore.Finding, testResult.EstimatedTScore.Reading, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='osteo-at-a-glance-finding-tscore']");
                    if (selectedNode != null && testResult.EstimatedTScore.Reading != null)
                        selectedNode.InnerHtml = testResult.EstimatedTScore.Reading.Value.ToString("0.00");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='osteo-at-a-glance-result']");
                    if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                        selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='osteo-at-a-glance-findingImage']");
                    if (selectedNode != null)
                    {
                        if (testResult.EstimatedTScore.Finding.Label.ToLower() == OsteoNormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMH_N.png");
                        else if (testResult.EstimatedTScore.Finding.Label.ToLower() == OsteoMild.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMH_M.png");
                        else if (testResult.EstimatedTScore.Finding.Label.ToLower() == OsteoHighRisk.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NMH_H.png");
                        else if (testResult.EstimatedTScore.Finding.Label.ToLower() == OsteoInConclusive.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication.png");
                    }
                }
                else
                    LoadOsteoFindings(doc, null, null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));

                _resultPdfHelper.SetInputBox(doc, "tscore-summary", testResult.EstimatedTScore);
                _resultPdfHelper.SetInputBox(doc, "tScoreTextbox", testResult.EstimatedTScore);

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Osteoporosis, "osteoUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpOsteo", "criticalOsteo", "physicianRemarksOsteo");
                _resultPdfHelper.SetTechnician(doc, testResult, "techOsteo", "", _technicianIdNamePairs);


                if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='osteo-at-a-glance-finding']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='osteo-at-a-glance-unabletoscreen']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='osteo-at-a-glance-result']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "N/A";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='osteo-at-a-glance-findingImage']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication.png");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='osteo-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadOsteoFindings(doc, null, null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Osteoporosis, "osteoUnableToScreen", null);
            }
        }

        private void LoadOsteoFindings(HtmlDocument doc, StandardFinding<decimal?> finding, decimal? tscore = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore);

            StandardFinding<decimal?> findingForLongDescription = null;
            if (tscore.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(tscore, (int)TestType.Osteoporosis, (int)ReadingLabels.EstimatedTScore);
                if (findingId > 0)
                    findingForLongDescription = standardFindingList.Where(sf => sf.Id == findingId).SingleOrDefault();
            }

            if (finding != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='osteo-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;
            }

            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "osteoFinding");
            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsOsteoDiv", "longdescription-osteo", findingForLongDescription, isTestPurchased, unableScreenReason);
        }

        private void LoadA1CResult(HemaglobinA1CTestResult testResult, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='a1c-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "basic-biometric-primaryEvalPhysicianSign", "basic-biometric-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                _resultPdfHelper.SetInputBox(doc, "hba1ctextbox", testResult.Hba1c);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.A1C, "a1cUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpHemaglobin", "criticalHemaglobin", "physicianRemarksHemaglobin");
                _resultPdfHelper.SetTechnician(doc, testResult, "techhba1c", "technoteshba1c", _technicianIdNamePairs);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='hba1c-rpp-resultspan']");
                if (selectedNode != null && testResult.Hba1c != null && !string.IsNullOrEmpty(testResult.Hba1c.Reading))
                    selectedNode.InnerHtml = testResult.Hba1c.Reading;
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.A1C, "a1cUnableToScreen", null);
            }
        }

        private void LoadKynResult(HtmlDocument doc, TestResult testResult)
        {
            if (testResult != null)
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Kyn, "kynUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpKyn", "criticalKyn", "physicianRemarksKyn");
                _resultPdfHelper.SetTechnician(doc, testResult, "techKyn", "technotesKyn", _technicianIdNamePairs);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Kyn, "kynUnableToScreen", null);
            }
        }

        private void LoadColorectalResult(HtmlDocument doc, TestResult testResult)
        {
            if (testResult != null)
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Colorectal, "colorectalUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpColorectal", "criticalColorectal", "physicianRemarksColorectal");
                _resultPdfHelper.SetTechnician(doc, testResult, "techColorectal", "technotesColorectal", _technicianIdNamePairs);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Colorectal, "colorectalUnableToScreen", null);
            }
        }

        private void LoadImtResult(ImtTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.IMT);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='imt-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "imt-primaryEvalPhysicianSign", "imt-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.IMT);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.QimtLeft:
                            _resultPdfHelper.SetInputBox(doc, "QIMTLeftInputText", testResult.QimtLeft);
                            break;

                        case ReadingLabels.QimtRight:
                            _resultPdfHelper.SetInputBox(doc, "QIMTRightInputText", testResult.QimtRight);
                            break;

                        case ReadingLabels.ExpectedQimt:
                            _resultPdfHelper.SetInputBox(doc, "ExceptedQIMTInputText", testResult.ExpectedQimt);
                            break;

                        case ReadingLabels.VascularAge:
                            _resultPdfHelper.SetInputBox(doc, "VASCULARAGEInputText", testResult.VascularAge);
                            _resultPdfHelper.SetInputBox(doc, "vascularage-imt-summary", testResult.VascularAge);
                            break;
                    }
                }

                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultMedia, "testmedia-imt", _loadImages);
                _resultPdfHelper.SetTechnician(doc, testResult, "techimt", "", _technicianIdNamePairs);
                _resultPdfHelper.SetFindingsVertical(doc, testResult.Finding, standardFindingList, "imtFinding");
                _resultPdfHelper.SetSummaryFindings(doc, testResult.Finding, standardFindingList, "findings-imt-div", "longdescription-imt", null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.IMT, "imtUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpImt", "criticalImt", "physicianRemarksImt");

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='imt-at-a-glance-vascular-age']");

                if (selectedNode != null && testResult.VascularAge != null)
                    selectedNode.InnerHtml = testResult.VascularAge.Reading.ToString();

                if (testResult.Finding != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='imt-at-a-glance-result']");
                    if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                        selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='imt-at-a-glance-findingImage']");
                    if (selectedNode != null)
                    {
                        if (testResult.Finding.Label.ToLower() == ImtNormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_N.png");
                        else if (testResult.Finding.Label.ToLower() == ImtAbnormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_A.png");
                        else
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");
                    }
                }
                if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='imt-at-a-glance-finding']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='imt-at-a-glance-unabletoscreen']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='imt-at-a-glance-result']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "N/A";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='imt-at-a-glance-findingImage']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='unabletoscreen-imt-checkbox']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("checked", "checked");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='imt-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

            }
            else
            {
                _resultPdfHelper.SetFindingsVertical(doc, null, standardFindingList, "imtFinding");
                _resultPdfHelper.SetSummaryFindings(doc, null, standardFindingList, "findings-imt-div", "longdescription-imt", null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.IMT, "imtUnableToScreen", null);
            }
        }

        private void LoadPulmonaryResult(PulmonaryFunctionTestResult testResult, HtmlDocument doc)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.PulmonaryFunction);

            if (testResult != null)
            {
                _resultPdfHelper.SetTechnician(doc, testResult, "techPulmonary", "", _technicianIdNamePairs);
                _resultPdfHelper.SetFindingsVertical(doc, testResult.Finding, standardFindingList, "pulmonaryFinding");
                _resultPdfHelper.SetSummaryFindings(doc, testResult.Finding, standardFindingList, "finding-pulmonary-div", "longdescription-pulmonary", null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PulmonaryFunction, "pulmonaryUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpPulmonary", "criticalPulmonary", "physicianRemarksPulmonary");

                if (testResult.Finding != null)
                {
                    var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pulmonary-at-a-glance-finding']");
                    if (selectedNode != null) selectedNode.InnerHtml = testResult.Finding.Label;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pulmonary-at-a-glance-result']");
                    if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                        selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='pulmonary-at-a-glance-findingImage']");
                    if (selectedNode != null)
                    {
                        if (testResult.Finding.Label.ToLower() == PulmonaryNormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_N.png");
                        else if (testResult.Finding.Label.ToLower() == PulmonaryAbnormal.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_A.png");
                        else
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");
                    }
                }

                if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                {
                    var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pulmonary-at-a-glance-finding']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "Unable to Screen";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='pulmonary-at-a-glance-result']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "N/A";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='pulmonary-at-a-glance-findingImage']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='unabletoscreen-pulmonary-checkbox']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("checked", "checked");
                }
            }
            else
            {
                _resultPdfHelper.SetFindingsVertical(doc, null, standardFindingList, "pulmonaryFinding");
                _resultPdfHelper.SetSummaryFindings(doc, null, standardFindingList, "finding-pulmonary-div", "longdescription-pulmonary", null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PulmonaryFunction, "pulmonaryUnableToScreen", null);
            }
        }

        private void SetTechnicianIdNamePairs(IEnumerable<TestResult> testResults)
        {
            var orgRoleUserIds = testResults.Select(tr => tr.ConductedByOrgRoleUserId).Distinct().ToArray();
            IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();

            _technicianIdNamePairs = organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds).ToList();
        }

        private void AsiOverlayResults(HtmlDocument doc, ASITestResult asiTestResult, BasicBiometric basicBiometric)
        {
            if (asiTestResult != null)
            {
                _resultPdfHelper.SetInputBox(doc, "ASI", asiTestResult.ASI);
                if (asiTestResult.Pattern != null && !string.IsNullOrEmpty(asiTestResult.Pattern.Reading))
                {
                    for (int index = 0; index < asiTestResult.Pattern.Reading.Length; index++)
                    {
                        IEnumerable<HtmlNode> selectedNodes;
                        switch (asiTestResult.Pattern.Reading.Substring(index, 1).ToUpper())
                        {
                            case "A":
                                selectedNodes = doc.DocumentNode.SelectNodes("//img[contains(@class, 'ASIPatternAImg')]");
                                if (selectedNodes != null)
                                {
                                    foreach (var selectedNode in selectedNodes)
                                    {
                                        selectedNode.SetAttributeValue("class", "black-border ASIPatternAImg");
                                    }
                                }
                                break;

                            case "B":
                                selectedNodes = doc.DocumentNode.SelectNodes("//img[contains(@class, 'ASIPatternBImg')]");
                                if (selectedNodes != null)
                                {
                                    foreach (var selectedNode in selectedNodes)
                                    {
                                        selectedNode.SetAttributeValue("class", "black-border ASIPatternBImg");
                                    }
                                }
                                break;

                            case "C":
                                selectedNodes = doc.DocumentNode.SelectNodes("//img[contains(@class, 'ASIPatternCImg')]");
                                if (selectedNodes != null)
                                {
                                    foreach (var selectedNode in selectedNodes)
                                    {
                                        selectedNode.SetAttributeValue("class", "black-border ASIPatternCImg");
                                    }
                                }
                                break;

                            case "D":
                                selectedNodes = doc.DocumentNode.SelectNodes("//img[contains(@class, 'ASIPatternDImg')]");
                                if (selectedNodes != null)
                                {
                                    foreach (var selectedNode in selectedNodes)
                                    {
                                        selectedNode.SetAttributeValue("class", "black-border ASIPatternDImg");
                                    }
                                }
                                break;

                            case "E":
                                selectedNodes = doc.DocumentNode.SelectNodes("//img[contains(@class, 'ASIPatternEImg')]");
                                if (selectedNodes != null)
                                {
                                    foreach (var selectedNode in selectedNodes)
                                    {
                                        selectedNode.SetAttributeValue("class", "black-border ASIPatternEImg");
                                    }
                                }
                                break;
                        }
                    }
                }
                if (asiTestResult.PressureReadings != null)
                {
                    _resultPdfHelper.SetInputBox(doc, "Pulse", asiTestResult.PressureReadings.Pulse);
                    _resultPdfHelper.SetInputBox(doc, "PulsePressure", asiTestResult.PressureReadings.PulsePressure);
                }
            }

            if (basicBiometric != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='Systolic']");
                if (selectedNode != null && basicBiometric.SystolicPressure != null)
                    selectedNode.SetAttributeValue("value", basicBiometric.SystolicPressure.Value.ToString());

                selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='Diastolic']");
                if (selectedNode != null && basicBiometric.DiastolicPressure != null)
                    selectedNode.SetAttributeValue("value", basicBiometric.DiastolicPressure.Value.ToString());
            }
        }

        public void CreateBloodLetterforPremiumPdf(string saveFilePathBloodLetter)
        {
            try
            {
                if (!File.Exists(_htmlFilePathBloodLetter)) return;

                var doc = new HtmlDocument();
                doc.Load(_htmlFilePathBloodLetter);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='company-address1']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.Address1;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='company-address2']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.Address2;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='company-city-state-zip']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.City + ", " + _settings.State + " " + _settings.ZipCode;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='company-tollfree']");
                if (selectedNode != null) selectedNode.InnerHtml = _settings.PhoneTollFree;

                doc.Save(saveFilePathBloodLetter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadPpAaaTestresults(PpAaaTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.PPAAA);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Ppaaa-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-Ppaaa-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "Ppaaa-primaryEvalPhysicianSign", "Ppaaa-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.PPAAA);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.AortaSize:
                            _resultPdfHelper.SetInputBox(doc, "PpAortaSizeInputText", testResult.AortaSize);
                            _resultPdfHelper.SetInputBox(doc, "aortasize-Ppaaa-summary", testResult.AortaSize);
                            break;

                        case ReadingLabels.IsSaccular:
                            _resultPdfHelper.SetCheckBox(doc, "PpSaccularCheckbox", testResult.Saccular);
                            break;

                        case ReadingLabels.IsFusiform:
                            _resultPdfHelper.SetCheckBox(doc, "PpFusiformCheckbox", testResult.Fusiform);
                            break;

                        case ReadingLabels.AortaRangeSaggitalView:
                            break;

                        case ReadingLabels.AortaRangeTransverseView:
                            break;

                        case ReadingLabels.TransverseViewDataPointOne:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "PpTVDatapointOneTextbox", testResult.TransverseView.FirstValue);
                            break;

                        case ReadingLabels.TransverseViewDataPointTwo:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "PpTVDatapointTwoTextbox", testResult.TransverseView.SecondValue);
                            break;

                        case ReadingLabels.AorticDissection:
                            _resultPdfHelper.SetCheckBox(doc, "PpAorticDissectionCheckbox", testResult.AorticDissection);
                            break;

                        case ReadingLabels.Plaque:
                            _resultPdfHelper.SetCheckBox(doc, "PpPlaqueCheckbox", testResult.Plaque);
                            break;

                        case ReadingLabels.Thrombus:
                            _resultPdfHelper.SetCheckBox(doc, "PpThrombusCheckbox", testResult.Thrombus);
                            break;

                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadablePpAaaInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyPpAaaInputCheck", testResult.RepeatStudy);
                            break;
                    }
                }



                var maxAortaSize = GetMaxofthreePpAortaValues(testResult);
                //TODO: This is a hack for U Screen Text on AAA Summary
                LoadPpAaaFindings(doc, testResult.Finding, testResult.AortaRangeSaggitalView, testResult.AortaRangeTransverseView, maxAortaSize, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Where(us => us.Reason == UnableToScreenReason.UnableToTechnicallyVisualize).Count() < 1 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PPAAA, "PpaaaUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techPpaaa", "technotesPpaaa", _technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpPpAaa", "criticalPpAaa", "physicianRemarksPpAaa");
                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-Ppaaa", _loadImages);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "PpaaaIncidenatlFindings");

                if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Count() > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//p[@id='incidentalfinding-description-Ppaaa']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block;");
                }

                if (testResult.Finding != null)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Ppaaa-at-a-glance-finding']");
                    if (selectedNode != null) selectedNode.InnerHtml = testResult.Finding.Label;

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Ppaaa-at-a-glance-result']");
                    if (selectedNode != null && testResult.ResultInterpretation.HasValue)
                        selectedNode.InnerHtml = ((ResultInterpretation)testResult.ResultInterpretation).ToString();

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='Ppaaa-at-a-glance-findingImage']");
                    if (selectedNode != null)
                    {
                        if (testResult.Finding.Label.ToLower() == AaaNoAneurysm.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_N.png");
                        else if (testResult.Finding.Label.ToLower() == AaaAneurysm.ToLower())
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NA_A.png");
                        else
                            selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");
                    }
                }

                if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Ppaaa-at-a-glance-finding']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "Unable to Screen";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Ppaaa-at-a-glance-result']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = "N/A";

                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='Ppaaa-at-a-glance-findingImage']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("src", StringforContentDirectory + "/NoIndication_NA.png");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='diagnosisCodePpAaa']");
                if (selectedNode != null && testResult.DiagnosisCode != null && !string.IsNullOrEmpty(testResult.DiagnosisCode.Reading))
                {
                    var readingList = testResult.DiagnosisCode.Reading.Split('|');
                    var stBuilder = string.Empty;
                    foreach (var reading in readingList)
                    {
                        stBuilder = stBuilder + "<br/>" + reading;
                    }
                    selectedNode.InnerHtml = stBuilder;
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='PpAaa-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "PpaaaIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.PPAAA, "PpaaaUnableToScreen", null);
                LoadPpAaaFindings(doc, null, null, null, null, false);
            }
        }

        private void LoadPpAaaFindings(HtmlDocument doc, StandardFinding<decimal?> finding = null, IEnumerable<StandardFinding<int>> aortaRangeSaggitalView = null, IEnumerable<StandardFinding<int>> aortaRangeTransverseView = null, decimal? maxAortaSize = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.PPAAA, (int)ReadingLabels.AortaSize);

            StandardFinding<decimal?> findingForLongDescription = null;
            if (maxAortaSize.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(maxAortaSize, (int)TestType.PPAAA, (int)ReadingLabels.AortaSize);
                if (findingId > 0)
                    findingForLongDescription = standardFindingList.Where(sf => sf.Id == findingId).SingleOrDefault();
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsPpAaaDiv", "long-description-Ppaaa", findingForLongDescription, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "PpaaaFinding");

            if (finding != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Ppaaa-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-Ppaaa']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            var sViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.PPAAA, (int)ReadingLabels.AortaRangeSaggitalView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeSaggitalView, sViewStandardFindingList, "PpaaaSagitalView");

            var tViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.PPAAA, (int)ReadingLabels.AortaRangeTransverseView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeTransverseView, tViewStandardFindingList, "PpaaaTransverseView");
        }

        private decimal? GetMaxofthreePpAortaValues(PpAaaTestResult testResult)
        {
            if (testResult == null) return null;

            var aortaValues = new decimal[3];
            int index = 0;

            if (testResult.AortaSize != null && testResult.AortaSize.Reading != null)
                aortaValues[index++] = testResult.AortaSize.Reading.Value;

            if (testResult.TransverseView != null)
            {
                if (testResult.TransverseView.FirstValue != null && testResult.TransverseView.FirstValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.FirstValue.Reading.Value;

                if (testResult.TransverseView.SecondValue != null && testResult.TransverseView.SecondValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.SecondValue.Reading.Value;
            }

            var aortaValue = aortaValues.Max();
            if (aortaValue > 0) return aortaValue;

            return null;
        }

        private void LoadSpiroTestresults(SpiroTestResult testResult, bool isPhysicianPartnerCustomer, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.Spiro);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-spiro-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "spiro-primaryEvalPhysicianSign", "spiro-primaryEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableSpiroInputCheck", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudySpiroInputCheck", testResult.RepeatStudy);

                _resultPdfHelper.SetCheckBox(doc, "PoorEffortSpiro", testResult.PoorEffort);
                _resultPdfHelper.SetCheckBox(doc, "RestrictiveSpiro", testResult.Restrictive);
                _resultPdfHelper.SetCheckBox(doc, "ObstructiveSpiro", testResult.Obstructive);

                _resultPdfHelper.SetTechnician(doc, testResult, "techspiro", "technotesspiro", _technicianIdNamePairs);
                _resultPdfHelper.SetFindingsVertical(doc, testResult.Finding, standardFindingList, "spiroFinding");
                _resultPdfHelper.SetSummaryFindings(doc, testResult.Finding, standardFindingList, "finding-spiro-div", "long-description-spiro", null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpSpiro", "criticalSpiro", "physicianRemarksSpiro");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Spiro, "SpiroUnableToScreen", testResult.UnableScreenReason);

                if (testResult.Finding != null)
                {
                    var stdFinding = standardFindingList.Where(f => f.Id == testResult.Finding.Id).Single();

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='spiro-rpp-resultspan']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = stdFinding.Label;
                }

                if (testResult.ResultImage != null)
                {
                    _resultPdfHelper.LoadTestMedia(doc, new[] { testResult.ResultImage }, "testmedia-spiro", _loadImages);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='SpiroReport']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block");
                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='spiroGraph']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("src", StringforMediaDirectory + "/" + testResult.ResultImage.File.Path);
                }

                if (isPhysicianPartnerCustomer)
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-patient-detail']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-description-text-div']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-right-img-div']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");
                }
                else
                {
                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-patient-detail']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:none");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-description-text-div']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-right-img-div']");
                    if (selectedNode != null)
                        selectedNode.SetAttributeValue("style", "display:block");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='spiro-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetFindingsVertical(doc, null, standardFindingList, "spiroFinding");
                _resultPdfHelper.SetSummaryFindings(doc, null, standardFindingList, "finding-spiro-div", "longdescription-spiro", null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Spiro, "spiroUnableToScreen", null);
            }
        }

        private void LoadHcpAaaTestresults(HcpAaaTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var incidentalFindings = _incidentalFindingRepository.GetAllIncidentalFinding((int)TestType.HCPAAA);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Hcpaaa-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-Hcpaaa-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "Hcpaaa-primaryEvalPhysicianSign", "Hcpaaa-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                var readings = new TestResultRepository().GetAllReadings((int)TestType.HCPAAA);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.AortaSize:
                            _resultPdfHelper.SetInputBox(doc, "HcpAortaSizeInputText", testResult.AortaSize);
                            break;

                        case ReadingLabels.TransverseViewDataPointOne:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "HcpTVDatapointOneTextbox", testResult.TransverseView.FirstValue);
                            break;

                        case ReadingLabels.TransverseViewDataPointTwo:
                            if (testResult.TransverseView != null)
                                _resultPdfHelper.SetInputBox(doc, "HcpTVDatapointTwoTextbox", testResult.TransverseView.SecondValue);
                            break;

                        case ReadingLabels.AorticDissection:
                            _resultPdfHelper.SetCheckBox(doc, "HcpAorticDissectionCheckbox", testResult.AorticDissection);
                            break;

                        case ReadingLabels.Plaque:
                            _resultPdfHelper.SetCheckBox(doc, "HcpPlaqueCheckbox", testResult.Plaque);
                            break;

                        case ReadingLabels.Thrombus:
                            _resultPdfHelper.SetCheckBox(doc, "HcpThrombusCheckbox", testResult.Thrombus);
                            break;

                        case ReadingLabels.TechnicallyLimitedbutReadable:
                            _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableHcpAaaInputCheck", testResult.TechnicallyLimitedbutReadable);
                            break;

                        case ReadingLabels.RepeatStudy:
                            _resultPdfHelper.SetCheckBox(doc, "RepeatStudyHcpAaaInputCheck", testResult.RepeatStudy);
                            break;
                    }
                }


                var maxAortaSize = GetMaxofthreeHcpAortaValues(testResult);

                //TODO: This is a hack for U Screen Text on AAA Summary
                LoadHcpAaaFindings(doc, testResult.Finding, testResult.AortaRangeSaggitalView, testResult.AortaRangeTransverseView, maxAortaSize, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 && testResult.UnableScreenReason.Where(us => us.Reason == UnableToScreenReason.UnableToTechnicallyVisualize).Count() < 1 ? testResult.UnableScreenReason.First() : null));

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HCPAAA, "HcpaaaUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetTechnician(doc, testResult, "techHcpaaa", "technotesHcpaaa", _technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpHcpAaa", "criticalHcpAaa", "physicianRemarksHcpAaa");
                _resultPdfHelper.LoadTestMedia(doc, testResult.ResultImages, "testmedia-Ppaaa", _loadImages);
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, testResult.IncidentalFindings, "HcpaaaIncidenatlFindings");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HcpAaa-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetIncidentalFindings(doc, incidentalFindings, null, "HcpaaaIncidenatlFindings");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HCPAAA, "HcpaaaUnableToScreen", null);
                LoadHcpAaaFindings(doc, null, null, null, null, false);
            }
        }

        private void LoadHcpAaaFindings(HtmlDocument doc, StandardFinding<decimal?> finding = null, IEnumerable<StandardFinding<int>> aortaRangeSaggitalView = null, IEnumerable<StandardFinding<int>> aortaRangeTransverseView = null, decimal? maxAortaSize = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.HCPAAA, (int)ReadingLabels.AortaSize);

            StandardFinding<decimal?> findingForLongDescription = null;
            if (maxAortaSize.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(maxAortaSize, (int)TestType.HCPAAA, (int)ReadingLabels.AortaSize);
                if (findingId > 0)
                    findingForLongDescription = standardFindingList.Where(sf => sf.Id == findingId).SingleOrDefault();
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsHcpAaaDiv", "long-description-Hcpaaa", findingForLongDescription, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "HcpaaaFinding");

            if (finding != null)
            {
                var stdFinding = standardFindingList.Where(f => f.Id == finding.Id).Single();

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Hcpaaa-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

            }

            var sViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeSaggitalView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeSaggitalView, sViewStandardFindingList, "HcpaaaSagitalView");

            var tViewStandardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeTransverseView);
            _resultPdfHelper.SetFindingsHorizontal(doc, aortaRangeTransverseView, tViewStandardFindingList, "HcpaaaTransverseView");
        }

        private decimal? GetMaxofthreeHcpAortaValues(HcpAaaTestResult testResult)
        {
            if (testResult == null) return null;

            var aortaValues = new decimal[3];
            int index = 0;

            if (testResult.AortaSize != null && testResult.AortaSize.Reading != null)
                aortaValues[index++] = testResult.AortaSize.Reading.Value;

            if (testResult.TransverseView != null)
            {
                if (testResult.TransverseView.FirstValue != null && testResult.TransverseView.FirstValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.FirstValue.Reading.Value;

                if (testResult.TransverseView.SecondValue != null && testResult.TransverseView.SecondValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.SecondValue.Reading.Value;
            }

            var aortaValue = aortaValues.Max();
            if (aortaValue > 0) return aortaValue;

            return null;
        }

        private void LoadAwvBoneMassTestResults(AwvBoneMassTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvBoneMass-rpp-section']");
                if (selectedNode != null && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvBoneMass-primaryEvalPhysicianSign", "AwvBoneMass-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                if (testResult.EstimatedTScore != null && testResult.EstimatedTScore.Finding != null)
                {
                    LoadAwvBoneMassFindings(doc, testResult.EstimatedTScore.Finding, testResult.EstimatedTScore.Reading, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                }
                else
                    LoadAwvBoneMassFindings(doc, null, null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));

                _resultPdfHelper.SetInputBox(doc, "AwvBoneMasstscore-summary", testResult.EstimatedTScore);
                _resultPdfHelper.SetInputBox(doc, "AwvBoneMasstScoreTextbox", testResult.EstimatedTScore);

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvBoneMass, "AwvBoneMassUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvBoneMass", "criticalAwvBoneMass", "physicianRemarksAwvBoneMass");
                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvBoneMass", "", _technicianIdNamePairs);

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvBoneMass-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                LoadAwvBoneMassFindings(doc, null, null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvBoneMass, "AwvBoneMassUnableToScreen", null);
            }
        }

        private void LoadAwvBoneMassFindings(HtmlDocument doc, StandardFinding<decimal?> finding, decimal? tscore = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore);

            StandardFinding<decimal?> findingForLongDescription = null;
            if (tscore.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(tscore, (int)TestType.AwvBoneMass, (int)ReadingLabels.EstimatedTScore);
                if (findingId > 0)
                    findingForLongDescription = standardFindingList.SingleOrDefault(sf => sf.Id == findingId);
            }

            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvBoneMass-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;
            }

            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "AwvBoneMassFinding");
            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAwvBoneMassDiv", "longdescription-AwvBoneMass", findingForLongDescription, isTestPurchased, unableScreenReason);
        }

        private void LoadAwvHemaglobinResult(AwvHemaglobinTestResult testResult, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvHemaglobin-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "basic-biometric-primaryEvalPhysicianSign", "basic-biometric-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                _resultPdfHelper.SetInputBox(doc, "AwvHemaglobintextbox", testResult.Hba1c);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvHBA1C, "AwvHemaglobinUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvHemaglobin", "criticalAwvHemaglobin", "physicianRemarksAwvHemaglobin");
                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvHemaglobin", "technotesAwvHemaglobin", _technicianIdNamePairs);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvHemaglobin-rpp-resultspan']");
                if (selectedNode != null && testResult.Hba1c != null && !string.IsNullOrEmpty(testResult.Hba1c.Reading))
                    selectedNode.InnerHtml = testResult.Hba1c.Reading;
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvHBA1C, "AwvHemaglobinUnableToScreen", null);
            }
        }

        private void LoadHemoglobinResult(HemoglobinTestResult testResult, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Hemoglobin-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "basic-biometric-primaryEvalPhysicianSign", "basic-biometric-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                _resultPdfHelper.SetInputBox(doc, "Hemoglobintextbox", testResult.Hemoglobin);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Hemoglobin, "HemoglobinUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpHemoglobin", "criticalHemoglobin", "physicianRemarksHemoglobin");
                _resultPdfHelper.SetTechnician(doc, testResult, "techHemoglobin", "technotesHemoglobin", _technicianIdNamePairs);

                selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Hemoglobin-rpp-resultspan']");
                if (selectedNode != null && testResult.Hemoglobin != null && testResult.Hemoglobin.Reading != null)
                    selectedNode.InnerHtml = testResult.Hemoglobin.Reading.Value.ToString("0.0") + " g/dL (" + testResult.Hemoglobin.Finding.Label.Replace("Male - ", "").Replace("Female - ", "") + ")";
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Hemoglobin, "HemoglobinUnableToScreen", null);
            }
        }

        private void LoadAwvSpiroTestresults(AwvSpiroTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.AwvSpiro);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvSpiro-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvSpiro-primaryEvalPhysicianSign", "AwvSpiro-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableAwvSpiroInputCheck", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyAwvSpiroInputCheck", testResult.RepeatStudy);

                _resultPdfHelper.SetCheckBox(doc, "PoorEffortAwvSpiro", testResult.PoorEffort);
                _resultPdfHelper.SetCheckBox(doc, "RestrictiveAwvSpiro", testResult.Restrictive);
                _resultPdfHelper.SetCheckBox(doc, "ObstructiveAwvSpiro", testResult.Obstructive);

                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvSpiro", "technotesAwvSpiro", _technicianIdNamePairs);
                _resultPdfHelper.SetFindingsVertical(doc, testResult.Finding, standardFindingList, "AwvSpiroFinding");
                _resultPdfHelper.SetSummaryFindings(doc, testResult.Finding, standardFindingList, "finding-AwvSpiro-div", "long-description-AwvSpiro", null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvSpiro", "criticalAwvSpiro", "physicianRemarksAwvSpiro");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvSpiro, "AwvSpiroUnableToScreen", testResult.UnableScreenReason);

                if (testResult.Finding != null)
                {
                    var stdFinding = standardFindingList.Single(f => f.Id == testResult.Finding.Id);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvSpiro-rpp-resultspan']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = stdFinding.Label;
                }

                if (testResult.ResultImage != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    _resultPdfHelper.LoadTestMedia(doc, new[] { testResult.ResultImage }, "testmedia-AwvSpiro", _loadImages);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvSpiroReport']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block");
                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='AwvSpiroGraph']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("src", StringforMediaDirectory + "/" + testResult.ResultImage.File.Path);
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvSpiro-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetFindingsVertical(doc, null, standardFindingList, "AwvSpiroFinding");
                _resultPdfHelper.SetSummaryFindings(doc, null, standardFindingList, "finding-AwvSpiro-div", "long-description-AwvSpiro", null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvSpiro, "AwvSpiroUnableToScreen", null);
            }
        }

        private void LoadAwvEkgIppeTestResults(AwvEkgIppeTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var bbbFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkgIPPE, (Int32)ReadingLabels.BundleBranchBlock);
            var ipFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.AwvEkgIPPE, (Int32)ReadingLabels.InfarctionPattern);

            if (testResult != null)
            {

                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEkgIppe-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-AwvEkgIppe-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvEkgIppe-primaryEvalPhysicianSign", "AwvEkgIppe-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                LoadAwvEkgIppeFindings(doc, testResult.Finding, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));

                _resultPdfHelper.SetInputBox(doc, "AwvEkgIppeprIntervalTextbox", testResult.PRInterval);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgIppeventRateTextbox", testResult.VentRate);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgIppeqrsDurationTextbox", testResult.QRSDuration);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgIppeqtIntervalTextbox", testResult.QTInterval);
                _resultPdfHelper.SetInputBox(doc, "AwvEkgIppeqtcInterval", testResult.QTcInterval);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeRepeatStudyInputCheck", testResult.RepeatStudy);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeArtifactInputCheck", testResult.Artifact);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeReversedLeadInputCheck", testResult.ReversedLeads);
                _resultPdfHelper.SetCheckBox(doc, "ComparetoPrevAwvEkgIppeInputCheck", testResult.ComparetoEkg);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeSinusRythmInputCheck", testResult.SinusRythm);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeSinusArrythmiaInputCheck", testResult.SinusArrythmia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeSinusBradycardiaInputCheck", testResult.SinusBradycardia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeMarkedInputCheck", testResult.Marked);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeSinusTachycardiaInputCheck", testResult.SinusTachycardia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeAtrialFibrillationInputCheck", testResult.AtrialFibrillation);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeAtrialFlutterInputCheck", testResult.AtrialFlutter);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeSupraventriculaCheckbox", testResult.SupraventricularArrythmia);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeSvtInputCheck", testResult.SVT);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppePacInputCheck", testResult.PACs);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppePvcInputCheck", testResult.PVCs);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppePacerRythmCheckbox", testResult.PacerRythm);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeBundleBranchBlockCheckbox", testResult.BundleBranchBlock);

                _resultPdfHelper.SetFindingsHorizontal(doc, testResult.BundleBranchBlockFinding, bbbFindings, "AwvEkgIppeBundleBranchBlockFinding", 3);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeQrsWideningInputCheck", testResult.QRSWidening);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeLeftAxisInputCheck", testResult.LeftAxis);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeRightAxisInputCheck", testResult.RightAxis);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeAbnormalAxisInputCheck", testResult.AbnormalAxis);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeLeftInputCheck", testResult.Left);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeRightInputCheck", testResult.Right);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeLeftAnteriorfasicularBlockCheckbox", testResult.LeftAnteriorFasicularBlock);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeHeartBlockInputCheck", testResult.HeartBlock);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeFirstDegreeBlockInputCheck", testResult.FirstDegreeBlock);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeSecondDegreeBlockCheckbox", testResult.SecondDegreeBlock);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeTypeIIInputCheck", testResult.TypeII);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeThirdDegreeBlockInputCheck", testResult.ThirdDegreeCompleteHeartBlock);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeVentricularCheckbox", testResult.VentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeLeftVentricularCheckbox", testResult.LeftVentricularHypertrophy);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeRightVentricularCheckbox", testResult.RightVentricularHypertrophy);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeProlongedQTCheckbox", testResult.ProlongedQTInterval);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeISchemicSttCheckbox", testResult.IschemicSTTChanges);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeNonSpecificSttCheckbox", testResult.NonSpecificSTTChanges);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppePoorRWaveProgressionCheckbox", testResult.PoorRWaveProgression);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeInfarctionPatternCheckbox", testResult.InfarctionPattern);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeATypicalWaveCheckbox", testResult.AtypicalQWaveLead);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeAtrialEnlargementCheckbox", testResult.AtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeLeftAtrialCheckbox", testResult.LeftAtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeRightAtrialCheckbox", testResult.RightAtrialEnlargement);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeRepolarizationCheckbox", testResult.RepolarizationVariant);

                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeLowVoltageCheckbox", testResult.LowVoltage);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppeLimbLeadsCheckbox", testResult.LimbLeads);
                _resultPdfHelper.SetCheckBox(doc, "AwvEkgIppePrecordialLeadsCheckbox", testResult.PrecordialLeads);

                _resultPdfHelper.SetFindingsHorizontal(doc, testResult.InfarctionPatternFinding, ipFindings, "AwvEkgIppeInfarctionPatternFinding", 2);

                if (testResult.ResultImage != null)
                {
                    _resultPdfHelper.LoadTestMedia(doc, new[] { testResult.ResultImage }, "testmedia-AwvEkgIppe", _loadImages);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEkgIppeReport']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("style", "display:block");
                    selectedNode = doc.DocumentNode.SelectSingleNode("//img[@id='AwvEkgIppeGraph']");
                    if (selectedNode != null) selectedNode.SetAttributeValue("src", StringforMediaDirectory + "/" + testResult.ResultImage.File.Path);
                }

                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvEkgIppe", "technotesAwvEkgIppe", _technicianIdNamePairs);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvEkgIPPE, "AwvEkgIppeUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvEkgIppe", "criticalAwvEkgIppe", "AwvEkgIppePhysicianNotesTextbox");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvEkgIppe-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

            }
            else
            {
                LoadAwvEkgIppeFindings(doc, null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvEkgIPPE, "AwvEkgIppeUnableToScreen", null);
                _resultPdfHelper.SetFindingsHorizontal(doc, new StandardFinding<int>(), bbbFindings, "AwvEkgIppeBundleBranchBlockFinding", 3);
                _resultPdfHelper.SetFindingsHorizontal(doc, new StandardFinding<int>(), ipFindings, "AwvEkgIppeInfarctionPatternFinding", 2);
            }
        }

        private void LoadAwvEkgIppeFindings(HtmlDocument doc, StandardFinding<int?> finding, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int?>(Convert.ToInt32(TestType.AwvEkgIPPE));

            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='AwvEkgIppe-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='docletter-AwvEkgIppe']");
                if (stdFinding.ResultInterpretation != null && stdFinding.ResultInterpretation.Value != (long)ResultInterpretation.Normal && selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");
            }

            _resultPdfHelper.SetSummaryFindings(doc, finding, standardFindingList, "FindingsAwvEkgIppeDiv", "longdescription-AwvEkgIppe", null, isTestPurchased, unableScreenReason);
            _resultPdfHelper.SetFindingsHorizontal(doc, finding, standardFindingList, "AwvEkgIppeFinding");
        }

        private void RemovePageBreakForLastSection(HtmlDocument doc)
        {
            var selectedSections =
                doc.DocumentNode.SelectNodes("//body/div[contains(@id,'rpp-section')][@style='display:block;']");
            if (selectedSections == null || !selectedSections.Any()) return;

            var maxItems = selectedSections.Count();

            var lastSection = selectedSections[maxItems - 1];
            if (lastSection != null)
            {
                lastSection.SetAttributeValue("class", "mainContainer-wopb");
            }
        }

        private void ShowBasicBiometricReportPage(HtmlDocument doc)
        {
            var basicbiometricreport = doc.DocumentNode.SelectSingleNode("//div[@id='basic-biometric-report']");
            if (basicbiometricreport == null) return;

            var selectNodes = doc.DocumentNode.SelectNodes("//div[@id='basic-biometric-report']//div[contains(@id,'rpp-section')][@style='display:block;']");

            if (selectNodes != null && selectNodes.Any()) //
            {
                basicbiometricreport.SetAttributeValue("style", "display:block;");
            }
            else
            {
                basicbiometricreport.SetAttributeValue("style", "display:none;");
                RemovePageBreakForLastSection(doc);
            }

        }

        private void LoadHypertensionTestResult(HypertensionTestResult hypertensionTest, DateTime eventDate, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (hypertensionTest == null) return;
            if ((hypertensionTest.UnableScreenReason != null && hypertensionTest.UnableScreenReason.Any()) || (hypertensionTest.TestNotPerformed != null && hypertensionTest.TestNotPerformed.TestNotPerformedReasonId > 0)
                || (hypertensionTest.RepeatStudy != null && hypertensionTest.RepeatStudy.Reading)) return;

            var hypertensionNode = doc.DocumentNode.SelectSingleNode("//div[@id='hypertension-rpp-section']");

            if (hypertensionNode != null)
            {
                hypertensionNode.SetAttributeValue("style", "display:" + (eventDate < _settings.BasicBiometricCutOfDate ? "none" : "block;"));
            }

            if (eventDate < _settings.BasicBiometricCutOfDate) return;

            hypertensionNode = doc.DocumentNode.SelectSingleNode("//div[@id='followup-section-hypertension']");

            if (hypertensionNode != null)
            {
                //hypertensionNode.SetAttributeValue("style", "display:block");
                hypertensionNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }

            SetHypertensionVariableReportSection(doc, hypertensionTest.Systolic, hypertensionTest.Diastolic);
            _resultPdfHelper.SetInputBox(doc, "hypertensionSystolic", hypertensionTest.Systolic);
            _resultPdfHelper.SetInputBox(doc, "hypertensionDiastolic", hypertensionTest.Diastolic);
            _resultPdfHelper.SetInputBox(doc, "hypertensionPulserate", hypertensionTest.Pulse);
            _resultPdfHelper.SetCheckBox(doc, "hypertensionElevatedBp", hypertensionTest.BloodPressureElevated);


            var selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='hypertensionRightArm']");
            if (selectedNode != null && hypertensionTest.RightArmBpMeasurement != null)
            {
                var isSelected = hypertensionTest.RightArmBpMeasurement.Reading;
                if (isSelected)
                    selectedNode.SetAttributeValue("checked", "checked");
            }

            selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='hypertensionLeftArm']");
            if (selectedNode != null && hypertensionTest.RightArmBpMeasurement != null)
            {
                var isSelected = hypertensionTest.RightArmBpMeasurement.Reading;
                if (!isSelected)
                    selectedNode.SetAttributeValue("checked", "checked");
            }
            else if (selectedNode != null)
            {
                selectedNode.SetAttributeValue("checked", "checked");
            }

            _resultPdfHelper.SetPhysicianSignature(doc, "basic-biometric-primaryEvalPhysicianSign", "basic-biometric-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);
        }

        private void SetHypertensionVariableReportSection(HtmlDocument doc, ResultReading<int?> systolicPressure, ResultReading<int?> dystolicPressure)
        {
            if ((systolicPressure == null || systolicPressure.Reading == null) && (dystolicPressure == null || dystolicPressure.Reading == null)) return;
            int findingSystolic = 0;
            int findingDiastolic = 0;
            if (systolicPressure != null)
            {
                findingSystolic = StandardFindingService.GetCalculatedStandardFinding(BloodPressureStandardFindingRange.AllSystolic.ToList(), systolicPressure.Reading);
            }

            if (dystolicPressure != null)
            {
                findingDiastolic = StandardFindingService.GetCalculatedStandardFinding(BloodPressureStandardFindingRange.AllDiastolic.ToList(), dystolicPressure.Reading);
            }

            var finding = BloodPressureStandardFindingRange.SelectedFinding(findingDiastolic > findingSystolic ? findingDiastolic : findingSystolic);

            _resultPdfHelper.SetSummaryFindings(doc, finding, BloodPressureStandardFindingRange.AllSystolic, "finding-bloodpressure", "longdescription-bloodpressure");

        }

        private void ShowHideHeaderImage(HtmlDocument doc, bool showHeaderImage)
        {
            if (showHeaderImage)
            {
                var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'test-header-image')]");
                if (nodes != null && nodes.Any())
                {
                    foreach (var node in nodes)
                    {
                        node.SetAttributeValue("style", "display:block;");
                    }
                }

                nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'test-header-text')]");
                if (nodes != null && nodes.Any())
                {
                    foreach (var node in nodes)
                    {
                        node.SetAttributeValue("style", "display:none;");
                    }
                }
            }
            else
            {
                var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'test-header-image')]");
                if (nodes != null && nodes.Any())
                {
                    foreach (var node in nodes)
                    {
                        node.SetAttributeValue("style", "display:none;");
                    }
                }

                nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'test-header-text')]");
                if (nodes != null && nodes.Any())
                {
                    foreach (var node in nodes)
                    {
                        node.SetAttributeValue("style", "display:block;");
                    }
                }
            }

        }

        private void LoadVisionTestResults(VisionTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Vision-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "Vision-primaryEvalPhysicianSign", "Vision-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                _resultPdfHelper.SetInputBox(doc, "RightEyeCylindrical", testResult.RightEyeCylindrical);
                _resultPdfHelper.SetInputBox(doc, "RightEyeSpherical", testResult.RightEyeSpherical);

                _resultPdfHelper.SetInputBox(doc, "LeftEyeCylindrical", testResult.LeftEyeCylindrical);
                _resultPdfHelper.SetInputBox(doc, "LeftEyeSpherical", testResult.LeftEyeSpherical);

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Vision, "VisionUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpVision", "criticalVision", "physicianRemarksVision");
                _resultPdfHelper.SetTechnician(doc, testResult, "techVision", "", _technicianIdNamePairs);

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Vision-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Vision, "VisionUnableToScreen", null);
            }
        }

        private void LoadRinneWeberHearingTestResults(RinneWeberHearingTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='RinneWeberHearing-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "RinneWeberHearing-primaryEvalPhysicianSign", "RinneWeberHearing-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                _resultPdfHelper.SetCheckBox(doc, "WeberNormal", testResult.WeberNormal);
                _resultPdfHelper.SetCheckBox(doc, "WeberAbnormal", testResult.WeberAbnormal);

                _resultPdfHelper.SetCheckBox(doc, "RinneNormal", testResult.RinneNormal);
                _resultPdfHelper.SetCheckBox(doc, "RinneAbnormal", testResult.RinneAbnormal);

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.RinneWeberHearing, "RinneWeberHearingUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpRinneWeberHearing", "criticalRinneWeberHearing", "physicianRemarksRinneWeberHearing");
                _resultPdfHelper.SetTechnician(doc, testResult, "techRinneWeberHearing", "", _technicianIdNamePairs);

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='RinneWeberHearing-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.RinneWeberHearing, "RinneWeberHearingUnableToScreen", null);
            }
        }

        private void LoadDiabeticNeuropathyTestResults(DiabeticNeuropathyTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.DiabeticNeuropathy);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='DiabeticNeuropathy-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "DiabeticNeuropathy-primaryEvalPhysicianSign", "DiabeticNeuropathy-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableDiabeticNeuropathyInputCheck", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyDiabeticNeuropathyInputCheck", testResult.RepeatStudy);

                _resultPdfHelper.SetInputBox(doc, "DiabeticNeuropathyAmplitudeTextbox", testResult.Amplitude);
                _resultPdfHelper.SetInputBox(doc, "DiabeticNeuropathyConductionVelocityTextbox", testResult.ConductionVelocity);

                _resultPdfHelper.SetCheckBox(doc, "DiabeticNeuropathyRightLegCheckbox", testResult.RightLeg);
                _resultPdfHelper.SetCheckBox(doc, "DiabeticNeuropathyLeftLegCheckbox", testResult.LeftLeg);

                _resultPdfHelper.SetTechnician(doc, testResult, "techDiabeticNeuropathy", "technotesDiabeticNeuropathy", _technicianIdNamePairs);
                _resultPdfHelper.SetFindingsVertical(doc, testResult.Finding, standardFindingList, "DiabeticNeuropathyFinding");
                _resultPdfHelper.SetSummaryFindings(doc, testResult.Finding, standardFindingList, "finding-DiabeticNeuropathy-div", "long-description-DiabeticNeuropathy", null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpDiabeticNeuropathy", "criticalDiabeticNeuropathy", "physicianRemarksDiabeticNeuropathy");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.DiabeticNeuropathy, "DiabeticNeuropathyUnableToScreen", testResult.UnableScreenReason);

                if (testResult.Finding != null)
                {
                    var stdFinding = standardFindingList.Single(f => f.Id == testResult.Finding.Id);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='DiabeticNeuropathy-rpp-resultspan']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = stdFinding.Label;
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='DiabeticNeuropathy-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetFindingsVertical(doc, null, standardFindingList, "DiabeticNeuropathyFinding");
                _resultPdfHelper.SetSummaryFindings(doc, null, standardFindingList, "finding-DiabeticNeuropathy-div", "long-description-DiabeticNeuropathy", null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.DiabeticNeuropathy, "DiabeticNeuropathyUnableToScreen", null);
            }
        }

        private void LoadQualityMeasuresTestResult(QualityMeasuresTestResult testResult, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='QualityMeasures-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='quality-rpp-section']");
                    if (selectedNode != null)
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                    }
                }
                var functionalAssessmentScoreFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.QualityMeasures, (Int32)ReadingLabels.FunctionalAssessmentScore);
                var painAssessmentScoreFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.QualityMeasures, (Int32)ReadingLabels.PainAssessmentScore);

                if (testResult.FunctionalAssessmentScore != null)
                {
                    _resultPdfHelper.SetFindingsDropdown(doc, testResult.FunctionalAssessmentScore, functionalAssessmentScoreFindings, "FunctionalAssessmentInputText");
                }

                if (testResult.PainAssessmentScore != null)
                {
                    _resultPdfHelper.SetFindingsDropdown(doc, testResult.PainAssessmentScore, painAssessmentScoreFindings, "PainAssessmentScoreInputText");
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='ClockdrawingInputText']");
                if (selectedNode != null)
                {
                    var clockResult = (testResult.ClockFail != null && testResult.ClockFail.Reading) ? "Fail" : string.Empty;
                    if (string.IsNullOrEmpty(clockResult))
                    {
                        clockResult = (testResult.ClockPass != null && testResult.ClockPass.Reading) ? "Pass" : string.Empty;
                    }
                    selectedNode.SetAttributeValue("value", clockResult);
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='GaitResultInputText']");
                if (selectedNode != null)
                {
                    var clockResult = (testResult.GaitFail != null && testResult.GaitFail.Reading) ? "Fail" : string.Empty;
                    if (string.IsNullOrEmpty(clockResult))
                    {
                        clockResult = (testResult.GaitPass != null && testResult.GaitPass.Reading) ? "Pass" : string.Empty;
                    }

                    selectedNode.SetAttributeValue("value", clockResult);
                }

                _resultPdfHelper.SetInputBox(doc, "MemoryRecallScoreInputText", testResult.MemoryRecallScore);

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.QualityMeasures, "QualityMeasuresUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpQualityMeasures", "criticalQualityMeasures", "physicianRemarksQualityMeasures");
                _resultPdfHelper.SetTechnician(doc, testResult, "techQualityMeasures", "", _technicianIdNamePairs);

            }

        }

        private void LoadIFobtTestResult(IFOBTTestResult testResult, bool removeLongDescription, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='ifobt-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0) && testResult.Finding != null
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");
                }

                var ifobtFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.IFOBT);

                if (testResult.Finding != null)
                {
                    var resultFinding = ifobtFindings.Single(x => x.Id == testResult.Finding.Id);
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Ifobt-rpp-resultspan']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.Label;
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='longdescription-Ifobt']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.LongDescription;
                    }
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Ifobt-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.IFOBT, "IfobtUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpIfobt", "criticalIfobt", "physicianRemarksIfobt");
                _resultPdfHelper.SetTechnician(doc, testResult, "techIfobt", "", _technicianIdNamePairs);
            }

        }

        private void LoadPhq9TestResult(Phq9TestResult testResult, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='PHQ9-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");

                    selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='quality-rpp-section']");
                    if (selectedNode != null)
                    {
                        selectedNode.SetAttributeValue("style", "display:block;");
                    }
                }

                _resultPdfHelper.SetInputBox(doc, "DepressionAssessmentInputText", testResult.Phq9Score);

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.RinneWeberHearing, "QualityMeasuresUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpPHQ9", "criticalPHQ9", "physicianRemarksPHQ9");
                _resultPdfHelper.SetTechnician(doc, testResult, "techPHQ9", "", _technicianIdNamePairs);

            }
        }

        private void LoadBmiValue(HtmlDocument doc, Customer customer)
        {
            var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='BMI-rpp-section']");
            var weight = customer.Weight;
            var height = customer.Height;

            if (weight != null && weight.Pounds > 1 && height != null && height.TotalInches > 1)
            {
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                var bmiIndex = BmiCalculator(weight.Pounds, height.TotalInches);

                selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='bmireading']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("value", bmiIndex.ToString("0.0"));

                var heightinFtin = customer.Height.Feet + " ft " + customer.Height.Inches + " in";

                selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='bmiheight']");

                if (selectedNode != null)
                    selectedNode.SetAttributeValue("value", heightinFtin);


                selectedNode = doc.DocumentNode.SelectSingleNode("//input[@id='bmiweight']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("value", weight.TotalPounds.ToString());

            }

        }

        private decimal BmiCalculator(double weightInPounds, double heightInInches)
        {
            var bmiIndex = (weightInPounds < 1 || heightInInches < 1) ? 0 : (weightInPounds / Math.Pow(heightInInches, 2)) * 703;
            return decimal.Parse(bmiIndex.ToString());
        }

        private void LoadUrineMicroalbuminTestResult(UrineMicroalbuminTestResult testResult, bool isMale, bool removeLongDescription, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='urinemicroalbumin-rpp-section']");

                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false) && (testResult.Finding != null || (testResult.MicroalbuminValue != null && testResult.MicroalbuminValue.Reading != "")))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");
                }

                var urineMicroalbuminFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.UrineMicroalbumin);

                urineMicroalbuminFindings = FilterMaleFemalRecordsontheGenderBasis(urineMicroalbuminFindings, isMale).ToList();

                if (testResult.Finding != null)
                {
                    var resultFinding = urineMicroalbuminFindings.Single(x => x.Id == testResult.Finding.Id);
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='urinemicroalbumin-rpp-resultspan']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.Label;
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='longdescription-urinemicroalbumin']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.LongDescription;
                    }
                }

                var readings = new TestResultRepository().GetAllReadings((int)TestType.UrineMicroalbumin);

                foreach (var resultReading in readings)
                {
                    switch (resultReading.Label)
                    {
                        case ReadingLabels.MicroalbuminValue:
                            _resultPdfHelper.SetInputBox(doc, "microalbumineValue", testResult.MicroalbuminValue);
                            break;
                    }
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='urinemicroalbumin-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.UrineMicroalbumin, "urinemicroalbuminUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpurinemicroalbumin", "criticalurinemicroalbumin", "physicianRemarksurinemicroalbumin");
                _resultPdfHelper.SetTechnician(doc, testResult, "techurinemicroalbumin", "", _technicianIdNamePairs);
            }

        }

        private void LoadChlamydiaTestResult(ChlamydiaTestResult testResult, bool removeLongDescription, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='chlamydia-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");
                }

                var ifobtFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.Chlamydia);

                if (testResult.Finding != null)
                {
                    var resultFinding = ifobtFindings.Single(x => x.Id == testResult.Finding.Id);
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='chlamydia-rpp-resultspan']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.Label;
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='longdescription-chlamydia']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.LongDescription;
                    }
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='chlamydia-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Chlamydia, "chlamydiaUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpchlamydia", "criticalchlamydia", "physicianRemarkschlamydia");
                _resultPdfHelper.SetTechnician(doc, testResult, "techchlamydia", "", _technicianIdNamePairs);
            }
        }

        private void LoadQuantaFloTestResult(QuantaFloABITestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
             IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='quantaflo-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");
                }

                var quantaFloABIFindings = _standardFindingRepository.GetAllStandardFindings<int>((Int32)TestType.QuantaFloABI);

                if (testResult.Finding != null)
                {
                    var resultFinding = quantaFloABIFindings.Single(x => x.Id == testResult.Finding.Id);
                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='QuantaFloAbi-rpp-resultspan']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.Label;
                    }

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='longdescription-QuantaFloAbi']");
                    if (selectedNode != null)
                    {
                        selectedNode.InnerHtml = resultFinding.LongDescription;
                    }
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='QuantaFloAbi-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
                _resultPdfHelper.SetPhysicianSignature(doc, "QuantaFloAbi-primaryEvalPhysicianSign", "QuantaFloAbi-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);
                _resultPdfHelper.SetTechnician(doc, testResult, "techQuantaFloAbi", "technotesQuantaFloAbi", _technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpQuantaFloAbi", "QuantaFloAbi", "physicianRemarksQuantaFloAbi");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.QuantaFloABI, "QuantaFloAbiUnableToScreen", testResult.UnableScreenReason);
            }
        }

        private void LoadMonofilamentTestResult(MonofilamentTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Monofilament-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetPhysicianSignature(doc, "monofilament-primaryEvalPhysicianSign", "monofilament-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                _resultPdfHelper.SetCheckBox(doc, "MonofilamentRightSensationIntact", testResult.RightPositive);
                _resultPdfHelper.SetCheckBox(doc, "MonofilamentRightSensationNotIntact", testResult.RightNegative);

                _resultPdfHelper.SetCheckBox(doc, "MonofilamentLeftSensationIntact", testResult.LeftPositive);
                _resultPdfHelper.SetCheckBox(doc, "MonofilamentLeftSensationNotIntact", testResult.LeftNegative);

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='monofilament-longdescription-div']");

                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Monofilament, "monofilamentUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpmonofilament", "criticalMonofilament", "physicianRemarksMonofilament");
                _resultPdfHelper.SetTechnician(doc, testResult, "techMonofilament", "", _technicianIdNamePairs);
            }

        }

        private void ShowIfobtUrineMicroalbumiReportPage(HtmlDocument doc)
        {
            var ifobturinemicroalbumineport = doc.DocumentNode.SelectSingleNode("//div[@id='ifobt-urinemicroalbumin-rpp-section']");
            if (ifobturinemicroalbumineport == null) return;

            var selectNodes = doc.DocumentNode.SelectNodes("//div[@id='ifobt-urinemicroalbumin-rpp-section']//div[contains(@id,'rpp-section')][@style='display:block;']");

            if (selectNodes != null && selectNodes.Any()) //
            {
                ifobturinemicroalbumineport.SetAttributeValue("style", "display:block;");
            }
            else
            {
                ifobturinemicroalbumineport.SetAttributeValue("style", "display:none;");
            }

        }

        private IEnumerable<StandardFinding<int>> FilterMaleFemalRecordsontheGenderBasis(IEnumerable<StandardFinding<int>> findings, bool isMale)
        {
            var coll = new List<StandardFinding<int>>();
            string toCheck = isMale ? StringForMale : StringForFemale;
            string toNotCheck = !isMale ? StringForMale : StringForFemale;
            if (string.IsNullOrEmpty(toCheck)) return findings;

            foreach (var finding in findings)
            {
                if (finding.Label.ToLower().IndexOf(toCheck) != 0 && finding.Label.ToLower().IndexOf(toNotCheck) >= 0)
                    continue;
                if (finding.Label.ToLower().IndexOf(toCheck) >= 0)
                    finding.Label = finding.Label.Substring(finding.Label.ToLower().IndexOf(toCheck) + toCheck.Length);

                coll.Add(finding);
            }
            return coll;
        }

        private void LoadMammogramTestResult(MammogramTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='mammogram-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                {
                    selectedNode.SetAttributeValue("style", "display:block;");
                }

                _resultPdfHelper.SetPhysicianSignature(doc, "mammogram-primaryEvalPhysicianSign", "mammogram-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='mammogram-longdescription-div']");

                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");

                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Mammogram, "mammogramUnableToScreen", testResult.UnableScreenReason);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpmammogram", "criticalmammogram", "physicianRemarksmammogram");
                _resultPdfHelper.SetTechnician(doc, testResult, "techmammogram", "", _technicianIdNamePairs);

                LoadmammogramFindings(doc, testResult.Finding);
            }
        }

        private void LoadmammogramFindings(HtmlDocument doc, StandardFinding<int> finding)
        {

            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.Mammogram);

            //if (standardFindingList.Count() > 0 && standardFindingList.First().WorstCaseOrder > 0)
            //{
            //    standardFindingList = standardFindingList.OrderBy(f => f.WorstCaseOrder).ToList();
            //}
            standardFindingList = standardFindingList.OrderBy(f => f.Id).ToList();

            if (finding != null)
            {
                var stdFinding = standardFindingList.Single(f => f.Id == finding.Id);

                var selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='mammogram-rpp-resultspan']");
                if (selectedNode != null)
                    selectedNode.InnerHtml = stdFinding.Label;
            }

            _resultPdfHelper.SetFindingsVertical(doc, finding, standardFindingList, "mammogramFinding");
        }

        private void LoadDpnTestResults(DpnTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
           IEnumerable<EventPhysicianTest> eventPhysicianTests, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, HtmlDocument doc)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.DPN);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Dpn-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "Dpn-primaryEvalPhysicianSign", "DiabeticNeuropathy-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluation, customerSkipReview);

                _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableDpnInputCheck", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyDpnInputCheck", testResult.RepeatStudy);

                _resultPdfHelper.SetInputBox(doc, "DpnAmplitudeTextbox", testResult.Amplitude);
                _resultPdfHelper.SetInputBox(doc, "DpnConductionVelocityTextbox", testResult.ConductionVelocity);

                _resultPdfHelper.SetCheckBox(doc, "DpnRightLegCheckbox", testResult.RightLeg);
                _resultPdfHelper.SetCheckBox(doc, "DpnLeftLegCheckbox", testResult.LeftLeg);

                _resultPdfHelper.SetTechnician(doc, testResult, "techDpn", "technotesDpn", _technicianIdNamePairs);
                _resultPdfHelper.SetFindingsVertical(doc, testResult.Finding, standardFindingList, "DpnFinding");
                _resultPdfHelper.SetSummaryFindings(doc, testResult.Finding, standardFindingList, "finding-Dpn-div", "long-description-Dpn", null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpDpn", "criticalDpn", "physicianRemarksDpn");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.DiabeticNeuropathy, "DpnUnableToScreen", testResult.UnableScreenReason);

                if (testResult.Finding != null)
                {
                    var stdFinding = standardFindingList.Single(f => f.Id == testResult.Finding.Id);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='Dpn-rpp-resultspan']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = stdFinding.Label;
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Dpn-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetFindingsVertical(doc, null, standardFindingList, "DpnFinding");
                _resultPdfHelper.SetSummaryFindings(doc, null, standardFindingList, "finding-Dpn-div", "long-description-Dpn", null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.DiabeticNeuropathy, "DpnUnableToScreen", null);
            }
        }

    }
}
