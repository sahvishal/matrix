using System.Linq;
using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    // [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class SourceCodeRepositoryTester
    {
        const string NONEXISTENT_SOURCE_CODE = "DOESN'T EXIST";
        const string EXISTING_SOURCE_CODE = "FAKE000011";

        [Test]
        public void ValidateSourceCodeReturnsTrueForNonexistentCouponCode()
        {
            ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
            bool isValid = sourceCodeRepository.ValidateSourceCode(NONEXISTENT_SOURCE_CODE);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void ValidateSourceCodeReturnsFalseForExistingCouponCode()
        {
            ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
            bool isValid = sourceCodeRepository.ValidateSourceCode(EXISTING_SOURCE_CODE);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void GetByIdsTest()
        {
            var ids = new long[] { 1, 2, 3, 4 };
            ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
            var collection = sourceCodeRepository.GetSourceCodeByIds(ids);
            Assert.IsNotNull(collection);
        }

        [Test]
        public void SaveSourceCodeSavesNewSourceCode()
        {
            //ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();

            //var sourceCode = new SourceCode { CouponCode = "TESTTESTMK4" };
            //sourceCodeRepository.SaveSourceCode(sourceCode);
        }

        [Test]
        public void GetByFilter_PassingNullfilter_Tester()
        {
            ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
            long totalRecords = 0;
            var records = sourceCodeRepository.GetbyFilter(null, 1, 25, out totalRecords);

            Assert.IsNotNull(records);
            Assert.IsNotEmpty(records.ToArray());
        }

        [Test]
        public void GetByFilter_Tester()
        {
            ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
            long totalRecords = 0;
            var filter = new SourceCodeListModelFilter { SourceCodeName = "Sand" };
            var records = sourceCodeRepository.GetbyFilter(filter, 1, 25, out totalRecords);

            Assert.IsNotNull(records);
            Assert.IsNotEmpty(records.ToArray());
        }
    }
}