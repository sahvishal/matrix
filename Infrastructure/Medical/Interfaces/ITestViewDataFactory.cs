using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Interfaces
{
    public interface ITestViewDataFactory
    {
        List<TestViewData> Create(List<Test> tests);
        List<TestViewData> Create(List<long> testIds, List<Test> tests);
        List<TestViewData> Create(Package package, List<Test> tests);
        List<TestViewData> Create(Package package, List<long> testIds, List<Test> tests);
    }
}