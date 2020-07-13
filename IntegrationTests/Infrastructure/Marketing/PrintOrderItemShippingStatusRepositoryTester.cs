using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.PrintOrder;
using Falcon.App.Infrastructure.Repositories.Users;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    [Ignore("The database must be in a stable state to run these tests.")]
    public class PrintOrderItemShippingStatusRepositoryTester
    {

        //private readonly IPrintOrderItemShippingStatusRepository _repository = new PrintOrderItemShippingRepository();

        //[Test]
        //public void SavePrintOrderItemShippingStatus()
        //{
        //    var organizationRoleUserRepository = new OrganizationRoleUserRepository();
        //    var organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(
        //               29719, 13,1);
        //    var printOrderItemShippingStatus = new PrintOrderItemShippingStatus
        //                                           {
        //                                               ConfirmationMode = ItemConfirmationMode.CallCenter,
        //                                               CreatedDate = DateTime.Now,
        //                                               Notes = "Test for Save",
        //                                               PaymentRecordedBy = organizationRoleUser,
        //                                               PrintOrderItemId = 800,
        //                                               Status = ItemShippingStatus.Assigned


        //                                           };
        //    _repository.Save(printOrderItemShippingStatus);



        //}

        [Test]
        public void AssignPrintOrderToPrintVendor()
        {
            var organizationRoleUser = IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId); ;
            var repository = new PrintOrderRepository();

            repository.AssignPrintOrderToPrintVendor(organizationRoleUser, 550, 1);
        }

        [Test]
        public void UpdatePrintOrderShipping()
        {
            //string sourceCode = "MLEKN728";
            //string notes = "update shipping through PSV file";

            //var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            //var statusUpdatedBy = organizationRoleUserRepository.GetOrganizationRoleUser(
            //    29719, 13, 1);
            //var repository = new PrintOrderRepository();
            ///repository.UpdatePrintOrderShipping(sourceCode, notes, statusUpdatedBy);

        }
        [Test]
        public void ParsePrintOrderShippingPsv()
        {
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var statusUpdatedBy = organizationRoleUserRepository.GetOrganizationRoleUser(1);
            const string filePath = @"C:\Documents and Settings\nitint\Desktop\EmpoweredReport.csv";
            Int32 successRecordCount;
            var repository = new PrintOrderRepository();
            repository.ParsePrintOrderShippingCsv(filePath, statusUpdatedBy, out successRecordCount);

        }
        
        [Test]
        public void GetPrintOrderItem()
        {
            var repository = new PrintOrderItemRepository();
            var printOrderId = 960;
            repository.GetPrintOrderItemDetail(printOrderId);

        }
        [Test]
        public void GetPrintOrderItemTrackingDetailByFilters()
        {
            var repository = new PrintOrderItemTrackingRepository();
            long totalRecord;
            var printOrderItemTracking=  repository.GetPrintOrderItemTrackingDetailByFilters
                (1892,  null, null, null,null,1,10,out totalRecord);
            Assert.IsNotEmpty(printOrderItemTracking);
        }

        [Test]
        public void GetPrintOrderItemTrackingDetail()
        {
            var repository = new PrintOrderItemTrackingRepository();
            long printOrderItemId = 807;
            var printOrderItemTracking = repository.GetPrintOrderItemTrackingDetail
                (printOrderItemId);
            Assert.IsNotNull(printOrderItemTracking);
        }
        [Test]
        public void ConfirmPrintOrderItemStatusByHsc()
        {
            var repository = new PrintOrderItemRepository();

            const string confirmeByName = "Ram lal";
            DateTime confirmationDate = DateTime.Now;
            const string sourceCode = "F1547A";
            var organizationRoleUserRepository = new OrganizationRoleUserRepository();
            var statusUpdatedBy = organizationRoleUserRepository.GetOrganizationRoleUser(1);
            repository.ConfirmPrintOrderItemStatusByHsc(confirmeByName, confirmationDate, sourceCode, statusUpdatedBy);

        }

        [Test]
        public void ValidateParsedFile()
        {
            
            const string filePath = @"C:\Documents and Settings\nitint\Desktop\EmpoweredReport.csv";
            var repository = new PrintOrderRepository();
            repository.ValidateParsedFile(filePath,',');

        }
       

    }
}