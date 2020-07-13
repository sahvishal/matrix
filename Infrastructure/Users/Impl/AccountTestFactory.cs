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
    public class AccountTestFactory : IAccountTestFactory
    {
        public OrganizationTestEditModel CreateModel(Test test, AccountTest accountTest)
        {
            return new OrganizationTestEditModel
            {
                TestId = test.Id,
                TestName = test.Name,
                Gender = (Gender)test.Gender,
            
            };
        }

        public IEnumerable<OrganizationTestEditModel> CreateModel(IEnumerable<Test> tests, IEnumerable<AccountTest> accountTests)
        {
            if (accountTests.IsNullOrEmpty()) return null;

            var list =
                accountTests.Select(
                    accountTest => CreateModel(tests.FirstOrDefault(x => x.Id == accountTest.TestId), accountTest))
                    .ToList();
            return list;
        }

        public AccountTest CreateDomain(OrganizationTestEditModel model, long accountId)
        {
            return new AccountTest
            {
                AccountId = accountId,
                TestId = model.TestId
            };
        }

        public IEnumerable<AccountTest> CreateDomain(IEnumerable<OrganizationTestEditModel> modelList, long accountId)
        {
            if (modelList.IsNullOrEmpty()) return null;

            var list = modelList.Select(model => new AccountTest
            {
                AccountId = accountId,
                TestId = model.TestId
            }).ToList();

            return list;
        }
    }
}