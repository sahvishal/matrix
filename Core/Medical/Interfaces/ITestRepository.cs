using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface ITestRepository
    {
        List<Test> GetAll();
        List<OrderedPair<long, long>> GetTestDependencyData();
        string GetTestNamesByPackageId(long packageId);
        List<Test> GetPermittedTestsForaPhysician(long orgRoleUserId);
        
        List<Test> GetTestsByPackageIds(List<long> packageIds);
        IEnumerable<Test> GetReviewableTests();
        IEnumerable<Test> GetAllTest(int pageNumber, int pageSize, TestListModelFilter filter, out int totalRecords);
        Test SaveTest(Test test);
        void SaveTestAvailabilityToRoles(long testId, IEnumerable<long> roleIds);
        Test GetTest(long testId);
        IEnumerable<long> GetRoleIdsAvailableForTest(long testId);
        IEnumerable<Test> GetRecordableTests();
        IEnumerable<OrderedPair<long, string>> GetTestNameValuePair(List<long> testIds);
        List<OrderedPair<long, string>> GetTestIdListByAliasList(IEnumerable<string> list);
        IEnumerable<Test> GetTestsByHealthPlanId(long healthPlanId);
        IEnumerable<Test> GetTestByIds(IEnumerable<long> testIds);
        List<string> GetAliasListByTestIdList(IEnumerable<long> testIds);

        IEnumerable<Test> GetTestByPreQualificationQuestionTemplateIds(IEnumerable<long> templateIds);
        //List<Test> GetTestsByCustomerId(long customerId);
        IEnumerable<Test> GetDependentTests(long testId);
    }
}