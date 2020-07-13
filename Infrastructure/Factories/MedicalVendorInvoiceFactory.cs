using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorInvoiceFactory : IMedicalVendorInvoiceFactory
    {
        private readonly IMedicalVendorInvoiceBaseFactory _medicalVendorInvoiceBaseFactory;
        private readonly IMedicalVendorInvoiceItemFactory _medicalVendorInvoiceItemFactory;

        public MedicalVendorInvoiceFactory()
        {
            _medicalVendorInvoiceBaseFactory = new MedicalVendorInvoiceBaseFactory();
            _medicalVendorInvoiceItemFactory = new MedicalVendorInvoiceItemFactory();
        }

        public MedicalVendorInvoiceFactory(IMedicalVendorInvoiceBaseFactory medicalVendorInvoiceBaseFactory, 
            IMedicalVendorInvoiceItemFactory medicalVendorInvoiceItemFactory)
        {
            _medicalVendorInvoiceBaseFactory = medicalVendorInvoiceBaseFactory;
            _medicalVendorInvoiceItemFactory = medicalVendorInvoiceItemFactory;
        }

        public PhysicianInvoice CreateMedicalVendorInvoice(PhysicianInvoiceEntity medicalVendorInvoiceEntity,
            EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities)
        {
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems = _medicalVendorInvoiceItemFactory.
                CreateMedicalVendorInvoiceItems(medicalVendorInvoiceItemEntities);
            return CreateMedicalVendorInvoice(medicalVendorInvoiceEntity, medicalVendorInvoiceItems);
        }

        public PhysicianInvoice CreateNewMedicalVendorInvoice(MedicalVendor medicalVendor, 
            Physician physician, List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems, 
            DateTime payPeriodStartDate, DateTime payPeriodEndDate)
        {
            return new PhysicianInvoice
            {
                ApprovalGuid = Guid.NewGuid(),
                ApprovalStatus = ApprovalStatus.Unapproved,
                DateGenerated = DateTime.Now,
                MedicalVendorAddress = medicalVendor.BusinessAddressId.ToString(),
                MedicalVendorId = medicalVendor.Id,
                MedicalVendorInvoiceItems = medicalVendorInvoiceItems,
                MedicalVendorName = medicalVendor.Name,
                PhysicianId = physician.Id,
                PhysicianName = physician.Name.FullName,
                PaymentStatus = PaymentStatus.Unpaid,
                PayPeriodStartDate = payPeriodStartDate,
                PayPeriodEndDate = payPeriodEndDate
            };
        }

        public PhysicianInvoice CreateMedicalVendorInvoice(PhysicianInvoiceEntity medicalVendorInvoiceEntity,
            List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems)
        {
            if (medicalVendorInvoiceEntity == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceEntity", "The given MedicalVendorInvoiceEntity cannot be null.");
            }
            if (medicalVendorInvoiceItems == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceEntity", "The given list of MedicalVendorInvoiceItems cannot be null.");
            }
            var medicalVendorInvoice = new PhysicianInvoice(medicalVendorInvoiceEntity.PhysicianInvoiceId)
                { MedicalVendorInvoiceItems = medicalVendorInvoiceItems };
            _medicalVendorInvoiceBaseFactory.SetMedicalVendorInvoiceBaseFields(medicalVendorInvoice, medicalVendorInvoiceEntity);
            return medicalVendorInvoice;
        }

        public List<PhysicianInvoice> CreateMedicalVendorInvoices(EntityCollection<PhysicianInvoiceEntity> medicalVendorInvoiceEntities, 
            EntityCollection<PhysicianInvoiceItemEntity> medicalVendorInvoiceItemEntities)
        {
            if (medicalVendorInvoiceEntities == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceEntities", 
                    "The given MedicalVendorInvoiceEntity collection cannot be null.");
            }
            if (medicalVendorInvoiceItemEntities == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItemEntities",
                    "The given MedicalVendorInvoiceItemEntity collection cannot be null.");
            }

            var medicalVendorInvoices = new List<PhysicianInvoice>();
            foreach (var medicalVendorInvoiceEntity in medicalVendorInvoiceEntities)
            {
                var invoiceItemEntitiesForInvoice = new EntityCollection<PhysicianInvoiceItemEntity>
                    (medicalVendorInvoiceItemEntities.Where(i => i.PhysicianInvoiceId == medicalVendorInvoiceEntity.PhysicianId).ToList());
                PhysicianInvoice medicalVendorInvoice = CreateMedicalVendorInvoice(medicalVendorInvoiceEntity, 
                    invoiceItemEntitiesForInvoice);
                medicalVendorInvoices.Add(medicalVendorInvoice);
            }
            return medicalVendorInvoices;
        }

        public PhysicianInvoiceEntity CreateMedicalVendorInvoiceEntity(PhysicianInvoice medicalVendorInvoice)
        {
            if (medicalVendorInvoice == null)
            {
                throw new ArgumentNullException("medicalVendorInvoice");
            }

            return new PhysicianInvoiceEntity
            {
                ApprovalGuid = medicalVendorInvoice.ApprovalGuid,
                ApprovalStatus = (byte)medicalVendorInvoice.ApprovalStatus,
                DateGenerated = medicalVendorInvoice.DateGenerated,
                MedicalVendorAddress = medicalVendorInvoice.MedicalVendorAddress,
                MedicalVendorName = medicalVendorInvoice.MedicalVendorName,
                PhysicianId = medicalVendorInvoice.PhysicianId,
                PhysicianName = medicalVendorInvoice.PhysicianName,
                PaymentStatus = (byte)medicalVendorInvoice.PaymentStatus,
                PayPeriodEndDate = medicalVendorInvoice.PayPeriodEndDate,
                PayPeriodStartDate = medicalVendorInvoice.PayPeriodStartDate,
                DatePaid = medicalVendorInvoice.DatePaid
            };
        }
    }
}
