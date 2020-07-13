using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Core.Medical
{
    public interface ILipidResultPdfHelper
    {
        void LoadLipidResult(HtmlDocument doc, LipidTestResult testResult, bool isMale, List<OrderedPair<long, string>> technicianIdNamePairs, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);

        void LoadAwvLipidResult(HtmlDocument doc, AwvLipidTestResult testResult, bool isMale, List<OrderedPair<long, string>> technicianIdNamePairs, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);

        void LoadAwvGlucoseResult(HtmlDocument doc, AwvGlucoseTestResult testResult, List<OrderedPair<long, string>> technicianIdNamePairs);
        void LoadCholesterolResult(HtmlDocument doc, CholesterolTestResult testResult, bool isMale, List<OrderedPair<long, string>> technicianIdNamePairs);
        void LoadDiabetesResult(HtmlDocument doc, DiabetesTestResult testResult, List<OrderedPair<long, string>> technicianIdNamePairs);

        void LoadMyBioCheckResult(HtmlDocument doc, MyBioAssessmentTestResult testResult, bool isMale,List<OrderedPair<long, string>> technicianIdNamePairs,IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians,
            IEnumerable<EventPhysicianTest> eventPhysicianTests,IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);
    }
}
