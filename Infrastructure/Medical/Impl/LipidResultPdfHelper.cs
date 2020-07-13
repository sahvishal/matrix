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
    public class LipidResultPdfHelper : ILipidResultPdfHelper
    {
        private const string StringForMale = "male - ";
        private const string StringForFemale = "female - ";

        private readonly IResultPdfHelper _resultPdfHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;
        private readonly Service.TestResultService _testResultService;

        public LipidResultPdfHelper(IResultPdfHelper resultPdfHelper, IStandardFindingRepository standardFindingRepository)
        {
            _resultPdfHelper = resultPdfHelper;
            _standardFindingRepository = standardFindingRepository;
            _testResultService = new Service.TestResultService();
        }

        public void LoadLipidResult(HtmlDocument doc, LipidTestResult testResult, bool isMale, List<OrderedPair<long, string>> technicianIdNamePairs, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            LoadLipidFinding(doc, testResult, isMale);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='lipid-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "lipid-primaryEvalPhysicianSign", "lipid-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                _resultPdfHelper.SetInputBox(doc, "TotalCholestrolLipidInputText", testResult.TotalCholestrol);
                _resultPdfHelper.SetInputBox(doc, "TCHDLRatioLipidInputText", testResult.TCHDLRatio);
                _resultPdfHelper.SetInputBox(doc, "HDLLipidInputText", testResult.HDL);
                _resultPdfHelper.SetInputBox(doc, "LDLLipidInputText", testResult.LDL);
                _resultPdfHelper.SetInputBox(doc, "GlucoseLipidInputText", testResult.Glucose);
                _resultPdfHelper.SetInputBox(doc, "TriglyceridesLipidInputText", testResult.TriGlycerides);

                _resultPdfHelper.SetTechnician(doc, testResult, "techlipid", "technoteslipid", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpLipid", "criticalLipid", "physicianRemarksLipid");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Lipid, "lipidUnableToScreen", testResult.UnableScreenReason);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Lipid, "lipidUnableToScreen", null);
            }
        }

        private void LoadLipidFinding(HtmlDocument doc, LipidTestResult testResult, bool isMale)
        {
            var hdlFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.Lipid, (int)ReadingLabels.HDL);
            var ldlFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.LDL);
            var glucoseFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.Glucose);
            var trigFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.Lipid, (int)ReadingLabels.TriGlycerides);
            var totalCholFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol);
            var tcHdlFinding = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Lipid, (int)ReadingLabels.TCHDLRatio);

            hdlFinding = FilterMaleFemalRecordsontheGenderBasis(hdlFinding, isMale).ToList();

            UnableScreenReason unableScreenReason = null;
            if (testResult != null && testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                unableScreenReason = testResult.UnableScreenReason.First();

            StandardFinding<string> hdlFindingForLongDescription = null;
            int t = 0;
            if (testResult != null && testResult.HDL != null && !string.IsNullOrEmpty(testResult.HDL.Reading) && int.TryParse(testResult.HDL.Reading, out t))
            {
                var findingIds = _testResultService.GetMultipleCalculatedStandardFinding(t, (int)TestType.Lipid, (int)ReadingLabels.HDL);
                if (findingIds != null && findingIds.Count() > 0)
                {
                    hdlFindingForLongDescription = hdlFinding.Where(fd => findingIds.Contains(fd.Id)).SingleOrDefault();
                }
            }
            _resultPdfHelper.SetSummaryFindings(doc, testResult != null && testResult.HDL != null ? testResult.HDL.Finding : null, hdlFinding, "FindingsHdlDiv", "longdescription-hdl", hdlFindingForLongDescription, testResult != null, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.HDL != null ? testResult.HDL.Finding : null, hdlFinding, "hdlFinding");



            StandardFinding<int?> ldlFindingForLongDescription = null;
            if (testResult != null && testResult.LDL != null && testResult.LDL.Reading.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(testResult.LDL.Reading, (int)TestType.Lipid, (int)ReadingLabels.LDL);
                if (findingId > 0)
                {
                    ldlFindingForLongDescription = ldlFinding.Where(fd => findingId == fd.Id).SingleOrDefault();
                }
            }
            _resultPdfHelper.SetSummaryFindings(doc, testResult != null && testResult.LDL != null ? testResult.LDL.Finding : null, ldlFinding, "FindingsLdlDiv", "longdescription-ldl", ldlFindingForLongDescription, testResult != null, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.LDL != null ? testResult.LDL.Finding : null, ldlFinding, "ldlFinding");


            StandardFinding<int?> glucoseFindingForLongDescription = null;
            if (testResult != null && testResult.Glucose != null && testResult.Glucose.Reading.HasValue)
            {
                var findingId = _testResultService.GetCalculatedStandardFinding(testResult.Glucose.Reading, (int)TestType.Lipid, (int)ReadingLabels.Glucose);
                if (findingId > 0)
                {
                    glucoseFindingForLongDescription = glucoseFinding.Where(fd => findingId == fd.Id).SingleOrDefault();
                }
            }
            _resultPdfHelper.SetSummaryFindings(doc, testResult != null && testResult.Glucose != null ? testResult.Glucose.Finding : null, glucoseFinding, "FindingsGlucoseDiv", "longdescription-glucose", glucoseFindingForLongDescription, testResult != null, unableScreenReason);
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Glucose != null ? testResult.Glucose.Finding : null, glucoseFinding, "glucoseFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TriGlycerides != null ? testResult.TriGlycerides.Finding : null, trigFinding, "triglyceridesFinding");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TotalCholestrol != null ? testResult.TotalCholestrol.Finding : null, totalCholFinding, "totalCholestrolFinding");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TCHDLRatio != null ? testResult.TCHDLRatio.Finding : null, tcHdlFinding, "tchdlRatioFinding");
        }

        public void LoadAwvLipidResult(HtmlDocument doc, AwvLipidTestResult testResult, bool isMale, List<OrderedPair<long, string>> technicianIdNamePairs, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            LoadAwvLipidFinding(doc, testResult, isMale);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvLipid-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "AwvLipid-primaryEvalPhysicianSign", "AwvLipid-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                _resultPdfHelper.SetInputBox(doc, "AwvLipidTotalCholestrolInputText", testResult.TotalCholestrol);
                _resultPdfHelper.SetInputBox(doc, "AwvLipidLDLInputText", testResult.LDL);
                _resultPdfHelper.SetInputBox(doc, "AwvLipidHDLInputText", testResult.HDL);
                _resultPdfHelper.SetInputBox(doc, "AwvLipidTriglyceridesInputText", testResult.TriGlycerides);
                _resultPdfHelper.SetInputBox(doc, "AwvLipidTCHDLRatioInputText", testResult.TCHDLRatio);

                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvLipid", "technotesAwvLipid", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvLipid", "criticalAwvLipid", "physicianRemarksAwvLipid");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvLipid, "AwvLipidUnableToScreen", testResult.UnableScreenReason);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvLipid, "AwvLipidUnableToScreen", null);
            }
        }

        private void LoadAwvLipidFinding(HtmlDocument doc, AwvLipidTestResult testResult, bool isMale)
        {
            var hdlFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.AwvLipid, (int)ReadingLabels.HDL);
            var ldlFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvLipid, (int)ReadingLabels.LDL);
            var trigFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.AwvLipid, (int)ReadingLabels.TriGlycerides);
            var totalCholFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.AwvLipid, (int)ReadingLabels.TotalCholestrol);
            var tcHdlFinding = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.AwvLipid, (int)ReadingLabels.TCHDLRatio);

            hdlFinding = FilterMaleFemalRecordsontheGenderBasis(hdlFinding, isMale).ToList();

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.HDL != null ? testResult.HDL.Finding : null, hdlFinding, "AwvLipidHdlFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.LDL != null ? testResult.LDL.Finding : null, ldlFinding, "AwvLipidLdlFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TriGlycerides != null ? testResult.TriGlycerides.Finding : null, trigFinding, "AwvLipidTriglyceridesFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TotalCholestrol != null ? testResult.TotalCholestrol.Finding : null, totalCholFinding, "AwvLipidTotalCholestrolFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TCHDLRatio != null ? testResult.TCHDLRatio.Finding : null, tcHdlFinding, "AwvLipidTchdlRatioFinding");
        }

        public void LoadAwvGlucoseResult(HtmlDocument doc, AwvGlucoseTestResult testResult, List<OrderedPair<long, string>> technicianIdNamePairs)
        {
            LoadAwvGlucoseFinding(doc, testResult);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='AwvGlucose-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetInputBox(doc, "AwvGlucoseInputText", testResult.Glucose);

                _resultPdfHelper.SetTechnician(doc, testResult, "techAwvGlucose", "technotesAwvGlucose", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpAwvGlucose", "criticalAwvGlucose", "physicianRemarksAwvGlucose");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvGlucose, "AwvGlucoseUnableToScreen", testResult.UnableScreenReason);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.AwvGlucose, "AwvGlucoseUnableToScreen", null);
            }
        }

        private void LoadAwvGlucoseFinding(HtmlDocument doc, AwvGlucoseTestResult testResult)
        {
            var glucoseFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.AwvGlucose, (int)ReadingLabels.Glucose);

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Glucose != null ? testResult.Glucose.Finding : null, glucoseFinding, "AwvGlucoseFinding");
        }

        public void LoadCholesterolResult(HtmlDocument doc, CholesterolTestResult testResult, bool isMale, List<OrderedPair<long, string>> technicianIdNamePairs)
        {
            LoadCholesterolFinding(doc, testResult, isMale);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Cholesterol-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetInputBox(doc, "CholesterolTotalCholestrolInputText", testResult.TotalCholesterol);
                _resultPdfHelper.SetInputBox(doc, "CholesterolLDLInputText", testResult.LDL);
                _resultPdfHelper.SetInputBox(doc, "CholesterolHDLInputText", testResult.HDL);
                _resultPdfHelper.SetInputBox(doc, "CholesterolTriglyceridesInputText", testResult.TriGlycerides);
                _resultPdfHelper.SetInputBox(doc, "CholesterolTCHDLRatioInputText", testResult.TCHDLRatio);

                _resultPdfHelper.SetTechnician(doc, testResult, "techCholesterol", "technotesCholesterol", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpCholesterol", "criticalCholesterol", "physicianRemarksCholesterol");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Cholesterol, "CholesterolUnableToScreen", testResult.UnableScreenReason);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Cholesterol, "CholesterolUnableToScreen", null);
            }
        }

        private void LoadCholesterolFinding(HtmlDocument doc, CholesterolTestResult testResult, bool isMale)
        {
            var hdlFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.Cholesterol, (int)ReadingLabels.HDL);
            var ldlFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Cholesterol, (int)ReadingLabels.LDL);
            var trigFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.Cholesterol, (int)ReadingLabels.TriGlycerides);
            var totalCholFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.Cholesterol, (int)ReadingLabels.TotalCholestrol);
            var tcHdlFinding = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.Cholesterol, (int)ReadingLabels.TCHDLRatio);

            hdlFinding = FilterMaleFemalRecordsontheGenderBasis(hdlFinding, isMale).ToList();

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.HDL != null ? testResult.HDL.Finding : null, hdlFinding, "CholesterolHdlFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.LDL != null ? testResult.LDL.Finding : null, ldlFinding, "CholesterolLdlFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TriGlycerides != null ? testResult.TriGlycerides.Finding : null, trigFinding, "CholesterolTriglyceridesFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TotalCholesterol != null ? testResult.TotalCholesterol.Finding : null, totalCholFinding, "CholesterolTotalCholestrolFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TCHDLRatio != null ? testResult.TCHDLRatio.Finding : null, tcHdlFinding, "CholesterolTchdlRatioFinding");
        }

        public void LoadDiabetesResult(HtmlDocument doc, DiabetesTestResult testResult, List<OrderedPair<long, string>> technicianIdNamePairs)
        {
            LoadDiabetesFinding(doc, testResult);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='Diabetes-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetInputBox(doc, "DiabetesGlucoseInputText", testResult.Glucose);

                _resultPdfHelper.SetTechnician(doc, testResult, "techDiabetes", "technotesDiabetes", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpDiabetes", "criticalDiabetes", "physicianRemarksDiabetes");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Diabetes, "DiabetesUnableToScreen", testResult.UnableScreenReason);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.Diabetes, "DiabetesUnableToScreen", null);
            }
        }

        private void LoadDiabetesFinding(HtmlDocument doc, DiabetesTestResult testResult)
        {
            var glucoseFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.Diabetes, (int)ReadingLabels.Glucose);

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Glucose != null ? testResult.Glucose.Finding : null, glucoseFinding, "DiabetesGlucoseFinding");
        }

        private IEnumerable<StandardFinding<string>> FilterMaleFemalRecordsontheGenderBasis(IEnumerable<StandardFinding<string>> findings, bool isMale)
        {
            var coll = new List<StandardFinding<string>>();
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


        public void LoadMyBioCheckResult(HtmlDocument doc, MyBioAssessmentTestResult testResult, bool isMale, List<OrderedPair<long, string>> technicianIdNamePairs, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview)
        {
            LoadMyBioCheckFinding(doc, testResult, isMale);

            if (testResult != null)
            {
                var selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='mybiocheck-rpp-section']");
                if (selectedNode != null && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.Count == 0) && (testResult.TestNotPerformed == null || testResult.TestNotPerformed.TestNotPerformedReasonId <= 0))
                    selectedNode.SetAttributeValue("style", "display:block;");

                _resultPdfHelper.SetPhysicianSignature(doc, "mybiocheck-primaryEvalPhysicianSign", "mybiocheck-overreadEvalPhysicianSign", physicians, eventPhysicianTests, eventCustomerPhysicianEvaluations, customerSkipReview);

                _resultPdfHelper.SetInputBox(doc, "mybiocheckTotalCholestrolInputText", testResult.TotalCholestrol);
                _resultPdfHelper.SetInputBox(doc, "mybiocheckTCHDLRatioInputText", testResult.TcHdlRatio);
                _resultPdfHelper.SetInputBox(doc, "mybiocheckHDLInputText", testResult.Hdl);
                _resultPdfHelper.SetInputBox(doc, "mybiocheckLDLInputText", testResult.Ldl);
                _resultPdfHelper.SetInputBox(doc, "mybiocheckGlucoseInputText", testResult.Glucose);
                _resultPdfHelper.SetInputBox(doc, "mybiocheckTriglyceridesInputText", testResult.TriGlycerides);

                _resultPdfHelper.SetTechnician(doc, testResult, "techmybiocheck", "technotesmybiocheck", technicianIdNamePairs);
                _resultPdfHelper.SetPhysicianRemarks(doc, testResult, "followUpmybiocheck", "criticalmybiocheck", "physicianRemarksmybiocheck");
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.MyBioCheckAssessment, "mybiocheckUnableToScreen", testResult.UnableScreenReason);
            }
            else
            {
                _resultPdfHelper.SetUnableToScreenReasons(doc, TestType.MyBioCheckAssessment, "mybiocheckUnableToScreen", null);
            }
        }

        private void LoadMyBioCheckFinding(HtmlDocument doc, MyBioAssessmentTestResult testResult, bool isMale)
        {
            var hdlFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.HDL);
            var ldlFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.LDL);
            var glucoseFinding = _standardFindingRepository.GetAllStandardFindings<int?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.Glucose);
            var trigFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TriGlycerides);
            var totalCholFinding = _standardFindingRepository.GetAllStandardFindings<string>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TotalCholestrol);
            var tcHdlFinding = _standardFindingRepository.GetAllStandardFindings<decimal?>((int)TestType.MyBioCheckAssessment, (int)ReadingLabels.TCHDLRatio);

            hdlFinding = FilterMaleFemalRecordsontheGenderBasis(hdlFinding, isMale).ToList();
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Hdl != null ? testResult.Hdl.Finding : null, hdlFinding, "mybiocheckhdlFinding");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Ldl != null ? testResult.Ldl.Finding : null, ldlFinding, "mybiocheckldlFinding");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Glucose != null ? testResult.Glucose.Finding : null, glucoseFinding, "mybiocheckglucoseFinding");

            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TriGlycerides != null ? testResult.TriGlycerides.Finding : null, trigFinding, "mybiochecktriglyceridesFinding");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TotalCholestrol != null ? testResult.TotalCholestrol.Finding : null, totalCholFinding, "mybiochecktotalCholestrolFinding");
            _resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TcHdlRatio != null ? testResult.TcHdlRatio.Finding : null, tcHdlFinding, "mybiochecktchdlRatioFinding");
            
            //StandardFinding<string> hdlFindingForLongDescription = null;
            //int t = 0;
            //if (testResult != null && testResult.Hdl != null && !string.IsNullOrEmpty(testResult.Hdl.Reading) && int.TryParse(testResult.Hdl.Reading, out t))
            //{
            //    var findingIds = _testResultService.GetMultipleCalculatedStandardFinding(t, (int)TestType.Lipid, (int)ReadingLabels.HDL);
            //    if (findingIds != null && findingIds.Count() > 0)
            //    {
            //        hdlFindingForLongDescription = hdlFinding.Where(fd => findingIds.Contains(fd.Id)).SingleOrDefault();
            //    }
            //}
            //_resultPdfHelper.SetSummaryFindings(doc, testResult != null && testResult.Hdl != null ? testResult.Hdl.Finding : null, hdlFinding, "FindingMyBioCheckHdlDiv", "longdescription-MyBioCheck-hdl", hdlFindingForLongDescription, testResult != null, unableScreenReason);
            //_resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Hdl != null ? testResult.Hdl.Finding : null, hdlFinding, "mybiocheckhdlFinding");



            //StandardFinding<int?> ldlFindingForLongDescription = null;
            //if (testResult != null && testResult.Ldl != null && testResult.Ldl.Reading.HasValue)
            //{
            //    var findingId = _testResultService.GetCalculatedStandardFinding(testResult.Ldl.Reading, (int)TestType.Lipid, (int)ReadingLabels.LDL);
            //    if (findingId > 0)
            //    {
            //        ldlFindingForLongDescription = ldlFinding.Where(fd => findingId == fd.Id).SingleOrDefault();
            //    }
            //}
            //_resultPdfHelper.SetSummaryFindings(doc, testResult != null && testResult.Ldl != null ? testResult.Ldl.Finding : null, ldlFinding, "FindingsLdlDiv", "longdescription-ldl", ldlFindingForLongDescription, testResult != null, unableScreenReason);
            //_resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Ldl != null ? testResult.Ldl.Finding : null, ldlFinding, "mybiocheckldlFinding");


            //StandardFinding<int?> glucoseFindingForLongDescription = null;
            //if (testResult != null && testResult.Glucose != null && testResult.Glucose.Reading.HasValue)
            //{
            //    var findingId = _testResultService.GetCalculatedStandardFinding(testResult.Glucose.Reading, (int)TestType.Lipid, (int)ReadingLabels.Glucose);
            //    if (findingId > 0)
            //    {
            //        glucoseFindingForLongDescription = glucoseFinding.Where(fd => findingId == fd.Id).SingleOrDefault();
            //    }
            //}
            //_resultPdfHelper.SetSummaryFindings(doc, testResult != null && testResult.Glucose != null ? testResult.Glucose.Finding : null, glucoseFinding, "FindingsGlucoseDiv", "longdescription-glucose", glucoseFindingForLongDescription, testResult != null, unableScreenReason);
            //_resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.Glucose != null ? testResult.Glucose.Finding : null, glucoseFinding, "mybiocheckglucoseFinding");

            //_resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TriGlycerides != null ? testResult.TriGlycerides.Finding : null, trigFinding, "mybiochecktriglyceridesFinding");
            //_resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TotalCholestrol != null ? testResult.TotalCholestrol.Finding : null, totalCholFinding, "mybiochecktotalCholestrolFinding");
            //_resultPdfHelper.SetFindingsVertical(doc, testResult != null && testResult.TcHdlRatio != null ? testResult.TcHdlRatio.Finding : null, tcHdlFinding, "mybiocheckTCHDLRatioInputText");
        }
    }
}
