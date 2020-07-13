using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface ITestResultFactory
    {
        TestResult CreateTestResult(CustomerEventScreeningTestsEntity customerEventTestsEntity);
        List<TestResult> CreateTestResults(List<CustomerEventScreeningTestsEntity> customerEventTestsEntities);
        CustomerEventScreeningTestsEntity CreateTestResultEntity(TestResult testResult, List<OrderedPair<int, int>> testReadingreadingPairs);
        List<CustomerEventScreeningTestsEntity> CreateTestResultEntities(List<TestResult> testResults);
    }
}
