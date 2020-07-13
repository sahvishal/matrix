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
    public class LipidTestRepositoryTester
    {
        private ITestResultRepository _testResultRepository;

        private const int CustomerID = 24147;
        private const int EventID = 1420;
        private const int TechnicianID = 180;

        [SetUp]
        public void SetupTest()
        {
            _testResultRepository = new LipidTestRepository();
        }

        [TearDown]
        public void TearDownTest()
        {
            _testResultRepository = null;
        }

        [Test]
        [Ignore]
        public void GetLipidTestResult()
        {
            var lipidTestResult = _testResultRepository.GetTestResults(CustomerID, EventID, false) as LipidTestResult;
            Assert.IsNotNull(lipidTestResult);
        }

        [Test]
        [Ignore]
        public void SaveLipidTestResult()
        {
            var testResult = new LipidTestResult((long)TestType.Lipid)
                                 {
                                     TotalCholestrol = new CompoundResultReading<string>((long)0)
                                       {
                                           Finding = new StandardFinding<string>(6),
                                           Label = ReadingLabels.TotalCholestrol,
                                           Reading = "10",
                                           ReadingSource = ReadingSource.Automatic
                                       },
                                     HDL = new CompoundResultReading<string>((long)0)
                                       {
                                           Finding = new StandardFinding<string>(9),
                                           Label = ReadingLabels.HDL,
                                           Reading = "22",
                                           ReadingSource = ReadingSource.Automatic
                                       },
                                     Glucose = new CompoundResultReading<int?>((long)0)
                                       {
                                           Finding = new StandardFinding<int?>(14),
                                           Label = ReadingLabels.Glucose,
                                           Reading = 33,
                                           ReadingSource = ReadingSource.Automatic
                                       },
                                     LDL = new CompoundResultReading<int?>((long)0)
                                     {
                                         Finding = new StandardFinding<int?>(11),
                                         Label = ReadingLabels.LDL,
                                         Reading = 44,
                                         ReadingSource = ReadingSource.Automatic
                                     },
                                     TriGlycerides = new CompoundResultReading<string>((long)0)
                                     {
                                         Finding = new StandardFinding<string>(17),
                                         Label = ReadingLabels.TriGlycerides,
                                         Reading = "55",
                                         ReadingSource = ReadingSource.Automatic
                                     },
                                     TCHDLRatio = new CompoundResultReading<decimal?>((long)0)
                                     {
                                         Finding = new StandardFinding<decimal?>(20),
                                         Label = ReadingLabels.TCHDLRatio,
                                         Reading = 66,
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