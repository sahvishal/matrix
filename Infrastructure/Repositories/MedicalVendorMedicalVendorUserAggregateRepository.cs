using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorMedicalVendorUserAggregateRepository : PersistenceRepository, IMedicalVendorMedicalVendorUserAggregateRepository
    {
        private readonly IMedicalVendorMedicalVendorUserRepository _medicalVendorMedicalVendorUserRepository;
        private readonly IMedicalVendorMedicalVendorUserAggregateFactory _medicalVendorMedicalVendorUserAggregateFactory;

        public MedicalVendorMedicalVendorUserAggregateRepository()
        {
            _medicalVendorMedicalVendorUserRepository = new MedicalVendorMedicalVendorUserRepository();
            _medicalVendorMedicalVendorUserAggregateFactory = new MedicalVendorMedicalVendorUserAggregateFactory();
        }

        public MedicalVendorMedicalVendorUserAggregateRepository(IPersistenceLayer persistenceLayer, 
            IMedicalVendorMedicalVendorUserRepository medicalVendorMedicalVendorUserRepository,
            IMedicalVendorMedicalVendorUserAggregateFactory medicalVendorMedicalVendorUserAggregateFactory)
            : base(persistenceLayer)
        {
            _medicalVendorMedicalVendorUserRepository = medicalVendorMedicalVendorUserRepository;
            _medicalVendorMedicalVendorUserAggregateFactory = medicalVendorMedicalVendorUserAggregateFactory;
        }

        public List<MedicalVendorMedicalVendorUserAggregate> GetMedicalVendorMedicalVendorUserAggregates(long medicalVendorId)
        {
            List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers = _medicalVendorMedicalVendorUserRepository
                .GetMedicalVendorMedicalVendorUsersForMedicalVendor(medicalVendorId);

            var medicalVendorMedicalVendorUserEarningAndPayRateView = new MedicalVendorMvuserEarningAndPayRateTypedView();
            IRelationPredicateBucket earningBucket = new RelationPredicateBucket(MedicalVendorMvuserEarningAndPayRateFields
                .OrganizationId == medicalVendorId);
            var medicalVendorMedicalVendorUserPaymentView = new MedicalVendorMvuserPaymentTypedView();
            IRelationPredicateBucket paymentBucket = new RelationPredicateBucket(MedicalVendorMvuserPaymentFields
                .OrganizationId == medicalVendorId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(medicalVendorMedicalVendorUserEarningAndPayRateView, earningBucket, false);
                myAdapter.FetchTypedView(medicalVendorMedicalVendorUserPaymentView, paymentBucket, false);
            }
            
            return _medicalVendorMedicalVendorUserAggregateFactory.CreateMedicalVendorMedicalVendorUserAggregates
                (medicalVendorMedicalVendorUsers, medicalVendorMedicalVendorUserEarningAndPayRateView, 
                medicalVendorMedicalVendorUserPaymentView);
        }
    }
}