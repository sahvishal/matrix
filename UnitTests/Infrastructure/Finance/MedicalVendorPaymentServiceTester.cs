using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class MedicalVendorPaymentServiceTester
    {
        //TODO:REWRITE TESTS
        //private readonly MockRepository _mocks = new MockRepository();
        //private IMedicalVendorRepository _medicalVendorRepository;
        //private IMedicalVendorMedicalVendorUserRepository _medicalVendorMedicalVendorUserRepository;
        //private IMedicalVendorInvoiceItemRepository _medicalVendorInvoiceItemRepository;
        //private IMedicalVendorInvoiceFactory _medicalVendorInvoiceFactory;

        //private IMedicalVendorPaymentService _medicalVendorPaymentService;

        //[SetUp]
        //public void SetUp()
        //{
        //    _medicalVendorRepository = _mocks.StrictMock<IMedicalVendorRepository>();
        //    _medicalVendorMedicalVendorUserRepository = _mocks.StrictMock<IMedicalVendorMedicalVendorUserRepository>();
        //    _medicalVendorInvoiceItemRepository = _mocks.StrictMock<IMedicalVendorInvoiceItemRepository>();
        //    _medicalVendorInvoiceFactory = _mocks.StrictMock<IMedicalVendorInvoiceFactory>();

        //    _medicalVendorPaymentService = new MedicalVendorPaymentService(_medicalVendorRepository,
        //        _medicalVendorMedicalVendorUserRepository, _medicalVendorInvoiceItemRepository,
        //        _medicalVendorInvoiceFactory);
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    _medicalVendorRepository = null;
        //    _medicalVendorMedicalVendorUserRepository = null;
        //    _medicalVendorInvoiceItemRepository = null;
        //    _medicalVendorInvoiceFactory = null;

        //    _medicalVendorPaymentService = null;
        //}

        //private void ExpectGenerateInvoice(long medicalVendorId, IEnumerable<long> organizationRoleUserIds)
        //{
        //    var medicalVendor = new MedicalVendor(medicalVendorId);
        //    var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> { new MedicalVendorInvoiceItem() };
        //    foreach (var organizationRoleUserId in organizationRoleUserIds)
        //    {
        //        var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser(organizationRoleUserId);
        //        ExpectGenerateInvoice(medicalVendor, medicalVendorMedicalVendorUser, new DateTime(),
        //            new DateTime(), medicalVendorInvoiceItems);
        //    }
        //}

        //private void ExpectGenerateInvoice(MedicalVendor medicalVendor, MedicalVendorMedicalVendorUser
        //    medicalVendorMedicalVendorUser, DateTime payPeriodStartDate, DateTime payPeriodEndDate,
        //    List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems)
        //{
        //    Expect.Call(_medicalVendorInvoiceItemRepository.GetMedicalVendorInvoiceItems(medicalVendorMedicalVendorUser.Id,
        //        payPeriodStartDate, payPeriodEndDate)).Return(medicalVendorInvoiceItems);
        //    Expect.Call(_medicalVendorMedicalVendorUserRepository.GetMedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUser.Id))
        //        .Return(medicalVendorMedicalVendorUser);
        //    Expect.Call(_medicalVendorRepository.GetMedicalVendor(medicalVendor.Id))
        //        .Return(medicalVendor);
        //    Expect.Call(_medicalVendorInvoiceFactory.CreateNewMedicalVendorInvoice(medicalVendor, medicalVendorMedicalVendorUser,
        //        medicalVendorInvoiceItems, payPeriodStartDate, payPeriodEndDate)).Return(new MedicalVendorInvoice());
        //}

        //[Test]
        //public void GenerateInvoiceReturnsNullWhenNoInvoiceItemsReturned()
        //{
        //    const int medicalVendorMedicalVendorUserId = 1;
        //    var payPeriodStartDate = new DateTime(2001, 1, 1);
        //    var payPeriodEndDate = payPeriodStartDate.AddDays(1);
        //    var returnedMedicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>();
        //    Expect.Call(_medicalVendorInvoiceItemRepository.GetMedicalVendorInvoiceItems(medicalVendorMedicalVendorUserId, 
        //        payPeriodStartDate, payPeriodEndDate)).Return(returnedMedicalVendorInvoiceItems);

        //    _mocks.ReplayAll();
        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorPaymentService.GenerateInvoice
        //        (1, medicalVendorMedicalVendorUserId, payPeriodStartDate, payPeriodEndDate);
        //    _mocks.VerifyAll();

        //    Assert.IsNull(medicalVendorInvoice, "Non-null object returned when no medical vendor invoice items found.");
        //}

        //[Test]
        //public void GenerateInvoiceReturnsNonNullObjectWhenInvoiceItemsAreReturned()
        //{
        //    const int medicalVendorId = 2;
        //    const int medicalVendorMedicalVendorUserId = 1;
        //    var payPeriodStartDate = new DateTime(2001, 1, 1);
        //    var payPeriodEndDate = payPeriodStartDate.AddDays(1);

        //    var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem> {new MedicalVendorInvoiceItem()};
        //    var medicalVendorMedicalVendorUser = new MedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserId)
        //        {Name = new Name()};
        //    var medicalVendor = new MedicalVendor(medicalVendorId)
        //        {BusinessAddressId = new Address(), Name = "BusinessName"};

        //    ExpectGenerateInvoice(medicalVendor, medicalVendorMedicalVendorUser, payPeriodStartDate, payPeriodEndDate, 
        //        medicalVendorInvoiceItems);

        //    _mocks.ReplayAll();
        //    MedicalVendorInvoice medicalVendorInvoice = _medicalVendorPaymentService.GenerateInvoice
        //        (medicalVendorId, medicalVendorMedicalVendorUserId, payPeriodStartDate, payPeriodEndDate);
        //    _mocks.VerifyAll();

        //    Assert.IsNotNull(medicalVendorInvoice, "Null object returned when medical vendor invoice items were found.");
        //}

        //[Test]
        //public void GenerateInvoicesForMedicalVendorReturnsEmptyListWhenNoOrganizationRoleUsersFound()
        //{
        //    const long medicalVendorId = 2;
        //    Expect.Call(_medicalVendorMedicalVendorUserRepository.GetMedicalVendorMedicalVendorUserIds
        //        (medicalVendorId, Roles.MedicalVendorUser)).Return(new List<long>());

        //    _mocks.ReplayAll();
        //    List<MedicalVendorInvoice> medicalVendorInvoices = _medicalVendorPaymentService.
        //        GenerateInvoicesForMedicalVendor(medicalVendorId, new DateTime(), new DateTime());
        //    _mocks.VerifyAll();

        //    Assert.IsNotNull(medicalVendorInvoices);
        //    Assert.IsEmpty(medicalVendorInvoices);
        //}

        //[Test]
        //public void GenerateInvoicesForMedicalVendorReturnsOneInvoiceWhenOneOrganizationRoleUserFound()
        //{
        //    const long medicalVendorId = 2;
        //    var organizationRoleUserIds = new List<long> {1};
        //    Expect.Call(_medicalVendorMedicalVendorUserRepository.GetMedicalVendorMedicalVendorUserIds
        //        (medicalVendorId, Roles.MedicalVendorUser)).Return(organizationRoleUserIds);
        //    ExpectGenerateInvoice(medicalVendorId, organizationRoleUserIds);

        //    _mocks.ReplayAll();
        //    List<MedicalVendorInvoice> medicalVendorInvoices = _medicalVendorPaymentService.
        //        GenerateInvoicesForMedicalVendor(medicalVendorId, new DateTime(), new DateTime());
        //    _mocks.VerifyAll();

        //    Assert.IsTrue(medicalVendorInvoices.HasSingleItem());
        //}

        //[Test]
        //public void GenerateInvoicesForMedicalVendorReturnsThreeInvoicesWhenThreeOrganizationRoleUsersFound()
        //{
        //    const long medicalVendorId = 2;
        //    var organizationRoleUserIds = new List<long> { 1, 4, 6 };
        //    Expect.Call(_medicalVendorMedicalVendorUserRepository.GetMedicalVendorMedicalVendorUserIds
        //        (medicalVendorId, Roles.MedicalVendorUser)).Return(organizationRoleUserIds);
        //    ExpectGenerateInvoice(medicalVendorId, organizationRoleUserIds);

        //    _mocks.ReplayAll();
        //    List<MedicalVendorInvoice> medicalVendorInvoices = _medicalVendorPaymentService.
        //        GenerateInvoicesForMedicalVendor(medicalVendorId, new DateTime(), new DateTime());
        //    _mocks.VerifyAll();

        //    Assert.IsTrue(medicalVendorInvoices.Count == 3);
        //}

        //[Test]
        //public void GenerateInvoicesForMedicalVendorReturnsEmptyListWhenNoUsersHaveItems()
        //{
        //    const long medicalVendorId = 2;
        //    var organizationRoleUserIds = new List<long> { 1, 4, 6 };
        //    Expect.Call(_medicalVendorMedicalVendorUserRepository.GetMedicalVendorMedicalVendorUserIds
        //        (medicalVendorId, Roles.MedicalVendorUser)).Return(organizationRoleUserIds);
        //    foreach (var organizationRoleUserId in organizationRoleUserIds)
        //    {
        //        Expect.Call(_medicalVendorInvoiceItemRepository.GetMedicalVendorInvoiceItems(organizationRoleUserId,
        //            new DateTime(), new DateTime())).Return(new List<MedicalVendorInvoiceItem>());
        //    }

        //    _mocks.ReplayAll();
        //    List<MedicalVendorInvoice> medicalVendorInvoices = _medicalVendorPaymentService.
        //        GenerateInvoicesForMedicalVendor(medicalVendorId, new DateTime(), new DateTime());
        //    _mocks.VerifyAll();

        //    Assert.IsTrue(medicalVendorInvoices.IsEmpty());
        //}

        //[Test]
        //public void GenerateInvoicesForMedicalVendorReturnsTwoInvoicesWhenThreeUsersFoundTwoWithInvoiceItems()
        //{
        //    const long medicalVendorId = 2;
        //    var organizationRoleUserIds = new List<long> { 1, 4, 6 };
        //    Expect.Call(_medicalVendorMedicalVendorUserRepository.GetMedicalVendorMedicalVendorUserIds
        //        (medicalVendorId, Roles.MedicalVendorUser)).Return(organizationRoleUserIds);
        //    ExpectGenerateInvoice(medicalVendorId, organizationRoleUserIds.Take(2));
        //    Expect.Call(_medicalVendorInvoiceItemRepository.GetMedicalVendorInvoiceItems(organizationRoleUserIds.Last(),
        //        new DateTime(), new DateTime())).Return(new List<MedicalVendorInvoiceItem>());

        //    _mocks.ReplayAll();
        //    List<MedicalVendorInvoice> medicalVendorInvoices = _medicalVendorPaymentService.
        //        GenerateInvoicesForMedicalVendor(medicalVendorId, new DateTime(), new DateTime());
        //    _mocks.VerifyAll();

        //    Assert.IsTrue(medicalVendorInvoices.Count == 2);
        //}
    }
}