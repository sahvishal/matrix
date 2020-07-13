using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class GenerateTestPdfHelper : IGenerateTestPdfHelper
    {
        private readonly ISettings _settings;
        private IEchoResultPdfHelper _echoResultPdfHelper;
        private IAwvAAAResultPdfHelper _awvAAAResultPdfHelper;
        private ILeadResultPdfHelper _leadResultPdfHelper;
        private IAwvEkgResultPdfHelper _awvEkgResultPdfHelper;
        private ICopyMediaResultPdfHelper _copyMediaResultPdfHelper;
        private IPdfGenerator _pdfGenerator;

        public GenerateTestPdfHelper(ISettings settings, IEchoResultPdfHelper echoResultPdfHelper, IAwvAAAResultPdfHelper awvAAAResultPdfHelper, ILeadResultPdfHelper leadResultPdfHelper,
            IAwvEkgResultPdfHelper awvEkgResultPdfHelper, ICopyMediaResultPdfHelper copyMediaResultPdfHelper, IPdfGenerator pdfGenerator)
        {
            _settings = settings;
            _echoResultPdfHelper = echoResultPdfHelper;
            _awvAAAResultPdfHelper = awvAAAResultPdfHelper;
            _leadResultPdfHelper = leadResultPdfHelper;
            _awvEkgResultPdfHelper = awvEkgResultPdfHelper;
            _copyMediaResultPdfHelper = copyMediaResultPdfHelper;
            _pdfGenerator = pdfGenerator;
        }

        public void GenerateTestPdf(TestType testType, TestResult testResult, Event eventData, Customer customer, bool showUnreadableTest,
            bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs, bool showRepeatStudyCheckbox,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, MediaLocation ipResultPdfMediaLocation,
            string stringforMediaDirectory, bool isPhysicianPartnerCustomer)
        {
            var resultMedia = new List<ResultMedia>();
            var testSourceHtmlPath = string.Empty;

            switch (testType)
            {
                case TestType.AwvAAA:
                    var awvAaaTestResult = testResult as AwvAaaTestResult;
                    if ((awvAaaTestResult.UnableScreenReason == null || awvAaaTestResult.UnableScreenReason.Count == 0)
                                && (awvAaaTestResult.TestNotPerformed == null || awvAaaTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                                && (showUnreadableTest || awvAaaTestResult.RepeatStudy == null || awvAaaTestResult.RepeatStudy.Reading == false))
                    {
                        testSourceHtmlPath = _settings.ResultPacketLocation + TestType.AwvAAA.ToString() + ".htm";

                        var awvAaaTestDoc = new HtmlDocument();
                        awvAaaTestDoc.Load(testSourceHtmlPath);

                        _awvAAAResultPdfHelper.LoadAwvAaaTestresults(awvAaaTestDoc, eventData.Id, customer.CustomerId, awvAaaTestResult, removeLongDescription, technicianIdNamePairs, loadImages, physicians, eventPhysicianTests, showUnreadableTest, eventCustomerPhysicianEvaluations, customerSkipReview);

                        if (awvAaaTestResult != null && awvAaaTestResult.ResultImages != null && awvAaaTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(awvAaaTestResult.ResultImages);
                        }

                        GeneratePdf(awvAaaTestDoc, ipResultPdfMediaLocation, eventData, customer, TestType.AwvAAA, testSourceHtmlPath, physicians, testResult, resultMedia);
                    }
                    break;
                case TestType.AwvEcho:
                    var awvEchoTestResult = testResult as AwvEchocardiogramTestResult;
                    if ((awvEchoTestResult.UnableScreenReason == null || awvEchoTestResult.UnableScreenReason.Count == 0) &&
                        (awvEchoTestResult.TestNotPerformed == null || awvEchoTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0) &&
                        (showUnreadableTest || awvEchoTestResult.RepeatStudyUnreadable == null || awvEchoTestResult.RepeatStudyUnreadable.Reading == false))
                    {
                        testSourceHtmlPath = _settings.ResultPacketLocation + TestType.AwvEcho.ToString() + ".htm";

                        var awvEchoTestDoc = new HtmlDocument();
                        awvEchoTestDoc.Load(testSourceHtmlPath);

                        if (awvEchoTestResult != null && awvEchoTestResult.Media != null && awvEchoTestResult.Media.Count > 0)
                        {
                            resultMedia.AddRange(awvEchoTestResult.Media);
                        }
                        _echoResultPdfHelper.LoadAwvEchoTestResults(awvEchoTestDoc, awvEchoTestResult, removeLongDescription, loadImages, technicianIdNamePairs, physicians, eventPhysicianTests, showUnreadableTest, eventCustomerPhysicianEvaluations, customerSkipReview, customer.CustomerId, eventData.Id);

                        GeneratePdf(awvEchoTestDoc, ipResultPdfMediaLocation, eventData, customer, TestType.AwvEcho, testSourceHtmlPath, physicians, testResult, resultMedia);
                    }
                    break;
                case TestType.AwvEkg:
                    var awvEkgTestResult = testResult as AwvEkgTestResult;
                    if ((awvEkgTestResult.UnableScreenReason == null || awvEkgTestResult.UnableScreenReason.Count == 0) && (awvEkgTestResult.TestNotPerformed == null || awvEkgTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (showUnreadableTest || awvEkgTestResult.RepeatStudy == null || awvEkgTestResult.RepeatStudy.Reading == false))
                    {
                        testSourceHtmlPath = _settings.ResultPacketLocation + TestType.AwvEkg.ToString() + ".htm";

                        var awvEkgTestDoc = new HtmlDocument();
                        awvEkgTestDoc.Load(testSourceHtmlPath);

                        _awvEkgResultPdfHelper.LoadAwvEkgTestResults(awvEkgTestDoc, awvEkgTestResult, removeLongDescription, technicianIdNamePairs, loadImages, physicians, eventPhysicianTests, showUnreadableTest, eventCustomerPhysicianEvaluations, customerSkipReview, stringforMediaDirectory);

                        GeneratePdf(awvEkgTestDoc, ipResultPdfMediaLocation, eventData, customer, TestType.AwvEkg, testSourceHtmlPath, physicians, testResult, resultMedia);
                    }
                    break;
                case TestType.Lead:
                    var leadTestResult = testResult as LeadTestResult;
                    if ((leadTestResult.UnableScreenReason == null || leadTestResult.UnableScreenReason.Count == 0) && (leadTestResult.TestNotPerformed == null || leadTestResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (leadTestResult.RepeatStudy == null || leadTestResult.RepeatStudy.Reading == false))
                    {
                        testSourceHtmlPath = _settings.ResultPacketLocation + TestType.Lead.ToString() + ".htm";

                        var leadTestDoc = new HtmlDocument();
                        leadTestDoc.Load(testSourceHtmlPath);

                        if (leadTestResult != null && leadTestResult.ResultImages != null && leadTestResult.ResultImages.Count > 0)
                        {
                            resultMedia.AddRange(leadTestResult.ResultImages);
                        }
                        _leadResultPdfHelper.LoadLeadTestresults(leadTestDoc, leadTestResult, removeLongDescription, technicianIdNamePairs, loadImages, physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview, eventData.EventDate, isPhysicianPartnerCustomer);

                        GeneratePdf(leadTestDoc, ipResultPdfMediaLocation, eventData, customer, TestType.Lead, testSourceHtmlPath, physicians, testResult, resultMedia);
                    }
                    break;
            }
        }

        private void GeneratePdf(HtmlDocument doc, MediaLocation ipResultPdfMediaLocation, Event eventData, Customer customer, TestType testType,
            string testSourceHtmlPath, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, TestResult testResult, List<ResultMedia> resultMedia)
        {
            string testName = testType.ToString();
            var testHtmlPath = Path.Combine(ipResultPdfMediaLocation.PhysicalPath, testName + ".html");
            var testHtmlUrl = Path.Combine(ipResultPdfMediaLocation.Url, testName + ".html");

            var appentAcesIdOrCustomerId = string.IsNullOrEmpty(customer.AcesId) ? "NoAcesId_" + customer.CustomerId : customer.AcesId;
            var testPdfLocation = ipResultPdfMediaLocation.PhysicalPath + testName + "_" + appentAcesIdOrCustomerId + "_" + customer.Name.LastName + "_" + customer.Name.FirstName + "_" + eventData.EventDate.Year + ".pdf";

            _copyMediaResultPdfHelper.CopyOverSupportDirectorytotheDestination(testHtmlPath, testSourceHtmlPath, physicians, copySupportMediaOtherThanPhysician: true);
            _copyMediaResultPdfHelper.CopyOverMedia(eventData.Id, customer.CustomerId, testHtmlPath, resultMedia);

            if (testType == TestType.AwvEkg)
            {
                _copyMediaResultPdfHelper.CopyOverAwvEkgGraph(eventData.Id, customer.CustomerId, testHtmlPath, testResult as AwvEkgTestResult);
            }

            _copyMediaResultPdfHelper.UpdateHTMLWithImages(doc);
            doc.Save(testHtmlPath);

            var dob = string.Empty;
            if (customer.DateOfBirth.HasValue)
                dob = " DOB:" + customer.DateOfBirth.Value.ToString("MM/dd/yyyy");

            _pdfGenerator.GeneratePdf(testHtmlUrl, testPdfLocation, true, customer.NameAsString + " [" + customer.CustomerId + "]" + dob + " Testing Date:" + eventData.EventDate.ToShortDateString());
        }
    }
}
