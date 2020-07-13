using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HPyloriResultPdfHelper : IHPyloriResultPdfHelper
    {
        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        public HPyloriResultPdfHelper(IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository)
        {
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
        }

        public void LoadHPyloriTestresults(HtmlDocument doc, HPyloriTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.HPylori);
            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HPylori-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0)
                    && (testResult.RepeatStudy == null || testResult.RepeatStudy.Reading == false))
                    selectedNode.SetAttributeValue("style", "display:block;");

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='rpp-eus-HPylori-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "HPylori-primaryEvalPhysicianSign", "HPylori-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                _resultPdfHelper.SetCheckBox(doc, "TechnicallyLimitedbutReadableHPyloriInputCheck", testResult.TechnicallyLimitedbutReadable);
                _resultPdfHelper.SetCheckBox(doc, "RepeatStudyHPyloriInputCheck", testResult.RepeatStudy);

                _resultPdfHelper.SetTechnician(doc, testResult, "techHPylori", "technotesHPylori", technicianIdNamePairs);
                _resultPdfHelper.SetFindingsVertical(doc, testResult.Finding, standardFindingList, "HPyloriFinding");
                _resultPdfHelper.SetSummaryFindings(doc, testResult.Finding, standardFindingList, "finding-HPylori-div", "long-description-HPylori", null, true, (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? testResult.UnableScreenReason.First() : null));
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpHPylori", "criticalHPylori", "physicianRemarksHPylori");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HPylori, "HPyloriUnableToScreen", testResult.UnableScreenReason);

                if (testResult.Finding != null)
                {
                    var stdFinding = standardFindingList.Single(f => f.Id == testResult.Finding.Id);

                    selectedNode = doc.DocumentNode.SelectSingleNode("//span[@id='HPylori-rpp-resultspan']");
                    if (selectedNode != null)
                        selectedNode.InnerHtml = stdFinding.Label;
                }

                selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='HPylori-longdescription-div']");
                if (selectedNode != null)
                    selectedNode.SetAttributeValue("style", removeLongDescription ? "display:none" : "display:block");
            }
            else
            {
                _resultPdfHelper.SetFindingsVertical(doc, null, standardFindingList, "HPyloriFinding");
                _resultPdfHelper.SetSummaryFindings(doc, null, standardFindingList, "finding-HPylori-div", "longdescription-HPylori", null, false);
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.HPylori, "HPyloriUnableToScreen", null);
            }
        }
    }
}
