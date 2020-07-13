using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IGenerateTestPdfHelper
    {
        void GenerateTestPdf(TestType testType, TestResult testResult, Event eventData, Customer customer, bool showUnreadableTest,
              bool removeLongDescription, bool loadImages, List<OrderedPair<long, string>> technicianIdNamePairs, bool showRepeatStudyCheckbox,
              IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, IEnumerable<EventPhysicianTest> eventPhysicianTests,
              IEnumerable<PhysicianEvaluation> eventCustomerPhysicianEvaluations, CustomerSkipReview customerSkipReview, MediaLocation ipResultPdfMediaLocation,
              string stringforMediaDirectory, bool isPhysicianPartnerCustomer);
    }
}
