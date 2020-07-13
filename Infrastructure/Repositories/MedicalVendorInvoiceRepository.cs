using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Impl;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorInvoiceRepository : PersistenceRepository, IMedicalVendorInvoiceRepository
    {
        private readonly IValidator<PhysicianInvoice> _validator;
        private readonly IMedicalVendorInvoiceFactory _medicalVendorInvoiceFactory;
        private readonly IMedicalVendorInvoiceItemFactory _medicalVendorInvoiceItemFactory;

        public MedicalVendorInvoiceRepository()
        {
            _validator = new Validator<PhysicianInvoice>(new MedicalVendorInvoiceValidationRuleFactory());
            _medicalVendorInvoiceFactory = new MedicalVendorInvoiceFactory();
            _medicalVendorInvoiceItemFactory = new MedicalVendorInvoiceItemFactory();
        }

        public MedicalVendorInvoiceRepository(IPersistenceLayer persistenceLayer, IValidator<PhysicianInvoice> validator, 
            IMedicalVendorInvoiceFactory medicalVendorInvoiceFactory, IMedicalVendorInvoiceItemFactory medicalVendorInvoiceItemFactory)
            : base(persistenceLayer)
        {
            _validator = validator;
            _medicalVendorInvoiceFactory = medicalVendorInvoiceFactory;
            _medicalVendorInvoiceItemFactory = medicalVendorInvoiceItemFactory;
        }

        private List<PhysicianInvoice> FetchMedicalVendorInvoices(IRelationPredicateBucket bucket)
        {
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity>();
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(medicalVendorInvoiceEntities, bucket);
                long[] medicalVendorInvoiceIds = medicalVendorInvoiceEntities.Select(i => i.PhysicianInvoiceId).ToArray();
                IRelationPredicateBucket medicalVendorInvoiceItemBucket = new RelationPredicateBucket
                    (PhysicianInvoiceItemFields.PhysicianInvoiceId == medicalVendorInvoiceIds);
                myAdapter.FetchEntityCollection(medicalVendorInvoiceItemEntities, medicalVendorInvoiceItemBucket);
            }
            return _medicalVendorInvoiceFactory.CreateMedicalVendorInvoices(medicalVendorInvoiceEntities, 
                medicalVendorInvoiceItemEntities);
        }

        public List<PhysicianInvoice> GetInvoicesByPaymentStatus(PaymentStatus paymentStatus)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PaymentStatus == paymentStatus);
            return FetchMedicalVendorInvoices(bucket);
        }

        public List<PhysicianInvoice> GetInvoicesForDateRange(DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PayPeriodStartDate <= endDate.GetEndOfDay());
            bucket.PredicateExpression.Add(PhysicianInvoiceFields.PayPeriodEndDate >= startDate);
            return FetchMedicalVendorInvoices(bucket);
        }

        public PhysicianInvoice GetMedicalVendorInvoice(long medicalVendorInvoiceId)
        {
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity(medicalVendorInvoiceId);
            var medicalVendorInvoiceItemEntites = new EntityCollection<PhysicianInvoiceItemEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.FetchEntity(medicalVendorInvoiceEntity))
                {
                    throw new ObjectNotFoundInPersistenceException<PhysicianInvoice>(medicalVendorInvoiceEntity.PhysicianInvoiceId);
                }
                var medicalVendorInvoiceItemBucket = new RelationPredicateBucket
                    (PhysicianInvoiceItemFields.PhysicianInvoiceId == medicalVendorInvoiceEntity.PhysicianInvoiceId);
                myAdapter.FetchEntityCollection(medicalVendorInvoiceItemEntites, medicalVendorInvoiceItemBucket);
            }
            return _medicalVendorInvoiceFactory.CreateMedicalVendorInvoice(medicalVendorInvoiceEntity, medicalVendorInvoiceItemEntites);
        }

        public PhysicianInvoice GetMedicalVendorInvoice(Guid approvalGuid)
        {
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity {ApprovalGuid = approvalGuid};
            var medicalVendorInvoiceItemEntities = new EntityCollection<PhysicianInvoiceItemEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var uniqueConstraintFilter = new PredicateExpression(PhysicianInvoiceFields.ApprovalGuid == approvalGuid);
                if (!myAdapter.FetchEntityUsingUniqueConstraint(medicalVendorInvoiceEntity, uniqueConstraintFilter))
                {
                    throw new ObjectNotFoundInPersistenceException<PhysicianInvoice>(approvalGuid);
                }
                var medicalVendorInvoiceItemBucket = new RelationPredicateBucket
                    (PhysicianInvoiceItemFields.PhysicianInvoiceId == medicalVendorInvoiceEntity.PhysicianInvoiceId);
                myAdapter.FetchEntityCollection(medicalVendorInvoiceItemEntities, medicalVendorInvoiceItemBucket);
            }
            return _medicalVendorInvoiceFactory.CreateMedicalVendorInvoice(medicalVendorInvoiceEntity, medicalVendorInvoiceItemEntities);
        }

        public PhysicianInvoice GetOldestUnapprovedInvoiceForMedicalVendorUser(long medicalVendorMedicalVenderUserId)
        {
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (PhysicianInvoiceFields.PhysicianId == medicalVendorMedicalVenderUserId);
            bucket.PredicateExpression.Add(PhysicianInvoiceFields.ApprovalStatus == ApprovalStatus.Unapproved);
            ISortExpression sortExpression = new SortExpression(PhysicianInvoiceFields.DateGenerated | SortOperator.Ascending);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(medicalVendorInvoiceEntities, bucket, 1, sortExpression);
            }
            return medicalVendorInvoiceEntities.HasSingleItem() ? GetMedicalVendorInvoice(medicalVendorInvoiceEntities.Single().PhysicianInvoiceId) 
                : null;
        }

        public List<OrderedPair<DateTime, DateTime>> GetMedicalVendorInvoicePayPeriods(long organizationRoleUserId, 
            PaymentStatus paymentStatus)
        {
            var payPeriodFields = new ResultsetFields(2);
            payPeriodFields.DefineField(PhysicianInvoiceFields.PayPeriodStartDate, 0);
            payPeriodFields.DefineField(PhysicianInvoiceFields.PayPeriodEndDate, 1);
            var payPeriodsDataTable = new DataTable("Medical Vendor Invoice Pay Periods");
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (PhysicianInvoiceFields.PhysicianId == organizationRoleUserId);
            bucket.PredicateExpression.Add(PhysicianInvoiceFields.PaymentStatus == (byte)paymentStatus);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedList(payPeriodFields, payPeriodsDataTable, bucket, false);
            }

            var payPeriods = new List<OrderedPair<DateTime, DateTime>>();
            foreach (DataRow row in payPeriodsDataTable.Rows)
            {
                var orderedPair = new OrderedPair<DateTime, DateTime>((DateTime) row["PayPeriodStartDate"], 
                    (DateTime)row["PayPeriodEndDate"]);
                payPeriods.Add(orderedPair);
            }
            return payPeriods;
        }

        public void SaveMedicalVendorInvoice(PhysicianInvoice medicalVendorInvoice)
        {
            if (medicalVendorInvoice == null)
            {
                throw new ArgumentNullException("medicalVendorInvoice", "The given MedicalVendorInvoice cannot be null.");
            }

            if (!_validator.IsValid(medicalVendorInvoice))
            {
                throw new InvalidObjectException<PhysicianInvoice>(_validator);
            }

            // TODO: TEST (Integration)
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (PhysicianInvoiceFields.PhysicianId == medicalVendorInvoice.PhysicianId &
                PhysicianInvoiceFields.PayPeriodStartDate <= medicalVendorInvoice.PayPeriodStartDate &
                PhysicianInvoiceFields.PayPeriodEndDate >= medicalVendorInvoice.PayPeriodStartDate);
            bucket.PredicateExpression.AddWithOr(
                PhysicianInvoiceFields.PhysicianId== medicalVendorInvoice.PhysicianId &
                PhysicianInvoiceFields.PayPeriodStartDate <= medicalVendorInvoice.PayPeriodEndDate &
                PhysicianInvoiceFields.PayPeriodEndDate >= medicalVendorInvoice.PayPeriodEndDate);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(medicalVendorInvoiceEntities, bucket);
            }
            if (!medicalVendorInvoiceEntities.IsEmpty())
            {
                throw new OverlappingInvoiceException(medicalVendorInvoice);
            }

            PhysicianInvoiceEntity medicalVendorInvoiceEntity = _medicalVendorInvoiceFactory.
                CreateMedicalVendorInvoiceEntity(medicalVendorInvoice);
            using(var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.StartTransaction(IsolationLevel.ReadCommitted, "MedicalVendorInvoiceRepository.SaveMedicalVendorInvoice");
                try
                {
                    if (!myAdapter.SaveEntity(medicalVendorInvoiceEntity, true))
                    {
                        throw new PersistenceFailureException();
                    }

                    var medicalVendorInvoiceItemEntities = _medicalVendorInvoiceItemFactory.
                        CreateMedicalVendorInvoiceItemEntities(medicalVendorInvoiceEntity.PhysicianInvoiceId,
                        medicalVendorInvoice.MedicalVendorInvoiceItems);

                    if (myAdapter.SaveEntityCollection(medicalVendorInvoiceItemEntities) == 0)
                    {
                        throw new PersistenceFailureException();
                    }
                    myAdapter.Commit();
                }
                catch (Exception)
                {
                    myAdapter.Rollback();
                    throw;
                }
            }
        }

        // TODO: TEST 
        // TODO: Refactor into more efficent DB access.
        public void SaveMedicalVendorInvoices(List<PhysicianInvoice> medicalVendorInvoices)
        {
            foreach (var medicalVendorInvoice in medicalVendorInvoices)
            {
                SaveMedicalVendorInvoice(medicalVendorInvoice);
            }
        }

        // TODO: TEST Set / nullify ApprovalDate (integration -- cannot accomplish via unit).
        public void ChangeMedicalVendorInvoiceApprovalStatus(long medicalVendorInvoiceId, ApprovalStatus approvalStatus)
        {
            DateTime? approvalDate;
            switch(approvalStatus)
            {
                case ApprovalStatus.Approved:
                    approvalDate = DateTime.Now;
                    break;
                case ApprovalStatus.Unapproved:
                    approvalDate = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("approvalStatus", string.Format("ApprovalStatus {0} is invalid.", approvalStatus));
            }

            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity(medicalVendorInvoiceId) 
                { ApprovalStatus = (byte)approvalStatus, DateApproved = approvalDate };
            var bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PhysicianInvoiceId == medicalVendorInvoiceId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // TODO: What if no entities are updated due to a persistence error?
                myAdapter.UpdateEntitiesDirectly(medicalVendorInvoiceEntity, bucket);
            }
        }

        // TODO: TEST date paid being set / nullified (integration -- cannot accomplish via unit).
        public void ChangeMedicalVendorInvoicePaymentStatus(long medicalVendorInvoiceId, PaymentStatus paymentStatus, DateTime datePaid)
        {
            if (paymentStatus != PaymentStatus.Paid && paymentStatus != PaymentStatus.Unpaid)
            {
                throw new ArgumentOutOfRangeException("paymentStatus", string.Format("PaymentStatus {0} is invalid.", paymentStatus));
            }

            DateTime? newDatePaid;
            switch (paymentStatus)
            {
                case PaymentStatus.Paid:
                    newDatePaid = datePaid;
                    break;
                case PaymentStatus.Unpaid:
                    newDatePaid = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("paymentStatus", string.Format("PaymentStatus {0} is invalid.", paymentStatus));
            }

            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity(medicalVendorInvoiceId) 
                { PaymentStatus = (byte)paymentStatus, DatePaid = newDatePaid};
            var bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PhysicianInvoiceId == medicalVendorInvoiceId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // TODO: What if no entities are updated due to a persistence error?
                myAdapter.UpdateEntitiesDirectly(medicalVendorInvoiceEntity, bucket);
            }
        }

        public bool HasInvoicePendingApproval(long medicalVendorMedicalVendorUserId)
        {
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PhysicianId == medicalVendorMedicalVendorUserId);
            bucket.PredicateExpression.Add(PhysicianInvoiceFields.ApprovalStatus == ApprovalStatus.Unapproved);
            
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(medicalVendorInvoiceEntities, bucket);
            }
                     
            return medicalVendorInvoiceEntities.Count > 0;
        }
    }
}