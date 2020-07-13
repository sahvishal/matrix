using System;
using System.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorEarningAggregateRepository : PersistenceRepository, IMedicalVendorEarningAggregateRepository
    {
        private readonly IMedicalVendorEarningAggregateFactory _medicalVendorEarningAggregateFactory;

        public MedicalVendorEarningAggregateRepository()
        {
            _medicalVendorEarningAggregateFactory = new MedicalVendorEarningAggregateFactory();
        }

        public MedicalVendorEarningAggregateRepository(IPersistenceLayer persistenceLayer, 
            IMedicalVendorEarningAggregateFactory medicalVendorEarningAggregateFactory)
            : base(persistenceLayer)
        {
            _medicalVendorEarningAggregateFactory = medicalVendorEarningAggregateFactory;
        }

        //TODO: SRE
        public MedicalVendorEarningAggregate GetMedicalVendorEarningAggregate(long physicianId, 
            long eventCustomerResultId, bool isActive)
        {
            var medicalVendorEarningInfoTypedView = new MedicalVendorEarningInfoTypedView();
            IRelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(MedicalVendorEarningInfoFields.OrganizationRoleUserId ==
                physicianId);

            //bucket.PredicateExpression.Add(MedicalVendorEarningInfoFields.IsMvmvuserCustomerPayRateActive == isActive);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(medicalVendorEarningInfoTypedView, bucket, false);
            }
            if (medicalVendorEarningInfoTypedView.Rows.Count == 0)
            {
                throw new ObjectNotFoundInPersistenceException<MedicalVendorMedicalVendorUser>(physicianId);
            }
            MedicalVendorEarningInfoRow medicalVendorEarningInfoRow = medicalVendorEarningInfoTypedView.Single();
            long medicalVendorUserEventTestLockId = GetMedicalVendorUserEventTestLockId(physicianId,
                eventCustomerResultId, isActive);
            return _medicalVendorEarningAggregateFactory.CreateMedicalVendorEarningAggregate(medicalVendorEarningInfoRow, 
                medicalVendorUserEventTestLockId);
        }

        // TODO: Move to own repository?
        private long GetMedicalVendorUserEventTestLockId(long physicianId, long eventCustomerResultId, bool isActive)
        {
            var medicalVendorUserEventTestLockEntities = new EntityCollection<EventCustomerEvaluationLockEntity>();

            IRelationPredicateBucket bucket = new RelationPredicateBucket(
                EventCustomerEvaluationLockFields.PhysicianId == physicianId);
            bucket.PredicateExpression.Add(EventCustomerEvaluationLockFields.EventCustomerId == eventCustomerResultId);
            //bucket.PredicateExpression.Add(EventCustomerEvaluationLockFields.IsActive == isActive);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(medicalVendorUserEventTestLockEntities, bucket);
            }

            try
            {
                return medicalVendorUserEventTestLockEntities.FirstOrDefault().PhysicianId;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException(string.Format
                    ("No UserEventTestLock exists for the given PhysicianId {0} and EventCustomerResultId {1}.",
                    physicianId, eventCustomerResultId));
            }
            
        }
    }
}