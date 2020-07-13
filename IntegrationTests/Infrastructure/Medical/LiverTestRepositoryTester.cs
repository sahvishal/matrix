using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class LiverTestRepositoryTester
    {
        private const int CustomerID = 24147;
        private const int EventID = 1420;
        private const int TechnicianID = 180;

        private ITestResultRepository _testResultRepository;

        [SetUp]
        public void SetupTest()
        {
            _testResultRepository = new LiverTestRepository();
        }

        [TearDown]
        public void TearDownTest()
        {
            _testResultRepository = null;
        }

        [Test]
        [Ignore]
        public void GetLiverTestResult()
        {
            var liverTestResult = _testResultRepository.GetTestResults(CustomerID, EventID, false) as LiverTestResult;
            Assert.IsNotNull(liverTestResult);
        }

        [Test]
        [Ignore]
        public void SaveLiverTestResult()
        {
            var testResult = new LiverTestResult((long)TestType.Liver)
                                 {
                                     ALT = new CompoundResultReading<int?>((long)0)
                                               {
                                                   Finding = new StandardFinding<int?>(6),
                                                   Label = ReadingLabels.ASI,
                                                   Reading = 11,
                                                   ReadingSource = ReadingSource.Automatic
                                               },
                                     AST = new CompoundResultReading<int?>((long)0)
                                               {
                                                   Finding = new StandardFinding<int?>(6),
                                                   Label = ReadingLabels.AST,
                                                   Reading = 12,
                                                   ReadingSource = ReadingSource.Automatic
                                               },
                                     DataRecorderMetaData = new DataRecorderMetaData
                                                                {
                                                                    DataRecorderCreator = new OrganizationRoleUser
                                                                                              {
                                                                                                  UserId = 1058,
                                                                                                  RoleId = 8,
                                                                                                  OrganizationId = 1
                                                                                              },
                                                                    DataRecorderModifier = new OrganizationRoleUser
                                                                                               {
                                                                                                   UserId = 1058,
                                                                                                   RoleId = 8,
                                                                                                   OrganizationId = 1
                                                                                               },
                                                                    DateCreated = DateTime.Now,
                                                                    DateModified = DateTime.Now
                                                                },
                                     ResultStatus = new TestResultState { SelfPresent = true, StateNumber = (int)TestResultStateNumber.ManualEntry, Status = TestResultStatus.Incomplete }

                                 };
            Assert.IsTrue(_testResultRepository.SaveTestResults(testResult, CustomerID, EventID, 12));
        }




    }
}