using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Factories
{
    public class MedicalVendorInvoiceItemFactory : IMedicalVendorInvoiceItemFactory
    {
        private readonly IMedicalVendorMedicalVendorUserFactory _medicalVendorMedicalVendorUserFactory;

        public MedicalVendorInvoiceItemFactory()
            : this(new MedicalVendorMedicalVendorUserFactory())
        {}

        public MedicalVendorInvoiceItemFactory(IMedicalVendorMedicalVendorUserFactory medicalVendorMedicalVendorUserFactory)
        {
            _medicalVendorMedicalVendorUserFactory = medicalVendorMedicalVendorUserFactory;
        }

        public List<MedicalVendorInvoiceItem> CreateMedicalVendorInvoiceItems(IEnumerable<MedicalVendorInvoiceItemRow> 
            medicalVendorInvoiceItemRows)
        {
            if (medicalVendorInvoiceItemRows == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItemRows");
            }

            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>();
            foreach (MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow in medicalVendorInvoiceItemRows)
            {
                if (medicalVendorInvoiceItems.Where(i => i.CustomerId == medicalVendorInvoiceItemRow.CustomerId
                    && i.EventId == medicalVendorInvoiceItemRow.EventId).ToList().IsEmpty())
                {
                    MedicalVendorInvoiceItem medicalVendorInvoiceItem = CreateMedicalVendorInvoiceItem(medicalVendorInvoiceItemRow);
                    medicalVendorInvoiceItems.Add(medicalVendorInvoiceItem);
                }
            }
            return medicalVendorInvoiceItems;
        }

        public MedicalVendorInvoiceItem CreateMedicalVendorInvoiceItem(MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow)
        {
            if (medicalVendorInvoiceItemRow == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItemRow");
            }

            var medicalVendorMedicalVendorUser = _medicalVendorMedicalVendorUserFactory.
                CreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow);
            DateTime? evaluationStartTime = medicalVendorInvoiceItemRow.EvaluationStartTime != DateTime.MinValue ? 
                medicalVendorInvoiceItemRow.EvaluationStartTime : (DateTime?)null;
            DateTime? evaluationEndTime = medicalVendorInvoiceItemRow.EvaluationEndTime != DateTime.MinValue ?
                medicalVendorInvoiceItemRow.EvaluationEndTime : (DateTime?)null;

            IEventCustomerPackageTestDetailService packageTestDetailService = new EventCustomerPackageTestDetailService();

            return new MedicalVendorInvoiceItem
            {
                CustomerId = medicalVendorInvoiceItemRow.CustomerId,
                CustomerName = medicalVendorMedicalVendorUser.Name.FullName,
                EvaluationStartTime = evaluationStartTime,
                EvaluationEndTime = evaluationEndTime,
                EventDate = medicalVendorInvoiceItemRow.EventDate,
                EventId = medicalVendorInvoiceItemRow.EventId,
                EventName = medicalVendorInvoiceItemRow.EventName,
                MedicalVendorAmountEarned = medicalVendorInvoiceItemRow.MedicalVendorAmountEarned,
                MedicalVendorInvoiceId = medicalVendorInvoiceItemRow.OrganizationRoleUserId,
                OrganizationRoleUserAmountEarned = medicalVendorInvoiceItemRow.OrganizationRoleUserAmountEarned,
                PackageName = packageTestDetailService.GetOrderPurchasedString(medicalVendorInvoiceItemRow.EventId, medicalVendorInvoiceItemRow.CustomerId),
                PodId = medicalVendorInvoiceItemRow.PodId,
                PodName = medicalVendorInvoiceItemRow.PodName,
                ReviewDate = medicalVendorInvoiceItemRow.ReviewDate
            };
        }

        public MedicalVendorInvoiceItem CreateMedicalVendorInvoiceItem(PhysicianInvoiceItemEntity medicalVendorInvoiceItemEntity)
        {
            if (medicalVendorInvoiceItemEntity == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItemEntity", "The given MedicalVendorInvoiceItemEntity cannot be null.");
            }

            IEventCustomerPackageTestDetailService packageTestDetailService = new EventCustomerPackageTestDetailService();

            return new MedicalVendorInvoiceItem(medicalVendorInvoiceItemEntity.PhysicianInvoiceItemId)
            {
                MedicalVendorAmountEarned = medicalVendorInvoiceItemEntity.AmountEarned,
                //OrganizationRoleUserAmountEarned = medicalVendorInvoiceItemEntity.OrganizationRoleUserAmountEarned,
                CustomerId = medicalVendorInvoiceItemEntity.CustomerId,
                CustomerName = medicalVendorInvoiceItemEntity.CustomerName,
                EventDate = medicalVendorInvoiceItemEntity.EventDate,
                EventId = medicalVendorInvoiceItemEntity.EventId,
                EventName = medicalVendorInvoiceItemEntity.EventName,
                MedicalVendorInvoiceId = medicalVendorInvoiceItemEntity.PhysicianInvoiceId,
                PackageName = packageTestDetailService.GetOrderPurchasedString(medicalVendorInvoiceItemEntity.EventId, medicalVendorInvoiceItemEntity.CustomerId),
                PodName = medicalVendorInvoiceItemEntity.PodName,
                ReviewDate = medicalVendorInvoiceItemEntity.ReviewDate
            };
        }

        public List<MedicalVendorInvoiceItem> CreateMedicalVendorInvoiceItems(EntityCollection<PhysicianInvoiceItemEntity>
            medicalVendorInvoiceItemEntities)
        {
            if (medicalVendorInvoiceItemEntities == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItemEntities",
                    "The given MedicalVendorInvoiceItem EntityCollection cannot be null.");
            }
            var medicalVendorInvoiceItems = new List<MedicalVendorInvoiceItem>();
            foreach (PhysicianInvoiceItemEntity medicalVendorInvoiceItemEntity in medicalVendorInvoiceItemEntities)
            {
                medicalVendorInvoiceItems.Add(CreateMedicalVendorInvoiceItem(medicalVendorInvoiceItemEntity));
            }
            return medicalVendorInvoiceItems;
        }

        public PhysicianInvoiceItemEntity CreateMedicalVendorInvoiceItemEntity(long medicalVendorInvoiceId,
            MedicalVendorInvoiceItem medicalVendorInvoiceItem)
        {
            if (medicalVendorInvoiceItem == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItem");
            }

            IEventCustomerPackageTestDetailService packageTestDetailService = new EventCustomerPackageTestDetailService();

            return new PhysicianInvoiceItemEntity
            {
                PhysicianInvoiceId = medicalVendorInvoiceId,
                AmountEarned = medicalVendorInvoiceItem.MedicalVendorAmountEarned,
                //OrganizationRoleUserAmountEarned = medicalVendorInvoiceItem.OrganizationRoleUserAmountEarned,
                CustomerId = medicalVendorInvoiceItem.CustomerId,
                CustomerName = medicalVendorInvoiceItem.CustomerName,
                EventDate = medicalVendorInvoiceItem.EventDate,
                EventId = medicalVendorInvoiceItem.EventId,
                EventName = medicalVendorInvoiceItem.EventName,
                PackageName = medicalVendorInvoiceItem.PackageName,
                PodId = medicalVendorInvoiceItem.PodId,
                PodName = medicalVendorInvoiceItem.PodName,
                ReviewDate = medicalVendorInvoiceItem.ReviewDate
            };
        }

        public EntityCollection<PhysicianInvoiceItemEntity> CreateMedicalVendorInvoiceItemEntities
            (long medicalVendorInvoiceId, List<MedicalVendorInvoiceItem> medicalVendorInvoiceItems)
        {
            if (medicalVendorInvoiceItems == null)
            {
                throw new ArgumentNullException("medicalVendorInvoiceItems");
            }

            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            foreach (var medicalVendorInvoiceItem in medicalVendorInvoiceItems)
            {
                var medicalVendorInvoiceItemEntity = CreateMedicalVendorInvoiceItemEntity
                    (medicalVendorInvoiceId, medicalVendorInvoiceItem);
                medicalVendorInvoiceItemEntities.Add(medicalVendorInvoiceItemEntity);
            }
            return medicalVendorInvoiceItemEntities;
        }

    }
}