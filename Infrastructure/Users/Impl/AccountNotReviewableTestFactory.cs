using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class AccountNotReviewableTestFactory : IAccountNotReviewableTestFactory
    {
        private OrganizationTestViewModel CreateModel(Test test)
        {
            return new OrganizationTestViewModel
            {
                Id = test.Id,
                Name = test.Name,
                Gender = (Gender)test.Gender,

            };
        }

        public IEnumerable<OrganizationTestViewModel> CreateModel(IEnumerable<Test> tests, IEnumerable<AccountNotReviewableTest> accountTests)
        {
            if (accountTests.IsNullOrEmpty()) return null;

            return accountTests.Select(accountTest => tests.First(x => x.Id == accountTest.TestId)).Select(CreateModel).ToList();
        }

        private AccountNotReviewableTest CreateDomain(OrganizationTestViewModel model, long accountId)
        {
            return new AccountNotReviewableTest
            {
                AccountId = accountId,
                TestId = model.Id
            };
        }

        public IEnumerable<AccountNotReviewableTest> CreateDomain(IEnumerable<OrganizationTestViewModel> modelList, long accountId)
        {
            if (modelList.IsNullOrEmpty()) return null;

            var list = modelList.Select(model => CreateDomain(model, accountId)).ToList();

            return list;
        }
    }
}