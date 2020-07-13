using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class PodRepositoryTester
    {
        private const long SALES_REP_ID_WITH_PODS = 172;
        private const long POD_ID = 1;
        private readonly IPodRepository _podRepository = new PodRepository();


        [SetUp]
        public void Init()
        { 
            IoC.Register<IUniqueItemRepository<Pod>, PodRepository>(); 
        }


        [Test]
        public void GetAllPodsReturnsPods()
        {
            List<Pod> allPods = _podRepository.GetAllPods();

            Assert.IsNotNull(allPods, "Null collection of Pods returned.");
            Assert.IsNotEmpty(allPods, "Empty collection of pods returned.");
        }

        [Test]
        public void GetPodsAssignedToSalesRepReturnsPods()
        {
            List<Pod> pods = _podRepository.GetPodsAssignedToSalesRep(SALES_REP_ID_WITH_PODS);

            Assert.IsNotNull(pods, "Null collection of Pods returned.");
            Assert.IsNotEmpty(pods, "Empty collection of pods returned.");
        }

        [Test]
        public void AssignPodToSalesRepSavesNewEntity()
        {
            bool saveSuccessful = _podRepository.AssignPodToSalesRep(POD_ID, SALES_REP_ID_WITH_PODS);

            Assert.IsTrue(saveSuccessful, "Persistence of Sales Rep Pod Assignment failed.");
        }

        [Test]
        public void UnassignPodFromSalesRepDeletesEntity()
        {
            bool deletionSuccessful = _podRepository.UnassignPodFromSalesRep(POD_ID, SALES_REP_ID_WITH_PODS);

            Assert.IsTrue(deletionSuccessful, "Unassignment of Pod from Sales Rep failed.");
        }

        [Test]
        public void GetByIdPodTester()
        {
            var pod = IoC.Resolve<IUniqueItemRepository<Pod>>().GetById(POD_ID);
            Assert.IsNotNull(pod);
        }

        [Test]
        public void SavePodTester()
        {
            var pod = IoC.Resolve<IUniqueItemRepository<Pod>>().GetById(POD_ID);
            pod.Description = "ChangeSomething";
            pod = IoC.Resolve<IUniqueItemRepository<Pod>>().Save(pod);
            Assert.AreSame("ChangeSomething",pod.Description);
        }


    }
}