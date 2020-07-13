using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;
using Falcon.App.Core.Medical;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class TestResultRepositoryTester
    {
        private ITestResultRepository _testResultRepository;
        private IMedicareQuestionRepository _medicareQuestionRepository;
        private const long ValidEventId = 24344;
        private const long ValidCustomerId = 467374;


        public TestResultRepositoryTester()
        {
            _testResultRepository = new TestResultRepository();
        }

        [SetUp]
        public void SetUp()
        {
            IoC.Register<ISettings, FakeSettings>();
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _medicareQuestionRepository = IoC.Resolve<MedicareQuestionRepository>();
        }

        [Test]
        public void GetAllMedicareQuestions_Tester()
        {
            _medicareQuestionRepository.GetAllQuestions();
            //var media = _testResultRepository.GetTestMedia(ValidEventId, ValidCustomerId);

            //Assert.IsNotNull(media);
            //Assert.IsNotEmpty(media.ToArray());


        }

        [Test]
        public void GetAllMediaforValidEventIdAndCustomerId_Tester()
        {

            //var media = _testResultRepository.GetTestMedia(ValidEventId, ValidCustomerId);

            //Assert.IsNotNull(media);
            //Assert.IsNotEmpty(media.ToArray());


        }

    }
}