using System.Collections.Generic;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IAccountTestFactory
    {
        OrganizationTestEditModel CreateModel(Test tests, AccountTest accountTest);
        IEnumerable<OrganizationTestEditModel> CreateModel(IEnumerable<Test> tests, IEnumerable<AccountTest> accountTests);
        AccountTest CreateDomain(OrganizationTestEditModel model, long accountId);
        IEnumerable<AccountTest> CreateDomain(IEnumerable<OrganizationTestEditModel> modelList, long accountId);
    }
}
