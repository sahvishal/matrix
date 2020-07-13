using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ITestService
    {
        TestListModel GetAllTest(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
        TestEditModel GetTestEditModel(long testId);
        void SaveTestEditModel(TestEditModel testEditModel);
    }
}
