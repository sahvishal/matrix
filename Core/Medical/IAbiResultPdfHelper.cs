using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Core.Medical
{
    public interface IAbiResultPdfHelper
    {
        void LoadPadTestResults(HtmlDocument doc, PADTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            List<OrderedPair<long, string>> technicianIdNamePairs, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);

        void LoadAwvAbiTestResults(HtmlDocument doc, AwvAbiTestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            List<OrderedPair<long, string>> technicianIdNamePairs, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);

        void PadOverlayResults(HtmlDocument doc, PADTestResult padTestResult);

        void LoadFloChecAbiTestResults(HtmlDocument doc, FloChecABITestResult testResult, bool removeLongDescription, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            List<OrderedPair<long, string>> technicianIdNamePairs, bool loadImages, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);
    }
}
