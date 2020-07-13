using Falcon.App.Core.Application;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    public class MergeCustomerTester
    {

        private readonly IMergeCustomerUploadService _mergeCustomerUploadService;
        private readonly IMergeCustomerUploadLogRepository _mergeCustomerUploadLogRepository;
        public MergeCustomerTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            IoC.Register<ISessionContext, FakeSessionContext>(); //override the default impl.
            _mergeCustomerUploadService = IoC.Resolve<IMergeCustomerUploadService>();
            _mergeCustomerUploadLogRepository = IoC.Resolve<IMergeCustomerUploadLogRepository>();
        }

        [Test]
        public void Invalid_CustomerId()
        {

            //arrange
            var mergeCustomerUpload = new MergeCustomerUploadLog
            {
                CustomerId = 175812915,
                DuplicateCustomerId = "abcd,1758129",
            };
            _mergeCustomerUploadService.ParseMergeCustomerLog(mergeCustomerUpload, 1);

           
        }


        [Test]
        public void InvalidDuplicate_CustomerIds()
        {

            //arrange
            var mergeCustomerUpload = new MergeCustomerUploadLog
            {
                CustomerId = 1758129,
                DuplicateCustomerId = "abcd|xyz",
            };
            _mergeCustomerUploadService.ParseMergeCustomerLog(mergeCustomerUpload, 1);
        }

        [Test]
        public void ValidDuplicate_DoesNotMatch()
        {

            //arrange
            var mergeCustomerUpload = new MergeCustomerUploadLog
            {
                CustomerId = 1758129,
                DuplicateCustomerId = "1832909|1118317",
            };
            _mergeCustomerUploadService.ParseMergeCustomerLog(mergeCustomerUpload, 1);
        }

        [Test]
        public void ValidDuplicate_Match()
        {

            //arrange
            var mergeCustomerUpload = new MergeCustomerUploadLog
            {
                CustomerId = 748974,
                DuplicateCustomerId = "727728",
            };
            _mergeCustomerUploadService.ParseMergeCustomerLog(mergeCustomerUpload, 1);
        }

        [Test]
        public void MergeBillingAccount_Match()
        {

            //arrange
            //var mergeCustomerUpload = new MergeCustomerUploadLog
            //{
            //    CustomerId = 1725139,
            //    DuplicateCustomerId = "1596267",
            //};
            _mergeCustomerUploadLogRepository.UpdateCustomerBillingInfo(1725139, 1596267);
        }
    }
}