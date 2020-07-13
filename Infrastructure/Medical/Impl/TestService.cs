using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IBillingAccountRepository _billingAccountRepository;

        public TestService(ITestRepository testRepository, IBillingAccountRepository billingAccountRepository)
        {
            _testRepository = testRepository;
            _billingAccountRepository = billingAccountRepository;
        }

        public TestListModel GetAllTest(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            var tests = _testRepository.GetAllTest(pageNumber, pageSize, filter as TestListModelFilter, out totalRecords);

            if (tests.IsNullOrEmpty()) return null;

            var model = new TestListModel();
            model.Collection = Mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(tests);

            return model;
        }

        public TestEditModel GetTestEditModel(long testId)
        {
            var test = _testRepository.GetTest(testId);
            var testEditModel = Mapper.Map<Test, TestEditModel>(test);

            var billingAccountTest = _billingAccountRepository.GetByTestId(testId);
            if (billingAccountTest != null)
            {
                testEditModel.IsTestCoveredByInsurance = true;
                testEditModel.BillingAccountId = billingAccountTest.BillingAccountId;
            }

            return testEditModel;
        }

        public void SaveTestEditModel(TestEditModel testEditModel)
        {
            var test = Mapper.Map<TestEditModel, Test>(testEditModel);
            _testRepository.SaveTest(test);

            _billingAccountRepository.SaveBillingAccountTest(testEditModel.BillingAccountId, testEditModel.TestId);
        }
    }
}
