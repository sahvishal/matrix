using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Core.Medical
{
    public interface IHPyloriResultPdfHelper
    {
        void LoadHPyloriTestresults(HtmlDocument doc, HPyloriTestResult testResult, bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs,
            IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview);
    }
}