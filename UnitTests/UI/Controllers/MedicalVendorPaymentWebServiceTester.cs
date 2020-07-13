using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.UI.App.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace HealthYes.Web.UnitTests.UI.Controllers
{
    [TestFixture]
    public class MedicalVendorPaymentWebServiceTester
    {
        private readonly MockRepository _mocks = new MockRepository();
        private IMedicalVendorInvoiceRepository _medicalVendorInvoiceRepository;

        private IMedicalVendorPaymentWebService _service = new MedicalVendorPaymentWebService();

        [SetUp]
        public void SetUp()
        {
            _medicalVendorInvoiceRepository = _mocks.StrictMock<IMedicalVendorInvoiceRepository>();
            _service = new MedicalVendorPaymentWebService(_medicalVendorInvoiceRepository);
        }

        [TearDown]
        public void TearDown()
        {
            _medicalVendorInvoiceRepository = null;
            _service = null;
        }

        [Test]
        public void HasInvoicePendingForApprovalReturnsTrueWhenRepositoryReturnsTrue()
        {
            const long medicalVendorMedicalVendorUserId = 3;
            Expect.Call(_medicalVendorInvoiceRepository.HasInvoicePendingApproval(medicalVendorMedicalVendorUserId)).
                Return(true);

            _mocks.ReplayAll();
            bool hasInvoicePending = _service.HasInvoicesPendingForApproval(medicalVendorMedicalVendorUserId);
            _mocks.VerifyAll();

            Assert.IsTrue(hasInvoicePending);
        }

        [Test]
        public void HasInvoicePendingForApprovalReturnsFalseWhenRepositoryReturnsTrue()
        {
            const long medicalVendorMedicalVendorUserId = 4;
            Expect.Call(_medicalVendorInvoiceRepository.HasInvoicePendingApproval(medicalVendorMedicalVendorUserId)).
                Return(false);

            _mocks.ReplayAll();
            bool hasInvoicePending = _service.HasInvoicesPendingForApproval(medicalVendorMedicalVendorUserId);
            _mocks.VerifyAll();

            Assert.IsFalse(hasInvoicePending);
        }

    }
}