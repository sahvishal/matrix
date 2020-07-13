using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorMedicalVendorUserRepository : PersistenceRepository, IMedicalVendorMedicalVendorUserRepository
    {
        private readonly IMedicalVendorMedicalVendorUserFactory _medicalVendorMedicalVendorUserFactory;

        public MedicalVendorMedicalVendorUserRepository()
        {
            _medicalVendorMedicalVendorUserFactory = new MedicalVendorMedicalVendorUserFactory();
        }

        public MedicalVendorMedicalVendorUserRepository(IPersistenceLayer persistenceLayer, 
            IMedicalVendorMedicalVendorUserFactory medicalVendorMedicalVendorUserFactory)
            : base(persistenceLayer)
        {
            _medicalVendorMedicalVendorUserFactory = medicalVendorMedicalVendorUserFactory;
        }

        public List<MedicalVendorMedicalVendorUser> GetMedicalVendorMedicalVendorUsersForMedicalVendor(long medicalVendorId)
        {
            var medicalVendorMedicalVendorUserTypedView = new MedicalVendorMedicalVendorUserTypedView();
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (MedicalVendorMedicalVendorUserFields.OrganizationId == medicalVendorId);
            bucket.PredicateExpression.Add(MedicalVendorMedicalVendorUserFields.IsActive == true);
            bucket.PredicateExpression.Add(MedicalVendorMedicalVendorUserFields.RoleName == Roles.MedicalVendorUser.ToString());

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(medicalVendorMedicalVendorUserTypedView, bucket, false);
            }

            return _medicalVendorMedicalVendorUserFactory.CreateMedicalVendorMedicalVendorUsers
                (medicalVendorMedicalVendorUserTypedView);
        }


        

    }
}