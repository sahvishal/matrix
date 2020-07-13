using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Core.Medical
{
    public interface IEchoResultPdfHelper
    {
        void LoadEchoTestResults(HtmlDocument doc, EchocardiogramTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs, bool showRepeatStudyCheckbox,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview);

        void LoadPpEchoTestResults(HtmlDocument doc, PpEchocardiogramTestResult testResult, bool removeLongDescription,bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview);

        void LoadAwvEchoTestResults(HtmlDocument doc, AwvEchocardiogramTestResult testResult, bool removeLongDescription,bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, 
            CustomerSkipReview customerSkipReview, long customerId, long eventId);
        
        void LoadHcpEchoTestResults(HtmlDocument doc, HcpEchocardiogramTestResult testResult, bool removeLongDescription,bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations,
            CustomerSkipReview customerSkipReview);
    }
}
