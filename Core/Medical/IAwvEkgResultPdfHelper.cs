using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Medical
{
    public interface IAwvEkgResultPdfHelper
    {
        void LoadAwvEkgTestResults(HtmlDocument doc, AwvEkgTestResult testResult, bool removeLongDescription, List<OrderedPair<long, string>> technicianIdNamePairs,
            bool loadImages, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
            bool showUnreadableTest, IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluation, CustomerSkipReview customerSkipReview, string stringforMediaDirectory);
    }
}
