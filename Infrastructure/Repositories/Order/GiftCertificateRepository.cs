using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Linq;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    [DefaultImplementation(Interface =  typeof(IGiftCertificateRepository))]
    public class GiftCertificateRepository : UniqueItemRepository<GiftCertificate, GiftCertificateEntity>,
        IGiftCertificateRepository
    {
        public GiftCertificateRepository()
            : base(new GiftCertificateMapper())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return GiftCertificateFields.GiftCertificateId; }
        }

        public decimal GetAmountUsedonGiftCertificate(long id)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var gcPayments =linqMetaData.GiftCertificatePayment.Where(gcp => gcp.GiftCertificateId == id).ToArray();
                if (gcPayments.IsNullOrEmpty()) return 0;

                return gcPayments.Sum(gcp => gcp.Amount);
            }
        }

        public bool IsClaimCodeValidForCertificate(string claimCode, int giftCertificateId)
        {            
            var giftCertificate = GetByClaimCode(claimCode);

            if (giftCertificate == null)
                return true;
            if (giftCertificate.Id == giftCertificateId)
                return true;

            return false;
        }


        public GiftCertificate GetByClaimCode(string claimCode)
        {
            return GetByPredicate(new PredicateExpression(GiftCertificateFields.ClaimCode == claimCode)).
                SingleOrDefault();
        }

        public void ActivateGiftCertificate(long id)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new GiftCertificateEntity {IsActive = true};
                var bucket = new RelationPredicateBucket(GiftCertificateFields.GiftCertificateId == id);
                if (myAdapter.UpdateEntitiesDirectly(entity, bucket) == 0)
                    throw new PersistenceFailureException();
            }
        }

    }
}