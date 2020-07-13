using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Core.Medical
{
    public interface IResultPdfHelper
    {
        void SetCheckBox(HtmlDocument doc, string nodeName, ResultReading<bool> resultReading);
        void SetCheckBox(HtmlDocument doc, string nodeName, ResultReading<bool?> resultReading);
        void SetInputBox<T>(HtmlDocument doc, string nodeName, ResultReading<T> resultReading);
        void SetSummaryFindings<T>(HtmlDocument doc, StandardFinding<T> findingInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId, string descriptionboxid = "", StandardFinding<T> findingForLongDescription = null, bool isTestPurchased = true, UnableScreenReason unableScreenReason = null, bool showAdditionalImagesNeeded = false, bool showConsiderOtherModalities = false);
        void LoadTestMedia(HtmlDocument doc, IEnumerable<ResultMedia> media, string containerId, bool loadImages);
        void SetPhysicianRemarks(HtmlDocument doc, TestResult testResult, string followUpCheckBoxId, string criticalCheckBoxId, string physicianRemarksTextboxId);
        void SetTechnician(HtmlDocument doc, TestResult testResult, string technicianTextBoxId, string technicianNotesTextboxId, List<OrderedPair<long, string>> technicianIdNamePairs);
        void SetUnableToScreenReasons(HtmlDocument doc, TestType testType, string containerId, IEnumerable<UnableScreenReason> unableScreenReasons);

        void SetFindingsHorizontal<T>(HtmlDocument doc, IEnumerable<StandardFinding<T>> findingsInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId, int colSpecified = 0);

        void SetFindingsHorizontal<T>(HtmlDocument doc, StandardFinding<T> findingInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId, int colSpecified = 0);

        void SetFindingsVertical<T>(HtmlDocument doc, StandardFinding<T> findingInDb, IEnumerable<StandardFinding<T>> findingsCollection, string containerId);

        void SetIncidentalFindings(HtmlDocument doc, IEnumerable<IncidentalFinding> allFortheTest, IEnumerable<IncidentalFinding> recordedForthecurrentRecord, string containerId);
        bool ShowHideRepeatStudyCheckbox(DateTime eventDate, long eventId, long customerId);
        void ShowHideRepeatStudy(HtmlDocument doc, string containerDivId, bool showRepeatStudyCheckbox);

        void ShowHideOtherModalitiesAdditionalImages(HtmlDocument doc, string containerDivId, bool showOtherModalitiesAdditionalImages);

        void SetPhysicianSignature(HtmlDocument doc, string priamryPhysicianContainerId, string overReadPhysicianControlId, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);

        void SetFindingsDropdown<T>(HtmlDocument doc, StandardFinding<T> findingInDb,IEnumerable<StandardFinding<T>> findingsCollection, string containerId);
    }
}
