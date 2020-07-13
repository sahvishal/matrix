using System.Collections.Generic;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IAccountNotReviewableTestFactory
    {
        IEnumerable<OrganizationTestViewModel> CreateModel(IEnumerable<Test> tests, IEnumerable<AccountNotReviewableTest> accountTests);
        IEnumerable<AccountNotReviewableTest> CreateDomain(IEnumerable<OrganizationTestViewModel> modelList, long accountId);
    }
}