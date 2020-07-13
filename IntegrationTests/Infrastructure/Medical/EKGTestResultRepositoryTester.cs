using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Medical.Impl;
using Falcon.App.Infrastructure.Repositories.Screening;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class EKGTestResultRepositoryTester
    {
        private ITestResultRepository _testResultRepository;

        private const int CUSTOMER_ID = 24147;
        private const int EVENT_ID = 1420;
        private const int EVENT_PACKAGE_ID = 5584;
        private const int TECHNICIAN_ID = 180;

        [SetUp]
        public void SetupTest()
        {
            _testResultRepository = new EKGTestRepository();
        }

        [TearDown]
        public void TearDownTest()
        {
            _testResultRepository = null;
        }


        [Test]
        [Ignore]
        public void SaveEKGTestResults()
        {
            var testResult = new EKGTestResult
                                 {
                                     PRInterval = new ResultReading<decimal?>(4)
                                                      {
                                                          Reading = 11,
                                                          ReadingSource = ReadingSource.Automatic
                                                      },
                                     RRInterval = new ResultReading<int?>(8)
                                                      {
                                                          Reading = 21,
                                                          ReadingSource = ReadingSource.Automatic
                                                      },
                                     VentRate = new ResultReading<int?>(9)
                                                    {
                                                        Reading = 31,
                                                        ReadingSource = ReadingSource.Automatic
                                                    },
                                     QRSDuration = new ResultReading<decimal?>(5)
                                                       {
                                                           Reading = 41,
                                                           ReadingSource = ReadingSource.Automatic
                                                       },
                                     QTInterval = new ResultReading<decimal?>(7)
                                                      {
                                                          Reading = 51,
                                                          ReadingSource = ReadingSource.Automatic
                                                      },
                                     QTDispersion = new ResultReading<int?>(6)
                                                        {
                                                            Reading = 61,
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
                                     Finding =
                                         new StandardFinding<int?>(1) { Description = "", Label = "NORMAL", MaxValue = null, MinValue = null },
                                     ResultStatus = new TestResultState { SelfPresent = true, StateNumber = (int)TestResultStateNumber.ManualEntry, Status = TestResultStatus.Incomplete }

                                 };


            Assert.IsTrue(_testResultRepository.SaveTestResults(testResult, CUSTOMER_ID, EVENT_ID, TECHNICIAN_ID));
        }

        [Test]
        [Ignore]
        public void UpdateEkgTestResult()
        {
            var ekgTestResult = (EKGTestResult)_testResultRepository.GetTestResults(CUSTOMER_ID, EVENT_ID, false);


            ekgTestResult.PRInterval.Reading = 11;
            ekgTestResult.RRInterval.Reading = 21;
            ekgTestResult.VentRate.Reading = 31;
            ekgTestResult.QRSDuration.Reading = 41;
            ekgTestResult.QTInterval.Reading = 51;
            ekgTestResult.QTDispersion = new ResultReading<int?>((long)0)
                                             {
                                                 Reading = 61,
                                                 ReadingSource = ReadingSource.Automatic
                                             };
            ekgTestResult.ResultStatus.SelfPresent = true;
            ekgTestResult.ResultStatus.StateNumber = (int)TestResultStateNumber.ManualEntry;
            ekgTestResult.Finding =
                new StandardFinding<int?>(1) { Description = "", Label = "NORMAL", MaxValue = null, MinValue = null };

            ekgTestResult.IncidentalFindings = new System.Collections.Generic.List<IncidentalFinding> { new IncidentalFinding() { Id = 33 } };


            Assert.IsTrue(_testResultRepository.SaveTestResults(ekgTestResult, CUSTOMER_ID, EVENT_ID, TECHNICIAN_ID));
        }

        [Test]
        [Ignore]
        public void GetEkgTestResult()
        {
            var ekgTestResult = _testResultRepository.GetTestResults(CUSTOMER_ID, EVENT_ID, false) as EKGTestResult;
            Assert.IsNotNull(ekgTestResult);
        }

        //[Test]
        //public void CheckEkgFileParser()
        //{
        //    var ekgFileParser2 = new EkgFileParser2("", EVENT_ID, null);
        //    var result = ekgFileParser2.GetDatafromXml(@"C:\Users\Ashutosh\Desktop\Integra\Ekg\ryan mcginty-1234-0.xml", new EKGTestResult());
        //    Assert.IsTrue(result);
        //}
    }


}